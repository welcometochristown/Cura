namespace Cura.Forms
{
    partial class DayCountFrm
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
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer2 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            this.exButton1 = new CG.Controls.Grid.Buttons.ExButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dayCountTxt = new System.Windows.Forms.NumericUpDown();
            this.excludeweekendChk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dayCountTxt)).BeginInit();
            this.SuspendLayout();
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
            this.exButton1.Location = new System.Drawing.Point(102, 88);
            this.exButton1.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exButton1.Name = "exButton1";
            this.exButton1.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer2.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exButton1.Renderer = officeButtonRenderer2;
            this.exButton1.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exButton1.Size = new System.Drawing.Size(78, 25);
            this.exButton1.SplitButtonWidth = 20;
            this.exButton1.TabIndex = 10;
            this.exButton1.Text = "Ok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Day Count";
            // 
            // dayCountTxt
            // 
            this.dayCountTxt.Location = new System.Drawing.Point(87, 14);
            this.dayCountTxt.Name = "dayCountTxt";
            this.dayCountTxt.Size = new System.Drawing.Size(92, 22);
            this.dayCountTxt.TabIndex = 14;
            // 
            // excludeweekendChk
            // 
            this.excludeweekendChk.AutoSize = true;
            this.excludeweekendChk.Location = new System.Drawing.Point(12, 54);
            this.excludeweekendChk.Name = "excludeweekendChk";
            this.excludeweekendChk.Size = new System.Drawing.Size(130, 18);
            this.excludeweekendChk.TabIndex = 15;
            this.excludeweekendChk.Text = "Exclude Weekends";
            this.excludeweekendChk.UseVisualStyleBackColor = true;
            // 
            // DayCountFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 126);
            this.Controls.Add(this.excludeweekendChk);
            this.Controls.Add(this.dayCountTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exButton1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DayCountFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Day Count";
            this.Load += new System.EventHandler(this.DayCountFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dayCountTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CG.Controls.Grid.Buttons.ExButton exButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown dayCountTxt;
        private System.Windows.Forms.CheckBox excludeweekendChk;
    }
}