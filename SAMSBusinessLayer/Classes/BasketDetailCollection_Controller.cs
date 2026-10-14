namespace SAMS.BusinessLayer.Classes
{
    using System;
    using System.Collections;

    public class BasketDetailCollection_Controller : CollectionBase
    {
        public void Add(Basket_Detail_Collection p_BDetCol)
        {
            base.List.Add(p_BDetCol);
        }

        public Basket_Detail_Collection Get(int p_Index)
        {
            return (Basket_Detail_Collection) base.List[p_Index];
        }

        public void Insert(int p_i, Basket_Detail_Collection p_BDetCol)
        {
            base.List.Insert(p_i, p_BDetCol);
        }

        public void RemoveOn(int p_i)
        {
            base.List.RemoveAt(p_i);
        }
    }
}

