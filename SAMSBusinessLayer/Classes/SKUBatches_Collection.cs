namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SKUBatches_Collection
    {
        private DateTime mBatch_Expiry;
        private string mBatch_No;
        private long mBatch_Units;
        private long mDist_ID;
        private long mSKU_ID;

        public DateTime Batch_Expiry
        {
            get
            {
                return this.mBatch_Expiry;
            }
            set
            {
                this.mBatch_Expiry = value;
            }
        }

        public string Batch_No
        {
            get
            {
                return this.mBatch_No;
            }
            set
            {
                this.mBatch_No = value;
            }
        }

        public long Batch_Units
        {
            get
            {
                return this.mBatch_Units;
            }
            set
            {
                this.mBatch_Units = value;
            }
        }

        public long Dist_ID
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

        public long SKU_ID
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
    }
}

