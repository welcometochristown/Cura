namespace Cura.Forms
{
    partial class WorkerListFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerListFrm));
            this.workerListCtrl1 = new Cura.Controls.WorkerListCtrl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupradio = new System.Windows.Forms.RadioButton();
            this.individualradio = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // workerListCtrl1
            // 
            this.workerListCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workerListCtrl1.Location = new System.Drawing.Point(0, 32);
            this.workerListCtrl1.Name = "workerListCtrl1";
            this.workerListCtrl1.SearchText = null;
            this.workerListCtrl1.ShowContextMenu = true;
            this.workerListCtrl1.ShowFilters = false;
            this.workerListCtrl1.ShowNewButton = false;
            this.workerListCtrl1.ShowSimpleContextMenu = false;
            this.workerListCtrl1.Size = new System.Drawing.Size(695, 320);
            this.workerListCtrl1.TabIndex = 0;
            this.workerListCtrl1.Load += new System.EventHandler(this.workerListCtrl1_Load);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupradio);
            this.panel2.Controls.Add(this.individualradio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 25);
            this.panel2.TabIndex = 1;
            // 
            // groupradio
            // 
            this.groupradio.AutoSize = true;
            this.groupradio.Location = new System.Drawing.Point(106, 3);
            this.groupradio.Name = "groupradio";
            this.groupradio.Size = new System.Drawing.Size(63, 18);
            this.groupradio.TabIndex = 0;
            this.groupradio.Text = "Groups";
            this.groupradio.UseVisualStyleBackColor = true;
            this.groupradio.CheckedChanged += new System.EventHandler(this.groupradio_CheckedChanged);
            // 
            // individualradio
            // 
            this.individualradio.AutoSize = true;
            this.individualradio.Checked = true;
            this.individualradio.Location = new System.Drawing.Point(6, 3);
            this.individualradio.Name = "individualradio";
            this.individualradio.Size = new System.Drawing.Size(80, 18);
            this.individualradio.TabIndex = 0;
            this.individualradio.TabStop = true;
            this.individualradio.Text = "Individuals";
            this.individualradio.UseVisualStyleBackColor = true;
            this.individualradio.CheckedChanged += new System.EventHandler(this.individualradio_CheckedChanged);
            // 
            // WorkerListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 377);
            this.Controls.Add(this.workerListCtrl1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Image = global::Cura.Properties.Resources.user;
            this.Name = "WorkerListFrm";
            this.Text = "Workers";
            this.Title = "All Care Workers";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.workerListCtrl1, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.WorkerListCtrl workerListCtrl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton groupradio;
        private System.Windows.Forms.RadioButton individualradio;
    }
}