using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_frmOrderEntry : System.Web.UI.Page
{
    private DataTable dtFreeSKU;
    private static int mCustomerTypeId;
    private static int mCustomerVolClassId;
    private int mTownId;
    private DataTable PurchaseSKU;
    private static int RowId;
    private static int UnitType;

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        if (this.FindCustomer())
        {
            decimal d = 0M;
            decimal num2 = 0M;
            decimal num3 = 0M;
            decimal num4 = 0M;
            decimal num5 = 0M;
            decimal num6 = 0M;
            DataControl control = new DataControl();
            OrderEntryController controller = new OrderEntryController();
            DataTable table = (DataTable)this.Session["PurchaseSKU"];
            foreach (DataRow row in table.Rows)
            {
                row["STANDARD_DISCOUNT"] = 0;
                row["STANDARD_DISCOUNT_PER"] = 0;
                row["EXTRA_DISCOUNT"] = 0;
            }
            PromotionCollections_Controller controller2 = (PromotionCollections_Controller)this.Session["Arpc"];
            this.CreateFreeSKU();
            this.LoadFreeGrid();
            if ((table.Rows.Count > 0) && (this.txtOutletCode.Text.Length > 0))
            {
                if (this.txtDiscountType.Text == "Auto Discount")
                {
                    ArrayList list = controller.GetPromotionOffers(controller2, mCustomerVolClassId, mCustomerTypeId, table, false);
                    for (int i = 0; i < list.Count; i++)
                    {
                        PromoOffers_Collection s_s = (PromoOffers_Collection)list[i];
                        if (s_s.SKU_ID > 0)
                        {
                            foreach (DataRow row2 in table.Rows)
                            {
                                if (int.Parse(row2["SKU_ID"].ToString()) == s_s.SKU_ID)
                                {
                                    if (s_s.Is_And)
                                    {
                                        if (s_s.Offer_Value > 0M)
                                        {
                                            row2["EXTRA_DISCOUNT"] = decimal.Parse(control.chkNull_0(row2["EXTRA_DISCOUNT"].ToString())) + s_s.Offer_Value;
                                        }
                                        if (s_s.Discount > 0f)
                                        {
                                            row2["EXTRA_DISCOUNT"] = decimal.Parse(control.chkNull_0(row2["EXTRA_DISCOUNT"].ToString())) + ((decimal.Parse(s_s.Discount.ToString()) / 100M) * decimal.Parse(row2["AMOUNT"].ToString()));
                                        }
                                    }
                                    else
                                    {
                                        bool flag1 = s_s.Offer_Value > 0M;
                                        if (s_s.Discount > 0f)
                                        {
                                            row2["STANDARD_DISCOUNT_PER"] = decimal.Parse(control.chkNull_0(row2["STANDARD_DISCOUNT_PER"].ToString())) + (decimal.Parse(s_s.Discount.ToString()) / 100M);
                                        }
                                    }
                                    if (s_s.Free_SKU_ID > 0)
                                    {
                                        DataRow[] rowArray = ((DataTable)this.Session["Dtsku_Price"]).Select("SKU_ID  = '" + s_s.Free_SKU_ID.ToString() + "'");
                                        int num8 = this.FreeSKUExist(this.dtFreeSKU, s_s.Free_SKU_ID);
                                        if (rowArray.Length > 0)
                                        {
                                            if (num8 < 0)
                                            {
                                                DataRow row3 = this.dtFreeSKU.NewRow();
                                                row3["SKU_ID"] = rowArray[0]["SKU_ID"];
                                                row3["SKU_Code"] = rowArray[0]["SKU_CODE"];
                                                row3["SKU_Name"] = rowArray[0]["SKU_NAME"];
                                                if (rowArray[0]["GST_ON"].ToString().Trim() == "T")
                                                {
                                                    row3["UNIT_PRICE"] = rowArray[0]["TRADE_PRICE"];
                                                    row3["Quantity"] = s_s.Quantity.ToString();
                                                    row3["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                                                    row3["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                                    row3["GST_AMOUNT"] = (decimal.Parse(control.chkNull_0(rowArray[0]["GST_RATE_TP"].ToString())) / 100M) * decimal.Parse(row3["AMOUNT"].ToString());
                                                }
                                                else if (rowArray[0]["GST_ON"].ToString().Trim() == "R")
                                                {
                                                    row3["UNIT_PRICE"] = rowArray[0]["TRADE_PRICE"];
                                                    row3["Quantity"] = s_s.Quantity.ToString();
                                                    row3["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                                                    row3["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                                    row3["GST_AMOUNT"] = 0;
                                                }
                                                else
                                                {
                                                    row3["UNIT_PRICE"] = rowArray[0]["TRADE_PRICE"];
                                                    row3["Quantity"] = s_s.Quantity.ToString();
                                                    row3["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                                                    row3["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                                    row3["GST_AMOUNT"] = 0;
                                                }
                                                row3["PROMOTION_ID"] = s_s.Promotion_ID.ToString();
                                                row3["BASKET_ID"] = s_s.Basket_ID.ToString();
                                                row3["BASKET_DETAIL_ID"] = s_s.BasketDetail_ID.ToString();
                                                row3["PROMOTION_OFFER_ID"] = s_s.PromoOffer_ID.ToString();
                                                num6 += decimal.Parse(row3["AMOUNT"].ToString());
                                                num5 += decimal.Parse(control.chkNull_0(row3["GST_AMOUNT"].ToString()));
                                                this.dtFreeSKU.Rows.Add(row3);
                                            }
                                            else
                                            {
                                                DataRow row4 = this.dtFreeSKU.Rows[num8];
                                                num6 -= decimal.Parse(row4["AMOUNT"].ToString());
                                                num5 -= decimal.Parse(row4["GST_AMOUNT"].ToString());
                                                row4["SKU_ID"] = rowArray[0]["SKU_ID"];
                                                row4["SKU_Code"] = rowArray[0]["SKU_CODE"];
                                                row4["SKU_Name"] = rowArray[0]["SKU_NAME"];
                                                row4["Quantity"] = int.Parse(row4["Quantity"].ToString()) + s_s.Quantity;
                                                if (rowArray[0]["GST_ON"].ToString().Trim() == "T")
                                                {
                                                    row4["UNIT_PRICE"] = rowArray[0]["TRADE_PRICE"];
                                                    row4["Quantity"] = s_s.Quantity.ToString();
                                                    row4["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                                                    row4["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                                    row4["GST_AMOUNT"] = (decimal.Parse(control.chkNull_0(rowArray[0]["GST_RATE_TP"].ToString())) / 100M) * decimal.Parse(row4["AMOUNT"].ToString());
                                                }
                                                else if (rowArray[0]["GST_ON"].ToString().Trim() == "R")
                                                {
                                                    row4["UNIT_PRICE"] = rowArray[0]["TRADE_PRICE"];
                                                    row4["Quantity"] = s_s.Quantity.ToString();
                                                    row4["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                                                    row4["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                                    row4["GST_AMOUNT"] = 0;
                                                }
                                                else
                                                {
                                                    row4["UNIT_PRICE"] = rowArray[0]["TRADE_PRICE"];
                                                    row4["Quantity"] = s_s.Quantity.ToString();
                                                    row4["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                                                    row4["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                                }
                                                row4["PROMOTION_ID"] = s_s.Promotion_ID.ToString();
                                                row4["BASKET_ID"] = s_s.Basket_ID.ToString();
                                                row4["BASKET_DETAIL_ID"] = s_s.BasketDetail_ID.ToString();
                                                row4["PROMOTION_OFFER_ID"] = s_s.PromoOffer_ID.ToString();
                                                num6 += decimal.Parse(row4["AMOUNT"].ToString());
                                                num5 += decimal.Parse(control.chkNull_0(row4["GST_AMOUNT"].ToString()));
                                            }
                                        }
                                    }
                                    this.Session.Add("dtFreeSKU", this.dtFreeSKU);
                                    this.LoadFreeGrid();
                                }
                            }
                        }
                        else
                        {
                            if (s_s.Free_SKU_ID > 0)
                            {
                                DataRow[] rowArray2 = ((DataTable)this.Session["Dtsku_Price"]).Select("SKU_ID  = '" + s_s.Free_SKU_ID.ToString() + "'");
                                int num9 = this.FreeSKUExist(this.dtFreeSKU, s_s.Free_SKU_ID);
                                if (rowArray2.Length > 0)
                                {
                                    if (num9 < 0)
                                    {
                                        DataRow row5 = this.dtFreeSKU.NewRow();
                                        row5["SKU_ID"] = rowArray2[0]["SKU_ID"];
                                        row5["SKU_Code"] = rowArray2[0]["SKU_CODE"];
                                        row5["SKU_Name"] = rowArray2[0]["SKU_NAME"];
                                        row5["UNIT_PRICE"] = rowArray2[0]["TRADE_PRICE"];
                                        row5["Quantity"] = s_s.Quantity.ToString();
                                        if (rowArray2[0]["GST_ON"].ToString().Trim() == "T")
                                        {
                                            row5["UNIT_PRICE"] = rowArray2[0]["TRADE_PRICE"];
                                            row5["Quantity"] = s_s.Quantity.ToString();
                                            row5["GST_RATE"] = rowArray2[0]["GST_RATE_TP"];
                                            row5["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray2[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                            row5["GST_AMOUNT"] = (decimal.Parse(control.chkNull_0(rowArray2[0]["GST_RATE_TP"].ToString())) / 100M) * decimal.Parse(row5["AMOUNT"].ToString());
                                        }
                                        else if (rowArray2[0]["GST_ON"].ToString().Trim() == "R")
                                        {
                                            row5["UNIT_PRICE"] = rowArray2[0]["TRADE_PRICE"];
                                            row5["Quantity"] = s_s.Quantity.ToString();
                                            row5["GST_RATE"] = rowArray2[0]["GST_RATE_TP"];
                                            row5["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray2[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                            row5["GST_AMOUNT"] = 0;
                                        }
                                        else
                                        {
                                            row5["UNIT_PRICE"] = rowArray2[0]["TRADE_PRICE"];
                                            row5["GST_RATE"] = rowArray2[0]["GST_RATE_TP"];
                                            row5["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray2[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                            row5["GST_AMOUNT"] = 0;
                                        }
                                        row5["PROMOTION_ID"] = s_s.Promotion_ID.ToString();
                                        row5["BASKET_ID"] = s_s.Basket_ID.ToString();
                                        row5["BASKET_DETAIL_ID"] = s_s.BasketDetail_ID.ToString();
                                        row5["PROMOTION_OFFER_ID"] = s_s.PromoOffer_ID.ToString();
                                        num6 += decimal.Parse(row5["AMOUNT"].ToString());
                                        num5 += decimal.Parse(control.chkNull_0(row5["GST_AMOUNT"].ToString()));
                                        this.dtFreeSKU.Rows.Add(row5);
                                    }
                                    else
                                    {
                                        DataRow row6 = this.dtFreeSKU.Rows[num9];
                                        num6 -= decimal.Parse(row6["AMOUNT"].ToString());
                                        num5 -= decimal.Parse(row6["GST_AMOUNT"].ToString());
                                        row6["SKU_ID"] = rowArray2[0]["SKU_ID"];
                                        row6["SKU_Code"] = rowArray2[0]["SKU_CODE"];
                                        row6["SKU_Name"] = rowArray2[0]["SKU_NAME"];
                                        row6["Quantity"] = int.Parse(row6["Quantity"].ToString()) + s_s.Quantity;
                                        if (rowArray2[0]["GST_ON"].ToString().Trim() == "T")
                                        {
                                            row6["UNIT_PRICE"] = rowArray2[0]["TRADE_PRICE"];
                                            row6["GST_RATE"] = rowArray2[0]["GST_RATE_TP"];
                                            row6["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray2[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                            row6["GST_AMOUNT"] = (decimal.Parse(control.chkNull_0(rowArray2[0]["GST_RATE_TP"].ToString())) / 100M) * decimal.Parse(row6["AMOUNT"].ToString());
                                        }
                                        else if (rowArray2[0]["GST_ON"].ToString().Trim() == "R")
                                        {
                                            row6["UNIT_PRICE"] = rowArray2[0]["TRADE_PRICE"];
                                            row6["GST_RATE"] = rowArray2[0]["GST_RATE_TP"];
                                            row6["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray2[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                            row6["GST_AMOUNT"] = 0;
                                        }
                                        else
                                        {
                                            row6["UNIT_PRICE"] = rowArray2[0]["TRADE_PRICE"];
                                            row6["GST_RATE"] = rowArray2[0]["GST_RATE_TP"];
                                            row6["AMOUNT"] = decimal.Parse(control.chkNull_0(rowArray2[0]["TRADE_PRICE"].ToString())) * decimal.Parse(s_s.Quantity.ToString());
                                            row6["GST_AMOUNT"] = 0;
                                        }
                                        row6["PROMOTION_ID"] = s_s.Promotion_ID.ToString();
                                        row6["BASKET_ID"] = s_s.Basket_ID.ToString();
                                        row6["BASKET_DETAIL_ID"] = s_s.BasketDetail_ID.ToString();
                                        row6["PROMOTION_OFFER_ID"] = s_s.PromoOffer_ID.ToString();
                                        num6 += decimal.Parse(row6["AMOUNT"].ToString());
                                        num5 += decimal.Parse(control.chkNull_0(row6["GST_AMOUNT"].ToString()));
                                    }
                                    this.Session.Add("dtFreeSKU", this.dtFreeSKU);
                                    this.LoadFreeGrid();
                                }
                            }
                            foreach (DataRow row7 in table.Rows)
                            {
                                if (controller.ExistsInGroup(-2147483648, s_s.Group_ID, int.Parse(row7["SKU_ID"].ToString())))
                                {
                                    if (s_s.Is_And)
                                    {
                                        if (s_s.Offer_Value > 0M)
                                        {
                                            row7["EXTRA_DISCOUNT"] = decimal.Parse(control.chkNull_0(row7["EXTRA_DISCOUNT"].ToString())) + s_s.Offer_Value;
                                        }
                                        if (s_s.Discount > 0f)
                                        {
                                            row7["EXTRA_DISCOUNT"] = decimal.Parse(control.chkNull_0(row7["EXTRA_DISCOUNT"].ToString())) + ((decimal.Parse(s_s.Discount.ToString()) / 100M) * (decimal.Parse(row7["AMOUNT"].ToString()) - decimal.Parse(control.chkNull_0(row7["EXTRA_DISCOUNT"].ToString()))));
                                        }
                                    }
                                    else
                                    {
                                        bool flag2 = s_s.Offer_Value > 0M;
                                        if (s_s.Discount > 0f)
                                        {
                                            row7["STANDARD_DISCOUNT_PER"] = decimal.Parse(control.chkNull_0(row7["STANDARD_DISCOUNT_PER"].ToString())) + (decimal.Parse(s_s.Discount.ToString()) / 100M);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (DataRow row8 in table.Rows)
                    {
                        row8["STANDARD_DISCOUNT"] = decimal.Parse(control.chkNull_0(row8["STANDARD_DISCOUNT_PER"].ToString())) * decimal.Parse(control.chkNull_0(row8["AMOUNT"].ToString()));
                        d += decimal.Parse(control.chkNull_0(row8["AMOUNT"].ToString()));
                        num2 += decimal.Parse(control.chkNull_0(row8["STANDARD_DISCOUNT"].ToString()));
                        num3 += decimal.Parse(control.chkNull_0(row8["EXTRA_DISCOUNT"].ToString()));
                        decimal num10 = decimal.Parse(control.chkNull_0(row8["AMOUNT"].ToString()));
                        decimal num11 = decimal.Parse(control.chkNull_0(row8["STANDARD_DISCOUNT"].ToString()));
                        decimal num12 = decimal.Parse(control.chkNull_0(row8["EXTRA_DISCOUNT"].ToString()));
                        row8["GST_AMOUNT"] = (((num10 - num11) - num12) * decimal.Parse(control.chkNull_0(row8["GST_RATE"].ToString()))) / 100M;
                        row8["NET_AMOUNT"] = ((num10 - num11) - num12) + decimal.Parse(control.chkNull_0(row8["GST_AMOUNT"].ToString()));
                        num4 += decimal.Parse(control.chkNull_0(row8["GST_AMOUNT"].ToString()));
                    }
                }
                else
                {
                    decimal num13 = 0M;
                    foreach (DataRow row9 in table.Rows)
                    {
                        d += decimal.Parse(control.chkNull_0(row9["AMOUNT"].ToString()));
                        if (row9["BATCH_NO"].ToString() == "T")
                        {
                            num13 += decimal.Parse(control.chkNull_0(row9["AMOUNT"].ToString()));
                        }
                    }
                    d = 0M;
                    foreach (DataRow row10 in table.Rows)
                    {
                        decimal num14 = 0M;
                        decimal num15 = 0M;
                        decimal num16 = 0M;
                        row10["EXTRA_DISCOUNT"] = 0;
                        row10["STANDARD_DISCOUNT"] = 0;
                        num14 = decimal.Parse(control.chkNull_0(row10["AMOUNT"].ToString()));
                        num15 = decimal.Parse(control.chkNull_0(row10["STANDARD_DISCOUNT"].ToString()));
                        num16 = decimal.Parse(control.chkNull_0(row10["EXTRA_DISCOUNT"].ToString()));
                        row10["GST_AMOUNT"] = (((num14 - num15) - num16) * decimal.Parse(control.chkNull_0(row10["GST_RATE"].ToString()))) / 100M;
                        row10["NET_AMOUNT"] = ((num14 - num15) - num16) + decimal.Parse(control.chkNull_0(row10["GST_AMOUNT"].ToString()));
                        d += decimal.Parse(control.chkNull_0(row10["AMOUNT"].ToString()));
                        num4 += decimal.Parse(control.chkNull_0(row10["GST_AMOUNT"].ToString()));
                    }
                    num2 += decimal.Parse(control.chkNull_0(this.numTxtTotalStndrdDiscnt.Text));
                    num3 += decimal.Parse(control.chkNull_0(this.numtxtTotalExtraDiscnt.Text));
                }
                this.txtGrossAmount.Text = Convert.ToString(Math.Round(d, 2));
                this.numtxtTotalExtraDiscnt.Text = Convert.ToString(Math.Round(num3, 2));
                this.numTxtTotalStndrdDiscnt.Text = Convert.ToString(Math.Round(num2, 2));
                this.numTxtTotalGST.Text = Convert.ToString(Math.Round((decimal)(num4 + num5), 2));
                this.numTxtTotlAmnt.Text = Convert.ToString(Math.Round((decimal)(((((d - num3) - num2) - Convert.ToDecimal(this.numTxtTotalHalfScheme.Text)) + num4) + num5), 2));
                this.btnSaveOrder.Enabled = true;
                if (this.RblPayMode.SelectedIndex == 1)
                {
                    this.txtCashReceived.Enabled = true;
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.txtCashReceived);
                }
                else
                {
                    this.txtCashReceived.Enabled = false;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        DataControl control = new DataControl();
        DataTable table = (DataTable)this.Session["Dtsku_Price"];
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] rowArray = table.Select("SKU_CODE  = '" + this.txtskuCode.Text + "'");
        decimal num = decimal.Parse(control.chkNull_0(rowArray[0]["TRADE_PRICE"].ToString()));
        int num2 = int.Parse(control.chkNull_0(rowArray[0]["UNITS_IN_CASE"].ToString()));
        if (this.btnSave.Text == "Add Sku")
        {
            if (this.CheckDublicateSKU())
            {
                DataRow row = this.PurchaseSKU.NewRow();
                row["SKU_ID"] = rowArray[0]["SKU_ID"];
                row["SKU_Code"] = rowArray[0]["SKU_CODE"];
                row["SKU_Name"] = rowArray[0]["SKU_NAME"];
                if (UnitType == 0)
                {
                    row["QUANTITY_UNIT"] = int.Parse(control.chkNull_0(this.txtQuantity.Text));
                    row["QUANTITY_CTN"] = 0;
                }
                else
                {
                    row["QUANTITY_UNIT"] = int.Parse(control.chkNull_0(this.txtQuantity.Text)) * num2;
                    row["QUANTITY_CTN"] = int.Parse(control.chkNull_0(this.txtQuantity.Text));
                }
                row["UNIT_PRICE"] = num.ToString();
                if (rowArray[0]["GST_ON"].ToString().Trim() == "T")
                {
                    row["AMOUNT"] = num * decimal.Parse(row["QUANTITY_UNIT"].ToString());
                    row["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                    row["BATCH_NO"] = "T";
                }
                else if (rowArray[0]["GST_ON"].ToString().Trim() == "R")
                {
                    row["AMOUNT"] = num * decimal.Parse(row["QUANTITY_UNIT"].ToString());
                    row["GST_RATE"] = 0;
                    row["BATCH_NO"] = "R";
                }
                else
                {
                    row["AMOUNT"] = num * decimal.Parse(row["QUANTITY_UNIT"].ToString());
                    row["GST_RATE"] = 0;
                    row["BATCH_NO"] = "E";
                }
                row["STANDARD_DISCOUNT"] = 0;
                row["EXTRA_DISCOUNT"] = 0;
                row["GST_AMOUNT"] = 0;
                row["NET_AMOUNT"] = 0;
                this.PurchaseSKU.Rows.Add(row);
            }
            else
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('SKU Already Exists')", true);
            }
        }
        else
        {
            DataRow row2 = this.PurchaseSKU.Rows[RowId];
            row2["SKU_ID"] = rowArray[0]["SKU_ID"];
            row2["SKU_Code"] = rowArray[0]["SKU_CODE"];
            row2["SKU_Name"] = rowArray[0]["SKU_NAME"];
            row2["BATCH_NO"] = this.txtBatchNo.Text;
            if (UnitType == 0)
            {
                row2["QUANTITY_UNIT"] = int.Parse(control.chkNull_0(this.txtQuantity.Text));
            }
            else
            {
                row2["QUANTITY_UNIT"] = int.Parse(control.chkNull_0(this.txtQuantity.Text)) * num2;
            }
            row2["UNIT_PRICE"] = num.ToString();
            row2["AMOUNT"] = num * decimal.Parse(row2["QUANTITY_UNIT"].ToString());
            if (rowArray[0]["GST_ON"].ToString().Trim() == "T")
            {
                row2["GST_RATE"] = rowArray[0]["GST_RATE_TP"];
                row2["AMOUNT"] = num * decimal.Parse(row2["QUANTITY_UNIT"].ToString());
                row2["BATCH_NO"] = "T";
            }
            else if (rowArray[0]["GST_ON"].ToString().Trim() == "R")
            {
                row2["AMOUNT"] = num * decimal.Parse(row2["QUANTITY_UNIT"].ToString());
                row2["GST_RATE"] = 0;
                row2["BATCH_NO"] = "R";
            }
            else
            {
                row2["AMOUNT"] = num * decimal.Parse(row2["QUANTITY_UNIT"].ToString());
                row2["GST_RATE"] = 0;
                row2["BATCH_NO"] = "E";
            }
            row2["STANDARD_DISCOUNT"] = 0;
            row2["EXTRA_DISCOUNT"] = 0;
            row2["GST_AMOUNT"] = 0;
            row2["NET_AMOUNT"] = 0;
            row2["STANDARD_DISCOUNT_PER"] = 0;
        }
        this.Session.Add("PurchaseSKU", this.PurchaseSKU);
        this.EnableDisableController(false);
        this.LoadGird();
        this.ClearAll();
        ScriptManager.GetCurrent(this.Page).SetFocus(this.txtskuCode);
        decimal d = 0M;
        foreach (DataRow row3 in this.PurchaseSKU.Rows)
        {
            d += decimal.Parse(control.chkNull_0(row3["AMOUNT"].ToString()));
            if (row3["BATCH_NO"].ToString() == "T")
            {
                decimal.Parse(control.chkNull_0(row3["AMOUNT"].ToString()));
            }
        }
        this.txtGrossAmount.Text = Convert.ToString(Math.Round(d, 2));
    }

    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        GrdPurchase.EditIndex = -1;
        if (this.FindCustomer())
        {
            DataControl control = new DataControl();
            this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
            this.dtFreeSKU = (DataTable)this.Session["dtFreeSKU"];
            OrderEntryController controller = new OrderEntryController();
            if (this.btnSaveOrder.Text == "Save Order")
            {
                foreach (DataRow row in this.PurchaseSKU.Rows)
                {
                    DataTable orderClosingStock = controller.GetOrderClosingStock(Convert.ToInt32(this.Session["DistributorId"]), Convert.ToInt32(row["SKU_ID"]));
                    if (orderClosingStock.Rows.Count > 0)
                    {
                        if (int.Parse(orderClosingStock.Rows[0][0].ToString()) >= int.Parse(row["QUANTITY_UNIT"].ToString()))
                        {
                            continue;
                        }
                        ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('" + row["SKU_Code"].ToString() + " Current Stock is " + orderClosingStock.Rows[0][0].ToString() + "');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert(' + " + row["SKU_Code"].ToString() + "No Stock Found');", true);
                    }
                    return;
                }
                if (controller.Add_Order(int.Parse(this.Session["DistributorId"].ToString()), this.mTownId, (long)this.Session["AreaId"], int.Parse(this.Session["PrincipalId"].ToString()), long.Parse(this.Session["CUSTOMER_ID"].ToString()), long.Parse(this.Session["CUSTOMER_ID"].ToString()), int.Parse(this.Session["OrderBookerId"].ToString()), int.Parse(this.Session["DeliveryManId"].ToString()), int.Parse(this.RblPayMode.SelectedValue.ToString()), decimal.Parse(control.chkNull_0(this.txtGrossAmount.Text)), decimal.Parse(control.chkNull_0(this.numtxtTotalExtraDiscnt.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotalStndrdDiscnt.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotalGST.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotlAmnt.Text)), 0M, 0x6f, this.PurchaseSKU, this.dtFreeSKU, int.Parse(this.Session["UserId"].ToString()), DateTime.Parse(this.Session["OrderDate"].ToString()), 0M, 0M, Convert.ToDecimal(this.numTxtTotalHalfScheme.Text)))
                {
                    this.LoadPendingOrder();
                    this.ClearMasterALL();
                    ScriptManager.GetCurrent(this.Page).SetFocus(this.txtOutletCode);
                }
            }
            else if (this.btnSaveOrder.Text == "Save Invoice")
            {
                if (Convert.ToDateTime(this.Session["CurrentWorkDate"]) < Convert.ToDateTime(this.Session["OrderDate"].ToString()))
                {
                    ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Order Date Can not be greater than current working date');", true);
                }
                else
                {
                    if ((int.Parse(this.RblPayMode.SelectedValue.ToString()) == 0xd7) || (int.Parse(this.RblPayMode.SelectedValue.ToString()) == 0xd8))
                    {
                        foreach (DataRow row2 in this.PurchaseSKU.Rows)
                        {
                            DataTable table2 = new PurchaseController().SelectSKUClosingStock(int.Parse(this.Session["DistributorId"].ToString()), int.Parse(row2["SKU_ID"].ToString()), this.txtBatchNo.Text);
                            if (table2.Rows.Count > 0)
                            {
                                if (int.Parse(table2.Rows[0][0].ToString()) >= int.Parse(row2["QUANTITY_UNIT"].ToString()))
                                {
                                    continue;
                                }
                                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('" + row2["SKU_Code"].ToString() + " Current Stock is " + table2.Rows[0][0].ToString() + "');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert(' + " + row2["SKU_Code"].ToString() + "No Stock Found');", true);
                            }
                            return;
                        }
                    }
                    if (controller.Add_Invoice(int.Parse(this.Session["DistributorId"].ToString()), this.mTownId, long.Parse(this.Session["AreaId"].ToString()), int.Parse(this.Session["PrincipalId"].ToString()), long.Parse(this.Session["CUSTOMER_ID"].ToString()), long.Parse(this.Session["CUSTOMER_ID"].ToString()), int.Parse(this.Session["OrderBookerId"].ToString()), int.Parse(this.Session["DeliveryManId"].ToString()), long.Parse(this.drpDocumentNo.SelectedValue.ToString()), decimal.Parse(control.chkNull_0(this.txtGrossAmount.Text)), decimal.Parse(control.chkNull_0(this.numtxtTotalExtraDiscnt.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotalStndrdDiscnt.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotalGST.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotlAmnt.Text)), 0M, int.Parse(this.RblPayMode.SelectedValue.ToString()), this.PurchaseSKU, this.dtFreeSKU, int.Parse(this.Session["UserId"].ToString()), decimal.Parse(control.chkNull_0(this.txtCashReceived.Text)), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), 0M, 0M, Convert.ToDecimal(this.numTxtTotalHalfScheme.Text)))
                    {
                        if (this.drpDocumentNo.Enabled)
                        {
                            this.btnSaveOrder.Text = "Save Order";
                        }
                        this.LoadPendingOrder();
                        this.ClearMasterALL();
                        ScriptManager.GetCurrent(this.Page).SetFocus(this.txtOutletCode);
                    }
                }
            }
            else if ((this.btnSaveOrder.Text == "Sale Return") && controller.Add_SaleReturn(int.Parse(this.Session["DistributorId"].ToString()), this.mTownId, (long)this.Session["AreaId"], int.Parse(this.Session["PrincipalId"].ToString()), long.Parse(this.Session["CUSTOMER_ID"].ToString()), long.Parse(this.Session["CUSTOMER_ID"].ToString()), int.Parse(this.Session["OrderBookerId"].ToString()), int.Parse(this.Session["DeliveryManId"].ToString()), long.Parse(this.drpDocumentNo.SelectedValue.ToString()), decimal.Parse(control.chkNull_0(this.txtGrossAmount.Text)), decimal.Parse(control.chkNull_0(this.numtxtTotalExtraDiscnt.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotalStndrdDiscnt.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotalGST.Text)), decimal.Parse(control.chkNull_0(this.numTxtTotlAmnt.Text)), 0M, int.Parse(this.RblPayMode.SelectedValue.ToString()), this.PurchaseSKU, this.dtFreeSKU, int.Parse(this.Session["UserId"].ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), 0M, this.RblPayMode.SelectedIndex))
            {
                this.ClearMasterALL();
                ScriptManager.GetCurrent(this.Page).SetFocus(this.txtOutletCode);
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Session.Remove("CUSTOMER_ID");
        this.Session.Remove("PrincipalId");
        this.Session.Remove("AreaId");
        this.Session.Remove("OrderBookerId");
        this.Session.Remove("DeliveryManId");
        base.Response.Redirect(string.Concat(new object[] { "~/Forms/frmOrderEntryStep1.aspx?Status=", false, "&LevelType=3&LevelID=", base.Request.QueryString["LevelID"].ToString() }));
    }

    private bool CheckDublicateSKU()
    {
        new DataControl();
        DataTable table1 = (DataTable)this.Session["Dtsku_Price"];
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        return (this.PurchaseSKU.Select("SKU_CODE  = '" + this.txtskuCode.Text + "'").Length == 0);
    }

    private void ClearAll()
    {
        this.txtskuCode.Text = "";
        this.txtskuName.Text = "";
        this.txtUnitRate.Text = "";
        this.txtQuantity.Text = "";
        this.txtBatchNo.Text = "";
        this.txtskuCode.Enabled = true;
        this.btnSave.Text = "Add Sku";
        this.btnSaveOrder.Enabled = false;
        this.btnCalculate.Enabled = true;
    }

    private void ClearMasterALL()
    {
        this.EnableDisableController(true);
        this.Session.Remove("PurchaseSKU");
        this.Session.Remove("dtFreeSKU");
        this.CreatTable();
        this.CreateFreeSKU();
        this.txtOutletCode.Text = "";
        this.txtOutletName.Text = "";
        this.txtOutletCode.Focus();
        this.LoadGird();
        this.LoadFreeGrid();
        this.txtGrossAmount.Text = "";
        this.numtxtTotalExtraDiscnt.Text = "";
        this.numTxtTotalStndrdDiscnt.Text = "";
        this.numTxtTotalHalfScheme.Text = "0.0000";
        this.numTxtTotalGST.Text = "";
        this.numTxtTotlAmnt.Text = "";
        RowId = 0;
        mCustomerTypeId = 0;
        mCustomerVolClassId = 0;
        this.drpDocumentNo.SelectedIndex = 0;
        this.txtCashReceived.Text = "";
    }

    private void CreateFreeSKU()
    {
        this.dtFreeSKU = new DataTable();
        this.dtFreeSKU.Columns.Add("SKU_ID", typeof(int));
        this.dtFreeSKU.Columns.Add("SKU_Code", typeof(string));
        this.dtFreeSKU.Columns.Add("SKU_Name", typeof(string));
        this.dtFreeSKU.Columns.Add("UNIT_PRICE", typeof(decimal));
        this.dtFreeSKU.Columns.Add("Quantity", typeof(int));
        this.dtFreeSKU.Columns.Add("AMOUNT", typeof(decimal));
        this.dtFreeSKU.Columns.Add("GST_RATE", typeof(decimal));
        this.dtFreeSKU.Columns.Add("GST_AMOUNT", typeof(decimal));
        this.dtFreeSKU.Columns.Add("PROMOTION_ID", typeof(int));
        this.dtFreeSKU.Columns.Add("BASKET_ID", typeof(int));
        this.dtFreeSKU.Columns.Add("BASKET_DETAIL_ID", typeof(int));
        this.dtFreeSKU.Columns.Add("PROMOTION_OFFER_ID", typeof(int));
        this.Session.Add("dtFreeSKU", this.dtFreeSKU);
    }

    private void CreatTable()
    {
        this.PurchaseSKU = new DataTable();
        this.PurchaseSKU.Columns.Add("SALE_ORDER_DETAIL_ID", typeof(long));
        this.PurchaseSKU.Columns.Add("DistributorId", typeof(int));
        this.PurchaseSKU.Columns.Add("SALE_ORDER_ID", typeof(int));
        this.PurchaseSKU.Columns.Add("SKU_ID", typeof(int));
        this.PurchaseSKU.Columns.Add("SKU_Code", typeof(string));
        this.PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
        this.PurchaseSKU.Columns.Add("BATCH_NO", typeof(string));
        this.PurchaseSKU.Columns.Add("UNIT_PRICE", typeof(decimal));
        this.PurchaseSKU.Columns.Add("QUANTITY_UNIT", typeof(int));
        this.PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
        this.PurchaseSKU.Columns.Add("STANDARD_DISCOUNT", typeof(decimal));
        this.PurchaseSKU.Columns.Add("STANDARD_DISCOUNT_PER", typeof(decimal));
        this.PurchaseSKU.Columns.Add("EXTRA_DISCOUNT", typeof(decimal));
        this.PurchaseSKU.Columns.Add("GST_RATE", typeof(decimal));
        this.PurchaseSKU.Columns.Add("GST_AMOUNT", typeof(decimal));
        this.PurchaseSKU.Columns.Add("NET_AMOUNT", typeof(decimal));
        this.PurchaseSKU.Columns.Add("QUANTITY_CTN", typeof(decimal));
        this.PurchaseSKU.Columns.Add("IS_DELETED", typeof(bool));
        this.Session.Add("PurchaseSKU", this.PurchaseSKU);
    }

    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (long.Parse(this.drpDocumentNo.SelectedValue.ToString()) != -9223372036854775808L)
        {
            DataRow[] rowArray = ((DataTable)this.Session["dtOrder"]).Select("SALE_ORDER_ID  = '" + this.drpDocumentNo.SelectedValue + "'");
            if (rowArray.Length > 0)
            {
                this.txtGrossAmount.Text = rowArray[0]["TOTAL_AMOUNT"].ToString();
                this.numtxtTotalExtraDiscnt.Text = rowArray[0]["EXTRA_DISCOUNT_AMOUNT"].ToString();
                this.numTxtTotalStndrdDiscnt.Text = rowArray[0]["STANDARD_DISCOUNT_AMOUNT"].ToString();
                this.numTxtTotalHalfScheme.Text = rowArray[0]["HALF_SCHEME"].ToString();
                this.numTxtTotalGST.Text = rowArray[0]["GST_AMOUNT"].ToString();
                this.numTxtTotlAmnt.Text = rowArray[0]["TOTAL_NET_AMOUNT"].ToString();
                this.txtOutletCode.Text = rowArray[0]["CUSTOMER_CODE"].ToString();
                this.txtOutletName.Text = rowArray[0]["CUSTOMER_NAME"].ToString();
                this.Session.Add("CUSTOMER_ID", long.Parse(rowArray[0]["CUSTOMER_ID"].ToString()));
                this.ExistenOrderDetail(long.Parse(this.drpDocumentNo.SelectedValue.ToString()));
                this.EnableDisableController(false);
                this.btnSaveOrder.Text = "Save Invoice";
                this.txtCashReceived.Enabled = true;
                this.ClearAll();
                ScriptManager.GetCurrent(this.Page).SetFocus(this.txtskuCode);
            }
        }
        else
        {
            this.CreateFreeSKU();
            this.CreatTable();
            this.LoadGird();
            this.LoadFreeGrid();
            this.ClearMasterALL();
            this.btnSaveOrder.Text = "Save Order";
        }
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
    }

    private void EnableDisableController(bool CValue)
    {
        if (CValue)
        {
            if (decimal.Parse(this.txtGrossAmount.Text) > 0M)
            {
                this.txtOutletCode.Enabled = true;
                this.txtOutletName.Enabled = true;
            }
        }
        else
        {
            this.txtOutletCode.Enabled = false;
            this.txtOutletName.Enabled = false;
        }
    }

    private void ExistenOrderDetail(long OrderId)
    {
        OrderEntryController controller = new OrderEntryController();
        this.PurchaseSKU = controller.SelectOrderDetail(int.Parse(this.Session["DistributorId"].ToString()), OrderId);
        this.dtFreeSKU = controller.SelectOrderPromotion(int.Parse(this.Session["DistributorId"].ToString()), OrderId);
        this.Session.Add("PurchaseSKU", this.PurchaseSKU);
        this.Session.Add("dtFreeSKU", this.dtFreeSKU);
        this.LoadGird();
        this.LoadFreeGrid();
    }

    private bool FindCustomer()
    {
        DataRow[] rowArray = ((DataTable)this.Session["dtCustomer"]).Select("CUSTOMER_CODE  = '" + this.txtOutletCode.Text.Trim() + "'");
        if (rowArray.Length > 0)
        {
            this.Session.Add("CUSTOMER_ID", long.Parse(rowArray[0]["CUSTOMER_ID"].ToString()));
            mCustomerTypeId = int.Parse(rowArray[0]["CHANNEL_TYPE_ID"].ToString());
            mCustomerVolClassId = int.Parse(rowArray[0]["VOLUME_CLASS_ID"].ToString());
            this.mTownId = int.Parse(rowArray[0]["TOWN_ID"].ToString());
            return true;
        }
        return false;
    }

    private int FreeSKUExist(DataTable dt, int Sku_id)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (int.Parse(dt.Rows[i]["SKU_ID"].ToString()) == Sku_id)
            {
                return i;
            }
        }
        return -1;
    }

    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataControl control = new DataControl();
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        this.PurchaseSKU.Rows.RemoveAt(e.RowIndex);
        decimal d = 0M;
        decimal num2 = 0M;
        decimal num3 = 0M;
        decimal num4 = 0M;
        foreach (DataRow row in this.PurchaseSKU.Rows)
        {
            d += decimal.Parse(control.chkNull_0(row["AMOUNT"].ToString()));
            num2 += decimal.Parse(control.chkNull_0(row["STANDARD_DISCOUNT"].ToString()));
            num3 += decimal.Parse(control.chkNull_0(row["GST_AMOUNT"].ToString()));
            num4 += decimal.Parse(control.chkNull_0(row["NET_AMOUNT"].ToString()));
        }
        this.txtGrossAmount.Text = Convert.ToString(Math.Round(d, 2));
        this.numTxtTotalStndrdDiscnt.Text = Convert.ToString(Math.Round(num2, 2));
        this.numTxtTotalGST.Text = Convert.ToString(Math.Round(num3, 2));
        this.numTxtTotlAmnt.Text = Convert.ToString(Math.Round(num4, 2));
        this.Session.Add("PurchaseSKU", this.PurchaseSKU);
        this.LoadGird();
    }

    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        this.txtskuCode.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtskuName.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtQuantity.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        this.txtUnitRate.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        this.txtBatchNo.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        if (UnitType == 0)
        {
            this.txtQuantity.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        }
        else
        {
            this.txtQuantity.Text = this.GrdPurchase.Rows[e.NewEditIndex].Cells[7].Text;
        }
        this.txtskuCode.Enabled = false;
        this.btnSave.Text = "Update SKU";
    }

    private void LoadCustomerData()
    {
        if ((int.Parse(this.Session["DistributorId"].ToString()) > 0) && (long.Parse(this.Session["AreaId"].ToString()) > 0L))
        {
            this.ListCustomer.Items.Clear();
            DataTable table = new CustomerDataController().SelectPrincipalCustomer(int.Parse(this.Session["DistributorId"].ToString()), int.Parse(this.Session["AreaId"].ToString()), -2147483648, int.Parse(this.Session["PrincipalId"].ToString()));
            clsWebFormUtil.FillListBox(this.ListCustomer, table, "CUSTOMER_DETAIL", "CUSTOMER_DETAIL", true);
            this.Session.Add("dtCustomer", table);
        }
        else
        {
            this.ListCustomer.Items.Clear();
        }
    }

    private void LoadFreeGrid()
    {
        this.dtFreeSKU = (DataTable)this.Session["dtFreeSKU"];
        this.GrdFreeSKU.DataSource = this.dtFreeSKU;
        this.GrdFreeSKU.DataBind();
    }

    private void LoadGird()
    {
        this.PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        this.GrdPurchase.DataSource = this.PurchaseSKU;
        this.GrdPurchase.DataBind();
    }

    private void LoadPendingOrder()
    {
        OrderEntryController controller = new OrderEntryController();
        this.drpDocumentNo.Items.Clear();
        DataTable table = controller.SelectPendingOrder(int.Parse(this.Session["DistributorId"].ToString()), int.Parse(this.Session["AreaId"].ToString()), int.Parse(this.Session["PrincipalId"].ToString()), int.Parse(this.Session["OrderBookerId"].ToString()), int.Parse(this.Session["DeliveryManId"].ToString()), 0x6f, -2147483648, int.Parse(this.Session["UserId"].ToString()), Convert.ToDateTime(this.Session["OrderDate"].ToString()));
        long num = -9223372036854775808L;
        this.drpDocumentNo.Items.Add((ListItem)new clsListItems("New", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDocumentNo, table, "SALE_ORDER_ID", "ORDERNO");
        this.Session.Add("dtOrder", table);
    }

    private void LoadPromotion()
    {
        if (int.Parse(this.Session["PrincipalId"].ToString()) > 0)
        {
            SKUPriceDetailController controller = new SKUPriceDetailController();
            if (!bool.Parse(controller.SelectDataPrice(int.Parse(this.Session["PrincipalId"].ToString()), -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["OrderDate"].ToString())).Rows[0]["Is_ManualDiscount"].ToString()))
            {
                PromotionCollections_Controller controller3 = new OrderEntryController().LoadSchemes(int.Parse(this.Session["DistributorId"].ToString()), int.Parse(this.Session["PrincipalId"].ToString()), Convert.ToDateTime(this.Session["OrderDate"]));
                this.Session.Add("Arpc", controller3);
                this.txtDiscountType.Text = "Auto Discount";
            }
            else
            {
                this.txtDiscountType.Text = "Manual Discount";
                this.numTxtTotalStndrdDiscnt.ReadOnly = false;
                this.numtxtTotalExtraDiscnt.ReadOnly = false;
            }
        }
    }

    private void LoadSKUDetail()
    {
        SKUPriceDetailController controller = new SKUPriceDetailController();
        if (int.Parse(this.Session["PrincipalId"].ToString()) > 0)
        {
            DataTable table = controller.SelectDataPrice(int.Parse(this.Session["PrincipalId"].ToString()), -2147483648, -2147483648, -2147483648, int.Parse(this.Session["DistributorId"].ToString()), int.Parse(this.Session["UserId"].ToString()), -2147483648, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, table, 10, 10, true);
            this.Session.Add("Dtsku_Price", table);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            int num = (int)this.Session["OrderNo"];
            UnitType = (int)this.Session["UnitType"];
            this.txtprincipal.Text = this.Session["Route"].ToString();
            this.txtDeliveryMan.Text = this.Session["SaleMan"].ToString();
            this.Session.Remove("Route");
            this.Session.Remove("SaleMan");
            if (num == -2)
            {
                this.drpDocumentNo.Enabled = false;
                this.RblPayMode.Items.Add(new ListItem("Sale Return", "10"));
                this.btnSaveOrder.Text = "Sale Return";
            }
            else
            {
                this.RblPayMode.Items.Add(new ListItem("Cash", "214"));
                this.RblPayMode.Items.Add(new ListItem("Credit", "215"));
                this.btnSaveOrder.Text = "Save Order";
                this.drpDocumentNo.Enabled = true;
            }
            this.RblPayMode.SelectedIndex = 0;
            this.LoadCustomerData();
            this.LoadSKUDetail();
            this.CreatTable();
            this.LoadPromotion();
            this.CreateFreeSKU();
            this.LoadFreeGrid();
            this.LoadPendingOrder();
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtOutletCode);
            this.btnSave.Attributes.Add("onclick", "return ValidateForm();");
        }
    }
}