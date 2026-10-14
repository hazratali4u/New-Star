namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class PromotionOfferColl_Controller : CollectionBase
    {
        public void Add(PromotionOffer_Collection p_POfferCol)
        {
            base.List.Add(p_POfferCol);
        }

        public PromotionOffer_Collection Get(int p_Index)
        {
            return (PromotionOffer_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, PromotionOffer_Collection p_POfferCol)
        {
            base.List.Insert(p_i, p_POfferCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

