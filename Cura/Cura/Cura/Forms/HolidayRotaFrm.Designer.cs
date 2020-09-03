namespace Cura.Forms
{
    partial class HolidayRotaFrm
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
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer1 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer2 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HolidayRotaFrm));
            this.holiday_calendar = new System.Windows.Forms.Calendar.Calendar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.dateLbl = new System.Windows.Forms.Label();
            this.decMonthBtn = new CG.Controls.Grid.Buttons.ExButton();
            this.incMonthBtn = new CG.Controls.Grid.Buttons.ExButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // holiday_calendar
            // 
            this.holiday_calendar.AllowItemEdit = false;
            this.holiday_calendar.AllowItemResize = false;
            this.holiday_calendar.AllowNew = false;
            this.holiday_calendar.AutoScroll = true;
            this.holiday_calendar.ColorScheme = 4;
            this.holiday_calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holiday_calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.holiday_calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[0];
            this.holiday_calendar.ItemIndent = false;
            this.holiday_calendar.Location = new System.Drawing.Point(0, 0);
            this.holiday_calendar.Name = "holiday_calendar";
            this.holiday_calendar.Size = new System.Drawing.Size(1089, 422);
            this.holiday_calendar.TabIndex = 2;
            this.holiday_calendar.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.SixtyMinutes;
            this.holiday_calendar.TimeUnitOffSetMax = -16;
            this.holiday_calendar.TimeUnitOffSetMin = -4;
            this.holiday_calendar.TimeUnitsVisible = 8;
            this.holiday_calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.holiday_calendar_ItemDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 81);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.helpCtrl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightGreen;
            this.splitContainer2.Panel2.Controls.Add(this.dateLbl);
            this.splitContainer2.Panel2.Controls.Add(this.decMonthBtn);
            this.splitContainer2.Panel2.Controls.Add(this.incMonthBtn);
            this.splitContainer2.Size = new System.Drawing.Size(1091, 81);
            this.splitContainer2.SplitterDistance = 35;
            this.splitContainer2.TabIndex = 1;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(3, 6);
            this.helpCtrl1.Message = null;
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = false;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 0;
            // 
            // dateLbl
            // 
            this.dateLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateLbl.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.Location = new System.Drawing.Point(300, 0);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(491, 42);
            this.dateLbl.TabIndex = 17;
            this.dateLbl.Text = "Dat eHERE";
            this.dateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decMonthBtn
            // 
            this.decMonthBtn.BackColor = System.Drawing.Color.Transparent;
            this.decMonthBtn.CornerRadius = 3;
            this.decMonthBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.decMonthBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.decMonthBtn.DrawFocusRect = true;
            this.decMonthBtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.decMonthBtn.ImageSize = new System.Drawing.Size(16, 16);
            this.decMonthBtn.IsSplitButton = false;
            this.decMonthBtn.Location = new System.Drawing.Point(0, 0);
            this.decMonthBtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.decMonthBtn.Name = "decMonthBtn";
            this.decMonthBtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.decMonthBtn.Renderer = officeButtonRenderer1;
            this.decMonthBtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.decMonthBtn.Size = new System.Drawing.Size(300, 42);
            this.decMonthBtn.SplitButtonWidth = 20;
            this.decMonthBtn.TabIndex = 16;
            this.decMonthBtn.Text = "<";
            this.decMonthBtn.Click += new System.EventHandler(this.decMonthBtn_Click);
            // 
            // incMonthBtn
            // 
            this.incMonthBtn.BackColor = System.Drawing.Color.Transparent;
            this.incMonthBtn.CornerRadius = 3;
            this.incMonthBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.incMonthBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.incMonthBtn.DrawFocusRect = true;
            this.incMonthBtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.incMonthBtn.ImageSize = new System.Drawing.Size(16, 16);
            this.incMonthBtn.IsSplitButton = false;
            this.incMonthBtn.Location = new System.Drawing.Point(791, 0);
            this.incMonthBtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.incMonthBtn.Name = "incMonthBtn";
            this.incMonthBtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer2.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.incMonthBtn.Renderer = officeButtonRenderer2;
            this.incMonthBtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.incMonthBtn.Size = new System.Drawing.Size(300, 42);
            this.incMonthBtn.SplitButtonWidth = 20;
            this.incMonthBtn.TabIndex = 15;
            this.incMonthBtn.Text = ">";
            this.incMonthBtn.Click += new System.EventHandler(this.incMonthBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.holiday_calendar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1091, 424);
            this.panel3.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 113);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel3);
            this.splitContainer3.Size = new System.Drawing.Size(1091, 453);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Holidays";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(125, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Day Offs";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HolidayRotaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 566);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::Cura.Properties.Resources.transmit_go;
            this.Name = "HolidayRotaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Holiday Rota";
            this.Title = "Holiday Rota";
            this.Load += new System.EventHandler(this.HolidayRotaFrm_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.splitContainer3, 0);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar holiday_calendar;
        private System.Windows.Forms.Panel panel2;
        private Controls.HelpCtrl helpCtrl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label dateLbl;
        private CG.Controls.Grid.Buttons.ExButton decMonthBtn;
        private CG.Controls.Grid.Buttons.ExButton incMonthBtn;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}