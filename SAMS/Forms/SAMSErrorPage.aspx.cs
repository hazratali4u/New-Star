using System;

public partial class Forms_SAMSErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack && (this.Session["UserID"] == null))
        {
            this.Session.Clear();
            base.Response.Redirect("~/Login.aspx");
        }
    }
}