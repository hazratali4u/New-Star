namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SKUGroupCol_Cntrlr : CollectionBase
    {
        public void Add(SKUGroup_Collection p_SKUC)
        {
            base.List.Add(p_SKUC);
        }

        public SKUGroup_Collection GetItem(int p_Index)
        {
            return (SKUGroup_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, SKUGroup_Collection p_SKUC)
        {
            base.List.Insert(p_i, p_SKUC);
        }
    }
}

