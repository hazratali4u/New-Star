using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmGeoHierarchyData : System.Web.UI.Page
{
    private GeoHierarchyController GControler = new GeoHierarchyController();
    private static int RegionId;
    private static int TerritoryId;
    private static int TownId;
    private static int ZoneId;

    protected void btnRegionSave_Click(object sender, EventArgs e)
    {
        grdRegionData.EditIndex = -1;
        if (this.btnRegionSave.Text == "Save")
        {
            this.GControler.InsertHierarchy(-2147483648, this.txtRegionCode.Text, this.txtRegionName.Text, true, true, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x33, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        else
        {
            this.GControler.UpdateHierarchy(RegionId, -2147483648, this.txtRegionCode.Text, this.txtRegionName.Text, true, this.ChIsActive.Checked, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x33, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        this.LoadRegion();
        this.txtRegionCode.Text = "";
        this.txtRegionName.Text = "";
        this.btnRegionSave.Text = "Save";
    }

    protected void btnSaveTerritory_Click(object sender, EventArgs e)
    {
        grdTerritoryData.EditIndex = -1;
        if (this.btnSaveTerritory.Text == "Save")
        {
            this.GControler.InsertHierarchy(int.Parse(this.DrpZone.SelectedValue.ToString()), this.txtTerritoryCode.Text, this.txtTerritoryName.Text, true, true, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x35, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        else
        {
            this.GControler.UpdateHierarchy(TerritoryId, int.Parse(this.DrpZone.SelectedValue.ToString()), this.txtTerritoryCode.Text, this.txtTerritoryName.Text, true, this.chbIsTerritoryActive.Checked, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x35, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        this.LoadTerritory();
        this.LoadTownTerritory();
        this.txtTerritoryCode.Text = "";
        this.txtTerritoryName.Text = "";
        this.btnSaveTerritory.Text = "Save";
    }

    protected void btnSaveTown_Click(object sender, EventArgs e)
    {
        grdTownData.EditIndex = -1;
        if (this.btnSaveTown.Text == "Save")
        {
            this.GControler.InsertHierarchy(int.Parse(this.DrpTerritory.SelectedValue.ToString()), this.txtTownCode.Text, this.txtTownName.Text, true, true, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x36, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        else
        {
            this.GControler.UpdateHierarchy(TownId, int.Parse(this.DrpTerritory.SelectedValue.ToString()), this.txtTownCode.Text, this.txtTownName.Text, true, this.chbIsTownActive.Checked, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x36, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        this.LoadTown();
        this.txtTownCode.Text = "";
        this.txtTownName.Text = "";
        this.btnSaveTown.Text = "Save";
    }

    protected void btnSaveZone_Click(object sender, EventArgs e)
    {
        grdZoneData.EditIndex = -1;
        if (this.btnSaveZone.Text == "Save")
        {
            this.GControler.InsertHierarchy(int.Parse(this.DrpRegion.SelectedValue.ToString()), this.txtZoneCode.Text, this.txtZoneName.Text, true, true, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x34, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        else
        {
            this.GControler.UpdateHierarchy(ZoneId, int.Parse(this.DrpRegion.SelectedValue.ToString()), this.txtZoneCode.Text, this.txtZoneName.Text, true, this.chbIsZoneActive.Checked, -2147483648, int.Parse(this.Session["CompanyId"].ToString()), 0x34, int.Parse(this.Session["UserId"].ToString()), Configuration.DistributorId, null);
        }
        this.LoadZone();
        this.LoadTerritoryZone();
        this.LoadTownZone();
        this.txtZoneCode.Text = "";
        this.txtZoneName.Text = "";
        this.btnSaveZone.Text = "Save";
    }

    protected void DrpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadZone();
    }

    protected void drpRegionTerritory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTerritoryZone();
        this.LoadTerritory();
    }

    protected void DrpTerritory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
    }

    protected void DrpTownRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTownZone();
        this.LoadTownTerritory();
        this.LoadTown();
    }

    protected void DrpTownZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTownTerritory();
        this.LoadTown();
    }

    protected void DrpZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTerritory();
    }

    protected void grdRegionData_RowEditing(object sender, GridViewEditEventArgs e)
    {        
        RegionId = int.Parse(this.grdRegionData.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtRegionCode.Text = this.grdRegionData.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtRegionName.Text = this.grdRegionData.Rows[e.NewEditIndex].Cells[2].Text;
        this.ChIsActive.Checked = bool.Parse(this.grdRegionData.Rows[e.NewEditIndex].Cells[3].Text);
        this.btnRegionSave.Text = "Update";        
    }

    protected void grdTerritoryData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdTerritoryData.PageIndex = e.NewPageIndex;
        this.LoadTerritory();
    }

    protected void grdTerritoryData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TerritoryId = int.Parse(this.grdTerritoryData.Rows[e.NewEditIndex].Cells[1].Text);
        this.txtTerritoryCode.Text = this.grdTerritoryData.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtTerritoryName.Text = this.grdTerritoryData.Rows[e.NewEditIndex].Cells[3].Text;
        this.chbIsTerritoryActive.Checked = bool.Parse(this.grdTerritoryData.Rows[e.NewEditIndex].Cells[4].Text);
        this.btnSaveTerritory.Text = "Update";
    }

    protected void grdTownData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdTownData.PageIndex = e.NewPageIndex;
        this.LoadTown();
    }

    protected void grdTownData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TownId = int.Parse(this.grdTownData.Rows[e.NewEditIndex].Cells[1].Text);
        this.txtTownCode.Text = this.grdTownData.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtTownName.Text = this.grdTownData.Rows[e.NewEditIndex].Cells[3].Text;
        this.chbIsTownActive.Checked = bool.Parse(this.grdTownData.Rows[e.NewEditIndex].Cells[4].Text);
        this.btnSaveTown.Text = "Update";
    }

    protected void grdZoneData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ZoneId = int.Parse(this.grdZoneData.Rows[e.NewEditIndex].Cells[1].Text);
        this.txtZoneCode.Text = this.grdZoneData.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtZoneName.Text = this.grdZoneData.Rows[e.NewEditIndex].Cells[3].Text;
        this.chbIsZoneActive.Checked = bool.Parse(this.grdZoneData.Rows[e.NewEditIndex].Cells[4].Text);
        this.btnSaveZone.Text = "Update";
    }

    protected void LoadRegion()
    {
        DataTable table = this.GControler.SelectGeoHierarchy(-2147483648, -2147483648, -2147483648, null, null, true, -2147483648, 0x33, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpRegion, table, 0, 4, true);
        clsWebFormUtil.FillDropDownList(this.drpRegionTerritory, table, 0, 4, true);
        clsWebFormUtil.FillDropDownList(this.DrpTownRegion, table, 0, 4, true);
        this.grdRegionData.DataSource = table;
        this.grdRegionData.DataBind();
    }

    protected void LoadTerritory()
    {
        if (this.DrpZone.Items.Count > 0)
        {
            DataTable table = this.GControler.SelectGeoHierarchy(-2147483648, -2147483648, int.Parse(this.DrpZone.SelectedValue.ToString()), null, null, true, -2147483648, 0x35, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            this.grdTerritoryData.DataSource = table;
            this.grdTerritoryData.DataBind();
        }
    }

    private void LoadTerritoryZone()
    {
        if (this.drpRegionTerritory.Items.Count > 0)
        {
            DataTable table = this.GControler.SelectGeoHierarchy(-2147483648, -2147483648, int.Parse(this.drpRegionTerritory.SelectedValue.ToString()), null, null, true, -2147483648, 0x34, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpZone, table, 0, 4, true);
        }
    }

    protected void LoadTown()
    {
        if (this.DrpTerritory.Items.Count > 0)
        {
            DataTable table = this.GControler.SelectGeoHierarchy(-2147483648, -2147483648, int.Parse(this.DrpTerritory.SelectedValue.ToString()), null, null, true, -2147483648, 0x36, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            this.grdTownData.DataSource = table;
            this.grdTownData.DataBind();
        }
    }

    private void LoadTownTerritory()
    {
        if (this.DrpTownZone.Items.Count > 0)
        {
            DataTable table = this.GControler.SelectGeoHierarchy(-2147483648, -2147483648, int.Parse(this.DrpTownZone.SelectedValue.ToString()), null, null, true, -2147483648, 0x35, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpTerritory, table, 0, 4, true);
            this.grdZoneData.DataSource = table;
            this.grdZoneData.DataBind();
        }
    }

    private void LoadTownZone()
    {
        if (this.DrpTownRegion.Items.Count > 0)
        {
            DataTable table = this.GControler.SelectGeoHierarchy(-2147483648, -2147483648, int.Parse(this.DrpTownRegion.SelectedValue.ToString()), null, null, true, -2147483648, 0x34, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpTownZone, table, 0, 4, true);
        }
    }

    protected void LoadZone()
    {
        if (this.DrpRegion.Items.Count > 0)
        {
            DataTable table = this.GControler.SelectGeoHierarchy(-2147483648, -2147483648, int.Parse(this.DrpRegion.SelectedValue.ToString()), null, null, true, -2147483648, 0x34, -2147483648, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            this.grdZoneData.DataSource = table;
            this.grdZoneData.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadRegion();
            this.LoadZone();
            this.LoadTerritoryZone();
            this.LoadTerritory();
            this.LoadTownZone();
            this.LoadTownTerritory();
            this.LoadTown();            
            this.btnRegionSave.Attributes.Add("onclick", "return ValidatRegion()");
            this.btnSaveZone.Attributes.Add("onclick", "return ValidatZone()");
            this.btnSaveTerritory.Attributes.Add("onclick", "return ValidateTerritory()");
            this.btnSaveTown.Attributes.Add("onclick", "return ValidateTown()");
        }
    }
}