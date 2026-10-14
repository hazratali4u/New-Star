namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class ClaimDetail_Collection
    {
        private decimal mAmount;
        private decimal mClaim_Amount;
        private long mClaim_Detail_ID;
        private long mClaim_ID;
        private int mDistributor_ID;
        private int mFree_Quantity;
        private int mIncentive_Offer_ID;
        private int mPromotion_ID;
        private int mQuantity;
        private int mScheme_ID;
        private int mSKU_ID;
        private int mUser_ID;

        public decimal Amount
        {
            get
            {
                return this.mAmount;
            }
            set
            {
                this.mAmount = value;
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

        public long Claim_Detail_ID
        {
            get
            {
                return this.mClaim_Detail_ID;
            }
            set
            {
                this.mClaim_Detail_ID = value;
            }
        }

        public long Claim_ID
        {
            get
            {
                return this.mClaim_ID;
            }
            set
            {
                this.mClaim_ID = value;
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

        public int Free_Quantity
        {
            get
            {
                return this.mFree_Quantity;
            }
            set
            {
                this.mFree_Quantity = value;
            }
        }

        public int Incentive_Offer_ID
        {
            get
            {
                return this.mIncentive_Offer_ID;
            }
            set
            {
                this.mIncentive_Offer_ID = value;
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

        public int User_ID
        {
            get
            {
                return this.mUser_ID;
            }
            set
            {
                this.mUser_ID = value;
            }
        }
    }
}

