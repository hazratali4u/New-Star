using SAMS.BusinessLayer.Classes;
using System;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    private SAMSUserController mController = new SAMSUserController();

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        this.ValidateUser();
    }

    private void LastClosedDay(int UserId, int p_Distributor)
    {
        DataTable table = new SAMSUserController().SelectMaxDayClose(UserId, p_Distributor);
        if (table.Rows.Count > 0)
        {
            this.Session.Add("CurrentWorkDate", DateTime.Parse(table.Rows[0]["CLOSING_DATE"].ToString()));
        }
        else
        {
            this.Session.Add("CurrentWorkDate", DateTime.Now);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.txtLogin.Focus();
        }
    }

    public void ValidateUser()
    {
        if ((this.txtLogin.Text != "") || (this.txtPassword.Text != ""))
        {
            DataTable table = this.mController.SelectSlashUser(this.txtLogin.Text, this.txtPassword.Text);
            this.Session.Clear();
            if (table.Rows.Count > 0)
            {
                this.Session.Add("UserID", Convert.ToInt32(table.Rows[0]["USER_ID"].ToString()));
                this.Session.Add("UserName", table.Rows[0]["USER_DETAIL"].ToString());
                this.Session.Add("DISTRIBUTOR_ID", Convert.ToInt32(table.Rows[0]["DISTRIBUTOR_ID"]));
                this.Session.Add("CompanyId", Convert.ToInt32(table.Rows[0]["COMPANY_ID"].ToString()));
                this.Session.Add("RoleID", Convert.ToInt32(table.Rows[0]["ROLE_ID"]));
                this.LastClosedDay(Convert.ToInt32(table.Rows[0]["USER_ID"]), Convert.ToInt32(table.Rows[0]["DISTRIBUTOR_ID"]));
                this.Session.Add("UserName2", table.Rows[0]["USER_NAME"].ToString());
                this.Session.Add("UserName", table.Rows[0]["USER_DETAIL"].ToString());
                base.Response.Redirect("Forms/Home.aspx");
            }
            else
            {
                this.lblErrorMsg.Visible = true;
                this.lblErrorMsg.Text = "Wrong User Id/Password";
            }
        }
    }


}