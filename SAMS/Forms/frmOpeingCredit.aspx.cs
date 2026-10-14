using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI;

public partial class Forms_frmOpeingCredit : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        OrderEntryController controller = new OrderEntryController();
        DataTable table = new DataTable();
        //if (controller.ChkDupID(Convert.ToInt32(this.txtChequeNo.Text)).Rows.Count > 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "alert('Manual Invoice No Already exist.');", true);
        //}
        //else
        //{
        //    DataRow[] rowArray = ((DataTable)this.Session["dt"]).Select("CUSTOMER_CODE  = '" + this.txtOutletCode.Text.Trim() + "'");
        //    if (rowArray.Length > 0)
        //    {
        //        controller.OpeningCredit(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(rowArray[0]["TOWN_ID"].ToString()), (long)int.Parse(this.DrpRoute.SelectedValue.ToString()), DateTime.Parse(this.txtFromdate.Text), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(rowArray[0]["CUSTOMER_ID"].ToString()), long.Parse(rowArray[0]["CUSTOMER_ID"].ToString()), -1, int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(this.txtChequeNo.Text));
        //        this.ClearAll();
        //        this.LoadOpeningCredit();
        //    }
        //    ScriptManager.GetCurrent(this.Page).SetFocus(this.txtOutletCode);
        //}

        DataRow[] rowArray = ((DataTable)this.Session["dt"]).Select("CUSTOMER_CODE  = '" + this.txtOutletCode.Text.Trim() + "'");
        if (rowArray.Length > 0)
        {
            controller.OpeningCredit(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(rowArray[0]["TOWN_ID"].ToString()), (long)int.Parse(this.DrpRoute.SelectedValue.ToString()), DateTime.Parse(this.txtFromdate.Text), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(rowArray[0]["CUSTOMER_ID"].ToString()), long.Parse(rowArray[0]["CUSTOMER_ID"].ToString()), -1, int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue);
            this.ClearAll();
            this.LoadOpeningCredit();
        }
        ScriptManager.GetCurrent(this.Page).SetFocus(this.txtOutletCode);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.ClearAll();
    }

    private void chkDuplMID()
    {
        //OrderEntryController controller = new OrderEntryController();
        //DataTable table = new DataTable();
        //if (controller.ChkDupID(Convert.ToInt32(this.txtChequeNo.Text)).Rows.Count > 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "alert('Manual Invoice No Already exist.');", true);
        //}
    }

    private void ClearAll()
    {        
        this.txtOutletCode.Text = "";
        this.txtAmount.Text = "";
        this.txtOutletName.Text = "";
        this.txtRemarks.Text = "";
        this.txtOutletCode.Focus();
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadData();
        this.LoadDeliveryman();
        this.LoadOpeningCredit();
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.LoadDeliveryman();
    }

    private void LoadArea()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
        }
        else
        {
            this.DrpRoute.Items.Clear();
        }
    }

    private void LoadData()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new CustomerDataController().SelectPrincipalCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), -2147483648, int.Parse(this.DrpPrincipal.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(this.ListCustomer, table, "CUSTOMER_DETAIL", "CUSTOMER_DETAIL", true);
            this.Session.Add("dt", table);
        }
    }

    private void LoadDeliveryman()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, table, 0, 3, true);
        }
        else
        {
            this.DrpDeliveryMan.Items.Clear();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadOpeningCredit()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new CustomerDataController().SelectOpeningCredit(int.Parse(this.drpDistributor.SelectedValue.ToString()),Convert.ToDateTime(Session["CurrentWorkDate"]));
            this.GrdOrder.DataSource = table;
            this.GrdOrder.DataBind();
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();
            this.LoadDeliveryman();
            this.LoadOpeningCredit();
            this.txtFromdate.Text = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).ToString("dd-MMM-yyyy");
            this.Button1.Attributes.Add("onclick", "return ValidateForm()");
        }
    }
}