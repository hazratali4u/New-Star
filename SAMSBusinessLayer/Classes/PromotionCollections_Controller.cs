namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class PromotionCollections_Controller : CollectionBase
    {
        public void Add_PCol(Promotion_Collection p_PCol)
        {
            base.List.Add(p_PCol);
        }

        public Promotion_Collection Get_PCol(int p_Index)
        {
            return (Promotion_Collection) base.List[p_Index];
        }
    }
}

