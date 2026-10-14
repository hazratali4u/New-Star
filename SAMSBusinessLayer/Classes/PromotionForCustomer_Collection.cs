namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class PromotionForCustomer_Collection
    {
        private int mCustomer_ID;
        private int mDist_ID;
        private long mPromotion_For_ID;
        private long mPromotion_ID;
        private int mScheme_ID;

        public int Customer_ID
        {
            get
            {
                return this.mCustomer_ID;
            }
            set
            {
                this.mCustomer_ID = value;
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

        public long Promotion_For_ID
        {
            get
            {
                return this.mPromotion_For_ID;
            }
            set
            {
                this.mPromotion_For_ID = value;
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
    }
}

