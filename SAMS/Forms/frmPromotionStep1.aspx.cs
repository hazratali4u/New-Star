using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmPromotionStep1 : System.Web.UI.Page
{
    protected void btnPromotion_Click(object sender, EventArgs e)
    {
        SchemeController controller = new SchemeController();
        if (this.btnPromotion.Text == "Get Promotion")
        {
            string str = this.txtFromdate.Text + " 00:00:00";
            string str2 = this.txttoDate.Text + " 23:59:59";
            DataTable table = controller.SelectPromotion(str, str2, int.Parse(this.Session["UserId"].ToString()), this.ChbActive.Checked);
            this.Session.Add("dt", table);
            this.Grid_pricedetails.DataSource = table;
            this.Grid_pricedetails.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Session.Add("IsEdit", false);
        base.Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString(), true);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    protected void drpScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    public void FillScheme()
    {
        DataTable table = new SchemeController().SelectScheme(-2147483648, Configuration.DistributorId, null, null, Constants.DateNullValue);
        this.drpScheme.Items.Clear();
        this.drpScheme.Items.Add((ListItem)new clsListItems("ALL", "0"));
        this.drpScheme.DataSource = table;
        clsWebFormUtil.FillDropDownList(this.drpScheme, table, "SCHEME_ID", "SCHEME_CODE");
    }

    protected void Grid_pricedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.Grid_pricedetails.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }

    protected void Grid_pricedetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PromotionController controller = new PromotionController();
        SchemeController controller2 = new SchemeController();
        int num = int.Parse(this.Grid_pricedetails.Rows[e.RowIndex].Cells[1].Text);
        int num2 = int.Parse(this.Grid_pricedetails.Rows[e.RowIndex].Cells[0].Text);
        controller.UpdatePromotion((long)num, num2, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), null, null, Constants.DateNullValue, false, Constants.DateNullValue, Constants.DateNullValue, false, -2147483648, -2147483648);
        string str = this.txtFromdate.Text + " 00:00:00";
        string str2 = this.txttoDate.Text + " 23:59:59";
        DataTable table = controller2.SelectPromotion(str, str2, int.Parse(this.Session["UserId"].ToString()), this.ChbActive.Checked);
        this.Session.Add("dt", table);
        this.Grid_pricedetails.DataSource = table;
        this.Grid_pricedetails.DataBind();
    }

    protected void Grid_pricedetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        bool flag = true;
        string str = "f";
        string text = this.Grid_pricedetails.Rows[e.NewEditIndex].Cells[1].Text;
        this.Session.Add("PromotionId", text);
        this.Session.Add("IsEdit", flag);
        this.Session.Add("Flow", str);
        base.Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString(), true);
    }

    protected void ImgBntFromCalc_Click(object sender, ImageClickEventArgs e)
    {
        this.txtFromdate.Text = null;
    }

    private void LoadGrid()
    {
        DataTable table = (DataTable)this.Session["dt"];
        switch (this.ddSearchType.SelectedIndex)
        {
            case 1:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 2:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " =" + this.txtSeach.Text;
                break;

            case 3:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 4:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 5:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            default:
                table.DefaultView.RowFilter = "PROMOTION_CODE like '%%'";
                break;
        }
        this.Grid_pricedetails.DataSource = table;
        this.Grid_pricedetails.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.FillScheme();
            this.btnPromotion.Attributes.Add("onclick", "return ValidateForm()");
        }
    }
}