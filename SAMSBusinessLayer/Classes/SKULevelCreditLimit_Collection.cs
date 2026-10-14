namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SKULevelCreditLimit_Collection
    {
        private decimal mAllowed_credit_limit;
        private long mCustomer_id;
        private decimal mOrdered_Amount;
        private long mSku_level_credit_limit_id;
        private long mSku_level_id;
        private string mSku_level_name;
        private decimal mUsed_limit;

        public decimal ALLOWED_CREDIT_LIMIT
        {
            get
            {
                return this.mAllowed_credit_limit;
            }
            set
            {
                this.mAllowed_credit_limit = value;
            }
        }

        public long CUSTOMER_ID
        {
            get
            {
                return this.mCustomer_id;
            }
            set
            {
                this.mCustomer_id = value;
            }
        }

        public decimal ORDERED_AMOUNT
        {
            get
            {
                return this.mOrdered_Amount;
            }
            set
            {
                this.mOrdered_Amount = value;
            }
        }

        public long SKU_LEVEL_CREDIT_LIMIT_ID
        {
            get
            {
                return this.mSku_level_credit_limit_id;
            }
            set
            {
                this.mSku_level_credit_limit_id = value;
            }
        }

        public long SKU_LEVEL_ID
        {
            get
            {
                return this.mSku_level_id;
            }
            set
            {
                this.mSku_level_id = value;
            }
        }

        public string SKU_LEVEL_NAME
        {
            get
            {
                return this.mSku_level_name;
            }
            set
            {
                this.mSku_level_name = value;
            }
        }

        public decimal USED_LIMIT
        {
            get
            {
                return this.mUsed_limit;
            }
            set
            {
                this.mUsed_limit = value;
            }
        }
    }
}

