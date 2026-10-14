namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class PromotionForCollection_Controller : CollectionBase
    {
        public void Add(PromotionFor_Collection p_PForCol)
        {
            base.List.Add(p_PForCol);
        }

        public PromotionFor_Collection Get(int p_Index)
        {
            return (PromotionFor_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, PromotionFor_Collection p_PForCol)
        {
            base.List.Insert(p_i, p_PForCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

