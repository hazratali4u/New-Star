namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SaleOrderPromoCol_Controller : CollectionBase
    {
        public void Add(SaleOrderPromotion_Collection p_BCol)
        {
            base.List.Add(p_BCol);
        }

        public SaleOrderPromotion_Collection Get(int p_Index)
        {
            return (SaleOrderPromotion_Collection) base.List[p_Index];
        }

        public SaleOrderPromotion_Collection GetPromoOffer(long SALE_ORDER_DETAIL_ID)
        {
            int num = 0;
            foreach (object obj2 in base.List)
            {
                if (((SaleOrderPromotion_Collection) obj2).Sale_Order_Detail_ID == SALE_ORDER_DETAIL_ID)
                {
                    break;
                }
                num++;
            }
            return (SaleOrderPromotion_Collection) base.List[num];
        }
    }
}

