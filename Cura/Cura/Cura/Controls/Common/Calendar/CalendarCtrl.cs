using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Timers;

namespace Cura.Controls.Common.Calendar
{

	public partial class CalendarCtrl : System.Windows.Forms.UserControl, System.Collections.Generic.IEnumerable<CalendarDayItem>
	{
		protected int mMonth;
		protected int mYear;



		//protected List<CalendarDayItem> CalendarDayItems = new List<CalendarDayItem>();
		protected CalendarDayItemCollection _calendarDayItems = null;


		private List<CalendarDayCtrl> CalendarDayCtrls = new List<CalendarDayCtrl>();

		protected System.Drawing.Size? StartSize = null;


		#region Properties
		public int Month
		{
			get { return mMonth; }
			set { SetDate(value, Year); }
		}

		public int Year
		{
			get { return mYear; }
			set { SetDate(Month, value); }
		}

		public CalendarDayItemCollection CalendarDayItems
		{
			get
			{

				if (_calendarDayItems == null)
				{
					_calendarDayItems = new CalendarDayItemCollection();

					_calendarDayItems.ObjectAdded += _calendarDayItems_ObjectAdded ;
					_calendarDayItems.ObjectRemoved += _calendarDayItems_ObjectRemoved;

				}

				return _calendarDayItems;
			}
		}

		#endregion

		private void _calendarDayItems_ObjectRemoved(object sender, Cura.Common.CollectionChangeEventArgs args)
		{
			CalendarDayItems.Sort(new CalendarDayItemComparer());

			UpdateCalendar();

		}


		private void _calendarDayItems_ObjectAdded(object sender, Cura.Common.CollectionChangeEventArgs args)
		{
			CalendarDayItems.Sort(new CalendarDayItemComparer());

			UpdateCalendar();
		}


		#region Events

		protected delegate void ResizeDelegate();

		protected bool mResizing = false;

