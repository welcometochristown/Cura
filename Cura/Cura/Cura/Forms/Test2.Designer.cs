namespace Cura.Forms
{
    partial class Test2
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
            this.colourCombo1 = new Cura.Controls.ColourCombo();
            this.imagedComboBox1 = new ComboxExtended.ImagedComboBox();
            this.SuspendLayout();
            // 
            // colourCombo1
            // 
            this.colourCombo1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colourCombo1.FormattingEnabled = true;
            this.colourCombo1.Location = new System.Drawing.Point(74, 66);
            this.colourCombo1.Name = "colourCombo1";
            this.colourCombo1.SelectedColour = System.Drawing.SystemColors.Window;
            this.colourCombo1.Size = new System.Drawing.Size(312, 21);
            this.colourCombo1.TabIndex = 0;
            // 
            // imagedComboBox1
            // 
            this.imagedComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.imagedComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imagedComboBox1.FormattingEnabled = true;
            this.imagedComboBox1.Location = new System.Drawing.Point(185, 113);
            this.imagedComboBox1.Name = "imagedComboBox1";
            this.imagedComboBox1.Size = new System.Drawing.Size(201, 21);
            this.imagedComboBox1.TabIndex = 1;
            // 
            // Test2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 262);
            this.Controls.Add(this.imagedComboBox1);
            this.Controls.Add(this.colourCombo1);
            this.Name = "Test2";
            this.Text = "Test2";
            this.Load += new System.EventHandler(this.Test2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ColourCombo colourCombo1;
        private ComboxExtended.ImagedComboBox imagedComboBox1;
    }
}