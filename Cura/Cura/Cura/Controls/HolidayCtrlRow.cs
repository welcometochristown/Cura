using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cura.Controls
{
    public partial class HolidayCtrlRow : UserControl
    {
        #region Fields
        private int _days;
        private DateTime _startDate;
        private IEnumerable<Worker> _workers;
        private List<PoolItem> panelPool;

        #endregion

        #region Constructor
        public HolidayCtrlRow()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.panelPool = new List<PoolItem>();
        }
        #endregion

        #region Properties

        public int days
        {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
            }
        }

       
        public DateTime StartDate 
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

      
        public IEnumerable<Worker> Workers
        {
            get
            {
                return _workers;
            }
            set
            {
                if (value == null)
                    return;

                _workers = value.OrderBy(w => w.surname);

            }
        }

        #endregion



        /// <summary>
        /// Redraw The Days And Items
        /// </summary>
        public void RedrawDays()
        {

            Controls.Clear();

            Panel allPanel = new Panel() { Dock = DockStyle.Fill, AutoScroll = true };

            int x = 250;

            int poolItemIndex = 0;

            if (StartDate == DateTime.MinValue)
                return;

            if (Workers != null)
            {
             
                int index = 2;
                foreach (Worker worker in Workers)
                {
                    PoolItem panel_workername = null;

                    if (panelPool.Count > poolItemIndex)
                    {
                        panel_workername = panelPool[poolItemIndex];
                    }
                    else
                    {
                        panel_workername = new PoolItem();
                        panelPool.Add(panel_workername);
                    }

                    panel_workername.Text = worker.Name;
                    panel_workername.BackCol = Color.White;
                    panel_workername.ForeCol = Color.Black;

                    poolItemIndex++;

                    allPanel.Controls.Add(panel_workername);

                    panel_workername.Size = new Size(x, 25);
                    panel_workername.Location = new Point(0, index * 25);

                    index++;
                }
            }
                   
            for (int i = 0; i < days; i++)
            {
                DateTime currentdate = StartDate.AddDays(i);

                ////Do the day name

                PoolItem panel_name = null;

                if (panelPool.Count > poolItemIndex)
                {
                    panel_name = panelPool[poolItemIndex];
                }
                else
                {
                    panel_name = new PoolItem();
                    panelPool.Add(panel_name);
                }

                allPanel.Controls.Add(panel_name);

                panel_name.Text = currentdate.DayOfWeek.ToString().Substring(0, 1);
                panel_name.BackCol = currentdate.DayOfWeek == DayOfWeek.Saturday || currentdate.DayOfWeek == DayOfWeek.Sunday ? Color.LightGray : Color.LightBlue;
                panel_name.ForeCol = Color.Black;
                panel_name.Size = new Size(25, 25);
                panel_name.Location = new Point(x+(i * 25) - i, 0);

                poolItemIndex++;

                //Now the day number

                PoolItem panel_no = null;

                if (panelPool.Count > poolItemIndex)
                {
                    panel_no = panelPool[poolItemIndex];
                }
                else
                {
                    panel_no = new PoolItem();
                    panelPool.Add(panel_no);
                }

                allPanel.Controls.Add(panel_no);

                panel_no.Text = currentdate.Day.ToString().PadLeft(1, '0');
                panel_no.BackCol = currentdate.DayOfWeek == DayOfWeek.Saturday || currentdate.DayOfWeek == DayOfWeek.Sunday ? Color.LightGray : Color.LightBlue;
                panel_no.ForeCol = Color.Black;
                panel_no.Size = new Size(25, 25);
                panel_no.Location = new Point(x + (i * 25) - i, 25);

                poolItemIndex++;


                if (Workers == null)
                    continue;

                int w_index = 0;
                foreach (Worker worker in Workers)
                {

                    Color col = Color.White;
                    string txt = "";
             
                    //check if day off
                    if( worker.isDayOff(currentdate))
                    {
                        col = Color.FromArgb(247, 216, 66);
                        txt = "D";
                    }else if(worker.Holidays.ContainsDate(currentdate))
                    {
                        col = Color.FromArgb(44, 168, 194);
                        txt = "H";
                    }else if(worker.SickDays.ContainsDate(currentdate))
                    {
                        col = Color.FromArgb(241,95,116);
                        txt = "S";
                    }else if(worker.Training.ContainsDate(currentdate))
                    {
                        col = Color.FromArgb(152, 203, 74);
                        txt = "T";
                    }

   
                    //Now the day info
                    //Panel panel_worker = new Panel() { BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle };

                    //panel_worker.Controls.Add(new Label()
                    //{
                    //    BackColor = col != Color.White ? col : (currentdate.DayOfWeek == DayOfWeek.Saturday || currentdate.DayOfWeek == DayOfWeek.Sunday ? Color.FromArgb(234,234,234) : Color.White), 
                    //    ForeColor = Color.Black,
                    //    TextAlign = ContentAlignment.MiddleCenter,
                    //    Text = txt,
                    //    AutoSize = false,
                    //    Dock = DockStyle.Fill
                    //});

                    //allPanel.Controls.Add(panel_worker);

                    //panel_worker.Size = new Size(25, 25);
                    //panel_worker.Location = new Point(x+(i * 25) - i, 50 + (w_index * 25));

                    PoolItem panel_worker = null;

                    if (panelPool.Count > poolItemIndex)
                    {
                        panel_worker = panelPool[poolItemIndex];
                    }
                    else
                    {
                        panel_worker = new PoolItem();
                        panelPool.Add(panel_worker);
                    }

                    allPanel.Controls.Add(panel_worker);

                    panel_worker.Text = txt;
                    panel_worker.BackCol = col != Color.White ? col : (currentdate.DayOfWeek == DayOfWeek.Saturday || currentdate.DayOfWeek == DayOfWeek.Sunday ? Color.FromArgb(234, 234, 234) : Color.White);
                    panel_worker.ForeCol = Color.Black;
                    panel_worker.Size = new Size(25, 25);
                    panel_worker.Location = new Point(x + (i * 25) - i, 50 + (w_index * 25));

                    poolItemIndex++;



                    w_index++;
                }
            }

            Controls.Add(allPanel);

        }

    }

    public class PoolItem : Panel
    {
        public Label label;

        public string Text
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }

        public Color BackCol
        {
            get
            {
                return label.BackColor;
            }
            set
            {
                label.BackColor = value;
            }
        }

        public Color ForeCol
        {
            get
            {
                return label.ForeColor;
            }
            set
            {
                label.ForeColor = value;
            }
        }
        public PoolItem()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           label = new Label()
                {
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.MiddleLeft ,
                    Text = "",
                    AutoSize = false,
                    Dock = DockStyle.Fill
                };

             Controls.Add(label);

        }
    }
}
