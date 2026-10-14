namespace SAMS.Common.Classes
{
    using SAMS;
    using System;
    using System.Configuration;

    public class Configuration
    {
        public static string ApplicationStatus;
        public static string Distributor_Address;
        public static string Distributor_Company;
        public static string Distributor_RegisterationNo;
        private static string Distributor_Type_Code;
        private static int Distributor_Type_Id;
        private static string Distributor_Type_Name;
        public static string HelpPath = (GetAppInstallationPath() + "UserManual_Desktop.chm");
        public static bool IsFirstApprear = false;
        private static string m_DesktopInbox;
        private static string m_DesktopOutbox;
        private static string m_DeviceInbox;
        private static string m_DeviceOutbox;
        private static string m_DownloadDirectory;
        private static string m_DownloadedFileName;
        private static bool m_isApplicationRunning;
        private static Language m_Language;
        private static Pack m_Pack;
        private static int m_PromotionId = -1;
        private static string m_ReportExportPath;
        private static string m_ServerHttpPath;
        private static string m_ServerSettingURL;
        private static string m_strClientDetail;
        private static string m_strClientName;
        private static string m_strDesktopVersion;
        private static string m_strMailingServerAddress;
        private static string m_strMailSenderAddress;
        private static string m_strPrintOnOrderForm;
        private static string m_strPrintType;
        private static string m_strServerFTPpath;
        private static string m_strServerVersion;
        private static string m_strSKUonHandShowValue;
        private static string m_strSyncLog_Process_Path;
        private static string m_strThreadTime;
        private static string m_strTimeInterval;
        private static string m_strUploadLog;
        private static string mAccountReceivable;
        private static string mBankDefault;
        private static string mBankDefaultType;
        private static string mBuiltyExp;
        private static string mCashDefault;
        private static string mCashDefaultType;
        public static int mCompanyID = 0;
        private static string mConnectionString;
        private static string mCurrentAssets;
        private static string mDiscountAccount;
        private static string mDistCode = null;
        private static string mDistPassword = null;
        public static int mDistributorCreditLevel;
        private static int mDistributorID = -2147483648;
        private static int mDivisionID = -2147483648;
        private static int mDocumentDurationToShow = 3;
        private static string mExpensDefaultType;
        private static string mFreeStock;
        private static string mGSTAccount;
        private static string mHHAppFilesFolder;
        private static string mInboxPath;
        private static bool mIsDistReg;
        public static bool mIsRpUpdate;
        public static bool mIsTaxPriceUpdate;
        public static bool mIsTpUpdate;
        private static int mMaxDayClose = 3;
        private static string mOutboxPath;
        private static string mPayableAccount;
        private static string mPeatyCash;
        private static SAMS.Common.Classes.Enums.PrintPaper mPrintPaper = SAMS.Common.Classes.Enums.PrintPaper.A4;
        private static string mPurchaseAccount;
        private static string mPurchasReturnAccount;
        private static string mQueryTimeOut;
        private static int mRoleID = -2147483648;
        private static string mSaleAccount;
        private static string mSaleDiscount;
        private static string mSaleScheme;
        private static string mSchemeAccount;
        private static string mStockInHand;
        private static string mstrAppPath;
        private static string mstrBackupFolder;
        private static string mstrDatabaseName;
        private static string mstrDatabaseServer;
        private static string mstrDistributorName = "";
        private static string mstrErrorLogPath;
        private static string mstrServerAuthentication;
        private static string mstrServerUserName;
        private static string mstrServerUserPswd;
        private static string mstrSMTPAddress;
        private static DateTime mSystemCurrentDate;
        private static DateTime mSystemCurrentDateTime;
        private static int mSystemUserID = 0x31;
        private static string mTransferInAccount;
        private static string mTransferOutAccount;
        private static int mUserID = -2147483648;
        private static int mUserTypeID = 50;
        public static long PrintingInvoicePurchaseMasterID = 0L;
        public static ApplicationType RunningApplicationType = ApplicationType.Default;

        public static void GetAccountHead()
        {
            XmlUtil util = new XmlUtil(GetAppInstallationPath() + @"Settings\AccountHead.xml");
            mPurchaseAccount = util.GetNode("Purchase");
            mPurchasReturnAccount = util.GetNode("PurchaseReturn");
            mTransferOutAccount = util.GetNode("TransferOut");
            mTransferInAccount = util.GetNode("TransferIN");
            mDiscountAccount = util.GetNode("PurchaseDiscount");
            mSchemeAccount = util.GetNode("PurchaseScheme");
            mGSTAccount = util.GetNode("SalesTaxPayable");
            mPayableAccount = util.GetNode("PayabletoPrincipal");
            mAccountReceivable = util.GetNode("AccountReceivable");
            mCashDefault = util.GetNode("CashDefualt");
            mBankDefault = util.GetNode("BankDefualt");
            mCurrentAssets = util.GetNode("CurrentAssets");
            mSaleAccount = util.GetNode("SaleAccount");
            mSaleDiscount = util.GetNode("SaleDiscount");
            mSaleScheme = util.GetNode("SaleScheme");
            mStockInHand = util.GetNode("StockInHand");
            mFreeStock = util.GetNode("FreeStock");
            mCashDefaultType = util.GetNode("CashDefualtType");
            mBankDefaultType = util.GetNode("BankDefualtType");
            mExpensDefaultType = util.GetNode("ExpDefualtType");
            mPeatyCash = util.GetNode("PeatyCash");
            mBuiltyExp = util.GetNode("BuiltyExp");
        }

        public static void GetAppConfiguration()
        {
            string appInstallationPath = GetAppInstallationPath();
            Encryption encryption = new Encryption();
            XmlUtil util = new XmlUtil(appInstallationPath + @"Settings\AppSettings.xml");
            mstrDatabaseServer = util.GetNode("Server");
            mstrDatabaseName = util.GetNode("DBName");
            mstrServerUserName = util.GetNode("DBUser");
            mstrServerUserPswd = util.GetNode("DBPassword");
            mQueryTimeOut = util.GetNode("QueryTimeOut");
            mstrBackupFolder = util.GetNode("BackupFolder");
            mstrServerAuthentication = util.GetNode("DBAuthentication");
            m_strDesktopVersion = util.GetNode("V2");
            m_strServerVersion = util.GetNode("V1");
            m_ServerSettingURL = util.GetNode("ServerSettingURL");
            m_strTimeInterval = util.GetNode("TimeInterval");
            m_strMailingServerAddress = util.GetNode("MailingserverAddress");
            m_strMailSenderAddress = util.GetNode("MailSenderAddress");
            m_strPrintType = util.GetNode("PrintType");
            m_strPrintOnOrderForm = util.GetNode("PrintOnOrderForm");
            m_strSKUonHandShowValue = util.GetNode("SKUonHandShowValue");
            m_strSyncLog_Process_Path = util.GetNode("SyncLog_Process_Path");
            m_strServerFTPpath = util.GetNode("ServerFTPpath");
            m_ServerHttpPath = util.GetNode("ServerHttpPath");
            m_strThreadTime = util.GetNode("ThreadTime");
            m_strUploadLog = util.GetNode("UploadLog");
            mInboxPath = util.GetNode("Inbox");
            mOutboxPath = util.GetNode("Outbox");
            m_DesktopInbox = util.GetNode("DesktopInbox");
            m_DesktopOutbox = util.GetNode("DesktopOutbox");
            m_DeviceInbox = util.GetNode("DeviceInbox");
            m_DeviceOutbox = util.GetNode("DeviceOutbox");
            m_ReportExportPath = util.GetNode("ReportExportPath");
            mHHAppFilesFolder = GetAppInstallationPath() + @"\SAMSMobile\";
            util.CloseDocument();
            util = null;
        }

        public static string GetAppInstallationPath()
        {
            try
            {
                if ((mstrAppPath == null) || (mstrAppPath == ""))
                {
                    mstrAppPath = ConfigurationSettings.AppSettings["AppPath"];
                }
            }
            catch (Exception exception)
            {
                throw new SAMSException("Registry Key Not Found.", exception);
            }
            return mstrAppPath;
        }

        public static void UpdateAppConfiguration()
        {
            Encryption encryption = new Encryption();
            XmlUtil util = new XmlUtil(mstrAppPath + @"Settings\AppSettings.xml");
            util.SetNode("Server", mstrDatabaseServer);
            util.SetNode("DBName", mstrDatabaseName);
            util.SetNode("DBUser", mstrServerUserName);
            util.SetNode("DBPassword", encryption.Encrypting(mstrServerUserPswd, "2188855"));
            util.SetNode("DBAuthentication", mstrServerAuthentication);
            util.SetNode("TimeInterval", m_strTimeInterval);
            util.SetNode("MailingserverAddress", m_strMailingServerAddress);
            util.SetNode("MailSenderAddress", m_strMailSenderAddress);
            util.Save();
            encryption = null;
        }

        public static string AccountReceivable
        {
            get
            {
                return mAccountReceivable;
            }
            set
            {
                mAccountReceivable = value;
            }
        }

        public static string BackupFolder
        {
            get
            {
                return mstrBackupFolder;
            }
            set
            {
                mstrBackupFolder = value;
            }
        }

        public static string BankDefault
        {
            get
            {
                return mBankDefault;
            }
            set
            {
                mBankDefault = value;
            }
        }

        public static string BankDefaultType
        {
            get
            {
                return mBankDefaultType;
            }
            set
            {
                mBankDefaultType = value;
            }
        }

        public static string BuiltyExp
        {
            get
            {
                return mBuiltyExp;
            }
            set
            {
                mBuiltyExp = value;
            }
        }

        public static string CashDefault
        {
            get
            {
                return mCashDefault;
            }
            set
            {
                mCashDefault = value;
            }
        }

        public static string CashDefaultType
        {
            get
            {
                return mCashDefaultType;
            }
            set
            {
                mCashDefaultType = value;
            }
        }

        public static string ClientDetail
        {
            get
            {
                return m_strClientDetail;
            }
            set
            {
                m_strClientDetail = value;
            }
        }

        public static string ClientName
        {
            get
            {
                return m_strClientName;
            }
            set
            {
                m_strClientName = value;
            }
        }

        public static int CompanyId
        {
            get
            {
                return mCompanyID;
            }
            set
            {
                mCompanyID = value;
            }
        }

        public static string ConnectionString
        {
            get
            {
                if ((Configuration.mConnectionString == null) || (Configuration.mConnectionString == ""))
                {
                    GetAppConfiguration();
                    if (DatabseAuthentication.Equals("Windows"))
                    {
                        Configuration.mConnectionString = "Integrated Security=SSPI;Persist Security Info=False;";
                    }
                    else
                    {
                        Configuration.mConnectionString = " Persist Security Info=False; ";
                        string mConnectionString = Configuration.mConnectionString;
                        Configuration.mConnectionString = mConnectionString + " User ID=" + ServerUserName + ";Password=" + ServerUserPwd + ";";
                    }
                    if (mQueryTimeOut != "")
                    {
                        Configuration.mConnectionString = Configuration.mConnectionString + " Connection Timeout = " + QueryTimeOut + "; ";
                        Configuration.mConnectionString = Configuration.mConnectionString + " Connection Lifetime = " + QueryTimeOut + "; ";
                    }
                    Configuration.mConnectionString = Configuration.mConnectionString + " Initial Catalog = " + DatabaseName + "; ";
                    Configuration.mConnectionString = Configuration.mConnectionString + " Data Source= " + DatabseServer + " ";
                }
                return Configuration.mConnectionString;
            }
        }

        public static DateTime CurrentOpenDate
        {
            get
            {
                return mSystemCurrentDate;
            }
            set
            {
                mSystemCurrentDate = value;
            }
        }

        public static string CurretnAssets
        {
            get
            {
                return mCurrentAssets;
            }
            set
            {
                mCurrentAssets = value;
            }
        }

        public static string DatabaseName
        {
            get
            {
                return mstrDatabaseName;
            }
            set
            {
                mstrDatabaseName = value;
            }
        }

        public static string DatabseAuthentication
        {
            get
            {
                return mstrServerAuthentication;
            }
            set
            {
                mstrServerAuthentication = value;
            }
        }

        public static string DatabseServer
        {
            get
            {
                return mstrDatabaseServer;
            }
            set
            {
                mstrDatabaseServer = value;
            }
        }

        public static string DesktopInbox
        {
            get
            {
                return m_DesktopInbox;
            }
        }

        public static string DesktopOutbox
        {
            get
            {
                return m_DesktopOutbox;
            }
        }

        public static string DesktopVersion
        {
            get
            {
                return m_strDesktopVersion;
            }
        }

        public static string DeviceInbox
        {
            get
            {
                return m_DeviceInbox;
            }
        }

        public static string DeviceOutbox
        {
            get
            {
                return m_DeviceOutbox;
            }
        }

        public static string DiscountAccount
        {
            get
            {
                return mDiscountAccount;
            }
            set
            {
                mDiscountAccount = value;
            }
        }

        public static string DistributorCode
        {
            get
            {
                return mDistCode;
            }
            set
            {
                mDistCode = value;
            }
        }

        public static int DistributorCreditLevel
        {
            get
            {
                return mDistributorCreditLevel;
            }
            set
            {
                mDistributorCreditLevel = value;
            }
        }

        public static int DistributorId
        {
            get
            {
                return mDistributorID;
            }
            set
            {
                mDistributorID = value;
            }
        }

        public static string DistributorName
        {
            get
            {
                return mstrDistributorName;
            }
            set
            {
                mstrDistributorName = value;
            }
        }

        public static string DistributorPassword
        {
            get
            {
                return mDistPassword;
            }
            set
            {
                mDistPassword = value;
            }
        }

        public static string DistributorTypeCode
        {
            get
            {
                return Distributor_Type_Code;
            }
            set
            {
                Distributor_Type_Code = value;
            }
        }

        public static int DistributorTypeId
        {
            get
            {
                return Distributor_Type_Id;
            }
            set
            {
                Distributor_Type_Id = value;
            }
        }

        public static string DistributorTypeName
        {
            get
            {
                return Distributor_Type_Name;
            }
            set
            {
                Distributor_Type_Name = value;
            }
        }

        public static int DivisionID
        {
            get
            {
                return mDivisionID;
            }
            set
            {
                mDivisionID = value;
            }
        }

        public static int DocumentDurationToShow
        {
            get
            {
                return mDocumentDurationToShow;
            }
            set
            {
                mDocumentDurationToShow = value;
            }
        }

        public static string ErrorLogPath
        {
            get
            {
                mstrErrorLogPath = GetAppInstallationPath() + "Logs";
                return mstrErrorLogPath;
            }
            set
            {
                mstrErrorLogPath = value;
            }
        }

        public static string ExpensDefaultType
        {
            get
            {
                return mExpensDefaultType;
            }
            set
            {
                mExpensDefaultType = value;
            }
        }

        public static string FreeStock
        {
            get
            {
                return mFreeStock;
            }
            set
            {
                mFreeStock = value;
            }
        }

        public static string GSTAccount
        {
            get
            {
                return mGSTAccount;
            }
            set
            {
                mGSTAccount = value;
            }
        }

        public static string HHAppFilesFolder
        {
            get
            {
                return mHHAppFilesFolder;
            }
        }

        public static string InboxPath
        {
            get
            {
                return mInboxPath;
            }
            set
            {
                mInboxPath = value;
            }
        }

        public static bool IsApplicationRunning
        {
            get
            {
                return m_isApplicationRunning;
            }
            set
            {
                m_isApplicationRunning = value;
            }
        }

        public static bool IsDistReg
        {
            get
            {
                return mIsDistReg;
            }
            set
            {
                mIsDistReg = value;
            }
        }

        public static bool IsRpUpdate
        {
            get
            {
                return mIsRpUpdate;
            }
            set
            {
                mIsRpUpdate = value;
            }
        }

        public static bool IsTaxPriceUpdate
        {
            get
            {
                return mIsTaxPriceUpdate;
            }
            set
            {
                mIsTaxPriceUpdate = value;
            }
        }

        public static bool IsTpUpdate
        {
            get
            {
                return mIsTpUpdate;
            }
            set
            {
                mIsTpUpdate = value;
            }
        }

        public static Language Languages
        {
            get
            {
                return m_Language;
            }
            set
            {
                m_Language = value;
            }
        }

        public static string MailingServerAddress
        {
            get
            {
                return m_strMailingServerAddress;
            }
            set
            {
                m_strMailingServerAddress = value;
            }
        }

        public static string MailSenderAddress
        {
            get
            {
                return m_strMailSenderAddress;
            }
            set
            {
                m_strMailSenderAddress = value;
            }
        }

        public static int MaxDayClose
        {
            get
            {
                return mMaxDayClose;
            }
            set
            {
                mMaxDayClose = value;
            }
        }

        public static string OutboxPath
        {
            get
            {
                return mOutboxPath;
            }
            set
            {
                mOutboxPath = value;
            }
        }

        public static Pack Packs
        {
            get
            {
                return m_Pack;
            }
            set
            {
                m_Pack = value;
            }
        }

        public static string PayableAccount
        {
            get
            {
                return mPayableAccount;
            }
            set
            {
                mPayableAccount = value;
            }
        }

        public static string PeatyCash
        {
            get
            {
                return mPeatyCash;
            }
            set
            {
                mPeatyCash = value;
            }
        }

        public static string PrintOnOrderForm
        {
            get
            {
                return m_strPrintOnOrderForm;
            }
            set
            {
                m_strPrintOnOrderForm = value;
            }
        }

        public static SAMS.Common.Classes.Enums.PrintPaper PrintPaper
        {
            get
            {
                return mPrintPaper;
            }
            set
            {
                mPrintPaper = value;
            }
        }

        public static string PrintType
        {
            get
            {
                return m_strPrintType;
            }
            set
            {
                m_strPrintType = value;
            }
        }

        public static int PromotionId
        {
            get
            {
                return m_PromotionId;
            }
            set
            {
                m_PromotionId = value;
            }
        }

        public static string PurchaseAccount
        {
            get
            {
                return mPurchaseAccount;
            }
            set
            {
                mPurchaseAccount = value;
            }
        }

        public static string PurchasReturnAccount
        {
            get
            {
                return mPurchasReturnAccount;
            }
            set
            {
                mPurchasReturnAccount = value;
            }
        }

        public static string QueryTimeOut
        {
            get
            {
                return mQueryTimeOut;
            }
            set
            {
                mQueryTimeOut = value;
            }
        }

        public static string ReportExportPath
        {
            get
            {
                return m_ReportExportPath;
            }
        }

        public static int RoleId
        {
            get
            {
                return mRoleID;
            }
            set
            {
                mRoleID = value;
            }
        }

        public static string SaleAccount
        {
            get
            {
                return mSaleAccount;
            }
            set
            {
                mSaleAccount = value;
            }
        }

        public static string SaleDiscount
        {
            get
            {
                return mSaleDiscount;
            }
            set
            {
                mSaleDiscount = value;
            }
        }

        public static string SaleScheme
        {
            get
            {
                return mSaleScheme;
            }
            set
            {
                mSaleScheme = value;
            }
        }

        public static string SchemeAccount
        {
            get
            {
                return mSchemeAccount;
            }
            set
            {
                mSchemeAccount = value;
            }
        }

        public static string ServerFTPpath
        {
            get
            {
                return m_strServerFTPpath;
            }
            set
            {
                m_strServerFTPpath = value;
            }
        }

        public static string ServerHttpPath
        {
            get
            {
                return m_ServerHttpPath;
            }
            set
            {
                ServerHttpPath = value;
            }
        }

        public static string ServerSettingURL
        {
            get
            {
                return m_ServerSettingURL;
            }
        }

        public static string ServerUserName
        {
            get
            {
                return mstrServerUserName;
            }
            set
            {
                mstrServerUserName = value;
            }
        }

        public static string ServerUserPwd
        {
            get
            {
                return mstrServerUserPswd;
            }
            set
            {
                mstrServerUserPswd = value;
            }
        }

        public static string ServerVersion
        {
            get
            {
                return m_strServerVersion;
            }
        }

        public static string SKUonHandShowValue
        {
            get
            {
                return m_strSKUonHandShowValue;
            }
            set
            {
                m_strSKUonHandShowValue = value;
            }
        }

        public static string SMTPAddress
        {
            get
            {
                return mstrSMTPAddress;
            }
            set
            {
                mstrSMTPAddress = value;
            }
        }

        public static string StockInHand
        {
            get
            {
                return mStockInHand;
            }
            set
            {
                mStockInHand = value;
            }
        }

        public static string SyncLog_Process_Path
        {
            get
            {
                return m_strSyncLog_Process_Path;
            }
            set
            {
                m_strSyncLog_Process_Path = value;
            }
        }

        public static DateTime SystemCurrentDate
        {
            get
            {
                return mSystemCurrentDate;
            }
            set
            {
                mSystemCurrentDate = value;
            }
        }

        public static DateTime SystemCurrentDateTime
        {
            get
            {
                return mSystemCurrentDateTime;
            }
            set
            {
                mSystemCurrentDateTime = value;
            }
        }

        public static int SystemUserId
        {
            get
            {
                return mSystemUserID;
            }
            set
            {
                mSystemUserID = value;
            }
        }

        public static string ThreadTime
        {
            get
            {
                return m_strThreadTime;
            }
            set
            {
                m_strThreadTime = value;
            }
        }

        public static string TimeInterval
        {
            get
            {
                return m_strTimeInterval;
            }
            set
            {
                m_strTimeInterval = value;
            }
        }

        public static DateTime TransactionDateTime
        {
            get
            {
                return (mSystemCurrentDate.Date + DateTime.Now.TimeOfDay);
            }
        }

        public static string TransferInAccount
        {
            get
            {
                return mTransferInAccount;
            }
            set
            {
                mTransferInAccount = value;
            }
        }

        public static string TransferOutAccount
        {
            get
            {
                return mTransferOutAccount;
            }
            set
            {
                mTransferOutAccount = value;
            }
        }

        public static string UploadLog
        {
            get
            {
                return m_strUploadLog;
            }
            set
            {
                m_strUploadLog = value;
            }
        }

        public static int UserID
        {
            get
            {
                return mUserID;
            }
            set
            {
                mUserID = value;
            }
        }

        public static int UserTypeId
        {
            get
            {
                return mUserTypeID;
            }
            set
            {
                mUserTypeID = value;
            }
        }
    }
}

