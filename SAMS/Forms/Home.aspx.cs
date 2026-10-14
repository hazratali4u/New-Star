using System;

public partial class Forms_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack && (this.Session["Message"] != null))
        {
            this.lblMessage.Text = this.Session["Message"].ToString();
            this.Session["Message"] = null;
        }
    }
}