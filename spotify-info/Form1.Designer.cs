namespace spotify_info
{
    partial class form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_getProcess = new System.Windows.Forms.Button();
            this.prog_getspotifyprocess = new System.Windows.Forms.ProgressBar();
            this.grp_currentTrack = new System.Windows.Forms.GroupBox();
            this.txt_accessToken = new System.Windows.Forms.TextBox();
            this.lbl_cTrackArtist = new System.Windows.Forms.Label();
            this.pic_Cover = new System.Windows.Forms.PictureBox();
            this.btn_updateCurrentlyPlaying = new System.Windows.Forms.Button();
            this.lbl_cTrackName = new System.Windows.Forms.Label();
            this.btn_toggleListener = new System.Windows.Forms.Button();
            this.grp_db = new System.Windows.Forms.GroupBox();
            this.txt_dbHost = new System.Windows.Forms.TextBox();
            this.txt_dbPort = new System.Windows.Forms.TextBox();
            this.btn_dbInsertCurrent = new System.Windows.Forms.Button();
            this.btn_connectDB = new System.Windows.Forms.Button();
            this.grp_Record = new System.Windows.Forms.GroupBox();
            this.btn_wav2mp3 = new System.Windows.Forms.Button();
            this.btn_useLocalDatabase = new System.Windows.Forms.Button();
            this.btn_selectdFolder = new System.Windows.Forms.Button();
            this.btn_toggleRecord = new System.Windows.Forms.Button();
            this.grp_currentTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cover)).BeginInit();
            this.grp_db.SuspendLayout();
            this.grp_Record.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_getProcess
            // 
            this.btn_getProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_getProcess.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_getProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_getProcess.ForeColor = System.Drawing.Color.White;
            this.btn_getProcess.Location = new System.Drawing.Point(0, 0);
            this.btn_getProcess.Name = "btn_getProcess";
            this.btn_getProcess.Size = new System.Drawing.Size(800, 93);
            this.btn_getProcess.TabIndex = 0;
            this.btn_getProcess.Text = "Get spotify process";
            this.btn_getProcess.UseVisualStyleBackColor = true;
            this.btn_getProcess.Click += new System.EventHandler(this.btn_getProcess_Click);
            // 
            // prog_getspotifyprocess
            // 
            this.prog_getspotifyprocess.Dock = System.Windows.Forms.DockStyle.Top;
            this.prog_getspotifyprocess.Location = new System.Drawing.Point(0, 93);
            this.prog_getspotifyprocess.Name = "prog_getspotifyprocess";
            this.prog_getspotifyprocess.Size = new System.Drawing.Size(800, 23);
            this.prog_getspotifyprocess.TabIndex = 1;
            // 
            // grp_currentTrack
            // 
            this.grp_currentTrack.Controls.Add(this.txt_accessToken);
            this.grp_currentTrack.Controls.Add(this.lbl_cTrackArtist);
            this.grp_currentTrack.Controls.Add(this.pic_Cover);
            this.grp_currentTrack.Controls.Add(this.btn_updateCurrentlyPlaying);
            this.grp_currentTrack.Controls.Add(this.lbl_cTrackName);
            this.grp_currentTrack.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp_currentTrack.ForeColor = System.Drawing.Color.White;
            this.grp_currentTrack.Location = new System.Drawing.Point(0, 116);
            this.grp_currentTrack.Name = "grp_currentTrack";
            this.grp_currentTrack.Size = new System.Drawing.Size(302, 334);
            this.grp_currentTrack.TabIndex = 2;
            this.grp_currentTrack.TabStop = false;
            this.grp_currentTrack.Text = "Currently playing:";
            // 
            // txt_accessToken
            // 
            this.txt_accessToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_accessToken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_accessToken.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_accessToken.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_accessToken.ForeColor = System.Drawing.Color.White;
            this.txt_accessToken.Location = new System.Drawing.Point(3, 276);
            this.txt_accessToken.Name = "txt_accessToken";
            this.txt_accessToken.Size = new System.Drawing.Size(296, 32);
            this.txt_accessToken.TabIndex = 2;
            this.txt_accessToken.Text = "Access Token";
            this.txt_accessToken.Click += new System.EventHandler(this.txt_accessToken_Click);
            this.txt_accessToken.DoubleClick += new System.EventHandler(this.txt_accessToken_DoubleClick);
            // 
            // lbl_cTrackArtist
            // 
            this.lbl_cTrackArtist.AutoSize = true;
            this.lbl_cTrackArtist.Location = new System.Drawing.Point(23, 207);
            this.lbl_cTrackArtist.Name = "lbl_cTrackArtist";
            this.lbl_cTrackArtist.Size = new System.Drawing.Size(98, 13);
            this.lbl_cTrackArtist.TabIndex = 3;
            this.lbl_cTrackArtist.Text = "Current Track Artist";
            // 
            // pic_Cover
            // 
            this.pic_Cover.Location = new System.Drawing.Point(26, 19);
            this.pic_Cover.Name = "pic_Cover";
            this.pic_Cover.Size = new System.Drawing.Size(150, 150);
            this.pic_Cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Cover.TabIndex = 2;
            this.pic_Cover.TabStop = false;
            // 
            // btn_updateCurrentlyPlaying
            // 
            this.btn_updateCurrentlyPlaying.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_updateCurrentlyPlaying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updateCurrentlyPlaying.Location = new System.Drawing.Point(3, 308);
            this.btn_updateCurrentlyPlaying.Name = "btn_updateCurrentlyPlaying";
            this.btn_updateCurrentlyPlaying.Size = new System.Drawing.Size(296, 23);
            this.btn_updateCurrentlyPlaying.TabIndex = 1;
            this.btn_updateCurrentlyPlaying.Text = "Manual update";
            this.btn_updateCurrentlyPlaying.UseVisualStyleBackColor = true;
            this.btn_updateCurrentlyPlaying.Click += new System.EventHandler(this.btn_updateCurrentlyPlaying_Click);
            // 
            // lbl_cTrackName
            // 
            this.lbl_cTrackName.AutoSize = true;
            this.lbl_cTrackName.Location = new System.Drawing.Point(23, 185);
            this.lbl_cTrackName.Name = "lbl_cTrackName";
            this.lbl_cTrackName.Size = new System.Drawing.Size(103, 13);
            this.lbl_cTrackName.TabIndex = 0;
            this.lbl_cTrackName.Text = "Current Track Name";
            // 
            // btn_toggleListener
            // 
            this.btn_toggleListener.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_toggleListener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_toggleListener.ForeColor = System.Drawing.Color.White;
            this.btn_toggleListener.Location = new System.Drawing.Point(302, 413);
            this.btn_toggleListener.Name = "btn_toggleListener";
            this.btn_toggleListener.Size = new System.Drawing.Size(498, 37);
            this.btn_toggleListener.TabIndex = 3;
            this.btn_toggleListener.Text = "Listen for song changes";
            this.btn_toggleListener.UseVisualStyleBackColor = true;
            this.btn_toggleListener.Click += new System.EventHandler(this.btn_toggleListener_Click);
            // 
            // grp_db
            // 
            this.grp_db.Controls.Add(this.txt_dbHost);
            this.grp_db.Controls.Add(this.txt_dbPort);
            this.grp_db.Controls.Add(this.btn_dbInsertCurrent);
            this.grp_db.Controls.Add(this.btn_connectDB);
            this.grp_db.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp_db.ForeColor = System.Drawing.Color.White;
            this.grp_db.Location = new System.Drawing.Point(302, 116);
            this.grp_db.Name = "grp_db";
            this.grp_db.Size = new System.Drawing.Size(248, 297);
            this.grp_db.TabIndex = 4;
            this.grp_db.TabStop = false;
            this.grp_db.Text = "Local Database";
            // 
            // txt_dbHost
            // 
            this.txt_dbHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_dbHost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dbHost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_dbHost.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dbHost.ForeColor = System.Drawing.Color.White;
            this.txt_dbHost.Location = new System.Drawing.Point(3, 230);
            this.txt_dbHost.Name = "txt_dbHost";
            this.txt_dbHost.Size = new System.Drawing.Size(242, 32);
            this.txt_dbHost.TabIndex = 4;
            this.txt_dbHost.Text = "localhost";
            // 
            // txt_dbPort
            // 
            this.txt_dbPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txt_dbPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dbPort.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_dbPort.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dbPort.ForeColor = System.Drawing.Color.White;
            this.txt_dbPort.Location = new System.Drawing.Point(3, 262);
            this.txt_dbPort.Name = "txt_dbPort";
            this.txt_dbPort.Size = new System.Drawing.Size(242, 32);
            this.txt_dbPort.TabIndex = 3;
            this.txt_dbPort.Text = "27017";
            // 
            // btn_dbInsertCurrent
            // 
            this.btn_dbInsertCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_dbInsertCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dbInsertCurrent.Location = new System.Drawing.Point(3, 39);
            this.btn_dbInsertCurrent.Name = "btn_dbInsertCurrent";
            this.btn_dbInsertCurrent.Size = new System.Drawing.Size(242, 23);
            this.btn_dbInsertCurrent.TabIndex = 1;
            this.btn_dbInsertCurrent.Text = "Insert current song";
            this.btn_dbInsertCurrent.UseVisualStyleBackColor = true;
            this.btn_dbInsertCurrent.Click += new System.EventHandler(this.btn_dbInsertCurrent_Click);
            // 
            // btn_connectDB
            // 
            this.btn_connectDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_connectDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connectDB.Location = new System.Drawing.Point(3, 16);
            this.btn_connectDB.Name = "btn_connectDB";
            this.btn_connectDB.Size = new System.Drawing.Size(242, 23);
            this.btn_connectDB.TabIndex = 0;
            this.btn_connectDB.Text = "Connect to Database";
            this.btn_connectDB.UseVisualStyleBackColor = true;
            this.btn_connectDB.Click += new System.EventHandler(this.btn_connectDB_Click);
            // 
            // grp_Record
            // 
            this.grp_Record.Controls.Add(this.btn_wav2mp3);
            this.grp_Record.Controls.Add(this.btn_useLocalDatabase);
            this.grp_Record.Controls.Add(this.btn_selectdFolder);
            this.grp_Record.Controls.Add(this.btn_toggleRecord);
            this.grp_Record.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp_Record.ForeColor = System.Drawing.Color.White;
            this.grp_Record.Location = new System.Drawing.Point(550, 116);
            this.grp_Record.Name = "grp_Record";
            this.grp_Record.Size = new System.Drawing.Size(248, 297);
            this.grp_Record.TabIndex = 5;
            this.grp_Record.TabStop = false;
            this.grp_Record.Text = "Record";
            // 
            // btn_wav2mp3
            // 
            this.btn_wav2mp3.Location = new System.Drawing.Point(170, 239);
            this.btn_wav2mp3.Name = "btn_wav2mp3";
            this.btn_wav2mp3.Size = new System.Drawing.Size(75, 23);
            this.btn_wav2mp3.TabIndex = 3;
            this.btn_wav2mp3.Text = "button1";
            this.btn_wav2mp3.UseVisualStyleBackColor = true;
            this.btn_wav2mp3.Visible = false;
            this.btn_wav2mp3.Click += new System.EventHandler(this.btn_wav2mp3_Click);
            // 
            // btn_useLocalDatabase
            // 
            this.btn_useLocalDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_useLocalDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_useLocalDatabase.Location = new System.Drawing.Point(3, 62);
            this.btn_useLocalDatabase.Name = "btn_useLocalDatabase";
            this.btn_useLocalDatabase.Size = new System.Drawing.Size(242, 23);
            this.btn_useLocalDatabase.TabIndex = 2;
            this.btn_useLocalDatabase.Text = "Use local Database";
            this.btn_useLocalDatabase.UseVisualStyleBackColor = true;
            this.btn_useLocalDatabase.Click += new System.EventHandler(this.btn_useLocalDatabase_Click);
            // 
            // btn_selectdFolder
            // 
            this.btn_selectdFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_selectdFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectdFolder.Location = new System.Drawing.Point(3, 39);
            this.btn_selectdFolder.Name = "btn_selectdFolder";
            this.btn_selectdFolder.Size = new System.Drawing.Size(242, 23);
            this.btn_selectdFolder.TabIndex = 1;
            this.btn_selectdFolder.Text = "Select Folder";
            this.btn_selectdFolder.UseVisualStyleBackColor = true;
            this.btn_selectdFolder.Click += new System.EventHandler(this.btn_selectdFolder_Click);
            // 
            // btn_toggleRecord
            // 
            this.btn_toggleRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_toggleRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_toggleRecord.Location = new System.Drawing.Point(3, 16);
            this.btn_toggleRecord.Name = "btn_toggleRecord";
            this.btn_toggleRecord.Size = new System.Drawing.Size(242, 23);
            this.btn_toggleRecord.TabIndex = 0;
            this.btn_toggleRecord.Text = "Record";
            this.btn_toggleRecord.UseVisualStyleBackColor = true;
            this.btn_toggleRecord.Click += new System.EventHandler(this.btn_toggleRecord_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grp_Record);
            this.Controls.Add(this.grp_db);
            this.Controls.Add(this.btn_toggleListener);
            this.Controls.Add(this.grp_currentTrack);
            this.Controls.Add(this.prog_getspotifyprocess);
            this.Controls.Add(this.btn_getProcess);
            this.Name = "form";
            this.Text = "Spotify Info";
            this.Load += new System.EventHandler(this.form_Load);
            this.grp_currentTrack.ResumeLayout(false);
            this.grp_currentTrack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cover)).EndInit();
            this.grp_db.ResumeLayout(false);
            this.grp_db.PerformLayout();
            this.grp_Record.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_getProcess;
        private System.Windows.Forms.ProgressBar prog_getspotifyprocess;
        private System.Windows.Forms.GroupBox grp_currentTrack;
        private System.Windows.Forms.Button btn_updateCurrentlyPlaying;
        private System.Windows.Forms.Label lbl_cTrackName;
        private System.Windows.Forms.PictureBox pic_Cover;
        private System.Windows.Forms.Label lbl_cTrackArtist;
        private System.Windows.Forms.Button btn_toggleListener;
        private System.Windows.Forms.GroupBox grp_db;
        private System.Windows.Forms.Button btn_connectDB;
        private System.Windows.Forms.Button btn_dbInsertCurrent;
        private System.Windows.Forms.TextBox txt_accessToken;
        private System.Windows.Forms.GroupBox grp_Record;
        private System.Windows.Forms.Button btn_selectdFolder;
        private System.Windows.Forms.Button btn_toggleRecord;
        private System.Windows.Forms.Button btn_useLocalDatabase;
        private System.Windows.Forms.TextBox txt_dbHost;
        private System.Windows.Forms.TextBox txt_dbPort;
        private System.Windows.Forms.Button btn_wav2mp3;
    }
}

