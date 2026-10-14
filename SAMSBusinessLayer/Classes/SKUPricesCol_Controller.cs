namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SKUPricesCol_Controller : CollectionBase
    {
        public void Add(SKUPrices_Collection p_SKUC)
        {
            base.List.Add(p_SKUC);
        }

        public SKUPrices_Collection GetItems(int p_Index)
        {
            return (SKUPrices_Collection) base.List[p_Index];
        }
    }
}

