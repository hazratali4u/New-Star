namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class PromotionCustTypeColl_Controller : CollectionBase
    {
        public void Add(PromotionCustomerType_Collection p_PCustTypeCol)
        {
            base.List.Add(p_PCustTypeCol);
        }

        public PromotionCustomerType_Collection Get(int p_Index)
        {
            return (PromotionCustomerType_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, PromotionCustomerType_Collection p_PCustTypeCol)
        {
            base.List.Insert(p_i, p_PCustTypeCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