		protected void ResizeCalender()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new ResizeDelegate(ResizeCalender));
				return;
			}

			int xSize = Convert.ToInt32(Math.Floor((double)Panel4.Width / 7));
			int ySize = Convert.ToInt32(Math.Floor((double)Panel4.Height / 6));

			for (int x = 0; x <= 6; x++)
			{
				for (int y = 0; y <= 5; y++)
				{
					CalendarDayCtrls[(y * 7) + x].Width = xSize;
					CalendarDayCtrls[(y * 7) + x].Height = ySize;

					CalendarDayCtrls[(y * 7) + x].Left = xSize * x;
					CalendarDayCtrls[(y * 7) + x].Top = ySize * y;
				}
			}

			sundaylbl.Left = (Panel4.Left + (xSize * 0) + (xSize / 2)) - (sundaylbl.Width / 2);
			mondaylbl.Left = (Panel4.Left + (xSize * 1) + (xSize / 2)) - (mondaylbl.Width / 2);
			tuesdaylbl.Left = (Panel4.Left + (xSize * 2) + (xSize / 2)) - (tuesdaylbl.Width / 2);
			wednesdaylbl.Left = (Panel4.Left + (xSize * 3) + (xSize / 2)) - (wednesdaylbl.Width / 2);
			thursdaylbl.Left = (Panel4.Left + (xSize * 4) + (xSize / 2)) - (thursdaylbl.Width / 2);
			fridaylbl.Left = (Panel4.Left + (xSize * 5) + (xSize / 2)) - (fridaylbl.Width / 2);
			saturdaylbl.Left = (Panel4.Left + (xSize * 6) + (xSize / 2)) - (saturdaylbl.Width / 2);

			monthyearlbl.Left = (Panel1.Left + (Panel1.Width / 2)) - (monthyearlbl.Width / 2);

			prvyearbtn.Left = monthyearlbl.Left - 100;
			prvmonthbtn.Left = monthyearlbl.Left - 50;


			nxtyearbtn.Left = monthyearlbl.Left + monthyearlbl.Width + 100;

			nxtmonthbtn.Left = monthyearlbl.Left + monthyearlbl.Width + 50;

			UpdateCalendar();
		}


		private void CalenderCtrl_Resize(System.Object sender, System.EventArgs e)
		{
			if (StartSize == null)
				return;

			if (mDisableResize)
				return;

			//mResizing = True

			//If mTimer.Enabled Then Exit Sub
			mTimer.Enabled = false;
			mTimer.Enabled = true;

		}

		private void AddCtrl(CalendarDayCtrl ctrl)
		{
			CalendarDayCtrls.Add(ctrl);
			ctrl.DragBegin += dragBegin;
			ctrl.DragEnd += dragEnd;
		}

		private void dragBegin(System.Object sender)
		{
		  //  Console.WriteLine("begindrag");
		}

		private void dragEnd(System.Object sender)
		{
		  //  Console.WriteLine("enddrag");
		}

		private void Button1_MouseEnter(System.Object sender, System.EventArgs e)
		{
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightGray;
		}

		private void Button1_MouseLeave(System.Object sender, System.EventArgs e)
		{
			((System.Windows.Forms.Button)sender).BackColor = System.Drawing.Color.LightSlateGray;
		}

		private void nxtmonthbtn_Click(System.Object sender, System.EventArgs e)
		{
			int m = (Month + 1) > 12 ? 1 : (Month + 1);

			SetDate(m, Year + (m == 1 ? 1 : 0));
		}

		private void prvmonthbtn_Click(System.Object sender, System.EventArgs e)
		{
			int m = (Month - 1) < 1 ? 12 : (Month - 1);

			SetDate(m, Year - (m == 12 ? 1 : 0));
		}

		private void nxtyearbtn_Click(System.Object sender, System.EventArgs e)
		{
			Year += 1;
		}

		private void prvyearbtn_Click(System.Object sender, System.EventArgs e)
		{
			Year -= 1;
		}

		public event ItemSelectedEventHandler ItemSelected;
		public delegate void ItemSelectedEventHandler(object sender, object item);

		private void CalenderDayCtrl1_ItemSelected(System.Object sender, System.Object item)
		{
			if (ItemSelected != null)
			{
				ItemSelected(this, item);
			}

		}

		public void UpdateCalendarDay(DateTime caldaydatetime)
		{
			CalendarDayCtrls[42].Disabled = false;
			CalendarDayCtrls[42].ShowDateNumber = false;
			CalendarDayCtrls[42].Day = caldaydatetime.Day;

			daydatelbl.Text = caldaydatetime.ToString("dd MMMM yyyy");

			CalendarDayCtrls[42].ClearItems();

			foreach (CalendarDayItem item_loopVariable in CalendarDayItems)
			{
			   CalendarDayItem item = item_loopVariable;

				if (item._Date.Month == caldaydatetime.Month & (item.IgnoreYear | item._Date.Year == caldaydatetime.Year) & item._Date.Day == caldaydatetime.Day)
				{
					string ttag = item.ShowTime ? item._Time != null ? item._Time + " " : "" : "" + item.Tag;

					CalendarDayCtrls[42].AddItem(item.Item, item.Color, ttag, false);
				}
			}

			CalendarDayCtrls[42].UpdateDayCtrl();
		}

		private void CalenderCtrl_Load(System.Object sender, System.EventArgs e)
		{
		}

		private void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Panel3.Visible = false;
			Panel2.Visible = true;
		}

		protected bool mDisableResize = true;
		public bool DisableResize
		{
			get { return mDisableResize; }
			set { mDisableResize = value; }
		}

		protected System.Timers.Timer mTimer;
		protected void timerelapsed(Object sender, ElapsedEventArgs e)
		{
			ResizeCalender();
			mTimer.Enabled = false;
		}
		#endregion

		public event DateChangedEventHandler DateChanged;
		public delegate void DateChangedEventHandler(object sender);

		private void SetDate(int month, int year)
		{
			bool change = (month != this.Month | year != this.Year);

			mMonth = month;
			mYear = year;

			if (change)
			{
				if (DateChanged != null)
				{
					DateChanged(this);
				}
			}

			UpdateCalendar();
		}

		public void UpdateCalendar()
		{
		 //   update the calendar text
			DateTime firstofmonth = new DateTime(Year, Month, 1);

			bool isThisMonth = firstofmonth.Year == DateTime.Now.Year & firstofmonth.Month == DateTime.Now.Month;

			monthyearlbl.Text = firstofmonth.ToString("MMMM yyyy");

			if (firstofmonth.DayOfWeek > 0)
			{
				for (int i = 0; i <= Convert.ToInt32(firstofmonth.DayOfWeek); i++)
				{
					CalendarDayCtrls[i].Disabled = true;
				}
			}

			for (int j = 0; j <= (DateTime.DaysInMonth(firstofmonth.Year, firstofmonth.Month) - 1); j++)
			{
			  
				CalendarDayCtrls[j + Convert.ToInt32(firstofmonth.DayOfWeek)].ClearItems();

				CalendarDayCtrls[j + Convert.ToInt32(firstofmonth.DayOfWeek)].Disabled = false;
				CalendarDayCtrls[j + Convert.ToInt32(firstofmonth.DayOfWeek)].Day = j + 1;

				if (isThisMonth)
				{
					//Draw todays day in green
					if (j + 1 == DateTime.Now.Day)
						CalendarDayCtrls[j + Convert.ToInt32(firstofmonth.DayOfWeek)].BackColor = System.Drawing.Color.LightGreen;
				}
				else
				{
					//Otherwise draw the backcolor in white!
					CalendarDayCtrls[j + Convert.ToInt32(firstofmonth.DayOfWeek)].BackColor = System.Drawing.Color.White;
				}

				//Iterate through all the items for the calendar days

				foreach (CalendarDayItem item_loopVariable in CalendarDayItems)
				{
					CalendarDayItem item = item_loopVariable;
					//check whether the item should be added

					if (item._Date.Month == Month & (item.IgnoreYear | item._Date.Year == Year) & item._Date.Day == j + 1)
					{
						string ttag = (item.ShowTime ? (item._Time != null ? item._Time + " " : "") : "") + item.Tag;

						CalendarDayCtrls[j + Convert.ToInt32(firstofmonth.DayOfWeek)].AddItem(item.Item, item.Color, ttag, false);
					}
				}

				CalendarDayCtrls[j + Convert.ToInt32(firstofmonth.DayOfWeek)].UpdateDayCtrl();
			}

			for (int j = DateTime.DaysInMonth(firstofmonth.Year, firstofmonth.Month) + Convert.ToInt32(firstofmonth.DayOfWeek); j <= (CalendarDayCtrls.Count - 1); j++)
			{
				CalendarDayCtrls[j].Disabled = true;
			}

		}

		public CalendarCtrl()
		{
			Resize += CalenderCtrl_Resize;
			Load += CalenderCtrl_Load;


			// This call is required by the designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent() call.
			AddCtrl(CalenderDayCtrl1);
			AddCtrl(CalenderDayCtrl2);
			AddCtrl(CalenderDayCtrl3);
			AddCtrl(CalenderDayCtrl4);
			AddCtrl(CalenderDayCtrl5);
			AddCtrl(CalenderDayCtrl6);
			AddCtrl(CalenderDayCtrl7);
			AddCtrl(CalenderDayCtrl8);
			AddCtrl(CalenderDayCtrl9);
			AddCtrl(CalenderDayCtrl10);
			AddCtrl(CalenderDayCtrl11);
			AddCtrl(CalenderDayCtrl12);
			AddCtrl(CalenderDayCtrl13);
			AddCtrl(CalenderDayCtrl14);
			AddCtrl(CalenderDayCtrl15);
			AddCtrl(CalenderDayCtrl16);
			AddCtrl(CalenderDayCtrl17);
			AddCtrl(CalenderDayCtrl18);
			AddCtrl(CalenderDayCtrl19);
			AddCtrl(CalenderDayCtrl20);
			AddCtrl(CalenderDayCtrl21);
			AddCtrl(CalenderDayCtrl22);
			AddCtrl(CalenderDayCtrl23);
			AddCtrl(CalenderDayCtrl24);
			AddCtrl(CalenderDayCtrl25);
			AddCtrl(CalenderDayCtrl26);
			AddCtrl(CalenderDayCtrl27);
			AddCtrl(CalenderDayCtrl28);
			AddCtrl(CalenderDayCtrl29);
			AddCtrl(CalenderDayCtrl30);
			AddCtrl(CalenderDayCtrl31);
			AddCtrl(CalenderDayCtrl32);
			AddCtrl(CalenderDayCtrl33);
			AddCtrl(CalenderDayCtrl34);
			AddCtrl(CalenderDayCtrl35);
			AddCtrl(CalenderDayCtrl36);
			AddCtrl(CalenderDayCtrl37);
			AddCtrl(CalenderDayCtrl38);
			AddCtrl(CalenderDayCtrl39);
			AddCtrl(CalenderDayCtrl40);
			AddCtrl(CalenderDayCtrl41);
			AddCtrl(CalenderDayCtrl42);
			AddCtrl(CalenderDayCtrl43);


			CalenderDayCtrl1.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl1.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl2.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl3.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl4.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl5.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl6.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl7.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl8.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl9.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl10.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl11.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl12.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl13.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl14.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl15.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl16.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl17.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl18.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl19.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl20.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl21.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl22.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl23.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl24.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl25.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl26.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl27.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl28.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl29.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl30.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl31.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl32.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl33.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl34.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl35.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl36.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl37.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl38.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl39.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl40.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl41.DaySelected += CalenderDayCtrl1_DaySelected;
			CalenderDayCtrl42.DaySelected += CalenderDayCtrl1_DaySelected;

			mMonth = DateTime.Now.Month;
			mYear = DateTime.Now.Year;

			StartSize = this.Size;

			mTimer = new System.Timers.Timer();
			mTimer.Interval = 150;
			mTimer.Elapsed += timerelapsed;
		}

		private void CalenderDayCtrl1_DaySelected(Object sender) 
		{
		   Panel2.Visible = false;
		   Panel3.Visible = true;

		   UpdateCalendarDay(new DateTime(Year, Month, (sender as CalendarDayCtrl).Day));
		}

		public System.Collections.Generic.IEnumerator<CalendarDayItem> GetEnumerator()
		{
			List<CalendarDayItem> list = new List<CalendarDayItem>();

			return list.GetEnumerator();
		}

		System.Collections.IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}


	}
}
