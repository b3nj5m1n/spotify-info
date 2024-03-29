﻿using CSCore.Codecs.WAV;
using CSCore.SoundIn;
using MongoDB.Bson;
using MongoDB.Driver;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
            if (DB_Handler.testConnection())
            {
                btn_connectDB.BackColor = Color.LightGreen;
                useLocalDB = true;
                btn_useLocalDatabase.BackColor = Color.LightGreen;
                settings s = DB_Handler.loadSettings();
                if (s != null)
                {
                    txt_clientID.Text = s.Client_id;
                    txt_secretID.Text = s.Secret_id;
                    txt_dbHost.Text = s.Host;
                    txt_dbPort.Text = s.Port;
                    txt_accessToken.Text = s.oAuthToken;
                    oAuthToken = s.oAuthToken;
                    token = new Token();
                    token.RefreshToken = s.refreshToken;
                    auth = new AuthorizationCodeAuth(
                        _clientId,
                        _secretId,
                        "http://localhost:4002",
                        "http://localhost:4002",
                        Scope.UserReadCurrentlyPlaying | Scope.UserReadPlaybackState | Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative | Scope.UserReadEmail | Scope.UserReadPrivate
                    );
                    path = s.Path;
                    if (Directory.Exists(path))
                    {
                        pathSpecified = true;
                        btn_selectdFolder.Text = path;
                    }
                    refreshToken();
                    resetExpires();
                }
            }
        }

        int timePassed = 0;
        // Access token will be renewed every 20 minutes
        int threshold = 60 * 20;//60 * 50;
        void resetExpires()
        {
            timePassed = 0;
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
        private string GetWindowTitleByHandle(IntPtr h)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);

            if (GetWindowText(h, Buff, nChars) > 0)
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
        string original_window_name = "";
        private void get_Process()
        {
            //// Delay to wait for to focus the spotify application in ms
            //int delay = 2500;
            //// Wait for delay
            //for (int i = 0; i < delay; i += delay / 100)
            //{
            //    Thread.Sleep(delay / 100);
            //    prog_getspotifyprocess.Invoke((MethodInvoker)delegate
            //    {
            //        prog_getspotifyprocess.Value = (prog_getspotifyprocess.Value + 1) % 100;
            //    });
            //}

            // Get process handle of active window
            //handle = GetForegroundWindow();

            if (!foundTask)
            {
                // Get all the processes named spotify and look for one with an open window
                foreach (Process process in Process.GetProcessesByName("Spotify"))
                {
                    if (GetWindowTitleByHandle(process.MainWindowHandle) != null)
                    {
                        handle = process.MainWindowHandle;
                    }
                }
            ;
                // Change the text of the button to the window name
                btn_getProcess.Invoke((MethodInvoker)delegate
                {
                    btn_getProcess.Text = "Task name: " + GetWindowTitle();
                });
                foundTask = true;
                original_window_name = GetWindowTitle();
            }
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
            if (currentlyplaying_ != null)
            {
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
                    try
                    {
                        // Display cover in picture box
                        pic_Cover.Invoke((MethodInvoker)delegate
                        {
                            pic_Cover.Load(currentlyplaying_.item.album.images[0].url);
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        // Token for Spotify API
        string oAuthToken = "";

        // Returns a currently playing object with all of the available information on the currently playing track
        private currentlyplaying get_Currently_Playing()
        {
            if (oAuthToken != "")
            {
                // Create an api request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/me/player/currently-playing?market=ES");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + txt_accessToken.Text); // oAuthToken);

                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        // Parse the returned json to a c# object
                        string response = streamReader.ReadToEnd();
                        currentlyplaying currentlyplaying_ = Newtonsoft.Json.JsonConvert.DeserializeObject<currentlyplaying>(response);

                        return currentlyplaying_;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Access token required.");
                return null;
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
                    updateWindowNameDisplay();
                }

            }
        }

        private void updateWindowNameDisplay()
        {

            if (GetWindowTitle() != original_window_name)
            {
                btn_getProcess.Invoke((MethodInvoker)delegate
                {
                    btn_getProcess.Text = original_window_name + ": " + GetWindowTitle();
                });
            }
            else
            {
                btn_getProcess.Invoke((MethodInvoker)delegate
                {
                    btn_getProcess.Text = original_window_name;
                });
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
            }
            else
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
            // txt_accessToken.Text = "";
        }

        private void txt_accessToken_DoubleClick(object sender, EventArgs e)
        {
            // System.Diagnostics.Process.Start("https://developer.spotify.com/console/get-users-currently-playing-track/?market=");
        }

        // Keep track if a path (To save the files to) has been specified
        bool pathSpecified = false;
        // String for the path to save the files to
        string path = "";
        // Keep track if local database should be used (Requires MongoDB installed)
        bool useLocalDB = false;
        private void btn_toggleRecord_Click(object sender, EventArgs e)
        {
            get_Process();
            if (!pathSpecified)
            {
                MessageBox.Show("Please select a folder to save the files in.");
            }
            else
            {
                if (stopRecording)
                {
                    stopRecording = false;
                    if (listen == false)
                    {
                        listen = true;
                        Task listenTask = new Task(song_change_listener);
                        listenTask.Start();
                    }
                    Task t = new Task(loopRecord);
                    t.Start();
                    btn_toggleRecord.Text = "Waiting for new song...";
                    btn_toggleRecord.BackColor = Color.Yellow;
                    btn_toggleRecord.ForeColor = Color.Black;
                }
                else
                {
                    stopRecording = true;
                    btn_toggleRecord.Text = "Finishing recording...";
                    btn_toggleRecord.BackColor = Color.Yellow;
                    btn_toggleRecord.ForeColor = Color.Black;
                }
            }
        }

        bool stopRecording = true;
        bool foundTask = false;
        void loopRecord()
        {
            // Get current window title of active window
            string title = GetWindowTitle();
            // Wait for the title to change, check 10 times per second
            while (title == GetWindowTitle() || GetWindowTitle() == "Advertisement" || GetWindowTitle() == "Spotify")
            {
                Thread.Sleep(100);
            }
            updateWindowNameDisplay();
            btn_toggleRecord.Invoke((MethodInvoker)delegate
            {
                btn_toggleRecord.Text = "Recording...";
                btn_toggleRecord.BackColor = Color.LightGreen;
                btn_toggleRecord.ForeColor = Color.White;
            });
            while (!stopRecording)
            {
                using (WasapiCapture capture = new WasapiLoopbackCapture())
                {
                    currentlyplaying cp = null;
                    while (cp == null)
                    {
                        cp = get_Currently_Playing();
                    }
                    if (cp.item != null)
                    {
                        string filename = cp.item.id; // GetWindowTitle();

                        //rtxt_songlist.Invoke((MethodInvoker)delegate {
                        //    // Running on the UI thread
                        //    rtxt_songlist.Text += filename + "\n";
                        //});

                        // rtxt_songlist.Text += filename + "\n";
                        //foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                        //{
                        //    filename = filename.Replace(c, '_');
                        //}


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
                                updateWindowNameDisplay();
                            }
                            //stop recording
                            capture.Stop();
                            updateWindowNameDisplay();
                            while (GetWindowTitle() == "Advertisement" || GetWindowTitle() == "Spotify")
                            {
                                Thread.Sleep(100);
                                updateWindowNameDisplay();
                            }
                            convertTagAsynch(path, filename, cp);


                            // Thread.Sleep(time);


                        }
                    }
                }

                if (title == GetWindowTitle())
                {
                    stopRecording = true;
                }
            }
            btn_toggleRecord.Invoke((MethodInvoker)delegate
            {
                btn_toggleRecord.Text = "Record";
                btn_toggleRecord.BackColor = Color.FromArgb(30, 30, 30);
                btn_toggleRecord.ForeColor = Color.White;
            });
        }

        // Method to convert wav to mp3 and tag the mp3 and also delete original wav file
        void convertTag(string path, string filename, currentlyplaying cp)
        {
            // This converts the wav to mp3
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    // C:\ffmpeg.exe -i 0A5gdlrpAuQqZ2iFgnqBFW.wav 0A5gdlrpAuQqZ2iFgnqBFW.mp3
                    FileName = @"C:\Windows\SysWOW64\cmd.exe",
                    Arguments = @"/c C:\ffmpeg.exe -i " + path + "\\" + filename + ".wav " + path + "\\" + filename + ".mp3",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = path
                }
            };
            proc.Start();
            proc.WaitForExit();
            proc.Close();
            // Delete the original wav file
            File.Delete(path + "\\" + filename + ".wav");
            // Tag the mp3
            TagLib.Id3v2.Tag.DefaultVersion = 3;
            TagLib.Id3v2.Tag.ForceDefaultVersion = true;
            TagLib.File file = TagLib.File.Create(path + "\\" + filename + ".mp3");
            SetAlbumArt(cp.item.album.images[0].url, file, path, filename);
            file.Tag.Title = cp.item.name;
            // Get artists
            string[] artists = new string[cp.item.artists.Count];
            int i = 0;
            foreach (currentlyplaying.Artist2 artist in cp.item.artists)
            {
                artists[i] = artist.name;
                i++;
            }
            file.Tag.Performers = artists;
            file.Tag.Album = cp.item.album.name;
            file.Tag.Track = (uint)cp.item.track_number;
            file.Tag.Year = (uint)Convert.ToInt32(Regex.Match(cp.item.album.release_date, @"(\d)(\d)(\d)(\d)").Value);
            // MessageBox.Show(cp.item.album.release_date.Split('-')[0]);
            file.RemoveTags(file.TagTypes & ~file.TagTypesOnDisk);
            file.Save();
            if (useLocalDB)
            {
                DB_Handler.insertSong(cp, path + "\\" + filename + ".mp3", true, DateTime.Now);
            }
        }
        // This method sets album cover art for mp3 files https://stackoverflow.com/a/50438153/
        public void SetAlbumArt(string url, TagLib.File file, string path_, string filename)
        {
            string path = string.Format(@"{0}\{1}.jpg", path_, filename);
            byte[] imageBytes = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    imageBytes = client.DownloadData(url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            TagLib.Id3v2.AttachedPictureFrame cover = new TagLib.Id3v2.AttachedPictureFrame
            {
                Type = TagLib.PictureType.FrontCover,
                Description = "Cover",
                MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg,
                Data = imageBytes,
                TextEncoding = TagLib.StringType.UTF16


            };
            file.Tag.Pictures = new TagLib.IPicture[] { cover };
        }
        void convertTagAsynch(string path, string filename, currentlyplaying cp)
        {
            Task.Run(() => convertTag(path, filename, cp));
        }

        private void btn_selectdFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (String.IsNullOrEmpty(path))
                {
                    fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                }
                else
                {
                    fbd.SelectedPath = path;
                }

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
                }
                else
                {
                    btn_useLocalDatabase.BackColor = Color.IndianRed;
                    MessageBox.Show("Connection to local database could not be established.");
                }
            }
            else
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

        private void btn_wav2mp3_Click(object sender, EventArgs e)
        {
            convertTagAsynch(path, "0A5gdlrpAuQqZ2iFgnqBFW", get_Currently_Playing());
        }

        Token token;
        AuthorizationCodeAuth auth;
        string _clientId = "a1049f9ae84b48d08f11dfddb806bf22";
        string _secretId = "f72602b2606643a0b05d0c4bf7357608";
        private void btn_tokenGet_Click(object sender, EventArgs e)
        {
            auth = new AuthorizationCodeAuth(
                        _clientId,
                        _secretId,
                        "http://localhost:4002",
                        "http://localhost:4002",
                        Scope.UserReadCurrentlyPlaying | Scope.UserReadPlaybackState | Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative | Scope.UserReadEmail | Scope.UserReadPrivate
                    );
            auth.AuthReceived += async (s, payload) =>
            {
                auth.Stop();
                token = await auth.ExchangeCode(payload.Code);
                oAuthToken = token.AccessToken;
                txt_accessToken.Invoke((MethodInvoker)delegate
                {
                    txt_accessToken.Text = oAuthToken;
                });
                // Token newToken = await auth.RefreshToken(token.RefreshToken);
            };
            auth.Start(); // Starts an internal HTTP Server
            auth.OpenBrowser();
        }

        private void btn_tokenRefresh_Click(object sender, EventArgs e)
        {
            refreshToken();
            resetExpires();
        }

        async void refreshToken()
        {
            try
            {
                Token newToken = await auth.RefreshToken(token.RefreshToken);
                oAuthToken = newToken.AccessToken;
                txt_accessToken.Invoke((MethodInvoker)delegate
                {
                    txt_accessToken.Text = oAuthToken;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txt_clientID_Click(object sender, EventArgs e)
        {
            // txt_clientID.Text = "";
        }

        private void txt_secretID_Click(object sender, EventArgs e)
        {
            // txt_secretID.Text = "";
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                settings s = new settings();
                s.Client_id = _clientId;
                s.Secret_id = _secretId;
                s.Host = txt_dbHost.Text;
                s.Port = txt_dbPort.Text;
                s.Path = path;
                s.oAuthToken = oAuthToken;
                s.refreshToken = token.RefreshToken;
                DB_Handler.saveSettings(s);
            }
            catch (Exception ex)
            {
                
            }
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timePassed += 1;
            updateTxtExpires();
            if (threshold < timePassed)
            {
                refreshToken();
                resetExpires();
            }
        }

        void updateTxtExpires()
        {
            txt_tokenExpires.Text = "Token expires in: " + ((60 * 60 - timePassed) / 60).ToString() + " minutes";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_loadPlaylists_Click(object sender, EventArgs e)
        {
            // Get username
            if (oAuthToken != "")
            {
                string username = "";
                // Create an api request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/me");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + txt_accessToken.Text); // oAuthToken);

                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        // Parse the returned json to a c# object
                        string response = streamReader.ReadToEnd();
                        userdata ud = Newtonsoft.Json.JsonConvert.DeserializeObject<userdata>(response);
                        username = ud.display_name;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Get list of playlists
                // Create an api request
                var httpWebRequest1 = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/users/" + username + "/playlists?limit=50&offset=0");
                httpWebRequest1.ContentType = "application/json";
                httpWebRequest1.Accept = "application/json";
                httpWebRequest1.Method = "GET";
                httpWebRequest1.Headers.Add("Authorization", "Bearer " + txt_accessToken.Text); // oAuthToken);

                try
                {
                    var httpResponse1 = (HttpWebResponse)httpWebRequest1.GetResponse();
                    using (var streamReader1 = new StreamReader(httpResponse1.GetResponseStream()))
                    {
                        // Parse the returned json to a c# object
                        string response = streamReader1.ReadToEnd();
                        playlists playlists = Newtonsoft.Json.JsonConvert.DeserializeObject<playlists>(response);
                        foreach (var playlist in playlists.items)
                        {
                            cmb_selectPlaylist.Items.Add(playlist);
                        }
                        cmb_selectPlaylist.SelectedIndex = 0;
                        playlistsloaded = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Access token required.");
            }
        }
        string saveplaylistfilename = "";
        bool playlistsloaded = false;
        bool saveplaylistfilenamechoosen = false;
        private void btn_selectPlaylistFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = path;
                saveFileDialog.Filter = "m3u (.m3u)|*.m3u";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveplaylistfilename = saveFileDialog.FileName;
                    saveplaylistfilenamechoosen = true;
                    btn_selectPlaylistFile.Text = saveplaylistfilename;
                }
            }
        }

        private void btn_createPlaylist_Click(object sender, EventArgs e)
        {
            if (playlistsloaded && saveplaylistfilenamechoosen && useLocalDB)
            {
                string id = (cmb_selectPlaylist.SelectedItem as playlists.Item).id;
                // Get the tracks from the playlist
                // Get list of playlists
                // Create an api request
                var httpWebRequest1 = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/playlists/" + id + "/tracks?market=ES&limit=100&offset=0");
                httpWebRequest1.ContentType = "application/json";
                httpWebRequest1.Accept = "application/json";
                httpWebRequest1.Method = "GET";
                httpWebRequest1.Headers.Add("Authorization", "Bearer " + txt_accessToken.Text); // oAuthToken);

                try
                {
                    var httpResponse1 = (HttpWebResponse)httpWebRequest1.GetResponse();
                    using (var streamReader1 = new StreamReader(httpResponse1.GetResponseStream()))
                    {
                        // Parse the returned json to a c# object
                        string response = streamReader1.ReadToEnd();
                        playlist playlist = Newtonsoft.Json.JsonConvert.DeserializeObject<playlist>(response);
                        List<string> ids = new List<string>();
                        foreach (playlist.Item item in playlist.items)
                        {
                            ids.Add(item.track.id);
                        }
                        List<song> songs = new List<song>();
                        foreach (string ID in ids)
                        {
                            song tmp = DB_Handler.get_song(ID);
                            if (tmp != null)
                            {
                                songs.Add(tmp);
                            }
                        }
                        foreach (var item in songs)
                        {
                            Console.WriteLine(item.local_Info.path);
                        }
                        m3u_Handler m3u = new m3u_Handler();
                        m3u.create_m3u(saveplaylistfilename, songs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You need to select a file to save to, you need to have a list of your playlists loaded and you need mongodb installed.");
            }
        }
    }

    class DB_Handler
    {
        string database_name = "spotify_downloader";
        string collection_name = "songs";
        string settings_collection_name = "settings";
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
        // OBSOLUTE SINCE SKIPPING TRACKS REQURIES SPOTIFY PREMIUM
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

        public settings loadSettings()
        {
            var client = new MongoClient("mongodb://" + host + ":" + port + "");
            var db = client.GetDatabase(database_name);
            var collection = db.GetCollection<settings>(settings_collection_name);
            var documents = collection.Find(Builders<settings>.Filter.Empty).Limit(1).ToListAsync().Result;
            settings s = null;
            foreach (var item in documents)
            {
                s = item;
            }
            return s;
        }
        public void saveSettings(settings s)
        {
            var client = new MongoClient("mongodb://" + host + ":" + port + "");
            var db = client.GetDatabase(database_name);
            db.DropCollection(settings_collection_name);
            var collection = db.GetCollection<settings>(settings_collection_name);
            collection.InsertOne(s);
        }

        public song get_song(string id)
        {
            var client = new MongoClient("mongodb://" + host + ":" + port + "");
            var db = client.GetDatabase(database_name);
            var collection = db.GetCollection<song>(collection_name);
            var docs = collection
                .Find(s => s.song_info.item.id == id)
                .Limit(1)
                .ToList();
            //foreach (song s in docs)
            //{
            //    Console.WriteLine(id);
            //    Console.WriteLine(s.song_info.item.id);
            //    Console.WriteLine("____");
            //    if (s.song_info.item.id == id)
            //    {
            //        return s;
            //    }
            //}
            if (docs.Count != 0)
            {
                return docs[0];
            }
            return null;
        }

    }

    class settings
    {
        public dynamic _id { get; set; }
        public string Client_id { get; set; }
        public string Secret_id { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Path { get; set; }
        public string oAuthToken { get; set; }
        public string refreshToken { get; set; }
    }

    class userdata
    {

        public class ExplicitContent
        {
            public bool filter_enabled { get; set; }
            public bool filter_locked { get; set; }
        }

        public class ExternalUrls
        {
            public string spotify { get; set; }
        }

        public class Followers
        {
            public object href { get; set; }
            public int total { get; set; }
        }

        public string country { get; set; }
        public string display_name { get; set; }
        public string email { get; set; }
        public ExplicitContent explicit_content { get; set; }
        public ExternalUrls external_urls { get; set; }
        public Followers followers { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<object> images { get; set; }
        public string product { get; set; }
        public string type { get; set; }
        public string uri { get; set; }


    }

    class playlists
    {



        public string href { get; set; }
        public Item[] items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public string previous { get; set; }
        public int total { get; set; }


        public class Item
        {
            public override string ToString()
            {
                return name;
            }
            public bool collaborative { get; set; }
            public string description { get; set; }
            public External_Urls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public Image[] images { get; set; }
            public string name { get; set; }
            public Owner owner { get; set; }
            public object primary_color { get; set; }
            public bool _public { get; set; }
            public string snapshot_id { get; set; }
            public Tracks tracks { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class External_Urls
        {
            public string spotify { get; set; }
        }

        public class Owner
        {
            public string display_name { get; set; }
            public External_Urls1 external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class External_Urls1
        {
            public string spotify { get; set; }
        }

        public class Tracks
        {
            public string href { get; set; }
            public int total { get; set; }
        }

        public class Image
        {
            public int? height { get; set; }
            public string url { get; set; }
            public int? width { get; set; }
        }

    }

    class playlist
    {

        public string href { get; set; }
        public Item[] items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }


        public class Item
        {
            public DateTime added_at { get; set; }
            public Added_By added_by { get; set; }
            public bool is_local { get; set; }
            public object primary_color { get; set; }
            public Track track { get; set; }
            public Video_Thumbnail video_thumbnail { get; set; }
        }

        public class Added_By
        {
            public External_Urls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class External_Urls
        {
            public string spotify { get; set; }
        }

        public class Track
        {
            public Album album { get; set; }
            public Artist1[] artists { get; set; }
            public int disc_number { get; set; }
            public int duration_ms { get; set; }
            public bool episode { get; set; }
            public bool _explicit { get; set; }
            public External_Ids external_ids { get; set; }
            public External_Urls3 external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public bool is_local { get; set; }
            public bool is_playable { get; set; }
            public string name { get; set; }
            public int popularity { get; set; }
            public string preview_url { get; set; }
            public bool track { get; set; }
            public int track_number { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class Album
        {
            public string album_type { get; set; }
            public Artist[] artists { get; set; }
            public External_Urls1 external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public Image[] images { get; set; }
            public string name { get; set; }
            public string release_date { get; set; }
            public string release_date_precision { get; set; }
            public int total_tracks { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class External_Urls1
        {
            public string spotify { get; set; }
        }

        public class Artist
        {
            public External_Urls2 external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class External_Urls2
        {
            public string spotify { get; set; }
        }

        public class Image
        {
            public int height { get; set; }
            public string url { get; set; }
            public int width { get; set; }
        }

        public class External_Ids
        {
            public string isrc { get; set; }
        }

        public class External_Urls3
        {
            public string spotify { get; set; }
        }

        public class Artist1
        {
            public External_Urls4 external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class External_Urls4
        {
            public string spotify { get; set; }
        }

        public class Video_Thumbnail
        {
            public object url { get; set; }
        }

    }
    class m3u_Handler
    {
        public void create_m3u(string filename, List<song> songs)
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            string content = "#EXTM3U" + Environment.NewLine;
            foreach (song s in songs)
            {
                content += "#EXTINF:" + (s.song_info.item.duration_ms / 1000).ToString() + "," + s.song_info.item.name + Environment.NewLine;
                content += s.local_Info.path + Environment.NewLine;
            }
            File.WriteAllText(filename, content);
        }
    }


}
