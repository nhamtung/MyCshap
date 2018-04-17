using System.Collections.Generic;

namespace Vn.Ntq.RoboFW.Commons
{
    public class MultiMapBuffer<T>
    {
        private Dictionary<int, LinkedList<T>> dict = new Dictionary<int, LinkedList<T>>();

        public void Add(T obj)
        {
            lock (dict)
            {
                LinkedList<T> list = null;
                if (dict.ContainsKey(obj.GetHashCode()))
                {
                    list = dict[obj.GetHashCode()];
                }
                if (list == null)
                { 
                    list = new LinkedList<T>();
                    dict[obj.GetHashCode()] = list;
                }
                list.AddLast(obj);
            }
        }
        public T Remove(T obj)
        {
            lock (dict)
            {
                LinkedList<T> list = null;
                if (dict.ContainsKey(obj.GetHashCode()))
                {
                    list = dict[obj.GetHashCode()];
                    if (list != null && list.Count > 0)
                    {
                        var retObj = list.First.Value;
                        list.RemoveFirst();
                        return retObj;
                    }
                }
                return default(T);
            }
        }
        public T RemoveByKey(int key)
        {
            lock (dict)
            {
                LinkedList<T> list = null;
                if (dict.ContainsKey(key))
                {
                    list = dict[key];
                    if (list != null && list.Count > 0)
                    {
                        var retObj = list.First.Value;
                        list.RemoveFirst();
                        return retObj;
                    }
                }
                return default(T);
            }
        }
    }
}