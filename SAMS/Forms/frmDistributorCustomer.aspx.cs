using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmDistributorCustomer : System.Web.UI.Page
{
    private static long CustomerId;
    private static string StrCode;

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Grid_users.EditIndex = -1;
        CustomerDataController controller = new CustomerDataController();
        if (this.btnSave.Text == "Save")
        {
            DataTable table = new SETTINGS_TABLE_Controller().Select_SETTINGS_TABLE("CUSTOMER", "CUSTOMER_ID", int.Parse(this.DrpDistributor.SelectedValue.ToString()));
            if (table.Rows.Count > 0)
            {
                CustomerId = long.Parse(table.Rows[0]["Value"].ToString()) + 1L;
                if (CustomerId.ToString().Length == 1)
                {
                    StrCode = "OT0000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 2)
                {
                    StrCode = "OT000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 3)
                {
                    StrCode = "OT00" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 4)
                {
                    StrCode = "OT0" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 5)
                {
                    StrCode = "OT" + CustomerId.ToString();
                }
                controller.InsertCustomer(CustomerId, this.ChbIsRegister.Checked, this.chkIsActive.Checked, int.Parse(this.drpChannelType.SelectedValue.ToString()), int.Parse(this.DrpVolumeClass.SelectedValue.ToString()), int.Parse(this.DrpBusinessType.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpMarket.SelectedValue.ToString()), int.Parse(this.DrpTown.SelectedValue.ToString()), int.Parse(this.DrpDistributor.SelectedValue.ToString()), this.txtIsRegister.Text, this.txtContactPerson.Text, this.txtPhoneNo.Text, this.txtemail.Text, StrCode, this.txtCustomerName.Text, this.txtAddress.Text, DateTime.Parse(this.txtRegdate.Text));
            }
        }
        else
        {
            controller.UpdateCustomer(CustomerId, this.ChbIsRegister.Checked, this.chkIsActive.Checked, int.Parse(this.drpChannelType.SelectedValue.ToString()), int.Parse(this.DrpVolumeClass.SelectedValue.ToString()), int.Parse(this.DrpBusinessType.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpMarket.SelectedValue.ToString()), int.Parse(this.DrpTown.SelectedValue.ToString()), int.Parse(this.DrpDistributor.SelectedValue.ToString()), this.txtIsRegister.Text, this.txtContactPerson.Text, this.txtPhoneNo.Text, this.txtemail.Text, null, this.txtCustomerName.Text, this.txtAddress.Text, Constants.DateNullValue);
        }
        this.UpdateCustomerPrincipalCredit();
        ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Record Update');", true);
        this.ClearAll();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ClearAll();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.LoadCustomer();
    }

    protected void ChbIsRegister_CheckedChanged(object sender, EventArgs e)
    {
        if (this.ChbIsRegister.Checked)
        {
            this.txtIsRegister.Text = "";
            this.txtIsRegister.Enabled = true;
        }
        else
        {
            this.txtIsRegister.Text = "";
            this.txtIsRegister.Enabled = false;
        }
    }

    private void ClearAll()
    {
        this.txtCustomerName.Text = "";
        this.txtContactPerson.Text = "";
        this.txtAddress.Text = "";
        this.txtemail.Text = "";
        this.txtPhoneNo.Text = "";
        this.txtSeach.Text = "";
        this.txtIsRegister.Text = "";
        this.btnSave.Text = "Save";
        this.Grid_users.DataSource = null;
        this.Grid_users.DataBind();
        this.LoadPrincipal();
    }

    protected void DrpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
        this.LoadArea();
        this.LoadRoute();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRoute();
    }

    protected void DrpTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadRoute();
    }

    protected void Grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.Grid_users.PageIndex = e.NewPageIndex;
        this.LoadCustomer();
    }

    protected void Grid_users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CustomerId = int.Parse(this.Grid_users.Rows[e.NewEditIndex].Cells[0].Text);
        this.DrpDistributor.SelectedValue = this.Grid_users.Rows[e.NewEditIndex].Cells[1].Text;
        this.DrpBusinessType.SelectedValue = this.Grid_users.Rows[e.NewEditIndex].Cells[2].Text;
        this.DrpVolumeClass.SelectedValue = this.Grid_users.Rows[e.NewEditIndex].Cells[3].Text;
        this.drpChannelType.SelectedValue = this.Grid_users.Rows[e.NewEditIndex].Cells[4].Text;
        this.LoadTown();
        this.DrpTown.SelectedValue = this.Grid_users.Rows[e.NewEditIndex].Cells[5].Text;
        this.LoadArea();
        this.DrpRoute.SelectedValue = this.Grid_users.Rows[e.NewEditIndex].Cells[6].Text;
        this.LoadRoute();
        this.DrpMarket.SelectedValue = this.Grid_users.Rows[e.NewEditIndex].Cells[7].Text;
        this.txtCustomerName.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[9].Text.Replace("amp;", "");
        this.txtContactPerson.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[10].Text.Replace("&nbsp;", "");
        this.txtPhoneNo.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[11].Text.Replace("&nbsp;", "");
        this.txtemail.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[12].Text.Replace("&nbsp;", "");
        this.txtAddress.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[13].Text.Replace("&nbsp;", "");
        this.txtIsRegister.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[14].Text.Replace("&nbsp;", "");
        if (this.Grid_users.Rows[e.NewEditIndex].Cells[14].Text.Trim() == "&nbsp;")
        {
            this.txtIsRegister.Text = "";
            this.ChbIsRegister.Checked = false;
        }
        else
        {
            this.ChbIsRegister.Checked = true;
            this.txtIsRegister.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[14].Text;
        }
        this.chkIsActive.Checked = bool.Parse(this.Grid_users.Rows[e.NewEditIndex].Cells[0x13].Text);
        this.txtRegdate.Text = this.Grid_users.Rows[e.NewEditIndex].Cells[20].Text;
        CustomerDataController controller = new CustomerDataController();
        for (int i = 0; i < this.GrdCreditLimit.Rows.Count; i++)
        {
            DataTable table = controller.SelectCustomerCreditLimit(int.Parse(this.DrpDistributor.SelectedValue.ToString()), CustomerId, int.Parse(this.GrdCreditLimit.Rows[i].Cells[0].Text));
            if (table.Rows.Count > 0)
            {
                TextBox box = (TextBox)this.GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
                TextBox box2 = (TextBox)this.GrdCreditLimit.Rows[i].FindControl("txtCreditDays");
                box.Text = table.Rows[0]["CREDITLIMIT_VALUE"].ToString();
                box2.Text = table.Rows[0]["CREDIT_DAYS"].ToString();
            }
            else
            {
                TextBox box3 = (TextBox)this.GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
                TextBox box4 = (TextBox)this.GrdCreditLimit.Rows[i].FindControl("txtCreditDays");
                box3.Text = "0";
                box4.Text = "0";
            }
        }
        this.btnSave.Text = "Update";
    }

    private void LoadArea()
    {
        if ((this.DrpDistributor.Items.Count > 0) && (this.DrpTown.Items.Count > 0))
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.DrpDistributor.SelectedValue.ToString()), int.Parse(this.DrpTown.SelectedValue.ToString()), null, null);
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
        }
    }

    private void LoadBusinessType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2f, null, -2147483648, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(this.DrpBusinessType, table, 0, 2, true);
    }

    private void LoadChannelType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(this.drpChannelType, table, 0, 2, true);
    }

    private void LoadCustomer()
    {
        if (((this.DrpDistributor.Items.Count > 0) && (this.DrpTown.Items.Count > 0)) && ((this.DrpRoute.Items.Count > 0) && (this.DrpMarket.Items.Count > 0)))
        {
            DataTable table = new CustomerDataController().UspSelectCustomer(int.Parse(this.DrpDistributor.SelectedValue.ToString()), this.ddSearchType.SelectedValue.ToString(), this.txtSeach.Text);
            this.Grid_users.DataSource = table;
            this.Grid_users.DataBind();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpDistributor, table, 0, 2, true);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.GrdCreditLimit.DataSource = table;
        this.GrdCreditLimit.DataBind();
    }

    private void LoadRoute()
    {
        if (((this.DrpDistributor.Items.Count > 0) && (this.DrpTown.Items.Count > 0)) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new DistributorRouteController().SelectDistributorRoute(-9223372036854775808L, int.Parse(this.DrpDistributor.SelectedValue.ToString()), int.Parse(this.DrpTown.SelectedValue.ToString()), long.Parse(this.DrpRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpMarket, table, 0, 8, true);
        }
        else
        {
            this.DrpMarket.Items.Clear();
        }
    }

    protected void LoadTown()
    {
        if (this.DrpDistributor.Items.Count > 0)
        {
            DataTable table = new GeoHierarchyController().SelectGeoHierarchy(int.Parse(this.DrpDistributor.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpTown, table, 0, 1, true);
        }
    }

    private void LoadVolumeType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x30, null, -2147483648, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(this.DrpVolumeClass, table, 0, 2, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadTown();
            this.LoadArea();
            this.LoadRoute();
            this.LoadChannelType();
            this.LoadBusinessType();
            this.LoadVolumeType();
            this.btnSave.Attributes.Add("onclick", "return ValidateForm()");
            this.Button2.Attributes.Add("onclick", "return SearchRecord()");            
            this.txtRegdate.Text = Convert.ToDateTime(Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
        }
    }

    private void UpdateCustomerPrincipalCredit()
    {
        CustomerDataController controller = new CustomerDataController();
        DataControl control = new DataControl();
        controller.UpdateCustomerCreditLimit(int.Parse(this.DrpDistributor.SelectedValue.ToString()), CustomerId, -2147483648, -79228162514264337593543950335M);
        for (int i = 0; i < this.GrdCreditLimit.Rows.Count; i++)
        {
            TextBox box = (TextBox)this.GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
            TextBox box2 = (TextBox)this.GrdCreditLimit.Rows[i].FindControl("txtCreditDays");
            if (decimal.Parse(control.chkNull_0(box.Text)) > 0M)
            {
                controller.InsertCustomerCreditLimit(int.Parse(this.DrpDistributor.SelectedValue.ToString()), CustomerId, int.Parse(this.GrdCreditLimit.Rows[i].Cells[0].Text), decimal.Parse(box.Text), int.Parse(box2.Text));
            }
        }
    }
}