using System;
namespace Cura.Controls.Common.Calendar
{
    partial class CalendarCtrl : System.Windows.Forms.UserControl, System.Collections.Generic.IEnumerable<CalendarDayItem>
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
            this.mondaylbl = new System.Windows.Forms.Label();
            this.tuesdaylbl = new System.Windows.Forms.Label();
            this.wednesdaylbl = new System.Windows.Forms.Label();
            this.thursdaylbl = new System.Windows.Forms.Label();
            this.fridaylbl = new System.Windows.Forms.Label();
            this.saturdaylbl = new System.Windows.Forms.Label();
            this.sundaylbl = new System.Windows.Forms.Label();
            this.monthyearlbl = new System.Windows.Forms.Label();
            this.nxtmonthbtn = new System.Windows.Forms.Button();
            this.prvmonthbtn = new System.Windows.Forms.Button();
            this.prvyearbtn = new System.Windows.Forms.Button();
            this.nxtyearbtn = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.CalenderDayCtrl14 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl13 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl12 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl42 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl41 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl40 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl39 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl38 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl37 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl36 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl35 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl34 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl33 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl32 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl31 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl30 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl29 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl28 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl27 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl26 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl25 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl24 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl23 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl22 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl21 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl20 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl19 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl18 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl17 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl16 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl15 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl11 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl10 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl9 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl8 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl7 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl6 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl5 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl4 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl3 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl2 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.CalenderDayCtrl1 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Button1 = new System.Windows.Forms.Button();
            this.daydatelbl = new System.Windows.Forms.Label();
            this.CalenderDayCtrl43 = new Cura.Controls.Common.Calendar.CalendarDayCtrl();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mondaylbl
            // 
            this.mondaylbl.AutoSize = true;
            this.mondaylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mondaylbl.Location = new System.Drawing.Point(196, 50);
            this.mondaylbl.Name = "mondaylbl";
            this.mondaylbl.Size = new System.Drawing.Size(51, 13);
            this.mondaylbl.TabIndex = 0;
            this.mondaylbl.Text = "Monday";
            // 
            // tuesdaylbl
            // 
            this.tuesdaylbl.AutoSize = true;
            this.tuesdaylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuesdaylbl.Location = new System.Drawing.Point(325, 50);
            this.tuesdaylbl.Name = "tuesdaylbl";
            this.tuesdaylbl.Size = new System.Drawing.Size(55, 13);
            this.tuesdaylbl.TabIndex = 0;
            this.tuesdaylbl.Text = "Tuesday";
            // 
            // wednesdaylbl
            // 
            this.wednesdaylbl.AutoSize = true;
            this.wednesdaylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wednesdaylbl.Location = new System.Drawing.Point(458, 50);
            this.wednesdaylbl.Name = "wednesdaylbl";
            this.wednesdaylbl.Size = new System.Drawing.Size(73, 13);
            this.wednesdaylbl.TabIndex = 0;
            this.wednesdaylbl.Text = "Wednesday";
            // 
            // thursdaylbl
            // 
            this.thursdaylbl.AutoSize = true;
            this.thursdaylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thursdaylbl.Location = new System.Drawing.Point(611, 50);
            this.thursdaylbl.Name = "thursdaylbl";
            this.thursdaylbl.Size = new System.Drawing.Size(59, 13);
            this.thursdaylbl.TabIndex = 0;
            this.thursdaylbl.Text = "Thursday";
            // 
            // fridaylbl
            // 
            this.fridaylbl.AutoSize = true;
            this.fridaylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fridaylbl.Location = new System.Drawing.Point(761, 50);
            this.fridaylbl.Name = "fridaylbl";
            this.fridaylbl.Size = new System.Drawing.Size(41, 13);
            this.fridaylbl.TabIndex = 0;
            this.fridaylbl.Text = "Friday";
            // 
            // saturdaylbl
            // 
            this.saturdaylbl.AutoSize = true;
            this.saturdaylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saturdaylbl.Location = new System.Drawing.Point(900, 50);
            this.saturdaylbl.Name = "saturdaylbl";
            this.saturdaylbl.Size = new System.Drawing.Size(57, 13);
            this.saturdaylbl.TabIndex = 0;
            this.saturdaylbl.Text = "Saturday";
            // 
            // sundaylbl
            // 
            this.sundaylbl.AutoSize = true;
            this.sundaylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sundaylbl.Location = new System.Drawing.Point(47, 50);
            this.sundaylbl.Name = "sundaylbl";
            this.sundaylbl.Size = new System.Drawing.Size(49, 13);
            this.sundaylbl.TabIndex = 0;
            this.sundaylbl.Text = "Sunday";
            // 
            // monthyearlbl
            // 
            this.monthyearlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthyearlbl.ForeColor = System.Drawing.Color.White;
            this.monthyearlbl.Location = new System.Drawing.Point(375, 3);
            this.monthyearlbl.Name = "monthyearlbl";
            this.monthyearlbl.Size = new System.Drawing.Size(184, 20);
            this.monthyearlbl.TabIndex = 0;
            this.monthyearlbl.Text = "January 2000";
            this.monthyearlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nxtmonthbtn
            // 
            this.nxtmonthbtn.FlatAppearance.BorderSize = 0;
            this.nxtmonthbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nxtmonthbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxtmonthbtn.ForeColor = System.Drawing.Color.White;
            this.nxtmonthbtn.Location = new System.Drawing.Point(565, 1);
            this.nxtmonthbtn.Name = "nxtmonthbtn";
            this.nxtmonthbtn.Size = new System.Drawing.Size(35, 23);
            this.nxtmonthbtn.TabIndex = 1;
            this.nxtmonthbtn.Text = ">";
            this.nxtmonthbtn.UseVisualStyleBackColor = true;
            this.nxtmonthbtn.Click += new System.EventHandler(this.nxtmonthbtn_Click);
            // 
            // prvmonthbtn
            // 
            this.prvmonthbtn.FlatAppearance.BorderSize = 0;
            this.prvmonthbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prvmonthbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prvmonthbtn.ForeColor = System.Drawing.Color.White;
            this.prvmonthbtn.Location = new System.Drawing.Point(340, 1);
            this.prvmonthbtn.Name = "prvmonthbtn";
            this.prvmonthbtn.Size = new System.Drawing.Size(35, 23);
            this.prvmonthbtn.TabIndex = 1;
            this.prvmonthbtn.Text = "<";
            this.prvmonthbtn.UseVisualStyleBackColor = true;
            this.prvmonthbtn.Click += new System.EventHandler(this.prvmonthbtn_Click);
            // 
            // prvyearbtn
            // 
            this.prvyearbtn.FlatAppearance.BorderSize = 0;
            this.prvyearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prvyearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prvyearbtn.ForeColor = System.Drawing.Color.White;
            this.prvyearbtn.Location = new System.Drawing.Point(305, 1);
            this.prvyearbtn.Name = "prvyearbtn";
            this.prvyearbtn.Size = new System.Drawing.Size(35, 23);
            this.prvyearbtn.TabIndex = 1;
            this.prvyearbtn.Text = "<<";
            this.prvyearbtn.UseVisualStyleBackColor = true;
            this.prvyearbtn.Click += new System.EventHandler(this.prvyearbtn_Click);
            // 
            // nxtyearbtn
            // 
            this.nxtyearbtn.FlatAppearance.BorderSize = 0;
            this.nxtyearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nxtyearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nxtyearbtn.ForeColor = System.Drawing.Color.White;
            this.nxtyearbtn.Location = new System.Drawing.Point(600, 1);
            this.nxtyearbtn.Name = "nxtyearbtn";
            this.nxtyearbtn.Size = new System.Drawing.Size(33, 23);
            this.nxtyearbtn.TabIndex = 1;
            this.nxtyearbtn.Text = ">>";
            this.nxtyearbtn.UseVisualStyleBackColor = true;
            this.nxtyearbtn.Click += new System.EventHandler(this.nxtyearbtn_Click);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.Panel1.Controls.Add(this.monthyearlbl);
            this.Panel1.Controls.Add(this.nxtmonthbtn);
            this.Panel1.Controls.Add(this.prvmonthbtn);
            this.Panel1.Controls.Add(this.prvyearbtn);
            this.Panel1.Controls.Add(this.nxtyearbtn);
            this.Panel1.Location = new System.Drawing.Point(27, 12);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(958, 26);
            this.Panel1.TabIndex = 3;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.Panel4);
            this.Panel2.Controls.Add(this.Panel1);
            this.Panel2.Controls.Add(this.sundaylbl);
            this.Panel2.Controls.Add(this.saturdaylbl);
            this.Panel2.Controls.Add(this.fridaylbl);
            this.Panel2.Controls.Add(this.thursdaylbl);
            this.Panel2.Controls.Add(this.wednesdaylbl);
            this.Panel2.Controls.Add(this.tuesdaylbl);
            this.Panel2.Controls.Add(this.mondaylbl);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1000, 722);
            this.Panel2.TabIndex = 0;
            // 
            // Panel4
            // 
            this.Panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.CalenderDayCtrl14);
            this.Panel4.Controls.Add(this.CalenderDayCtrl13);
            this.Panel4.Controls.Add(this.CalenderDayCtrl12);
            this.Panel4.Controls.Add(this.CalenderDayCtrl42);
            this.Panel4.Controls.Add(this.CalenderDayCtrl41);
            this.Panel4.Controls.Add(this.CalenderDayCtrl40);
            this.Panel4.Controls.Add(this.CalenderDayCtrl39);
            this.Panel4.Controls.Add(this.CalenderDayCtrl38);
            this.Panel4.Controls.Add(this.CalenderDayCtrl37);
            this.Panel4.Controls.Add(this.CalenderDayCtrl36);
            this.Panel4.Controls.Add(this.CalenderDayCtrl35);
            this.Panel4.Controls.Add(this.CalenderDayCtrl34);
            this.Panel4.Controls.Add(this.CalenderDayCtrl33);
            this.Panel4.Controls.Add(this.CalenderDayCtrl32);
            this.Panel4.Controls.Add(this.CalenderDayCtrl31);
            this.Panel4.Controls.Add(this.CalenderDayCtrl30);
            this.Panel4.Controls.Add(this.CalenderDayCtrl29);
            this.Panel4.Controls.Add(this.CalenderDayCtrl28);
            this.Panel4.Controls.Add(this.CalenderDayCtrl27);
            this.Panel4.Controls.Add(this.CalenderDayCtrl26);
            this.Panel4.Controls.Add(this.CalenderDayCtrl25);
            this.Panel4.Controls.Add(this.CalenderDayCtrl24);
            this.Panel4.Controls.Add(this.CalenderDayCtrl23);
            this.Panel4.Controls.Add(this.CalenderDayCtrl22);
            this.Panel4.Controls.Add(this.CalenderDayCtrl21);
            this.Panel4.Controls.Add(this.CalenderDayCtrl20);
            this.Panel4.Controls.Add(this.CalenderDayCtrl19);
            this.Panel4.Controls.Add(this.CalenderDayCtrl18);
            this.Panel4.Controls.Add(this.CalenderDayCtrl17);
            this.Panel4.Controls.Add(this.CalenderDayCtrl16);
            this.Panel4.Controls.Add(this.CalenderDayCtrl15);
            this.Panel4.Controls.Add(this.CalenderDayCtrl11);
            this.Panel4.Controls.Add(this.CalenderDayCtrl10);
            this.Panel4.Controls.Add(this.CalenderDayCtrl9);
            this.Panel4.Controls.Add(this.CalenderDayCtrl8);
            this.Panel4.Controls.Add(this.CalenderDayCtrl7);
            this.Panel4.Controls.Add(this.CalenderDayCtrl6);
            this.Panel4.Controls.Add(this.CalenderDayCtrl5);
            this.Panel4.Controls.Add(this.CalenderDayCtrl4);
            this.Panel4.Controls.Add(this.CalenderDayCtrl3);
            this.Panel4.Controls.Add(this.CalenderDayCtrl2);
            this.Panel4.Controls.Add(this.CalenderDayCtrl1);
            this.Panel4.Location = new System.Drawing.Point(6, 71);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(991, 643);
            this.Panel4.TabIndex = 4;
            // 
            // CalenderDayCtrl14
            // 
            this.CalenderDayCtrl14.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl14.D = false;
            this.CalenderDayCtrl14.Day = 7;
            this.CalenderDayCtrl14.Disabled = false;
            this.CalenderDayCtrl14.Location = new System.Drawing.Point(846, 105);
            this.CalenderDayCtrl14.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl14.Name = "CalenderDayCtrl14";
            this.CalenderDayCtrl14.ShowDateNumber = true;
            this.CalenderDayCtrl14.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl14.TabIndex = 2;
            // 
            // CalenderDayCtrl13
            // 
            this.CalenderDayCtrl13.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl13.D = false;
            this.CalenderDayCtrl13.Day = 7;
            this.CalenderDayCtrl13.Disabled = false;
            this.CalenderDayCtrl13.Location = new System.Drawing.Point(705, 105);
            this.CalenderDayCtrl13.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl13.Name = "CalenderDayCtrl13";
            this.CalenderDayCtrl13.ShowDateNumber = true;
            this.CalenderDayCtrl13.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl13.TabIndex = 2;
            // 
            // CalenderDayCtrl12
            // 
            this.CalenderDayCtrl12.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl12.D = false;
            this.CalenderDayCtrl12.Day = 7;
            this.CalenderDayCtrl12.Disabled = false;
            this.CalenderDayCtrl12.Location = new System.Drawing.Point(564, 105);
            this.CalenderDayCtrl12.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl12.Name = "CalenderDayCtrl12";
            this.CalenderDayCtrl12.ShowDateNumber = true;
            this.CalenderDayCtrl12.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl12.TabIndex = 2;
            // 
            // CalenderDayCtrl42
            // 
            this.CalenderDayCtrl42.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl42.D = false;
            this.CalenderDayCtrl42.Day = 7;
            this.CalenderDayCtrl42.Disabled = false;
            this.CalenderDayCtrl42.Location = new System.Drawing.Point(846, 533);
            this.CalenderDayCtrl42.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl42.Name = "CalenderDayCtrl42";
            this.CalenderDayCtrl42.ShowDateNumber = true;
            this.CalenderDayCtrl42.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl42.TabIndex = 2;
            // 
            // CalenderDayCtrl41
            // 
            this.CalenderDayCtrl41.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl41.D = false;
            this.CalenderDayCtrl41.Day = 7;
            this.CalenderDayCtrl41.Disabled = false;
            this.CalenderDayCtrl41.Location = new System.Drawing.Point(705, 533);
            this.CalenderDayCtrl41.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl41.Name = "CalenderDayCtrl41";
            this.CalenderDayCtrl41.ShowDateNumber = true;
            this.CalenderDayCtrl41.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl41.TabIndex = 2;
            // 
            // CalenderDayCtrl40
            // 
            this.CalenderDayCtrl40.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl40.D = false;
            this.CalenderDayCtrl40.Day = 7;
            this.CalenderDayCtrl40.Disabled = false;
            this.CalenderDayCtrl40.Location = new System.Drawing.Point(564, 533);
            this.CalenderDayCtrl40.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl40.Name = "CalenderDayCtrl40";
            this.CalenderDayCtrl40.ShowDateNumber = true;
            this.CalenderDayCtrl40.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl40.TabIndex = 2;
            // 
            // CalenderDayCtrl39
            // 
            this.CalenderDayCtrl39.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl39.D = false;
            this.CalenderDayCtrl39.Day = 7;
            this.CalenderDayCtrl39.Disabled = false;
            this.CalenderDayCtrl39.Location = new System.Drawing.Point(423, 533);
            this.CalenderDayCtrl39.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl39.Name = "CalenderDayCtrl39";
            this.CalenderDayCtrl39.ShowDateNumber = true;
            this.CalenderDayCtrl39.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl39.TabIndex = 2;
            // 
            // CalenderDayCtrl38
            // 
            this.CalenderDayCtrl38.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl38.D = false;
            this.CalenderDayCtrl38.Day = 7;
            this.CalenderDayCtrl38.Disabled = false;
            this.CalenderDayCtrl38.Location = new System.Drawing.Point(282, 533);
            this.CalenderDayCtrl38.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl38.Name = "CalenderDayCtrl38";
            this.CalenderDayCtrl38.ShowDateNumber = true;
            this.CalenderDayCtrl38.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl38.TabIndex = 2;
            // 
            // CalenderDayCtrl37
            // 
            this.CalenderDayCtrl37.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl37.D = false;
            this.CalenderDayCtrl37.Day = 7;
            this.CalenderDayCtrl37.Disabled = false;
            this.CalenderDayCtrl37.Location = new System.Drawing.Point(141, 533);
            this.CalenderDayCtrl37.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl37.Name = "CalenderDayCtrl37";
            this.CalenderDayCtrl37.ShowDateNumber = true;
            this.CalenderDayCtrl37.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl37.TabIndex = 2;
            // 
            // CalenderDayCtrl36
            // 
            this.CalenderDayCtrl36.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl36.D = false;
            this.CalenderDayCtrl36.Day = 7;
            this.CalenderDayCtrl36.Disabled = false;
            this.CalenderDayCtrl36.Location = new System.Drawing.Point(0, 533);
            this.CalenderDayCtrl36.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl36.Name = "CalenderDayCtrl36";
            this.CalenderDayCtrl36.ShowDateNumber = true;
            this.CalenderDayCtrl36.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl36.TabIndex = 2;
            // 
            // CalenderDayCtrl35
            // 
            this.CalenderDayCtrl35.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl35.D = false;
            this.CalenderDayCtrl35.Day = 7;
            this.CalenderDayCtrl35.Disabled = false;
            this.CalenderDayCtrl35.Location = new System.Drawing.Point(846, 426);
            this.CalenderDayCtrl35.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl35.Name = "CalenderDayCtrl35";
            this.CalenderDayCtrl35.ShowDateNumber = true;
            this.CalenderDayCtrl35.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl35.TabIndex = 2;
            // 
            // CalenderDayCtrl34
            // 
            this.CalenderDayCtrl34.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl34.D = false;
            this.CalenderDayCtrl34.Day = 7;
            this.CalenderDayCtrl34.Disabled = false;
            this.CalenderDayCtrl34.Location = new System.Drawing.Point(705, 426);
            this.CalenderDayCtrl34.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl34.Name = "CalenderDayCtrl34";
            this.CalenderDayCtrl34.ShowDateNumber = true;
            this.CalenderDayCtrl34.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl34.TabIndex = 2;
            // 
            // CalenderDayCtrl33
            // 
            this.CalenderDayCtrl33.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl33.D = false;
            this.CalenderDayCtrl33.Day = 7;
            this.CalenderDayCtrl33.Disabled = false;
            this.CalenderDayCtrl33.Location = new System.Drawing.Point(564, 426);
            this.CalenderDayCtrl33.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl33.Name = "CalenderDayCtrl33";
            this.CalenderDayCtrl33.ShowDateNumber = true;
            this.CalenderDayCtrl33.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl33.TabIndex = 2;
            // 
            // CalenderDayCtrl32
            // 
            this.CalenderDayCtrl32.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl32.D = false;
            this.CalenderDayCtrl32.Day = 7;
            this.CalenderDayCtrl32.Disabled = false;
            this.CalenderDayCtrl32.Location = new System.Drawing.Point(423, 426);
            this.CalenderDayCtrl32.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl32.Name = "CalenderDayCtrl32";
            this.CalenderDayCtrl32.ShowDateNumber = true;
            this.CalenderDayCtrl32.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl32.TabIndex = 2;
            // 
            // CalenderDayCtrl31
            // 
            this.CalenderDayCtrl31.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl31.D = false;
            this.CalenderDayCtrl31.Day = 7;
            this.CalenderDayCtrl31.Disabled = false;
            this.CalenderDayCtrl31.Location = new System.Drawing.Point(282, 426);
            this.CalenderDayCtrl31.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl31.Name = "CalenderDayCtrl31";
            this.CalenderDayCtrl31.ShowDateNumber = true;
            this.CalenderDayCtrl31.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl31.TabIndex = 2;
            // 
            // CalenderDayCtrl30
            // 
            this.CalenderDayCtrl30.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl30.D = false;
            this.CalenderDayCtrl30.Day = 7;
            this.CalenderDayCtrl30.Disabled = false;
            this.CalenderDayCtrl30.Location = new System.Drawing.Point(141, 426);
            this.CalenderDayCtrl30.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl30.Name = "CalenderDayCtrl30";
            this.CalenderDayCtrl30.ShowDateNumber = true;
            this.CalenderDayCtrl30.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl30.TabIndex = 2;
            // 
            // CalenderDayCtrl29
            // 
            this.CalenderDayCtrl29.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl29.D = false;
            this.CalenderDayCtrl29.Day = 7;
            this.CalenderDayCtrl29.Disabled = false;
            this.CalenderDayCtrl29.Location = new System.Drawing.Point(0, 426);
            this.CalenderDayCtrl29.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl29.Name = "CalenderDayCtrl29";
            this.CalenderDayCtrl29.ShowDateNumber = true;
            this.CalenderDayCtrl29.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl29.TabIndex = 2;
            // 
            // CalenderDayCtrl28
            // 
            this.CalenderDayCtrl28.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl28.D = false;
            this.CalenderDayCtrl28.Day = 7;
            this.CalenderDayCtrl28.Disabled = false;
            this.CalenderDayCtrl28.Location = new System.Drawing.Point(846, 319);
            this.CalenderDayCtrl28.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl28.Name = "CalenderDayCtrl28";
            this.CalenderDayCtrl28.ShowDateNumber = true;
            this.CalenderDayCtrl28.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl28.TabIndex = 2;
            // 
            // CalenderDayCtrl27
            // 
            this.CalenderDayCtrl27.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl27.D = false;
            this.CalenderDayCtrl27.Day = 7;
            this.CalenderDayCtrl27.Disabled = false;
            this.CalenderDayCtrl27.Location = new System.Drawing.Point(705, 319);
            this.CalenderDayCtrl27.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl27.Name = "CalenderDayCtrl27";
            this.CalenderDayCtrl27.ShowDateNumber = true;
            this.CalenderDayCtrl27.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl27.TabIndex = 2;
            // 
            // CalenderDayCtrl26
            // 
            this.CalenderDayCtrl26.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl26.D = false;
            this.CalenderDayCtrl26.Day = 7;
            this.CalenderDayCtrl26.Disabled = false;
            this.CalenderDayCtrl26.Location = new System.Drawing.Point(564, 319);
            this.CalenderDayCtrl26.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl26.Name = "CalenderDayCtrl26";
            this.CalenderDayCtrl26.ShowDateNumber = true;
            this.CalenderDayCtrl26.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl26.TabIndex = 2;
            // 
            // CalenderDayCtrl25
            // 
            this.CalenderDayCtrl25.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl25.D = false;
            this.CalenderDayCtrl25.Day = 7;
            this.CalenderDayCtrl25.Disabled = false;
            this.CalenderDayCtrl25.Location = new System.Drawing.Point(423, 319);
            this.CalenderDayCtrl25.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl25.Name = "CalenderDayCtrl25";
            this.CalenderDayCtrl25.ShowDateNumber = true;
            this.CalenderDayCtrl25.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl25.TabIndex = 2;
            // 
            // CalenderDayCtrl24
            // 
            this.CalenderDayCtrl24.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl24.D = false;
            this.CalenderDayCtrl24.Day = 7;
            this.CalenderDayCtrl24.Disabled = false;
            this.CalenderDayCtrl24.Location = new System.Drawing.Point(282, 319);
            this.CalenderDayCtrl24.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl24.Name = "CalenderDayCtrl24";
            this.CalenderDayCtrl24.ShowDateNumber = true;
            this.CalenderDayCtrl24.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl24.TabIndex = 2;
            // 
            // CalenderDayCtrl23
            // 
            this.CalenderDayCtrl23.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl23.D = false;
            this.CalenderDayCtrl23.Day = 7;
            this.CalenderDayCtrl23.Disabled = false;
            this.CalenderDayCtrl23.Location = new System.Drawing.Point(141, 319);
            this.CalenderDayCtrl23.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl23.Name = "CalenderDayCtrl23";
            this.CalenderDayCtrl23.ShowDateNumber = true;
            this.CalenderDayCtrl23.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl23.TabIndex = 2;
            // 
            // CalenderDayCtrl22
            // 
            this.CalenderDayCtrl22.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl22.D = false;
            this.CalenderDayCtrl22.Day = 7;
            this.CalenderDayCtrl22.Disabled = false;
            this.CalenderDayCtrl22.Location = new System.Drawing.Point(0, 319);
            this.CalenderDayCtrl22.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl22.Name = "CalenderDayCtrl22";
            this.CalenderDayCtrl22.ShowDateNumber = true;
            this.CalenderDayCtrl22.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl22.TabIndex = 2;
            // 
            // CalenderDayCtrl21
            // 
            this.CalenderDayCtrl21.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl21.D = false;
            this.CalenderDayCtrl21.Day = 7;
            this.CalenderDayCtrl21.Disabled = false;
            this.CalenderDayCtrl21.Location = new System.Drawing.Point(846, 212);
            this.CalenderDayCtrl21.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl21.Name = "CalenderDayCtrl21";
            this.CalenderDayCtrl21.ShowDateNumber = true;
            this.CalenderDayCtrl21.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl21.TabIndex = 2;
            // 
            // CalenderDayCtrl20
            // 
            this.CalenderDayCtrl20.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl20.D = false;
            this.CalenderDayCtrl20.Day = 7;
            this.CalenderDayCtrl20.Disabled = false;
            this.CalenderDayCtrl20.Location = new System.Drawing.Point(705, 212);
            this.CalenderDayCtrl20.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl20.Name = "CalenderDayCtrl20";
            this.CalenderDayCtrl20.ShowDateNumber = true;
            this.CalenderDayCtrl20.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl20.TabIndex = 2;
            // 
            // CalenderDayCtrl19
            // 
            this.CalenderDayCtrl19.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl19.D = false;
            this.CalenderDayCtrl19.Day = 7;
            this.CalenderDayCtrl19.Disabled = false;
            this.CalenderDayCtrl19.Location = new System.Drawing.Point(564, 212);
            this.CalenderDayCtrl19.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl19.Name = "CalenderDayCtrl19";
            this.CalenderDayCtrl19.ShowDateNumber = true;
            this.CalenderDayCtrl19.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl19.TabIndex = 2;
            // 
            // CalenderDayCtrl18
            // 
            this.CalenderDayCtrl18.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl18.D = false;
            this.CalenderDayCtrl18.Day = 7;
            this.CalenderDayCtrl18.Disabled = false;
            this.CalenderDayCtrl18.Location = new System.Drawing.Point(423, 212);
            this.CalenderDayCtrl18.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl18.Name = "CalenderDayCtrl18";
            this.CalenderDayCtrl18.ShowDateNumber = true;
            this.CalenderDayCtrl18.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl18.TabIndex = 2;
            // 
            // CalenderDayCtrl17
            // 
            this.CalenderDayCtrl17.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl17.D = false;
            this.CalenderDayCtrl17.Day = 7;
            this.CalenderDayCtrl17.Disabled = false;
            this.CalenderDayCtrl17.Location = new System.Drawing.Point(282, 212);
            this.CalenderDayCtrl17.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl17.Name = "CalenderDayCtrl17";
            this.CalenderDayCtrl17.ShowDateNumber = true;
            this.CalenderDayCtrl17.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl17.TabIndex = 2;
            // 
            // CalenderDayCtrl16
            // 
            this.CalenderDayCtrl16.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl16.D = false;
            this.CalenderDayCtrl16.Day = 7;
            this.CalenderDayCtrl16.Disabled = false;
            this.CalenderDayCtrl16.Location = new System.Drawing.Point(141, 212);
            this.CalenderDayCtrl16.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl16.Name = "CalenderDayCtrl16";
            this.CalenderDayCtrl16.ShowDateNumber = true;
            this.CalenderDayCtrl16.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl16.TabIndex = 2;
            // 
            // CalenderDayCtrl15
            // 
            this.CalenderDayCtrl15.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl15.D = false;
            this.CalenderDayCtrl15.Day = 7;
            this.CalenderDayCtrl15.Disabled = false;
            this.CalenderDayCtrl15.Location = new System.Drawing.Point(0, 212);
            this.CalenderDayCtrl15.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl15.Name = "CalenderDayCtrl15";
            this.CalenderDayCtrl15.ShowDateNumber = true;
            this.CalenderDayCtrl15.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl15.TabIndex = 2;
            // 
            // CalenderDayCtrl11
            // 
            this.CalenderDayCtrl11.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl11.D = false;
            this.CalenderDayCtrl11.Day = 7;
            this.CalenderDayCtrl11.Disabled = false;
            this.CalenderDayCtrl11.Location = new System.Drawing.Point(423, 105);
            this.CalenderDayCtrl11.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl11.Name = "CalenderDayCtrl11";
            this.CalenderDayCtrl11.ShowDateNumber = true;
            this.CalenderDayCtrl11.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl11.TabIndex = 2;
            // 
            // CalenderDayCtrl10
            // 
            this.CalenderDayCtrl10.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl10.D = false;
            this.CalenderDayCtrl10.Day = 7;
            this.CalenderDayCtrl10.Disabled = false;
            this.CalenderDayCtrl10.Location = new System.Drawing.Point(282, 105);
            this.CalenderDayCtrl10.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl10.Name = "CalenderDayCtrl10";
            this.CalenderDayCtrl10.ShowDateNumber = true;
            this.CalenderDayCtrl10.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl10.TabIndex = 2;
            // 
            // CalenderDayCtrl9
            // 
            this.CalenderDayCtrl9.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl9.D = false;
            this.CalenderDayCtrl9.Day = 7;
            this.CalenderDayCtrl9.Disabled = false;
            this.CalenderDayCtrl9.Location = new System.Drawing.Point(141, 105);
            this.CalenderDayCtrl9.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl9.Name = "CalenderDayCtrl9";
            this.CalenderDayCtrl9.ShowDateNumber = true;
            this.CalenderDayCtrl9.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl9.TabIndex = 2;
            // 
            // CalenderDayCtrl8
            // 
            this.CalenderDayCtrl8.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl8.D = false;
            this.CalenderDayCtrl8.Day = 7;
            this.CalenderDayCtrl8.Disabled = false;
            this.CalenderDayCtrl8.Location = new System.Drawing.Point(0, 105);
            this.CalenderDayCtrl8.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl8.Name = "CalenderDayCtrl8";
            this.CalenderDayCtrl8.ShowDateNumber = true;
            this.CalenderDayCtrl8.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl8.TabIndex = 2;
            // 
            // CalenderDayCtrl7
            // 
            this.CalenderDayCtrl7.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl7.D = true;
            this.CalenderDayCtrl7.Day = 7;
            this.CalenderDayCtrl7.Disabled = false;
            this.CalenderDayCtrl7.Location = new System.Drawing.Point(846, -2);
            this.CalenderDayCtrl7.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl7.Name = "CalenderDayCtrl7";
            this.CalenderDayCtrl7.ShowDateNumber = true;
            this.CalenderDayCtrl7.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl7.TabIndex = 2;
            // 
            // CalenderDayCtrl6
            // 
            this.CalenderDayCtrl6.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl6.D = false;
            this.CalenderDayCtrl6.Day = 7;
            this.CalenderDayCtrl6.Disabled = false;
            this.CalenderDayCtrl6.Location = new System.Drawing.Point(705, -2);
            this.CalenderDayCtrl6.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl6.Name = "CalenderDayCtrl6";
            this.CalenderDayCtrl6.ShowDateNumber = true;
            this.CalenderDayCtrl6.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl6.TabIndex = 2;
            // 
            // CalenderDayCtrl5
            // 
            this.CalenderDayCtrl5.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl5.D = false;
            this.CalenderDayCtrl5.Day = 7;
            this.CalenderDayCtrl5.Disabled = false;
            this.CalenderDayCtrl5.Location = new System.Drawing.Point(564, -2);
            this.CalenderDayCtrl5.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl5.Name = "CalenderDayCtrl5";
            this.CalenderDayCtrl5.ShowDateNumber = true;
            this.CalenderDayCtrl5.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl5.TabIndex = 2;
            // 
            // CalenderDayCtrl4
            // 
            this.CalenderDayCtrl4.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl4.D = false;
            this.CalenderDayCtrl4.Day = 7;
            this.CalenderDayCtrl4.Disabled = false;
            this.CalenderDayCtrl4.Location = new System.Drawing.Point(423, -2);
            this.CalenderDayCtrl4.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl4.Name = "CalenderDayCtrl4";
            this.CalenderDayCtrl4.ShowDateNumber = true;
            this.CalenderDayCtrl4.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl4.TabIndex = 2;
            // 
            // CalenderDayCtrl3
            // 
            this.CalenderDayCtrl3.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl3.D = false;
            this.CalenderDayCtrl3.Day = 7;
            this.CalenderDayCtrl3.Disabled = false;
            this.CalenderDayCtrl3.Location = new System.Drawing.Point(282, -2);
            this.CalenderDayCtrl3.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl3.Name = "CalenderDayCtrl3";
            this.CalenderDayCtrl3.ShowDateNumber = true;
            this.CalenderDayCtrl3.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl3.TabIndex = 2;
            // 
            // CalenderDayCtrl2
            // 
            this.CalenderDayCtrl2.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl2.D = false;
            this.CalenderDayCtrl2.Day = 7;
            this.CalenderDayCtrl2.Disabled = false;
            this.CalenderDayCtrl2.Location = new System.Drawing.Point(141, -2);
            this.CalenderDayCtrl2.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl2.Name = "CalenderDayCtrl2";
            this.CalenderDayCtrl2.ShowDateNumber = true;
            this.CalenderDayCtrl2.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl2.TabIndex = 2;
            // 
            // CalenderDayCtrl1
            // 
            this.CalenderDayCtrl1.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl1.D = false;
            this.CalenderDayCtrl1.Day = 7;
            this.CalenderDayCtrl1.Disabled = false;
            this.CalenderDayCtrl1.Location = new System.Drawing.Point(0, -2);
            this.CalenderDayCtrl1.Margin = new System.Windows.Forms.Padding(0);
            this.CalenderDayCtrl1.Name = "CalenderDayCtrl1";
            this.CalenderDayCtrl1.ShowDateNumber = true;
            this.CalenderDayCtrl1.Size = new System.Drawing.Size(142, 108);
            this.CalenderDayCtrl1.TabIndex = 2;
            // 
            // Panel3
            // 
            this.Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel3.BackColor = System.Drawing.Color.Transparent;
            this.Panel3.Controls.Add(this.Button1);
            this.Panel3.Controls.Add(this.daydatelbl);
            this.Panel3.Controls.Add(this.CalenderDayCtrl43);
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(1000, 722);
            this.Panel3.TabIndex = 5;
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Button1.Location = new System.Drawing.Point(912, 6);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(85, 23);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Close";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // daydatelbl
            // 
            this.daydatelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.daydatelbl.BackColor = System.Drawing.Color.Transparent;
            this.daydatelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daydatelbl.Location = new System.Drawing.Point(7, 4);
            this.daydatelbl.Name = "daydatelbl";
            this.daydatelbl.Size = new System.Drawing.Size(1044, 27);
            this.daydatelbl.TabIndex = 2;
            this.daydatelbl.Text = "daydatelbl";
            this.daydatelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalenderDayCtrl43
            // 
            this.CalenderDayCtrl43.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalenderDayCtrl43.BackColor = System.Drawing.Color.White;
            this.CalenderDayCtrl43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CalenderDayCtrl43.D = false;
            this.CalenderDayCtrl43.Day = 0;
            this.CalenderDayCtrl43.Disabled = false;
            this.CalenderDayCtrl43.Location = new System.Drawing.Point(6, 33);
            this.CalenderDayCtrl43.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CalenderDayCtrl43.Name = "CalenderDayCtrl43";
            this.CalenderDayCtrl43.ShowDateNumber = true;
            this.CalenderDayCtrl43.Size = new System.Drawing.Size(1126, 763);
            this.CalenderDayCtrl43.TabIndex = 0;
            // 
            // CalendarCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel3);
            this.Name = "CalendarCtrl";
            this.Size = new System.Drawing.Size(1000, 722);
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel4.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.Label mondaylbl;
        internal System.Windows.Forms.Label tuesdaylbl;
        internal System.Windows.Forms.Label wednesdaylbl;
        internal System.Windows.Forms.Label thursdaylbl;
        internal System.Windows.Forms.Label fridaylbl;
        internal System.Windows.Forms.Label saturdaylbl;
        internal System.Windows.Forms.Label sundaylbl;
        internal System.Windows.Forms.Label monthyearlbl;
        internal System.Windows.Forms.Button nxtmonthbtn;
        internal System.Windows.Forms.Button prvmonthbtn;
        internal System.Windows.Forms.Button prvyearbtn;
        internal System.Windows.Forms.Button nxtyearbtn;
        internal CalendarDayCtrl CalenderDayCtrl1;
        internal CalendarDayCtrl CalenderDayCtrl2;
        internal CalendarDayCtrl CalenderDayCtrl3;
        internal CalendarDayCtrl CalenderDayCtrl4;
        internal CalendarDayCtrl CalenderDayCtrl5;
        internal CalendarDayCtrl CalenderDayCtrl6;
        internal CalendarDayCtrl CalenderDayCtrl7;
        internal CalendarDayCtrl CalenderDayCtrl8;
        internal CalendarDayCtrl CalenderDayCtrl9;
        internal CalendarDayCtrl CalenderDayCtrl10;
        internal CalendarDayCtrl CalenderDayCtrl11;
        internal CalendarDayCtrl CalenderDayCtrl12;
        internal CalendarDayCtrl CalenderDayCtrl13;
        internal CalendarDayCtrl CalenderDayCtrl14;
        internal CalendarDayCtrl CalenderDayCtrl15;
        internal CalendarDayCtrl CalenderDayCtrl16;
        internal CalendarDayCtrl CalenderDayCtrl17;
        internal CalendarDayCtrl CalenderDayCtrl18;
        internal CalendarDayCtrl CalenderDayCtrl19;
        internal CalendarDayCtrl CalenderDayCtrl20;
        internal CalendarDayCtrl CalenderDayCtrl21;
        internal CalendarDayCtrl CalenderDayCtrl22;
        internal CalendarDayCtrl CalenderDayCtrl23;
        internal CalendarDayCtrl CalenderDayCtrl24;
        internal CalendarDayCtrl CalenderDayCtrl25;
        internal CalendarDayCtrl CalenderDayCtrl26;
        internal CalendarDayCtrl CalenderDayCtrl27;
        internal CalendarDayCtrl CalenderDayCtrl28;
        internal CalendarDayCtrl CalenderDayCtrl29;
        internal CalendarDayCtrl CalenderDayCtrl30;
        internal CalendarDayCtrl CalenderDayCtrl31;
        internal CalendarDayCtrl CalenderDayCtrl32;
        internal CalendarDayCtrl CalenderDayCtrl33;
        internal CalendarDayCtrl CalenderDayCtrl34;
        internal CalendarDayCtrl CalenderDayCtrl35;
        internal CalendarDayCtrl CalenderDayCtrl36;
        internal CalendarDayCtrl CalenderDayCtrl37;
        internal CalendarDayCtrl CalenderDayCtrl38;
        internal CalendarDayCtrl CalenderDayCtrl39;
        internal CalendarDayCtrl CalenderDayCtrl40;
        internal CalendarDayCtrl CalenderDayCtrl41;
        internal CalendarDayCtrl CalenderDayCtrl42;
        internal CalendarDayCtrl CalenderDayCtrl43;

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel3;

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label daydatelbl;
        internal System.Windows.Forms.Panel Panel4;


        #endregion
        private System.Windows.Forms.Panel panel2;
    }
}
