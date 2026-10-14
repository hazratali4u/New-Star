using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmDemangedClaim : System.Web.UI.Page
{
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        LedgerController controller = new LedgerController();
        string s = controller.SelectLedgerMaxDocumentId(0x10, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        int num = 0x17a;
        if (this.RbdClaimType.SelectedValue == num.ToString())
        {
            controller.PostingCash_Bank_Account(0x10, long.Parse(s), long.Parse(this.DrpAccountHead.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(this.txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), null, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, null, Constants.DateNullValue, 0x17a, "");
        }
        else
        {
            controller.PostingCash_Bank_Account(0x10, long.Parse(s), long.Parse(this.DrpAccountHead.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), null, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, null, Constants.DateNullValue, 0x17f, "");
        }
        this.txtAmount.Text = "";
        this.txtRemarks.Text = "";
        this.LoadGrid();
    }

    private void CreatTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Account_Head_Id", typeof(long));
        table.Columns.Add("Account_Code", typeof(string));
        table.Columns.Add("Account_Name", typeof(string));
        table.Columns.Add("Debit", typeof(decimal));
        table.Columns.Add("Credit", typeof(decimal));
        table.Columns.Add("Remarks", typeof(string));
        this.Session.Add("dtVoucher", table);
        this.GrdOrder.DataSource = table;
        this.GrdOrder.DataBind();
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadCustomer();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer();
    }

    protected void DrpVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LedgerController controller = new LedgerController();
        DataControl control = new DataControl();
        controller.DeleteWareHouseLedger(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[2].Text)), (long)int.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[6].Text)), -9223372036854775808L, decimal.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[7].Text)));
        this.LoadGrid();
    }

    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    private void LoadAccountHead()
    {
        DataTable table = new AccountHeadController().SelectClaimHead(int.Parse(this.RbdClaimType.SelectedValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpAccountHead, table, 0, 2, true);
    }

    private void LoadArea()
    {
        DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
        clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
        this.DrpRoute.Enabled = true;
    }

    private void LoadClaimType()
    {
        int num = 0x17a;
        this.RbdClaimType.Items.Add(new ListItem("Debit Claim", num.ToString()));
        int num2 = 0x17f;
        this.RbdClaimType.Items.Add(new ListItem("Credit Claim", num2.ToString()));
        this.RbdClaimType.SelectedIndex = 0;
    }

    private void LoadCustomer()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new CustomerDataController().SelectPrincipalCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), -2147483648, int.Parse(this.DrpPrincipal.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, table, 0, 4, true);
        }
        else
        {
            this.DrpCustomer.Items.Clear();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadGrid()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new LedgerController().SelectClaimDetail(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.RbdClaimType.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            this.GrdOrder.DataSource = table;
            this.GrdOrder.DataBind();
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadClaimType();
            this.LoadAccountHead();
            this.LoadPrincipal();
            this.CreatTable();
            this.LoadArea();
            this.LoadCustomer();
            this.LoadGrid();
            this.btnAddNew.Attributes.Add("onclick", "return ValidateForm();");
            ScriptManager.GetCurrent(this.Page).SetFocus(this.drpDistributor);
            this.lblRowId.Text = "-1";
        }
    }

    protected void RbdClaimType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAccountHead();
        this.LoadGrid();
    }
}