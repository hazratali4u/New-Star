using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmTargetEntry : System.Web.UI.Page
{
    private static long TargetId;
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        TargetController controller = new TargetController();
        DataRow[] rowArray = ((DataTable)this.Session["Dtsku_Price"]).Select("SKU_CODE  = '" + this.txtskuCode.Text + "'");
        if (rowArray.Length > 0)
        {
            if (this.btnSave.Text == "Save")
            {
                controller.InsertTarget(int.Parse(this.drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.txtFromdate.Text), int.Parse(this.DrpTargetType.SelectedValue.ToString()), int.Parse(this.DrpTargetFor.SelectedValue.ToString()), int.Parse(rowArray[0]["SKU_ID"].ToString()), decimal.Parse(rowArray[0]["TRADE_PRICE"].ToString()), int.Parse(this.txtQuantity.Text), int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()));
            }
            else
            {
                controller.UpdateTarget(TargetId, int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtUnitRate.Text), int.Parse(this.txtQuantity.Text), true);
            }
        }
        this.LoadGird();
        this.ClearAll();
        ScriptManager.GetCurrent(this.Page).SetFocus(this.txtskuCode);
    }

    protected void btnTarget_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        this.LoadGird();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void ChbBatchNo_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void ClearAll()
    {
        this.txtskuCode.Text = "";
        this.txtskuName.Text = "";
        this.txtUnitRate.Text = "";
        this.txtQuantity.Text = "";
        this.btnSave.Text = "Save";
        this.txtskuCode.Enabled = true;
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
        this.LoadTargetForId();
    }

    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
    }

    protected void DrpTargetFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGird();
    }

    protected void DrpTargetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTargetForId();
    }

    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new TargetController().UpdateTarget(long.Parse(this.GrdPurchase.Rows[e.RowIndex].Cells[0].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), -79228162514264337593543950335M, -2147483648, false);
        this.LoadGird();
    }

    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TargetId = long.Parse(this.GrdPurchase.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtskuCode.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtskuName.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        this.txtQuantity.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        this.txtUnitRate.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        this.btnSave.Text = "Update";
        this.txtskuCode.Enabled = false;
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadGird()
    {
        if (((this.txtFromdate.Text.Length > 1) && (this.drpDistributor.Items.Count > 0)) && ((this.DrpTargetFor.Items.Count > 0) && (this.drpPrincipal.Items.Count > 0)))
        {
            decimal d = 0M;
            DataTable table = new TargetController().SelectTarget(DateTime.Parse(this.txtFromdate.Text), int.Parse(this.DrpTargetType.SelectedValue.ToString()), int.Parse(this.DrpTargetFor.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
            this.GrdPurchase.DataSource = table;
            this.GrdPurchase.DataBind();
            foreach (DataRow row in table.Rows)
            {
                d += decimal.Parse(row["AMOUNT"].ToString());
            }
            this.txtTotalAmt.Text = decimal.Round(d, 2).ToString();
        }
        else
        {
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert(' Some Selection is Wrong');", true);
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, table, 0, 1, true);
    }

    private void LoadSKUDetail()
    {
        SKUPriceDetailController controller = new SKUPriceDetailController();
        if (this.drpPrincipal.Items.Count > 0)
        {
            DataTable table = controller.SelectDataPrice(int.Parse(this.drpPrincipal.SelectedValue.ToString()), -2147483648, -2147483648, -2147483648, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), -2147483648, 2, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, table, 10, 10, true);
            this.Session.Add("Dtsku_Price", table);
        }
    }

    private void LoadTargetForId()
    {
        if (this.DrpTargetType.SelectedIndex == 0)
        {
            if (this.drpDistributor.Items.Count > 0)
            {
                DataTable table = new Distributor_UserController().SelectDistributorUser(0x23, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpTargetFor, table, 0, 6, true);
            }
        }
        else if (this.DrpTargetType.SelectedIndex == 1)
        {
            if (this.drpDistributor.Items.Count > 0)
            {
                DataTable table2 = new Distributor_UserController().SelectDistributorUser(0x25, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpTargetFor, table2, 0, 6, true);
            }
        }
        else if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table3 = new GeoHierarchyController().SelectAssignTown(-2147483648, int.Parse(this.drpDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillDropDownList(this.DrpTargetFor, table3, 0, 1, true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadTargetForId();
            this.LoadPrincipal();
            this.LoadSKUDetail();
            this.btnSave.Attributes.Add("onclick", "return ValidateForm();");
        }
    }
}