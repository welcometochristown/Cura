using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura
{
     public class AbsenceCollection : Cura.Common.Collection<Absence>
     {
        #region Fields
        private bool _flattening;
        #endregion

        #region Constructor
        public AbsenceCollection()
        {
            this.ObjectAdded += AbsenceCollection_ObjectAdded;
        }
        #endregion
     
        private void AbsenceCollection_ObjectAdded(object sender, Cura.Common.CollectionChangeEventArgs args)
        {
            while (ResolveConflicts() != 0)
            {/*keep resolving till clean */}

            FlattenDays();
        }

        public void AddTime(DateTime date, int minutes)
        {
            Add(new Absence() { DateStart = date.Date, Duration = minutes });
        }

        public void AddDay(DateTime date)
        {
            Add(new Absence() { DateStart = date.Date, DaysCount = 1 });
        }

        public void RemoveAbsence(Absence absence)
        {
            RemoveTime(absence.DateStart, absence.Duration);
        }


        public void RemoveDays(DateTime date, int count)
        {
            if (Count == 0)
                return;

            for (int i = 0; i < count; i++ )
            {
                RemoveDay(date.Date);
                date = date.AddDays(1);
            }
            
        }

        public void RemoveDay(DateTime date)
        {
            RemoveTime(date, (60 * 24));
        }

        public void RemoveTime(DateTime date, int minutes)
        {
            if (Count == 0)
                return;

             /*?umm?*/
            //find where it is,
            //if its at the start then just move start day and -1 day 
            //if its at the end of an absence then just -1
            //if its in the middle then its a little more complicated and we are going to have to divide
            // an absence into two ending the day before and starting the day after!

            Absence absToRemove = new Absence() { DateStart = date, Duration = minutes };

            Conflict []conflicts = Conflicts(absToRemove);

            if (conflicts.Length == 0)    //no conflict
                return;

            foreach (Conflict conflict in conflicts)
            {
                switch (conflict.result)
                {
                    case ConflictResult.Left:
                        {
                            /*
                               *                 -- conflictor ---
                               *    ==============-----------------------------------
                               *                 =                                  |
                               *       abs2rem   =                                  |
                               *                 =                                  |
                               *    ==============-----------------------------------
                               * 
                            */

                            conflict.conflictor.DateStart = absToRemove.DateEnd;
                            break;
                        }
                    case ConflictResult.Right:
                        {
                            /*
                             *                    -- conflictor ---
                             * --------------------------------===================
                             * |                               =              
                             * |                               =    abc2rem         
                             * |                               =             
                             * --------------------------------===================
                             * * 
                          */
                            conflict.conflictor.DateEnd = absToRemove.DateStart;
                            break;
                        }
                    case ConflictResult.InnerOrFull:
                        {
                            //its inside the conflictor so do fancyness
                            /*
                                *                              -- conflictor ---
                                * --------------------------------------------------------------------------------------
                                * |                                |       |                                           |
                                * |             absence_left       |  abs  |         absence_right                     |
                                * |                                |  2rem |                                           |
                                * --------------------------------------------------------------------------------------
                                * 
                                */

                            Absence absence_left = new Absence() { Reason = conflict.conflictor.Reason, DateStart = conflict.conflictor.DateStart, DateEnd = absToRemove.DateStart };
                            Absence absence_right = new Absence() { Reason = conflict.conflictor.Reason, DateStart = absToRemove.DateEnd, DateEnd = conflict.conflictor.DateEnd };

                            this.Remove(conflict.conflictor);

                            this.AddRange(new Absence[2] { absence_left, absence_right });

                            break;
                        }
                    case ConflictResult.Outer:
                        {
                            //it is an exact match for the conflictor so just remove it
                            this.Remove(conflict.conflictor);

                            break;
                        }
                }
            }

        }


        /// <summary>
        /// Check whether this collection contains an absence on this date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool ContainsDate(DateTime date)
        {
            foreach(Absence absence in this)
            {
                if (absence.DateStart <= date && absence.DateEnd >= date)
                {
                    return true;
                }
            }
            return false;
        }

        public struct Conflict
        {
            public Absence conflictor;
            public ConflictResult result;
        }

        public enum ConflictResult
        {
            InnerOrFull= 0,
            Left = 1,
            Right = -1,
            Outer = 2,
            None = 3
        }

        public Conflict[] Conflicts(Absence absenceObj)
        {
            List<Conflict> conflicts = new List<Conflict>();

            foreach (Absence absence in this)
            {
                if (absence == absenceObj)
                    continue;
               
                if (absenceObj.DateStart >= absence.DateStart && absenceObj.DateEnd <= absence.DateEnd)
                    conflicts.Add( new Conflict() { conflictor = absence, result = ConflictResult.InnerOrFull }); 

                if (absenceObj.DateStart < absence.DateStart && absenceObj.DateEnd > absence.DateEnd)
                    conflicts.Add( new Conflict() { conflictor = absence, result = ConflictResult.Outer });

                if (absenceObj.DateStart < absence.DateStart && (absenceObj.DateEnd > absence.DateStart && absenceObj.DateEnd <= absence.DateEnd))
                    conflicts.Add( new Conflict() { conflictor = absence, result = ConflictResult.Left }); 

                if ( (absenceObj.DateStart >= absence.DateStart && absenceObj.DateStart < absence.DateEnd) && absenceObj.DateEnd > absence.DateEnd)
                    conflicts.Add( new Conflict() { conflictor = absence, result = ConflictResult.Right });  
                
            }

            return conflicts.ToArray();
        }


        public int ResolveConflicts()
        {
            if (this.Count < 2)
                return 0;

            int resolved = 0;

            //iterate over each absence in this collection
            for(int i =this.Count - 1; i>= 0; i--)
            {
                //get the next absence
                Absence absence = this[i];

                //check for conflicts
                Conflict [] conflictresults = Conflicts(absence);

                if (conflictresults.Length == 0)
                    continue;

                //iterate over each conflict
                foreach (Conflict conflictresult in conflictresults)
                {


                    switch (conflictresult.result)
                    {
                        case ConflictResult.None:
                            {
                                continue;
                            }
                        case ConflictResult.InnerOrFull:
                            {
                                //just remove this instance;
                                break;
                            }
                        case ConflictResult.Left:
                            {
                                conflictresult.conflictor.DateStart = absence.DateStart;
                                break;
                            }
                        case ConflictResult.Right:
                            {
                                conflictresult.conflictor.DateEnd = absence.DateEnd;
                                break;
                            }
                        case ConflictResult.Outer:
                            {
                                conflictresult.conflictor.DateStart = absence.DateStart;
                                conflictresult.conflictor.DateEnd = absence.DateEnd;
                                break;
                            }
                    }


                }
                resolved += 1;

                //it must have conflicted, so remove it now that it has been appended to the conflictor
                Remove(absence);

            }

            return resolved;
        }

        public void FlattenDays()
        {
            if (_flattening || this.Count < 2)
                return;

            _flattening = true;

            this.Sort((x, y) => x.DateStart.CompareTo(y.DateStart));

            //basically here just look for days that lead on from one another and create one from two
            for (int i = this.Count() - 1; i > 0; i--)
            {
                Absence absCur = this[i];
                Absence absPre = this[i - 1];

                if (absPre.DateEnd == absCur.DateStart)
                {
                    //fix it
                    absPre.DateEnd = absCur.DateEnd;
                    this.Remove(absCur);
                }
            }

            _flattening = false;
        }
    }
}
