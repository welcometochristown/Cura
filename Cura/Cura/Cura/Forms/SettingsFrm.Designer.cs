namespace Cura.Forms
{
    partial class SettingsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsFrm));
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.label2 = new System.Windows.Forms.Label();
            this.dataPathTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.exButton1 = new CG.Controls.Grid.Buttons.ExButton();
            this.securitykeyTxt = new System.Windows.Forms.TextBox();
            this.securitykeyerrorpic = new System.Windows.Forms.PictureBox();
            this.fileerrorpic = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rotaRangeNUm = new System.Windows.Forms.NumericUpDown();
            this.helpCtrl2 = new Cura.Controls.HelpCtrl();
            this.helpCtrl3 = new Cura.Controls.HelpCtrl();
            this.rotaWeekCount = new System.Windows.Forms.NumericUpDown();
            this.showtraveltime = new System.Windows.Forms.CheckBox();
            this.helpCtrl4 = new Cura.Controls.HelpCtrl();
            this.helpCtrl5 = new Cura.Controls.HelpCtrl();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.remaining = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.securitykeyerrorpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaRangeNUm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaWeekCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpCtrl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(708, 8);
            this.helpCtrl1.Message = "This is the settings menu, and should only be edited if you know what you\'re doin" +
    "g. \r\n\r\nIf unsure you may want to consult your nearest IT wizz.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = true;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.label2.Location = new System.Drawing.Point(29, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data File Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataPathTxt
            // 
            this.dataPathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPathTxt.Location = new System.Drawing.Point(164, 21);
            this.dataPathTxt.Name = "dataPathTxt";
            this.dataPathTxt.ReadOnly = true;
            this.dataPathTxt.Size = new System.Drawing.Size(481, 22);
            this.dataPathTxt.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(660, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exButton1
            // 
            this.exButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exButton1.BackColor = System.Drawing.Color.Transparent;
            this.exButton1.CornerRadius = 3;
            this.exButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.exButton1.DrawFocusRect = true;
            this.exButton1.ImageOffset = new System.Drawing.Point(4, 0);
            this.exButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.exButton1.IsSplitButton = false;
            this.exButton1.Location = new System.Drawing.Point(632, 279);
            this.exButton1.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exButton1.Name = "exButton1";
            this.exButton1.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exButton1.Renderer = officeButtonRenderer1;
            this.exButton1.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exButton1.Size = new System.Drawing.Size(87, 23);
            this.exButton1.SplitButtonWidth = 20;
            this.exButton1.TabIndex = 5;
            this.exButton1.Text = "Ok";
            // 
            // securitykeyTxt
            // 
            this.securitykeyTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.securitykeyTxt.Location = new System.Drawing.Point(164, 52);
            this.securitykeyTxt.Name = "securitykeyTxt";
            this.securitykeyTxt.Size = new System.Drawing.Size(481, 22);
            this.securitykeyTxt.TabIndex = 3;
            this.securitykeyTxt.TextChanged += new System.EventHandler(this.securitykeyTxt_TextChanged);
            // 
            // securitykeyerrorpic
            // 
            this.securitykeyerrorpic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.securitykeyerrorpic.BackgroundImage = global::Cura.Properties.Resources.exclamation;
            this.securitykeyerrorpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.securitykeyerrorpic.Location = new System.Drawing.Point(660, 63);
            this.securitykeyerrorpic.Name = "securitykeyerrorpic";
            this.securitykeyerrorpic.Size = new System.Drawing.Size(16, 15);
            this.securitykeyerrorpic.TabIndex = 12;
            this.securitykeyerrorpic.TabStop = false;
            // 
            // fileerrorpic
            // 
            this.fileerrorpic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileerrorpic.BackgroundImage = global::Cura.Properties.Resources.exclamation;
            this.fileerrorpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileerrorpic.Location = new System.Drawing.Point(696, 25);
            this.fileerrorpic.Name = "fileerrorpic";
            this.fileerrorpic.Size = new System.Drawing.Size(16, 15);
            this.fileerrorpic.TabIndex = 12;
            this.fileerrorpic.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(164, 133);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(199, 22);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // rotaRangeNUm
            // 
            this.rotaRangeNUm.Location = new System.Drawing.Point(164, 167);
            this.rotaRangeNUm.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rotaRangeNUm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rotaRangeNUm.Name = "rotaRangeNUm";
            this.rotaRangeNUm.Size = new System.Drawing.Size(82, 22);
            this.rotaRangeNUm.TabIndex = 15;
            this.rotaRangeNUm.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // helpCtrl2
            // 
            this.helpCtrl2.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl2.Caption = null;
            this.helpCtrl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl2.Location = new System.Drawing.Point(8, 169);
            this.helpCtrl2.Message = "The rota period range defines how many rota periods appear in the drop down list " +
    "on the main screen additional to the current one.\r\n\r\nMin :1 / Max: 10";
            this.helpCtrl2.Name = "helpCtrl2";
            this.helpCtrl2.OpenLeft = false;
            this.helpCtrl2.OpenUp = false;
            this.helpCtrl2.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl2.TabIndex = 1;
            // 
            // helpCtrl3
            // 
            this.helpCtrl3.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl3.Caption = null;
            this.helpCtrl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl3.Location = new System.Drawing.Point(8, 104);
            this.helpCtrl3.Message = "The rota period range defines how many rota periods appear in the drop down list " +
    "on the main screen additional to the current one.\r\n\r\nMin :1 / Max: 10";
            this.helpCtrl3.Name = "helpCtrl3";
            this.helpCtrl3.OpenLeft = false;
            this.helpCtrl3.OpenUp = false;
            this.helpCtrl3.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl3.TabIndex = 1;
            // 
            // rotaWeekCount
            // 
            this.rotaWeekCount.Location = new System.Drawing.Point(164, 99);
            this.rotaWeekCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.rotaWeekCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rotaWeekCount.Name = "rotaWeekCount";
            this.rotaWeekCount.Size = new System.Drawing.Size(82, 22);
            this.rotaWeekCount.TabIndex = 15;
            this.rotaWeekCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // showtraveltime
            // 
            this.showtraveltime.AutoSize = true;
            this.showtraveltime.Location = new System.Drawing.Point(205, 204);
            this.showtraveltime.Name = "showtraveltime";
            this.showtraveltime.Size = new System.Drawing.Size(15, 14);
            this.showtraveltime.TabIndex = 16;
            this.showtraveltime.UseVisualStyleBackColor = true;
            // 
            // helpCtrl4
            // 
            this.helpCtrl4.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl4.Caption = null;
            this.helpCtrl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl4.Location = new System.Drawing.Point(8, 24);
            this.helpCtrl4.Message = "The data file contains all the data for use with Cura. To load a data file you ne" +
    "ed to find a valid .db file.\r\n\r\nClick the elipse to the right to search for a da" +
    "ta file.";
            this.helpCtrl4.Name = "helpCtrl4";
            this.helpCtrl4.OpenLeft = false;
            this.helpCtrl4.OpenUp = false;
            this.helpCtrl4.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl4.TabIndex = 1;
            // 
            // helpCtrl5
            // 
            this.helpCtrl5.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl5.Caption = null;
            this.helpCtrl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl5.Location = new System.Drawing.Point(8, 202);
            this.helpCtrl5.Message = "Checking this option will mean that Cura includes travel time when displaying cal" +
    "ls on the worker calendar.";
            this.helpCtrl5.Name = "helpCtrl5";
            this.helpCtrl5.OpenLeft = false;
            this.helpCtrl5.OpenUp = false;
            this.helpCtrl5.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.label3.Location = new System.Drawing.Point(29, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Security Key";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.label6.Location = new System.Drawing.Point(29, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Weeks In Rota Period";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.label4.Location = new System.Drawing.Point(29, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 22);
            this.label4.TabIndex = 19;
            this.label4.Text = "Initial Week ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.label5.Location = new System.Drawing.Point(29, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "Rota Period Range";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(225)))), ((int)(((byte)(234)))));
            this.label8.Location = new System.Drawing.Point(29, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "Display Calls With Travel Time";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.remaining);
            this.groupBox1.Controls.Add(this.dataPathTxt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.helpCtrl2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.helpCtrl5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.helpCtrl3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.helpCtrl4);
            this.groupBox1.Controls.Add(this.showtraveltime);
            this.groupBox1.Controls.Add(this.securitykeyTxt);
            this.groupBox1.Controls.Add(this.rotaWeekCount);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rotaRangeNUm);
            this.groupBox1.Controls.Add(this.securitykeyerrorpic);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.fileerrorpic);
            this.groupBox1.Location = new System.Drawing.Point(10, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 230);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // remaining
            // 
            this.remaining.AutoSize = true;
            this.remaining.Font = new System.Drawing.Font("Tahoma", 8F);
            this.remaining.ForeColor = System.Drawing.Color.DarkRed;
            this.remaining.Location = new System.Drawing.Point(173, 75);
            this.remaining.Name = "remaining";
            this.remaining.Size = new System.Drawing.Size(13, 13);
            this.remaining.TabIndex = 22;
            this.remaining.Text = "_";
            this.remaining.Click += new System.EventHandler(this.remaining_Click);
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 314);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.helpCtrl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::Cura.Properties.Resources.settings;
            this.ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "SettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Title = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFrm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.Controls.SetChildIndex(this.helpCtrl1, 0);
            this.Controls.SetChildIndex(this.exButton1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.securitykeyerrorpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaRangeNUm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotaWeekCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.HelpCtrl helpCtrl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dataPathTxt;
        private System.Windows.Forms.Button button1;
        private CG.Controls.Grid.Buttons.ExButton exButton1;
        private System.Windows.Forms.TextBox securitykeyTxt;
        private System.Windows.Forms.PictureBox securitykeyerrorpic;
        private System.Windows.Forms.PictureBox fileerrorpic;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown rotaRangeNUm;
        private Controls.HelpCtrl helpCtrl2;
        private Controls.HelpCtrl helpCtrl3;
        private System.Windows.Forms.NumericUpDown rotaWeekCount;
        private System.Windows.Forms.CheckBox showtraveltime;
        private Controls.HelpCtrl helpCtrl4;
        private Controls.HelpCtrl helpCtrl5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label remaining;
    }
}