namespace SAMS.Common.Classes
{
    using System;
    using System.Runtime.CompilerServices;

    public class Constants
    {
        public const int AC_AccountHeadId = 0x5e;
        public const string AC_Area = "AR";
        public const string AC_Customer = "OT";
        public const int AC_DetailTypeId = 0x5d;
        public const string AC_HHDeviceCode = "HHDC";
        public const string AC_HHImportBatchNumber = "HHBN";
        public const int AC_MainTypeId = 0x5b;
        public const string AC_MerchandizingItem = "MI";
        public const string AC_Route = "RU";
        public const string AC_SalesForce = "SF";
        public const int AC_SubTypeId = 0x5c;
        public const int Advance_PaymentOrder_id = 0xd8;
        public const int Bank_Deposit = 0x16;
        public const int Bank_Voucher = 15;
        public const int Basket_On_Amount = 0x53;
        public const int Basket_On_Quantity = 0x52;
        public const int Builty_Exp = 30;
        public const byte ByteNullValue = 0;
        public const int Cash_Advance = 0x15;
        public const int Cash_Order_Id = 0xd6;
        public const int Cash_Relization = 0x13;
        public const int Cash_Voucher = 14;
        public const int CashPayment = 0x13;
        public const int CashSaleReturn = 0x1a;
        public const int CashSales = 0x19;
        public const char CharNullValue = '\0';
        public const int Cheque_Advance = 20;
        public const int Cheque_Bons = 530;
        public const int Cheque_Cancel = 0x213;
        public const int Cheque_Clear = 0x211;
        public const int Cheque_Deposit = 0x210;
        public const int Cheque_Hold = 0x214;
        public const int Cheque_Pending = 0x20f;
        public const int Cheque_Relization = 0x12;
        public const int ChequePayment = 0x12;
        public const int Credit_Order_Id = 0xd7;
        public const int Credit_TransferOut = 0x1c;
        public const int CreditClaim = 0x17f;
        public const int CreditSale = 0x18;
        public const int CustomerChannelType = 0x2e;
        public const int CustomerTypeBusiness = 0x2f;
        public const int CustomerVolumeClassType = 0x30;
        public static DateTime DateNullValue = new DateTime(0x76c, 1, 1);
        public const int DebitClaim = 0x17a;
        [DecimalConstant(0, 0x80, uint.MaxValue, uint.MaxValue, uint.MaxValue)]
        public static readonly decimal DecimalNullValue = -79228162514264337593543950335M;
        public const int DefaultStatus = 1;
        public const int Document_Acess = 9;
        public const int Document_Damaged = 6;
        public const int Document_Invoice = 13;
        public const int Document_Opening = 7;
        public const int Document_Order = 12;
        public const int Document_Petty_Cash = 0x1b;
        public const int Document_Purchase = 2;
        public const int Document_Purchase_Return = 3;
        public const int Document_Sale_Return = 14;
        public const int Document_SaleInvoice = 13;
        public const int Document_SaleReturn = 14;
        public const int Document_Short = 8;
        public const int Document_Transfer_In = 4;
        public const int Document_Transfer_Out = 5;
        public const int Dozen = 12;
        public const int DTWareHouse = 3;
        public const string EncryptionKey = "19995";
        public const int Expanse_Voucher = 0x11;
        public const string expPublishExceptionError = "Error YE-1201 has occurred. Please contact System Administrator to resolve the issue.";
        public static char[] File_Delimiter = new char[] { '\t', '~' };
        public const string FileEncryptionKey = "ENCRYPTE";
        public const float FloatNullValue = float.MinValue;
        public const int IncomeTax_Relization = 0x17;
        public const int IntNullValue = -2147483648;
        public const int Journal_Voucher = 0x10;
        public const long LongNullValue = -9223372036854775808L;
        public const int Market = 0x38;
        public const int Mod_1st_Layer = 11;
        public const int Mod_2nd_Layer = 12;
        public const int Mod_3rd_Layer = 13;
        public const int NumberOfDecimal = 2;
        public const int Order_Cancel_Id = 0x71;
        public const int Order_Pending_Id = 0x6f;
        public const int Order_Posted_Id = 0x70;
        public const int Region = 0x33;
        public const int Route = 0x37;
        public const string SaleDefult = "Sale Default";
        public const int SaleForce = 0x22;
        public const string SaleReturn = "Sale Return Default";
        public const int SALES_FORCE_DELIVERYMAN = 0x24;
        public const int SALES_FORCE_ORDERBOOKER = 0x23;
        public const int SALES_FORCE_SALESPERSON = 0x25;
        public const short ShortNullValue = -32768;
        public const int SKUBrand = 60;
        public const int SKUCategory = 0x3b;
        public const int SKUDivision = 0x3a;
        public const int SKUPrincipal = 0x39;
        public const int SKUS = 0x3d;
        public const int Territory = 0x35;
        public const int Town = 0x36;
        public const int UOM_ID_Case = 3;
        public const int UOM_ID_Dozen = 2;
        public const int UOM_ID_Unit = 1;
        public const int UserType = 0x1f;
        public const int Zone = 0x34;

        public static string fldDistributorFolder
        {
            get
            {
                return General.ReplaceSymbols(@"%SERVERFTPPATH%\Distributor\");
            }
        }

        public static string fldLogFileFolder
        {
            get
            {
                return General.ReplaceSymbols(@"%APPPATH%Logs\");
            }
        }

        public static string fldOtherDataFolder
        {
            get
            {
                return General.ReplaceSymbols(@"%SERVERFTPPATH%\OtherData\");
            }
        }

        public static string fldPickSlipFolder
        {
            get
            {
                return General.ReplaceSymbols(@"%SERVERFTPPATH%\PickSlip\");
            }
        }

        public static string fldPromotionFolder
        {
            get
            {
                return General.ReplaceSymbols(@"%SERVERFTPPATH%\Promotion\");
            }
        }

        public static string fldSKUFolder
        {
            get
            {
                return General.ReplaceSymbols(@"%SERVERFTPPATH%\SKU\");
            }
        }

        public static string fldSkuStockFolder
        {
            get
            {
                return General.ReplaceSymbols(@"%SERVERFTPPATH%\SkuStock\");
            }
        }
    }
}

