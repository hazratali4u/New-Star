namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class OrderGridCollection_Controller : CollectionBase
    {
        public void Add(OrderGrid_Collection p_OGCol)
        {
            base.List.Add(p_OGCol);
        }

        public OrderGrid_Collection Get(int p_Index)
        {
            return (OrderGrid_Collection) base.List[p_Index];
        }
    }
}

