namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SchemeCollection_Controller : CollectionBase
    {
        public void Add(Scheme_Collection p_SchCol)
        {
            base.List.Add(p_SchCol);
        }

        public Scheme_Collection Get(int p_Index)
        {
            return (Scheme_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, Scheme_Collection p_SchCol)
        {
            base.List.Insert(p_i, p_SchCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

