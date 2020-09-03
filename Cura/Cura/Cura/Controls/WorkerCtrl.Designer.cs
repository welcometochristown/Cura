namespace Cura.Controls
{
    partial class WorkerCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer_workersmain = new System.Windows.Forms.SplitContainer();
            this.workerHeaderCtrl1 = new Cura.Controls.WorkerHeaderCtrl();
            this.splitcontainer_workers = new System.Windows.Forms.SplitContainer();
            this.workerListCtrl1 = new Cura.Controls.WorkerListCtrl();
            this.workerCalendarCtrl1 = new Cura.Controls.WorkerCalendarCtrl();
            this.splitContainer_workersmain.Panel1.SuspendLayout();
            this.splitContainer_workersmain.Panel2.SuspendLayout();
            this.splitContainer_workersmain.SuspendLayout();
            this.splitcontainer_workers.Panel1.SuspendLayout();
            this.splitcontainer_workers.Panel2.SuspendLayout();
            this.splitcontainer_workers.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_workersmain
            // 
            this.splitContainer_workersmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_workersmain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_workersmain.IsSplitterFixed = true;
            this.splitContainer_workersmain.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_workersmain.Name = "splitContainer_workersmain";
            this.splitContainer_workersmain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_workersmain.Panel1
            // 
            this.splitContainer_workersmain.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer_workersmain.Panel1.BackgroundImage = global::Cura.Properties.Resources.back;
            this.splitContainer_workersmain.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer_workersmain.Panel1.Controls.Add(this.workerHeaderCtrl1);
            // 
            // splitContainer_workersmain.Panel2
            // 
            this.splitContainer_workersmain.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitContainer_workersmain.Panel2.Controls.Add(this.splitcontainer_workers);
            this.splitContainer_workersmain.Size = new System.Drawing.Size(870, 572);
            this.splitContainer_workersmain.SplitterDistance = 25;
            this.splitContainer_workersmain.TabIndex = 1;
            // 
            // workerHeaderCtrl1
            // 
            this.workerHeaderCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workerHeaderCtrl1.Location = new System.Drawing.Point(0, 0);
            this.workerHeaderCtrl1.Name = "workerHeaderCtrl1";
            this.workerHeaderCtrl1.Size = new System.Drawing.Size(870, 25);
            this.workerHeaderCtrl1.TabIndex = 0;
            // 
            // splitcontainer_workers
            // 
            this.splitcontainer_workers.BackColor = System.Drawing.SystemColors.Control;
            this.splitcontainer_workers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainer_workers.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitcontainer_workers.Location = new System.Drawing.Point(0, 0);
            this.splitcontainer_workers.Name = "splitcontainer_workers";
            // 
            // splitcontainer_workers.Panel1
            // 
            this.splitcontainer_workers.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitcontainer_workers.Panel1.Controls.Add(this.workerListCtrl1);
            // 
            // splitcontainer_workers.Panel2
            // 
            this.splitcontainer_workers.Panel2.Controls.Add(this.workerCalendarCtrl1);
            this.splitcontainer_workers.Size = new System.Drawing.Size(870, 543);
            this.splitcontainer_workers.SplitterDistance = 250;
            this.splitcontainer_workers.SplitterWidth = 5;
            this.splitcontainer_workers.TabIndex = 0;
            // 
            // workerListCtrl1
            // 
            this.workerListCtrl1.AllowOpenWorker = true;
            this.workerListCtrl1.BackColor = System.Drawing.SystemColors.Control;
            this.workerListCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workerListCtrl1.Filter = null;
            this.workerListCtrl1.GroupResults = true;
            this.workerListCtrl1.Location = new System.Drawing.Point(0, 0);
            this.workerListCtrl1.Name = "workerListCtrl1";
            this.workerListCtrl1.SearchText = null;
            this.workerListCtrl1.ShowByGroup = false;
            this.workerListCtrl1.ShowContextMenu = true;
            this.workerListCtrl1.ShowFilters = true;
            this.workerListCtrl1.ShowNewButton = true;
            this.workerListCtrl1.ShowSimpleContextMenu = false;
            this.workerListCtrl1.Size = new System.Drawing.Size(250, 543);
            this.workerListCtrl1.TabIndex = 0;
            this.workerListCtrl1.WorkerSelectionChanged += new System.EventHandler(this.workerListCtrl1_WorkerSelectionChanged);
            // 
            // workerCalendarCtrl1
            // 
            this.workerCalendarCtrl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(217)))), ((int)(((byte)(232)))));
            this.workerCalendarCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workerCalendarCtrl1.Location = new System.Drawing.Point(0, 0);
            this.workerCalendarCtrl1.Name = "workerCalendarCtrl1";
            this.workerCalendarCtrl1.Size = new System.Drawing.Size(615, 543);
            this.workerCalendarCtrl1.TabIndex = 0;
            this.workerCalendarCtrl1.Worker = null;
            // 
            // WorkerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_workersmain);
            this.Name = "WorkerCtrl";
            this.Size = new System.Drawing.Size(870, 572);
            this.splitContainer_workersmain.Panel1.ResumeLayout(false);
            this.splitContainer_workersmain.Panel2.ResumeLayout(false);
            this.splitContainer_workersmain.ResumeLayout(false);
            this.splitcontainer_workers.Panel1.ResumeLayout(false);
            this.splitcontainer_workers.Panel2.ResumeLayout(false);
            this.splitcontainer_workers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_workersmain;
        private System.Windows.Forms.SplitContainer splitcontainer_workers;
        private WorkerListCtrl workerListCtrl1;
        private WorkerCalendarCtrl workerCalendarCtrl1;
        private WorkerHeaderCtrl workerHeaderCtrl1;
    }
}
