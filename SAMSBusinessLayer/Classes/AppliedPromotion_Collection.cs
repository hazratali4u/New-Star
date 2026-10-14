namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class AppliedPromotion_Collection
    {
        private long mBasket_ID;
        private int mBasket_Selection;
        private long mBasketDetail_ID;
        private int mDist_ID;
        private int mGroup_Id;
        private long mPromotion_ID;
        private int mPromotion_Offer_ID;
        private int mScheme_ID;
        private decimal mSku_Amount;
        private int mSKU_ID;
        private int mSKU_Quantity;

        public long Basket_ID
        {
            get
            {
                return this.mBasket_ID;
            }
            set
            {
                this.mBasket_ID = value;
            }
        }

        public int Basket_Selection
        {
            get
            {
                return this.mBasket_Selection;
            }
            set
            {
                this.mBasket_Selection = value;
            }
        }

        public long BasketDetail_ID
        {
            get
            {
                return this.mBasketDetail_ID;
            }
            set
            {
                this.mBasketDetail_ID = value;
            }
        }

        public int Dist_ID
        {
            get
            {
                return this.mDist_ID;
            }
            set
            {
                this.mDist_ID = value;
            }
        }

        public int Group_Id
        {
            get
            {
                return this.mGroup_Id;
            }
            set
            {
                this.mGroup_Id = value;
            }
        }

        public long Promotion_ID
        {
            get
            {
                return this.mPromotion_ID;
            }
            set
            {
                this.mPromotion_ID = value;
            }
        }

        public int Promotion_Offer_ID
        {
            get
            {
                return this.mPromotion_Offer_ID;
            }
            set
            {
                this.mPromotion_Offer_ID = value;
            }
        }

        public int Scheme_ID
        {
            get
            {
                return this.mScheme_ID;
            }
            set
            {
                this.mScheme_ID = value;
            }
        }

        public decimal Sku_Amount
        {
            get
            {
                return this.mSku_Amount;
            }
            set
            {
                this.mSku_Amount = value;
            }
        }

        public int SKU_ID
        {
            get
            {
                return this.mSKU_ID;
            }
            set
            {
                this.mSKU_ID = value;
            }
        }

        public int SKU_Quantity
        {
            get
            {
                return this.mSKU_Quantity;
            }
            set
            {
                this.mSKU_Quantity = value;
            }
        }
    }
}

