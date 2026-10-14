namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class AppliedPromotionCol_Controller : CollectionBase
    {
        public void Add(AppliedPromotion_Collection p_APCol)
        {
            base.List.Add(p_APCol);
        }

        public AppliedPromotion_Collection GetItem(int p_Index)
        {
            return (AppliedPromotion_Collection) base.List[p_Index];
        }
    }
}

