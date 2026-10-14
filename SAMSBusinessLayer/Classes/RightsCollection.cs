namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class RightsCollection : CollectionBase
    {
        public int Add(Rights accessRights)
        {
            return base.List.Add(accessRights);
        }

        public bool Contains(Rights accessRights)
        {
            return base.List.Contains(accessRights);
        }

        public void CopyTo(Rights[] array, int index)
        {
            base.List.CopyTo(array, index);
        }

        public int IndexOf(Rights accessRights)
        {
            return base.List.IndexOf(accessRights);
        }

        public void Insert(int index, Rights accessRights)
        {
            base.List.Insert(index, accessRights);
        }

        public void Remove(Rights accessRights)
        {
            base.List.Remove(accessRights);
        }

        public Rights this[int id]
        {
            get
            {
                for (int i = 0; i < base.List.Count; i++)
                {
                    if (((Rights) base.List[i]).ModuleID == id)
                    {
                        return (Rights) base.List[i];
                    }
                }
                return null;
            }
        }

        public Rights this[string key]
        {
            get
            {
                int num = 0;
                while (num < base.List.Count)
                {
                    if (((Rights) base.List[num]).ModuleName.Equals(key))
                    {
                        break;
                    }
                    num++;
                }
                if (base.List.Count == 0)
                {
                    return new Rights(-1, "", true, true, true, true, -1, "");
                }
                return (Rights) base.List[num];
            }
        }
    }
}

