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
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.prog_getspotifyprocess);
            this.Controls.Add(this.btn_getProcess);
            this.Name = "form";
            this.Text = "Spotify Info";
            this.Load += new System.EventHandler(this.form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_getProcess;
        private System.Windows.Forms.ProgressBar prog_getspotifyprocess;
    }
}

