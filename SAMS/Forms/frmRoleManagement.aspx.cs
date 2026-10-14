using System;
using System.Data;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmRoleManagement : System.Web.UI.Page
{
    private DataControl dc = new DataControl();
    private RoleManagementController mController = new RoleManagementController();

    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (this.btnNew.Text == "New")
        {
            this.ddRole.Visible = false;
            this.TextBox1.Text = null;
            this.TextBox1.Visible = true;
            this.TextBox1.Enabled = true;
            this.btnNew.Text = "Save";
        }
        else
        {
            if (this.TextBox1.Text == "")
            {
                this.lblmsg.Visible = true;
                this.lblmsg.Text = "Enter Role.";
            }
            else
            {
                this.lblmsg.Visible = false;
                this.mController.InsertRoleMaster(this.TextBox1.Text, DateTime.Today, DateTime.Today, true);
                this.LoadRole();
                this.lblmsg.Visible = false;
            }
            this.btnNew.Text = "New";
            this.ddRole.Visible = true;
            this.TextBox1.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.lstUnAssignModule.Items.Count > 0)
        {
            for (int i = 0; i < this.lstUnAssignModule.Items.Count; i++)
            {
                if (this.lstUnAssignModule.Items[i].Selected)
                {
                    this.mController.InsertRoleDetail(int.Parse(this.ddRole.SelectedValue.ToString()), Convert.ToInt32(this.lstUnAssignModule.SelectedValue.ToString()), 1);
                }
            }
            this.GetUnAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
            this.GetAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Convert.ToInt32(this.ddRole.SelectedValue.ToString());
        this.lstAssignModule.SelectedValue.ToString();
        if (this.lstAssignModule.Items.Count > 0)
        {
            for (int i = 0; i < this.lstAssignModule.Items.Count; i++)
            {
                if (this.lstAssignModule.Items[i].Selected)
                {
                    this.mController.InsertRoleDetail(int.Parse(this.ddRole.SelectedValue.ToString()), Convert.ToInt32(this.lstAssignModule.SelectedValue.ToString()), 0);
                }
            }
            this.GetUnAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
            this.GetAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
    }

    protected void ddRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetUnAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
    }

    protected void DrpModule1stLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMod2ndtLayer();
        this.LoadMod3rdtLayer();
        this.GetUnAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
    }

    protected void DrpModule2ndLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMod3rdtLayer();
        this.GetUnAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
    }

    protected void DrpModule3rdLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetUnAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(this.ddRole.SelectedValue.ToString()));
    }

    private void GetAssingModule(int RoleID)
    {
        DataTable table = this.mController.GetAssignUnAssignModule(RoleID, int.Parse(this.dc.chkNull(this.DrpModule3rdLayer.SelectedValue.ToString())), -2147483648, 1);
        table.DefaultView.Sort = "MODULE_DESCRIPTION";
        this.lstAssignModule.DataSource = table.DefaultView;
        this.lstAssignModule.DataTextField = "MODULE_DESCRIPTION";
        this.lstAssignModule.DataValueField = "MODULE_ID";
        this.lstAssignModule.DataBind();
    }

    private void GetUnAssingModule(int RoleID)
    {
        DataTable table = this.mController.GetAssignUnAssignModule(RoleID, int.Parse(this.dc.chkNull(this.DrpModule3rdLayer.SelectedValue.ToString())), -2147483648, 0);
        table.DefaultView.Sort = "MODULE_DESCRIPTION";
        this.lstUnAssignModule.DataSource = table.DefaultView;
        this.lstUnAssignModule.DataTextField = "MODULE_DESCRIPTION";
        this.lstUnAssignModule.DataValueField = "MODULE_ID";
        this.lstUnAssignModule.DataBind();
    }

    private void LoadMod1stLayer()
    {
        DataTable table = this.mController.SelectModule(-2147483648, null, -2147483648, 11, Constants.DateNullValue, true);
        table.DefaultView.Sort = "MODULE_DESCRIPTION";
        this.DrpModule1stLayer.DataSource = table.DefaultView;
        this.DrpModule1stLayer.DataTextField = "MODULE_DESCRIPTION";
        this.DrpModule1stLayer.DataValueField = "MODULE_ID";
        this.DrpModule1stLayer.DataBind();
    }

    private void LoadMod2ndtLayer()
    {
        DataTable table = this.mController.SelectModule(-2147483648, null, int.Parse(this.dc.chkNull(this.DrpModule1stLayer.SelectedValue.ToString())), 12, Constants.DateNullValue, true);
        table.DefaultView.Sort = "MODULE_DESCRIPTION";
        this.DrpModule2ndLayer.DataSource = table.DefaultView;
        this.DrpModule2ndLayer.DataTextField = "MODULE_DESCRIPTION";
        this.DrpModule2ndLayer.DataValueField = "MODULE_ID";
        this.DrpModule2ndLayer.DataBind();
    }

    private void LoadMod3rdtLayer()
    {
        DataTable table = this.mController.SelectModule(-2147483648, null, int.Parse(this.dc.chkNull(this.DrpModule2ndLayer.SelectedValue.ToString())), 13, Constants.DateNullValue, true);
        table.DefaultView.Sort = "MODULE_DESCRIPTION";
        this.DrpModule3rdLayer.DataSource = table.DefaultView;
        this.DrpModule3rdLayer.DataTextField = "MODULE_DESCRIPTION";
        this.DrpModule3rdLayer.DataValueField = "MODULE_ID";
        this.DrpModule3rdLayer.DataBind();
    }

    private void LoadRole()
    {
        DataTable table = this.mController.SelectRoleMaster(0, null, DateTime.Today, DateTime.Today, true);
        this.ddRole.DataSource = table;
        this.ddRole.DataTextField = "ROLE_NAME";
        this.ddRole.DataValueField = "ROLE_ID";
        this.ddRole.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadRole();
            this.LoadMod1stLayer();
            this.LoadMod2ndtLayer();
            this.LoadMod3rdtLayer();
            int roleID = Convert.ToInt32(this.ddRole.SelectedValue.ToString());
            this.GetUnAssingModule(roleID);
            this.GetAssingModule(roleID);
        }
    }
}