namespace Cura.Forms
{
    partial class RotaPrintMenuFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotaPrintMenuFrm));
            this.allweekradio = new System.Windows.Forms.RadioButton();
            this.selectionweekradio = new System.Windows.Forms.RadioButton();
            this.weekstxt = new System.Windows.Forms.TextBox();
            this.exButton1 = new CG.Controls.Grid.Buttons.ExButton();
            this.label1 = new System.Windows.Forms.Label();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.SuspendLayout();
            // 
            // allweekradio
            // 
            this.allweekradio.AutoSize = true;
            this.allweekradio.Checked = true;
            this.allweekradio.Location = new System.Drawing.Point(14, 17);
            this.allweekradio.Name = "allweekradio";
            this.allweekradio.Size = new System.Drawing.Size(78, 18);
            this.allweekradio.TabIndex = 0;
            this.allweekradio.TabStop = true;
            this.allweekradio.Text = "All Weeks";
            this.allweekradio.UseVisualStyleBackColor = true;
            this.allweekradio.CheckedChanged += new System.EventHandler(this.allweekradio_CheckedChanged);
            // 
            // selectionweekradio
            // 
            this.selectionweekradio.AutoSize = true;
            this.selectionweekradio.Location = new System.Drawing.Point(14, 44);
            this.selectionweekradio.Name = "selectionweekradio";
            this.selectionweekradio.Size = new System.Drawing.Size(111, 18);
            this.selectionweekradio.TabIndex = 0;
            this.selectionweekradio.Text = "Week Selection";
            this.selectionweekradio.UseVisualStyleBackColor = true;
            this.selectionweekradio.CheckedChanged += new System.EventHandler(this.selectionweekradio_CheckedChanged);
            // 
            // weekstxt
            // 
            this.weekstxt.Enabled = false;
            this.weekstxt.Location = new System.Drawing.Point(133, 42);
            this.weekstxt.Name = "weekstxt";
            this.weekstxt.Size = new System.Drawing.Size(184, 22);
            this.weekstxt.TabIndex = 1;
            this.weekstxt.TextChanged += new System.EventHandler(this.weekstxt_TextChanged);
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
            this.exButton1.Location = new System.Drawing.Point(247, 92);
            this.exButton1.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exButton1.Name = "exButton1";
            this.exButton1.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exButton1.Renderer = officeButtonRenderer1;
            this.exButton1.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exButton1.Size = new System.Drawing.Size(101, 25);
            this.exButton1.SplitButtonWidth = 20;
            this.exButton1.TabIndex = 5;
            this.exButton1.Text = "Ok";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(130, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "(1, 3, 4, 5, etc)";
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(341, 8);
            this.helpCtrl1.Message = resources.GetString("helpCtrl1.Message");
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = false;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 7;
            // 
            // RotaPrintMenuFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 130);
            this.Controls.Add(this.helpCtrl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.weekstxt);
            this.Controls.Add(this.selectionweekradio);
            this.Controls.Add(this.allweekradio);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RotaPrintMenuFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rota Week Selection";
            this.Load += new System.EventHandler(this.RotaPrintMenuFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton allweekradio;
        private System.Windows.Forms.RadioButton selectionweekradio;
        private System.Windows.Forms.TextBox weekstxt;
        private CG.Controls.Grid.Buttons.ExButton exButton1;
        private System.Windows.Forms.Label label1;
        private Controls.HelpCtrl helpCtrl1;
    }
}