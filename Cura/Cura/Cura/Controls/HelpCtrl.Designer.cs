namespace Cura.Controls
{
    partial class HelpCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.helpImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpImg)).BeginInit();
            this.SuspendLayout();
            // 
            // helpImg
            // 
            this.helpImg.BackColor = System.Drawing.Color.Transparent;
            this.helpImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpImg.Location = new System.Drawing.Point(0, 0);
            this.helpImg.Name = "helpImg";
            this.helpImg.Size = new System.Drawing.Size(16, 16);
            this.helpImg.TabIndex = 16;
            this.helpImg.TabStop = false;
            this.helpImg.Click += new System.EventHandler(this.helpImg_Click);
            this.helpImg.MouseEnter += new System.EventHandler(this.helpImg_MouseEnter);
            this.helpImg.MouseLeave += new System.EventHandler(this.helpImg_MouseLeave);
            // 
            // HelpCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.helpImg);
            this.Name = "HelpCtrl";
            this.Size = new System.Drawing.Size(16, 16);
            ((System.ComponentModel.ISupportInitialize)(this.helpImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox helpImg;
    }
}
