using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura
{
    class ChangeItem
    {
        #region Fields
        private int _id;

        private string _tablename;
        private string _fieldname;

        private int _tableid;

        private string _oldvalue;
        private string _newvalue;

        private DateTime _dateupdate;
        private string _uid;
        #endregion

        #region Properties
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int TableID
        {
            get
            {
                return _tableid;
            }
            set
            {
                _tableid = value;
            }
        }

        public string TableName
        {
            get
            {
                return _tablename;
            }
            set
            {
                _tablename = value;
            }
        }

        public string FieldName
        {
            get
            {
                return _fieldname;
            }
            set
            {
                _fieldname = value;
            }
        }

        public string OldValue
        {
            get
            {
                return _oldvalue;
            }
            set
            {
                _oldvalue = value;
            }
        }

        public string NewValue
        {
            get
            {
                return _newvalue;
            }
            set
            {
                _newvalue = value;
            }

        }

        public DateTime DateUpdate
        {
            get
            {
                return _dateupdate;
            }
            set
            {
                _dateupdate = value;
            }
        }

        public string UID
        {
            get
            {
                return _uid;
            }
            set
            {
                _uid = value;
            }
        }
        #endregion
    }
}
