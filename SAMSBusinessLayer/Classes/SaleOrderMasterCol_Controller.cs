namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SaleOrderMasterCol_Controller : CollectionBase
    {
        public void Add(SaleOrderMaster_Collection p_BCol)
        {
            base.List.Add(p_BCol);
        }

        public SaleOrderMaster_Collection Get(int p_Index)
        {
            return (SaleOrderMaster_Collection) base.List[p_Index];
        }
    }
}

