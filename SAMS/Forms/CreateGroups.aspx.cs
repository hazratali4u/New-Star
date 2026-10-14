using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_CreateGroups : System.Web.UI.Page
{
    private DataView dv;
    private CreateGroupController gController = new CreateGroupController();
    private RoleManagementController rolemanagementController = new RoleManagementController();
    private static int SKUGroupID;

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SKUGroup_Grid.EditIndex = -1;
        if (this.txtGroupName.Text.Length == 0)
        {
            this.lblErrormsg.Text = "Must Enter Group Name";
        }
        else
        {
            if (this.btnSave.Text == "Save")
            {
                if (this.GetUnique_GroupName().Rows.Count > 0)
                {
                    this.lblErrormsg.Text = "Group Name already exists.";
                    return;
                }
                this.lblErrormsg.Text = null;
                string s = this.gController.Insert_SKUGroup(this.txtGroupName.Text, DateTime.Today, this.chIsActive.Checked, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.ddPrincipal.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                for (int i = 0; i < this.lstAssignSKU.Items.Count; i++)
                {
                    int num2 = Convert.ToInt32(this.lstAssignSKU.Items[i].Value.ToString());
                    this.gController.Insert_SKU_GroupDetail(int.Parse(s), num2);
                }
            }
            if (this.btnSave.Text == "Update")
            {
                this.lblErrormsg.Text = null;
                this.Update();
            }
            this.LoadGrid();
            this.lstAssignSKU.Items.Clear();
            this.lstUnAssignSKU.Items.Clear();
            this.txtGroupName.Text = "";
            this.btnSave.Text = "Save";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.lstUnAssignSKU.Items.Count > 0)
        {
            this.lstAssignSKU.Items.Add((ListItem)new clsListItems(this.lstUnAssignSKU.SelectedItem.Text, this.lstUnAssignSKU.SelectedValue.ToString()));
            this.lstUnAssignSKU.Items.RemoveAt(this.lstUnAssignSKU.SelectedIndex);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.lstAssignSKU.Items.Count > 0)
        {
            this.lstUnAssignSKU.Items.Add((ListItem)new clsListItems(this.lstAssignSKU.SelectedItem.Text, this.lstAssignSKU.SelectedValue.ToString()));
            this.lstAssignSKU.Items.RemoveAt(this.lstAssignSKU.SelectedIndex);
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int count = this.lstUnAssignSKU.Items.Count;
        for (int i = 0; i < count; i++)
        {
            this.lstAssignSKU.Items.Add((ListItem)new clsListItems(this.lstUnAssignSKU.Items[i].Text, this.lstUnAssignSKU.Items[i].Value.ToString()));
        }
        this.lstUnAssignSKU.Items.Clear();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        int count = this.lstAssignSKU.Items.Count;
        for (int i = 0; i < count; i++)
        {
            this.lstUnAssignSKU.Items.Add((ListItem)new clsListItems(this.lstAssignSKU.Items[i].Text, this.lstAssignSKU.Items[i].Value.ToString()));
        }
        this.lstAssignSKU.Items.Clear();
    }

    protected void ddBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetSKUName();
    }

    protected void ddCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetBrand();
        this.GetSKUName();
    }

    protected void ddDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCategory();
        this.GetBrand();
        this.GetSKUName();
    }

    protected void ddPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDivision();
        this.LoadCategory();
        this.GetBrand();
        this.GetSKUName();
    }

    protected void GetBrand()
    {
        if (this.ddCatagory.Items.Count > 0)
        {
            DataTable table = new SkuHierarchyController().SelectSkuHierarchy(60, int.Parse(this.ddCatagory.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddBrand, table, 0, 3, true);
        }
    }

    protected void GetSKUName()
    {
        if (this.ddBrand.Items.Count > 0)
        {
            DataTable table = new SkuController().SelectSkuInfo(-2147483648, -2147483648, -2147483648, int.Parse(this.ddBrand.SelectedValue.ToString()), -2147483648);
            this.lstUnAssignSKU.DataSource = table;
            this.lstUnAssignSKU.DataTextField = "SKUDETAIL";
            this.lstUnAssignSKU.DataValueField = "SKU_ID";
            this.lstUnAssignSKU.DataBind();
        }
    }

    protected DataTable GetUnique_GroupName()
    {
        return this.gController.GET_UniqueGroupName(-2147483648, this.txtGroupName.Text, Constants.DateNullValue, true, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
    }

    private void LoadCategory()
    {
        if (this.ddDivision.Items.Count > 0)
        {
            DataTable table = new SkuHierarchyController().SelectSkuHierarchy(0x3b, int.Parse(this.ddDivision.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddCatagory, table, 0, 3, true);
        }
    }

    private void LoadDivision()
    {
        if (this.ddPrincipal.Items.Count > 0)
        {
            DataTable table = new SkuHierarchyController().SelectSkuHierarchy(0x3a, int.Parse(this.ddPrincipal.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddDivision, table, 0, 3, true);
        }
    }

    protected DataTable LoadGrid()
    {
        DataTable table = this.gController.GET_SKUGroupDetail(int.Parse(this.Session["CompanyId"].ToString()));
        this.dv = new DataView(table);
        DataTable table2 = this.gController.GET_Group_ID(int.Parse(this.Session["CompanyId"].ToString()));
        this.SKUGroup_Grid.DataSource = table2;
        this.SKUGroup_Grid.DataBind();
        for (int i = 0; i < this.SKUGroup_Grid.Rows.Count; i++)
        {
            this.dv.RowFilter = "SKU_GROUP_ID = " + table2.Rows[i]["SKU_GROUP_ID"].ToString();
            ListBox box = (ListBox)this.SKUGroup_Grid.Rows[i].Cells[2].FindControl("listbox1");
            box.DataSource = this.dv;
            box.DataTextField = "SKUDETAIL";
            box.DataValueField = "SKU_ID";
            box.DataBind();
        }
        return table;
    }

    private void LoadPrincipal()
    {
        DataTable table = new SkuHierarchyController().SelectSkuHierarchy(0x39, -2147483648);
        clsWebFormUtil.FillDropDownList(this.ddPrincipal, table, 0, 3, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDivision();
            this.LoadCategory();
            this.GetBrand();
            this.GetSKUName();
            this.LoadGrid();
        }
    }

    protected void SKUGroup_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.SKUGroup_Grid.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }

    protected void SKUGroup_Grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.lstAssignSKU.Items.Clear();
        GridViewRow row = this.SKUGroup_Grid.Rows[e.NewEditIndex];
        SKUGroupID = int.Parse(row.Cells[0].Text);
        this.txtGroupName.Text = row.Cells[1].Text;
        ListBox box = (ListBox)row.Cells[2].FindControl("listbox1");
        for (int i = 0; i < box.Items.Count; i++)
        {
            this.lstAssignSKU.DataSource = box.DataSource;
            this.lstAssignSKU.Items.Add(box.Items[i].Text);
            this.lstAssignSKU.Items[i].Value = box.Items[i].Value;
            this.lstAssignSKU.DataBind();
        }
        this.btnSave.Text = "Update";
    }

    protected void SKUGroup_Grid_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void Update()
    {
        if (this.lstAssignSKU.Items.Count == 0)
        {
            this.gController.UpdateSKUinGroup(SKUGroupID, 0, this.txtGroupName.Text, this.chIsActive.Checked, int.Parse(this.ddPrincipal.SelectedValue.ToString()));
        }
        else
        {
            this.gController.UpdateSKUinGroup(SKUGroupID, 0, this.txtGroupName.Text, this.chIsActive.Checked, int.Parse(this.ddPrincipal.SelectedValue.ToString()));
            for (int i = 0; i < this.lstAssignSKU.Items.Count; i++)
            {
                this.gController.UpdateSKUinGroup(SKUGroupID, Convert.ToInt32(this.lstAssignSKU.Items[i].Value), this.txtGroupName.Text, this.chIsActive.Checked, int.Parse(this.ddPrincipal.SelectedValue.ToString()));
            }
        }
    }
}