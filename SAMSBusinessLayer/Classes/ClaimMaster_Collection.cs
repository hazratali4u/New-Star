namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class ClaimMaster_Collection
    {
        private decimal mClaim_Amount;
        private long mClaim_ID;
        private int mClaim_Status_ID;
        private int mClaim_SubType;
        private int mClaim_Type_ID;
        private DateTime mDate_From;
        private DateTime mDate_To;
        private int mDistributor_ID;
        private DateTime mLastUpdate_Date;
        private ClaimDetailCol_Controller mobjClaimDetailCol_Cntrlr;
        private string mRemarks;
        private DateTime mTime_Stamp;

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

        public int Claim_Status_ID
        {
            get
            {
                return this.mClaim_Status_ID;
            }
            set
            {
                this.mClaim_Status_ID = value;
            }
        }

        public int Claim_SubType
        {
            get
            {
                return this.mClaim_SubType;
            }
            set
            {
                this.mClaim_SubType = value;
            }
        }

        public int Claim_Type_ID
        {
            get
            {
                return this.mClaim_Type_ID;
            }
            set
            {
                this.mClaim_Type_ID = value;
            }
        }

        public DateTime Date_From
        {
            get
            {
                return this.mDate_From;
            }
            set
            {
                this.mDate_From = value;
            }
        }

        public DateTime Date_To
        {
            get
            {
                return this.mDate_To;
            }
            set
            {
                this.mDate_To = value;
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

        public DateTime LastUpdate_Date
        {
            get
            {
                return this.mLastUpdate_Date;
            }
            set
            {
                this.mLastUpdate_Date = value;
            }
        }

        public ClaimDetailCol_Controller ObjClaimDetailCol_Cntrlr
        {
            get
            {
                return this.mobjClaimDetailCol_Cntrlr;
            }
            set
            {
                this.mobjClaimDetailCol_Cntrlr = value;
            }
        }

        public string Remarks
        {
            get
            {
                return this.mRemarks;
            }
            set
            {
                this.mRemarks = value;
            }
        }

        public DateTime Time_Stamp
        {
            get
            {
                return this.mTime_Stamp;
            }
            set
            {
                this.mTime_Stamp = value;
            }
        }
    }
}

