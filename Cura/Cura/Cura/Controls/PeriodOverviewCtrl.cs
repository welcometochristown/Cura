using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Cura.Controls
{
    public partial class PeriodOverviewCtrl : UserControl
    {

        /// <summary>
        /// Class for a report
        /// </summary>
        private class Report
        {
            public string Measure;
            public string Name;

            public Report(string measure, string name)
            {
                this.Measure = measure;
                this.Name = name;
            }
        }

        #region Fields

        //int calls_total, calls_assigned;
        //int morn_calls, lunch_calls, tea_calls, evening_calls;
        //int solo_worker_calls, dual_worker_calls;
        //int worker_holidays, worker_sickdays;
        //int drivers;
        //int withkeyserv, withkeywork;
        //int age0, age1, age2;

        DateTime _PeriodStartDate;
        private List<Report> _reports = new List<Report>();
        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime PeriodStartDate
        {
            get
            {
                return _PeriodStartDate;
            }
            set
            {
                if (_PeriodStartDate == value)
                    return;

                _PeriodStartDate = value;

                RefreshReport();
            }
        }

        #endregion

        #region Constructor
        public PeriodOverviewCtrl()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load

        private void PeriodOverviewCtrl_Load(object sender, EventArgs e)
        {
            BuildReportList();

            PopulateMeasureCombo();
            PopulateReportCombo();
            PopulateReportyTypeCombo();

            UpdateControls();
        }
        #endregion

        #region Events
        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReportList();

        }

        private void reportCmbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void reportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void exportOutBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = "CuraReport_" + DateTime.Now.ToString("ddMMyy_HHmss");
            dlg.Filter = "Excel files (*.csv)|*.csv|All files (*.*)|*.*";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(dlg.FileName);
             
                ValueData data = GetReportData();

                writer.WriteLine(reportCmbo.Text);
                writer.WriteLine();
                writer.WriteLine("Period Starting :, " + PeriodStartDate.ToString("dd/MM/yyyy"));

                IEnumerable<string> headers = data.valuesets.Select(v => v.Name).Distinct();

                string header = "Date";
                foreach (string h in headers)
                    header += "," + h;

                writer.WriteLine(header);

                for (int i = 0; i < data.weeks.Count; i++ )
                {
                    string line = data.weeks[i].ToString();

                    foreach (string h in headers)
                    {
                        line += "," + data.valuesets.Single(v => v.Name == h).values[i];
                    }

                    writer.WriteLine(line);
                }

                writer.Close();

                if (MessageBox.Show("Would you like to view this file now?", "Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(dlg.FileName);
                }

            }
            catch (Exception ex)
            {
                //(ex.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Builds the report list.
        /// </summary>
        private void BuildReportList()
        {
            _reports.Clear();
            _reports.Add(new Report("Calls", "Call Count"));
            _reports.Add(new Report("Calls", "Call Duration"));
            _reports.Add(new Report("Calls", "Avg Call Duration"));
            _reports.Add(new Report("Calls", "Required Workers Call Count"));
        }

        /// <summary>
        /// Populates the type combo.
        /// </summary>
        private void PopulateMeasureCombo()
        {
            typeCombo.Items.Clear();
            typeCombo.Items.Add("<Select Report Type>");
          
            foreach(string measure in _reports.Select(r => r.Measure).Distinct())
                typeCombo.Items.Add(measure);

            typeCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// Populates the report combo.
        /// </summary>
        private void PopulateReportCombo()
        {
            reportCmbo.Items.Clear();
            reportCmbo.Items.Add("<Select Report>");

            if (typeCombo.SelectedIndex != 0)
            {
                foreach(string report in _reports.Where(r => r.Measure == typeCombo.Text).Select(r => r.Name))
                    reportCmbo.Items.Add(report);
            }

            reportCmbo.SelectedIndex = 0;
        }

        /// <summary>
        /// Populates the reporty type combo.
        /// </summary>
        private void PopulateReportyTypeCombo()
        {
            reportType.Items.Clear();
            reportType.Items.Add("Basic");
            reportType.Items.Add("Stacked");

            reportType.SelectedIndex = 0;
        }

        /// <summary>
        /// Refreshes the report list.
        /// </summary>
        private void RefreshReportList()
        {
            //populate combo here
            PopulateReportCombo();

            //select index 0
            reportCmbo.SelectedIndex = 0;

            UpdateControls();
        }

        /// <summary>
        /// struct to store value data about a report
        /// </summary>
        public class ValueData
        {
            public List<DateTime> weeks;
            public List<ValueSet> valuesets;
        }

        /// <summary>
        /// struct to store value set information
        /// </summary>
        public struct ValueSet
        {
           public string Name;
           public double[] values;
           public Color color;
        }

        /// <summary>
        /// Builds the date report.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="dates">The dates.</param>
        /// <param name="values">The values.</param>
        private void BuildDateReport(GraphPane myPane, DateTime start, int step, DateTime end, IEnumerable<DateTime> dates, List<ValueSet> valueList)
        {
            myPane.BarSettings.Type = BarType.Cluster;

            if (reportType.Text == "Stacked")
                myPane.BarSettings.Type = BarType.Stack;

            List<double> XDates = new List<double>();
            foreach (DateTime date in dates)
                XDates.Add(new XDate(date));

            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.FontSpec.Size = 8.0f;
            myPane.XAxis.Title.Text = "Date";
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "dd-MMM-yy";
            myPane.XAxis.Scale.MajorUnit = DateUnit.Day;
            myPane.XAxis.Scale.MajorStep = step;
            myPane.XAxis.Scale.Min = new XDate(start);
            myPane.XAxis.Scale.Max = new XDate(end);
            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            myPane.XAxis.MinorTic.Size = 0;
            myPane.XAxis.MajorTic.IsInside = false;
            myPane.XAxis.MajorTic.IsOutside = true;

            foreach (ValueSet values in valueList)
            {
             BarItem bar = myPane.AddBar(values.Name, XDates.ToArray(), values.values, values.color);
             bar.Label.FontSpec = new FontSpec(zedGraphControl1.Font.FontFamily.Name, 08.0f, Color.Black, false, true, false);
             bar.Label.FontSpec.Border.IsVisible = false;
            
            }
        }

        /// <summary>
        /// Gets the report data.
        /// </summary>
        /// <returns></returns>
        private ValueData GetReportData()
        {
            switch (typeCombo.Text)
            {
                case "Calls":
                    {

                        List<DateTime> Weeks = new List<DateTime>();

                        for (int i = 0; i < Settings.Instance.rotaweekcount; i++)
                            Weeks.Add(PeriodStartDate.AddDays(7 * i));

                        List<double> SingleWorker = new List<double>();
                        List<double> DoubleWorker = new List<double>();
                        List<double> Covered = new List<double>();
                        List<double> UnCovered = new List<double>();
                        List<double> Duration = new List<double>();

                        foreach (DateTime week in Weeks)
                        {
                            IEnumerable<Call> calls = CallManager.Instance.Calls.Where(c => c.TimeFrom >= week && c.TimeFrom < week.AddDays(7 + 1));

                            Covered.Add(calls.Where(c => c.HasFullWorkers).Count());
                            UnCovered.Add(calls.Where(c => !c.HasFullWorkers).Count());
                            Duration.Add(calls.Select(c => c.duration_mins).Sum());
                            SingleWorker.Add(calls.Where(c => c.required_workers == 1).Count());
                            DoubleWorker.Add(calls.Where(c => c.required_workers == 2).Count());
                        }

                        List<ValueSet> valuelist = new List<ValueSet>();

                        Color color_pink = Color.FromArgb(247,224,224);
                        Color color_white = Color.White;
                        Color color_blue = Color.FromArgb(222,230,244);
                        Color color_green= Color.FromArgb(222, 244, 224);

                        switch (reportCmbo.Text)
                        {
                            case "Call Count":
                                {
                                    valuelist.Add(new ValueSet { Name = "Covered", values = Covered.ToArray(), color = color_pink });
                                    valuelist.Add(new ValueSet { Name = "UnCovered", values = UnCovered.ToArray(), color = color_white });
                                    break;
                                }
                            case "Call Duration":
                                {
                                    valuelist.Add(new ValueSet { Name = "Total Duration", values = Duration.ToArray(), color = color_pink });
                                    break;
                                }
                            case "Avg Call Duration":
                                {
                                    List<double> AvgTimesCovered = new List<double>();
                                    List<double> AvgTimesUnCovered = new List<double>();

                                    for (int i = 0; i < Weeks.Count; i++)
                                    {
                                        AvgTimesCovered.Add(Duration[i] / Covered[i]);
                                        AvgTimesUnCovered.Add(Duration[i] / UnCovered[i]);
                                    }

                                    valuelist.Add(new ValueSet { Name = "Avg Duration Covered", values = AvgTimesCovered.ToArray(), color = color_pink });
                                    valuelist.Add(new ValueSet { Name = "Avg Duration Uncovered", values = AvgTimesUnCovered.ToArray(), color = color_white });

                                    break;
                                }
                            case "Required Workers Call Count":
                                {
                                    valuelist.Add(new ValueSet { Name = "Single Worker", values = SingleWorker.ToArray(), color = color_blue });
                                    valuelist.Add(new ValueSet { Name = "Double Worker", values = DoubleWorker.ToArray(), color = color_green });
                                
                                    break;
                                }

                        }

                        return new ValueData() { weeks = Weeks, valuesets = valuelist };
                    }
            }

            return null;
            
        }


        /// <summary>
        /// Refreshes the report.
        /// </summary>
        private void RefreshReport()
        {
            //refresh report data here
            GraphPane myPane = zedGraphControl1.GraphPane;

            //clear everything
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            //set the title
            myPane.Title.Text = reportCmbo.Text;

            myPane.XAxis.Title.FontSpec = new FontSpec(zedGraphControl1.Font.FontFamily.Name, 08.0f, Color.Black, true, false, false);
            myPane.XAxis.Title.FontSpec.Border.IsVisible = false;
    
            myPane.YAxis.Title.FontSpec = new FontSpec(zedGraphControl1.Font.FontFamily.Name, 08.0f, Color.Black, true, false, false);
            myPane.YAxis.Title.FontSpec.Border.IsVisible = false;
            myPane.YAxis.Scale.Min = 0;

            switch (typeCombo.Text)
            {
                case "Calls":
                    {
                        switch (reportCmbo.Text)
                        {
                            case "Call Count":
                            case "Required Workers Count":
                                {
                                    myPane.YAxis.Title.Text = "Count";
                                    break;
                                }
                            case "Call Duration":
                            case "Avg Call Duration":
                                {
                                    myPane.YAxis.Title.Text = "Duration (mins)";
                                    break;
                                }
                        }

                        //get the report data
                        ValueData data = GetReportData();

                        //build the date report
                        BuildDateReport(myPane,
                            PeriodStartDate.AddDays(-7),
                            7,
                            PeriodStartDate.AddDays(7 * Settings.Instance.rotaweekcount).AddDays(7),
                            data.weeks,
                            data.valuesets );

                        break;
                    }
            }
           
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            UpdateControls();
        }


        /// <summary>
        /// Updates the controls.
        /// </summary>
        private void UpdateControls()
        {
            reportCmbo.Enabled = typeCombo.SelectedIndex != 0;

            splitContainer1.Panel1Collapsed = reportCmbo.SelectedIndex != 0;
            splitContainer1.Panel2Collapsed = reportCmbo.SelectedIndex == 0;

            exportOutBtn.Enabled = reportCmbo.SelectedIndex != 0;
        }

 
        /// <summary>
        /// Refresh the display data
        /// </summary>
        public void RefreshData()
        {
            /*
            #region Calls

                calls_total = CallManager.Instance.Calls.Count();
                calls_assigned = CallManager.Instance.AssignedCalls.Count();

                totalCallsTxt.Text = calls_total.ToString();
                assignedCallstxt.Text = calls_assigned.ToString();
                unassignedcallstxt.Text = (calls_total - calls_assigned).ToString();

                morn_calls = CallManager.Instance.Calls.Where(c => c.CallTimeZone == Call.Timezone.Morning).Count();
                lunch_calls = CallManager.Instance.Calls.Where(c => c.CallTimeZone == Call.Timezone.Lunch).Count();
                tea_calls = CallManager.Instance.Calls.Where(c => c.CallTimeZone == Call.Timezone.Tea).Count();
                evening_calls = CallManager.Instance.Calls.Where(c => c.CallTimeZone == Call.Timezone.Evening).Count();

                morningcallsTxt.Text = morn_calls.ToString();
                lunchcallsTxt.Text = lunch_calls.ToString();
                teacallsTxt.Text = tea_calls.ToString();
                eveningcallsTxt.Text = evening_calls.ToString();

                solo_worker_calls = CallManager.Instance.Calls.Where(c => c.required_workers == 1).Count();
                dual_worker_calls = CallManager.Instance.Calls.Where(c => c.required_workers == 2).Count();

                soloworkerTxt.Text = solo_worker_calls.ToString();
                dualWorkerTxt.Text = dual_worker_calls.ToString();

                worker_holidays = 0;
                foreach (Worker worker in WorkerManager.Instance.ActiveWorkers)
                    worker_holidays += worker.Holidays.Count();
            
                worker_sickdays = 0;
                foreach (Worker worker in WorkerManager.Instance.ActiveWorkers)
                   worker_sickdays += worker.SickDays.Count();

                sickdayTxt.Text = worker_sickdays.ToString();
                holidayTxt.Text = worker_holidays.ToString();
            
    #endregion
  
            #region Workers
                drivers = WorkerManager.Instance.ActiveWorkers.Where(w => w.isDriver).Count();
                withkeyserv = WorkerManager.Instance.ActiveWorkers.Where(w => w.KeyServiceUsers.Count() != 0).Count();

                driversTxt.Text = drivers.ToString();
                withkeyservTxt.Text = withkeyserv.ToString();

                int travelMins = 0;

                foreach (Worker worker in WorkerManager.Instance.ActiveWorkers)
                {
                    foreach (Call call in worker.Calls.Where(c => c.traveltime_mins > 0))
                    {
                        travelMins += call.traveltime_mins;
                    }
                }

                TimeSpan travelTime = new TimeSpan(0, travelMins, 0);

                travelTimeTxt.Text = (travelTime.Hours > 0 ? travelTime.Hours.ToString() + "h": "") + travelMins.ToString() + "m";
    #endregion
  
            #region Service Users

                withkeywork = ServiceUserManager.Instance.ServiceUsers.Where(s => s.KeyWorkers.Count() != 0).Count();

                withkeyworkTxt.Text = withkeywork.ToString();

                age0 = ServiceUserManager.Instance.ServiceUsers.Where(s => s.Age <= 40 ).Count();
                age1 = ServiceUserManager.Instance.ServiceUsers.Where(s => s.Age >40 && s.Age <= 60).Count();
                age2 = ServiceUserManager.Instance.ServiceUsers.Where(s => s.Age >60).Count();

                age0Txt.Text = age0.ToString();
                age1Txt.Text = age1.ToString();
                age2Txt.Text = age2.ToString();
    #endregion
                */
        }

        /// <summary>
        /// Export Period Overview data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportbtn_Click(object sender, EventArgs e)
        {
            /*
                   SaveFileDialog dlg = new SaveFileDialog();
            
                   dlg.FileName = "CuraOverview_" + DateTime.Now.ToString("dd-MM-yy");
                   dlg.Filter = "Excel files (*.csv)|*.csv|All files (*.*)|*.*";

                   if (dlg.ShowDialog() != DialogResult.OK)
                       return;

                   try
                   {
                       System.IO.StreamWriter writer = new System.IO.StreamWriter(dlg.FileName);

                       writer.WriteLine("Period Starting :, " + PeriodStartDate.ToString("dd/MM/yyyy") + ", [Over " + Settings.Instance.rotaweekcount.ToString() + " Weeks ]");

                       writer.WriteLine("Total Calls," + calls_total.ToString());
                       writer.WriteLine("Calls Assigned," + calls_assigned.ToString());
             
                       writer.WriteLine("Morning Calls," + morn_calls);
                       writer.WriteLine("Lunch Calls," + lunch_calls);
                       writer.WriteLine("Tea Calls," + tea_calls);
                       writer.WriteLine("Evening Calls," + evening_calls);

                       writer.WriteLine("Solo Worker Calls," + solo_worker_calls);
                       writer.WriteLine("Dual Worker Calls," + dual_worker_calls);

                       writer.WriteLine("Worker Holidays," + worker_holidays);
                       writer.WriteLine("Worker Sickdays," + worker_sickdays);

                       writer.WriteLine("Drivers," + drivers);

                       writer.WriteLine("Workers With Key Service Users," + withkeyserv);
                       writer.WriteLine("Service Users With Key Workers," + withkeywork);
                
                       writer.Close();

                       if (MessageBox.Show("Would you like to view this file now?", "Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
                       {
                           System.Diagnostics.Process.Start(dlg.FileName);
                       }
                   }
                   catch (Exception ex)
                   {
                       //(ex.ToString());
                   }
       */
        }

        /// <summary>
        /// export period call data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void periodcallsrpt_Click(object sender, EventArgs e)
        {
            /*
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = "CuraCallReport_" + DateTime.Now.ToString("dd-MM-yy");
            dlg.Filter = "Excel files (*.csv)|*.csv|All files (*.*)|*.*";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(dlg.FileName);

                writer.WriteLine("Period Starting :, " + PeriodStartDate.ToString("dd/MM/yyyy"));

                writer.WriteLine("ServiceUser, P-Number, Call DateTime, Duration(mins), Fully Covered, Covered By, Travel Time, Notes, Flag");

                foreach (Call call in CallManager.Instance.Calls.OrderBy(c => c.ServiceUserName))
                {
                    writer.WriteLine(call.ServiceUserName + "," + call.ServiceUser.PNumber + "," + call.time.ToString() + "," + call.duration_mins.ToString() + "," + call.HasFullWorkers.ToString() + "," + call.CoveredBy + "," + call.traveltime_mins + "," + call.notes + "," + call.flag.ToString());
                }
       
                writer.Close();

                if (MessageBox.Show("Would you like to view this file now?", "Open", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                //(ex.ToString());
            }
             */
        }

   


    }
}
