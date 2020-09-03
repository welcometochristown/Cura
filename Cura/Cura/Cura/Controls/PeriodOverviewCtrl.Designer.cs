namespace Cura.Controls
{
    partial class PeriodOverviewCtrl
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
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer3 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportType = new System.Windows.Forms.ComboBox();
            this.reportCmbo = new System.Windows.Forms.ComboBox();
            this.typeCombo = new System.Windows.Forms.ComboBox();
            this.periodcallsrpt = new CG.Controls.Grid.Buttons.ExButton();
            this.exportbtn = new CG.Controls.Grid.Buttons.ExButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exportOutBtn = new CG.Controls.Grid.Buttons.ExButton();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.helpCtrl3 = new Cura.Controls.HelpCtrl();
            this.helpCtrl2 = new Cura.Controls.HelpCtrl();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(-149, 161);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(111, 14);
            this.label21.TabIndex = 23;
            this.label21.Text = "Total Service Users";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.reportType);
            this.panel1.Controls.Add(this.reportCmbo);
            this.panel1.Controls.Add(this.typeCombo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 32);
            this.panel1.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Cura.Properties.Resources.arrow_refresh;
            this.button1.Location = new System.Drawing.Point(811, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(83)))), ((int)(((byte)(145)))));
            this.label3.Location = new System.Drawing.Point(606, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(83)))), ((int)(((byte)(145)))));
            this.label2.Location = new System.Drawing.Point(248, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Report";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(83)))), ((int)(((byte)(145)))));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Measure";
            // 
            // reportType
            // 
            this.reportType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.reportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportType.FormattingEnabled = true;
            this.reportType.Location = new System.Drawing.Point(650, 5);
            this.reportType.Name = "reportType";
            this.reportType.Size = new System.Drawing.Size(137, 22);
            this.reportType.TabIndex = 0;
            this.reportType.SelectedIndexChanged += new System.EventHandler(this.reportType_SelectedIndexChanged);
            // 
            // reportCmbo
            // 
            this.reportCmbo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.reportCmbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportCmbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportCmbo.FormattingEnabled = true;
            this.reportCmbo.Location = new System.Drawing.Point(296, 5);
            this.reportCmbo.Name = "reportCmbo";
            this.reportCmbo.Size = new System.Drawing.Size(189, 22);
            this.reportCmbo.TabIndex = 0;
            this.reportCmbo.SelectedIndexChanged += new System.EventHandler(this.reportCmbo_SelectedIndexChanged);
            // 
            // typeCombo
            // 
            this.typeCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeCombo.FormattingEnabled = true;
            this.typeCombo.Location = new System.Drawing.Point(57, 5);
            this.typeCombo.Name = "typeCombo";
            this.typeCombo.Size = new System.Drawing.Size(189, 22);
            this.typeCombo.TabIndex = 0;
            this.typeCombo.SelectedIndexChanged += new System.EventHandler(this.typeCombo_SelectedIndexChanged);
            // 
            // periodcallsrpt
            // 
            this.periodcallsrpt.BackColor = System.Drawing.Color.Transparent;
            this.periodcallsrpt.CornerRadius = 3;
            this.periodcallsrpt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.periodcallsrpt.DrawFocusRect = true;
            this.periodcallsrpt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodcallsrpt.Image = global::Cura.Properties.Resources.table_excel_icon;
            this.periodcallsrpt.ImageOffset = new System.Drawing.Point(4, 0);
            this.periodcallsrpt.ImageSize = new System.Drawing.Size(16, 16);
            this.periodcallsrpt.IsSplitButton = false;
            this.periodcallsrpt.Location = new System.Drawing.Point(472, 7);
            this.periodcallsrpt.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.periodcallsrpt.Name = "periodcallsrpt";
            this.periodcallsrpt.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.periodcallsrpt.Renderer = officeButtonRenderer1;
            this.periodcallsrpt.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.periodcallsrpt.Size = new System.Drawing.Size(130, 28);
            this.periodcallsrpt.SplitButtonWidth = 20;
            this.periodcallsrpt.TabIndex = 26;
            this.periodcallsrpt.Text = "Period Call Report";
            this.periodcallsrpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.periodcallsrpt.Visible = false;
            this.periodcallsrpt.Click += new System.EventHandler(this.periodcallsrpt_Click);
            // 
            // exportbtn
            // 
            this.exportbtn.BackColor = System.Drawing.Color.Transparent;
            this.exportbtn.CornerRadius = 3;
            this.exportbtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.exportbtn.DrawFocusRect = true;
            this.exportbtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportbtn.Image = global::Cura.Properties.Resources.table_excel_icon;
            this.exportbtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.exportbtn.ImageSize = new System.Drawing.Size(16, 16);
            this.exportbtn.IsSplitButton = false;
            this.exportbtn.Location = new System.Drawing.Point(322, 6);
            this.exportbtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exportbtn.Name = "exportbtn";
            this.exportbtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer2.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exportbtn.Renderer = officeButtonRenderer2;
            this.exportbtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exportbtn.Size = new System.Drawing.Size(99, 28);
            this.exportbtn.SplitButtonWidth = 20;
            this.exportbtn.TabIndex = 26;
            this.exportbtn.Text = "Stats Report ";
            this.exportbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportbtn.Visible = false;
            this.exportbtn.Click += new System.EventHandler(this.exportbtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.periodcallsrpt);
            this.panel2.Controls.Add(this.exportOutBtn);
            this.panel2.Controls.Add(this.exportbtn);
            this.panel2.Controls.Add(this.helpCtrl3);
            this.panel2.Controls.Add(this.helpCtrl2);
            this.panel2.Controls.Add(this.helpCtrl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 38);
            this.panel2.TabIndex = 34;
            // 
            // exportOutBtn
            // 
            this.exportOutBtn.BackColor = System.Drawing.Color.Transparent;
            this.exportOutBtn.CornerRadius = 3;
            this.exportOutBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.exportOutBtn.DrawFocusRect = true;
            this.exportOutBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportOutBtn.Image = global::Cura.Properties.Resources.table_excel_icon;
            this.exportOutBtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.exportOutBtn.ImageSize = new System.Drawing.Size(16, 16);
            this.exportOutBtn.IsSplitButton = false;
            this.exportOutBtn.Location = new System.Drawing.Point(3, 3);
            this.exportOutBtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exportOutBtn.Name = "exportOutBtn";
            this.exportOutBtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer3.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exportOutBtn.Renderer = officeButtonRenderer3;
            this.exportOutBtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exportOutBtn.Size = new System.Drawing.Size(76, 28);
            this.exportOutBtn.SplitButtonWidth = 20;
            this.exportOutBtn.TabIndex = 26;
            this.exportOutBtn.Text = "Export";
            this.exportOutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportOutBtn.Click += new System.EventHandler(this.exportOutBtn_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(557, 403);
            this.zedGraphControl1.TabIndex = 35;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zedGraphControl1);
            this.splitContainer1.Size = new System.Drawing.Size(841, 403);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 36;
            // 
            // helpCtrl3
            // 
            this.helpCtrl3.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl3.Caption = null;
            this.helpCtrl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl3.Location = new System.Drawing.Point(82, 6);
            this.helpCtrl3.Message = "Export Current Data";
            this.helpCtrl3.Name = "helpCtrl3";
            this.helpCtrl3.OpenLeft = false;
            this.helpCtrl3.OpenUp = false;
            this.helpCtrl3.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl3.TabIndex = 31;
            // 
            // helpCtrl2
            // 
            this.helpCtrl2.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl2.Caption = null;
            this.helpCtrl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl2.Location = new System.Drawing.Point(605, 8);
            this.helpCtrl2.Message = "This report will contain a break down of each call over this rota period. ";
            this.helpCtrl2.Name = "helpCtrl2";
            this.helpCtrl2.OpenLeft = false;
            this.helpCtrl2.OpenUp = false;
            this.helpCtrl2.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl2.TabIndex = 32;
            this.helpCtrl2.Visible = false;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(423, 7);
            this.helpCtrl1.Message = "This report will just contain the figures shown on the overview tab.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = false;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 31;
            this.helpCtrl1.Visible = false;
            // 
            // PeriodOverviewCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PeriodOverviewCtrl";
            this.Size = new System.Drawing.Size(841, 473);
            this.Load += new System.EventHandler(this.PeriodOverviewCtrl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CG.Controls.Grid.Buttons.ExButton exportbtn;
        private System.Windows.Forms.Label label21;
        private CG.Controls.Grid.Buttons.ExButton periodcallsrpt;
        private HelpCtrl helpCtrl1;
        private HelpCtrl helpCtrl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reportCmbo;
        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.Panel panel2;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CG.Controls.Grid.Buttons.ExButton exportOutBtn;
        private HelpCtrl helpCtrl3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox reportType;
    }
}
