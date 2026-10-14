using System;
using System.Data;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmDistributorAssignment : System.Web.UI.Page
{
    protected void Button3_Click(object sender, EventArgs e)
    {
        SAMSUserController controller = new SAMSUserController();
        for (int i = 0; i < this.lstUnAssignDistributor.Items.Count; i++)
        {
            if (this.lstUnAssignDistributor.Items[i].Selected && (this.ddRole.Items.Count > 0))
            {
                controller.InsertUserAssignment(int.Parse(this.ddRole.SelectedValue.ToString()), int.Parse(this.ddDistributorType.SelectedValue.ToString()), int.Parse(this.lstUnAssignDistributor.Items[i].Value.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            }
        }
        this.LoadUnAssingned();
        this.LoadAssingned();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SAMSUserController controller = new SAMSUserController();
        for (int i = 0; i < this.lstAssignDistributor.Items.Count; i++)
        {
            if (this.lstAssignDistributor.Items[i].Selected && (this.ddRole.Items.Count > 0))
            {
                controller.DeleteUserAssignment(int.Parse(this.ddRole.SelectedValue.ToString()), int.Parse(this.ddDistributorType.SelectedValue.ToString()), int.Parse(this.lstAssignDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            }
        }
        this.LoadUnAssingned();
        this.LoadAssingned();
    }

    protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssingned();
        this.LoadAssingned();
    }

    protected void ddUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssingned();
        this.LoadAssingned();
    }

    private void DistributorType()
    {
        DataTable table = new DistributorController().SelectDistributorTypeInfo(-2147483648);
        clsWebFormUtil.FillDropDownList(this.ddDistributorType, table, 0, 2);
    }

    private void LoadAssingned()
    {
        if ((this.ddRole.Items.Count > 0) && (this.ddDistributorType.Items.Count > 0))
        {
            DataTable table = new SAMSUserController().SelectUserAssignment(int.Parse(this.ddRole.SelectedValue.ToString()), int.Parse(this.ddDistributorType.SelectedValue.ToString()), 1, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillListBox(this.lstAssignDistributor, table, 0, 1, true);
        }
    }

    private void LoadUnAssingned()
    {
        if ((this.ddRole.Items.Count > 0) && (this.ddDistributorType.Items.Count > 0))
        {
            DataTable table = new SAMSUserController().SelectUserAssignment(int.Parse(this.ddRole.SelectedValue.ToString()), int.Parse(this.ddDistributorType.SelectedValue.ToString()), 0, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillListBox(this.lstUnAssignDistributor, table, 0, 1, true);
        }
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
            this.DistributorType();
            this.LoadUnAssingned();
            this.LoadAssingned();
        }
    }
}