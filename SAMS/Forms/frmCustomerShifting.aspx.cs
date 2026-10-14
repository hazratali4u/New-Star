using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmCustomerShifting : System.Web.UI.Page
{
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController controller = new CustomerDataController();
        foreach (ListItem item in this.ChbAreaList.Items)
        {
            if (item.Selected)
            {
                controller.CustomerShifting(int.Parse(this.drpfromDistributor.SelectedValue.ToString()), int.Parse(this.DrptoDistributor.SelectedValue.ToString()), int.Parse(this.DrpfromRoute.SelectedValue.ToString()), int.Parse(this.drptoRoute.SelectedValue.ToString()), int.Parse(item.Value));
            }
        }
        this.LoadRoute();
    }

    protected void drpfromDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadfromArea();
        this.LoadRoute();
    }

    protected void DrpfromRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRoute();
    }

    protected void DrptoDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadtoArea();
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpfromDistributor, table, 0, 2, true);
        clsWebFormUtil.FillDropDownList(this.DrptoDistributor, table, 0, 2, true);
    }

    private void LoadfromArea()
    {
        if (this.drpfromDistributor.Items.Count > 0)
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpfromDistributor.SelectedValue.ToString()), -2147483648, null, null);
            clsWebFormUtil.FillDropDownList(this.DrpfromRoute, table, 0, 6, true);
        }
        else
        {
            this.DrpfromRoute.Items.Clear();
        }
    }

    private void LoadRoute()
    {
        if ((this.drpfromDistributor.Items.Count > 0) && (this.DrpfromRoute.Items.Count > 0))
        {
            DataTable table = new DistributorRouteController().SelectDistributorRoute(-9223372036854775808L, int.Parse(this.drpfromDistributor.SelectedValue.ToString()), -2147483648, long.Parse(this.DrpfromRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(this.ChbAreaList, table, 0, 8, true);
        }
        else
        {
            this.ChbAreaList.Items.Clear();
        }
    }

    private void LoadtoArea()
    {
        if (this.DrptoDistributor.Items.Count > 0)
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.DrptoDistributor.SelectedValue.ToString()), -2147483648, null, null);
            clsWebFormUtil.FillDropDownList(this.drptoRoute, table, 0, 6, true);
        }
        else
        {
            this.drptoRoute.Items.Clear();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadfromArea();
            this.LoadtoArea();
            this.LoadRoute();
        }
    }
}