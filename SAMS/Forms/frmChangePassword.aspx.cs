using SAMS.BusinessLayer.Classes;
using System;
using System.Web.UI;
using System.Data;

public partial class Forms_frmChangePassword : System.Web.UI.Page
{
    private DataTable dtLogin_ID = new DataTable();
    private SAMSUserController UserInfo = new SAMSUserController();

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtCurrentPassword.Text = null;
        this.txtNewPassword.Text = null;
        this.txtConfirmNewPassword.Text = null;
    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {
        if (this.UpdatePassword())
        {
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Password has changed successfully ');", true);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.btnSave.Attributes.Add("onclick", "return ValidatePassword();");
        }
    }

    protected bool UpdatePassword()
    {
        try
        {
            this.dtLogin_ID = this.UserInfo.SelectSlashUser(Convert.ToInt32(this.Session["UserID"].ToString()));
            if (this.txtCurrentPassword.Text == this.dtLogin_ID.Rows[0]["PASSWORD"].ToString())
            {
                this.UserInfo.UpdateSlashUser(Convert.ToInt32(this.Session["UserID"].ToString()), Convert.ToInt32(this.Session["CompanyId"]), this.dtLogin_ID.Rows[0]["LOGIN_ID"].ToString(), this.txtConfirmNewPassword.Text, -2147483648, true, Convert.ToInt32(this.Session["DISTRIBUTOR_ID"].ToString()));
                return true;
            }
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Current Password is wrong ');", true);
            return false;
        }
        catch (Exception exception)
        {
            exception.ToString();
            return false;
        }
    }
}