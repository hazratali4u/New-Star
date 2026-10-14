using System;
using System.Web.Security;

public partial class Forms_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        this.Session.Abandon();
        base.Response.Redirect("../Login.aspx");
    }
}