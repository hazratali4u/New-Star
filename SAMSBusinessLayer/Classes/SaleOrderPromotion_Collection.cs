namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SaleOrderPromotion_Collection
    {
        private int mBasket_ID;
        private int mBasketDetail_ID;
        private decimal mClaim_Amount;
        private decimal mDisc_Amount;
        private decimal mDisc_Rate;
        private int mDistributor_ID;
        private decimal mGST_Amount;
        private float mGST_Rate;
        private bool mIs_Scheme;
        private int mPromotion_ID;
        private int mPromotionOffer_ID;
        private int mQuantity;
        private decimal mRetail_Price;
        private long mSale_Order_Detail_ID;
        private decimal mSale_Order_Master_Id;
        private int mSALE_ORDER_PROMOTION_ID;
        private int mScheme_ID;
        private int mSKU_ID;
        private decimal mUnit_Price;

        public int Basket_ID
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

        public int BasketDetail_ID
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

        public decimal Claim_Amount
        {
            get
            {
                return this.mClaim_Amount;
            }
            set
            {
                this.mClaim_Amount = value;
            }
        }

        public decimal Disc_Amount
        {
            get
            {
                return this.mDisc_Amount;
            }
            set
            {
                this.mDisc_Amount = value;
            }
        }

        public decimal Disc_Rate
        {
            get
            {
                return this.mDisc_Rate;
            }
            set
            {
                this.mDisc_Rate = value;
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

        public decimal GST_Amount
        {
            get
            {
                return this.mGST_Amount;
            }
            set
            {
                this.mGST_Amount = value;
            }
        }

        public float GST_Rate
        {
            get
            {
                return this.mGST_Rate;
            }
            set
            {
                this.mGST_Rate = value;
            }
        }

        public bool Is_Scheme
        {
            get
            {
                return this.mIs_Scheme;
            }
            set
            {
                this.mIs_Scheme = value;
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

        public int PromotionOffer_ID
        {
            get
            {
                return this.mPromotionOffer_ID;
            }
            set
            {
                this.mPromotionOffer_ID = value;
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

        public decimal Retail_Price
        {
            get
            {
                return this.mRetail_Price;
            }
            set
            {
                this.mRetail_Price = value;
            }
        }

        public long Sale_Order_Detail_ID
        {
            get
            {
                return this.mSale_Order_Detail_ID;
            }
            set
            {
                this.mSale_Order_Detail_ID = value;
            }
        }

        public decimal Sale_Order_Master_Id
        {
            get
            {
                return this.mSale_Order_Master_Id;
            }
            set
            {
                this.mSale_Order_Master_Id = value;
            }
        }

        public int SALE_ORDER_PROMOTION_ID
        {
            get
            {
                return this.mSALE_ORDER_PROMOTION_ID;
            }
            set
            {
                this.mSALE_ORDER_PROMOTION_ID = value;
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

        public decimal Unit_Price
        {
            get
            {
                return this.mUnit_Price;
            }
            set
            {
                this.mUnit_Price = value;
            }
        }
    }
}

