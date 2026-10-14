using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_frmCreateUser : System.Web.UI.Page
{
    private RoleManagementController mController = new RoleManagementController();
    private SAMSUserController UController = new SAMSUserController();

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Grid_users.EditIndex = -1;
            if (this.btnSave.Text == "Save")
            {
                if (this.UController.SelectSlashUser(this.txtLoginId.Text, this.txtpassword.Text).Rows.Count > 0)
                {
                    this.lblErrorMsg.Text = "LoginId Already Exist";
                    return;
                }
                this.UController.InsertSlashUser(int.Parse(this.DrpUser.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()), int.Parse(this.ddDistributorId.SelectedValue.ToString()), this.txtLoginId.Text, this.txtpassword.Text, int.Parse(this.ddRole.SelectedValue.ToString()));
            }
            else if (this.btnSave.Text == "Update")
            {
                this.UController.UpdateSlashUser(int.Parse(this.DrpUser.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()), this.txtLoginId.Text, this.txtpassword.Text, int.Parse(this.ddRole.SelectedValue.ToString()), this.chkIsActive.Checked, int.Parse(this.ddDistributorId.SelectedValue.ToString()));
            }
            this.LoadGrid();
            this.ClearControls();
            this.btnSave.Text = "Save";
        }
        catch (Exception)
        {
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ClearControls();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    protected void ClearControls()
    {
        try
        {
            this.txtLoginId.Text = null;
            this.txtpassword.Text = null;
            this.lblErrorMsg.Text = null;
            this.btnSave.Text = "Save";
        }
        catch (Exception exception)
        {
            exception.Message.ToString();
        }
    }

    protected void ddDistributorId_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUser();
    }

    protected void Grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.Grid_users.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }

    protected void Grid_users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridViewRow row = this.Grid_users.Rows[e.NewEditIndex];
            this.ddDistributorId.SelectedValue = row.Cells[1].Text;
            this.LoadUser();
            this.DrpUser.SelectedValue = row.Cells[0].Text;
            this.txtLoginId.Text = row.Cells[4].Text;
            this.txtpassword.Text = row.Cells[5].Text;
            this.chkIsActive.Checked = bool.Parse(row.Cells[7].Text);
            this.ddRole.SelectedValue = row.Cells[8].Text;
            this.btnSave.Text = "Update";
        }
        catch (Exception exception)
        {
            exception.Message.ToString();
        }
    }

    private void LoadDISTRIBUTOR()
    {
        DataTable table = new DistributorController().SelectDistributor(-2147483648, -2147483648, -2147483648);
        this.ddDistributorId.DataSource = table;
        this.ddDistributorId.DataTextField = "DISTRIBUTOR_NAME";
        this.ddDistributorId.DataValueField = "DISTRIBUTOR_ID";
        this.ddDistributorId.DataBind();
    }

    protected void LoadGrid()
    {
        if (this.ddDistributorId.Items.Count > 0)
        {
            DataTable table = this.UController.SelectSlashUser(null, null);
            switch (this.ddSearchType.SelectedIndex)
            {
                case 1:
                    table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                    break;

                case 2:
                    table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                    break;

                case 3:
                    table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                    break;

                default:
                    table.DefaultView.RowFilter = "USER_NAME like '%%'";
                    break;
            }
            this.Grid_users.DataSource = table;
            this.Grid_users.DataBind();
        }
    }

    protected void LoadRole()
    {
        DataTable table = this.mController.SelectRoleMaster(-2147483648, null, Constants.DateNullValue, Constants.DateNullValue, true);
        this.ddRole.DataSource = table;
        this.ddRole.DataTextField = "ROLE_NAME";
        this.ddRole.DataValueField = "ROLE_ID";
        this.ddRole.DataBind();
    }

    private void LoadUser()
    {
        if (this.ddDistributorId.Items.Count > 0)
        {
            DataTable table = new Distributor_UserController().SelectDistributorUser(-2147483648, int.Parse(this.ddDistributorId.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpUser, table, 0, 6, true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadUser();
            this.LoadRole();
            this.LoadGrid();
            this.btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }
        base.Response.Expires = 0;
        base.Response.Cache.SetNoStore();
    }
}