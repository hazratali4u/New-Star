namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class SKUGroup_Collection
    {
        private int mSKU_GROUP_DETAIL_ID;
        private int mSKU_ID;
        private int mSKUGroup_ID;

        public int SKU_GROUP_DETAIL_ID
        {
            get
            {
                return this.mSKU_GROUP_DETAIL_ID;
            }
            set
            {
                this.mSKU_GROUP_DETAIL_ID = value;
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

        public int SKUGroup_ID
        {
            get
            {
                return this.mSKUGroup_ID;
            }
            set
            {
                this.mSKUGroup_ID = value;
            }
        }
    }
}

