namespace Cura.Forms
{
    partial class NewGroupFrm
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
            this.newGroupNameTxt = new System.Windows.Forms.TextBox();
            this.exButton1 = new CG.Controls.Grid.Buttons.ExButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // newGroupNameTxt
            // 
            this.newGroupNameTxt.Location = new System.Drawing.Point(126, 31);
            this.newGroupNameTxt.MaxLength = 100;
            this.newGroupNameTxt.Name = "newGroupNameTxt";
            this.newGroupNameTxt.Size = new System.Drawing.Size(153, 22);
            this.newGroupNameTxt.TabIndex = 0;
            this.newGroupNameTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newGroupNameTxt_KeyDown);
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
            this.exButton1.Location = new System.Drawing.Point(233, 80);
            this.exButton1.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exButton1.Name = "exButton1";
            this.exButton1.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exButton1.Renderer = officeButtonRenderer1;
            this.exButton1.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exButton1.Size = new System.Drawing.Size(101, 25);
            this.exButton1.SplitButtonWidth = 20;
            this.exButton1.TabIndex = 6;
            this.exButton1.Text = "Ok";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "New Group Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::Cura.Properties.Resources.sidepointman_small;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(293, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 70);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(6, 94);
            this.helpCtrl1.Message = "This is the name of the new group you want to create. \r\n\r\nJust enter the name and" +
    " press the OK button.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = false;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 9;
            // 
            // NewGroupFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 117);
            this.Controls.Add(this.helpCtrl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.newGroupNameTxt);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewGroupFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Group";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewGroupFrm_FormClosing);
            this.Load += new System.EventHandler(this.NewGroupFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newGroupNameTxt;
        private CG.Controls.Grid.Buttons.ExButton exButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.HelpCtrl helpCtrl1;
    }
}