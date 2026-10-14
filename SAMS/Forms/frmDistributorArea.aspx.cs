using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmDistributorArea : System.Web.UI.Page
{
    private static long Area_Id;
    private static long Route_id;
    private static string strcode = "";

    protected void btnSaveMarket_Click(object sender, EventArgs e)
    {
        grdRouteData.EditIndex = -1;
        DistributorRouteController controller = new DistributorRouteController();
        if (this.btnSaveMarket.Text == "Save")
        {
            DataTable table = new SETTINGS_TABLE_Controller().Select_SETTINGS_TABLE("DISTRIBUTOR_ROUTE", "ROUTE_ID", int.Parse(this.drpMDistributor.SelectedValue.ToString()));
            if (table.Rows.Count > 0)
            {
                Route_id = long.Parse(table.Rows[0]["Value"].ToString()) + 1L;
                if (Route_id.ToString().Length == 1)
                {
                    strcode = "MR00" + Route_id.ToString();
                }
                else if (Route_id.ToString().Length == 2)
                {
                    strcode = "MR0" + Route_id.ToString();
                }
                else if (Route_id.ToString().Length == 3)
                {
                    strcode = "MR" + Route_id.ToString();
                }
                controller.InsertDistributorRoute(Route_id, int.Parse(this.drpMDistributor.SelectedValue.ToString()), int.Parse(this.DrpMTown.SelectedValue.ToString()), (long)int.Parse(this.DrpRoute.SelectedValue.ToString()), strcode, this.txtMarketName.Text, true);
            }
        }
        else
        {
            controller.UpdateDistributorRoute(Route_id, int.Parse(this.drpMDistributor.SelectedValue.ToString()), int.Parse(this.DrpMTown.SelectedValue.ToString()), (long)int.Parse(this.DrpRoute.SelectedValue.ToString()), strcode, this.txtMarketName.Text, this.chMarkeIsActive.Checked);
        }
        this.drpMDistributor.Enabled = true;
        this.drpMDistributor.Enabled = true;
        this.DrpMTown.Enabled = true;
        this.DrpRoute.Enabled = true;
        this.btnSaveMarket.Text = "Save";
        this.txtMarketName.Text = "";
        this.LoadMarketGrid();
    }

    protected void btnSaveRoute_Click(object sender, EventArgs e)
    {
        grdAreaData.EditIndex = -1;
        DistributorAreaController controller = new DistributorAreaController();
        if (this.btnSaveRoute.Text == "Save")
        {
            DataTable table = new SETTINGS_TABLE_Controller().Select_SETTINGS_TABLE("DISTRIBUTOR_AREA", "AREA_ID", int.Parse(this.drpDistributor.SelectedValue.ToString()));
            if (table.Rows.Count > 0)
            {
                Area_Id = long.Parse(table.Rows[0]["Value"].ToString()) + 1L;
                if (Area_Id.ToString().Length == 1)
                {
                    strcode = "RT00" + Area_Id.ToString();
                }
                else if (Area_Id.ToString().Length == 2)
                {
                    strcode = "RT0" + Area_Id.ToString();
                }
                else if (Area_Id.ToString().Length == 3)
                {
                    strcode = "RT" + Area_Id.ToString();
                }
                controller.insertDisct_Area(long.Parse(Area_Id.ToString()), bool.Parse("true"), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpTown.SelectedValue.ToString()), this.txtAreaName.Text, strcode);
            }
        }
        else if (this.btnSaveRoute.Text == "Update")
        {
            controller.UpdateDisct_Area(Area_Id, this.ChIsActive.Checked, DateTime.Now, DateTime.Now, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpTown.SelectedValue.ToString()), this.txtAreaName.Text, strcode);
        }
        this.LoadAREA();
        this.LoadGrid();
        this.drpDistributor.Enabled = true;
        this.drpTown.Enabled = true;
        this.txtAreaName.Text = "";
        this.btnSaveRoute.Text = "Save";
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
        this.LoadGrid();
    }

    protected void drpMDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMTown();
        this.LoadAREA();
        this.LoadMarketGrid();
    }

    protected void DrpMTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAREA();
        this.LoadMarketGrid();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMarketGrid();
    }

    protected void drpTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    protected void grdAreaData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdAreaData.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }

    protected void grdAreaData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Area_Id = long.Parse(this.grdAreaData.Rows[e.NewEditIndex].Cells[0].Text);
        int num = int.Parse(this.grdAreaData.Rows[e.NewEditIndex].Cells[2].Text);
        for (int i = 0; this.drpTown.Items.Count > 0; i++)
        {
            if (int.Parse(this.drpTown.Items[i].Value.ToString()) == num)
            {
                this.drpTown.Items[i].Selected = true;
                break;
            }
        }
        strcode = this.grdAreaData.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtAreaName.Text = this.grdAreaData.Rows[e.NewEditIndex].Cells[6].Text;
        this.ChIsActive.Checked = bool.Parse(this.grdAreaData.Rows[e.NewEditIndex].Cells[7].Text);
        this.drpDistributor.Enabled = false;
        this.drpTown.Enabled = false;
        this.btnSaveRoute.Text = "Update";
    }

    protected void grdRouteData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdRouteData.PageIndex = e.NewPageIndex;
        this.LoadMarketGrid();
    }

    protected void grdRouteData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Route_id = long.Parse(this.grdRouteData.Rows[e.NewEditIndex].Cells[0].Text);
        strcode = this.grdRouteData.Rows[e.NewEditIndex].Cells[7].Text;
        this.txtMarketName.Text = this.grdRouteData.Rows[e.NewEditIndex].Cells[8].Text;
        this.chMarkeIsActive.Checked = bool.Parse(this.grdRouteData.Rows[e.NewEditIndex].Cells[9].Text);
        this.drpMDistributor.Enabled = false;
        this.drpMDistributor.Enabled = false;
        this.DrpMTown.Enabled = false;
        this.DrpRoute.Enabled = false;
        this.btnSaveMarket.Text = "Update";
    }

    private void LoadAREA()
    {
        if ((this.drpMDistributor.Items.Count > 0) && (this.DrpMTown.Items.Count > 0))
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpMDistributor.SelectedValue.ToString()), int.Parse(this.DrpMTown.SelectedValue.ToString()), null, null);
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
        }
    }

    private void LoadDISTRIBUTOR()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
        clsWebFormUtil.FillDropDownList(this.drpMDistributor, table, 0, 2, true);
    }

    private void LoadGrid()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.drpTown.Items.Count > 0))
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.drpTown.SelectedValue.ToString()), null, null);
            this.grdAreaData.DataSource = table;
            this.grdAreaData.DataBind();
        }
    }

    private void LoadMarketGrid()
    {
        if (((this.drpMDistributor.Items.Count > 0) && (this.DrpMTown.Items.Count > 0)) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new DistributorRouteController().SelectDistributorRoute(-9223372036854775808L, int.Parse(this.drpMDistributor.SelectedValue.ToString()), int.Parse(this.DrpMTown.SelectedValue.ToString()), long.Parse(this.DrpRoute.SelectedValue.ToString()));
            this.grdRouteData.DataSource = table;
            this.grdRouteData.DataBind();
        }
    }

    private void LoadMTown()
    {
        if (this.drpMDistributor.Items.Count > 0)
        {
            DataTable table = new GeoHierarchyController().SelectAssignTown(-2147483648, int.Parse(this.drpMDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillDropDownList(this.DrpMTown, table, 0, 1, true);
        }
    }

    private void LoadTown()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new GeoHierarchyController().SelectAssignTown(-2147483648, int.Parse(this.drpDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillDropDownList(this.drpTown, table, 0, 1, true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadTown();
            this.LoadGrid();
            this.LoadMTown();
            this.LoadAREA();
            this.LoadMarketGrid();
            this.btnSaveRoute.Attributes.Add("onclick", "return ValidateArea()");
            this.btnSaveMarket.Attributes.Add("onclick", "return ValidateRoute()");
        }
    }
}