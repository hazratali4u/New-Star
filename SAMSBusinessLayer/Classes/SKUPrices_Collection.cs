namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SKUPrices_Collection
    {
        private decimal m_Case_Price;
        private long m_Dist_ID;
        private decimal m_Dist_Price;
        private decimal m_Dozen_Price;
        private decimal m_Retail_Price;
        private long m_SKU_ID;
        private long m_SKU_Mapping_ID;
        private decimal m_SKU_Unit_Price;
        private string m_SKUCode;
        private decimal m_Tax_Price;
        private decimal m_Trade_Price;

        public long SKU_SKU_ID
        {
            get
            {
                return this.m_SKU_ID;
            }
            set
            {
                this.m_SKU_ID = value;
            }
        }

        public long SKU_SKU_Mapping_ID
        {
            get
            {
                return this.m_SKU_Mapping_ID;
            }
            set
            {
                this.m_SKU_Mapping_ID = value;
            }
        }

        public string SKU_SKUCode
        {
            get
            {
                return this.m_SKUCode;
            }
            set
            {
                this.m_SKUCode = value;
            }
        }

        public decimal SKUCase_Price
        {
            get
            {
                return this.m_Case_Price;
            }
            set
            {
                this.m_Case_Price = value;
            }
        }

        public long SKUDist_ID
        {
            get
            {
                return this.m_Dist_ID;
            }
            set
            {
                this.m_Dist_ID = value;
            }
        }

        public decimal SKUDist_Price
        {
            get
            {
                return this.m_Dist_Price;
            }
            set
            {
                this.m_Dist_Price = value;
            }
        }

        public decimal SKUDozen_Price
        {
            get
            {
                return this.m_Dozen_Price;
            }
            set
            {
                this.m_Dozen_Price = value;
            }
        }

        public decimal SKURetail_Price
        {
            get
            {
                return this.m_Retail_Price;
            }
            set
            {
                this.m_Retail_Price = value;
            }
        }

        public decimal SKUTax_Price
        {
            get
            {
                return this.m_Tax_Price;
            }
            set
            {
                this.m_Tax_Price = value;
            }
        }

        public decimal SKUTrade_Price
        {
            get
            {
                return this.m_Trade_Price;
            }
            set
            {
                this.m_Trade_Price = value;
            }
        }

        public decimal SKUUnit_Price
        {
            get
            {
                return this.m_SKU_Unit_Price;
            }
            set
            {
                this.m_SKU_Unit_Price = value;
            }
        }
    }
}

