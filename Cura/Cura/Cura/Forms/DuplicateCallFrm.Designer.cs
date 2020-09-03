namespace Cura.Forms
{
    partial class DuplicateCallFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.excludeweekendCk = new System.Windows.Forms.CheckBox();
            this.duplicateWeekradio = new System.Windows.Forms.RadioButton();
            this.duplicateDayRadio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.duplicateWeekNum = new System.Windows.Forms.NumericUpDown();
            this.dupliateDayNum = new System.Windows.Forms.NumericUpDown();
            this.exButton1 = new CG.Controls.Grid.Buttons.ExButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplicateWeekNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dupliateDayNum)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.helpCtrl1);
            this.groupBox1.Controls.Add(this.excludeweekendCk);
            this.groupBox1.Controls.Add(this.duplicateWeekradio);
            this.groupBox1.Controls.Add(this.duplicateDayRadio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.duplicateWeekNum);
            this.groupBox1.Controls.Add(this.dupliateDayNum);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 200);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duplication";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "I would like to duplicate this call :";
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(320, 14);
            this.helpCtrl1.Message = null;
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = true;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 11;
            // 
            // excludeweekendCk
            // 
            this.excludeweekendCk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.excludeweekendCk.AutoSize = true;
            this.excludeweekendCk.Enabled = false;
            this.excludeweekendCk.Location = new System.Drawing.Point(201, 176);
            this.excludeweekendCk.Name = "excludeweekendCk";
            this.excludeweekendCk.Size = new System.Drawing.Size(136, 18);
            this.excludeweekendCk.TabIndex = 10;
            this.excludeweekendCk.Text = "Exclude Weekends?";
            this.excludeweekendCk.UseVisualStyleBackColor = true;
            // 
            // duplicateWeekradio
            // 
            this.duplicateWeekradio.AutoSize = true;
            this.duplicateWeekradio.Location = new System.Drawing.Point(17, 121);
            this.duplicateWeekradio.Name = "duplicateWeekradio";
            this.duplicateWeekradio.Size = new System.Drawing.Size(133, 18);
            this.duplicateWeekradio.TabIndex = 9;
            this.duplicateWeekradio.Text = "The Same Time For";
            this.duplicateWeekradio.UseVisualStyleBackColor = true;
            this.duplicateWeekradio.CheckedChanged += new System.EventHandler(this.duplicateWeekradio_CheckedChanged);
            // 
            // duplicateDayRadio
            // 
            this.duplicateDayRadio.AutoSize = true;
            this.duplicateDayRadio.Location = new System.Drawing.Point(17, 80);
            this.duplicateDayRadio.Name = "duplicateDayRadio";
            this.duplicateDayRadio.Size = new System.Drawing.Size(133, 18);
            this.duplicateDayRadio.TabIndex = 9;
            this.duplicateDayRadio.Text = "The Same Time For";
            this.duplicateDayRadio.UseVisualStyleBackColor = true;
            this.duplicateDayRadio.CheckedChanged += new System.EventHandler(this.duplicateDayRadio_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Week(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Day(s)";
            // 
            // duplicateWeekNum
            // 
            this.duplicateWeekNum.Enabled = false;
            this.duplicateWeekNum.Location = new System.Drawing.Point(156, 120);
            this.duplicateWeekNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.duplicateWeekNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.duplicateWeekNum.Name = "duplicateWeekNum";
            this.duplicateWeekNum.Size = new System.Drawing.Size(73, 22);
            this.duplicateWeekNum.TabIndex = 3;
            this.duplicateWeekNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dupliateDayNum
            // 
            this.dupliateDayNum.Enabled = false;
            this.dupliateDayNum.Location = new System.Drawing.Point(156, 76);
            this.dupliateDayNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.dupliateDayNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dupliateDayNum.Name = "dupliateDayNum";
            this.dupliateDayNum.Size = new System.Drawing.Size(73, 22);
            this.dupliateDayNum.TabIndex = 3;
            this.dupliateDayNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.exButton1.Location = new System.Drawing.Point(242, 229);
            this.exButton1.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exButton1.Name = "exButton1";
            this.exButton1.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exButton1.Renderer = officeButtonRenderer1;
            this.exButton1.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exButton1.Size = new System.Drawing.Size(117, 27);
            this.exButton1.SplitButtonWidth = 20;
            this.exButton1.TabIndex = 13;
            this.exButton1.Text = "Ok";
            // 
            // DuplicateCallFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 265);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DuplicateCallFrm";
            this.Text = "Call Duplication";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duplicateWeekNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dupliateDayNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox excludeweekendCk;
        private System.Windows.Forms.RadioButton duplicateWeekradio;
        private System.Windows.Forms.RadioButton duplicateDayRadio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown duplicateWeekNum;
        private System.Windows.Forms.NumericUpDown dupliateDayNum;
        private CG.Controls.Grid.Buttons.ExButton exButton1;
        private Controls.HelpCtrl helpCtrl1;
        private System.Windows.Forms.Label label1;
    }
}