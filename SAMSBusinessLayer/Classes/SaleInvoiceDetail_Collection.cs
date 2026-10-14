namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SaleInvoiceDetail_Collection
    {
        private decimal mAmount;
        private string mBatch_No;
        private int mDistributor_Id;
        private decimal mExtra_Discount;
        private char mGst_On;
        private float mGst_Rate;
        private decimal mNet_Amount;
        private int mQuantity_Unit;
        private decimal mRetail_Price;
        private long mSale_Invoice_Detail_Id;
        private long mSale_Invoice_Id;
        private long mSale_Order_Detail_Id;
        private int mSku_Id;
        private decimal mStandard_Discount;
        private decimal mTax_Price;
        private decimal mUnit_Price;
        private SaleInvoicePromotion_Controller SaleInvPromo_ctrl = new SaleInvoicePromotion_Controller();

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

        public int Distributor_Id
        {
            get
            {
                return this.mDistributor_Id;
            }
            set
            {
                this.mDistributor_Id = value;
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

        public char Gst_On
        {
            get
            {
                return this.mGst_On;
            }
            set
            {
                this.mGst_On = value;
            }
        }

        public float Gst_Rate
        {
            get
            {
                return this.mGst_Rate;
            }
            set
            {
                this.mGst_Rate = value;
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

        public long Sale_Invoice_Detail_Id
        {
            get
            {
                return this.mSale_Invoice_Detail_Id;
            }
            set
            {
                this.mSale_Invoice_Detail_Id = value;
            }
        }

        public long Sale_Invoice_Id
        {
            get
            {
                return this.mSale_Invoice_Id;
            }
            set
            {
                this.mSale_Invoice_Id = value;
            }
        }

        public SaleInvoicePromotion_Controller Sale_Invoice_Prmotion_Ctrl
        {
            get
            {
                return this.SaleInvPromo_ctrl;
            }
            set
            {
                this.SaleInvPromo_ctrl = value;
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

        public int Sku_Id
        {
            get
            {
                return this.mSku_Id;
            }
            set
            {
                this.mSku_Id = value;
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

