using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Controls.Common.Calendar
{
	public partial class CalendarDayCtrl : UserControl
	{
  

	public bool ShowDateNumber {
		get { return dayNolbl.Visible; }
		set { dayNolbl.Visible = value; }
	}

	protected List<CalendarDayCtrlItem> CalendarDayCtrlItems = new List<CalendarDayCtrlItem>();

	protected List<System.Windows.Forms.Label> Labels = new List<System.Windows.Forms.Label>();

	private int scrollOffset = 0;
	protected bool mDisabled;
	public bool Disabled {
		get { return mDisabled; }
		set {
			mDisabled = value;

			this.Enabled = !Disabled;
			this.BackColor = Disabled ? System.Drawing.Color.FromArgb(234, 234, 234) : System.Drawing.Color.White;
			dayNolbl.Visible = !Disabled;


			if (Disabled) {
				foreach (System.Windows.Forms.Label l in Labels) {
					l.Visible = false;
				}

				Button1.Visible = false;
				Button2.Visible = false;
			}
		}
	}

	public bool D { get; set; }

	public int Day {
		get { return Convert.ToInt32(dayNolbl.Text); }
		set { dayNolbl.Text = value.ToString(); }
	}

	public void ClearItems()
	{
		CalendarDayCtrlItems.Clear();
	}

	public void AddItem(object item, System.Drawing.Color color, string tag, bool redraw = true)
	{
		CalendarDayCtrlItems.Add(new CalendarDayCtrlItem {
			Item = item,
			Color = color,
			Tag = tag
		});

		if (redraw)
			UpdateDayCtrl();
	}


	public void UpdateDayCtrl()
	{
		if (Labels.Count != CalendarDayCtrlItems.Count) {
			if (Labels.Count < CalendarDayCtrlItems.Count) {
				//add some

				for (int i = 0; i <= (CalendarDayCtrlItems.Count - Labels.Count) - 1; i++) {
					Label lbl = new Label();

					lbl.Name = "Label" + Labels.Count + 1;
					lbl.Width = Label1.Width;
					lbl.Height = Label1.Height;

					lbl.Anchor = Label1.Anchor;
					lbl.BorderStyle = Label1.BorderStyle;

					lbl.Click += Label_Click;
					lbl.MouseDown += Label_MouseDown;
					lbl.MouseUp += Label_MouseUp;
					lbl.MouseEnter += Label_MouseEnter;
					lbl.MouseLeave += Label_MouseLeave;

					Labels.Add(lbl);

					Controls.Add(lbl);

				}

			} else if (Labels.Count > CalendarDayCtrlItems.Count) {
				//remove some some
				while ((Labels.Count != CalendarDayCtrlItems.Count & Labels.Count != 1)) {
					// delete a label
					Label l = Labels[Labels.Count - 1];

					Labels.Remove(l);
					Controls.Remove(l);
				}
			}
		}

		foreach (System.Windows.Forms.Label l in Labels) {
			l.Visible = false;
		}

		if (CalendarDayCtrlItems.Count > 0) {

			for (int i = 0; i <= (CalendarDayCtrlItems.Count - 1) - scrollOffset; i++) {
				if (i > 0) {
					Labels[i].Top = Labels[i - 1].Top + Labels[i - 1].Height + 2;
					Labels[i].Left = Labels[i - 1].Left;
				}


				Labels[i].Visible = true;
				Labels[i].BackColor = CalendarDayCtrlItems[i + scrollOffset].Color;
				Labels[i].Tag = CalendarDayCtrlItems[i + scrollOffset].Tag;
				Labels[i].Text = CalendarDayCtrlItems[i + scrollOffset].Tag;

			}
		}

		int totalHeight = (Label1.Height + 2) * Labels.Count;

		bool showScrollButtons = CalendarDayCtrlItems.Count == 0 ? false : Label1.Top + totalHeight > this.Height;

		Button1.Visible = showScrollButtons;
		Button2.Visible = showScrollButtons;

	}

	protected class CalendarDayCtrlItem
	{
		public object Item;
		public System.Drawing.Color Color;
		public string Tag;
	}


	public CalendarDayCtrl()
	{
		MouseDoubleClick += CalenderDayCtrl_MouseDoubleClick;
		Load += CalenderDayCtrl_Load;
		// This call is required by the designer.
		InitializeComponent();

		//' Add any initialization after the InitializeComponent() call.
		Labels.Add(Label1);

		Label1.Click += Label_Click;
		Label1.MouseEnter += Label_MouseEnter;
		Label1.MouseLeave += Label_MouseLeave;
		Label1.MouseDown += Label_MouseDown;
		Label1.MouseUp += Label_MouseUp;
	
	}

	private void CalenderDayCtrl_Load(object sender, System.EventArgs e)
	{
		UpdateDayCtrl();
	}

	public event ItemSelectedEventHandler ItemSelected;
	public delegate void ItemSelectedEventHandler(object sender, object item);

	private void Label_Click(System.Object sender, System.EventArgs e)
	{
		int index = Convert.ToInt32(((System.Windows.Forms.Label)sender).Name.Replace("Label", ""));
		if (ItemSelected != null) {
			ItemSelected(this, CalendarDayCtrlItems[(index - 1) + scrollOffset].Item);
		}
	}

	private bool mMouseDown;
	private bool mDragging;
	private void Label_MouseDown(System.Object sender, MouseEventArgs e)
	{
		mMouseDown = true;
	}
	private void Label_MouseUp(System.Object sender, MouseEventArgs e)
	{
		mMouseDown = false;

		if (mDragging) {
			if (DragEnd != null) {
				DragEnd(this);
			}
		}
	}

	public event DragBeginEventHandler DragBegin;
	public delegate void DragBeginEventHandler(System.Object sender);
	public event DragEndEventHandler DragEnd;
	public delegate void DragEndEventHandler(System.Object sender);

	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		scrollOffset -= 1;

		if (scrollOffset < 0)
			scrollOffset = 0;

		UpdateDayCtrl();
	}

	private void Button2_Click(System.Object sender, System.EventArgs e)
	{
		scrollOffset += 1;

		if (scrollOffset + 4 > CalendarDayCtrlItems.Count)
			scrollOffset = CalendarDayCtrlItems.Count - 4;

		UpdateDayCtrl();
	}

	private void Label_MouseEnter(System.Object sender, System.EventArgs e)
	{
		((System.Windows.Forms.Label)sender).BorderStyle = System.Windows.Forms.BorderStyle.None;
	}

	private void Label_MouseLeave(System.Object sender, System.EventArgs e)
	{
		((System.Windows.Forms.Label)sender).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;


		if (mMouseDown) {
			mDragging = true;
			if (DragBegin != null) {
				DragBegin(this);
			}
		}
	}

	public event DaySelectedEventHandler DaySelected;
	public delegate void DaySelectedEventHandler(object sender);
	private void CalenderDayCtrl_MouseDoubleClick(System.Object sender, System.Windows.Forms.MouseEventArgs e)
	{
		if (DaySelected != null) {
			DaySelected(this);
		}
	}



	}
}
