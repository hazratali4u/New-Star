using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmSKU_Price : System.Web.UI.Page
{
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.btnSave.Text == "Save")
        {
            SkuController controller = new SkuController();
            DataControl control = new DataControl();
            for (int i = 0; i < this.ChbDistributorList.Items.Count; i++)
            {
                if (this.ChbDistributorList.Items[i].Selected)
                {
                    controller.InsertSKU_PRICES(int.Parse(this.ChbDistributorList.Items[i].Value), int.Parse(this.ddskuName.SelectedValue.ToString()), 1, decimal.Parse(control.chkNull_0(this.txtDistributorPrice.Text)), decimal.Parse(control.chkNull_0(this.txtTaxPrices.Text)), decimal.Parse(control.chkNull_0(this.txtDistributorPrice.Text)), decimal.Parse(control.chkNull_0(this.txtTradePrice.Text)), decimal.Parse(control.chkNull_0(this.txtRetailPrice.Text)), DateTime.Parse(this.txtFromdate.Text), decimal.Parse(control.chkNull_0(this.txtSADTax.Text)));
                }
            }
            this.LoadGrid();
            this.txtRetailPrice.Text = "";
            this.txtTradePrice.Text = "";
            this.txtDistributorPrice.Text = "";
        }
    }

    protected void ddskuBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUS();
        this.LoadGrid();
    }

    protected void ddskuCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUBrand();
        this.LoadSKUS();
        this.LoadGrid();
    }

    protected void ddskuDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUCategory();
        this.Populate_drpSKUBrand();
        this.LoadSKUS();
        this.LoadGrid();
    }

    protected void ddskuName_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    protected void ddskuPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUDivisions();
        this.Populate_drpSKUCategory();
        this.Populate_drpSKUBrand();
        this.LoadSKUS();
        this.LoadGrid();
    }

    protected void Grid_pricedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected void Grid_pricedetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillListBox(this.ChbDistributorList, table, 0, 2, true);
    }

    private void LoadGrid()
    {
        SkuController controller = new SkuController();
        if (this.ddskuName.Items.Count > 0)
        {
            DataTable table = controller.SelectSKuCurrentPrice(-2147483648, int.Parse(this.Session["CompanyId"].ToString()), -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.ddskuName.SelectedValue.ToString()));
            this.Grid_pricedetails.DataSource = table.DefaultView;
            this.Grid_pricedetails.DataBind();
        }
    }

    private void LoadSKUS()
    {
        if (this.ddskuBrand.Items.Count > 0)
        {
            SkuController controller = new SkuController();
            int num = int.Parse(this.ddskuPrincipal.SelectedItem.Value);
            int num2 = int.Parse(this.ddskuDivision.SelectedItem.Value);
            int num3 = int.Parse(this.ddskuCategory.SelectedItem.Value);
            int num4 = int.Parse(this.ddskuBrand.SelectedItem.Value);
            int num5 = -2147483648;
            DataTable table = controller.SelectSkuInfo(num, num2, num3, num4, num5);
            clsWebFormUtil.FillDropDownList(this.ddskuName, table, 0, 0x12, true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.Populate_drpSKUCompany();
            this.Populate_drpSKUDivisions();
            this.Populate_drpSKUCategory();
            this.Populate_drpSKUBrand();
            this.LoadSKUS();
            this.LoadGrid();
            this.LoadDistributor();
            this.btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }
    }

    private void Populate_drpSKUBrand()
    {
        if (this.ddskuCategory.Items.Count > 0)
        {
            SkuHierarchyController controller = new SkuHierarchyController();
            string s = this.ddskuCategory.SelectedItem.Value;
            if (int.Parse(s) > 0)
            {
                DataTable table = controller.SelectSkuHierarchy(60, -2147483648, int.Parse(s), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuBrand, table, 0, 3, true);
            }
        }
    }

    private void Populate_drpSKUCategory()
    {
        if (this.ddskuDivision.Items.Count > 0)
        {
            SkuHierarchyController controller = new SkuHierarchyController();
            string s = this.ddskuDivision.SelectedItem.Value;
            if (int.Parse(s) > 0)
            {
                DataTable table = controller.SelectSkuHierarchy(0x3b, -2147483648, int.Parse(s), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuCategory, table, 0, 3, true);
            }
        }
    }

    private void Populate_drpSKUCompany()
    {
        DataTable table = new SkuHierarchyController().SelectSkuHierarchy(0x39, -2147483648, -2147483648, null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddskuPrincipal, table, 0, 3, true);
    }

    private void Populate_drpSKUDivisions()
    {
        if (this.ddskuPrincipal.Items.Count > 0)
        {
            SkuHierarchyController controller = new SkuHierarchyController();
            string s = this.ddskuPrincipal.SelectedItem.Value;
            if (int.Parse(s) > 0)
            {
                DataTable table = controller.SelectSkuHierarchy(0x3a, -2147483648, int.Parse(s), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuDivision, table, 0, 3, true);
            }
        }
    }
}