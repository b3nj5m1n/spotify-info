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
            for (int i = 0; i < delay; i+=delay/100)
            {
                Thread.Sleep(delay/100);
                prog_getspotifyprocess.Invoke((MethodInvoker)delegate {
                    prog_getspotifyprocess.Value += 1;
                });
            }
            
            // Get process handle of active window
            handle = GetForegroundWindow();
            // Change the text of the button to the window name
            btn_getProcess.Invoke((MethodInvoker)delegate {
                btn_getProcess.Text = "Task name: " + GetWindowTitle();
            });
        }

        // Manually update currently playing information
        private void btn_updateCurrentlyPlaying_Click(object sender, EventArgs e)
        {
            get_Currently_Playing();
        }

        private void get_Currently_Playing()
        {
            // Create an api request
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/me/player/currently-playing?market=ES");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer BQDwo0fB8127wPrY2feLmIi5Y8_n_s8rpggyTWviCBf78p1e7LXMV5n-Fi9xnkBfLBhdu_CFGVj63Sdjjfb5laPoN9RFCQIRnDzBuShQfnCPjcjN4ApG1tl-GdeXaVdUj30wcosFY6U");

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                // Parse the returned json to a c# object
                currentlyplaying currentlyplaying_ = Newtonsoft.Json.JsonConvert.DeserializeObject<currentlyplaying>(streamReader.ReadToEnd());
                lbl_cTrackName.Text = currentlyplaying_.item.name;
            }

        }

        

    }
}
