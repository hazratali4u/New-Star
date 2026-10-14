namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class OrderInfoCollection_Controller : CollectionBase
    {
        public void Add(OrderInfo_Collection p_OGColCntrlr)
        {
            base.List.Add(p_OGColCntrlr);
        }

        public OrderInfo_Collection Get(int p_Index)
        {
            return (OrderInfo_Collection) base.List[p_Index];
        }
    }
}

