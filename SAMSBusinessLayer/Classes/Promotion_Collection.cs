namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class Promotion_Collection
    {
        private bool mClaimable;
        private int mDist_ID;
        private DateTime mEnd_Date;
        private bool mIs_Active;
        private bool mIs_Scheme;
        private string mPromotion_Code;
        private DateTime mPromotion_Date;
        private string mPromotion_Desc;
        private bool mPromotion_For;
        private long mPromotion_ID;
        private int mPromotion_Selection;
        private int mPromotion_Type;
        private int mScheme_ID;
        private DateTime mStart_Date;
        private BasketCollection_Controller objBasketCol_Cntrl;
        private PromotionCustVolclassColl_Controller ObjPromotionCustVolClassCol_Cntrl;
        private PromotionForCollection_Controller objPromotionForCol_Cntrl;
        private PromotionForCustColl_Controller objPromotionForCustCol_Cntrl;
        private PromotionCustTypeColl_Controller objPromotionForCustTypeCol_Cntrl;

        public bool Claimable
        {
            get
            {
                return this.mClaimable;
            }
            set
            {
                this.mClaimable = value;
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

        public DateTime End_Date
        {
            get
            {
                return this.mEnd_Date;
            }
            set
            {
                this.mEnd_Date = value;
            }
        }

        public bool Is_Active
        {
            get
            {
                return this.mIs_Active;
            }
            set
            {
                this.mIs_Active = value;
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

        public BasketCollection_Controller ObjBasketCol_Cntrl
        {
            get
            {
                return this.objBasketCol_Cntrl;
            }
            set
            {
                this.objBasketCol_Cntrl = value;
            }
        }

        public PromotionCustTypeColl_Controller ObjPromotionCustTypeCol_Cntrl
        {
            get
            {
                return this.objPromotionForCustTypeCol_Cntrl;
            }
            set
            {
                this.objPromotionForCustTypeCol_Cntrl = value;
            }
        }

        public PromotionForCollection_Controller ObjPromotionForCol_Cntrl
        {
            get
            {
                return this.objPromotionForCol_Cntrl;
            }
            set
            {
                this.objPromotionForCol_Cntrl = value;
            }
        }

        public PromotionForCustColl_Controller ObjPromotionForCustCol_Cntrl
        {
            get
            {
                return this.objPromotionForCustCol_Cntrl;
            }
            set
            {
                this.objPromotionForCustCol_Cntrl = value;
            }
        }

        public PromotionCustVolclassColl_Controller ObjPromotionVolClassCol_Cntrl
        {
            get
            {
                return this.ObjPromotionCustVolClassCol_Cntrl;
            }
            set
            {
                this.ObjPromotionCustVolClassCol_Cntrl = value;
            }
        }

        public string Promotion_Code
        {
            get
            {
                return this.mPromotion_Code;
            }
            set
            {
                this.mPromotion_Code = value;
            }
        }

        public DateTime Promotion_Date
        {
            get
            {
                return this.mPromotion_Date;
            }
            set
            {
                this.mPromotion_Date = value;
            }
        }

        public string Promotion_Desc
        {
            get
            {
                return this.mPromotion_Desc;
            }
            set
            {
                this.mPromotion_Desc = value;
            }
        }

        public bool Promotion_For
        {
            get
            {
                return this.mPromotion_For;
            }
            set
            {
                this.mPromotion_For = value;
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

        public int Promotion_Selection
        {
            get
            {
                return this.mPromotion_Selection;
            }
            set
            {
                this.mPromotion_Selection = value;
            }
        }

        public int Promotion_Type
        {
            get
            {
                return this.mPromotion_Type;
            }
            set
            {
                this.mPromotion_Type = value;
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

        public DateTime Start_Date
        {
            get
            {
                return this.mStart_Date;
            }
            set
            {
                this.mStart_Date = value;
            }
        }
    }
}

