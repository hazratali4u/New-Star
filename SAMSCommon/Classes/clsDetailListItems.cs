namespace SAMS.Common.Classes
{
    using System;

    public class clsDetailListItems
    {
        private int imageIndex;
        private string m_itemKey;
        private string m_itemParentKey;
        private string m_itemString;
        private bool m_itemType;

        public clsDetailListItems()
        {
            this.imageIndex = -1;
        }

        public clsDetailListItems(bool itmType, string itmString, string itmParentKey, string itmKey)
        {
            this.imageIndex = -1;
            this.m_itemType = itmType;
            this.m_itemString = itmString;
            this.m_itemParentKey = itmParentKey;
            this.m_itemKey = itmKey;
        }

        public override string ToString()
        {
            return this.m_itemString;
        }

        public int ImageIndex
        {
            get
            {
                return this.imageIndex;
            }
            set
            {
                this.imageIndex = value;
            }
        }

        public string ItemKey
        {
            get
            {
                return this.m_itemKey;
            }
            set
            {
                this.m_itemKey = value;
            }
        }

        public string ItemParentKey
        {
            get
            {
                return this.m_itemParentKey;
            }
            set
            {
                this.m_itemParentKey = value;
            }
        }

        public string ItemString
        {
            get
            {
                return this.m_itemString;
            }
            set
            {
                this.m_itemString = value;
            }
        }

        public bool ItemType
        {
            get
            {
                return this.m_itemType;
            }
            set
            {
                this.m_itemType = value;
            }
        }
    }
}

