namespace SAMS.Common.Classes
{
    using System;
    using System.Web.UI.WebControls;

    public class clsListItems
    {
        private int imageIndex;
        private string m_itemKey;
        private string m_itemString;

        public clsListItems()
        {
            this.imageIndex = -1;
        }

        public clsListItems(string itmString, string itmKey)
        {
            this.imageIndex = -1;
            this.m_itemString = itmString;
            this.m_itemKey = itmKey;
        }

        public static implicit operator ListItem(clsListItems pObjListItem)
        {
            return new ListItem(pObjListItem.m_itemString, pObjListItem.m_itemKey);
        }

        public static clsListItems ToListItem(ListItem pObjListItem)
        {
            return new clsListItems(pObjListItem.Text, pObjListItem.Value);
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

