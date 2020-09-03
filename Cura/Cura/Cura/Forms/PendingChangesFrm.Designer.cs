namespace Cura.Forms
{
    partial class PendingChangesFrm
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
            CG.Controls.Grid.Buttons.OfficeButtonRenderer officeButtonRenderer2 = new CG.Controls.Grid.Buttons.OfficeButtonRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingChangesFrm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.undoTSbtn = new System.Windows.Forms.ToolStripButton();
            this.saveTSbtn = new System.Windows.Forms.ToolStripButton();
            this.objectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.helpCtrl1 = new Cura.Controls.HelpCtrl();
            this.selectAllbtn = new CG.Controls.Grid.Buttons.ExButton();
            this.unselectallbtn = new CG.Controls.Grid.Buttons.ExButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoTSbtn,
            this.saveTSbtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(708, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // undoTSbtn
            // 
            this.undoTSbtn.Enabled = false;
            this.undoTSbtn.Image = global::Cura.Properties.Resources.arrow_undo_red;
            this.undoTSbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoTSbtn.Name = "undoTSbtn";
            this.undoTSbtn.Size = new System.Drawing.Size(113, 22);
            this.undoTSbtn.Text = "Undo Change(s)";
            this.undoTSbtn.Click += new System.EventHandler(this.undoTSbtn_Click);
            // 
            // saveTSbtn
            // 
            this.saveTSbtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveTSbtn.Enabled = false;
            this.saveTSbtn.Image = global::Cura.Properties.Resources.disk;
            this.saveTSbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveTSbtn.Name = "saveTSbtn";
            this.saveTSbtn.Size = new System.Drawing.Size(108, 22);
            this.saveTSbtn.Text = "Save Change(s)";
            this.saveTSbtn.Click += new System.EventHandler(this.saveTSbtn_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumn7);
            this.objectListView1.CheckBoxes = true;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7});
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(0, 57);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.OwnerDraw = true;
            this.objectListView1.ShowGroups = false;
            this.objectListView1.ShowImagesOnSubItems = true;
            this.objectListView1.Size = new System.Drawing.Size(708, 337);
            this.objectListView1.TabIndex = 3;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.UseFiltering = true;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.VirtualMode = true;
            this.objectListView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.objectListView1_ItemChecked);
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "Changes";
            this.olvColumn7.Groupable = false;
            this.olvColumn7.Text = "Changes";
            this.olvColumn7.Width = 500;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "DateUpdate";
            this.olvColumn4.DisplayIndex = 0;
            this.olvColumn4.Text = "Date Update";
            this.olvColumn4.Width = 96;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "UID";
            this.olvColumn5.DisplayIndex = 1;
            this.olvColumn5.Text = "User";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "FieldName";
            this.olvColumn1.DisplayIndex = 2;
            this.olvColumn1.Text = "FieldName";
            this.olvColumn1.Width = 96;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "OldValue";
            this.olvColumn2.DisplayIndex = 3;
            this.olvColumn2.Text = "OldValue";
            this.olvColumn2.Width = 90;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "NewValue";
            this.olvColumn3.DisplayIndex = 4;
            this.olvColumn3.Text = "NewValue";
            this.olvColumn3.Width = 94;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.helpCtrl1);
            this.panel2.Controls.Add(this.selectAllbtn);
            this.panel2.Controls.Add(this.unselectallbtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 26);
            this.panel2.TabIndex = 4;
            // 
            // helpCtrl1
            // 
            this.helpCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.helpCtrl1.Caption = null;
            this.helpCtrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpCtrl1.Location = new System.Drawing.Point(688, 5);
            this.helpCtrl1.Message = "The pending changes allows you to view changes you have made and select which cha" +
    "nges you wish to save and which you wish to undo. \r\n\r\nNote: If you close Cura wi" +
    "thout saving changes they\'ll be lost.";
            this.helpCtrl1.Name = "helpCtrl1";
            this.helpCtrl1.OpenLeft = true;
            this.helpCtrl1.OpenUp = true;
            this.helpCtrl1.Size = new System.Drawing.Size(16, 16);
            this.helpCtrl1.TabIndex = 12;
            // 
            // selectAllbtn
            // 
            this.selectAllbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllbtn.BackColor = System.Drawing.Color.Transparent;
            this.selectAllbtn.CornerRadius = 3;
            this.selectAllbtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.selectAllbtn.DrawFocusRect = true;
            this.selectAllbtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.selectAllbtn.ImageSize = new System.Drawing.Size(16, 16);
            this.selectAllbtn.IsSplitButton = false;
            this.selectAllbtn.Location = new System.Drawing.Point(1, 1);
            this.selectAllbtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.selectAllbtn.Name = "selectAllbtn";
            this.selectAllbtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer1.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.selectAllbtn.Renderer = officeButtonRenderer1;
            this.selectAllbtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.selectAllbtn.Size = new System.Drawing.Size(94, 24);
            this.selectAllbtn.SplitButtonWidth = 20;
            this.selectAllbtn.TabIndex = 11;
            this.selectAllbtn.Text = "Select All";
            this.selectAllbtn.Click += new System.EventHandler(this.selectAllbtn_Click);
            // 
            // unselectallbtn
            // 
            this.unselectallbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectallbtn.BackColor = System.Drawing.Color.Transparent;
            this.unselectallbtn.CornerRadius = 3;
            this.unselectallbtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.unselectallbtn.DrawFocusRect = true;
            this.unselectallbtn.ImageOffset = new System.Drawing.Point(4, 0);
            this.unselectallbtn.ImageSize = new System.Drawing.Size(16, 16);
            this.unselectallbtn.IsSplitButton = false;
            this.unselectallbtn.Location = new System.Drawing.Point(100, 1);
            this.unselectallbtn.MetroColorScheme = CG.Controls.Grid.Render.MetroScheme.Orange;
            this.unselectallbtn.Name = "unselectallbtn";
            this.unselectallbtn.PaddingText = new System.Windows.Forms.Padding(4);
            officeButtonRenderer2.TextColorDisabled = System.Drawing.SystemColors.GrayText;
            this.unselectallbtn.Renderer = officeButtonRenderer2;
            this.unselectallbtn.RenderType = CG.Controls.Common.EnRenderType.Office2007;
            this.unselectallbtn.Size = new System.Drawing.Size(94, 24);
            this.unselectallbtn.SplitButtonWidth = 20;
            this.unselectallbtn.TabIndex = 11;
            this.unselectallbtn.Text = "Unselect All";
            this.unselectallbtn.Click += new System.EventHandler(this.unselectallbtn_Click);
            // 
            // PendingChangesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 420);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::Cura.Properties.Resources.star_16;
            this.Name = "PendingChangesFrm";
            this.Text = "Pending Changes";
            this.Title = "Pending Changes";
            this.Load += new System.EventHandler(this.PendingChangesFrm_Load);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.objectListView1, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton undoTSbtn;
        private System.Windows.Forms.ToolStripButton saveTSbtn;
        private BrightIdeasSoftware.FastObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.Panel panel2;
        private CG.Controls.Grid.Buttons.ExButton selectAllbtn;
        private CG.Controls.Grid.Buttons.ExButton unselectallbtn;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private Controls.HelpCtrl helpCtrl1;
    }
}