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
            this.lbl_cTrackName = new System.Windows.Forms.Label();
            this.btn_updateCurrentlyPlaying = new System.Windows.Forms.Button();
            this.grp_currentTrack.SuspendLayout();
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
            this.grp_currentTrack.Controls.Add(this.btn_updateCurrentlyPlaying);
            this.grp_currentTrack.Controls.Add(this.lbl_cTrackName);
            this.grp_currentTrack.Dock = System.Windows.Forms.DockStyle.Left;
            this.grp_currentTrack.ForeColor = System.Drawing.Color.White;
            this.grp_currentTrack.Location = new System.Drawing.Point(0, 99);
            this.grp_currentTrack.Name = "grp_currentTrack";
            this.grp_currentTrack.Size = new System.Drawing.Size(276, 351);
            this.grp_currentTrack.TabIndex = 2;
            this.grp_currentTrack.TabStop = false;
            this.grp_currentTrack.Text = "Currently playing:";
            // 
            // lbl_cTrackName
            // 
            this.lbl_cTrackName.AutoSize = true;
            this.lbl_cTrackName.Location = new System.Drawing.Point(22, 47);
            this.lbl_cTrackName.Name = "lbl_cTrackName";
            this.lbl_cTrackName.Size = new System.Drawing.Size(103, 13);
            this.lbl_cTrackName.TabIndex = 0;
            this.lbl_cTrackName.Text = "Current Track Name";
            // 
            // btn_updateCurrentlyPlaying
            // 
            this.btn_updateCurrentlyPlaying.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_updateCurrentlyPlaying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updateCurrentlyPlaying.Location = new System.Drawing.Point(3, 325);
            this.btn_updateCurrentlyPlaying.Name = "btn_updateCurrentlyPlaying";
            this.btn_updateCurrentlyPlaying.Size = new System.Drawing.Size(270, 23);
            this.btn_updateCurrentlyPlaying.TabIndex = 1;
            this.btn_updateCurrentlyPlaying.Text = "Manual update";
            this.btn_updateCurrentlyPlaying.UseVisualStyleBackColor = true;
            this.btn_updateCurrentlyPlaying.Click += new System.EventHandler(this.btn_updateCurrentlyPlaying_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grp_currentTrack);
            this.Controls.Add(this.prog_getspotifyprocess);
            this.Controls.Add(this.btn_getProcess);
            this.Name = "form";
            this.Text = "Spotify Info";
            this.Load += new System.EventHandler(this.form_Load);
            this.grp_currentTrack.ResumeLayout(false);
            this.grp_currentTrack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_getProcess;
        private System.Windows.Forms.ProgressBar prog_getspotifyprocess;
        private System.Windows.Forms.GroupBox grp_currentTrack;
        private System.Windows.Forms.Button btn_updateCurrentlyPlaying;
        private System.Windows.Forms.Label lbl_cTrackName;
    }
}

