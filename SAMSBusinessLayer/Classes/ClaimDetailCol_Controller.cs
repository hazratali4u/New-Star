namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class ClaimDetailCol_Controller : CollectionBase
    {
        public void Add(ClaimDetail_Collection p_PForCol)
        {
            base.List.Add(p_PForCol);
        }

        public ClaimDetail_Collection Get(int p_Index)
        {
            return (ClaimDetail_Collection) base.List[p_Index];
        }
    }
}

