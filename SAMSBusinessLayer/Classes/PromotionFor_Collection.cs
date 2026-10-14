namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class PromotionFor_Collection
    {
        private int mAssigned_Dist_ID;
        private int mDist_ID;
        private long mPromotion_For_ID;
        private long mPromotion_ID;
        private int mScheme_ID;

        public int Assigned_Dist_ID
        {
            get
            {
                return this.mAssigned_Dist_ID;
            }
            set
            {
                this.mAssigned_Dist_ID = value;
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

