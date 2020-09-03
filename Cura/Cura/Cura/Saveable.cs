using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura
{
    public class Saveable
    {
        #region Fields
        protected bool _MarkForSave;
        #endregion

        public delegate void SaveableChangedEvent(object sender, bool oldValue, bool newValue);
        public delegate void SaveableChangingEvent(object sender, bool oldValue, bool newValue, out bool cancel);

        public event SaveableChangedEvent SaveMarkerChanged;
        public event SaveableChangingEvent SaveMarkerChanging;

        #region Properties
        public bool MarkForSave
        {
            get
            {
                return _MarkForSave;
            }
            set
            {
                bool cancel = false;
                bool oldVal = _MarkForSave;

                if (SaveMarkerChanging != null)
                    SaveMarkerChanging(this, oldVal, value, out cancel);

                if (cancel)
                    return;

                _MarkForSave = value;

                if (SaveMarkerChanged != null)
                    SaveMarkerChanged(this, oldVal, value);
            }
        }
        #endregion
   

        public Saveable()
        {
            this.MarkForSave = false;
        }

        public virtual void Save()
        {
            /*override to save*/
        }
    }

}
