namespace Cura.Forms
{
    partial class ServiceUserListFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceUserListFrm));
            this.serviceUserListCtrl1 = new Cura.Controls.ServiceUserListCtrl();
            this.SuspendLayout();
            // 
            // serviceUserListCtrl1
            // 
            this.serviceUserListCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceUserListCtrl1.Location = new System.Drawing.Point(0, 32);
            this.serviceUserListCtrl1.Name = "serviceUserListCtrl1";
            this.serviceUserListCtrl1.SearchText = null;
            this.serviceUserListCtrl1.ServiceUsers = null;
            this.serviceUserListCtrl1.ShowFilters = false;
            this.serviceUserListCtrl1.ShowNewButton = false;
            this.serviceUserListCtrl1.Size = new System.Drawing.Size(687, 423);
            this.serviceUserListCtrl1.TabIndex = 1;
            // 
            // ServiceUserListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 455);
            this.Controls.Add(this.serviceUserListCtrl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::Cura.Properties.Resources.s_user_16;
            this.Name = "ServiceUserListFrm";
            this.Text = "Service Users";
            this.Title = "All Service Users";
            this.Controls.SetChildIndex(this.serviceUserListCtrl1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ServiceUserListCtrl serviceUserListCtrl1;
    }
}