using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;

public partial class Forms_Level : System.Web.UI.Page
{
    private RoleManagementController ObjRole = new RoleManagementController();

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView view = (GridView)e.Row.FindControl("gvForms");
            int num = (int)this.Session["RoleID"];
            int num2 = int.Parse(((GridView)sender).DataKeys[e.Row.RowIndex].Value.ToString());
            DataTable table = this.ObjRole.SelectRoleWiseModule(num, 4, num2);
            if ((table != null) && (table.Rows.Count > 0))
            {
                view.DataSource = table;
                view.DataBind();
            }
        }
    }

    private void LoadMainGrid()
    {
        int num = (int)this.Session["RoleID"];
        DataTable table = this.ObjRole.SelectRoleWiseModule(num, 3, Convert.ToInt32(base.Request.QueryString["LevelID"]));
        this.gvMain.DataSource = table;
        this.gvMain.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadMainGrid();
        }
    }
}