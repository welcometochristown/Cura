using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cura.Common
{
        public class Collection<T>
        : List<T>
        {

            public delegate void CollectionChangeEvent(object sender, CollectionChangeEventArgs args);

            #region Events
            public event CollectionChangeEvent ObjectAdded;

            public void Add(T obj)
            {
                base.Add(obj);

                if (ObjectAdded != null)
                {
                    CollectionChangeEventArgs args = new CollectionChangeEventArgs();
                    args.added.Add(obj);

                    ObjectAdded(this, args);
                }

            }
            public void AddRange(IEnumerable<T> collection)
            {
                base.AddRange(collection);

                if (ObjectAdded != null)
                {
                    CollectionChangeEventArgs args = new CollectionChangeEventArgs();
                    args.added.AddRange(collection.Cast<Object>().ToList());

                    ObjectAdded(this, args);
                }
            }

            public event CollectionChangeEvent ObjectRemoved;

            public void Remove(T obj)
            {
                base.Remove(obj);

                if (ObjectRemoved != null)
                {
                    CollectionChangeEventArgs args = new CollectionChangeEventArgs();
                    args.removed.Add(obj);

                    ObjectRemoved(this, args);
                }

            }
            #endregion

          
    }
}
