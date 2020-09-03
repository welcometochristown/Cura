namespace Cura.Controls
{
    partial class WorkerListCtrl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerListCtrl));
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer1 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer2 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printRotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailRotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.hideInactiveChk = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.newworkerbtn = new CG.Controls.Grid.Buttons.ExButton();
            this.filter1 = new Cura.Controls.Common.Filter();
            this.searchTypeBtn = new CG.Controls.Grid.Buttons.ExButton();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn3,
            this.olvColumn2});
            this.objectListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(0, 24);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.ShowImagesOnSubItems = true;
            this.objectListView1.Size = new System.Drawing.Size(647, 294);
            this.objectListView1.SmallImageList = this.imageList1;
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectionChanged += new System.EventHandler(this.objectListView1_SelectionChanged);
            this.objectListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objectListView1_MouseDoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.ImageAspectName = "GetStatusImage";
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 100;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Enumber";
            this.olvColumn3.Text = "ENumber";
            // 
            // olvColumn2
            // 
            this.olvColumn2.ImageAspectName = "PropertiesImage";
            this.olvColumn2.Text = "";
            this.olvColumn2.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.duplicateUserToolStripMenuItem,
            this.toolStripSeparator3,
            this.disableToolStripMenuItem,
            this.enableToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.printRotaToolStripMenuItem,
            this.emailRotaToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToGroupToolStripMenuItem,
            this.removeFromGroupToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 220);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Cura.Properties.Resources.application_edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // duplicateUserToolStripMenuItem
            // 
            this.duplicateUserToolStripMenuItem.Image = global::Cura.Properties.Resources.page_copy_icon;
            this.duplicateUserToolStripMenuItem.Name = "duplicateUserToolStripMenuItem";
            this.duplicateUserToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.duplicateUserToolStripMenuItem.Text = "Duplicate";
            this.duplicateUserToolStripMenuItem.Click += new System.EventHandler(this.duplicateUserToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Image = global::Cura.Properties.Resources.disable;
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.disableToolStripMenuItem.Text = "Deactivate";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Image = global::Cura.Properties.Resources.enable;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.enableToolStripMenuItem.Text = "Activate";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Cura.Properties.Resources.user_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // printRotaToolStripMenuItem
            // 
            this.printRotaToolStripMenuItem.Image = global::Cura.Properties.Resources.pdf_icon;
            this.printRotaToolStripMenuItem.Name = "printRotaToolStripMenuItem";
            this.printRotaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.printRotaToolStripMenuItem.Text = "View / Print Rota";
            this.printRotaToolStripMenuItem.Click += new System.EventHandler(this.printRotaToolStripMenuItem_Click);
            // 
            // emailRotaToolStripMenuItem
            // 
            this.emailRotaToolStripMenuItem.Image = global::Cura.Properties.Resources.email;
            this.emailRotaToolStripMenuItem.Name = "emailRotaToolStripMenuItem";
            this.emailRotaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.emailRotaToolStripMenuItem.Text = "Email Rota";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // addToGroupToolStripMenuItem
            // 
            this.addToGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGroupToolStripMenuItem});
            this.addToGroupToolStripMenuItem.Name = "addToGroupToolStripMenuItem";
            this.addToGroupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addToGroupToolStripMenuItem.Text = "Add To Group";
            // 
            // newGroupToolStripMenuItem
            // 
            this.newGroupToolStripMenuItem.Name = "newGroupToolStripMenuItem";
            this.newGroupToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.newGroupToolStripMenuItem.Text = "<New Group>";
            this.newGroupToolStripMenuItem.Click += new System.EventHandler(this.newGroupToolStripMenuItem_Click);
            // 
            // removeFromGroupToolStripMenuItem
            // 
            this.removeFromGroupToolStripMenuItem.Name = "removeFromGroupToolStripMenuItem";
            this.removeFromGroupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.removeFromGroupToolStripMenuItem.Text = "Remove From Group";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "disable.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hideInactiveChk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 25);
            this.panel1.TabIndex = 6;
            // 
            // hideInactiveChk
            // 
            this.hideInactiveChk.AutoSize = true;
            this.hideInactiveChk.Checked = true;
            this.hideInactiveChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideInactiveChk.Location = new System.Drawing.Point(6, 6);
            this.hideInactiveChk.Name = "hideInactiveChk";
            this.hideInactiveChk.Size = new System.Drawing.Size(89, 17);
            this.hideInactiveChk.TabIndex = 0;
            this.hideInactiveChk.Text = "Hide Inactive";
            this.hideInactiveChk.UseVisualStyleBackColor = true;
            this.hideInactiveChk.CheckedChanged += new System.EventHandler(this.hideInactiveChk_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.helpCtrl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(631, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel3.Size = new System.Drawing.Size(16, 24);
            this.panel3.TabIndex = 11;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpCtrl1.Location = new System.Drawing.Point(0, 4);
            this.helpCtrl1.Message = "This area is for searching for care workers. You can use the button to the right " +
    "of filter to specify by name or ENumber.\r\n\r\nA list of the worker icons can be se" +
    "en in the help library.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = false;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 20);
            this.helpCtrl1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 24);
            this.panel2.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.searchTypeBtn);
            this.splitContainer2.Panel2MinSize = 24;
            this.splitContainer2.Size = new System.Drawing.Size(631, 24);
            this.splitContainer2.SplitterDistance = 602;
            this.splitContainer2.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.newworkerbtn);
            this.splitContainer1.Panel1MinSize = 24;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.filter1);
            this.splitContainer1.Size = new System.Drawing.Size(602, 24);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 5;
            // 
            // newworkerbtn
            // 
            this.newworkerbtn.BackColor = System.Drawing.Color.Transparent;
            this.newworkerbtn.CornerRadius = 3;
            this.newworkerbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.newworkerbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newworkerbtn.DrawFocusRect = true;
            this.newworkerbtn.Image = global::Cura.Properties.Resources.add_user;
            this.newworkerbtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.newworkerbtn.ImageSize = new System.Drawing.Size(16, 16);
            this.newworkerbtn.IsSplitButton = false;
            this.newworkerbtn.Location = new System.Drawing.Point(0, 0);
            this.newworkerbtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.newworkerbtn.Name = "newworkerbtn";
            this.newworkerbtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.newworkerbtn.Renderer = officeButtonRenderer1;
            this.newworkerbtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.newworkerbtn.Size = new System.Drawing.Size(25, 24);
            this.newworkerbtn.SplitButtonWidth = 20;
            this.newworkerbtn.TabIndex = 5;
            this.newworkerbtn.Click += new System.EventHandler(this.newworkerbtn_Click_1);
            // 
            // filter1
            // 
            this.filter1.BackColor = System.Drawing.Color.White;
            this.filter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter1.Location = new System.Drawing.Point(0, 0);
            this.filter1.Name = "filter1";
            this.filter1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.filter1.Size = new System.Drawing.Size(573, 24);
            this.filter1.TabIndex = 2;
            this.filter1.TextChanged += new System.EventHandler(this.filter1_TextChanged);
            // 
            // searchTypeBtn
            // 
            this.searchTypeBtn.BackColor = System.Drawing.Color.Transparent;
            this.searchTypeBtn.CornerRadius = 3;
            this.searchTypeBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.searchTypeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTypeBtn.DrawFocusRect = true;
            this.searchTypeBtn.Image = global::Cura.Properties.Resources.font;
            this.searchTypeBtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.searchTypeBtn.ImageSize = new System.Drawing.Size(16, 16);
            this.searchTypeBtn.IsSplitButton = false;
            this.searchTypeBtn.Location = new System.Drawing.Point(0, 0);
            this.searchTypeBtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.searchTypeBtn.Name = "searchTypeBtn";
            this.searchTypeBtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer2.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.searchTypeBtn.Renderer = officeButtonRenderer2;
            this.searchTypeBtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.searchTypeBtn.Size = new System.Drawing.Size(25, 24);
            this.searchTypeBtn.SplitButtonWidth = 20;
            this.searchTypeBtn.TabIndex = 2;
            this.searchTypeBtn.Click += new System.EventHandler(this.searchTypeBtn_Click_1);
            // 
            // WorkerListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WorkerListCtrl";
            this.Size = new System.Drawing.Size(647, 343);
            this.Load += new System.EventHandler(this.WorkerListCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printRotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailRotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
       private System.Windows.Forms.ToolStripMenuItem duplicateUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox hideInactiveChk;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.Panel panel3;
        private HelpCtrl helpCtrl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CG.Controls.Grid.Buttons.ExButton newworkerbtn;
        private Common.Filter filter1;
        private CG.Controls.Grid.Buttons.ExButton searchTypeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addToGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromGroupToolStripMenuItem;
    }
}
