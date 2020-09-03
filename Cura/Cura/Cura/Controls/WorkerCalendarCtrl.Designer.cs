namespace Cura.Controls
{
    partial class WorkerCalendarCtrl
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
            this.worker_calendar = new System.Windows.Forms.Calendar.Calendar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsHolidayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeHolidayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsSickDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayOnlyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.weeksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSickDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoWeeksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unassignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.workernamelbl = new System.Windows.Forms.Label();
            this.overtimeTxt = new System.Windows.Forms.TextBox();
            this.overtimelbl = new System.Windows.Forms.Label();
            this.unassignedTxt = new System.Windows.Forms.TextBox();
            this.unassignedlbl = new System.Windows.Forms.Label();
            this.assignedTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.dayHeaderTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.worker_calendar);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.vScrollBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(978, 553);
            this.splitContainer1.SplitterDistance = 777;
            this.splitContainer1.TabIndex = 2;
            // 
            // worker_calendar
            // 
            this.worker_calendar.AllowItemEdit = false;
            this.worker_calendar.AllowItemResize = false;
            this.worker_calendar.AllowNew = false;
            this.worker_calendar.AutoScroll = true;
            this.worker_calendar.ColorScheme = 1;
            this.worker_calendar.ContextMenuStrip = this.contextMenuStrip1;
            this.worker_calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worker_calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.worker_calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[0];
            this.worker_calendar.ItemIndent = false;
            this.worker_calendar.Location = new System.Drawing.Point(0, 0);
            this.worker_calendar.Name = "worker_calendar";
            this.worker_calendar.Size = new System.Drawing.Size(758, 521);
            this.worker_calendar.TabIndex = 1;
            this.worker_calendar.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
            this.worker_calendar.TimeUnitOffSetMax = -20;
            this.worker_calendar.TimeUnitOffSetMin = -6;
            this.worker_calendar.TimeUnitsVisible = 4;
            this.worker_calendar.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.worker_calendar_ItemDeleted);
            this.worker_calendar.ItemMouseHover += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.worker_calendar_ItemMouseHover);
            this.worker_calendar.ItemMouseLeave += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.worker_calendar_ItemMouseLeave);
            this.worker_calendar.MouseEnterDayTop += new System.Windows.Forms.Calendar.Calendar.CalendarDayTopEventHandler(this.worker_calendar_MouseEnterDayTop);
            this.worker_calendar.MouseLeaveDayTop += new System.Windows.Forms.Calendar.Calendar.CalendarDayTopEventHandler(this.worker_calendar_MouseLeaveDayTop);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsHolidayToolStripMenuItem,
            this.removeHolidayToolStripMenuItem,
            this.setAsSickDayToolStripMenuItem,
            this.removeSickDayToolStripMenuItem,
            this.setAsTrainingToolStripMenuItem,
            this.removeTrainingToolStripMenuItem,
            this.unassignToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 158);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // setAsHolidayToolStripMenuItem
            // 
            this.setAsHolidayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayOnlyToolStripMenuItem,
            this.weekToolStripMenuItem,
            this.weeksToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.setAsHolidayToolStripMenuItem.Image = global::Cura.Properties.Resources.transmit_go;
            this.setAsHolidayToolStripMenuItem.Name = "setAsHolidayToolStripMenuItem";
            this.setAsHolidayToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setAsHolidayToolStripMenuItem.Text = "Set As Holiday";
            // 
            // todayOnlyToolStripMenuItem
            // 
            this.todayOnlyToolStripMenuItem.Name = "todayOnlyToolStripMenuItem";
            this.todayOnlyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.todayOnlyToolStripMenuItem.Text = "Selection";
            this.todayOnlyToolStripMenuItem.Click += new System.EventHandler(this.selectionToolStripMenuItem_Click);
            // 
            // weekToolStripMenuItem
            // 
            this.weekToolStripMenuItem.Name = "weekToolStripMenuItem";
            this.weekToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.weekToolStripMenuItem.Text = "1 Week";
            this.weekToolStripMenuItem.Click += new System.EventHandler(this.weekToolStripMenuItem_Click);
            // 
            // weeksToolStripMenuItem
            // 
            this.weeksToolStripMenuItem.Name = "weeksToolStripMenuItem";
            this.weeksToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.weeksToolStripMenuItem.Text = "2 Weeks";
            this.weeksToolStripMenuItem.Click += new System.EventHandler(this.weeksToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.otherToolStripMenuItem.Text = "Other...";
            this.otherToolStripMenuItem.Click += new System.EventHandler(this.otherToolStripMenuItem_Click);
            // 
            // removeHolidayToolStripMenuItem
            // 
            this.removeHolidayToolStripMenuItem.Image = global::Cura.Properties.Resources.transmit_remove;
            this.removeHolidayToolStripMenuItem.Name = "removeHolidayToolStripMenuItem";
            this.removeHolidayToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeHolidayToolStripMenuItem.Text = "Remove Holiday";
            this.removeHolidayToolStripMenuItem.Click += new System.EventHandler(this.removeHolidayToolStripMenuItem_Click);
            // 
            // setAsSickDayToolStripMenuItem
            // 
            this.setAsSickDayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayOnlyToolStripMenuItem1,
            this.weekToolStripMenuItem1,
            this.weeksToolStripMenuItem1,
            this.otherToolStripMenuItem1});
            this.setAsSickDayToolStripMenuItem.Image = global::Cura.Properties.Resources.thermometer_go_icon;
            this.setAsSickDayToolStripMenuItem.Name = "setAsSickDayToolStripMenuItem";
            this.setAsSickDayToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setAsSickDayToolStripMenuItem.Text = "Set As Sick Day";
            // 
            // todayOnlyToolStripMenuItem1
            // 
            this.todayOnlyToolStripMenuItem1.Name = "todayOnlyToolStripMenuItem1";
            this.todayOnlyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.todayOnlyToolStripMenuItem1.Text = "Selection";
            this.todayOnlyToolStripMenuItem1.Click += new System.EventHandler(this.selectionToolStripMenuItem1_Click);
            // 
            // weekToolStripMenuItem1
            // 
            this.weekToolStripMenuItem1.Name = "weekToolStripMenuItem1";
            this.weekToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.weekToolStripMenuItem1.Text = "1 Week";
            this.weekToolStripMenuItem1.Click += new System.EventHandler(this.weekToolStripMenuItem1_Click);
            // 
            // weeksToolStripMenuItem1
            // 
            this.weeksToolStripMenuItem1.Name = "weeksToolStripMenuItem1";
            this.weeksToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.weeksToolStripMenuItem1.Text = "2 Weeks";
            this.weeksToolStripMenuItem1.Click += new System.EventHandler(this.weeksToolStripMenuItem1_Click);
            // 
            // otherToolStripMenuItem1
            // 
            this.otherToolStripMenuItem1.Name = "otherToolStripMenuItem1";
            this.otherToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.otherToolStripMenuItem1.Text = "Other";
            this.otherToolStripMenuItem1.Click += new System.EventHandler(this.otherToolStripMenuItem1_Click);
            // 
            // removeSickDayToolStripMenuItem
            // 
            this.removeSickDayToolStripMenuItem.Image = global::Cura.Properties.Resources.thermometer_remove_icon;
            this.removeSickDayToolStripMenuItem.Name = "removeSickDayToolStripMenuItem";
            this.removeSickDayToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSickDayToolStripMenuItem.Text = "Remove Sick Day";
            this.removeSickDayToolStripMenuItem.Click += new System.EventHandler(this.removeSickDayToolStripMenuItem_Click);
            // 
            // setAsTrainingToolStripMenuItem
            // 
            this.setAsTrainingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionToolStripMenuItem,
            this.oneWeekToolStripMenuItem,
            this.twoWeeksToolStripMenuItem,
            this.otherToolStripMenuItem2});
            this.setAsTrainingToolStripMenuItem.Image = global::Cura.Properties.Resources.training;
            this.setAsTrainingToolStripMenuItem.Name = "setAsTrainingToolStripMenuItem";
            this.setAsTrainingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setAsTrainingToolStripMenuItem.Text = "Set As Training";
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.selectionToolStripMenuItem.Text = "Selection";
            this.selectionToolStripMenuItem.Click += new System.EventHandler(this.selectionToolStripMenuItem_Click_1);
            // 
            // oneWeekToolStripMenuItem
            // 
            this.oneWeekToolStripMenuItem.Name = "oneWeekToolStripMenuItem";
            this.oneWeekToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.oneWeekToolStripMenuItem.Text = "One Week";
            this.oneWeekToolStripMenuItem.Click += new System.EventHandler(this.oneWeekToolStripMenuItem_Click);
            // 
            // twoWeeksToolStripMenuItem
            // 
            this.twoWeeksToolStripMenuItem.Name = "twoWeeksToolStripMenuItem";
            this.twoWeeksToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.twoWeeksToolStripMenuItem.Text = "Two Weeks";
            this.twoWeeksToolStripMenuItem.Click += new System.EventHandler(this.twoWeeksToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem2
            // 
            this.otherToolStripMenuItem2.Name = "otherToolStripMenuItem2";
            this.otherToolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.otherToolStripMenuItem2.Text = "Other...";
            this.otherToolStripMenuItem2.Click += new System.EventHandler(this.otherToolStripMenuItem2_Click);
            // 
            // removeTrainingToolStripMenuItem
            // 
            this.removeTrainingToolStripMenuItem.Image = global::Cura.Properties.Resources.training_remove;
            this.removeTrainingToolStripMenuItem.Name = "removeTrainingToolStripMenuItem";
            this.removeTrainingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeTrainingToolStripMenuItem.Text = "Remove Training";
            this.removeTrainingToolStripMenuItem.Click += new System.EventHandler(this.removeTrainingToolStripMenuItem_Click);
            // 
            // unassignToolStripMenuItem
            // 
            this.unassignToolStripMenuItem.Image = global::Cura.Properties.Resources.delete_icon;
            this.unassignToolStripMenuItem.Name = "unassignToolStripMenuItem";
            this.unassignToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.unassignToolStripMenuItem.Text = "Unassign";
            this.unassignToolStripMenuItem.Click += new System.EventHandler(this.unassignToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.workernamelbl);
            this.panel1.Controls.Add(this.overtimeTxt);
            this.panel1.Controls.Add(this.overtimelbl);
            this.panel1.Controls.Add(this.unassignedTxt);
            this.panel1.Controls.Add(this.unassignedlbl);
            this.panel1.Controls.Add(this.assignedTxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 30);
            this.panel1.TabIndex = 0;
            // 
            // workernamelbl
            // 
            this.workernamelbl.AutoSize = true;
            this.workernamelbl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workernamelbl.Location = new System.Drawing.Point(6, 6);
            this.workernamelbl.Name = "workernamelbl";
            this.workernamelbl.Size = new System.Drawing.Size(19, 19);
            this.workernamelbl.TabIndex = 2;
            this.workernamelbl.Text = "_";
            // 
            // overtimeTxt
            // 
            this.overtimeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.overtimeTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.overtimeTxt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overtimeTxt.Location = new System.Drawing.Point(679, 4);
            this.overtimeTxt.Name = "overtimeTxt";
            this.overtimeTxt.ReadOnly = true;
            this.overtimeTxt.Size = new System.Drawing.Size(73, 22);
            this.overtimeTxt.TabIndex = 1;
            this.overtimeTxt.Visible = false;
            // 
            // overtimelbl
            // 
            this.overtimelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.overtimelbl.AutoSize = true;
            this.overtimelbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overtimelbl.Location = new System.Drawing.Point(587, 8);
            this.overtimelbl.Name = "overtimelbl";
            this.overtimelbl.Size = new System.Drawing.Size(87, 14);
            this.overtimelbl.TabIndex = 0;
            this.overtimelbl.Text = "Overtime (hrs)";
            this.overtimelbl.Visible = false;
            // 
            // unassignedTxt
            // 
            this.unassignedTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unassignedTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.unassignedTxt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedTxt.Location = new System.Drawing.Point(490, 4);
            this.unassignedTxt.Name = "unassignedTxt";
            this.unassignedTxt.ReadOnly = true;
            this.unassignedTxt.Size = new System.Drawing.Size(73, 22);
            this.unassignedTxt.TabIndex = 1;
            this.unassignedTxt.Visible = false;
            // 
            // unassignedlbl
            // 
            this.unassignedlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unassignedlbl.AutoSize = true;
            this.unassignedlbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedlbl.Location = new System.Drawing.Point(389, 8);
            this.unassignedlbl.Name = "unassignedlbl";
            this.unassignedlbl.Size = new System.Drawing.Size(98, 14);
            this.unassignedlbl.TabIndex = 0;
            this.unassignedlbl.Text = "Unassigned (hrs)";
            this.unassignedlbl.Visible = false;
            // 
            // assignedTxt
            // 
            this.assignedTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.assignedTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.assignedTxt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedTxt.Location = new System.Drawing.Point(302, 4);
            this.assignedTxt.Name = "assignedTxt";
            this.assignedTxt.ReadOnly = true;
            this.assignedTxt.Size = new System.Drawing.Size(73, 22);
            this.assignedTxt.TabIndex = 1;
            this.assignedTxt.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Assigned (hrs)";
            this.label2.Visible = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.LargeChange = 2;
            this.vScrollBar1.Location = new System.Drawing.Point(758, 0);
            this.vScrollBar1.Maximum = 12;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 551);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 551);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a worker to view their calendar.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkerCalendarCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkerCalendarCtrl";
            this.Size = new System.Drawing.Size(978, 553);
            this.Load += new System.EventHandler(this.WorkerCalendarCtrl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar worker_calendar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setAsHolidayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeHolidayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsSickDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSickDayToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox overtimeTxt;
        private System.Windows.Forms.Label overtimelbl;
        private System.Windows.Forms.TextBox unassignedTxt;
        private System.Windows.Forms.Label unassignedlbl;
        private System.Windows.Forms.TextBox assignedTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label workernamelbl;
        private System.Windows.Forms.ToolStripMenuItem todayOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weeksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayOnlyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem weeksToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setAsTrainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTrainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoWeeksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem unassignToolStripMenuItem;
        private System.Windows.Forms.ToolTip dayHeaderTooltip;


    }
}
