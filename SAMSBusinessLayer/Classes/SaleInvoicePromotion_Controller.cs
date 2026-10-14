namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SaleInvoicePromotion_Controller : CollectionBase
    {
        public void Add(SaleInvoicePromotion_Collection p_BCol)
        {
            base.List.Add(p_BCol);
        }

        public SaleInvoicePromotion_Collection Get(int p_Index)
        {
            return (SaleInvoicePromotion_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, SaleInvoicePromotion_Collection p_BCol)
        {
            base.List.Insert(p_i, p_BCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

