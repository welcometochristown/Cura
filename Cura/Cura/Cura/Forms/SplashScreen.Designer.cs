namespace Cura.Forms
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.versionlbl = new System.Windows.Forms.Label();
            this.trialLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Cura.Properties.Resources.loading2;
            this.pictureBox1.Location = new System.Drawing.Point(279, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 66);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // versionlbl
            // 
            this.versionlbl.AutoSize = true;
            this.versionlbl.BackColor = System.Drawing.Color.White;
            this.versionlbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionlbl.Location = new System.Drawing.Point(6, 6);
            this.versionlbl.Name = "versionlbl";
            this.versionlbl.Size = new System.Drawing.Size(80, 16);
            this.versionlbl.TabIndex = 2;
            this.versionlbl.Text = "Beta Version";
            // 
            // trialLbl
            // 
            this.trialLbl.AutoSize = true;
            this.trialLbl.BackColor = System.Drawing.Color.White;
            this.trialLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trialLbl.ForeColor = System.Drawing.Color.Green;
            this.trialLbl.Location = new System.Drawing.Point(6, 25);
            this.trialLbl.Name = "trialLbl";
            this.trialLbl.Size = new System.Drawing.Size(34, 16);
            this.trialLbl.TabIndex = 2;
            this.trialLbl.Text = "Trial";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Cura.Properties.Resources.splash;
            this.ClientSize = new System.Drawing.Size(597, 366);
            this.Controls.Add(this.trialLbl);
            this.Controls.Add(this.versionlbl);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label versionlbl;
        private System.Windows.Forms.Label trialLbl;



    }
}