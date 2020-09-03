namespace Cura.Forms
{
    partial class HistoryFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryFrm));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.filter1 = new Cura.Controls.Common.Filter();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.servicerRadio = new System.Windows.Forms.RadioButton();
            this.callassignmentradio = new System.Windows.Forms.RadioButton();
            this.workerRadio = new System.Windows.Forms.RadioButton();
            this.callRadio = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fullviewRadio = new System.Windows.Forms.RadioButton();
            this.simpleViewRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn4);
            this.objectListView1.AllColumns.Add(this.olvColumn5);
            this.objectListView1.AllColumns.Add(this.olvColumn1);
            this.objectListView1.AllColumns.Add(this.olvColumn2);
            this.objectListView1.AllColumns.Add(this.olvColumn3);
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.ShowImagesOnSubItems = true;
            this.objectListView1.Size = new System.Drawing.Size(838, 392);
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "DateUpdate";
            this.olvColumn4.Text = "Date Update";
            this.olvColumn4.Width = 96;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "UID";
            this.olvColumn5.Text = "User";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "FieldName";
            this.olvColumn1.Text = "FieldName";
            this.olvColumn1.Width = 96;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "OldValue";
            this.olvColumn2.Text = "OldValue";
            this.olvColumn2.Width = 90;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "NewValue";
            this.olvColumn3.Text = "NewValue";
            this.olvColumn3.Width = 94;
            // 
            // filter1
            // 
            this.filter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(219)))));
            this.filter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.filter1.Location = new System.Drawing.Point(0, 61);
            this.filter1.Name = "filter1";
            this.filter1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.filter1.Size = new System.Drawing.Size(838, 28);
            this.filter1.TabIndex = 3;
            this.filter1.TextChanged += new System.EventHandler(this.filter1_TextChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 89);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(219)))));
            this.splitContainer2.Panel1.Controls.Add(this.helpCtrl1);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox4);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox3);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox5);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer2.Panel1.Controls.Add(this.servicerRadio);
            this.splitContainer2.Panel1.Controls.Add(this.callassignmentradio);
            this.splitContainer2.Panel1.Controls.Add(this.workerRadio);
            this.splitContainer2.Panel1.Controls.Add(this.callRadio);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.objectListView1);
            this.splitContainer2.Size = new System.Drawing.Size(838, 429);
            this.splitContainer2.SplitterDistance = 32;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 4;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(814, 7);
            this.helpCtrl1.Message = "Here you can see all the changes that have been made to Calls, Workers and Servic" +
    "e Users.\r\n\r\nUse the filter buttons, or filter field to search for a specific cha" +
    "nge.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = true;
            this.helpCtrl1.OpenUp = false;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 8;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Cura.Properties.Resources.house_go;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(14, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 18);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Cura.Properties.Resources.s_user_16;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(393, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 18);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Cura.Properties.Resources.house_user;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(101, 7);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 18);
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Cura.Properties.Resources.user;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(251, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 18);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // servicerRadio
            // 
            this.servicerRadio.AutoSize = true;
            this.servicerRadio.Location = new System.Drawing.Point(416, 6);
            this.servicerRadio.Name = "servicerRadio";
            this.servicerRadio.Size = new System.Drawing.Size(100, 19);
            this.servicerRadio.TabIndex = 5;
            this.servicerRadio.TabStop = true;
            this.servicerRadio.Text = "Service Users";
            this.servicerRadio.UseVisualStyleBackColor = true;
            this.servicerRadio.CheckedChanged += new System.EventHandler(this.servicerRadio_CheckedChanged);
            // 
            // callassignmentradio
            // 
            this.callassignmentradio.AutoSize = true;
            this.callassignmentradio.Location = new System.Drawing.Point(125, 6);
            this.callassignmentradio.Name = "callassignmentradio";
            this.callassignmentradio.Size = new System.Drawing.Size(119, 19);
            this.callassignmentradio.TabIndex = 5;
            this.callassignmentradio.TabStop = true;
            this.callassignmentradio.Text = "Call Assignments";
            this.callassignmentradio.UseVisualStyleBackColor = true;
            this.callassignmentradio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // workerRadio
            // 
            this.workerRadio.AutoSize = true;
            this.workerRadio.Location = new System.Drawing.Point(274, 6);
            this.workerRadio.Name = "workerRadio";
            this.workerRadio.Size = new System.Drawing.Size(99, 19);
            this.workerRadio.TabIndex = 5;
            this.workerRadio.TabStop = true;
            this.workerRadio.Text = "Care Workers";
            this.workerRadio.UseVisualStyleBackColor = true;
            this.workerRadio.CheckedChanged += new System.EventHandler(this.workerRadio_CheckedChanged);
            // 
            // callRadio
            // 
            this.callRadio.AutoSize = true;
            this.callRadio.Checked = true;
            this.callRadio.Location = new System.Drawing.Point(37, 6);
            this.callRadio.Name = "callRadio";
            this.callRadio.Size = new System.Drawing.Size(52, 19);
            this.callRadio.TabIndex = 5;
            this.callRadio.TabStop = true;
            this.callRadio.Text = "Calls";
            this.callRadio.UseVisualStyleBackColor = true;
            this.callRadio.CheckedChanged += new System.EventHandler(this.callRadio_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.fullviewRadio);
            this.panel2.Controls.Add(this.simpleViewRadio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(838, 29);
            this.panel2.TabIndex = 5;
            // 
            // fullviewRadio
            // 
            this.fullviewRadio.AutoSize = true;
            this.fullviewRadio.Checked = true;
            this.fullviewRadio.Location = new System.Drawing.Point(6, 4);
            this.fullviewRadio.Name = "fullviewRadio";
            this.fullviewRadio.Size = new System.Drawing.Size(74, 19);
            this.fullviewRadio.TabIndex = 0;
            this.fullviewRadio.TabStop = true;
            this.fullviewRadio.Text = "Full View";
            this.fullviewRadio.UseVisualStyleBackColor = true;
            // 
            // simpleViewRadio
            // 
            this.simpleViewRadio.AutoSize = true;
            this.simpleViewRadio.Location = new System.Drawing.Point(97, 4);
            this.simpleViewRadio.Name = "simpleViewRadio";
            this.simpleViewRadio.Size = new System.Drawing.Size(93, 19);
            this.simpleViewRadio.TabIndex = 0;
            this.simpleViewRadio.TabStop = true;
            this.simpleViewRadio.Text = "Simple View";
            this.simpleViewRadio.UseVisualStyleBackColor = true;
            // 
            // HistoryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 518);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.filter1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::Cura.Properties.Resources.History_Folder_Willow_icon_48;
            this.ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "HistoryFrm";
            this.Text = "History";
            this.Title = "History";
            this.Load += new System.EventHandler(this.HistoryFrm_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.filter1, 0);
            this.Controls.SetChildIndex(this.splitContainer2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private Controls.Common.Filter filter1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RadioButton callRadio;
        private System.Windows.Forms.RadioButton workerRadio;
        private System.Windows.Forms.RadioButton servicerRadio;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RadioButton callassignmentradio;
        private Controls.HelpCtrl helpCtrl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton fullviewRadio;
        private System.Windows.Forms.RadioButton simpleViewRadio;
    }
}