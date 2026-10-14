using System;
using System.Data;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmTownAssignment : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DistributorTownController controller = new DistributorTownController();
        for (int i = 0; i < this.lstUnAssignTown.Items.Count; i++)
        {
            if (this.lstUnAssignTown.Items[i].Selected && (this.drpDistributor.Items.Count > 0))
            {
                controller.InsertDistributorTown(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.lstUnAssignTown.Items[i].Value), bool.Parse("True"), 1, null, int.Parse(this.Session["UserId"].ToString()));
            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DistributorTownController controller = new DistributorTownController();
        for (int i = 0; i < this.lstAssignTown.Items.Count; i++)
        {
            if (this.lstAssignTown.Items[i].Selected && (this.drpDistributor.Items.Count > 0))
            {
                controller.DeletedDistributorTown(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.lstAssignTown.Items[i].Value));
            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        DistributorTownController controller = new DistributorTownController();
        if (this.drpDistributor.Items.Count > 0)
        {
            for (int i = 0; i < this.lstUnAssignTown.Items.Count; i++)
            {
                controller.InsertDistributorTown(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.lstUnAssignTown.Items[i].Value), bool.Parse("True"), 1, null, int.Parse(this.Session["UserId"].ToString()));
            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        DistributorTownController controller = new DistributorTownController();
        if (this.drpDistributor.Items.Count > 0)
        {
            for (int i = 0; i < this.lstAssignTown.Items.Count; i++)
            {
                controller.DeletedDistributorTown(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.lstAssignTown.Items[i].Value));
            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    protected void ddRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadZone();
        this.LoadTerritory();
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    protected void ddTerritory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    protected void ddZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTerritory();
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

    private void LoadAssignTown()
    {
        if ((this.ddTerritory.Items.Count > 0) && (this.drpDistributor.Items.Count > 0))
        {
            DataTable table = new GeoHierarchyController().SelectAssignTown(int.Parse(this.ddTerritory.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillListBox(this.lstAssignTown, table, 0, 1, true);
        }
        else
        {
            this.lstAssignTown.Items.Clear();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributor(-2147483648, -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 1, 3, true);
    }

    protected void LoadRegion()
    {
        DataTable table = new GeoHierarchyController().SelectGeoHierarchy(-2147483648, -2147483648, -2147483648, null, null, true, -2147483648, 0x33, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        table.DefaultView.Sort = "GEO_ID";
        this.ddRegion.DataSource = table.DefaultView;
        this.ddRegion.DataTextField = "GEO_NAME";
        this.ddRegion.DataValueField = "GEO_ID";
        this.ddRegion.DataBind();
    }

    protected void LoadTerritory()
    {
        if (this.ddZone.Items.Count > 0)
        {
            DataTable table = new GeoHierarchyController().SelectGeoHierarchy(-2147483648, -2147483648, Convert.ToInt32(this.ddZone.SelectedValue.ToString()), null, null, true, -2147483648, 0x35, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            this.ddTerritory.DataSource = table;
            this.ddTerritory.DataTextField = "GEO_NAME";
            this.ddTerritory.DataValueField = "GEO_ID";
            this.ddTerritory.DataBind();
        }
        else
        {
            this.ddTerritory.Items.Clear();
        }
    }

    private void LoadUnAssignTown()
    {
        if ((this.ddTerritory.Items.Count > 0) && (this.drpDistributor.Items.Count > 0))
        {
            DataTable table = new GeoHierarchyController().SelectAssignTown(int.Parse(this.ddTerritory.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0);
            clsWebFormUtil.FillListBox(this.lstUnAssignTown, table, 0, 1, true);
        }
        else
        {
            this.lstUnAssignTown.Items.Clear();
        }
    }

    protected void LoadZone()
    {
        if (this.ddRegion.Items.Count > 0)
        {
            DataTable table = new GeoHierarchyController().SelectGeoHierarchy(-2147483648, -2147483648, Convert.ToInt32(this.ddRegion.SelectedValue.ToString()), null, null, true, -2147483648, 0x34, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            this.ddZone.DataSource = table;
            this.ddZone.DataTextField = "GEO_NAME";
            this.ddZone.DataValueField = "GEO_ID";
            this.ddZone.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadRegion();
            this.LoadZone();
            this.LoadTerritory();
            this.LoadUnAssignTown();
            this.LoadAssignTown();
        }
    }
}