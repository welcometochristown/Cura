namespace Cura.Controls
{
    partial class ServiceUserHeaderCtrl
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
            this.label2 = new System.Windows.Forms.Label();
            this.weekCntLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.allCountLbl = new System.Windows.Forms.Label();
            this.newProgressBar2 = new Cura.Controls.Common.NewProgressBar();
            this.newProgressBar1 = new Cura.Controls.Common.NewProgressBar();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service Users";
            // 
            // weekCntLbl
            // 
            this.weekCntLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weekCntLbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekCntLbl.Location = new System.Drawing.Point(738, 12);
            this.weekCntLbl.Name = "weekCntLbl";
            this.weekCntLbl.Size = new System.Drawing.Size(141, 14);
            this.weekCntLbl.TabIndex = 4;
            this.weekCntLbl.Text = "8888 / 8888";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(650, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "This Week";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(904, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "All";
            // 
            // allCountLbl
            // 
            this.allCountLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.allCountLbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allCountLbl.Location = new System.Drawing.Point(935, 12);
            this.allCountLbl.Name = "allCountLbl";
            this.allCountLbl.Size = new System.Drawing.Size(141, 14);
            this.allCountLbl.TabIndex = 4;
            this.allCountLbl.Text = "8888 / 8888";
            this.allCountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // newProgressBar2
            // 
            this.newProgressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newProgressBar2.Location = new System.Drawing.Point(738, 1);
            this.newProgressBar2.Name = "newProgressBar2";
            this.newProgressBar2.Size = new System.Drawing.Size(143, 10);
            this.newProgressBar2.TabIndex = 0;
            this.newProgressBar2.Value = 60;
            // 
            // newProgressBar1
            // 
            this.newProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newProgressBar1.Location = new System.Drawing.Point(935, 1);
            this.newProgressBar1.Name = "newProgressBar1";
            this.newProgressBar1.Size = new System.Drawing.Size(143, 10);
            this.newProgressBar1.TabIndex = 0;
            this.newProgressBar1.Value = 60;
            // 
            // ServiceUserHeaderCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newProgressBar2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newProgressBar1);
            this.Controls.Add(this.allCountLbl);
            this.Controls.Add(this.weekCntLbl);
            this.Controls.Add(this.label2);
            this.Name = "ServiceUserHeaderCtrl";
            this.Size = new System.Drawing.Size(1084, 28);
            this.Load += new System.EventHandler(this.ServiceUserHeaderCtrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label weekCntLbl;
        private Common.NewProgressBar newProgressBar1;
        private Common.NewProgressBar newProgressBar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label allCountLbl;
    }
}
