using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptPrincipalWiseExp : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            DateTime time = DateTime.Parse(this.txtFromDate.Text);
            DateTime time2 = DateTime.Parse(this.txtToDate.Text);
            string str = time.ToShortDateString();
            string str2 = time2.ToShortDateString();
            string str3 = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrincipalWiseExp exp = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrincipalWiseExp();
            DataSet dataSet = null;
            for (int i = 0; i < this.LstAccountHead.Items.Count; i++)
            {
                if (this.LstAccountHead.Items[i].Selected)
                {
                    str3 = str3 + this.LstAccountHead.Items[i].Value.ToString() + ",";
                }
            }
            dataSet = controller.PrincipalWiseSale(int.Parse(this.drpPrincipal.SelectedValue.ToString()), Convert.ToInt32(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str + " 00:00:00"), Convert.ToDateTime(str2 + " 00:00:00"), str3, this.RadioButtonList1.SelectedIndex);
            exp.SetDataSource(dataSet);
            exp.Refresh();
            exp.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            exp.SetParameterValue("Distributor", this.DrpLocation.SelectedItem.Text.ToString());
            exp.SetParameterValue("From_date", this.txtFromDate.Text);
            exp.SetParameterValue("To_Date", this.txtToDate.Text);
            exp.SetParameterValue("ReportTitle", "Principal Wise Petty Report");
            this.Session.Add("CrpReport", exp);
            this.Session.Add("ReportType", 0);
            string str4 = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str4 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void ChbAllLocationType_CheckedChanged(object sender, EventArgs e)
    {
        this.CheckAll();
    }

    protected void CheckAll()
    {
        if (this.ChbAllAccountHead.Checked)
        {
            for (int i = 0; i < this.LstAccountHead.Items.Count; i++)
            {
                this.LstAccountHead.Items[i].Selected = true;
            }
        }
        else
        {
            for (int j = 0; j < this.LstAccountHead.Items.Count; j++)
            {
                this.LstAccountHead.Items[j].Selected = false;
            }
        }
    }

    private void LoadAccountHead()
    {
        Configuration.GetAccountHead();
        DataTable table = new AccountHeadController().SelectAccountHead(0x5e, long.Parse(Configuration.ExpensDefaultType));
        clsWebFormUtil.FillListBox(this.LstAccountHead, table, 0, 4);
    }

    private void LoadDistributor()
    {
        this.DrpLocation.Items.Clear();
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        int num = -2147483648;
        this.DrpLocation.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpLocation, table, 0, 2);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        int num = -2147483648;
        this.drpPrincipal.Items.Add(new ListItem("All", num.ToString()));
        this.drpPrincipal.Items.Add(new ListItem("General Expense", "0"));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadAccountHead();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtFromDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtToDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}