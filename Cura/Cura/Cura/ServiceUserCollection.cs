using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura
{
    public class ServiceUserCollection
      : Cura.Common.Collection<ServiceUser>
    {

         #region Constructor
        public ServiceUserCollection()
        {
        //ctor
        }
        #endregion

        /// <summary>
        /// Save The Collection
        /// </summary>
        public void Save()
        {
            foreach (ServiceUser s in this)
            {
                s.Save();
            }
        }

    }
}
