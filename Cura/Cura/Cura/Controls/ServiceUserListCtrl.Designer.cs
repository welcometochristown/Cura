namespace Cura.Controls
{
    partial class ServiceUserListCtrl
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
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer1 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer2 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewUnassignedCallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.addServiceUserBtn = new CG.Controls.Grid.Buttons.ExButton();
            this.filter2 = new Cura.Controls.Common.Filter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hideEmptyChk = new System.Windows.Forms.CheckBox();
            this.hideFullAssignedChk = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.searchTypeBtn = new CG.Controls.Grid.Buttons.ExButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.objectListView1.MultiSelect = false;
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.ShowImagesOnSubItems = true;
            this.objectListView1.Size = new System.Drawing.Size(445, 309);
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectionChanged += new System.EventHandler(this.objectListView1_SelectionChanged_1);
            this.objectListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objectListView1_MouseDoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 100;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "PNumber";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.Text = "PNumber";
            // 
            // olvColumn2
            // 
            this.olvColumn2.ImageAspectName = "PropertiesImage";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.viewUnassignedCallsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 104);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Cura.Properties.Resources.application_edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Image = global::Cura.Properties.Resources.page_copy_icon;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Cura.Properties.Resources.user_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // viewUnassignedCallsToolStripMenuItem
            // 
            this.viewUnassignedCallsToolStripMenuItem.Enabled = false;
            this.viewUnassignedCallsToolStripMenuItem.Name = "viewUnassignedCallsToolStripMenuItem";
            this.viewUnassignedCallsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewUnassignedCallsToolStripMenuItem.Text = "View Unassigned Calls";
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
            this.splitContainer1.Panel1.Controls.Add(this.addServiceUserBtn);
            this.splitContainer1.Panel1MinSize = 24;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.filter2);
            this.splitContainer1.Size = new System.Drawing.Size(400, 24);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 6;
            // 
            // addServiceUserBtn
            // 
            this.addServiceUserBtn.BackColor = System.Drawing.Color.Transparent;
            this.addServiceUserBtn.CornerRadius = 3;
            this.addServiceUserBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.addServiceUserBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addServiceUserBtn.DrawFocusRect = true;
            this.addServiceUserBtn.Image = global::Cura.Properties.Resources.s_user_add;
            this.addServiceUserBtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.addServiceUserBtn.ImageSize = new System.Drawing.Size(16, 16);
            this.addServiceUserBtn.IsSplitButton = false;
            this.addServiceUserBtn.Location = new System.Drawing.Point(0, 0);
            this.addServiceUserBtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.addServiceUserBtn.Name = "addServiceUserBtn";
            this.addServiceUserBtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.addServiceUserBtn.Renderer = officeButtonRenderer1;
            this.addServiceUserBtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.addServiceUserBtn.Size = new System.Drawing.Size(25, 24);
            this.addServiceUserBtn.SplitButtonWidth = 20;
            this.addServiceUserBtn.TabIndex = 0;
            this.addServiceUserBtn.Click += new System.EventHandler(this.addServiceUserBtn_Click);
            // 
            // filter2
            // 
            this.filter2.BackColor = System.Drawing.Color.White;
            this.filter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filter2.Location = new System.Drawing.Point(0, 0);
            this.filter2.Name = "filter2";
            this.filter2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.filter2.Size = new System.Drawing.Size(371, 24);
            this.filter2.TabIndex = 0;
            this.filter2.TextChanged += new System.EventHandler(this.filter1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hideEmptyChk);
            this.panel1.Controls.Add(this.hideFullAssignedChk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 25);
            this.panel1.TabIndex = 7;
            // 
            // hideEmptyChk
            // 
            this.hideEmptyChk.AutoSize = true;
            this.hideEmptyChk.Location = new System.Drawing.Point(130, 5);
            this.hideEmptyChk.Name = "hideEmptyChk";
            this.hideEmptyChk.Size = new System.Drawing.Size(90, 17);
            this.hideEmptyChk.TabIndex = 0;
            this.hideEmptyChk.Text = "Hide No Calls";
            this.hideEmptyChk.UseVisualStyleBackColor = true;
            this.hideEmptyChk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // hideFullAssignedChk
            // 
            this.hideFullAssignedChk.AutoSize = true;
            this.hideFullAssignedChk.Location = new System.Drawing.Point(6, 6);
            this.hideFullAssignedChk.Name = "hideFullAssignedChk";
            this.hideFullAssignedChk.Size = new System.Drawing.Size(118, 17);
            this.hideFullAssignedChk.TabIndex = 0;
            this.hideFullAssignedChk.Text = "Hide Fully Assigned";
            this.hideFullAssignedChk.UseVisualStyleBackColor = true;
            this.hideFullAssignedChk.CheckedChanged += new System.EventHandler(this.hideFullAssignedChk_CheckedChanged);
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
            this.splitContainer2.Size = new System.Drawing.Size(429, 24);
            this.splitContainer2.SplitterDistance = 400;
            this.splitContainer2.TabIndex = 8;
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
            this.searchTypeBtn.TabIndex = 1;
            this.searchTypeBtn.Click += new System.EventHandler(this.searchTypeBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 24);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.helpCtrl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(429, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panel3.Size = new System.Drawing.Size(16, 24);
            this.panel3.TabIndex = 12;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpCtrl1.Location = new System.Drawing.Point(0, 4);
            this.helpCtrl1.Message = "This area is for searching for service users. You can use the button to the right" +
    " of filter to specify by name or PNumber.\r\n\r\nA list of the service user icons ca" +
    "n be seen in the help library.\r\n";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = false;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 20);
            this.helpCtrl1.TabIndex = 0;
            // 
            // ServiceUserListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ServiceUserListCtrl";
            this.Size = new System.Drawing.Size(445, 358);
            this.Load += new System.EventHandler(this.ServiceUserListCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Common.Filter filter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private Common.Filter filter2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox hideFullAssignedChk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private System.Windows.Forms.CheckBox hideEmptyChk;
        private CG.Controls.Grid.Buttons.ExButton addServiceUserBtn;
        private System.Windows.Forms.ToolStripMenuItem viewUnassignedCallsToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CG.Controls.Grid.Buttons.ExButton searchTypeBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private HelpCtrl helpCtrl1;
    }
}
