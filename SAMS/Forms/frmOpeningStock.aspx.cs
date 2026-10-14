using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_frmOpeningStock : System.Web.UI.Page
{
    private DataControl dc = new DataControl();
    private SKUPriceDetailController PController = new SKUPriceDetailController();
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
            decimal.Parse(this.dc.chkNull_0(rowArray[0]["GST_RATE_REG"].ToString()));
            if (this.btnSave.Text == "Add Sku")
            {
                if (!this.CheckDublicateSKU())
                {
                    ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('  " + this.txtskuCode.Text + " Already Exists ');", true);
                    this.txtskuName.Text = rowArray[0]["SKU_NAME"].ToString();
                    return;
                }
                DataRow row = this.PurchaseSKU.NewRow();
                row["SKU_ID"] = rowArray[0]["SKU_ID"];
                row["SKU_Code"] = rowArray[0]["SKU_CODE"];
                row["SKU_Name"] = rowArray[0]["SKU_NAME"];
                row["BATCH_NO"] = this.txtBatchNo.Text;
                row["FREE_SKU"] = int.Parse(this.dc.chkNull_0(this.txtFreeSKU.Text));
                row["PRICE"] = rowArray[0]["DISTRIBUTOR_PRICE"];
                row["Quantity"] = int.Parse(this.dc.chkNull_0(this.txtQuantity.Text));
                row["AMOUNT"] = decimal.Parse(rowArray[0]["DISTRIBUTOR_PRICE"].ToString()) * decimal.Parse(this.dc.chkNull_0(this.txtQuantity.Text));
                this.PurchaseSKU.Rows.Add(row);
            }
            else if (this.btnSave.Text == "Update Sku")
            {
                DataRow row2 = this.PurchaseSKU.Rows[RowNo];
                row2["SKU_ID"] = rowArray[0]["SKU_ID"];
                row2["SKU_Code"] = rowArray[0]["SKU_CODE"];
                row2["SKU_Name"] = rowArray[0]["SKU_NAME"];
                row2["BATCH_NO"] = this.txtBatchNo.Text;
                row2["PRICE"] = rowArray[0]["DISTRIBUTOR_PRICE"];
                row2["Quantity"] = int.Parse(this.txtQuantity.Text);
                row2["FREE_SKU"] = int.Parse(this.dc.chkNull_0(this.txtFreeSKU.Text));
                row2["AMOUNT"] = decimal.Parse(rowArray[0]["DISTRIBUTOR_PRICE"].ToString()) * decimal.Parse(this.dc.chkNull_0(this.txtQuantity.Text));
            }
            this.Session.Add("PurchaseSKU", this.PurchaseSKU);
            this.ClearAll();
            this.LoadGird();
            this.DisAbaleOption(true);
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtskuCode);
        }
        else
        {
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Wrong SKU please check in list');", true);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        DataTable table = new SAMSUserController().SelectMaxDayClose(-2147483648, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (table.Rows.Count > 0)
        {
            DateTime time = DateTime.Parse(table.Rows[0]["CLOSING_DATE"].ToString());
            PurchaseController controller2 = new PurchaseController();
            DataTable table2 = (DataTable)this.Session["PurchaseSKU"];
            decimal num = 0M;
            foreach (DataRow row in table2.Rows)
            {
                num += decimal.Parse(row["AMOUNT"].ToString());
            }
            long num2 = -9223372036854775808L;
            if (this.drpDocumentNo.SelectedValue.ToString() == num2.ToString())
            {
                controller2.InsertPurchaseDocument(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), time, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()), num, false, table2, 0, null, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            else
            {
                controller2.UpdatePurchaseDocument((long)int.Parse(this.drpDocumentNo.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), this.txtDocumentNo.Text, int.Parse(this.DrpDocumentType.SelectedValue.ToString()), time, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()), num, false, table2, 0, null, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            this.lblErrorMsg.Text = "Record Upated";
            this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
            this.PurchaseSKU.Rows.Clear();
            this.Session.Add("PurchaseSKU", this.PurchaseSKU);
            this.LoadGird();
            this.GetDocumentNo();
            this.drpDistributor.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.DrpDocumentType.Enabled = true;
            this.ClearAll();
            this.txtDocumentNo.Text = "";
            this.DisAbaleOption(false);
        }
        else
        {
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Wrong Location or Unassigne');", true);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.CreatTable();
        this.LoadGird();
        this.drpDistributor.Enabled = true;
        this.drpPrincipal.Enabled = true;
        this.DrpDocumentType.Enabled = true;
        this.ClearAll();
        this.txtDocumentNo.Text = "";
        this.DisAbaleOption(false);
    }

    protected void ChbBatchNo_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void ChbFreeSKU_CheckedChanged(object sender, EventArgs e)
    {
    }

    private bool CheckDublicateSKU()
    {
        new DataControl();
        DataTable table1 = (DataTable)this.Session["Dtsku_Price"];
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        return (this.PurchaseSKU.Select("SKU_CODE  = '" + this.txtskuCode.Text + "'").Length == 0);
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
        this.lblErrorMsg.Text = "";
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

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
    }

    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        long num = -9223372036854775808L;
        if (this.drpDocumentNo.SelectedValue.ToString() == num.ToString())
        {
            this.CreatTable();
            this.LoadGird();
            this.drpDistributor.Enabled = true;
            this.drpPrincipal.Enabled = true;
            this.DrpDocumentType.Enabled = true;
            this.ClearAll();
            this.txtDocumentNo.Text = "";
            this.DisAbaleOption(false);
        }
        else
        {
            this.LoadDocumentDetail();
            this.LoadSKUDetail();
        }
    }

    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDocumentNo();
    }

    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
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
            this.drpDistributor.SelectedValue = table.Rows[0]["SOLD_TO"].ToString();
            this.drpPrincipal.SelectedValue = table.Rows[0]["SOLD_FROM"].ToString();
            this.txtDocumentNo.Text = table.Rows[0][2].ToString();
            this.PurchaseSKU = controller.SelectPurchaseDetail(-2147483648, long.Parse(table.Rows[0][0].ToString()));
            this.Session.Add("PurchaseSKU", this.PurchaseSKU);
            this.LoadGird();
        }
    }

    private void LoadGird()
    {
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        this.GrdPurchase.DataSource = this.PurchaseSKU;
        this.GrdPurchase.DataBind();
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
            DataTable table = this.PController.SelectDataPrice(int.Parse(this.drpPrincipal.SelectedValue.ToString()), -2147483648, -2147483648, -2147483648, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), -2147483648, 2, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, table, 9, 9, true);
            this.Session.Add("Dtsku_Price", table);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.CreatTable();
            this.GetDocumentNo();
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadSKUDetail();
        }
    }
}