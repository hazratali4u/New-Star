using SAMS.BusinessLayer.Classes;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_frmSaleForce : System.Web.UI.Page
{
    private Distributor_UserController UController = new Distributor_UserController();
    private static int UserId;

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Grid_users.EditIndex = -1;
            if (this.btnSave.Text == "Save")
            {
                SETTINGS_TABLE_Controller controller = new SETTINGS_TABLE_Controller();
                string str = "";
                UserId = int.Parse(controller.GetAutoCustomerCode("EM", 0, -9223372036854775808L).ToString());
                if (UserId.ToString().Length == 1)
                {
                    str = "EM000" + UserId.ToString();
                }
                else if (UserId.ToString().Length == 2)
                {
                    str = "EM00" + UserId.ToString();
                }
                else if (UserId.ToString().Length == 3)
                {
                    str = "EM0" + UserId.ToString();
                }
                else
                {
                    str = "EM" + UserId.ToString();
                }
                this.UController.InsertDistributor_User(int.Parse(this.Session["CompanyId"].ToString()), this.txtNICNo.Text, true, DateTime.Now, DateTime.Now, int.Parse(this.ddDesignation.SelectedValue.ToString()), int.Parse(this.ddDistributorId.SelectedValue.ToString()), -2147483648, this.txtEmail.Text, this.txtAddress1.Text, this.txtAddress2.Text, this.txtLoginId.Text, this.txtpassword.Text, this.txtMobileNo.Text, str, this.txtUserName.Text, this.txtPhoneNo.Text);
                controller.GetAutoCustomerCode("EM", 1, long.Parse(UserId.ToString()));
            }
            else if (this.btnSave.Text == "Update")
            {
                this.UController.UpdateDistributor_User(UserId, int.Parse(this.Session["CompanyId"].ToString()), this.txtNICNo.Text, this.chkIsActive.Checked, DateTime.Now, DateTime.Now, int.Parse(this.ddDesignation.SelectedValue.ToString()), int.Parse(this.ddDistributorId.SelectedValue.ToString()), -2147483648, this.txtEmail.Text, this.txtAddress1.Text, this.txtAddress2.Text, this.txtLoginId.Text, this.txtpassword.Text, this.txtMobileNo.Text, null, this.txtUserName.Text, this.txtPhoneNo.Text);
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
        this.LoadGrid();
        this.ClearControls();
        this.btnSave.Text = "Save";
    }

    protected void ClearControls()
    {
        try
        {
            this.txtUserName.Text = null;
            this.txtPhoneNo.Text = null;
            this.txtMobileNo.Text = null;
            this.txtAddress1.Text = null;
            this.txtAddress2.Text = null;
            this.txtEmail.Text = null;
            this.txtLoginId.Text = null;
            this.txtpassword.Text = null;
            this.txtNICNo.Text = null;
            this.lblErrorMsg.Text = null;
        }
        catch (Exception exception)
        {
            exception.Message.ToString();
        }
    }

    protected void ddDistributorId_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
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
            UserId = int.Parse(row.Cells[0].Text);
            if (row.Cells[2].Text == "&nbsp;")
            {
                this.txtUserName.Text = null;
            }
            else
            {
                this.txtUserName.Text = row.Cells[2].Text;
            }
            if (row.Cells[3].Text == "&nbsp;")
            {
                this.txtNICNo.Text = null;
            }
            else
            {
                this.txtNICNo.Text = row.Cells[3].Text;
            }
            if (row.Cells[4].Text == "&nbsp;")
            {
                this.txtPhoneNo.Text = null;
            }
            else
            {
                this.txtPhoneNo.Text = row.Cells[4].Text;
            }
            if (row.Cells[5].Text == "&nbsp;")
            {
                this.txtMobileNo.Text = null;
            }
            else
            {
                this.txtMobileNo.Text = row.Cells[5].Text;
            }
            if (row.Cells[6].Text == "&nbsp;")
            {
                this.txtEmail.Text = null;
            }
            else
            {
                this.txtEmail.Text = row.Cells[6].Text;
            }
            if (row.Cells[7].Text == "&nbsp;")
            {
                this.txtAddress1.Text = null;
            }
            else
            {
                this.txtAddress1.Text = row.Cells[7].Text;
            }
            if (row.Cells[8].Text == "&nbsp;")
            {
                this.txtAddress2.Text = null;
            }
            else
            {
                this.txtAddress2.Text = row.Cells[8].Text;
            }
            this.chkIsActive.Checked = bool.Parse(row.Cells[10].Text);
            this.ddDesignation.SelectedValue = row.Cells[11].Text;
            this.btnSave.Text = "Update";
        }
        catch (Exception exception)
        {
            exception.Message.ToString();
        }
    }

    private void LoadDesignation()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x22, null, -2147483648, true);
        this.ddDesignation.DataSource = table;
        this.ddDesignation.DataTextField = "SLASH_DESC";
        this.ddDesignation.DataValueField = "REF_ID";
        this.ddDesignation.DataBind();
    }

    private void LoadDISTRIBUTOR()
    {
        DataTable table = new DistributorController().SelectDistributor(-2147483648, -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        this.ddDistributorId.DataSource = table;
        this.ddDistributorId.DataTextField = "DISTRIBUTOR_NAME";
        this.ddDistributorId.DataValueField = "DISTRIBUTOR_ID";
        this.ddDistributorId.DataBind();
    }

    protected void LoadGrid()
    {
        if (this.ddDistributorId.Items.Count > 0)
        {
            DataTable table = this.UController.SelectDistributorUser(-2147483648, int.Parse(this.ddDistributorId.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            this.Grid_users.DataSource = table;
            this.Grid_users.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadDesignation();
            this.LoadGrid();
            this.btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }
        base.Response.Expires = 0;
        base.Response.Cache.SetNoStore();
    }
}