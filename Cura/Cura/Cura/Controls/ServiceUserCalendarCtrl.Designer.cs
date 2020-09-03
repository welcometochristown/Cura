namespace Cura.Controls
{
    partial class ServiceUserCalendarCtrl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.serviceuser_calendar = new System.Windows.Forms.Calendar.Calendar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flagItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTop10WorkersForThisCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelFutureCallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpCtrl2 = new Cura.Controls.HelpCtrl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.serviceusernamelbl = new System.Windows.Forms.Label();
            this.unassignedTxt = new System.Windows.Forms.TextBox();
            this.assignedTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.unassignedlbl = new System.Windows.Forms.Label();
            this.callsTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.doubleworker_unassignedImg = new System.Windows.Forms.PictureBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.doubleworker_halfunassignedImg = new System.Windows.Forms.PictureBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.doubleworkerImg = new System.Windows.Forms.PictureBox();
            this.singleworker_unassignedImg = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.singleWorkerImg = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.serviceuser_calendar.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleworker_unassignedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleworker_halfunassignedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleworkerImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleworker_unassignedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleWorkerImg)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.serviceuser_calendar);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1167, 519);
            this.splitContainer1.SplitterDistance = 1006;
            this.splitContainer1.TabIndex = 3;
            // 
            // serviceuser_calendar
            // 
            this.serviceuser_calendar.AllowItemEdit = false;
            this.serviceuser_calendar.AllowItemResize = false;
            this.serviceuser_calendar.AutoScroll = true;
            this.serviceuser_calendar.ColorScheme = 3;
            this.serviceuser_calendar.ContextMenuStrip = this.contextMenuStrip1;
            this.serviceuser_calendar.Controls.Add(this.helpCtrl2);
            this.serviceuser_calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceuser_calendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.serviceuser_calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.serviceuser_calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[0];
            this.serviceuser_calendar.ItemIndent = false;
            this.serviceuser_calendar.Location = new System.Drawing.Point(0, 0);
            this.serviceuser_calendar.Name = "serviceuser_calendar";
            this.serviceuser_calendar.Size = new System.Drawing.Size(1004, 487);
            this.serviceuser_calendar.TabIndex = 2;
            this.serviceuser_calendar.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
            this.serviceuser_calendar.TimeUnitOffSetMax = 0;
            this.serviceuser_calendar.TimeUnitOffSetMin = 0;
            this.serviceuser_calendar.TimeUnitsVisible = 4;
            this.serviceuser_calendar.UseTOD = true;
            this.serviceuser_calendar.ItemCreating += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar_ItemCreating);
            this.serviceuser_calendar.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.serviceuser_calendar_ItemDeleted);
            this.serviceuser_calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.serviceuser_calendar_ItemDoubleClick);
            this.serviceuser_calendar.ItemMouseHover += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.serviceuser_calendar_ItemMouseHover);
            this.serviceuser_calendar.ItemMouseLeave += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.serviceuser_calendar_ItemMouseLeave);
            this.serviceuser_calendar.GlobalMouseDown += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar_GlobalMouseDown);
            this.serviceuser_calendar.GlobalMouseUp += new System.Windows.Forms.MouseEventHandler(this.calendar_GlobalMouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.flagItToolStripMenuItem,
            this.toolStripSeparator1,
            this.duplicateToolStripMenuItem,
            this.viewTop10WorkersForThisCallToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem,
            this.cancelFutureCallsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 148);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Cura.Properties.Resources.application_edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // flagItToolStripMenuItem
            // 
            this.flagItToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.orangeToolStripMenuItem,
            this.pinkToolStripMenuItem,
            this.purpleToolStripMenuItem,
            this.redToolStripMenuItem1,
            this.yellowToolStripMenuItem});
            this.flagItToolStripMenuItem.Image = global::Cura.Properties.Resources.flag_blue;
            this.flagItToolStripMenuItem.Name = "flagItToolStripMenuItem";
            this.flagItToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.flagItToolStripMenuItem.Text = "Flag It!";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Image = global::Cura.Properties.Resources.flag_blue;
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Image = global::Cura.Properties.Resources.flag_green;
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // orangeToolStripMenuItem
            // 
            this.orangeToolStripMenuItem.Image = global::Cura.Properties.Resources.flag_orange;
            this.orangeToolStripMenuItem.Name = "orangeToolStripMenuItem";
            this.orangeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.orangeToolStripMenuItem.Text = "Orange";
            this.orangeToolStripMenuItem.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // pinkToolStripMenuItem
            // 
            this.pinkToolStripMenuItem.Image = global::Cura.Properties.Resources.flag_pink;
            this.pinkToolStripMenuItem.Name = "pinkToolStripMenuItem";
            this.pinkToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.pinkToolStripMenuItem.Text = "Pink";
            this.pinkToolStripMenuItem.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // purpleToolStripMenuItem
            // 
            this.purpleToolStripMenuItem.Image = global::Cura.Properties.Resources.flag_purple;
            this.purpleToolStripMenuItem.Name = "purpleToolStripMenuItem";
            this.purpleToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.purpleToolStripMenuItem.Text = "Purple";
            this.purpleToolStripMenuItem.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // redToolStripMenuItem1
            // 
            this.redToolStripMenuItem1.Image = global::Cura.Properties.Resources.flag_red;
            this.redToolStripMenuItem1.Name = "redToolStripMenuItem1";
            this.redToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.redToolStripMenuItem1.Text = "Red";
            this.redToolStripMenuItem1.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // yellowToolStripMenuItem
            // 
            this.yellowToolStripMenuItem.Image = global::Cura.Properties.Resources.flag_yellow;
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.yellowToolStripMenuItem.Text = "Yellow";
            this.yellowToolStripMenuItem.Click += new System.EventHandler(this.flagToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Image = global::Cura.Properties.Resources.page_copy;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // viewTop10WorkersForThisCallToolStripMenuItem
            // 
            this.viewTop10WorkersForThisCallToolStripMenuItem.Image = global::Cura.Properties.Resources.user_question;
            this.viewTop10WorkersForThisCallToolStripMenuItem.Name = "viewTop10WorkersForThisCallToolStripMenuItem";
            this.viewTop10WorkersForThisCallToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.viewTop10WorkersForThisCallToolStripMenuItem.Text = "Top 10 Relevant Workers";
            this.viewTop10WorkersForThisCallToolStripMenuItem.Click += new System.EventHandler(this.viewTop10WorkersForThisCallToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Cura.Properties.Resources.delete_icon;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cancelFutureCallsToolStripMenuItem
            // 
            this.cancelFutureCallsToolStripMenuItem.Image = global::Cura.Properties.Resources.eraser;
            this.cancelFutureCallsToolStripMenuItem.Name = "cancelFutureCallsToolStripMenuItem";
            this.cancelFutureCallsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.cancelFutureCallsToolStripMenuItem.Text = "Delete Future Calls";
            this.cancelFutureCallsToolStripMenuItem.Click += new System.EventHandler(this.cancelFutureCallsToolStripMenuItem_Click);
            // 
            // helpCtrl2
            // 
            this.helpCtrl2.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl2.Caption = null;
            this.helpCtrl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl2.Location = new System.Drawing.Point(27, 14);
            this.helpCtrl2.Message = "Double click a cell to create a call for this service user.\r\n\r\nCalls can be assig" +
    "ned by holding CTRL and dragging the call into the workers calendar.";
            this.helpCtrl2.Name = "helpCtrl2";
            this.helpCtrl2.OpenLeft = false;
            this.helpCtrl2.OpenUp = false;
            this.helpCtrl2.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.serviceusernamelbl);
            this.panel1.Controls.Add(this.unassignedTxt);
            this.panel1.Controls.Add(this.assignedTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.unassignedlbl);
            this.panel1.Controls.Add(this.callsTxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.helpCtrl1);
            this.panel1.Controls.Add(this.doubleworker_unassignedImg);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.doubleworker_halfunassignedImg);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.doubleworkerImg);
            this.panel1.Controls.Add(this.singleworker_unassignedImg);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.singleWorkerImg);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 30);
            this.panel1.TabIndex = 3;
            // 
            // serviceusernamelbl
            // 
            this.serviceusernamelbl.AutoSize = true;
            this.serviceusernamelbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceusernamelbl.Location = new System.Drawing.Point(5, 6);
            this.serviceusernamelbl.Name = "serviceusernamelbl";
            this.serviceusernamelbl.Size = new System.Drawing.Size(19, 19);
            this.serviceusernamelbl.TabIndex = 16;
            this.serviceusernamelbl.Text = "_";
            // 
            // unassignedTxt
            // 
            this.unassignedTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unassignedTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.unassignedTxt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedTxt.Location = new System.Drawing.Point(613, 4);
            this.unassignedTxt.Name = "unassignedTxt";
            this.unassignedTxt.ReadOnly = true;
            this.unassignedTxt.Size = new System.Drawing.Size(40, 22);
            this.unassignedTxt.TabIndex = 14;
            this.unassignedTxt.Visible = false;
            // 
            // assignedTxt
            // 
            this.assignedTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assignedTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.assignedTxt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedTxt.Location = new System.Drawing.Point(459, 5);
            this.assignedTxt.Name = "assignedTxt";
            this.assignedTxt.ReadOnly = true;
            this.assignedTxt.Size = new System.Drawing.Size(40, 22);
            this.assignedTxt.TabIndex = 14;
            this.assignedTxt.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(508, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Unasssigned (hrs)";
            this.label3.Visible = false;
            // 
            // unassignedlbl
            // 
            this.unassignedlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unassignedlbl.AutoSize = true;
            this.unassignedlbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedlbl.Location = new System.Drawing.Point(368, 8);
            this.unassignedlbl.Name = "unassignedlbl";
            this.unassignedlbl.Size = new System.Drawing.Size(90, 14);
            this.unassignedlbl.TabIndex = 12;
            this.unassignedlbl.Text = "Asssigned (hrs)";
            this.unassignedlbl.Visible = false;
            // 
            // callsTxt
            // 
            this.callsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.callsTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.callsTxt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callsTxt.Location = new System.Drawing.Point(313, 5);
            this.callsTxt.Name = "callsTxt";
            this.callsTxt.ReadOnly = true;
            this.callsTxt.Size = new System.Drawing.Size(40, 22);
            this.callsTxt.TabIndex = 15;
            this.callsTxt.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Calls (hrs)";
            this.label2.Visible = false;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = "Calendar Filters";
            this.helpCtrl1.Location = new System.Drawing.Point(983, 6);
            this.helpCtrl1.Message = "These tick boxes let you filter the calls that are shown in the service user\'s ca" +
    "lendar. \r\n\r\nTo view what each one does, hover the mouse of the checkbox.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = true;
            this.helpCtrl1.OpenUp = true;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 0;
            // 
            // doubleworker_unassignedImg
            // 
            this.doubleworker_unassignedImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleworker_unassignedImg.BackgroundImage = global::Cura.Properties.Resources.double_user_bw;
            this.doubleworker_unassignedImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doubleworker_unassignedImg.Location = new System.Drawing.Point(926, 6);
            this.doubleworker_unassignedImg.Name = "doubleworker_unassignedImg";
            this.doubleworker_unassignedImg.Size = new System.Drawing.Size(32, 16);
            this.doubleworker_unassignedImg.TabIndex = 11;
            this.doubleworker_unassignedImg.TabStop = false;
            this.doubleworker_unassignedImg.MouseHover += new System.EventHandler(this.doubleworker_unassignedImg_MouseHover);
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(961, 8);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // doubleworker_halfunassignedImg
            // 
            this.doubleworker_halfunassignedImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleworker_halfunassignedImg.BackgroundImage = global::Cura.Properties.Resources.double_user_bwhalf;
            this.doubleworker_halfunassignedImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doubleworker_halfunassignedImg.Location = new System.Drawing.Point(862, 6);
            this.doubleworker_halfunassignedImg.Name = "doubleworker_halfunassignedImg";
            this.doubleworker_halfunassignedImg.Size = new System.Drawing.Size(32, 16);
            this.doubleworker_halfunassignedImg.TabIndex = 9;
            this.doubleworker_halfunassignedImg.TabStop = false;
            this.doubleworker_halfunassignedImg.MouseHover += new System.EventHandler(this.doubleworker_halfunassignedImg_MouseHover);
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(897, 8);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // doubleworkerImg
            // 
            this.doubleworkerImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleworkerImg.BackgroundImage = global::Cura.Properties.Resources.double_user;
            this.doubleworkerImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doubleworkerImg.Location = new System.Drawing.Point(747, 6);
            this.doubleworkerImg.Name = "doubleworkerImg";
            this.doubleworkerImg.Size = new System.Drawing.Size(32, 16);
            this.doubleworkerImg.TabIndex = 9;
            this.doubleworkerImg.TabStop = false;
            this.doubleworkerImg.MouseHover += new System.EventHandler(this.doubleworkerImg_MouseHover);
            // 
            // singleworker_unassignedImg
            // 
            this.singleworker_unassignedImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.singleworker_unassignedImg.BackgroundImage = global::Cura.Properties.Resources.user_bw;
            this.singleworker_unassignedImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.singleworker_unassignedImg.Location = new System.Drawing.Point(812, 6);
            this.singleworker_unassignedImg.Name = "singleworker_unassignedImg";
            this.singleworker_unassignedImg.Size = new System.Drawing.Size(16, 16);
            this.singleworker_unassignedImg.TabIndex = 7;
            this.singleworker_unassignedImg.TabStop = false;
            this.singleworker_unassignedImg.MouseHover += new System.EventHandler(this.singleworker_unassignedImg_MouseHover);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(782, 8);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(831, 8);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // singleWorkerImg
            // 
            this.singleWorkerImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.singleWorkerImg.BackgroundImage = global::Cura.Properties.Resources.user;
            this.singleWorkerImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.singleWorkerImg.Location = new System.Drawing.Point(696, 6);
            this.singleWorkerImg.Name = "singleWorkerImg";
            this.singleWorkerImg.Size = new System.Drawing.Size(15, 16);
            this.singleWorkerImg.TabIndex = 7;
            this.singleWorkerImg.TabStop = false;
            this.singleWorkerImg.MouseHover += new System.EventHandler(this.singleWorkerImg_MouseHover);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(715, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 517);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a service user to view their calendar.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServiceUserCalendarCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ServiceUserCalendarCtrl";
            this.Size = new System.Drawing.Size(1167, 519);
            this.Load += new System.EventHandler(this.UserCalendarCtrl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.serviceuser_calendar.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleworker_unassignedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleworker_halfunassignedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleworkerImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleworker_unassignedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleWorkerImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar serviceuser_calendar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox doubleworker_unassignedImg;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.PictureBox doubleworker_halfunassignedImg;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.PictureBox doubleworkerImg;
        private System.Windows.Forms.PictureBox singleworker_unassignedImg;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.PictureBox singleWorkerImg;
        private System.Windows.Forms.CheckBox checkBox1;
        private HelpCtrl helpCtrl1;
        private HelpCtrl helpCtrl2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewTop10WorkersForThisCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flagItToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelFutureCallsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.TextBox unassignedTxt;
        private System.Windows.Forms.TextBox assignedTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label unassignedlbl;
        private System.Windows.Forms.TextBox callsTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label serviceusernamelbl;
    }
}
