using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura.Common
{

    public class CollectionChangeEventArgs
    {
        public List<Object> added;
        public List<Object> removed;

        public CollectionChangeEventArgs()
        {
            added = new List<Object>();
            removed = new List<Object>();
        }

    }
}
