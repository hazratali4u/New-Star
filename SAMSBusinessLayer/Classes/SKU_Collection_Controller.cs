namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SKU_Collection_Controller : CollectionBase
    {
        public void Add(SKU_Collection p_SKUC)
        {
            base.List.Add(p_SKUC);
        }

        public SKU_Collection GetItem(int p_Index)
        {
            return (SKU_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, SKU_Collection p_SKUC)
        {
            base.List.Insert(p_i, p_SKUC);
        }
    }
}

