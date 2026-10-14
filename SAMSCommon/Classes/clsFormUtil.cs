namespace SAMS.Common.Classes
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Windows.Forms;

    public class clsFormUtil
    {
        private clsFormUtil()
        {
        }

        public static void FillComboBox(ComboBox pCboControl, ArrayList pObjList)
        {
            FillComboBox(pCboControl, pObjList, false);
        }

        public static void FillComboBox(ComboBox pCboControl, ArrayList pObjList, bool pBClearListItems)
        {
            if (pObjList != null)
            {
                if (pBClearListItems)
                {
                    pCboControl.Items.Clear();
                }
                for (int i = 0; i < pObjList.Count; i++)
                {
                    pCboControl.Items.Add((clsListItems) pObjList[i]);
                }
            }
            else
            {
                pCboControl.Items.Clear();
            }
        }

        public static void FillComboBox(ComboBox pCboControl, DataTable pObjTable, string KeyFieldName, string TextFieldName)
        {
            FillComboBox(pCboControl, pObjTable, KeyFieldName, TextFieldName, false);
        }

        public static void FillComboBox(ComboBox pCboControl, DataTable pObjTable, string KeyFieldName, string TextFieldName, bool pBClearListItems)
        {
            if (pObjTable != null)
            {
                if (pBClearListItems)
                {
                    pCboControl.Items.Clear();
                }
                foreach (DataRow row in pObjTable.Rows)
                {
                    pCboControl.Items.Add(new clsListItems(row[TextFieldName].ToString(), row[KeyFieldName].ToString()));
                }
            }
            else
            {
                pCboControl.Items.Clear();
            }
        }

        public static void FillListBox(ListBox pLstControl, ArrayList pObjList)
        {
            FillListBox(pLstControl, pObjList, false);
        }

        public static void FillListBox(ListBox pLstControl, ArrayList pObjList, bool pBClearListItems)
        {
            FillListBox(pLstControl, pObjList, pBClearListItems, true);
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
                        pLstControl.Items.Add((clsListItems) pObjList[i]);
                    }
                    if (pBSortList)
                    {
                        pLstControl.Sorted = true;
                    }
                }
                else
                {
                    pLstControl.Items.Clear();
                }
            }
        }

        public static int GetComboBoxItemIndexByKey(ComboBox pCboControl, object pObjItemKey)
        {
            clsListItems items = null;
            for (int i = 0; i < pCboControl.Items.Count; i++)
            {
                items = (clsListItems) pCboControl.Items[i];
                if (items.ItemKey.Equals(pObjItemKey.ToString()))
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetListItemKey(ComboBox pCboSource)
        {
            return GetListItemKey(pCboSource, pCboSource.SelectedIndex);
        }

        public static string GetListItemKey(ComboBox pCboSource, int pNIndex)
        {
            return GetListItemKey(pCboSource, pNIndex, null);
        }

        public static string GetListItemKey(ComboBox pCboSource, string pStrDefaultErrorValue)
        {
            return GetListItemKey(pCboSource, pCboSource.SelectedIndex, pStrDefaultErrorValue);
        }

        public static string GetListItemKey(ComboBox pCboSource, int pNIndex, string pStrDefaultErrorValue)
        {
            string str = pStrDefaultErrorValue;
            clsListItems items = null;
            if (pNIndex > -1)
            {
                items = (clsListItems) pCboSource.Items[pNIndex];
                str = (items == null) ? pStrDefaultErrorValue : items.ItemKey;
            }
            return str;
        }

        public static void SelectComboBoxItemByKey(ComboBox pCboControl, object pObjKey)
        {
            pCboControl.SelectedIndex = GetComboBoxItemIndexByKey(pCboControl, pObjKey);
        }

        public static void SetControlsEnablity(bool pBEnable, params Control[] pObjControls)
        {
            foreach (Control control in pObjControls)
            {
                control.Enabled = pBEnable;
            }
        }

        public static void SetControlsText(string pStrTextValue, params Control[] pObjTextControls)
        {
            foreach (TextBoxBase base2 in pObjTextControls)
            {
                base2.Text = pStrTextValue;
            }
        }

        public static void SetControlsTextAndEnability(string pStrTextValue, bool pBEnable, params Control[] pObjTextControls)
        {
            foreach (TextBoxBase base2 in pObjTextControls)
            {
                base2.Text = pStrTextValue;
                base2.Enabled = pBEnable;
            }
        }

        public static void SetDateTimePickerValue(params DateTimePicker[] pDtpControls)
        {
            SetDateTimePickerValue(DateTime.Now, pDtpControls);
        }

        public static void SetDateTimePickerValue(DateTime pDtmValue, params DateTimePicker[] pDtpControls)
        {
            foreach (DateTimePicker picker in pDtpControls)
            {
                picker.Value = pDtmValue;
            }
        }

        public static void SetEntryButtonsEnabilityByCapiton(Button pBtnEntry, string pStrEntryCaption, string pStrSaveCaption, params Control[] pObjDependentControls)
        {
            if (pBtnEntry.Text == pStrSaveCaption)
            {
                pBtnEntry.Text = pStrEntryCaption;
                SetControlsEnablity(false, pObjDependentControls);
            }
            else
            {
                pBtnEntry.Text = pStrSaveCaption;
                SetControlsEnablity(true, pObjDependentControls);
            }
        }

        public static void SetListControlsSelectedIndex(int pNIndex, params ListControl[] pObjListControls)
        {
            foreach (ListControl control in pObjListControls)
            {
                control.SelectedIndex = pNIndex;
            }
        }
    }
}

