using SAMS.BusinessLayer.Classes;
using System;
using System.Data;

public partial class Forms_Level2 : System.Web.UI.Page
{
    private RoleManagementController ObjRole = new RoleManagementController();

    private void LoadFormGrid()
    {
        int num = (int)this.Session["RoleID"];
        DataTable table = this.ObjRole.SelectRoleWiseModule(num, 4, Convert.ToInt32(base.Request.QueryString["LevelID"]));
        this.gvFrom.DataSource = table;
        this.gvFrom.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadFormGrid();
        }
    }
}