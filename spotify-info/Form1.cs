using CSCore;
using CSCore.SoundIn;
using CSCore.Codecs.WAV;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spotify_info
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void form_Load(object sender, EventArgs e)
        {

        }

        #region Process/Window
        // Get the process of the window currently in focus
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        // Get the window name of a process
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        // Handle to store the process handle of the spotify process
        public IntPtr handle;
        // Get the window name of the spotify process
        private string GetWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        #endregion

        // When pressed, you have 5 seconds to focus the spotif application window
        private void btn_getProcess_Click(object sender, EventArgs e)
        {
            Task getProcessTask = new Task(get_Process);
            getProcessTask.Start();
        }

        private void get_Process()
        {
            // Delay to wait for to focus the spotify application in ms
            int delay = 5000;
            // Wait for delay
            for (int i = 0; i < delay; i += delay / 100)
            {
                Thread.Sleep(delay / 100);
                prog_getspotifyprocess.Invoke((MethodInvoker)delegate
                {
                    prog_getspotifyprocess.Value = prog_getspotifyprocess.Value + 1 % 100;
                });
            }

            // Get process handle of active window
            handle = GetForegroundWindow();
            // Change the text of the button to the window name
            btn_getProcess.Invoke((MethodInvoker)delegate
            {
                btn_getProcess.Text = "Task name: " + GetWindowTitle();
            });
        }

        // Manually update currently playing information
        private void btn_updateCurrentlyPlaying_Click(object sender, EventArgs e)
        {
            update_currently_playing();
        }

        currentlyplaying currentlyplaying_;
        private void update_currently_playing()
        {
            // Get curretly playing object
            currentlyplaying_ = get_Currently_Playing();
            if (currentlyplaying_.item != null)
            {
                // Set Track name label to track name
                lbl_cTrackName.Invoke((MethodInvoker)delegate
                {
                    lbl_cTrackName.Text = currentlyplaying_.item.name;
                });
                // Put list of artists into a string and set as text for Track artists label
                lbl_cTrackArtist.Invoke((MethodInvoker)delegate
                {
                    lbl_cTrackArtist.Text = String.Join(", ", currentlyplaying_.item.artists.Select(p => p.name).ToArray());
                });
                // Display cover in picture box
                pic_Cover.Invoke((MethodInvoker)delegate
                {
                    pic_Cover.Load(currentlyplaying_.item.album.images[0].url);
                });
            }
        }

        // Token for Spotify API
        string oAuthToken = "BQDGW5FQN7kU8zx5lIZq54k5Qjxs33PFKWKRpjibeI8sigPbFbxOmNBEfJMKR3CmLudkxR9_sqLhCFkMpr13lKCPSvOqtMBDHSZU6r-ozIgSpBJXCFQ25fma_gvmkC10CAa_cgCFmU8";

        // Returns a currently playing object with all of the available information on the currently playing track
        private currentlyplaying get_Currently_Playing()
        {
            // Create an api request
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/me/player/currently-playing?market=ES");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + oAuthToken);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                // Parse the returned json to a c# object
                string response = streamReader.ReadToEnd();
                currentlyplaying currentlyplaying_ = Newtonsoft.Json.JsonConvert.DeserializeObject<currentlyplaying>(response);

                return currentlyplaying_;
            }

        }

        // This will check if spotify started playing a new song
        private void song_change_listener()
        {
            while (listen)
            {
                // Get current window title of active window
                string title = GetWindowTitle();
                // Wait for the title to change, check 10 times per second
                while (title == GetWindowTitle())
                {
                    Thread.Sleep(100);
                }
                // MessageBox.Show("New song");
                for (int i = 0; i < 2; i++)
                {
                    Task.Delay(600);
                    update_currently_playing();
                }

            }
        }

        bool listen = false;
        private void btn_toggleListener_Click(object sender, EventArgs e)
        {
            if (listen == false)
            {
                listen = true;
                Task listenTask = new Task(song_change_listener);
                listenTask.Start();
            }
            else
            {
                listen = false;
            }
        }

        DB_Handler DB_Handler = new DB_Handler();
        private void btn_connectDB_Click(object sender, EventArgs e)
        {
            // DB_Handler dB_Handler = new DB_Handler();
            updateHostPort();
            bool live = DB_Handler.testConnection();
            if (live)
            {
                btn_connectDB.BackColor = Color.LightGreen;
            } else
            {
                btn_connectDB.BackColor = Color.IndianRed;
            }
        }

        private void btn_dbInsertCurrent_Click(object sender, EventArgs e)
        {
            DB_Handler.insertSong(currentlyplaying_, "C:", false, DateTime.Now);
        }

        private void txt_accessToken_Click(object sender, EventArgs e)
        {
            txt_accessToken.Text = "";
        }

        private void txt_accessToken_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://developer.spotify.com/console/get-users-currently-playing-track/?market=");
        }

        // Keep track if a path (To save the files to) has been specified
        bool pathSpecified = false;
        // String for the path to save the files to
        string path = "";
        // Keep track if local database should be used (Requires MongoDB installed)
        bool useLocalDB = false;
        private void btn_toggleRecord_Click(object sender, EventArgs e)
        {
            if (!pathSpecified)
            {
                MessageBox.Show("Please select a folder to save the files in.");
            } else
            {
                if (stopRecording)
                {
                    stopRecording = false;
                    Task t = new Task(loopRecord);
                    t.Start();
                } else
                {
                    stopRecording = true;
                }
            }
        }

        bool stopRecording = true;
        void loopRecord()
        {
            // Get current window title of active window
            string title = GetWindowTitle();
            // Wait for the title to change, check 10 times per second
            while (title == GetWindowTitle())
            {
                Thread.Sleep(100);
            }
            while (!stopRecording)
            {
                using (WasapiCapture capture = new WasapiLoopbackCapture())
                {

                    string filename = GetWindowTitle();

                    //rtxt_songlist.Invoke((MethodInvoker)delegate {
                    //    // Running on the UI thread
                    //    rtxt_songlist.Text += filename + "\n";
                    //});

                    // rtxt_songlist.Text += filename + "\n";
                    foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    {
                        filename = filename.Replace(c, '_');
                    }



                    //initialize the selected device for recording
                    capture.Initialize();

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //create a wavewriter to write the data to
                    using (WaveWriter w = new WaveWriter(path + "\\" + filename + ".wav", capture.WaveFormat))
                    {
                        //setup an eventhandler to receive the recorded data
                        capture.DataAvailable += (s, E) =>
                        {
                            //save the recorded audio
                            w.Write(E.Data, E.Offset, E.ByteCount);
                        };

                        //start recording
                        capture.Start();

                        //for (int i = 0; i < 100; i++)
                        //{
                        //    Thread.Sleep(time / 100);
                        //    prog_recording.Value = 1 * i;
                        //}

                        // Get current window title of active window
                        string newTitle = GetWindowTitle();
                        // Wait for the title to change, check 10 times per second
                        while (newTitle == GetWindowTitle())
                        {
                            Thread.Sleep(100);
                        }

                        // Thread.Sleep(time);


                        //stop recording
                        capture.Stop();
                    }
                }

                if (title == GetWindowTitle())
                {
                    stopRecording = true;
                }
            }
            MessageBox.Show("Recording session complete.");
        }

        private void btn_selectdFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                    pathSpecified = true;
                    btn_selectdFolder.Text = path;
                }
            }
        }

        private void btn_useLocalDatabase_Click(object sender, EventArgs e)
        {
            updateHostPort();
            // If currently the local db isn't used
            if (!useLocalDB)
            {
                // If there is a mongoDB service running on localhost
                if (DB_Handler.testConnection())
                {
                    btn_useLocalDatabase.BackColor = Color.LightGreen;
                    useLocalDB = true;
                } else
                {
                    btn_useLocalDatabase.BackColor = Color.IndianRed;
                    MessageBox.Show("Connection to local database could not be established.");
                }
            } else
            {
                useLocalDB = false;
                btn_useLocalDatabase.BackColor = Color.FromArgb(30, 30, 30);
            }
        }
            
        void updateHostPort()
        {
            DB_Handler.host = txt_dbHost.Text;
            DB_Handler.port = txt_dbPort.Text;
        }
    }

    class DB_Handler
    {
        string database_name = "spotify_downloader";
        string collection_name = "songs";
        public string host = "localhost";
        public string port = "27017";
        public bool testConnection()
        {
            var client = new MongoClient("mongodb://" + host + ":" + port + "");
            var db = client.GetDatabase(database_name);
            bool live = db.RunCommandAsync((Command<BsonDocument>)"{ping:1}")
                .Wait(1000);
            return live;

            // var coll = db.GetCollection<currentlyplaying>(collection_name);
            // var document = new currentlyplaying();
            // coll.InsertOne(document);
        }

        // Tests if song already exists in database
        bool doesExist(string id)
        {

            return false;
        }

        // Inserts song into database
        public void insertSong(currentlyplaying currentlyplaying_, string path_, bool downloaded_, DateTime dateTime_)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase(database_name);
            var coll = db.GetCollection<song>(collection_name);
            var document = new song();
            document.song_info = currentlyplaying_;
            document.local_Info = new song.Local_info();
            document.local_Info.path = path_;
            document.local_Info.downloaded = downloaded_;
            document.local_Info.time = dateTime_;
            coll.InsertOne(document);
        }

    }


}
