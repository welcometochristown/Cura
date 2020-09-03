namespace Cura.Forms
{
    partial class FutureCallDeletionFrm
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
            this.addRadio = new System.Windows.Forms.RadioButton();
            this.picknchooseradio = new System.Windows.Forms.RadioButton();
            this.sametimechk = new System.Windows.Forms.CheckBox();
            this.samedaychk = new System.Windows.Forms.CheckBox();
            this.otherdayschk = new System.Windows.Forms.CheckBox();
            this.othertimeschk = new System.Windows.Forms.CheckBox();
            this.exButton1 = new CG.Controls.Grid.Buttons.ExButton();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.SuspendLayout();
            // 
            // addRadio
            // 
            this.addRadio.AutoSize = true;
            this.addRadio.Checked = true;
            this.addRadio.Location = new System.Drawing.Point(22, 14);
            this.addRadio.Name = "addRadio";
            this.addRadio.Size = new System.Drawing.Size(37, 18);
            this.addRadio.TabIndex = 0;
            this.addRadio.TabStop = true;
            this.addRadio.Text = "All";
            this.addRadio.UseVisualStyleBackColor = true;
            this.addRadio.CheckedChanged += new System.EventHandler(this.addRadio_CheckedChanged);
            // 
            // picknchooseradio
            // 
            this.picknchooseradio.AutoSize = true;
            this.picknchooseradio.Location = new System.Drawing.Point(22, 42);
            this.picknchooseradio.Name = "picknchooseradio";
            this.picknchooseradio.Size = new System.Drawing.Size(107, 18);
            this.picknchooseradio.TabIndex = 0;
            this.picknchooseradio.Text = "Pick \'n\' Choose";
            this.picknchooseradio.UseVisualStyleBackColor = true;
            this.picknchooseradio.CheckedChanged += new System.EventHandler(this.picknchooseradio_CheckedChanged);
            // 
            // sametimechk
            // 
            this.sametimechk.AutoSize = true;
            this.sametimechk.Checked = true;
            this.sametimechk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sametimechk.Enabled = false;
            this.sametimechk.Location = new System.Drawing.Point(58, 71);
            this.sametimechk.Name = "sametimechk";
            this.sametimechk.Size = new System.Drawing.Size(87, 18);
            this.sametimechk.TabIndex = 1;
            this.sametimechk.Text = "Same Time";
            this.sametimechk.UseVisualStyleBackColor = true;
            // 
            // samedaychk
            // 
            this.samedaychk.AutoSize = true;
            this.samedaychk.Checked = true;
            this.samedaychk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.samedaychk.Enabled = false;
            this.samedaychk.Location = new System.Drawing.Point(158, 71);
            this.samedaychk.Name = "samedaychk";
            this.samedaychk.Size = new System.Drawing.Size(80, 18);
            this.samedaychk.TabIndex = 1;
            this.samedaychk.Text = "Same Day";
            this.samedaychk.UseVisualStyleBackColor = true;
            // 
            // otherdayschk
            // 
            this.otherdayschk.AutoSize = true;
            this.otherdayschk.Enabled = false;
            this.otherdayschk.Location = new System.Drawing.Point(158, 96);
            this.otherdayschk.Name = "otherdayschk";
            this.otherdayschk.Size = new System.Drawing.Size(87, 18);
            this.otherdayschk.TabIndex = 1;
            this.otherdayschk.Text = "Other Days";
            this.otherdayschk.UseVisualStyleBackColor = true;
            // 
            // othertimeschk
            // 
            this.othertimeschk.AutoSize = true;
            this.othertimeschk.Enabled = false;
            this.othertimeschk.Location = new System.Drawing.Point(58, 96);
            this.othertimeschk.Name = "othertimeschk";
            this.othertimeschk.Size = new System.Drawing.Size(94, 18);
            this.othertimeschk.TabIndex = 1;
            this.othertimeschk.Text = "Other Times";
            this.othertimeschk.UseVisualStyleBackColor = true;
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
            this.exButton1.Location = new System.Drawing.Point(185, 130);
            this.exButton1.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exButton1.Name = "exButton1";
            this.exButton1.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exButton1.Renderer = officeButtonRenderer1;
            this.exButton1.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exButton1.Size = new System.Drawing.Size(100, 25);
            this.exButton1.SplitButtonWidth = 20;
            this.exButton1.TabIndex = 12;
            this.exButton1.Text = "Ok";
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(271, 12);
            this.helpCtrl1.Message = "Here you can select which future calls you want to delete.\r\n\r\nUse Pick \'n\' Choose" +
    " to select specific future calls.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = true;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 13;
            // 
            // FutureCallDeletionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 167);
            this.Controls.Add(this.helpCtrl1);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.othertimeschk);
            this.Controls.Add(this.otherdayschk);
            this.Controls.Add(this.samedaychk);
            this.Controls.Add(this.sametimechk);
            this.Controls.Add(this.picknchooseradio);
            this.Controls.Add(this.addRadio);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FutureCallDeletionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Future Call Deletion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton addRadio;
        private System.Windows.Forms.RadioButton picknchooseradio;
        private System.Windows.Forms.CheckBox sametimechk;
        private System.Windows.Forms.CheckBox samedaychk;
        private System.Windows.Forms.CheckBox otherdayschk;
        private System.Windows.Forms.CheckBox othertimeschk;
        private CG.Controls.Grid.Buttons.ExButton exButton1;
        private Controls.HelpCtrl helpCtrl1;
    }
}