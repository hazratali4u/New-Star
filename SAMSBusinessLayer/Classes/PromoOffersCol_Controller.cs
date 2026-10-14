namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class PromoOffersCol_Controller : CollectionBase
    {
        public void Add(PromoOffers_Collection p_POCol)
        {
            base.List.Add(p_POCol);
        }

        public PromoOffers_Collection Get(int p_Index)
        {
            return (PromoOffers_Collection) base.List[p_Index];
        }
    }
}

