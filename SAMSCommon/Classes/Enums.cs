namespace SAMS.Common.Classes
{
    using System;

    public class Enums
    {
        public enum CheckEntries
        {
            Unhandled,
            Bounced,
            Cleared,
            Deposit
        }

        public enum ClaimStatus
        {
            Approved = 0x39,
            Cancelled = 0x3a,
            Pending = 0x38,
            Rejected = 0x3b
        }

        public enum ClaimTo
        {
            HeadOffice,
            Factory,
            Distributor
        }

        public enum ClaimType
        {
            DamageClaim = 0x6c,
            IncentivesClaim = 0x36,
            OtherClaim = 0x37,
            PromotionalClaim = 0x33,
            SalesReturnClaim = 0x34,
            TADAClaims = 0x35
        }

        public enum DisputeStatus
        {
            Pending,
            Approved,
            Rejected
        }

        public enum PartyType
        {
            Bank = 60,
            Cash = 0x3f,
            Customer = 0x41,
            Expense = 0x3d,
            FixedAssets = 0x3e,
            Purchase = 0x7b,
            SalesForce = 100,
            SaleType = 0x6a,
            Supplier = 0x40
        }

        public enum PaymentMode
        {
            Both = 0x45,
            Cash = 0x42,
            Cheque = 0x43,
            Credit = 0x44
        }

        public enum PrintPaper
        {
            A4 = 4,
            A5 = 5
        }

        public enum PurchaseType
        {
            Invoice = 0x5f,
            Pickslip = 0x5e,
            Requisition = 0x65,
            ReturnPickSlip = 0x6d
        }

        public enum SalesForceType
        {
            Delieryman = 0x62,
            OrderBooker = 0x61,
            SalesPerson = 0x63
        }

        public enum TransactionType
        {
            Credit = 0x4b,
            Debit = 0x4c
        }
    }
}

