namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SaleOrderDetailCol_Controller : CollectionBase
    {
        public void Add(SaleOrderDetail_Collection p_BCol)
        {
            base.List.Add(p_BCol);
        }

        public SaleOrderDetail_Collection Get(int p_Index)
        {
            return (SaleOrderDetail_Collection) base.List[p_Index];
        }
    }
}

