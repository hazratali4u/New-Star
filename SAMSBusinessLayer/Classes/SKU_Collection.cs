namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SKU_Collection
    {
        private decimal mCase_Price;
        private long mDist_ID;
        private decimal mDist_PriceCase;
        private decimal mDist_PriceDozen;
        private decimal mDist_PriceUnit;
        private decimal mDozen_Price;
        private string mGST_On;
        private decimal mGSTRate;
        private decimal mGSTRate_Reg;
        private decimal mGSTRate_UnReg;
        private bool mIs_Exempted;
        private decimal mRetail_PriceCase;
        private decimal mRetail_PriceDozen;
        private decimal mRetail_PriceUnit;
        private long mSKU_ID;
        private string mSKU_Mapping_Code;
        private long mSKU_Mapping_ID;
        private decimal mSKU_Unit_Price;
        private long mSKUBrand_ID;
        private long mSKUCase_Units;
        private long mSKUCatg_ID;
        private string mSKUCode;
        private long mSKUCompany_ID;
        private long mSKUDiv_ID;
        private long[] mSKUGroup;
        private string mSKUName;
        private long mSKUProductLine_ID;
        private decimal mTax_PriceCase;
        private decimal mTax_PriceDozen;
        private decimal mTax_PriceUnit;
        private decimal mTrade_PriceCase;
        private decimal mTrade_PriceDozen;
        private decimal mTrade_PriceUnit;
        private int mUOM_ID;
        private SKUPricesCol_Controller objSKUPricesCol_Cntrl = new SKUPricesCol_Controller();

        public decimal Case_Price
        {
            get
            {
                return this.mCase_Price;
            }
            set
            {
                this.mCase_Price = value;
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

        public decimal Dist_Price_Case
        {
            get
            {
                return this.mDist_PriceCase;
            }
            set
            {
                this.mDist_PriceCase = value;
            }
        }

        public decimal Dist_Price_Dozen
        {
            get
            {
                return this.mDist_PriceDozen;
            }
            set
            {
                this.mDist_PriceDozen = value;
            }
        }

        public decimal Dist_Price_Unit
        {
            get
            {
                return this.mDist_PriceUnit;
            }
            set
            {
                this.mDist_PriceUnit = value;
            }
        }

        public decimal Dozen_Price
        {
            get
            {
                return this.mDozen_Price;
            }
            set
            {
                this.mDozen_Price = value;
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

        public decimal GSTRate
        {
            get
            {
                return this.mGSTRate;
            }
            set
            {
                this.mGSTRate = value;
            }
        }

        public decimal GSTRate_Reg
        {
            get
            {
                return this.mGSTRate_Reg;
            }
            set
            {
                this.mGSTRate_Reg = value;
            }
        }

        public decimal GSTRate_UnReg
        {
            get
            {
                return this.mGSTRate_UnReg;
            }
            set
            {
                this.mGSTRate_UnReg = value;
            }
        }

        public bool Is_Exempted
        {
            get
            {
                return this.mIs_Exempted;
            }
            set
            {
                this.mIs_Exempted = value;
            }
        }

        public SKUPricesCol_Controller ObjSKUPricesCol_Cntrl
        {
            get
            {
                return this.objSKUPricesCol_Cntrl;
            }
            set
            {
                this.objSKUPricesCol_Cntrl = value;
            }
        }

        public decimal Retail_Price_Case
        {
            get
            {
                return this.mRetail_PriceCase;
            }
            set
            {
                this.mRetail_PriceCase = value;
            }
        }

        public decimal Retail_Price_Dozen
        {
            get
            {
                return this.mRetail_PriceDozen;
            }
            set
            {
                this.mRetail_PriceDozen = value;
            }
        }

        public decimal Retail_Price_Unit
        {
            get
            {
                return this.mRetail_PriceUnit;
            }
            set
            {
                this.mRetail_PriceUnit = value;
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

        public string SKU_Mapping_Code
        {
            get
            {
                return this.mSKU_Mapping_Code;
            }
            set
            {
                this.mSKU_Mapping_Code = value;
            }
        }

        public long SKU_Mapping_ID
        {
            get
            {
                return this.mSKU_Mapping_ID;
            }
            set
            {
                this.mSKU_Mapping_ID = value;
            }
        }

        public decimal SKU_Unit_Price
        {
            get
            {
                return this.mSKU_Unit_Price;
            }
            set
            {
                this.mSKU_Unit_Price = value;
            }
        }

        public long SKUBrand_ID
        {
            get
            {
                return this.mSKUBrand_ID;
            }
            set
            {
                this.mSKUBrand_ID = value;
            }
        }

        public long SKUCase_Units
        {
            get
            {
                return this.mSKUCase_Units;
            }
            set
            {
                this.mSKUCase_Units = value;
            }
        }

        public long SKUCatg_ID
        {
            get
            {
                return this.mSKUCatg_ID;
            }
            set
            {
                this.mSKUCatg_ID = value;
            }
        }

        public string SKUCode
        {
            get
            {
                return this.mSKUCode;
            }
            set
            {
                this.mSKUCode = value;
            }
        }

        public long SKUComapny_ID
        {
            get
            {
                return this.mSKUCompany_ID;
            }
            set
            {
                this.mSKUCompany_ID = value;
            }
        }

        public long SKUDiv_ID
        {
            get
            {
                return this.mSKUDiv_ID;
            }
            set
            {
                this.mSKUDiv_ID = value;
            }
        }

        public string SKUName
        {
            get
            {
                return this.mSKUName;
            }
            set
            {
                this.mSKUName = value;
            }
        }

        public long SKUProductLine_ID
        {
            get
            {
                return this.mSKUProductLine_ID;
            }
            set
            {
                this.mSKUProductLine_ID = value;
            }
        }

        public decimal Tax_Price_Case
        {
            get
            {
                return this.mTax_PriceCase;
            }
            set
            {
                this.mTax_PriceCase = value;
            }
        }

        public decimal Tax_Price_Dozen
        {
            get
            {
                return this.mTax_PriceDozen;
            }
            set
            {
                this.mTax_PriceDozen = value;
            }
        }

        public decimal Tax_Price_Unit
        {
            get
            {
                return this.mTax_PriceUnit;
            }
            set
            {
                this.mTax_PriceUnit = value;
            }
        }

        public decimal Trade_Price_Case
        {
            get
            {
                return this.mTrade_PriceCase;
            }
            set
            {
                this.mTrade_PriceCase = value;
            }
        }

        public decimal Trade_Price_Dozen
        {
            get
            {
                return this.mTrade_PriceDozen;
            }
            set
            {
                this.mTrade_PriceDozen = value;
            }
        }

        public decimal Trade_Price_Unit
        {
            get
            {
                return this.mTrade_PriceUnit;
            }
            set
            {
                this.mTrade_PriceUnit = value;
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

