namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class ClaimMasterCol_Controller : CollectionBase
    {
        public void Add(ClaimMaster_Collection p_PForCol)
        {
            base.List.Add(p_PForCol);
        }

        public ClaimMaster_Collection Get(int p_Index)
        {
            return (ClaimMaster_Collection) base.List[p_Index];
        }
    }
}

