namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class SKULevelCreditLimitController : CollectionBase
    {
        public void Add(SKULevelCreditLimit_Collection p_SKUC)
        {
            base.List.Add(p_SKUC);
        }

        public SKULevelCreditLimit_Collection Get(int p_Index)
        {
            return (SKULevelCreditLimit_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, SKULevelCreditLimit_Collection p_SKUC)
        {
            base.List.Insert(p_i, p_SKUC);
        }
    }
}

