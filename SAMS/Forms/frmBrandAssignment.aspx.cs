using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;

public partial class Forms_frmBrandAssignment : System.Web.UI.Page
{
    private void AssignBrand()
    {
        DataTable table = new SkuHierarchyController().SelectBrandAssignment(1, int.Parse(this.ddRole.SelectedValue.ToString()));
        clsWebFormUtil.FillListBox(this.lstAssignBrand, table, 0, 1, true);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SkuHierarchyController controller = new SkuHierarchyController();
        for (int i = 0; i < this.lstUnAssignBrand.Items.Count; i++)
        {
            if (this.ddRole.Items.Count > 0)
            {
                controller.InsertAssignBrand(int.Parse(this.lstUnAssignBrand.Items[i].Value.ToString()), int.Parse(this.ddRole.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SkuHierarchyController controller = new SkuHierarchyController();
        for (int i = 0; i < this.lstAssignBrand.Items.Count; i++)
        {
            if (this.ddRole.Items.Count > 0)
            {
                controller.DeleteAssignBrand(int.Parse(this.lstAssignBrand.Items[i].Value.ToString()), int.Parse(this.ddRole.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SkuHierarchyController controller = new SkuHierarchyController();
        for (int i = 0; i < this.lstUnAssignBrand.Items.Count; i++)
        {
            if (this.lstUnAssignBrand.Items[i].Selected && (this.ddRole.Items.Count > 0))
            {
                controller.InsertAssignBrand(int.Parse(this.lstUnAssignBrand.SelectedValue.ToString()), int.Parse(this.ddRole.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SkuHierarchyController controller = new SkuHierarchyController();
        for (int i = 0; i < this.lstAssignBrand.Items.Count; i++)
        {
            if (this.lstAssignBrand.Items[i].Selected && (this.ddRole.Items.Count > 0))
            {
                controller.DeleteAssignBrand(int.Parse(this.lstAssignBrand.Items[i].Value.ToString()), int.Parse(this.ddRole.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand();
    }

    protected void ddUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.UnAssignBrand();
        this.AssignBrand();
    }

    private void LoadUser()
    {
        DataTable table = new SAMSUserController().SelectSlashUser(null, null);
        clsWebFormUtil.FillDropDownList(this.ddRole, table, 0, 4, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadUser();
            this.UnAssignBrand();
            this.AssignBrand();
        }
    }

    private void UnAssignBrand()
    {
        DataTable table = new SkuHierarchyController().SelectBrandAssignment(0, int.Parse(this.ddRole.SelectedValue.ToString()));
        clsWebFormUtil.FillListBox(this.lstUnAssignBrand, table, 0, 1, true);
    }
}