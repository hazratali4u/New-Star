namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SaleOrderDetail_Collection
    {
        private decimal mAmount;
        private string mBatch_No;
        private int mDistributor_ID;
        private decimal mExtra_Discount;
        private decimal mGST_Amount;
        private string mGST_On;
        private float mGST_Rate;
        private bool mIs_Deleted;
        private decimal mNet_Amount;
        private int mQuantity_Unit;
        private decimal mRetail_Price;
        private long mSale_Order_Detail_ID;
        private long mSale_Order_Id;
        private int mSKU_ID;
        private decimal mStandard_Discount;
        private decimal mTax_Price;
        private DateTime mTime_Stamp;
        private decimal mUnit_Price;
        private SaleOrderPromoCol_Controller objSOrderPromoCol_Cntrlr;

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

        public decimal Extra_Discount
        {
            get
            {
                return this.mExtra_Discount;
            }
            set
            {
                this.mExtra_Discount = value;
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

        public string GST_On
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

        public decimal Net_Amount
        {
            get
            {
                return this.mNet_Amount;
            }
            set
            {
                this.mNet_Amount = value;
            }
        }

        public SaleOrderPromoCol_Controller ObjSOrderPromoCol_Cntrlr
        {
            get
            {
                return this.objSOrderPromoCol_Cntrlr;
            }
            set
            {
                this.objSOrderPromoCol_Cntrlr = value;
            }
        }

        public int Quantity_Unit
        {
            get
            {
                return this.mQuantity_Unit;
            }
            set
            {
                this.mQuantity_Unit = value;
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

        public long Sale_Order_Id
        {
            get
            {
                return this.mSale_Order_Id;
            }
            set
            {
                this.mSale_Order_Id = value;
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

        public decimal Standard_Discount
        {
            get
            {
                return this.mStandard_Discount;
            }
            set
            {
                this.mStandard_Discount = value;
            }
        }

        public decimal Tax_Price
        {
            get
            {
                return this.mTax_Price;
            }
            set
            {
                this.mTax_Price = value;
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

