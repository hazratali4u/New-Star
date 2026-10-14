namespace SAMS.Common.Classes
{
    using System;

    public class clsCheckedListItems
    {
        private int imageIndex;
        private bool m_checkState;
        private string m_itemKey;
        private string m_itemString;

        public clsCheckedListItems()
        {
            this.imageIndex = -1;
        }

        public clsCheckedListItems(string pItemString, string pItemKey, bool pCheckState)
        {
            this.imageIndex = -1;
            this.m_itemString = pItemString;
            this.m_itemKey = pItemKey;
            this.m_checkState = pCheckState;
        }

        public override string ToString()
        {
            return this.m_itemString;
        }

        public bool CheckState
        {
            get
            {
                return this.m_checkState;
            }
            set
            {
                this.m_checkState = value;
            }
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
    }
}

