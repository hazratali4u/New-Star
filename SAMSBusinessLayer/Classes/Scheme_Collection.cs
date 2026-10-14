namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class Scheme_Collection
    {
        private int mDist_ID;
        private string mScheme_Code;
        private DateTime mScheme_date;
        private string mScheme_Desc;
        private int mScheme_ID;
        private PromotionCollections_Controller objPromotionCol_Cntrl;

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

        public PromotionCollections_Controller ObjPromotionCol_Cntrl
        {
            get
            {
                return this.objPromotionCol_Cntrl;
            }
            set
            {
                this.objPromotionCol_Cntrl = value;
            }
        }

        public string Scheme_Code
        {
            get
            {
                return this.mScheme_Code;
            }
            set
            {
                this.mScheme_Code = value;
            }
        }

        public DateTime Scheme_date
        {
            get
            {
                return this.mScheme_date;
            }
            set
            {
                this.mScheme_date = value;
            }
        }

        public string Scheme_Desc
        {
            get
            {
                return this.mScheme_Desc;
            }
            set
            {
                this.mScheme_Desc = value;
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
    }
}

