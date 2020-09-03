namespace Cura.Forms
{
    partial class BackupRestoreFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupRestoreFrm));
            this.backupRadio = new System.Windows.Forms.RadioButton();
            this.restoreRadio = new System.Windows.Forms.RadioButton();
            this.backupTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.restoreTxt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.exButton1 = new CG.Controls.Grid.Buttons.ExButton();
            this.label2 = new System.Windows.Forms.Label();
            this.backuperrorpic = new System.Windows.Forms.PictureBox();
            this.restoreerrorpic = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backuppanel = new System.Windows.Forms.Panel();
            this.restorepanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backuperrorpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreerrorpic)).BeginInit();
            this.backuppanel.SuspendLayout();
            this.restorepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backupRadio
            // 
            this.backupRadio.AutoSize = true;
            this.backupRadio.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupRadio.Location = new System.Drawing.Point(10, 131);
            this.backupRadio.Name = "backupRadio";
            this.backupRadio.Size = new System.Drawing.Size(80, 22);
            this.backupRadio.TabIndex = 1;
            this.backupRadio.TabStop = true;
            this.backupRadio.Text = "Backup";
            this.backupRadio.UseVisualStyleBackColor = true;
            this.backupRadio.CheckedChanged += new System.EventHandler(this.backupRadio_CheckedChanged);
            // 
            // restoreRadio
            // 
            this.restoreRadio.AutoSize = true;
            this.restoreRadio.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreRadio.Location = new System.Drawing.Point(10, 272);
            this.restoreRadio.Name = "restoreRadio";
            this.restoreRadio.Size = new System.Drawing.Size(85, 22);
            this.restoreRadio.TabIndex = 1;
            this.restoreRadio.TabStop = true;
            this.restoreRadio.Text = "Restore";
            this.restoreRadio.UseVisualStyleBackColor = true;
            this.restoreRadio.CheckedChanged += new System.EventHandler(this.restoreRadio_CheckedChanged);
            // 
            // backupTxt
            // 
            this.backupTxt.Location = new System.Drawing.Point(22, 44);
            this.backupTxt.Name = "backupTxt";
            this.backupTxt.Size = new System.Drawing.Size(278, 22);
            this.backupTxt.TabIndex = 2;
            this.backupTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // restoreTxt
            // 
            this.restoreTxt.Location = new System.Drawing.Point(22, 48);
            this.restoreTxt.Name = "restoreTxt";
            this.restoreTxt.Size = new System.Drawing.Size(278, 22);
            this.restoreTxt.TabIndex = 2;
            this.restoreTxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // exButton1
            // 
            this.exButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exButton1.BackColor = System.Drawing.Color.Transparent;
            this.exButton1.CornerRadius = 3;
            this.exButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.exButton1.DrawFocusRect = true;
            this.exButton1.Enabled = false;
            this.exButton1.ImageOffset = new System.Drawing.Point(4, 0);
            this.exButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.exButton1.IsSplitButton = false;
            this.exButton1.Location = new System.Drawing.Point(334, 423);
            this.exButton1.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.exButton1.Name = "exButton1";
            this.exButton1.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.exButton1.Renderer = officeButtonRenderer1;
            this.exButton1.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.exButton1.Size = new System.Drawing.Size(87, 23);
            this.exButton1.SplitButtonWidth = 20;
            this.exButton1.TabIndex = 6;
            this.exButton1.Text = "Begin";
            this.exButton1.Click += new System.EventHandler(this.exButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Specify the location you wish to backup to.";
            // 
            // backuperrorpic
            // 
            this.backuperrorpic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backuperrorpic.BackgroundImage = global::Cura.Properties.Resources.exclamation;
            this.backuperrorpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backuperrorpic.Location = new System.Drawing.Point(347, 47);
            this.backuperrorpic.Name = "backuperrorpic";
            this.backuperrorpic.Size = new System.Drawing.Size(16, 15);
            this.backuperrorpic.TabIndex = 13;
            this.backuperrorpic.TabStop = false;
            // 
            // restoreerrorpic
            // 
            this.restoreerrorpic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreerrorpic.BackgroundImage = global::Cura.Properties.Resources.exclamation;
            this.restoreerrorpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.restoreerrorpic.Location = new System.Drawing.Point(346, 52);
            this.restoreerrorpic.Name = "restoreerrorpic";
            this.restoreerrorpic.Size = new System.Drawing.Size(16, 15);
            this.restoreerrorpic.TabIndex = 13;
            this.restoreerrorpic.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select the file to restore from.";
            // 
            // backuppanel
            // 
            this.backuppanel.Controls.Add(this.backupTxt);
            this.backuppanel.Controls.Add(this.button1);
            this.backuppanel.Controls.Add(this.label2);
            this.backuppanel.Controls.Add(this.backuperrorpic);
            this.backuppanel.Enabled = false;
            this.backuppanel.Location = new System.Drawing.Point(28, 159);
            this.backuppanel.Name = "backuppanel";
            this.backuppanel.Size = new System.Drawing.Size(390, 90);
            this.backuppanel.TabIndex = 14;
            // 
            // restorepanel
            // 
            this.restorepanel.Controls.Add(this.restoreTxt);
            this.restorepanel.Controls.Add(this.button2);
            this.restorepanel.Controls.Add(this.restoreerrorpic);
            this.restorepanel.Controls.Add(this.label3);
            this.restorepanel.Enabled = false;
            this.restorepanel.Location = new System.Drawing.Point(28, 300);
            this.restorepanel.Name = "restorepanel";
            this.restorepanel.Size = new System.Drawing.Size(390, 90);
            this.restorepanel.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(409, 62);
            this.label4.TabIndex = 16;
            this.label4.Text = "Please select whether you want to backup or restore. \r\n\r\nWARNING: Restoring will " +
    "override the current data file. It is recommended that you back the current one " +
    "up first.";
            // 
            // BackupRestoreFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 458);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.restorepanel);
            this.Controls.Add(this.backuppanel);
            this.Controls.Add(this.exButton1);
            this.Controls.Add(this.restoreRadio);
            this.Controls.Add(this.backupRadio);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::Cura.Properties.Resources.site_backup_and_restore_icon;
            this.Name = "BackupRestoreFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup / Restore";
            this.Title = "Backup / Restore";
            this.Load += new System.EventHandler(this.BackupRestoreFrm_Load);
            this.Controls.SetChildIndex(this.backupRadio, 0);
            this.Controls.SetChildIndex(this.restoreRadio, 0);
            this.Controls.SetChildIndex(this.exButton1, 0);
            this.Controls.SetChildIndex(this.backuppanel, 0);
            this.Controls.SetChildIndex(this.restorepanel, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.backuperrorpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restoreerrorpic)).EndInit();
            this.backuppanel.ResumeLayout(false);
            this.backuppanel.PerformLayout();
            this.restorepanel.ResumeLayout(false);
            this.restorepanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton backupRadio;
        private System.Windows.Forms.RadioButton restoreRadio;
        private System.Windows.Forms.TextBox backupTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox restoreTxt;
        private System.Windows.Forms.Button button2;
        private CG.Controls.Grid.Buttons.ExButton exButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox backuperrorpic;
        private System.Windows.Forms.PictureBox restoreerrorpic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel backuppanel;
        private System.Windows.Forms.Panel restorepanel;
        private System.Windows.Forms.Label label4;
    }
}