namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SKUBatchesColl_Controller : CollectionBase
    {
        public void Add(SKUBatches_Collection p_SKUC)
        {
            base.List.Add(p_SKUC);
        }

        public SKUBatches_Collection GetItem(int p_Index)
        {
            return (SKUBatches_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, SKUBatches_Collection p_SKUC)
        {
            base.List.Insert(p_i, p_SKUC);
        }
    }
}

