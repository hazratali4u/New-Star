namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SaleOrderMaster_Collection
    {
        private long mArea_ID;
        private decimal mCash_Received;
        private int mDeliveryMan_ID;
        private int mDistributor_ID;
        private DateTime mDocument_Date;
        private decimal mExtra_Discount_Amount;
        private decimal mGST_Amount;
        private DateTime mLastUpdate_Date;
        private int mLegend_ID;
        private SaleOrderDetailCol_Controller mobjSaleOrderDtlCol_Cntrlr;
        private int mOrderBooker_ID;
        private int mOrderType_ID;
        private long mSale_Order_Id;
        private long mShip_To;
        private DateTime mShipment_Date;
        private long mSold_To;
        private decimal mStandard_Discount_Amount;
        private int mStatus_ID;
        private int mTerritory_ID;
        private DateTime mTime_Stamp;
        private decimal mTotal_Amount;
        private string mTotal_Claim_Amount;
        private decimal mTotal_Net_Amount;

        public long Area_ID
        {
            get
            {
                return this.mArea_ID;
            }
            set
            {
                this.mArea_ID = value;
            }
        }

        public decimal CashReceived
        {
            get
            {
                return this.mCash_Received;
            }
            set
            {
                this.mCash_Received = value;
            }
        }

        public int DeliveryMan_ID
        {
            get
            {
                return this.mDeliveryMan_ID;
            }
            set
            {
                this.mDeliveryMan_ID = value;
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

        public DateTime Document_Date
        {
            get
            {
                return this.mDocument_Date;
            }
            set
            {
                this.mDocument_Date = value;
            }
        }

        public decimal Extra_Discount_Amount
        {
            get
            {
                return this.mExtra_Discount_Amount;
            }
            set
            {
                this.mExtra_Discount_Amount = value;
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

        public int Legend_ID
        {
            get
            {
                return this.mLegend_ID;
            }
            set
            {
                this.mLegend_ID = value;
            }
        }

        public SaleOrderDetailCol_Controller objSaleOrderDtlCol_Cntrlr
        {
            get
            {
                return this.mobjSaleOrderDtlCol_Cntrlr;
            }
            set
            {
                this.mobjSaleOrderDtlCol_Cntrlr = value;
            }
        }

        public int OrderBooker_ID
        {
            get
            {
                return this.mOrderBooker_ID;
            }
            set
            {
                this.mOrderBooker_ID = value;
            }
        }

        public int OrderType_ID
        {
            get
            {
                return this.mOrderType_ID;
            }
            set
            {
                this.mOrderType_ID = value;
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

        public long Ship_To
        {
            get
            {
                return this.mShip_To;
            }
            set
            {
                this.mShip_To = value;
            }
        }

        public DateTime Shipment_Date
        {
            get
            {
                return this.mShipment_Date;
            }
            set
            {
                this.mShipment_Date = value;
            }
        }

        public long Sold_To
        {
            get
            {
                return this.mSold_To;
            }
            set
            {
                this.mSold_To = value;
            }
        }

        public decimal Standard_Discount_Amount
        {
            get
            {
                return this.mStandard_Discount_Amount;
            }
            set
            {
                this.mStandard_Discount_Amount = value;
            }
        }

        public int Status_ID
        {
            get
            {
                return this.mStatus_ID;
            }
            set
            {
                this.mStatus_ID = value;
            }
        }

        public int Territory_ID
        {
            get
            {
                return this.mTerritory_ID;
            }
            set
            {
                this.mTerritory_ID = value;
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

        public decimal Total_Amount
        {
            get
            {
                return this.mTotal_Amount;
            }
            set
            {
                this.mTotal_Amount = value;
            }
        }

        public string Total_Claim_Amount
        {
            get
            {
                return this.mTotal_Claim_Amount;
            }
            set
            {
                this.mTotal_Claim_Amount = value;
            }
        }

        public decimal Total_Net_Amount
        {
            get
            {
                return this.mTotal_Net_Amount;
            }
            set
            {
                this.mTotal_Net_Amount = value;
            }
        }
    }
}

