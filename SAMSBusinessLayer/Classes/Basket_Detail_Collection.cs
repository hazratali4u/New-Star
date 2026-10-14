namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class Basket_Detail_Collection
    {
        private long mBasket_ID;
        private long mBasketDetail_ID;
        private int mDist_ID;
        private decimal mMax_Val;
        private decimal mMin_Val;
        private int mMultiple_Of;
        private long mPromotion_ID;
        private int mScheme_ID;
        private int mSKU_ID;
        private int mSKUBrand_ID;
        private int mSKUCatg_ID;
        private int mSKUCompany_ID;
        private int mSKUDiv_ID;
        private int mSKUGroup_ID;
        private int mSKUProductLine_ID;
        private int mUOM_ID;
        private PromotionOfferColl_Controller objPromotionOfferCol_Cntrl;

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

        public decimal Max_Val
        {
            get
            {
                return this.mMax_Val;
            }
            set
            {
                this.mMax_Val = value;
            }
        }

        public decimal Min_Val
        {
            get
            {
                return this.mMin_Val;
            }
            set
            {
                this.mMin_Val = value;
            }
        }

        public int Multiple_Of
        {
            get
            {
                return this.mMultiple_Of;
            }
            set
            {
                this.mMultiple_Of = value;
            }
        }

        public PromotionOfferColl_Controller ObjPromotionOfferCol_Cntrl
        {
            get
            {
                return this.objPromotionOfferCol_Cntrl;
            }
            set
            {
                this.objPromotionOfferCol_Cntrl = value;
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

        public int SKUBrand_ID
        {
            get
            {
                return this.mSKUBrand_ID;
            }
            set
            {
                this.mSKUBrand_ID = value;
            }
        }

        public int SKUCatg_ID
        {
            get
            {
                return this.mSKUCatg_ID;
            }
            set
            {
                this.mSKUCatg_ID = value;
            }
        }

        public int SKUCompany_ID
        {
            get
            {
                return this.mSKUCompany_ID;
            }
            set
            {
                this.mSKUCompany_ID = value;
            }
        }

        public int SKUDiv_ID
        {
            get
            {
                return this.mSKUDiv_ID;
            }
            set
            {
                this.mSKUDiv_ID = value;
            }
        }

        public int SKUGroup_ID
        {
            get
            {
                return this.mSKUGroup_ID;
            }
            set
            {
                this.mSKUGroup_ID = value;
            }
        }

        public int SKUProductLine_ID
        {
            get
            {
                return this.mSKUProductLine_ID;
            }
            set
            {
                this.mSKUProductLine_ID = value;
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

