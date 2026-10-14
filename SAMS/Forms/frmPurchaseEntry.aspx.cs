using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_frmPurchaseEntry : System.Web.UI.Page
{
    private DataControl dc = new DataControl();
    private static int FreePrivousQty;
    private SKUPriceDetailController PController = new SKUPriceDetailController();
    private static int PrivouseQty;
    private DataTable PurchaseSKU;
    private static int RowNo;
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        DataTable table = (DataTable)this.Session["Dtsku_Price"];
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] rowArray = table.Select("SKU_CODE  = '" + this.txtskuCode.Text + "'");
        if (rowArray.Length > 0)
        {
            decimal.Parse(this.dc.chkNull_0(rowArray[0]["DISTRIBUTOR_DISCOUNT"].ToString()));
            decimal.Parse(this.dc.chkNull_0(rowArray[0]["GST_RATE_TP"].ToString()));
            int num = this.CheckStockStatus(int.Parse(this.dc.chkNull_0(rowArray[0]["SKU_ID"].ToString())));
            if (this.btnSave.Text == "Add Sku")
            {
                if (!this.CheckDublicateSKU())
                {
                    ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('  " + this.txtskuCode.Text + " Already Exists ');", true);
                    this.txtskuName.Text = rowArray[0]["SKU_NAME"].ToString();
                    return;
                }
                if (num != -1)
                {
                    ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('  " + this.txtskuCode.Text + " Current closing Stock is " + num.ToString() + "');", true);
                    this.txtskuName.Text = rowArray[0]["SKU_NAME"].ToString();
                    return;
                }
                DataRow row = this.PurchaseSKU.NewRow();
                row["SKU_ID"] = rowArray[0]["SKU_ID"];
                row["SKU_Code"] = rowArray[0]["SKU_CODE"];
                row["SKU_Name"] = rowArray[0]["SKU_NAME"];
                row["BATCH_NO"] = this.txtBatchNo.Text;
                row["FREE_SKU"] = int.Parse(this.dc.chkNull_0(this.txtFreeSKU.Text));
                row["PRICE"] = rowArray[0]["TRADE_PRICE"];
                row["Quantity"] = int.Parse(this.dc.chkNull_0(this.txtQuantity.Text));
                row["AMOUNT"] = decimal.Parse(rowArray[0]["TRADE_PRICE"].ToString()) * decimal.Parse(this.dc.chkNull_0(this.txtQuantity.Text));
                this.PurchaseSKU.Rows.Add(row);
            }
            else if (this.btnSave.Text == "Update Sku")
            {
                if (num != -1)
                {
                    ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('  " + this.txtskuCode.Text + "Current closing Stock is " + num.ToString() + "');", true);
                    this.txtskuName.Text = rowArray[0]["SKU_NAME"].ToString();
                    return;
                }
                DataRow row2 = this.PurchaseSKU.Rows[RowNo];
                row2["SKU_ID"] = rowArray[0]["SKU_ID"];
                row2["SKU_Code"] = rowArray[0]["SKU_CODE"];
                row2["SKU_Name"] = rowArray[0]["SKU_NAME"];
                row2["BATCH_NO"] = this.txtBatchNo.Text;
                row2["PRICE"] = rowArray[0]["TRADE_PRICE"];
                row2["Quantity"] = int.Parse(this.txtQuantity.Text);
                row2["FREE_SKU"] = int.Parse(this.dc.chkNull_0(this.txtFreeSKU.Text));
                row2["AMOUNT"] = decimal.Parse(rowArray[0]["TRADE_PRICE"].ToString()) * decimal.Parse(this.dc.chkNull_0(this.txtQuantity.Text));
            }
            this.Session.Add("PurchaseSKU", this.PurchaseSKU);
            this.ClearAll();
            this.LoadGird();
            this.DisAbaleOption(true);
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtskuCode);
        }
        else
        {
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Wrong SKU Select');", true);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
        if (((this.DrpDocumentType.SelectedIndex == 2) || (this.DrpDocumentType.SelectedIndex == 3)) && (this.drpDistributor.SelectedValue.ToString() == this.DrpTransferFor.SelectedValue.ToString()))
        {
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert(' Transfer to Location must be different ');", true);
        }
        else
        {
            this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
            if (this.PurchaseSKU.Rows.Count > 0)
            {
                DataTable table = new SAMSUserController().SelectMaxDayClose(-2147483648, int.Parse(this.drpDistributor.SelectedValue.ToString()));
                if (table.Rows.Count <= 0)
                {
                    ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Wrong Location');", true);
                }
                else if (this.CalculatePurchase(DateTime.Parse(table.Rows[0]["CLOSING_DATE"].ToString())))
                {
                    this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
                    this.PurchaseSKU.Rows.Clear();
                    this.Session.Add("PurchaseSKU", this.PurchaseSKU);
                    this.LoadGird();
                    this.GetDocumentNo();
                    this.drpDistributor.Enabled = true;
                    this.drpPrincipal.Enabled = true;
                    this.DrpDocumentType.Enabled = true;
                    this.ClearAll();
                    this.txtBuiltyNo.Text = "";
                    this.txtDocumentNo.Text = "";
                    this.txtDocumentNo.Text = "";
                    this.DisAbaleOption(false);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert(' At least one SKU must enter');", true);
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.DisAbaleOption(false);
        this.CreatTable();
        this.LoadGird();
        this.ClearAll();
        this.txtDocumentNo.Text = "";
        this.txtBuiltyNo.Text = "";
        this.txtDocumentNo.Text = "";
    }

    private bool CalculatePurchase(DateTime MWorkDate)
    {
        decimal num = 0M;
        PurchaseController controller = new PurchaseController();
        DataTable table = (DataTable)this.Session["PurchaseSKU"];
        foreach (DataRow row in table.Rows)
        {
            num += decimal.Parse(row["AMOUNT"].ToString());
        }
        if (this.DrpDocumentType.SelectedIndex == 0)
        {
            long num2 = -9223372036854775808L;
            if (this.drpDocumentNo.SelectedValue.ToString() == num2.ToString())
            {
                return controller.InsertPurchaseDocument(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            return controller.UpdatePurchaseDocument((long)int.Parse(this.drpDocumentNo.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
        }
        if (this.DrpDocumentType.SelectedIndex == 1)
        {
            long num3 = -9223372036854775808L;
            if (this.drpDocumentNo.SelectedValue.ToString() == num3.ToString())
            {
                return controller.InsertPurchaseDocument(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.DrpTransferFor.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            return controller.UpdatePurchaseDocument((long)int.Parse(this.drpDocumentNo.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.DrpTransferFor.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
        }
        if (this.DrpDocumentType.SelectedIndex == 2)
        {
            long num4 = -9223372036854775808L;
            if (this.drpDocumentNo.SelectedValue.ToString() == num4.ToString())
            {
                return controller.InsertPurchaseDocument(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            return controller.UpdatePurchaseDocument((long)int.Parse(this.drpDocumentNo.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
        }
        if (this.DrpDocumentType.SelectedIndex == 3)
        {
            long num5 = -9223372036854775808L;
            if (this.drpDocumentNo.SelectedValue.ToString() == num5.ToString())
            {
                return controller.InsertPurchaseDocument(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpTransferFor.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            return controller.UpdatePurchaseDocument((long)int.Parse(this.drpDocumentNo.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpTransferFor.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
        }
        long num6 = -9223372036854775808L;
        if (this.drpDocumentNo.SelectedValue.ToString() == num6.ToString())
        {
            return controller.InsertPurchaseDocument(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
        }
        return controller.UpdatePurchaseDocument((long)int.Parse(this.drpDocumentNo.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), MWorkDate, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()), num, false, table, 0, this.txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
    }

    protected void ChbBatchNo_CheckedChanged(object sender, EventArgs e)
    {
        if (this.ChbBatchNo.Checked)
        {
            this.lblBatchNo.Enabled = true;
            this.txtBatchNo.Enabled = true;
        }
        else
        {
            this.txtBatchNo.Text = "N/A";
            this.lblBatchNo.Enabled = false;
            this.txtBatchNo.Enabled = false;
        }
    }

    protected void ChbFreeSKU_CheckedChanged(object sender, EventArgs e)
    {
        if (this.ChbFreeSKU.Checked)
        {
            this.lblFreeSKU.Enabled = true;
            this.txtFreeSKU.Enabled = true;
        }
        else
        {
            this.txtFreeSKU.Text = "0";
            this.lblFreeSKU.Enabled = false;
            this.txtFreeSKU.Enabled = false;
        }
    }

    private bool CheckDublicateSKU()
    {
        new DataControl();
        DataTable table1 = (DataTable)this.Session["Dtsku_Price"];
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        return (this.PurchaseSKU.Select("SKU_CODE  = '" + this.txtskuCode.Text + "'").Length == 0);
    }

    private int CheckStockStatus(int SKU_ID)
    {
        if ((this.DrpDocumentType.SelectedIndex == 0) || (this.DrpDocumentType.SelectedIndex == 3))
        {
            return -1;
        }
        DataTable table = new PurchaseController().SelectSKUClosingStock(int.Parse(this.drpDistributor.SelectedValue.ToString()), SKU_ID, this.txtBatchNo.Text);
        if (table.Rows.Count <= 0)
        {
            return 0;
        }
        if (((int.Parse(table.Rows[0][0].ToString()) + PrivouseQty) + FreePrivousQty) >= int.Parse(this.txtQuantity.Text))
        {
            return -1;
        }
        return ((int.Parse(table.Rows[0][0].ToString()) + PrivouseQty) + FreePrivousQty);
    }

    private void ClearAll()
    {
        this.txtskuCode.Text = "";
        this.txtskuName.Text = "";
        this.txtQuantity.Text = "";
        this.txtFreeSKU.Text = "0";
        this.txtBatchNo.Text = "N/A";
        this.txtskuCode.Enabled = true;
        this.btnSave.Text = "Add Sku";
        PrivouseQty = 0;
        FreePrivousQty = 0;
    }

    private void CreatTable()
    {
        this.PurchaseSKU = new DataTable();
        this.PurchaseSKU.Columns.Add("PURCHASE_DETAIL_ID", typeof(long));
        this.PurchaseSKU.Columns.Add("SKU_ID", typeof(int));
        this.PurchaseSKU.Columns.Add("SKU_Code", typeof(string));
        this.PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
        this.PurchaseSKU.Columns.Add("BATCH_NO", typeof(string));
        this.PurchaseSKU.Columns.Add("PRICE", typeof(decimal));
        this.PurchaseSKU.Columns.Add("Quantity", typeof(int));
        this.PurchaseSKU.Columns.Add("FREE_SKU", typeof(int));
        this.PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
        this.Session.Add("PurchaseSKU", this.PurchaseSKU);
    }

    private void DisAbaleOption(bool IsDisable)
    {
        if (IsDisable)
        {
            this.DrpDocumentType.Enabled = false;
            this.drpPrincipal.Enabled = false;
            this.drpDistributor.Enabled = false;
            this.drpDocumentNo.Enabled = false;
        }
        else
        {
            this.DrpDocumentType.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.drpDistributor.Enabled = true;
            this.drpDocumentNo.Enabled = true;
            this.drpDocumentNo.SelectedIndex = 0;
        }
    }

    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        long num = -9223372036854775808L;
        if (this.drpDocumentNo.SelectedValue.ToString() == num.ToString())
        {
            this.CreatTable();
            this.Session.Add("PurchaseSKU", this.PurchaseSKU);
            this.LoadGird();
            this.ClearAll();
            this.drpPrincipal.Enabled = true;
            this.drpDistributor.Enabled = true;
            this.DrpDocumentType.Enabled = true;
        }
        else
        {
            this.txtBuiltyNo.Text = "";
            this.txtDocumentNo.Text = "";
            this.drpPrincipal.Enabled = false;
            this.drpDistributor.Enabled = false;
            this.DrpDocumentType.Enabled = false;
            this.LoadDocumentDetail();
            this.LoadSKUDetail();
        }
    }

    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DrpDocumentType.SelectedIndex == 0)
        {
            this.lbltoLocation.Text = "Principal";
            this.lblfromLocation.Text = "Purchase For";
            this.drpDistributor.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            this.Label4.Visible = false;
            this.GetDocumentNo();
        }
        else if (this.DrpDocumentType.SelectedIndex == 1)
        {
            this.lblfromLocation.Text = "Transfer From";
            this.drpDistributor.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.LoadToDistributor();
            this.DrpTransferFor.Visible = true;
            this.Label4.Visible = true;
            this.Label4.Text = "Transfer To";
            this.GetDocumentNo();
        }
        else if (this.DrpDocumentType.SelectedIndex == 2)
        {
            this.lbltoLocation.Text = "Principal";
            this.lblfromLocation.Text = "Return From";
            this.drpDistributor.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            this.Label4.Visible = false;
            this.GetDocumentNo();
        }
        else if (this.DrpDocumentType.SelectedIndex == 3)
        {
            this.lblfromLocation.Text = "Transfer to";
            this.drpDistributor.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.LoadToDistributor();
            this.DrpTransferFor.Visible = true;
            this.Label4.Visible = true;
            this.Label4.Text = "Transfer From";
            this.GetDocumentNo();
        }
        else
        {
            this.lbltoLocation.Text = "Principal";
            this.lblfromLocation.Text = "Location";
            this.drpDistributor.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            this.Label4.Visible = false;
            this.GetDocumentNo();
        }
    }

    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
    }

    protected void DrpTransferFor_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void GetDocumentNo()
    {
        this.drpDocumentNo.Items.Clear();
        DateTime now = DateTime.Now;
        DataTable table = new PurchaseController().SelectPurchaseDocumentNo(int.Parse(this.DrpDocumentType.SelectedValue.ToString()), -2147483648, -9223372036854775808L, int.Parse(this.Session["UserId"].ToString()), 0);
        long num = -9223372036854775808L;
        this.drpDocumentNo.Items.Add((ListItem)new clsListItems("New", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDocumentNo, table, 0, 0);
    }

    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        if (this.PurchaseSKU.Rows.Count > 0)
        {
            this.PurchaseSKU.Rows.RemoveAt(e.RowIndex);
            this.Session.Add("PurchaseSKU", this.PurchaseSKU);
            this.LoadGird();
        }
    }

    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowNo = e.NewEditIndex;
        this.txtskuCode.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtskuName.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtQuantity.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        PrivouseQty = int.Parse(this.GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text);
        FreePrivousQty = int.Parse(this.GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text);
        this.txtFreeSKU.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        this.txtBatchNo.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtskuCode.Enabled = false;
        this.txtQuantity.Focus();
        this.btnSave.Text = "Update Sku";
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadDocumentDetail()
    {
        DateTime now = DateTime.Now;
        PurchaseController controller = new PurchaseController();
        DataTable table = controller.SelectPurchaseDocumentNo(-2147483648, -2147483648, long.Parse(this.drpDocumentNo.SelectedValue.ToString()), -2147483648, -2147483648);
        if (table.Rows.Count > 0)
        {
            if ((this.DrpDocumentType.SelectedIndex == 0) || (this.DrpDocumentType.SelectedIndex == 4))
            {
                this.drpDistributor.SelectedValue = table.Rows[0]["SOLD_TO"].ToString();
                this.drpPrincipal.SelectedValue = table.Rows[0]["SOLD_FROM"].ToString();
                this.txtDocumentNo.Text = table.Rows[0][2].ToString();
                this.txtBuiltyNo.Text = table.Rows[0]["BUILTY_NO"].ToString();
            }
            else if (this.DrpDocumentType.SelectedIndex == 1)
            {
                this.drpDistributor.SelectedValue = table.Rows[0]["SOLD_FROM"].ToString();
                this.DrpTransferFor.SelectedValue = table.Rows[0]["SOLD_TO"].ToString();
                this.txtDocumentNo.Text = table.Rows[0][2].ToString();
                this.txtBuiltyNo.Text = table.Rows[0]["BUILTY_NO"].ToString();
            }
            else if (this.DrpDocumentType.SelectedIndex == 2)
            {
                this.drpPrincipal.SelectedValue = table.Rows[0]["SOLD_TO"].ToString();
                this.drpDistributor.SelectedValue = table.Rows[0]["SOLD_FROM"].ToString();
                this.txtDocumentNo.Text = table.Rows[0][2].ToString();
                this.txtBuiltyNo.Text = table.Rows[0]["BUILTY_NO"].ToString();
            }
            else
            {
                this.DrpTransferFor.SelectedValue = table.Rows[0]["SOLD_FROM"].ToString();
                this.drpDistributor.SelectedValue = table.Rows[0]["SOLD_TO"].ToString();
                this.txtDocumentNo.Text = table.Rows[0][2].ToString();
                this.txtBuiltyNo.Text = table.Rows[0]["BUILTY_NO"].ToString();
            }
            this.PurchaseSKU = controller.SelectPurchaseDetail(-2147483648, long.Parse(table.Rows[0][0].ToString()));
            this.Session.Add("PurchaseSKU", this.PurchaseSKU);
            this.LoadGird();
        }
    }

    private void LoadGird()
    {
        int num = 0;
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        this.GrdPurchase.DataSource = this.PurchaseSKU;
        this.GrdPurchase.DataBind();
        foreach (DataRow row in this.PurchaseSKU.Rows)
        {
            num += int.Parse(row["Quantity"].ToString());
        }
        this.txtTotalQuantity.Text = num.ToString();
    }

    private void LoadPrincipal()
    {
        DataTable table = this.PController.SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, table, 0, 1, true);
    }

    private void LoadSKUDetail()
    {
        if (this.drpPrincipal.Items.Count > 0)
        {
            DataTable table = this.PController.SelectDataPrice(int.Parse(this.drpPrincipal.SelectedValue.ToString()), -2147483648, -2147483648, -2147483648, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), -2147483648, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, table, 9, 9, true);
            this.Session.Add("Dtsku_Price", table);
        }
    }

    private void LoadToDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpTransferFor, table, 0, 2, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadSKUDetail();
            this.CreatTable();
            this.GetDocumentNo();
            this.btnSave.Attributes.Add("onclick", "return ValidateForm();");
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
        }
    }
}