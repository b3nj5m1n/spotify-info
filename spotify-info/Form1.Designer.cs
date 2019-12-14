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
            this.lbl_cTrackArtist = new System.Windows.Forms.Label();
            this.pic_Cover = new System.Windows.Forms.PictureBox();
            this.btn_updateCurrentlyPlaying = new System.Windows.Forms.Button();
            this.lbl_cTrackName = new System.Windows.Forms.Label();
            this.btn_toggleListener = new System.Windows.Forms.Button();
            this.grp_db = new System.Windows.Forms.GroupBox();
            this.btn_connectDB = new System.Windows.Forms.Button();
            this.btn_dbInsertCurrent = new System.Windows.Forms.Button();
            this.grp_currentTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Cover)).BeginInit();
            this.grp_db.SuspendLayout();
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
            this.btn_getProcess.Size = new System.Drawing.Size(800, 76);
            this.btn_getProcess.TabIndex = 0;
            this.btn_getProcess.Text = "Get spotify process";
            this.btn_getProcess.UseVisualStyleBackColor = true;
            this.btn_getProcess.Click += new System.EventHandler(this.btn_getProcess_Click);
            // 
            // prog_getspotifyprocess
            // 
            this.prog_getspotifyprocess.Dock = System.Windows.Forms.DockStyle.Top;
            this.prog_getspotifyprocess.Location = new System.Drawing.Point(0, 76);
            this.prog_getspotifyprocess.Name = "prog_getspotifyprocess";
            this.prog_getspotifyprocess.Size = new System.Drawing.Size(800, 23);
            this.prog_getspotifyprocess.TabIndex = 1;
            // 
            // grp_currentTrack
            // 
            this.grp_currentTrack.Controls.Add(this.lbl_cTrackArtist);
            this.grp_currentTrack.Controls.Add(this.pic_Cover);
            this.grp_currentTrack.Controls.Add(this.btn_updateCurrentlyPlaying);
            this.grp_currentTrack.Controls.Add(this.lbl_cTrackName);
            this.grp_currentTrack.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp_currentTrack.ForeColor = System.Drawing.Color.White;
            this.grp_currentTrack.Location = new System.Drawing.Point(0, 99);
            this.grp_currentTrack.Name = "grp_currentTrack";
            this.grp_currentTrack.Size = new System.Drawing.Size(302, 351);
            this.grp_currentTrack.TabIndex = 2;
            this.grp_currentTrack.TabStop = false;
            this.grp_currentTrack.Text = "Currently playing:";
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
            this.btn_updateCurrentlyPlaying.Location = new System.Drawing.Point(3, 325);
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
            this.grp_db.Controls.Add(this.btn_dbInsertCurrent);
            this.grp_db.Controls.Add(this.btn_connectDB);
            this.grp_db.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp_db.ForeColor = System.Drawing.Color.White;
            this.grp_db.Location = new System.Drawing.Point(302, 99);
            this.grp_db.Name = "grp_db";
            this.grp_db.Size = new System.Drawing.Size(248, 314);
            this.grp_db.TabIndex = 4;
            this.grp_db.TabStop = false;
            this.grp_db.Text = "Local Database";
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
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

