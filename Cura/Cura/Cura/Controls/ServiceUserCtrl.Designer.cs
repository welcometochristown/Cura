namespace Cura.Controls
{
    partial class ServiceUserCtrl
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
            this.splitContainer_usersmain = new System.Windows.Forms.SplitContainer();
            this.serviceUserHeaderCtrl1 = new Cura.Controls.ServiceUserHeaderCtrl();
            this.splitContainer_users = new System.Windows.Forms.SplitContainer();
            this.userListCtrl1 = new Cura.Controls.ServiceUserListCtrl();
            this.userCalendarCtrl1 = new Cura.Controls.ServiceUserCalendarCtrl();
            this.splitContainer_usersmain.Panel1.SuspendLayout();
            this.splitContainer_usersmain.Panel2.SuspendLayout();
            this.splitContainer_usersmain.SuspendLayout();
            this.splitContainer_users.Panel1.SuspendLayout();
            this.splitContainer_users.Panel2.SuspendLayout();
            this.splitContainer_users.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_usersmain
            // 
            this.splitContainer_usersmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_usersmain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_usersmain.IsSplitterFixed = true;
            this.splitContainer_usersmain.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_usersmain.Name = "splitContainer_usersmain";
            this.splitContainer_usersmain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_usersmain.Panel1
            // 
            this.splitContainer_usersmain.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer_usersmain.Panel1.BackgroundImage = global::Cura.Properties.Resources.back;
            this.splitContainer_usersmain.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer_usersmain.Panel1.Controls.Add(this.serviceUserHeaderCtrl1);
            // 
            // splitContainer_usersmain.Panel2
            // 
            this.splitContainer_usersmain.Panel2.Controls.Add(this.splitContainer_users);
            this.splitContainer_usersmain.Size = new System.Drawing.Size(870, 532);
            this.splitContainer_usersmain.SplitterDistance = 25;
            this.splitContainer_usersmain.TabIndex = 2;
            // 
            // serviceUserHeaderCtrl1
            // 
            this.serviceUserHeaderCtrl1.CurrentPeriodStart = new System.DateTime(((long)(0)));
            this.serviceUserHeaderCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceUserHeaderCtrl1.Location = new System.Drawing.Point(0, 0);
            this.serviceUserHeaderCtrl1.Name = "serviceUserHeaderCtrl1";
            this.serviceUserHeaderCtrl1.Size = new System.Drawing.Size(870, 25);
            this.serviceUserHeaderCtrl1.StartDate = new System.DateTime(((long)(0)));
            this.serviceUserHeaderCtrl1.TabIndex = 0;
            // 
            // splitContainer_users
            // 
            this.splitContainer_users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_users.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_users.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_users.Name = "splitContainer_users";
            // 
            // splitContainer_users.Panel1
            // 
            this.splitContainer_users.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer_users.Panel1.Controls.Add(this.userListCtrl1);
            // 
            // splitContainer_users.Panel2
            // 
            this.splitContainer_users.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer_users.Panel2.Controls.Add(this.userCalendarCtrl1);
            this.splitContainer_users.Size = new System.Drawing.Size(870, 503);
            this.splitContainer_users.SplitterDistance = 250;
            this.splitContainer_users.SplitterWidth = 5;
            this.splitContainer_users.TabIndex = 2;
            // 
            // userListCtrl1
            // 
            this.userListCtrl1.AllowOpenServiceUser = true;
            this.userListCtrl1.BackColor = System.Drawing.SystemColors.Control;
            this.userListCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userListCtrl1.Filter = null;
            this.userListCtrl1.Location = new System.Drawing.Point(0, 0);
            this.userListCtrl1.Name = "userListCtrl1";
            this.userListCtrl1.SearchText = null;
            this.userListCtrl1.ServiceUsers = null;
            this.userListCtrl1.ShowContextMenu = true;
            this.userListCtrl1.ShowFilters = true;
            this.userListCtrl1.ShowNewButton = true;
            this.userListCtrl1.Size = new System.Drawing.Size(250, 503);
            this.userListCtrl1.TabIndex = 0;
            this.userListCtrl1.ServiceUserSelectionChanged += new System.EventHandler(this.userListCtrl1_ServiceUserSelectionChanged);
            // 
            // userCalendarCtrl1
            // 
            this.userCalendarCtrl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.userCalendarCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userCalendarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.userCalendarCtrl1.Name = "userCalendarCtrl1";
            this.userCalendarCtrl1.ServiceUser = null;
            this.userCalendarCtrl1.Size = new System.Drawing.Size(615, 503);
            this.userCalendarCtrl1.TabIndex = 0;
            this.userCalendarCtrl1.GlobalMouseUp += new Cura.Controls.ServiceUserCalendarCtrl.ServiceUserDropHandler(this.userCalendarCtrl1_GlobalMouseUp);
            this.userCalendarCtrl1.GlobalMouseDown += new System.Windows.Forms.MouseEventHandler(this.userCalendarCtrl1_GlobalMouseDown);
            // 
            // ServiceUserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_usersmain);
            this.Name = "ServiceUserCtrl";
            this.Size = new System.Drawing.Size(870, 532);
            this.splitContainer_usersmain.Panel1.ResumeLayout(false);
            this.splitContainer_usersmain.Panel2.ResumeLayout(false);
            this.splitContainer_usersmain.ResumeLayout(false);
            this.splitContainer_users.Panel1.ResumeLayout(false);
            this.splitContainer_users.Panel2.ResumeLayout(false);
            this.splitContainer_users.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_usersmain;
        private System.Windows.Forms.SplitContainer splitContainer_users;
        private ServiceUserListCtrl userListCtrl1;
        private ServiceUserCalendarCtrl userCalendarCtrl1;
        private ServiceUserHeaderCtrl serviceUserHeaderCtrl1;
    }
}
