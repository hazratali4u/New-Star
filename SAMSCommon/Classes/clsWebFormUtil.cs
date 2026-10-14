namespace SAMS.Common.Classes
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class clsWebFormUtil
    {
        private clsWebFormUtil()
        {
        }

        public static void FillDropDownList(DropDownList pCboControl, ArrayList pObjList)
        {
            FillDropDownList(pCboControl, pObjList, false);
        }

        public static void FillDropDownList(DropDownList pCboControl, ArrayList pObjList, bool pBClearListItems)
        {
            if (pObjList != null)
            {
                if (pBClearListItems)
                {
                    pCboControl.Items.Clear();
                }
                for (int i = 0; i < pObjList.Count; i++)
                {
                    pCboControl.Items.Add((ListItem) ((clsListItems) pObjList[i]));
                }
            }
            else
            {
                pCboControl.Items.Clear();
            }
        }

        public static void FillDropDownList(DropDownList pCboControl, DataTable pObjTable, int pColKey, int pColValue)
        {
            FillDropDownList(pCboControl, pObjTable, pColKey, pColValue, false);
        }

        public static void FillDropDownList(DropDownList pCboControl, DataTable pObjTable, string pColKey, string pColValue)
        {
            FillDropDownList(pCboControl, pObjTable, pColKey, pColValue, false);
        }

        public static void FillDropDownList(DropDownList pCboControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems)
        {
            if (pObjTable != null)
            {
                if (pBClearListItems)
                {
                    pCboControl.Items.Clear();
                }
                for (int i = 0; i < pObjTable.Rows.Count; i++)
                {
                    pCboControl.Items.Add((ListItem) new clsListItems(pObjTable.Rows[i][pColValue].ToString(), pObjTable.Rows[i][pColKey].ToString()));
                }
            }
            else
            {
                pCboControl.Items.Clear();
            }
        }

        public static void FillDropDownList(DropDownList pCboControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems)
        {
            if (pObjTable != null)
            {
                if (pBClearListItems)
                {
                    pCboControl.Items.Clear();
                }
                for (int i = 0; i < pObjTable.Rows.Count; i++)
                {
                    pCboControl.Items.Add((ListItem) new clsListItems(pObjTable.Rows[i][pColValue].ToString(), pObjTable.Rows[i][pColKey].ToString()));
                }
            }
            else
            {
                pCboControl.Items.Clear();
            }
        }

        public static void FillListBox(CheckBoxList pLstControl, ArrayList pObjList)
        {
            FillListBox(pLstControl, pObjList, false);
        }

        public static void FillListBox(ListBox pLstControl, ArrayList pObjList)
        {
            FillListBox(pLstControl, pObjList, false);
        }

        public static void FillListBox(CheckBoxList pLstControl, ArrayList pObjList, bool pBClearListItems)
        {
            FillListBox(pLstControl, pObjList, pBClearListItems, true);
        }

        public static void FillListBox(ListBox pLstControl, ArrayList pObjList, bool pBClearListItems)
        {
            FillListBox(pLstControl, pObjList, pBClearListItems, true);
        }

        public static void FillListBox(CheckBoxList pLstControl, ArrayList pObjList, bool pBClearListItems, bool pBSortList)
        {
            if (pLstControl != null)
            {
                if (pObjList != null)
                {
                    if (pBClearListItems)
                    {
                        pLstControl.Items.Clear();
                    }
                    for (int i = 0; i < pObjList.Count; i++)
                    {
                        pLstControl.Items.Add((ListItem) ((clsListItems) pObjList[i]));
                    }
                    if (pBSortList)
                    {
                    }
                }
                else
                {
                    pLstControl.Items.Clear();
                }
            }
        }

        public static void FillListBox(CheckBoxList pLstControl, DataTable pObjTable, int pColKey, int pColValue)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, false);
        }

        public static void FillListBox(CheckBoxList pLstControl, DataTable pObjTable, string pColKey, string pColValue)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, false);
        }

        public static void FillListBox(ListBox pLstControl, ArrayList pObjList, bool pBClearListItems, bool pBSortList)
        {
            if (pLstControl != null)
            {
                if (pObjList != null)
                {
                    if (pBClearListItems)
                    {
                        pLstControl.Items.Clear();
                    }
                    for (int i = 0; i < pObjList.Count; i++)
                    {
                        pLstControl.Items.Add((ListItem) ((clsListItems) pObjList[i]));
                    }
                    if (pBSortList)
                    {
                    }
                }
                else
                {
                    pLstControl.Items.Clear();
                }
            }
        }

        public static void FillListBox(ListBox pLstControl, DataTable pObjTable, int pColKey, int pColValue)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, false);
        }

        public static void FillListBox(ListBox pLstControl, DataTable pObjTable, string pColKey, string pColValue)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, false);
        }

        public static void FillListBox(CheckBoxList pLstControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, pBClearListItems, true);
        }

        public static void FillListBox(CheckBoxList pLstControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, pBClearListItems, true);
        }

        public static void FillListBox(ListBox pLstControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, pBClearListItems, true);
        }

        public static void FillListBox(ListBox pLstControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems)
        {
            FillListBox(pLstControl, pObjTable, pColKey, pColValue, pBClearListItems, true);
        }

        public static void FillListBox(CheckBoxList pLstControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems, bool pBSortList)
        {
            if (pLstControl != null)
            {
                if (pObjTable != null)
                {
                    if (pBClearListItems)
                    {
                        pLstControl.Items.Clear();
                    }
                    for (int i = 0; i < pObjTable.Rows.Count; i++)
                    {
                        pLstControl.Items.Add((ListItem) new clsListItems(pObjTable.Rows[i][pColValue].ToString(), pObjTable.Rows[i][pColKey].ToString()));
                    }
                    if (pBSortList)
                    {
                    }
                }
                else
                {
                    pLstControl.Items.Clear();
                }
            }
        }

        public static void FillListBox(CheckBoxList pLstControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems, bool pBSortList)
        {
            if (pLstControl != null)
            {
                if (pObjTable != null)
                {
                    if (pBClearListItems)
                    {
                        pLstControl.Items.Clear();
                    }
                    for (int i = 0; i < pObjTable.Rows.Count; i++)
                    {
                        pLstControl.Items.Add((ListItem) new clsListItems(pObjTable.Rows[i][pColValue].ToString(), pObjTable.Rows[i][pColKey].ToString()));
                    }
                    if (pBSortList)
                    {
                    }
                }
                else
                {
                    pLstControl.Items.Clear();
                }
            }
        }

        public static void FillListBox(ListBox pLstControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems, bool pBSortList)
        {
            if (pLstControl != null)
            {
                if (pObjTable != null)
                {
                    if (pBClearListItems)
                    {
                        pLstControl.Items.Clear();
                    }
                    for (int i = 0; i < pObjTable.Rows.Count; i++)
                    {
                        pLstControl.Items.Add((ListItem) new clsListItems(pObjTable.Rows[i][pColValue].ToString(), pObjTable.Rows[i][pColKey].ToString()));
                    }
                    if (pBSortList)
                    {
                    }
                }
                else
                {
                    pLstControl.Items.Clear();
                }
            }
        }

        public static void FillListBox(ListBox pLstControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems, bool pBSortList)
        {
            if (pLstControl != null)
            {
                if (pObjTable != null)
                {
                    if (pBClearListItems)
                    {
                        pLstControl.Items.Clear();
                    }
                    for (int i = 0; i < pObjTable.Rows.Count; i++)
                    {
                        pLstControl.Items.Add((ListItem) new clsListItems(pObjTable.Rows[i][pColValue].ToString(), pObjTable.Rows[i][pColKey].ToString()));
                    }
                    if (pBSortList)
                    {
                    }
                }
                else
                {
                    pLstControl.Items.Clear();
                }
            }
        }

        public static int GetDropDownListItemIndexByKey(DropDownList pCboControl, object pObjItemKey)
        {
            for (int i = 0; i < pCboControl.Items.Count; i++)
            {
                if (clsListItems.ToListItem(pCboControl.Items[i]).ItemKey.Equals(pObjItemKey.ToString()))
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetListItemKey(DropDownList pCboSource)
        {
            return GetListItemKey(pCboSource, pCboSource.SelectedIndex);
        }

        public static string GetListItemKey(DropDownList pCboSource, int pNIndex)
        {
            return GetListItemKey(pCboSource, pNIndex, null);
        }

        public static string GetListItemKey(DropDownList pCboSource, string pStrDefaultErrorValue)
        {
            return GetListItemKey(pCboSource, pCboSource.SelectedIndex, pStrDefaultErrorValue);
        }

        public static string GetListItemKey(DropDownList pCboSource, int pNIndex, string pStrDefaultErrorValue)
        {
            string str = pStrDefaultErrorValue;
            clsListItems items = null;
            if (pNIndex > -1)
            {
                items = clsListItems.ToListItem(pCboSource.Items[pNIndex]);
                str = (items == null) ? pStrDefaultErrorValue : items.ItemKey;
            }
            return str;
        }

        public static void SelectDropDownListItemByKey(DropDownList pCboControl, object pObjKey)
        {
            pCboControl.SelectedIndex = GetDropDownListItemIndexByKey(pCboControl, pObjKey);
        }

        public static void SetControlsTextAndEnability(string pStrTextValue, bool pBEnable, params Control[] pObjTextControls)
        {
            foreach (TextBox box in pObjTextControls)
            {
                box.Text = pStrTextValue;
                box.Enabled = pBEnable;
            }
        }

        public static void SetEntryButtonsEnabilityByCapiton(Button pBtnEntry, string pStrEntryCaption, string pStrSaveCaption, params WebControl[] pObjDependentControls)
        {
            if (pBtnEntry.Text == pStrSaveCaption)
            {
                pBtnEntry.Text = pStrEntryCaption;
                SetWebControlsEnability(false, pObjDependentControls);
            }
            else
            {
                pBtnEntry.Text = pStrSaveCaption;
                SetWebControlsEnability(true, pObjDependentControls);
            }
        }

        public static void SetListControlsSelectedIndex(int pNIndex, params ListControl[] pObjListControls)
        {
            foreach (ListControl control in pObjListControls)
            {
                control.SelectedIndex = pNIndex;
            }
        }

        public static void SetTextBoxText(string pStrTextValue, params TextBox[] pObjTextControls)
        {
            foreach (TextBox box in pObjTextControls)
            {
                box.Text = pStrTextValue;
            }
        }

        public static void SetWebControlsEnability(bool pBEnable, params WebControl[] pObjControls)
        {
            foreach (WebControl control in pObjControls)
            {
                control.Enabled = pBEnable;
            }
        }
    }
}

