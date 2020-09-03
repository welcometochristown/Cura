namespace CuraMerge
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mergeBtn = new System.Windows.Forms.Button();
            this.oldcurapathtxt = new System.Windows.Forms.TextBox();
            this.oldcurafilebtn = new System.Windows.Forms.Button();
            this.fileerrorpic = new System.Windows.Forms.PictureBox();
            this.newlocationRadio = new System.Windows.Forms.RadioButton();
            this.datakeepRadio = new System.Windows.Forms.RadioButton();
            this.newCuralocationRadio = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datafiletxt = new System.Windows.Forms.TextBox();
            this.newdatalocationfilebtn = new System.Windows.Forms.Button();
            this.panel00 = new System.Windows.Forms.Panel();
            this.panel01 = new System.Windows.Forms.Panel();
            this.fileerrorpic4 = new System.Windows.Forms.PictureBox();
            this.fileerrorpic3 = new System.Windows.Forms.PictureBox();
            this.fileerrorpic2 = new System.Windows.Forms.PictureBox();
            this.panel02 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.loading01 = new System.Windows.Forms.PictureBox();
            this.loadin02 = new System.Windows.Forms.PictureBox();
            this.loading03 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic)).BeginInit();
            this.panel00.SuspendLayout();
            this.panel01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic2)).BeginInit();
            this.panel02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loading01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadin02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loading03)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::CuraMerge.Properties.Resources.welcomeman;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(4, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(223, 281);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(630, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Welcome to Cura Merge Tool";
            // 
            // mergeBtn
            // 
            this.mergeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeBtn.Location = new System.Drawing.Point(457, 454);
            this.mergeBtn.Name = "mergeBtn";
            this.mergeBtn.Size = new System.Drawing.Size(93, 32);
            this.mergeBtn.TabIndex = 3;
            this.mergeBtn.Text = "Merge!";
            this.mergeBtn.UseVisualStyleBackColor = true;
            this.mergeBtn.Click += new System.EventHandler(this.mergeBtn_Click);
            // 
            // oldcurapathtxt
            // 
            this.oldcurapathtxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(234)))), ((int)(((byte)(198)))));
            this.oldcurapathtxt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldcurapathtxt.Location = new System.Drawing.Point(32, 81);
            this.oldcurapathtxt.Name = "oldcurapathtxt";
            this.oldcurapathtxt.ReadOnly = true;
            this.oldcurapathtxt.Size = new System.Drawing.Size(300, 21);
            this.oldcurapathtxt.TabIndex = 4;
            // 
            // oldcurafilebtn
            // 
            this.oldcurafilebtn.Location = new System.Drawing.Point(338, 82);
            this.oldcurafilebtn.Name = "oldcurafilebtn";
            this.oldcurafilebtn.Size = new System.Drawing.Size(31, 20);
            this.oldcurafilebtn.TabIndex = 5;
            this.oldcurafilebtn.Text = "...";
            this.oldcurafilebtn.UseVisualStyleBackColor = true;
            this.oldcurafilebtn.Click += new System.EventHandler(this.oldcurafilebtn_Click);
            // 
            // fileerrorpic
            // 
            this.fileerrorpic.BackgroundImage = global::CuraMerge.Properties.Resources.exclamation;
            this.fileerrorpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileerrorpic.Location = new System.Drawing.Point(10, 82);
            this.fileerrorpic.Name = "fileerrorpic";
            this.fileerrorpic.Size = new System.Drawing.Size(16, 15);
            this.fileerrorpic.TabIndex = 13;
            this.fileerrorpic.TabStop = false;
            // 
            // newlocationRadio
            // 
            this.newlocationRadio.AutoSize = true;
            this.newlocationRadio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newlocationRadio.Location = new System.Drawing.Point(34, 83);
            this.newlocationRadio.Name = "newlocationRadio";
            this.newlocationRadio.Size = new System.Drawing.Size(186, 20);
            this.newlocationRadio.TabIndex = 14;
            this.newlocationRadio.TabStop = true;
            this.newlocationRadio.Text = "Copy data to new location...";
            this.newlocationRadio.UseVisualStyleBackColor = true;
            this.newlocationRadio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // datakeepRadio
            // 
            this.datakeepRadio.AutoSize = true;
            this.datakeepRadio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datakeepRadio.Location = new System.Drawing.Point(34, 33);
            this.datakeepRadio.Name = "datakeepRadio";
            this.datakeepRadio.Size = new System.Drawing.Size(185, 20);
            this.datakeepRadio.TabIndex = 14;
            this.datakeepRadio.TabStop = true;
            this.datakeepRadio.Text = "Leave data in same location";
            this.datakeepRadio.UseVisualStyleBackColor = true;
            this.datakeepRadio.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // newCuralocationRadio
            // 
            this.newCuralocationRadio.AutoSize = true;
            this.newCuralocationRadio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCuralocationRadio.Location = new System.Drawing.Point(34, 57);
            this.newCuralocationRadio.Name = "newCuralocationRadio";
            this.newCuralocationRadio.Size = new System.Drawing.Size(211, 20);
            this.newCuralocationRadio.TabIndex = 14;
            this.newCuralocationRadio.TabStop = true;
            this.newCuralocationRadio.Text = "Move to new cura data directory";
            this.newCuralocationRadio.UseVisualStyleBackColor = true;
            this.newCuralocationRadio.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(10, 51);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 20);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Clean Up Old Cura";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 73);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ok, lets get started! \r\n\r\nThe first step is to find out where the old version of " +
    "Cura is. Please find appropriate location below.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "Next you need to define where the datafile will be kept.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(338, 39);
            this.label5.TabIndex = 18;
            this.label5.Text = "Finally you can specify whether you want to clean up the old version of Cura. (Op" +
    "tional)";
            // 
            // datafiletxt
            // 
            this.datafiletxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(234)))), ((int)(((byte)(198)))));
            this.datafiletxt.Location = new System.Drawing.Point(36, 109);
            this.datafiletxt.Name = "datafiletxt";
            this.datafiletxt.ReadOnly = true;
            this.datafiletxt.Size = new System.Drawing.Size(310, 20);
            this.datafiletxt.TabIndex = 19;
            // 
            // newdatalocationfilebtn
            // 
            this.newdatalocationfilebtn.Enabled = false;
            this.newdatalocationfilebtn.Location = new System.Drawing.Point(353, 109);
            this.newdatalocationfilebtn.Name = "newdatalocationfilebtn";
            this.newdatalocationfilebtn.Size = new System.Drawing.Size(31, 20);
            this.newdatalocationfilebtn.TabIndex = 5;
            this.newdatalocationfilebtn.Text = "...";
            this.newdatalocationfilebtn.UseVisualStyleBackColor = true;
            this.newdatalocationfilebtn.Click += new System.EventHandler(this.newdatalocationfilebtn_Click);
            // 
            // panel00
            // 
            this.panel00.Controls.Add(this.label3);
            this.panel00.Controls.Add(this.oldcurapathtxt);
            this.panel00.Controls.Add(this.oldcurafilebtn);
            this.panel00.Controls.Add(this.fileerrorpic);
            this.panel00.Location = new System.Drawing.Point(243, 104);
            this.panel00.Name = "panel00";
            this.panel00.Size = new System.Drawing.Size(395, 111);
            this.panel00.TabIndex = 20;
            // 
            // panel01
            // 
            this.panel01.Controls.Add(this.fileerrorpic4);
            this.panel01.Controls.Add(this.fileerrorpic3);
            this.panel01.Controls.Add(this.fileerrorpic2);
            this.panel01.Controls.Add(this.label4);
            this.panel01.Controls.Add(this.newdatalocationfilebtn);
            this.panel01.Controls.Add(this.newlocationRadio);
            this.panel01.Controls.Add(this.datafiletxt);
            this.panel01.Controls.Add(this.datakeepRadio);
            this.panel01.Controls.Add(this.newCuralocationRadio);
            this.panel01.Location = new System.Drawing.Point(244, 223);
            this.panel01.Name = "panel01";
            this.panel01.Size = new System.Drawing.Size(394, 139);
            this.panel01.TabIndex = 21;
            // 
            // fileerrorpic4
            // 
            this.fileerrorpic4.BackgroundImage = global::CuraMerge.Properties.Resources.exclamation;
            this.fileerrorpic4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileerrorpic4.Location = new System.Drawing.Point(11, 109);
            this.fileerrorpic4.Name = "fileerrorpic4";
            this.fileerrorpic4.Size = new System.Drawing.Size(16, 15);
            this.fileerrorpic4.TabIndex = 20;
            this.fileerrorpic4.TabStop = false;
            this.fileerrorpic4.Visible = false;
            // 
            // fileerrorpic3
            // 
            this.fileerrorpic3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fileerrorpic3.BackgroundImage")));
            this.fileerrorpic3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileerrorpic3.Location = new System.Drawing.Point(11, 58);
            this.fileerrorpic3.Name = "fileerrorpic3";
            this.fileerrorpic3.Size = new System.Drawing.Size(16, 15);
            this.fileerrorpic3.TabIndex = 20;
            this.fileerrorpic3.TabStop = false;
            this.fileerrorpic3.Visible = false;
            // 
            // fileerrorpic2
            // 
            this.fileerrorpic2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fileerrorpic2.BackgroundImage")));
            this.fileerrorpic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileerrorpic2.Location = new System.Drawing.Point(11, 33);
            this.fileerrorpic2.Name = "fileerrorpic2";
            this.fileerrorpic2.Size = new System.Drawing.Size(16, 15);
            this.fileerrorpic2.TabIndex = 20;
            this.fileerrorpic2.TabStop = false;
            this.fileerrorpic2.Visible = false;
            // 
            // panel02
            // 
            this.panel02.Controls.Add(this.pictureBox3);
            this.panel02.Controls.Add(this.checkBox1);
            this.panel02.Controls.Add(this.label5);
            this.panel02.Location = new System.Drawing.Point(243, 368);
            this.panel02.Name = "panel02";
            this.panel02.Size = new System.Drawing.Size(395, 80);
            this.panel02.TabIndex = 22;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackgroundImage = global::CuraMerge.Properties.Resources.brush;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(351, 36);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 41);
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(544, 26);
            this.label6.TabIndex = 23;
            this.label6.Text = "You can use this tool to merge an old version of Cura with the current one.";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(558, 458);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 24);
            this.button3.TabIndex = 3;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // loading01
            // 
            this.loading01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loading01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loading01.Image = global::CuraMerge.Properties.Resources.animated_bullet;
            this.loading01.Location = new System.Drawing.Point(228, 109);
            this.loading01.Name = "loading01";
            this.loading01.Size = new System.Drawing.Size(16, 15);
            this.loading01.TabIndex = 24;
            this.loading01.TabStop = false;
            // 
            // loadin02
            // 
            this.loadin02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadin02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadin02.Image = global::CuraMerge.Properties.Resources.animated_bullet;
            this.loadin02.Location = new System.Drawing.Point(228, 231);
            this.loadin02.Name = "loadin02";
            this.loadin02.Size = new System.Drawing.Size(16, 15);
            this.loadin02.TabIndex = 25;
            this.loadin02.TabStop = false;
            this.loadin02.Visible = false;
            // 
            // loading03
            // 
            this.loading03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loading03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loading03.Image = global::CuraMerge.Properties.Resources.animated_bullet;
            this.loading03.Location = new System.Drawing.Point(228, 377);
            this.loading03.Name = "loading03";
            this.loading03.Size = new System.Drawing.Size(16, 15);
            this.loading03.TabIndex = 26;
            this.loading03.TabStop = false;
            this.loading03.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 497);
            this.Controls.Add(this.loading03);
            this.Controls.Add(this.loadin02);
            this.Controls.Add(this.loading01);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel02);
            this.Controls.Add(this.panel01);
            this.Controls.Add(this.panel00);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.mergeBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Image = global::CuraMerge.Properties.Resources.icon_alpha_merge;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Title = "Cura Merge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.mergeBtn, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.panel00, 0);
            this.Controls.SetChildIndex(this.panel01, 0);
            this.Controls.SetChildIndex(this.panel02, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.loading01, 0);
            this.Controls.SetChildIndex(this.loadin02, 0);
            this.Controls.SetChildIndex(this.loading03, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic)).EndInit();
            this.panel00.ResumeLayout(false);
            this.panel00.PerformLayout();
            this.panel01.ResumeLayout(false);
            this.panel01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileerrorpic2)).EndInit();
            this.panel02.ResumeLayout(false);
            this.panel02.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loading01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadin02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loading03)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mergeBtn;
        private System.Windows.Forms.TextBox oldcurapathtxt;
        private System.Windows.Forms.Button oldcurafilebtn;
        private System.Windows.Forms.PictureBox fileerrorpic;
        private System.Windows.Forms.RadioButton newlocationRadio;
        private System.Windows.Forms.RadioButton datakeepRadio;
        private System.Windows.Forms.RadioButton newCuralocationRadio;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox datafiletxt;
        private System.Windows.Forms.Button newdatalocationfilebtn;
        private System.Windows.Forms.Panel panel00;
        private System.Windows.Forms.Panel panel01;
        private System.Windows.Forms.Panel panel02;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox fileerrorpic4;
        private System.Windows.Forms.PictureBox fileerrorpic3;
        private System.Windows.Forms.PictureBox fileerrorpic2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox loading01;
        private System.Windows.Forms.PictureBox loadin02;
        private System.Windows.Forms.PictureBox loading03;
    }
}

