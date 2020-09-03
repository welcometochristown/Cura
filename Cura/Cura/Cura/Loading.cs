using Cura.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cura
{
    class Loading
    {
        #region Fields
        private int _value;
        private int _maxvalue;
        #endregion

        #region Singleton Stuff
        private static Loading instance;

        public static Loading Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Loading();
                }
                return instance;
            }
        }
        #endregion

        System.Threading.Thread thread;
        LoadingFrm frm;

        public void Start(int maxval = 100)
        {
            if (thread != null)
                return;

            _value = 0;
            _maxvalue = maxval;

            frm = new LoadingFrm()
            {
                MaxValue = _maxvalue,
                Value = _value
            };

            thread = new System.Threading.Thread(_threadFunc);
            thread.Start(frm);
        }

        private void _threadFunc(object obj)
        {
            LoadingFrm frm = obj as LoadingFrm;
            frm.ShowDialog();
        }

        public delegate void StopDelegate();
        public void Stop()
        {
            if (thread == null)
                return;

            if (frm.InvokeRequired)
            {
                frm.Invoke(new StopDelegate(Stop));
                return;
            }

            frm.Close();
            thread = null;
        }

        #region Value
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                SetValue(value);
            }
        }

        public delegate void SetValueDelegate(int val);
        private void SetValue(int val)
        {
            if (frm.InvokeRequired)
            {
                frm.Invoke(new SetValueDelegate(SetValue), val);
                return;
            }

            frm.Value = val;
        }
        #endregion

        #region MaxValue
        public int MaxValue
        {
            set
            {
                _maxvalue = value;
                SetMaxValue(value);
            }
        }

        public delegate void SetMaxValueDelegate(int val);
        private void SetMaxValue(int val)
        {
            if (frm.InvokeRequired)
            {
                frm.Invoke(new SetMaxValueDelegate(SetMaxValue), val);
                return;
            }

            frm.Value = val;
        }

        #endregion

      
    }
}
