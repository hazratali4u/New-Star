namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class PromotionForCustColl_Controller : CollectionBase
    {
        public void Add(PromotionForCustomer_Collection p_PForCustCol)
        {
            base.List.Add(p_PForCustCol);
        }

        public PromotionForCustomer_Collection Get(int p_Index)
        {
            return (PromotionForCustomer_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, PromotionForCustomer_Collection p_PForCustCol)
        {
            base.List.Insert(p_i, p_PForCustCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

