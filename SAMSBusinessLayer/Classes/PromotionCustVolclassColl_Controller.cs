namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class PromotionCustVolclassColl_Controller : CollectionBase
    {
        public void Add(PromotionCustomerVolClass_Collection p_PCustVolClassCol)
        {
            base.List.Add(p_PCustVolClassCol);
        }

        public PromotionCustomerVolClass_Collection Get(int p_Index)
        {
            return (PromotionCustomerVolClass_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, PromotionCustomerVolClass_Collection p_PCustVolClassCol)
        {
            base.List.Insert(p_i, p_PCustVolClassCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

