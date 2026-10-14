namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class PromoOffers_Collection
    {
        private long mBasket_ID;
        private long mBasketDetail_ID;
        private float mDiscount;
        private int mDistributor_ID;
        private int mFree_SKU_ID;
        private bool mIs_And;
        private decimal mOffer_Value;
        private int mPromoOffer_ID;
        private int mPromotion_ID;
        private int mQuantity;
        private int mScheme_ID;
        private int mSKU_GroupID;
        private int mSKU_ID;
        private int mUOM_ID;

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

        public float Discount
        {
            get
            {
                return this.mDiscount;
            }
            set
            {
                this.mDiscount = value;
            }
        }

        public int Distributor_ID
        {
            get
            {
                return this.mDistributor_ID;
            }
            set
            {
                this.mDistributor_ID = value;
            }
        }

        public int Free_SKU_ID
        {
            get
            {
                return this.mFree_SKU_ID;
            }
            set
            {
                this.mFree_SKU_ID = value;
            }
        }

        public int Group_ID
        {
            get
            {
                return this.mSKU_GroupID;
            }
            set
            {
                this.mSKU_GroupID = value;
            }
        }

        public bool Is_And
        {
            get
            {
                return this.mIs_And;
            }
            set
            {
                this.mIs_And = value;
            }
        }

        public decimal Offer_Value
        {
            get
            {
                return this.mOffer_Value;
            }
            set
            {
                this.mOffer_Value = value;
            }
        }

        public int PromoOffer_ID
        {
            get
            {
                return this.mPromoOffer_ID;
            }
            set
            {
                this.mPromoOffer_ID = value;
            }
        }

        public int Promotion_ID
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

        public int Quantity
        {
            get
            {
                return this.mQuantity;
            }
            set
            {
                this.mQuantity = value;
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

        public int UOM_ID
        {
            get
            {
                return this.mUOM_ID;
            }
            set
            {
                this.mUOM_ID = value;
            }
        }
    }
}

