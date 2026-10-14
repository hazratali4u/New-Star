using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmPysicalStockteken : System.Web.UI.Page
{
    private DataControl dc = new DataControl();
    private DataTable PurchaseSKU;
    private static int RowNo;

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        DataTable table = (DataTable)this.Session["Dtsku_Price"];
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] rowArray = table.Select("SKU_CODE  = '" + this.txtskuCode.Text + "'");
        DataControl control = new DataControl();
        if (rowArray.Length > 0)
        {
            ControllerPaysical paysical = new ControllerPaysical();
            if (this.btnSave.Text == "Save")
            {
                paysical.InsertPysicalStock(int.Parse(this.drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(rowArray[0]["SKU_ID"].ToString()), int.Parse(control.chkNull_0(this.txtQuantity.Text)), int.Parse(control.chkNull_0(this.txtusaleableqty.Text)), decimal.Parse(this.txtUnitRate.Text), 0, int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            else
            {
                paysical.UpdatePysicalStock(int.Parse(this.drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(rowArray[0]["SKU_ID"].ToString()), int.Parse(control.chkNull_0(this.txtQuantity.Text)), int.Parse(control.chkNull_0(this.txtusaleableqty.Text)), decimal.Parse(this.txtUnitRate.Text), 0, int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            }
            this.LoadGird();
            this.ClearAll();
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtskuCode);
        }
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
        this.txtusaleableqty.Text = "";
        this.txtUnitRate.Text = "0";
        this.txtskuCode.Enabled = true;
        this.btnSave.Text = "Save";
    }

    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGird();
        this.LoadSKUDetail();
    }

    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new ControllerPaysical().DELETEPysicalStock(int.Parse(this.drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(this.GrdPurchase.Rows[e.RowIndex].Cells[0].Text));
        this.LoadGird();
    }

    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowNo = e.NewEditIndex;
        this.txtskuCode.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtskuName.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtQuantity.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        this.txtusaleableqty.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        this.txtUnitRate.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtQuantity.Focus();
        this.btnSave.Text = "Update Sku";
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadGird()
    {
        DataTable table = new ControllerPaysical().SelectPysicalStock(int.Parse(this.drpDistributor.SelectedValue.ToString()), 0, int.Parse(this.drpPrincipal.SelectedValue.ToString()));
        this.GrdPurchase.DataSource = table;
        this.GrdPurchase.DataBind();
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, table, 0, 1, true);
    }

    private void LoadSKUDetail()
    {
        if (this.drpPrincipal.Items.Count > 0)
        {
            DataTable table = new SKUPriceDetailController().SelectDataPrice(int.Parse(this.drpPrincipal.SelectedValue.ToString()), -2147483648, -2147483648, -2147483648, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), int.Parse(this.Session["UserId"].ToString()), -2147483648, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, table, 10, 10, true);
            this.Session.Add("Dtsku_Price", table);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadSKUDetail();
            this.LoadGird();
        }
    }
}