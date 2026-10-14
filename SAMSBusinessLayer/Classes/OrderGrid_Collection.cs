namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class OrderGrid_Collection
    {
        private decimal mAmount;
        private string mBatchNo;
        private string mBatchQty;
        private decimal mDozenPrice;
        private int mDozens;
        private decimal mGST_Amount;
        private char mGST_On;
        private decimal mGST_Rate;
        private bool mIs_Deleted;
        private bool mIsGstOnTradePrice;
        private decimal mNetAmount;
        private decimal mRetailPrice;
        private long mSale_Order_Detail_Id;
        private decimal mSchemeAmount;
        private decimal mSchemeDiscount_Rate;
        private string mSKU_Code;
        private int mSKU_ID;
        private string mSKU_Name;
        private string mSKUBrand;
        private string mSKUCategory;
        private string mSKUCompanyId;
        private string mSkuDiv;
        private string mSKUGroupId;
        private string mSkuProductline;
        private decimal mStdDiscount;
        private decimal mStdDiscount_Rate;
        private decimal mTaxPrice;
        private decimal mTotalAmount;
        private decimal mUnitPrice;
        private int mUnits;
        private int mUOM_ID;

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

        public decimal DozenPrice
        {
            get
            {
                return this.mDozenPrice;
            }
            set
            {
                this.mDozenPrice = value;
            }
        }

        public int Dozens
        {
            get
            {
                return this.mDozens;
            }
            set
            {
                this.mDozens = value;
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

        public char GST_On
        {
            get
            {
                return this.mGST_On;
            }
            set
            {
                this.mGST_On = value;
            }
        }

        public decimal GST_Rate
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

        public bool Is_Deleted
        {
            get
            {
                return this.mIs_Deleted;
            }
            set
            {
                this.mIs_Deleted = value;
            }
        }

        public bool IsGstOnTradePrice
        {
            get
            {
                return this.mIsGstOnTradePrice;
            }
            set
            {
                this.mIsGstOnTradePrice = value;
            }
        }

        public decimal NetAmount
        {
            get
            {
                return this.mNetAmount;
            }
            set
            {
                this.mNetAmount = value;
            }
        }

        public decimal RetailPrice
        {
            get
            {
                return this.mRetailPrice;
            }
            set
            {
                this.mRetailPrice = value;
            }
        }

        public long Sale_Order_Detail_Id
        {
            get
            {
                return this.mSale_Order_Detail_Id;
            }
            set
            {
                this.mSale_Order_Detail_Id = value;
            }
        }

        public decimal SchemeAmount
        {
            get
            {
                return this.mSchemeAmount;
            }
            set
            {
                this.mSchemeAmount = value;
            }
        }

        public decimal SchemeDiscount_Rate
        {
            get
            {
                return this.mSchemeDiscount_Rate;
            }
            set
            {
                this.mSchemeDiscount_Rate = value;
            }
        }

        public string SKU_Code
        {
            get
            {
                return this.mSKU_Code;
            }
            set
            {
                this.mSKU_Code = value;
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

        public string SKU_Name
        {
            get
            {
                return this.mSKU_Name;
            }
            set
            {
                this.mSKU_Name = value;
            }
        }

        public string SKUBatchNo
        {
            get
            {
                return this.mBatchNo;
            }
            set
            {
                this.mBatchNo = value;
            }
        }

        public string SKUBatchQty
        {
            get
            {
                return this.mBatchQty;
            }
            set
            {
                this.mBatchQty = value;
            }
        }

        public string SKUBrand
        {
            get
            {
                return this.mSKUBrand;
            }
            set
            {
                this.mSKUBrand = value;
            }
        }

        public string SKUCategory
        {
            get
            {
                return this.mSKUCategory;
            }
            set
            {
                this.mSKUCategory = value;
            }
        }

        public string SkuCompany
        {
            get
            {
                return this.mSKUCompanyId;
            }
            set
            {
                this.mSKUCompanyId = value;
            }
        }

        public string SkuDiv
        {
            get
            {
                return this.mSkuDiv;
            }
            set
            {
                this.mSkuDiv = value;
            }
        }

        public string SKUGroupId
        {
            get
            {
                return this.mSKUGroupId;
            }
            set
            {
                this.mSKUGroupId = value;
            }
        }

        public string SkuProductline
        {
            get
            {
                return this.mSkuProductline;
            }
            set
            {
                this.mSkuProductline = value;
            }
        }

        public decimal StdDiscount
        {
            get
            {
                return this.mStdDiscount;
            }
            set
            {
                this.mStdDiscount = value;
            }
        }

        public decimal StdDiscount_Rate
        {
            get
            {
                return this.mStdDiscount_Rate;
            }
            set
            {
                this.mStdDiscount_Rate = value;
            }
        }

        public decimal TaxPrice
        {
            get
            {
                return this.mTaxPrice;
            }
            set
            {
                this.mTaxPrice = value;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return this.mTotalAmount;
            }
            set
            {
                this.mTotalAmount = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return this.mUnitPrice;
            }
            set
            {
                this.mUnitPrice = value;
            }
        }

        public int Units
        {
            get
            {
                return this.mUnits;
            }
            set
            {
                this.mUnits = value;
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

