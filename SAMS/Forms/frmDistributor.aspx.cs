using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmDistributor : System.Web.UI.Page
{
    private static int CompanyId;
    private static int DistributorId;
    private DistributorController mController = new DistributorController();

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GridDistributor.EditIndex = -1;
        if (this.btnSave.Text == "Save")
        {
            this.mController.InsertDistributor(int.Parse(this.DrpCompanyName.SelectedValue.ToString()), -2147483648, false, DateTime.Now, DateTime.Now, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.ddDistributorType.SelectedValue.ToString()), this.txtcontactperson.Text, this.txtPhoneNo.Text, this.txtgstno.Text, this.txtpassword.Text, this.txtAddress1.Text, this.txtAddress2.Text, this.txtDistributorCode.Text, this.txtDistributorName.Text, null, this.CheckBox1.Checked, 1, int.Parse(this.Session["UserId"].ToString()));
        }
        else
        {
            this.mController.UpdateDistributor(int.Parse(this.DrpCompanyName.SelectedValue.ToString()), -2147483648, false, Constants.DateNullValue, DateTime.Now, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.ddDistributorType.SelectedValue.ToString()), this.txtcontactperson.Text, this.txtPhoneNo.Text, this.txtgstno.Text, this.txtpassword.Text, this.txtAddress1.Text, this.txtAddress2.Text, DistributorId, this.txtDistributorCode.Text, this.txtDistributorName.Text, null, this.CheckBox1.Checked, 1, int.Parse(this.Session["UserId"].ToString()));
        }
        this.lblErrorMsg.Text = "";
        this.ClearAll();
        this.LoadGird();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ClearAll();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.LoadGird();
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (this.CheckBox1.Checked)
        {
            this.txtgstno.Enabled = true;
            this.txtgstno.Focus();
        }
        else
        {
            this.txtgstno.Text = "";
            this.txtgstno.Enabled = false;
        }
    }

    private void ClearAll()
    {
        this.txtDistributorName.Text = "";
        this.txtDistributorCode.Text = "";
        this.txtAddress1.Text = "";
        this.txtAddress2.Text = "";
        this.txtcontactperson.Text = "";
        this.txtPhoneNo.Text = "";
        this.txtpassword.Text = "";
        this.txtgstno.Text = "";
        this.btnSave.Text = "Save";
        this.CheckBox1.Checked = false;
    }

    protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void GetDistributorType()
    {
        DataTable table = this.mController.SelectDistributorTypeInfo(-2147483648);
        clsWebFormUtil.FillDropDownList(this.ddDistributorType, table, 0, 2);
    }

    protected void GridDistributor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridDistributor.PageIndex = e.NewPageIndex;
        this.LoadGird();
    }

    protected void GridDistributor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DistributorId = int.Parse(this.GridDistributor.Rows[e.RowIndex].Cells[0].Text);
        CompanyId = int.Parse(this.GridDistributor.Rows[e.RowIndex].Cells[11].Text);
        bool.Parse(this.GridDistributor.Rows[e.RowIndex].Cells[1].Text);
        this.mController.UpdateDistributor(CompanyId, -2147483648, true, Constants.DateNullValue, DateTime.Now, -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, null, null, null, null, null, null, DistributorId, null, null, null, true, 1, int.Parse(this.Session["UserId"].ToString()));
        this.LoadGird();
    }

    protected void GridDistributor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DistributorId = int.Parse(this.GridDistributor.Rows[e.NewEditIndex].Cells[0].Text);
        this.DrpCompanyName.SelectedValue = this.GridDistributor.Rows[e.NewEditIndex].Cells[11].Text;
        this.CheckBox1.Checked = bool.Parse(this.GridDistributor.Rows[e.NewEditIndex].Cells[1].Text);
        this.ddDistributorType.SelectedValue = this.GridDistributor.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtAddress2.Text = this.GridDistributor.Rows[e.NewEditIndex].Cells[3].Text;
        this.txtDistributorCode.Text = this.GridDistributor.Rows[e.NewEditIndex].Cells[4].Text;
        this.txtDistributorName.Text = this.GridDistributor.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtAddress1.Text = this.GridDistributor.Rows[e.NewEditIndex].Cells[7].Text;
        this.txtcontactperson.Text = this.GridDistributor.Rows[e.NewEditIndex].Cells[8].Text;
        this.txtPhoneNo.Text = this.GridDistributor.Rows[e.NewEditIndex].Cells[9].Text;
        if (this.GridDistributor.Rows[e.NewEditIndex].Cells[10].Text == "&nbsp;")
        {
            this.txtgstno.Text = "";
        }
        else
        {
            this.txtgstno.Text = this.GridDistributor.Rows[e.NewEditIndex].Cells[10].Text;
        }
        this.btnSave.Text = "Update";
    }

    private void LoadCompany()
    {
        DataTable table = new CompanyController().SelectCompany(-2147483648, -2147483648);
        clsWebFormUtil.FillDropDownList(this.DrpCompanyName, table, 0, 1, true);
    }

    private void LoadGird()
    {
        if (this.ddDistributorType.Items.Count > 0)
        {
            DataTable table = this.mController.SelectDistributor(-2147483648, -2147483648, -2147483648);
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

                case 4:
                    table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                    break;

                case 5:
                    table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                    break;

                default:
                    table.DefaultView.RowFilter = "Distributor_name like '%%'";
                    break;
            }
            this.GridDistributor.DataSource = table;
            this.GridDistributor.Columns[0].Visible = true;
            this.GridDistributor.Columns[1].Visible = true;
            this.GridDistributor.Columns[2].Visible = true;
            this.GridDistributor.Columns[3].Visible = true;
            this.GridDistributor.Columns[11].Visible = true;
            this.GridDistributor.DataBind();
            this.GridDistributor.Columns[0].Visible = false;
            this.GridDistributor.Columns[1].Visible = false;
            this.GridDistributor.Columns[2].Visible = false;
            this.GridDistributor.Columns[3].Visible = false;
            this.GridDistributor.Columns[11].Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.GetDistributorType();
            this.LoadGird();
            this.LoadCompany();
            this.btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }
    }
}