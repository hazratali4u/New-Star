namespace SAMS.BusinessLayer.Reports
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, DesignerCategory("code"), XmlRoot("DsReport2"), HelpKeyword("vs.data.DataSet"), XmlSchemaProvider("GetTypedDataSetSchema"), ToolboxItem(true)]
    public class DsReport2 : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private GrossPrifitReportDataTable tableGrossPrifitReport;
        private RptCustomerSaleReportDataTable tableRptCustomerSaleReport;
        private RptLoadCreditDetailDataTable tableRptLoadCreditDetail;
        private RptLoadPassSummaryDataTable tableRptLoadPassSummary;
        private RptPrintDSRDataTable tableRptPrintDSR;
        private RptSKUWiseBookingVsExecutionDataTable tableRptSKUWiseBookingVsExecution;
        private rptStockValuationDetailDataTable tablerptStockValuationDetail;
        private uspGetStockValuationDataTable tableuspGetStockValuation;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DsReport2()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected DsReport2(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
            else
            {
                string s = (string) info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["RptLoadPassSummary"] != null)
                    {
                        base.Tables.Add(new RptLoadPassSummaryDataTable(dataSet.Tables["RptLoadPassSummary"]));
                    }
                    if (dataSet.Tables["RptLoadCreditDetail"] != null)
                    {
                        base.Tables.Add(new RptLoadCreditDetailDataTable(dataSet.Tables["RptLoadCreditDetail"]));
                    }
                    if (dataSet.Tables["GrossPrifitReport"] != null)
                    {
                        base.Tables.Add(new GrossPrifitReportDataTable(dataSet.Tables["GrossPrifitReport"]));
                    }
                    if (dataSet.Tables["RptCustomerSaleReport"] != null)
                    {
                        base.Tables.Add(new RptCustomerSaleReportDataTable(dataSet.Tables["RptCustomerSaleReport"]));
                    }
                    if (dataSet.Tables["RptPrintDSR"] != null)
                    {
                        base.Tables.Add(new RptPrintDSRDataTable(dataSet.Tables["RptPrintDSR"]));
                    }
                    if (dataSet.Tables["RptSKUWiseBookingVsExecution"] != null)
                    {
                        base.Tables.Add(new RptSKUWiseBookingVsExecutionDataTable(dataSet.Tables["RptSKUWiseBookingVsExecution"]));
                    }
                    if (dataSet.Tables["uspGetStockValuation"] != null)
                    {
                        base.Tables.Add(new uspGetStockValuationDataTable(dataSet.Tables["uspGetStockValuation"]));
                    }
                    if (dataSet.Tables["rptStockValuationDetail"] != null)
                    {
                        base.Tables.Add(new rptStockValuationDetailDataTable(dataSet.Tables["rptStockValuationDetail"]));
                    }
                    base.DataSetName = dataSet.DataSetName;
                    base.Prefix = dataSet.Prefix;
                    base.Namespace = dataSet.Namespace;
                    base.Locale = dataSet.Locale;
                    base.CaseSensitive = dataSet.CaseSensitive;
                    base.EnforceConstraints = dataSet.EnforceConstraints;
                    base.Merge(dataSet, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    base.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                base.GetSerializationData(info, context);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += handler2;
                this.Relations.CollectionChanged += handler2;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public override DataSet Clone()
        {
            DsReport2 report = (DsReport2) base.Clone();
            report.InitVars();
            report.SchemaSerializationMode = this.SchemaSerializationMode;
            return report;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            DsReport2 report = new DsReport2();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = report.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = report.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema) enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitClass()
        {
            base.DataSetName = "DsReport2";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/DsReport2.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableRptLoadPassSummary = new RptLoadPassSummaryDataTable();
            base.Tables.Add(this.tableRptLoadPassSummary);
            this.tableRptLoadCreditDetail = new RptLoadCreditDetailDataTable();
            base.Tables.Add(this.tableRptLoadCreditDetail);
            this.tableGrossPrifitReport = new GrossPrifitReportDataTable();
            base.Tables.Add(this.tableGrossPrifitReport);
            this.tableRptCustomerSaleReport = new RptCustomerSaleReportDataTable();
            base.Tables.Add(this.tableRptCustomerSaleReport);
            this.tableRptPrintDSR = new RptPrintDSRDataTable();
            base.Tables.Add(this.tableRptPrintDSR);
            this.tableRptSKUWiseBookingVsExecution = new RptSKUWiseBookingVsExecutionDataTable();
            base.Tables.Add(this.tableRptSKUWiseBookingVsExecution);
            this.tableuspGetStockValuation = new uspGetStockValuationDataTable();
            base.Tables.Add(this.tableuspGetStockValuation);
            this.tablerptStockValuationDetail = new rptStockValuationDetailDataTable();
            base.Tables.Add(this.tablerptStockValuationDetail);
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars(bool initTable)
        {
            this.tableRptLoadPassSummary = (RptLoadPassSummaryDataTable) base.Tables["RptLoadPassSummary"];
            if (initTable && (this.tableRptLoadPassSummary != null))
            {
                this.tableRptLoadPassSummary.InitVars();
            }
            this.tableRptLoadCreditDetail = (RptLoadCreditDetailDataTable) base.Tables["RptLoadCreditDetail"];
            if (initTable && (this.tableRptLoadCreditDetail != null))
            {
                this.tableRptLoadCreditDetail.InitVars();
            }
            this.tableGrossPrifitReport = (GrossPrifitReportDataTable) base.Tables["GrossPrifitReport"];
            if (initTable && (this.tableGrossPrifitReport != null))
            {
                this.tableGrossPrifitReport.InitVars();
            }
            this.tableRptCustomerSaleReport = (RptCustomerSaleReportDataTable) base.Tables["RptCustomerSaleReport"];
            if (initTable && (this.tableRptCustomerSaleReport != null))
            {
                this.tableRptCustomerSaleReport.InitVars();
            }
            this.tableRptPrintDSR = (RptPrintDSRDataTable) base.Tables["RptPrintDSR"];
            if (initTable && (this.tableRptPrintDSR != null))
            {
                this.tableRptPrintDSR.InitVars();
            }
            this.tableRptSKUWiseBookingVsExecution = (RptSKUWiseBookingVsExecutionDataTable) base.Tables["RptSKUWiseBookingVsExecution"];
            if (initTable && (this.tableRptSKUWiseBookingVsExecution != null))
            {
                this.tableRptSKUWiseBookingVsExecution.InitVars();
            }
            this.tableuspGetStockValuation = (uspGetStockValuationDataTable) base.Tables["uspGetStockValuation"];
            if (initTable && (this.tableuspGetStockValuation != null))
            {
                this.tableuspGetStockValuation.InitVars();
            }
            this.tablerptStockValuationDetail = (rptStockValuationDetailDataTable) base.Tables["rptStockValuationDetail"];
            if (initTable && (this.tablerptStockValuationDetail != null))
            {
                this.tablerptStockValuationDetail.InitVars();
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["RptLoadPassSummary"] != null)
                {
                    base.Tables.Add(new RptLoadPassSummaryDataTable(dataSet.Tables["RptLoadPassSummary"]));
                }
                if (dataSet.Tables["RptLoadCreditDetail"] != null)
                {
                    base.Tables.Add(new RptLoadCreditDetailDataTable(dataSet.Tables["RptLoadCreditDetail"]));
                }
                if (dataSet.Tables["GrossPrifitReport"] != null)
                {
                    base.Tables.Add(new GrossPrifitReportDataTable(dataSet.Tables["GrossPrifitReport"]));
                }
                if (dataSet.Tables["RptCustomerSaleReport"] != null)
                {
                    base.Tables.Add(new RptCustomerSaleReportDataTable(dataSet.Tables["RptCustomerSaleReport"]));
                }
                if (dataSet.Tables["RptPrintDSR"] != null)
                {
                    base.Tables.Add(new RptPrintDSRDataTable(dataSet.Tables["RptPrintDSR"]));
                }
                if (dataSet.Tables["RptSKUWiseBookingVsExecution"] != null)
                {
                    base.Tables.Add(new RptSKUWiseBookingVsExecutionDataTable(dataSet.Tables["RptSKUWiseBookingVsExecution"]));
                }
                if (dataSet.Tables["uspGetStockValuation"] != null)
                {
                    base.Tables.Add(new uspGetStockValuationDataTable(dataSet.Tables["uspGetStockValuation"]));
                }
                if (dataSet.Tables["rptStockValuationDetail"] != null)
                {
                    base.Tables.Add(new rptStockValuationDetailDataTable(dataSet.Tables["rptStockValuationDetail"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeGrossPrifitReport()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeRptCustomerSaleReport()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeRptLoadCreditDetail()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeRptLoadPassSummary()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeRptPrintDSR()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeRptSKUWiseBookingVsExecution()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializerptStockValuationDetail()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeuspGetStockValuation()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public GrossPrifitReportDataTable GrossPrifitReport
        {
            get
            {
                return this.tableGrossPrifitReport;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RptCustomerSaleReportDataTable RptCustomerSaleReport
        {
            get
            {
                return this.tableRptCustomerSaleReport;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public RptLoadCreditDetailDataTable RptLoadCreditDetail
        {
            get
            {
                return this.tableRptLoadCreditDetail;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false)]
        public RptLoadPassSummaryDataTable RptLoadPassSummary
        {
            get
            {
                return this.tableRptLoadPassSummary;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public RptPrintDSRDataTable RptPrintDSR
        {
            get
            {
                return this.tableRptPrintDSR;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
        public RptSKUWiseBookingVsExecutionDataTable RptSKUWiseBookingVsExecution
        {
            get
            {
                return this.tableRptSKUWiseBookingVsExecution;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
        public rptStockValuationDetailDataTable rptStockValuationDetail
        {
            get
            {
                return this.tablerptStockValuationDetail;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(true), DebuggerNonUserCode]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public uspGetStockValuationDataTable uspGetStockValuation
        {
            get
            {
                return this.tableuspGetStockValuation;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class GrossPrifitReportDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAdministrative_Exp;
            private DataColumn columnCostofGoods;
            private DataColumn columnGrossSales;
            private DataColumn columnSale_return;
            private DataColumn columnSelling_Exp;
            private DataColumn columnUnClaimableDiscount;
            private DataColumn columnUtillity_Exp;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.GrossPrifitReportRowChangeEventHandler GrossPrifitReportRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.GrossPrifitReportRowChangeEventHandler GrossPrifitReportRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.GrossPrifitReportRowChangeEventHandler GrossPrifitReportRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.GrossPrifitReportRowChangeEventHandler GrossPrifitReportRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public GrossPrifitReportDataTable()
            {
                base.TableName = "GrossPrifitReport";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal GrossPrifitReportDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected GrossPrifitReportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddGrossPrifitReportRow(DsReport2.GrossPrifitReportRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.GrossPrifitReportRow AddGrossPrifitReportRow(decimal GrossSales, decimal UnClaimableDiscount, decimal Administrative_Exp, decimal Utillity_Exp, decimal Selling_Exp, decimal Sale_return, decimal CostofGoods)
            {
                DsReport2.GrossPrifitReportRow row = (DsReport2.GrossPrifitReportRow) base.NewRow();
                row.ItemArray = new object[] { GrossSales, UnClaimableDiscount, Administrative_Exp, Utillity_Exp, Selling_Exp, Sale_return, CostofGoods };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DsReport2.GrossPrifitReportDataTable table = (DsReport2.GrossPrifitReportDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.GrossPrifitReportDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.GrossPrifitReportRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "GrossPrifitReportDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnGrossSales = new DataColumn("GrossSales", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnGrossSales);
                this.columnUnClaimableDiscount = new DataColumn("UnClaimableDiscount", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnUnClaimableDiscount);
                this.columnAdministrative_Exp = new DataColumn("Administrative_Exp", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnAdministrative_Exp);
                this.columnUtillity_Exp = new DataColumn("Utillity_Exp", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnUtillity_Exp);
                this.columnSelling_Exp = new DataColumn("Selling_Exp", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnSelling_Exp);
                this.columnSale_return = new DataColumn("Sale_return", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnSale_return);
                this.columnCostofGoods = new DataColumn("CostofGoods", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnCostofGoods);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnGrossSales = base.Columns["GrossSales"];
                this.columnUnClaimableDiscount = base.Columns["UnClaimableDiscount"];
                this.columnAdministrative_Exp = base.Columns["Administrative_Exp"];
                this.columnUtillity_Exp = base.Columns["Utillity_Exp"];
                this.columnSelling_Exp = base.Columns["Selling_Exp"];
                this.columnSale_return = base.Columns["Sale_return"];
                this.columnCostofGoods = base.Columns["CostofGoods"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.GrossPrifitReportRow NewGrossPrifitReportRow()
            {
                return (DsReport2.GrossPrifitReportRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.GrossPrifitReportRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.GrossPrifitReportRowChanged != null)
                {
                    this.GrossPrifitReportRowChanged(this, new DsReport2.GrossPrifitReportRowChangeEvent((DsReport2.GrossPrifitReportRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.GrossPrifitReportRowChanging != null)
                {
                    this.GrossPrifitReportRowChanging(this, new DsReport2.GrossPrifitReportRowChangeEvent((DsReport2.GrossPrifitReportRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.GrossPrifitReportRowDeleted != null)
                {
                    this.GrossPrifitReportRowDeleted(this, new DsReport2.GrossPrifitReportRowChangeEvent((DsReport2.GrossPrifitReportRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.GrossPrifitReportRowDeleting != null)
                {
                    this.GrossPrifitReportRowDeleting(this, new DsReport2.GrossPrifitReportRowChangeEvent((DsReport2.GrossPrifitReportRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveGrossPrifitReportRow(DsReport2.GrossPrifitReportRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Administrative_ExpColumn
            {
                get
                {
                    return this.columnAdministrative_Exp;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn CostofGoodsColumn
            {
                get
                {
                    return this.columnCostofGoods;
                }
            }

            [DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GrossSalesColumn
            {
                get
                {
                    return this.columnGrossSales;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.GrossPrifitReportRow this[int index]
            {
                get
                {
                    return (DsReport2.GrossPrifitReportRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Sale_returnColumn
            {
                get
                {
                    return this.columnSale_return;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Selling_ExpColumn
            {
                get
                {
                    return this.columnSelling_Exp;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn UnClaimableDiscountColumn
            {
                get
                {
                    return this.columnUnClaimableDiscount;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn Utillity_ExpColumn
            {
                get
                {
                    return this.columnUtillity_Exp;
                }
            }
        }

        public class GrossPrifitReportRow : DataRow
        {
            private DsReport2.GrossPrifitReportDataTable tableGrossPrifitReport;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal GrossPrifitReportRow(DataRowBuilder rb) : base(rb)
            {
                this.tableGrossPrifitReport = (DsReport2.GrossPrifitReportDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsAdministrative_ExpNull()
            {
                return base.IsNull(this.tableGrossPrifitReport.Administrative_ExpColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsCostofGoodsNull()
            {
                return base.IsNull(this.tableGrossPrifitReport.CostofGoodsColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGrossSalesNull()
            {
                return base.IsNull(this.tableGrossPrifitReport.GrossSalesColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSale_returnNull()
            {
                return base.IsNull(this.tableGrossPrifitReport.Sale_returnColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSelling_ExpNull()
            {
                return base.IsNull(this.tableGrossPrifitReport.Selling_ExpColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUnClaimableDiscountNull()
            {
                return base.IsNull(this.tableGrossPrifitReport.UnClaimableDiscountColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsUtillity_ExpNull()
            {
                return base.IsNull(this.tableGrossPrifitReport.Utillity_ExpColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAdministrative_ExpNull()
            {
                base[this.tableGrossPrifitReport.Administrative_ExpColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetCostofGoodsNull()
            {
                base[this.tableGrossPrifitReport.CostofGoodsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGrossSalesNull()
            {
                base[this.tableGrossPrifitReport.GrossSalesColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSale_returnNull()
            {
                base[this.tableGrossPrifitReport.Sale_returnColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSelling_ExpNull()
            {
                base[this.tableGrossPrifitReport.Selling_ExpColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetUnClaimableDiscountNull()
            {
                base[this.tableGrossPrifitReport.UnClaimableDiscountColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetUtillity_ExpNull()
            {
                base[this.tableGrossPrifitReport.Utillity_ExpColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal Administrative_Exp
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableGrossPrifitReport.Administrative_ExpColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Administrative_Exp' in table 'GrossPrifitReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrossPrifitReport.Administrative_ExpColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal CostofGoods
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableGrossPrifitReport.CostofGoodsColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CostofGoods' in table 'GrossPrifitReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrossPrifitReport.CostofGoodsColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal GrossSales
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableGrossPrifitReport.GrossSalesColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'GrossSales' in table 'GrossPrifitReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrossPrifitReport.GrossSalesColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal Sale_return
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableGrossPrifitReport.Sale_returnColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sale_return' in table 'GrossPrifitReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrossPrifitReport.Sale_returnColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal Selling_Exp
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableGrossPrifitReport.Selling_ExpColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Selling_Exp' in table 'GrossPrifitReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrossPrifitReport.Selling_ExpColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal UnClaimableDiscount
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableGrossPrifitReport.UnClaimableDiscountColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'UnClaimableDiscount' in table 'GrossPrifitReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrossPrifitReport.UnClaimableDiscountColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal Utillity_Exp
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableGrossPrifitReport.Utillity_ExpColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Utillity_Exp' in table 'GrossPrifitReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableGrossPrifitReport.Utillity_ExpColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class GrossPrifitReportRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.GrossPrifitReportRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public GrossPrifitReportRowChangeEvent(DsReport2.GrossPrifitReportRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.GrossPrifitReportRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void GrossPrifitReportRowChangeEventHandler(object sender, DsReport2.GrossPrifitReportRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class RptCustomerSaleReportDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAMOUNT;
            private DataColumn columnCUSTOMER_NAME;
            private DataColumn columnDISCOUNT;
            private DataColumn columnGST_AMOUNT;
            private DataColumn columnNET_AMOUNT;
            private DataColumn columnQUANTITY_UNIT;
            private DataColumn columnSERIAL_NO;
            private DataColumn columnSKU_CODE;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptCustomerSaleReportRowChangeEventHandler RptCustomerSaleReportRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptCustomerSaleReportRowChangeEventHandler RptCustomerSaleReportRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptCustomerSaleReportRowChangeEventHandler RptCustomerSaleReportRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptCustomerSaleReportRowChangeEventHandler RptCustomerSaleReportRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RptCustomerSaleReportDataTable()
            {
                base.TableName = "RptCustomerSaleReport";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal RptCustomerSaleReportDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected RptCustomerSaleReportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddRptCustomerSaleReportRow(DsReport2.RptCustomerSaleReportRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptCustomerSaleReportRow AddRptCustomerSaleReportRow(string CUSTOMER_NAME, string SKU_CODE, decimal AMOUNT, decimal DISCOUNT, decimal GST_AMOUNT, decimal NET_AMOUNT, long QUANTITY_UNIT)
            {
                DsReport2.RptCustomerSaleReportRow row = (DsReport2.RptCustomerSaleReportRow) base.NewRow();
                object[] objArray2 = new object[8];
                objArray2[1] = CUSTOMER_NAME;
                objArray2[2] = SKU_CODE;
                objArray2[3] = AMOUNT;
                objArray2[4] = DISCOUNT;
                objArray2[5] = GST_AMOUNT;
                objArray2[6] = NET_AMOUNT;
                objArray2[7] = QUANTITY_UNIT;
                object[] objArray = objArray2;
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DsReport2.RptCustomerSaleReportDataTable table = (DsReport2.RptCustomerSaleReportDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.RptCustomerSaleReportDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.RptCustomerSaleReportRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "RptCustomerSaleReportDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnSERIAL_NO = new DataColumn("SERIAL_NO", typeof(long), null, MappingType.Element);
                base.Columns.Add(this.columnSERIAL_NO);
                this.columnCUSTOMER_NAME = new DataColumn("CUSTOMER_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCUSTOMER_NAME);
                this.columnSKU_CODE = new DataColumn("SKU_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_CODE);
                this.columnAMOUNT = new DataColumn("AMOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnAMOUNT);
                this.columnDISCOUNT = new DataColumn("DISCOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnDISCOUNT);
                this.columnGST_AMOUNT = new DataColumn("GST_AMOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnGST_AMOUNT);
                this.columnNET_AMOUNT = new DataColumn("NET_AMOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnNET_AMOUNT);
                this.columnQUANTITY_UNIT = new DataColumn("QUANTITY_UNIT", typeof(long), null, MappingType.Element);
                base.Columns.Add(this.columnQUANTITY_UNIT);
                this.columnSERIAL_NO.AutoIncrement = true;
                this.columnSERIAL_NO.AllowDBNull = false;
                this.columnSERIAL_NO.ReadOnly = true;
                this.columnCUSTOMER_NAME.ReadOnly = true;
                this.columnCUSTOMER_NAME.MaxLength = 0x65;
                this.columnSKU_CODE.AllowDBNull = false;
                this.columnSKU_CODE.MaxLength = 15;
                this.columnDISCOUNT.ReadOnly = true;
                this.columnGST_AMOUNT.ReadOnly = true;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnSERIAL_NO = base.Columns["SERIAL_NO"];
                this.columnCUSTOMER_NAME = base.Columns["CUSTOMER_NAME"];
                this.columnSKU_CODE = base.Columns["SKU_CODE"];
                this.columnAMOUNT = base.Columns["AMOUNT"];
                this.columnDISCOUNT = base.Columns["DISCOUNT"];
                this.columnGST_AMOUNT = base.Columns["GST_AMOUNT"];
                this.columnNET_AMOUNT = base.Columns["NET_AMOUNT"];
                this.columnQUANTITY_UNIT = base.Columns["QUANTITY_UNIT"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.RptCustomerSaleReportRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.RptCustomerSaleReportRow NewRptCustomerSaleReportRow()
            {
                return (DsReport2.RptCustomerSaleReportRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RptCustomerSaleReportRowChanged != null)
                {
                    this.RptCustomerSaleReportRowChanged(this, new DsReport2.RptCustomerSaleReportRowChangeEvent((DsReport2.RptCustomerSaleReportRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RptCustomerSaleReportRowChanging != null)
                {
                    this.RptCustomerSaleReportRowChanging(this, new DsReport2.RptCustomerSaleReportRowChangeEvent((DsReport2.RptCustomerSaleReportRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RptCustomerSaleReportRowDeleted != null)
                {
                    this.RptCustomerSaleReportRowDeleted(this, new DsReport2.RptCustomerSaleReportRowChangeEvent((DsReport2.RptCustomerSaleReportRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RptCustomerSaleReportRowDeleting != null)
                {
                    this.RptCustomerSaleReportRowDeleting(this, new DsReport2.RptCustomerSaleReportRowChangeEvent((DsReport2.RptCustomerSaleReportRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveRptCustomerSaleReportRow(DsReport2.RptCustomerSaleReportRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn AMOUNTColumn
            {
                get
                {
                    return this.columnAMOUNT;
                }
            }

            [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CUSTOMER_NAMEColumn
            {
                get
                {
                    return this.columnCUSTOMER_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DISCOUNTColumn
            {
                get
                {
                    return this.columnDISCOUNT;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GST_AMOUNTColumn
            {
                get
                {
                    return this.columnGST_AMOUNT;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.RptCustomerSaleReportRow this[int index]
            {
                get
                {
                    return (DsReport2.RptCustomerSaleReportRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NET_AMOUNTColumn
            {
                get
                {
                    return this.columnNET_AMOUNT;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn QUANTITY_UNITColumn
            {
                get
                {
                    return this.columnQUANTITY_UNIT;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SERIAL_NOColumn
            {
                get
                {
                    return this.columnSERIAL_NO;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_CODEColumn
            {
                get
                {
                    return this.columnSKU_CODE;
                }
            }
        }

        public class RptCustomerSaleReportRow : DataRow
        {
            private DsReport2.RptCustomerSaleReportDataTable tableRptCustomerSaleReport;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RptCustomerSaleReportRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRptCustomerSaleReport = (DsReport2.RptCustomerSaleReportDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAMOUNTNull()
            {
                return base.IsNull(this.tableRptCustomerSaleReport.AMOUNTColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsCUSTOMER_NAMENull()
            {
                return base.IsNull(this.tableRptCustomerSaleReport.CUSTOMER_NAMEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDISCOUNTNull()
            {
                return base.IsNull(this.tableRptCustomerSaleReport.DISCOUNTColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsGST_AMOUNTNull()
            {
                return base.IsNull(this.tableRptCustomerSaleReport.GST_AMOUNTColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsNET_AMOUNTNull()
            {
                return base.IsNull(this.tableRptCustomerSaleReport.NET_AMOUNTColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQUANTITY_UNITNull()
            {
                return base.IsNull(this.tableRptCustomerSaleReport.QUANTITY_UNITColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetAMOUNTNull()
            {
                base[this.tableRptCustomerSaleReport.AMOUNTColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetCUSTOMER_NAMENull()
            {
                base[this.tableRptCustomerSaleReport.CUSTOMER_NAMEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDISCOUNTNull()
            {
                base[this.tableRptCustomerSaleReport.DISCOUNTColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetGST_AMOUNTNull()
            {
                base[this.tableRptCustomerSaleReport.GST_AMOUNTColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetNET_AMOUNTNull()
            {
                base[this.tableRptCustomerSaleReport.NET_AMOUNTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQUANTITY_UNITNull()
            {
                base[this.tableRptCustomerSaleReport.QUANTITY_UNITColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal AMOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptCustomerSaleReport.AMOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'AMOUNT' in table 'RptCustomerSaleReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.AMOUNTColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CUSTOMER_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptCustomerSaleReport.CUSTOMER_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CUSTOMER_NAME' in table 'RptCustomerSaleReport' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.CUSTOMER_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal DISCOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptCustomerSaleReport.DISCOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DISCOUNT' in table 'RptCustomerSaleReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.DISCOUNTColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal GST_AMOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptCustomerSaleReport.GST_AMOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'GST_AMOUNT' in table 'RptCustomerSaleReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.GST_AMOUNTColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal NET_AMOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptCustomerSaleReport.NET_AMOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'NET_AMOUNT' in table 'RptCustomerSaleReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.NET_AMOUNTColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public long QUANTITY_UNIT
            {
                get
                {
                    long num;
                    try
                    {
                        num = (long) base[this.tableRptCustomerSaleReport.QUANTITY_UNITColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'QUANTITY_UNIT' in table 'RptCustomerSaleReport' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.QUANTITY_UNITColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public long SERIAL_NO
            {
                get
                {
                    return (long) base[this.tableRptCustomerSaleReport.SERIAL_NOColumn];
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.SERIAL_NOColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_CODE
            {
                get
                {
                    return (string) base[this.tableRptCustomerSaleReport.SKU_CODEColumn];
                }
                set
                {
                    base[this.tableRptCustomerSaleReport.SKU_CODEColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class RptCustomerSaleReportRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.RptCustomerSaleReportRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RptCustomerSaleReportRowChangeEvent(DsReport2.RptCustomerSaleReportRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptCustomerSaleReportRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void RptCustomerSaleReportRowChangeEventHandler(object sender, DsReport2.RptCustomerSaleReportRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class RptLoadCreditDetailDataTable : DataTable, IEnumerable
        {
            private DataColumn columnBANK_NAME;
            private DataColumn columnCHEQUE_AMOUNT;
            private DataColumn columnCHEQUE_NO;
            private DataColumn columnCUSTOMER_CODE;
            private DataColumn columnCUSTOMER_NAME;
            private DataColumn columnDATE;
            private DataColumn columnSALE_INVOICE_ID;
            private DataColumn columnType;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadCreditDetailRowChangeEventHandler RptLoadCreditDetailRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadCreditDetailRowChangeEventHandler RptLoadCreditDetailRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadCreditDetailRowChangeEventHandler RptLoadCreditDetailRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadCreditDetailRowChangeEventHandler RptLoadCreditDetailRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public RptLoadCreditDetailDataTable()
            {
                base.TableName = "RptLoadCreditDetail";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RptLoadCreditDetailDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected RptLoadCreditDetailDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddRptLoadCreditDetailRow(DsReport2.RptLoadCreditDetailRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptLoadCreditDetailRow AddRptLoadCreditDetailRow(string Type, string CUSTOMER_CODE, string CUSTOMER_NAME, string BANK_NAME, string CHEQUE_NO, string DATE, decimal CHEQUE_AMOUNT, double SALE_INVOICE_ID)
            {
                DsReport2.RptLoadCreditDetailRow row = (DsReport2.RptLoadCreditDetailRow) base.NewRow();
                row.ItemArray = new object[] { Type, CUSTOMER_CODE, CUSTOMER_NAME, BANK_NAME, CHEQUE_NO, DATE, CHEQUE_AMOUNT, SALE_INVOICE_ID };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                DsReport2.RptLoadCreditDetailDataTable table = (DsReport2.RptLoadCreditDetailDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.RptLoadCreditDetailDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.RptLoadCreditDetailRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "RptLoadCreditDetailDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnType = new DataColumn("Type", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnType);
                this.columnCUSTOMER_CODE = new DataColumn("CUSTOMER_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCUSTOMER_CODE);
                this.columnCUSTOMER_NAME = new DataColumn("CUSTOMER_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCUSTOMER_NAME);
                this.columnBANK_NAME = new DataColumn("BANK_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBANK_NAME);
                this.columnCHEQUE_NO = new DataColumn("CHEQUE_NO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCHEQUE_NO);
                this.columnDATE = new DataColumn("DATE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDATE);
                this.columnCHEQUE_AMOUNT = new DataColumn("CHEQUE_AMOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnCHEQUE_AMOUNT);
                this.columnSALE_INVOICE_ID = new DataColumn("SALE_INVOICE_ID", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnSALE_INVOICE_ID);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnType = base.Columns["Type"];
                this.columnCUSTOMER_CODE = base.Columns["CUSTOMER_CODE"];
                this.columnCUSTOMER_NAME = base.Columns["CUSTOMER_NAME"];
                this.columnBANK_NAME = base.Columns["BANK_NAME"];
                this.columnCHEQUE_NO = base.Columns["CHEQUE_NO"];
                this.columnDATE = base.Columns["DATE"];
                this.columnCHEQUE_AMOUNT = base.Columns["CHEQUE_AMOUNT"];
                this.columnSALE_INVOICE_ID = base.Columns["SALE_INVOICE_ID"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.RptLoadCreditDetailRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.RptLoadCreditDetailRow NewRptLoadCreditDetailRow()
            {
                return (DsReport2.RptLoadCreditDetailRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RptLoadCreditDetailRowChanged != null)
                {
                    this.RptLoadCreditDetailRowChanged(this, new DsReport2.RptLoadCreditDetailRowChangeEvent((DsReport2.RptLoadCreditDetailRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RptLoadCreditDetailRowChanging != null)
                {
                    this.RptLoadCreditDetailRowChanging(this, new DsReport2.RptLoadCreditDetailRowChangeEvent((DsReport2.RptLoadCreditDetailRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RptLoadCreditDetailRowDeleted != null)
                {
                    this.RptLoadCreditDetailRowDeleted(this, new DsReport2.RptLoadCreditDetailRowChangeEvent((DsReport2.RptLoadCreditDetailRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RptLoadCreditDetailRowDeleting != null)
                {
                    this.RptLoadCreditDetailRowDeleting(this, new DsReport2.RptLoadCreditDetailRowChangeEvent((DsReport2.RptLoadCreditDetailRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveRptLoadCreditDetailRow(DsReport2.RptLoadCreditDetailRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn BANK_NAMEColumn
            {
                get
                {
                    return this.columnBANK_NAME;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn CHEQUE_AMOUNTColumn
            {
                get
                {
                    return this.columnCHEQUE_AMOUNT;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn CHEQUE_NOColumn
            {
                get
                {
                    return this.columnCHEQUE_NO;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CUSTOMER_CODEColumn
            {
                get
                {
                    return this.columnCUSTOMER_CODE;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn CUSTOMER_NAMEColumn
            {
                get
                {
                    return this.columnCUSTOMER_NAME;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DATEColumn
            {
                get
                {
                    return this.columnDATE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptLoadCreditDetailRow this[int index]
            {
                get
                {
                    return (DsReport2.RptLoadCreditDetailRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SALE_INVOICE_IDColumn
            {
                get
                {
                    return this.columnSALE_INVOICE_ID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TypeColumn
            {
                get
                {
                    return this.columnType;
                }
            }
        }

        public class RptLoadCreditDetailRow : DataRow
        {
            private DsReport2.RptLoadCreditDetailDataTable tableRptLoadCreditDetail;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RptLoadCreditDetailRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRptLoadCreditDetail = (DsReport2.RptLoadCreditDetailDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBANK_NAMENull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.BANK_NAMEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsCHEQUE_AMOUNTNull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.CHEQUE_AMOUNTColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsCHEQUE_NONull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.CHEQUE_NOColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCUSTOMER_CODENull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.CUSTOMER_CODEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsCUSTOMER_NAMENull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.CUSTOMER_NAMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDATENull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.DATEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSALE_INVOICE_IDNull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.SALE_INVOICE_IDColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsTypeNull()
            {
                return base.IsNull(this.tableRptLoadCreditDetail.TypeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBANK_NAMENull()
            {
                base[this.tableRptLoadCreditDetail.BANK_NAMEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetCHEQUE_AMOUNTNull()
            {
                base[this.tableRptLoadCreditDetail.CHEQUE_AMOUNTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCHEQUE_NONull()
            {
                base[this.tableRptLoadCreditDetail.CHEQUE_NOColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetCUSTOMER_CODENull()
            {
                base[this.tableRptLoadCreditDetail.CUSTOMER_CODEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetCUSTOMER_NAMENull()
            {
                base[this.tableRptLoadCreditDetail.CUSTOMER_NAMEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDATENull()
            {
                base[this.tableRptLoadCreditDetail.DATEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSALE_INVOICE_IDNull()
            {
                base[this.tableRptLoadCreditDetail.SALE_INVOICE_IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTypeNull()
            {
                base[this.tableRptLoadCreditDetail.TypeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string BANK_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadCreditDetail.BANK_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'BANK_NAME' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.BANK_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal CHEQUE_AMOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadCreditDetail.CHEQUE_AMOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CHEQUE_AMOUNT' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.CHEQUE_AMOUNTColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string CHEQUE_NO
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadCreditDetail.CHEQUE_NOColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CHEQUE_NO' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.CHEQUE_NOColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string CUSTOMER_CODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadCreditDetail.CUSTOMER_CODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CUSTOMER_CODE' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.CUSTOMER_CODEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string CUSTOMER_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadCreditDetail.CUSTOMER_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CUSTOMER_NAME' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.CUSTOMER_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string DATE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadCreditDetail.DATEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DATE' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.DATEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public double SALE_INVOICE_ID
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableRptLoadCreditDetail.SALE_INVOICE_IDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SALE_INVOICE_ID' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.SALE_INVOICE_IDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string Type
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadCreditDetail.TypeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Type' in table 'RptLoadCreditDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadCreditDetail.TypeColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class RptLoadCreditDetailRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.RptLoadCreditDetailRow eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public RptLoadCreditDetailRowChangeEvent(DsReport2.RptLoadCreditDetailRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptLoadCreditDetailRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void RptLoadCreditDetailRowChangeEventHandler(object sender, DsReport2.RptLoadCreditDetailRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class RptLoadPassSummaryDataTable : DataTable, IEnumerable
        {
            private DataColumn columnAREA_NAME;
            private DataColumn columnDA_DISCOUNT;
            private DataColumn columnDAMAGEDQTY;
            private DataColumn columnORDERQTY;
            private DataColumn columnRATE;
            private DataColumn columnRETURNQTY;
            private DataColumn columnSA_DISCOUNT;
            private DataColumn columnSALEDQTY;
            private DataColumn columnSKU_CODE;
            private DataColumn columnSKU_HIE_NAME;
            private DataColumn columnSKU_NAME;
            private DataColumn columnSR_DISCOUNT;
            private DataColumn columnUSER_NAME;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadPassSummaryRowChangeEventHandler RptLoadPassSummaryRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadPassSummaryRowChangeEventHandler RptLoadPassSummaryRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadPassSummaryRowChangeEventHandler RptLoadPassSummaryRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptLoadPassSummaryRowChangeEventHandler RptLoadPassSummaryRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public RptLoadPassSummaryDataTable()
            {
                base.TableName = "RptLoadPassSummary";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RptLoadPassSummaryDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected RptLoadPassSummaryDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddRptLoadPassSummaryRow(DsReport2.RptLoadPassSummaryRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptLoadPassSummaryRow AddRptLoadPassSummaryRow(string SKU_HIE_NAME, string SKU_CODE, string SKU_NAME, string AREA_NAME, string USER_NAME, decimal RATE, decimal ORDERQTY, decimal SALEDQTY, decimal SA_DISCOUNT, decimal RETURNQTY, decimal DAMAGEDQTY, decimal SR_DISCOUNT, decimal DA_DISCOUNT)
            {
                DsReport2.RptLoadPassSummaryRow row = (DsReport2.RptLoadPassSummaryRow) base.NewRow();
                row.ItemArray = new object[] { SKU_HIE_NAME, SKU_CODE, SKU_NAME, AREA_NAME, USER_NAME, RATE, ORDERQTY, SALEDQTY, SA_DISCOUNT, RETURNQTY, DAMAGEDQTY, SR_DISCOUNT, DA_DISCOUNT };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                DsReport2.RptLoadPassSummaryDataTable table = (DsReport2.RptLoadPassSummaryDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.RptLoadPassSummaryDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.RptLoadPassSummaryRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "RptLoadPassSummaryDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnSKU_HIE_NAME = new DataColumn("SKU_HIE_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_HIE_NAME);
                this.columnSKU_CODE = new DataColumn("SKU_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_CODE);
                this.columnSKU_NAME = new DataColumn("SKU_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_NAME);
                this.columnAREA_NAME = new DataColumn("AREA_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAREA_NAME);
                this.columnUSER_NAME = new DataColumn("USER_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUSER_NAME);
                this.columnRATE = new DataColumn("RATE", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnRATE);
                this.columnORDERQTY = new DataColumn("ORDERQTY", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnORDERQTY);
                this.columnSALEDQTY = new DataColumn("SALEDQTY", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnSALEDQTY);
                this.columnSA_DISCOUNT = new DataColumn("SA_DISCOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnSA_DISCOUNT);
                this.columnRETURNQTY = new DataColumn("RETURNQTY", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnRETURNQTY);
                this.columnDAMAGEDQTY = new DataColumn("DAMAGEDQTY", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnDAMAGEDQTY);
                this.columnSR_DISCOUNT = new DataColumn("SR_DISCOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnSR_DISCOUNT);
                this.columnDA_DISCOUNT = new DataColumn("DA_DISCOUNT", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnDA_DISCOUNT);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnSKU_HIE_NAME = base.Columns["SKU_HIE_NAME"];
                this.columnSKU_CODE = base.Columns["SKU_CODE"];
                this.columnSKU_NAME = base.Columns["SKU_NAME"];
                this.columnAREA_NAME = base.Columns["AREA_NAME"];
                this.columnUSER_NAME = base.Columns["USER_NAME"];
                this.columnRATE = base.Columns["RATE"];
                this.columnORDERQTY = base.Columns["ORDERQTY"];
                this.columnSALEDQTY = base.Columns["SALEDQTY"];
                this.columnSA_DISCOUNT = base.Columns["SA_DISCOUNT"];
                this.columnRETURNQTY = base.Columns["RETURNQTY"];
                this.columnDAMAGEDQTY = base.Columns["DAMAGEDQTY"];
                this.columnSR_DISCOUNT = base.Columns["SR_DISCOUNT"];
                this.columnDA_DISCOUNT = base.Columns["DA_DISCOUNT"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.RptLoadPassSummaryRow(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.RptLoadPassSummaryRow NewRptLoadPassSummaryRow()
            {
                return (DsReport2.RptLoadPassSummaryRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RptLoadPassSummaryRowChanged != null)
                {
                    this.RptLoadPassSummaryRowChanged(this, new DsReport2.RptLoadPassSummaryRowChangeEvent((DsReport2.RptLoadPassSummaryRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RptLoadPassSummaryRowChanging != null)
                {
                    this.RptLoadPassSummaryRowChanging(this, new DsReport2.RptLoadPassSummaryRowChangeEvent((DsReport2.RptLoadPassSummaryRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RptLoadPassSummaryRowDeleted != null)
                {
                    this.RptLoadPassSummaryRowDeleted(this, new DsReport2.RptLoadPassSummaryRowChangeEvent((DsReport2.RptLoadPassSummaryRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RptLoadPassSummaryRowDeleting != null)
                {
                    this.RptLoadPassSummaryRowDeleting(this, new DsReport2.RptLoadPassSummaryRowChangeEvent((DsReport2.RptLoadPassSummaryRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveRptLoadPassSummaryRow(DsReport2.RptLoadPassSummaryRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn AREA_NAMEColumn
            {
                get
                {
                    return this.columnAREA_NAME;
                }
            }

            [DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DA_DISCOUNTColumn
            {
                get
                {
                    return this.columnDA_DISCOUNT;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DAMAGEDQTYColumn
            {
                get
                {
                    return this.columnDAMAGEDQTY;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptLoadPassSummaryRow this[int index]
            {
                get
                {
                    return (DsReport2.RptLoadPassSummaryRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ORDERQTYColumn
            {
                get
                {
                    return this.columnORDERQTY;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn RATEColumn
            {
                get
                {
                    return this.columnRATE;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn RETURNQTYColumn
            {
                get
                {
                    return this.columnRETURNQTY;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SA_DISCOUNTColumn
            {
                get
                {
                    return this.columnSA_DISCOUNT;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SALEDQTYColumn
            {
                get
                {
                    return this.columnSALEDQTY;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SKU_CODEColumn
            {
                get
                {
                    return this.columnSKU_CODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_HIE_NAMEColumn
            {
                get
                {
                    return this.columnSKU_HIE_NAME;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SKU_NAMEColumn
            {
                get
                {
                    return this.columnSKU_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SR_DISCOUNTColumn
            {
                get
                {
                    return this.columnSR_DISCOUNT;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn USER_NAMEColumn
            {
                get
                {
                    return this.columnUSER_NAME;
                }
            }
        }

        public class RptLoadPassSummaryRow : DataRow
        {
            private DsReport2.RptLoadPassSummaryDataTable tableRptLoadPassSummary;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RptLoadPassSummaryRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRptLoadPassSummary = (DsReport2.RptLoadPassSummaryDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAREA_NAMENull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.AREA_NAMEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDA_DISCOUNTNull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.DA_DISCOUNTColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDAMAGEDQTYNull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.DAMAGEDQTYColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsORDERQTYNull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.ORDERQTYColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsRATENull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.RATEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsRETURNQTYNull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.RETURNQTYColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSA_DISCOUNTNull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.SA_DISCOUNTColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSALEDQTYNull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.SALEDQTYColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSKU_CODENull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.SKU_CODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSKU_HIE_NAMENull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.SKU_HIE_NAMEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSKU_NAMENull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.SKU_NAMEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSR_DISCOUNTNull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.SR_DISCOUNTColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsUSER_NAMENull()
            {
                return base.IsNull(this.tableRptLoadPassSummary.USER_NAMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAREA_NAMENull()
            {
                base[this.tableRptLoadPassSummary.AREA_NAMEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDA_DISCOUNTNull()
            {
                base[this.tableRptLoadPassSummary.DA_DISCOUNTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDAMAGEDQTYNull()
            {
                base[this.tableRptLoadPassSummary.DAMAGEDQTYColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetORDERQTYNull()
            {
                base[this.tableRptLoadPassSummary.ORDERQTYColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetRATENull()
            {
                base[this.tableRptLoadPassSummary.RATEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetRETURNQTYNull()
            {
                base[this.tableRptLoadPassSummary.RETURNQTYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSA_DISCOUNTNull()
            {
                base[this.tableRptLoadPassSummary.SA_DISCOUNTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSALEDQTYNull()
            {
                base[this.tableRptLoadPassSummary.SALEDQTYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSKU_CODENull()
            {
                base[this.tableRptLoadPassSummary.SKU_CODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSKU_HIE_NAMENull()
            {
                base[this.tableRptLoadPassSummary.SKU_HIE_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSKU_NAMENull()
            {
                base[this.tableRptLoadPassSummary.SKU_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSR_DISCOUNTNull()
            {
                base[this.tableRptLoadPassSummary.SR_DISCOUNTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUSER_NAMENull()
            {
                base[this.tableRptLoadPassSummary.USER_NAMEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string AREA_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadPassSummary.AREA_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'AREA_NAME' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.AREA_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal DA_DISCOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.DA_DISCOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DA_DISCOUNT' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.DA_DISCOUNTColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal DAMAGEDQTY
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.DAMAGEDQTYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DAMAGEDQTY' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.DAMAGEDQTYColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal ORDERQTY
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.ORDERQTYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ORDERQTY' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.ORDERQTYColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal RATE
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.RATEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'RATE' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.RATEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal RETURNQTY
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.RETURNQTYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'RETURNQTY' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.RETURNQTYColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal SA_DISCOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.SA_DISCOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SA_DISCOUNT' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.SA_DISCOUNTColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal SALEDQTY
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.SALEDQTYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SALEDQTY' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.SALEDQTYColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SKU_CODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadPassSummary.SKU_CODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_CODE' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.SKU_CODEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_HIE_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadPassSummary.SKU_HIE_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_HIE_NAME' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.SKU_HIE_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SKU_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadPassSummary.SKU_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_NAME' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.SKU_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal SR_DISCOUNT
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptLoadPassSummary.SR_DISCOUNTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SR_DISCOUNT' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.SR_DISCOUNTColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string USER_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptLoadPassSummary.USER_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'USER_NAME' in table 'RptLoadPassSummary' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptLoadPassSummary.USER_NAMEColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class RptLoadPassSummaryRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.RptLoadPassSummaryRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RptLoadPassSummaryRowChangeEvent(DsReport2.RptLoadPassSummaryRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptLoadPassSummaryRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void RptLoadPassSummaryRowChangeEventHandler(object sender, DsReport2.RptLoadPassSummaryRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class RptPrintDSRDataTable : DataTable, IEnumerable
        {
            private DataColumn columnADDRESS;
            private DataColumn columncustomer_code;
            private DataColumn columncustomer_name;
            private DataColumn columnGrossAmount;
            private DataColumn columnORDERBOOKER;
            private DataColumn columnorderNO;
            private DataColumn columnqty;
            private DataColumn columnReturned;
            private DataColumn columnsku_code;
            private DataColumn columnSKU_HIE_NAME;
            private DataColumn columnSKU_NAME;
            private DataColumn columnSLASH_DESC;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptPrintDSRRowChangeEventHandler RptPrintDSRRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptPrintDSRRowChangeEventHandler RptPrintDSRRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptPrintDSRRowChangeEventHandler RptPrintDSRRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptPrintDSRRowChangeEventHandler RptPrintDSRRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RptPrintDSRDataTable()
            {
                base.TableName = "RptPrintDSR";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RptPrintDSRDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected RptPrintDSRDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddRptPrintDSRRow(DsReport2.RptPrintDSRRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.RptPrintDSRRow AddRptPrintDSRRow(string ORDERBOOKER, long orderNO, string customer_code, string ADDRESS, string customer_name, string SLASH_DESC, string SKU_HIE_NAME, string SKU_NAME, string sku_code, int qty, string Returned, decimal GrossAmount)
            {
                DsReport2.RptPrintDSRRow row = (DsReport2.RptPrintDSRRow) base.NewRow();
                row.ItemArray = new object[] { ORDERBOOKER, orderNO, customer_code, ADDRESS, customer_name, SLASH_DESC, SKU_HIE_NAME, SKU_NAME, sku_code, qty, Returned, GrossAmount };
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DsReport2.RptPrintDSRDataTable table = (DsReport2.RptPrintDSRDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.RptPrintDSRDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.RptPrintDSRRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "RptPrintDSRDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnORDERBOOKER = new DataColumn("ORDERBOOKER", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnORDERBOOKER);
                this.columnorderNO = new DataColumn("orderNO", typeof(long), null, MappingType.Element);
                base.Columns.Add(this.columnorderNO);
                this.columncustomer_code = new DataColumn("customer_code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncustomer_code);
                this.columnADDRESS = new DataColumn("ADDRESS", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnADDRESS);
                this.columncustomer_name = new DataColumn("customer_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncustomer_name);
                this.columnSLASH_DESC = new DataColumn("SLASH_DESC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSLASH_DESC);
                this.columnSKU_HIE_NAME = new DataColumn("SKU_HIE_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_HIE_NAME);
                this.columnSKU_NAME = new DataColumn("SKU_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_NAME);
                this.columnsku_code = new DataColumn("sku_code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnsku_code);
                this.columnqty = new DataColumn("qty", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnqty);
                this.columnReturned = new DataColumn("Returned", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnReturned);
                this.columnGrossAmount = new DataColumn("GrossAmount", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnGrossAmount);
                this.columnORDERBOOKER.ReadOnly = true;
                this.columnORDERBOOKER.MaxLength = 30;
                this.columnorderNO.ReadOnly = true;
                this.columncustomer_code.ReadOnly = true;
                this.columncustomer_code.MaxLength = 0x19;
                this.columnADDRESS.ReadOnly = true;
                this.columnADDRESS.MaxLength = 250;
                this.columncustomer_name.ReadOnly = true;
                this.columncustomer_name.MaxLength = 100;
                this.columnSLASH_DESC.ReadOnly = true;
                this.columnSLASH_DESC.MaxLength = 200;
                this.columnSKU_HIE_NAME.ReadOnly = true;
                this.columnSKU_HIE_NAME.MaxLength = 60;
                this.columnSKU_NAME.ReadOnly = true;
                this.columnSKU_NAME.MaxLength = 100;
                this.columnsku_code.ReadOnly = true;
                this.columnsku_code.MaxLength = 15;
                this.columnqty.ReadOnly = true;
                this.columnGrossAmount.ReadOnly = true;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnORDERBOOKER = base.Columns["ORDERBOOKER"];
                this.columnorderNO = base.Columns["orderNO"];
                this.columncustomer_code = base.Columns["customer_code"];
                this.columnADDRESS = base.Columns["ADDRESS"];
                this.columncustomer_name = base.Columns["customer_name"];
                this.columnSLASH_DESC = base.Columns["SLASH_DESC"];
                this.columnSKU_HIE_NAME = base.Columns["SKU_HIE_NAME"];
                this.columnSKU_NAME = base.Columns["SKU_NAME"];
                this.columnsku_code = base.Columns["sku_code"];
                this.columnqty = base.Columns["qty"];
                this.columnReturned = base.Columns["Returned"];
                this.columnGrossAmount = base.Columns["GrossAmount"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.RptPrintDSRRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptPrintDSRRow NewRptPrintDSRRow()
            {
                return (DsReport2.RptPrintDSRRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RptPrintDSRRowChanged != null)
                {
                    this.RptPrintDSRRowChanged(this, new DsReport2.RptPrintDSRRowChangeEvent((DsReport2.RptPrintDSRRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RptPrintDSRRowChanging != null)
                {
                    this.RptPrintDSRRowChanging(this, new DsReport2.RptPrintDSRRowChangeEvent((DsReport2.RptPrintDSRRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RptPrintDSRRowDeleted != null)
                {
                    this.RptPrintDSRRowDeleted(this, new DsReport2.RptPrintDSRRowChangeEvent((DsReport2.RptPrintDSRRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RptPrintDSRRowDeleting != null)
                {
                    this.RptPrintDSRRowDeleting(this, new DsReport2.RptPrintDSRRowChangeEvent((DsReport2.RptPrintDSRRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveRptPrintDSRRow(DsReport2.RptPrintDSRRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ADDRESSColumn
            {
                get
                {
                    return this.columnADDRESS;
                }
            }

            [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn customer_codeColumn
            {
                get
                {
                    return this.columncustomer_code;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn customer_nameColumn
            {
                get
                {
                    return this.columncustomer_name;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn GrossAmountColumn
            {
                get
                {
                    return this.columnGrossAmount;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptPrintDSRRow this[int index]
            {
                get
                {
                    return (DsReport2.RptPrintDSRRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ORDERBOOKERColumn
            {
                get
                {
                    return this.columnORDERBOOKER;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn orderNOColumn
            {
                get
                {
                    return this.columnorderNO;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn qtyColumn
            {
                get
                {
                    return this.columnqty;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ReturnedColumn
            {
                get
                {
                    return this.columnReturned;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn sku_codeColumn
            {
                get
                {
                    return this.columnsku_code;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_HIE_NAMEColumn
            {
                get
                {
                    return this.columnSKU_HIE_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_NAMEColumn
            {
                get
                {
                    return this.columnSKU_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SLASH_DESCColumn
            {
                get
                {
                    return this.columnSLASH_DESC;
                }
            }
        }

        public class RptPrintDSRRow : DataRow
        {
            private DsReport2.RptPrintDSRDataTable tableRptPrintDSR;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal RptPrintDSRRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRptPrintDSR = (DsReport2.RptPrintDSRDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsADDRESSNull()
            {
                return base.IsNull(this.tableRptPrintDSR.ADDRESSColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool Iscustomer_codeNull()
            {
                return base.IsNull(this.tableRptPrintDSR.customer_codeColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Iscustomer_nameNull()
            {
                return base.IsNull(this.tableRptPrintDSR.customer_nameColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGrossAmountNull()
            {
                return base.IsNull(this.tableRptPrintDSR.GrossAmountColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsORDERBOOKERNull()
            {
                return base.IsNull(this.tableRptPrintDSR.ORDERBOOKERColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsorderNONull()
            {
                return base.IsNull(this.tableRptPrintDSR.orderNOColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsqtyNull()
            {
                return base.IsNull(this.tableRptPrintDSR.qtyColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsReturnedNull()
            {
                return base.IsNull(this.tableRptPrintDSR.ReturnedColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Issku_codeNull()
            {
                return base.IsNull(this.tableRptPrintDSR.sku_codeColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSKU_HIE_NAMENull()
            {
                return base.IsNull(this.tableRptPrintDSR.SKU_HIE_NAMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSKU_NAMENull()
            {
                return base.IsNull(this.tableRptPrintDSR.SKU_NAMEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSLASH_DESCNull()
            {
                return base.IsNull(this.tableRptPrintDSR.SLASH_DESCColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetADDRESSNull()
            {
                base[this.tableRptPrintDSR.ADDRESSColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setcustomer_codeNull()
            {
                base[this.tableRptPrintDSR.customer_codeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setcustomer_nameNull()
            {
                base[this.tableRptPrintDSR.customer_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGrossAmountNull()
            {
                base[this.tableRptPrintDSR.GrossAmountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetORDERBOOKERNull()
            {
                base[this.tableRptPrintDSR.ORDERBOOKERColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetorderNONull()
            {
                base[this.tableRptPrintDSR.orderNOColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetqtyNull()
            {
                base[this.tableRptPrintDSR.qtyColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetReturnedNull()
            {
                base[this.tableRptPrintDSR.ReturnedColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void Setsku_codeNull()
            {
                base[this.tableRptPrintDSR.sku_codeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSKU_HIE_NAMENull()
            {
                base[this.tableRptPrintDSR.SKU_HIE_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSKU_NAMENull()
            {
                base[this.tableRptPrintDSR.SKU_NAMEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSLASH_DESCNull()
            {
                base[this.tableRptPrintDSR.SLASH_DESCColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ADDRESS
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.ADDRESSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ADDRESS' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.ADDRESSColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string customer_code
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.customer_codeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'customer_code' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.customer_codeColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string customer_name
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.customer_nameColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'customer_name' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.customer_nameColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal GrossAmount
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableRptPrintDSR.GrossAmountColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'GrossAmount' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptPrintDSR.GrossAmountColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string ORDERBOOKER
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.ORDERBOOKERColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ORDERBOOKER' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.ORDERBOOKERColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public long orderNO
            {
                get
                {
                    long num;
                    try
                    {
                        num = (long) base[this.tableRptPrintDSR.orderNOColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'orderNO' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptPrintDSR.orderNOColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int qty
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableRptPrintDSR.qtyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'qty' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptPrintDSR.qtyColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Returned
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.ReturnedColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Returned' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.ReturnedColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string sku_code
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.sku_codeColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'sku_code' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.sku_codeColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_HIE_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.SKU_HIE_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_HIE_NAME' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.SKU_HIE_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.SKU_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_NAME' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.SKU_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SLASH_DESC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptPrintDSR.SLASH_DESCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SLASH_DESC' in table 'RptPrintDSR' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptPrintDSR.SLASH_DESCColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class RptPrintDSRRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.RptPrintDSRRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RptPrintDSRRowChangeEvent(DsReport2.RptPrintDSRRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptPrintDSRRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void RptPrintDSRRowChangeEventHandler(object sender, DsReport2.RptPrintDSRRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class RptSKUWiseBookingVsExecutionDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDOCUMENT_DATE;
            private DataColumn columnExecutedOrderSKUS;
            private DataColumn columnNOofOrderSKUS;
            private DataColumn columnPACKSIZE;
            private DataColumn columnSKU_CODE;
            private DataColumn columnSKU_HIE_NAME;
            private DataColumn columnSKU_ID;
            private DataColumn columnSKU_NAME;
            private DataColumn columnTotalValueOfExecutedOrderSKUS;
            private DataColumn columnTotalValueofOrderSKUS;
            private DataColumn columnUNITS_IN_CASE;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptSKUWiseBookingVsExecutionRowChangeEventHandler RptSKUWiseBookingVsExecutionRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptSKUWiseBookingVsExecutionRowChangeEventHandler RptSKUWiseBookingVsExecutionRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptSKUWiseBookingVsExecutionRowChangeEventHandler RptSKUWiseBookingVsExecutionRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.RptSKUWiseBookingVsExecutionRowChangeEventHandler RptSKUWiseBookingVsExecutionRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RptSKUWiseBookingVsExecutionDataTable()
            {
                base.TableName = "RptSKUWiseBookingVsExecution";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RptSKUWiseBookingVsExecutionDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected RptSKUWiseBookingVsExecutionDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddRptSKUWiseBookingVsExecutionRow(DsReport2.RptSKUWiseBookingVsExecutionRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.RptSKUWiseBookingVsExecutionRow AddRptSKUWiseBookingVsExecutionRow(DateTime DOCUMENT_DATE, string SKU_CODE, string SKU_NAME, string PACKSIZE, short UNITS_IN_CASE, string SKU_HIE_NAME, int NOofOrderSKUS, int TotalValueofOrderSKUS, int ExecutedOrderSKUS, int TotalValueOfExecutedOrderSKUS)
            {
                DsReport2.RptSKUWiseBookingVsExecutionRow row = (DsReport2.RptSKUWiseBookingVsExecutionRow) base.NewRow();
                object[] objArray2 = new object[11];
                objArray2[0] = DOCUMENT_DATE;
                objArray2[2] = SKU_CODE;
                objArray2[3] = SKU_NAME;
                objArray2[4] = PACKSIZE;
                objArray2[5] = UNITS_IN_CASE;
                objArray2[6] = SKU_HIE_NAME;
                objArray2[7] = NOofOrderSKUS;
                objArray2[8] = TotalValueofOrderSKUS;
                objArray2[9] = ExecutedOrderSKUS;
                objArray2[10] = TotalValueOfExecutedOrderSKUS;
                object[] objArray = objArray2;
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                DsReport2.RptSKUWiseBookingVsExecutionDataTable table = (DsReport2.RptSKUWiseBookingVsExecutionDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.RptSKUWiseBookingVsExecutionDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.RptSKUWiseBookingVsExecutionRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "RptSKUWiseBookingVsExecutionDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnDOCUMENT_DATE = new DataColumn("DOCUMENT_DATE", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDOCUMENT_DATE);
                this.columnSKU_ID = new DataColumn("SKU_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_ID);
                this.columnSKU_CODE = new DataColumn("SKU_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_CODE);
                this.columnSKU_NAME = new DataColumn("SKU_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_NAME);
                this.columnPACKSIZE = new DataColumn("PACKSIZE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPACKSIZE);
                this.columnUNITS_IN_CASE = new DataColumn("UNITS_IN_CASE", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnUNITS_IN_CASE);
                this.columnSKU_HIE_NAME = new DataColumn("SKU_HIE_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_HIE_NAME);
                this.columnNOofOrderSKUS = new DataColumn("NOofOrderSKUS", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnNOofOrderSKUS);
                this.columnTotalValueofOrderSKUS = new DataColumn("TotalValueofOrderSKUS", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnTotalValueofOrderSKUS);
                this.columnExecutedOrderSKUS = new DataColumn("ExecutedOrderSKUS", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnExecutedOrderSKUS);
                this.columnTotalValueOfExecutedOrderSKUS = new DataColumn("TotalValueOfExecutedOrderSKUS", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnTotalValueOfExecutedOrderSKUS);
                this.columnSKU_ID.AutoIncrement = true;
                this.columnSKU_ID.AutoIncrementSeed = -1L;
                this.columnSKU_ID.AutoIncrementStep = -1L;
                this.columnSKU_ID.AllowDBNull = false;
                this.columnSKU_ID.ReadOnly = true;
                this.columnSKU_CODE.AllowDBNull = false;
                this.columnSKU_CODE.MaxLength = 15;
                this.columnSKU_NAME.AllowDBNull = false;
                this.columnSKU_NAME.MaxLength = 100;
                this.columnPACKSIZE.MaxLength = 100;
                this.columnUNITS_IN_CASE.AllowDBNull = false;
                this.columnSKU_HIE_NAME.MaxLength = 60;
                this.columnNOofOrderSKUS.ReadOnly = true;
                this.columnTotalValueofOrderSKUS.ReadOnly = true;
                this.columnExecutedOrderSKUS.ReadOnly = true;
                this.columnTotalValueOfExecutedOrderSKUS.ReadOnly = true;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnDOCUMENT_DATE = base.Columns["DOCUMENT_DATE"];
                this.columnSKU_ID = base.Columns["SKU_ID"];
                this.columnSKU_CODE = base.Columns["SKU_CODE"];
                this.columnSKU_NAME = base.Columns["SKU_NAME"];
                this.columnPACKSIZE = base.Columns["PACKSIZE"];
                this.columnUNITS_IN_CASE = base.Columns["UNITS_IN_CASE"];
                this.columnSKU_HIE_NAME = base.Columns["SKU_HIE_NAME"];
                this.columnNOofOrderSKUS = base.Columns["NOofOrderSKUS"];
                this.columnTotalValueofOrderSKUS = base.Columns["TotalValueofOrderSKUS"];
                this.columnExecutedOrderSKUS = base.Columns["ExecutedOrderSKUS"];
                this.columnTotalValueOfExecutedOrderSKUS = base.Columns["TotalValueOfExecutedOrderSKUS"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.RptSKUWiseBookingVsExecutionRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptSKUWiseBookingVsExecutionRow NewRptSKUWiseBookingVsExecutionRow()
            {
                return (DsReport2.RptSKUWiseBookingVsExecutionRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RptSKUWiseBookingVsExecutionRowChanged != null)
                {
                    this.RptSKUWiseBookingVsExecutionRowChanged(this, new DsReport2.RptSKUWiseBookingVsExecutionRowChangeEvent((DsReport2.RptSKUWiseBookingVsExecutionRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RptSKUWiseBookingVsExecutionRowChanging != null)
                {
                    this.RptSKUWiseBookingVsExecutionRowChanging(this, new DsReport2.RptSKUWiseBookingVsExecutionRowChangeEvent((DsReport2.RptSKUWiseBookingVsExecutionRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RptSKUWiseBookingVsExecutionRowDeleted != null)
                {
                    this.RptSKUWiseBookingVsExecutionRowDeleted(this, new DsReport2.RptSKUWiseBookingVsExecutionRowChangeEvent((DsReport2.RptSKUWiseBookingVsExecutionRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RptSKUWiseBookingVsExecutionRowDeleting != null)
                {
                    this.RptSKUWiseBookingVsExecutionRowDeleting(this, new DsReport2.RptSKUWiseBookingVsExecutionRowChangeEvent((DsReport2.RptSKUWiseBookingVsExecutionRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveRptSKUWiseBookingVsExecutionRow(DsReport2.RptSKUWiseBookingVsExecutionRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DOCUMENT_DATEColumn
            {
                get
                {
                    return this.columnDOCUMENT_DATE;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ExecutedOrderSKUSColumn
            {
                get
                {
                    return this.columnExecutedOrderSKUS;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptSKUWiseBookingVsExecutionRow this[int index]
            {
                get
                {
                    return (DsReport2.RptSKUWiseBookingVsExecutionRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn NOofOrderSKUSColumn
            {
                get
                {
                    return this.columnNOofOrderSKUS;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PACKSIZEColumn
            {
                get
                {
                    return this.columnPACKSIZE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_CODEColumn
            {
                get
                {
                    return this.columnSKU_CODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_HIE_NAMEColumn
            {
                get
                {
                    return this.columnSKU_HIE_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_IDColumn
            {
                get
                {
                    return this.columnSKU_ID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_NAMEColumn
            {
                get
                {
                    return this.columnSKU_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TotalValueOfExecutedOrderSKUSColumn
            {
                get
                {
                    return this.columnTotalValueOfExecutedOrderSKUS;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn TotalValueofOrderSKUSColumn
            {
                get
                {
                    return this.columnTotalValueofOrderSKUS;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UNITS_IN_CASEColumn
            {
                get
                {
                    return this.columnUNITS_IN_CASE;
                }
            }
        }

        public class RptSKUWiseBookingVsExecutionRow : DataRow
        {
            private DsReport2.RptSKUWiseBookingVsExecutionDataTable tableRptSKUWiseBookingVsExecution;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal RptSKUWiseBookingVsExecutionRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRptSKUWiseBookingVsExecution = (DsReport2.RptSKUWiseBookingVsExecutionDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDOCUMENT_DATENull()
            {
                return base.IsNull(this.tableRptSKUWiseBookingVsExecution.DOCUMENT_DATEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsExecutedOrderSKUSNull()
            {
                return base.IsNull(this.tableRptSKUWiseBookingVsExecution.ExecutedOrderSKUSColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsNOofOrderSKUSNull()
            {
                return base.IsNull(this.tableRptSKUWiseBookingVsExecution.NOofOrderSKUSColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsPACKSIZENull()
            {
                return base.IsNull(this.tableRptSKUWiseBookingVsExecution.PACKSIZEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSKU_HIE_NAMENull()
            {
                return base.IsNull(this.tableRptSKUWiseBookingVsExecution.SKU_HIE_NAMEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsTotalValueOfExecutedOrderSKUSNull()
            {
                return base.IsNull(this.tableRptSKUWiseBookingVsExecution.TotalValueOfExecutedOrderSKUSColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTotalValueofOrderSKUSNull()
            {
                return base.IsNull(this.tableRptSKUWiseBookingVsExecution.TotalValueofOrderSKUSColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDOCUMENT_DATENull()
            {
                base[this.tableRptSKUWiseBookingVsExecution.DOCUMENT_DATEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetExecutedOrderSKUSNull()
            {
                base[this.tableRptSKUWiseBookingVsExecution.ExecutedOrderSKUSColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetNOofOrderSKUSNull()
            {
                base[this.tableRptSKUWiseBookingVsExecution.NOofOrderSKUSColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetPACKSIZENull()
            {
                base[this.tableRptSKUWiseBookingVsExecution.PACKSIZEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSKU_HIE_NAMENull()
            {
                base[this.tableRptSKUWiseBookingVsExecution.SKU_HIE_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTotalValueOfExecutedOrderSKUSNull()
            {
                base[this.tableRptSKUWiseBookingVsExecution.TotalValueOfExecutedOrderSKUSColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetTotalValueofOrderSKUSNull()
            {
                base[this.tableRptSKUWiseBookingVsExecution.TotalValueofOrderSKUSColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DateTime DOCUMENT_DATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tableRptSKUWiseBookingVsExecution.DOCUMENT_DATEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DOCUMENT_DATE' in table 'RptSKUWiseBookingVsExecution' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.DOCUMENT_DATEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ExecutedOrderSKUS
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableRptSKUWiseBookingVsExecution.ExecutedOrderSKUSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ExecutedOrderSKUS' in table 'RptSKUWiseBookingVsExecution' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.ExecutedOrderSKUSColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int NOofOrderSKUS
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableRptSKUWiseBookingVsExecution.NOofOrderSKUSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'NOofOrderSKUS' in table 'RptSKUWiseBookingVsExecution' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.NOofOrderSKUSColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PACKSIZE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptSKUWiseBookingVsExecution.PACKSIZEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PACKSIZE' in table 'RptSKUWiseBookingVsExecution' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.PACKSIZEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_CODE
            {
                get
                {
                    return (string) base[this.tableRptSKUWiseBookingVsExecution.SKU_CODEColumn];
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.SKU_CODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SKU_HIE_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableRptSKUWiseBookingVsExecution.SKU_HIE_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_HIE_NAME' in table 'RptSKUWiseBookingVsExecution' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.SKU_HIE_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int SKU_ID
            {
                get
                {
                    return (int) base[this.tableRptSKUWiseBookingVsExecution.SKU_IDColumn];
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.SKU_IDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_NAME
            {
                get
                {
                    return (string) base[this.tableRptSKUWiseBookingVsExecution.SKU_NAMEColumn];
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.SKU_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int TotalValueOfExecutedOrderSKUS
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableRptSKUWiseBookingVsExecution.TotalValueOfExecutedOrderSKUSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'TotalValueOfExecutedOrderSKUS' in table 'RptSKUWiseBookingVsExecution' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.TotalValueOfExecutedOrderSKUSColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int TotalValueofOrderSKUS
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableRptSKUWiseBookingVsExecution.TotalValueofOrderSKUSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'TotalValueofOrderSKUS' in table 'RptSKUWiseBookingVsExecution' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.TotalValueofOrderSKUSColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short UNITS_IN_CASE
            {
                get
                {
                    return (short) base[this.tableRptSKUWiseBookingVsExecution.UNITS_IN_CASEColumn];
                }
                set
                {
                    base[this.tableRptSKUWiseBookingVsExecution.UNITS_IN_CASEColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class RptSKUWiseBookingVsExecutionRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.RptSKUWiseBookingVsExecutionRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RptSKUWiseBookingVsExecutionRowChangeEvent(DsReport2.RptSKUWiseBookingVsExecutionRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.RptSKUWiseBookingVsExecutionRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void RptSKUWiseBookingVsExecutionRowChangeEventHandler(object sender, DsReport2.RptSKUWiseBookingVsExecutionRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class rptStockValuationDetailDataTable : DataTable, IEnumerable
        {
            private DataColumn columnClosingStock;
            private DataColumn columnDISTRIBUTOR_NAME;
            private DataColumn columnDISTRIBUTOR_PRICE;
            private DataColumn columnPACKSIZE;
            private DataColumn columnSKU_CODE;
            private DataColumn columnSKU_HIE_ID;
            private DataColumn columnSKU_HIE_NAME;
            private DataColumn columnSKU_ID;
            private DataColumn columnSKU_NAME;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.rptStockValuationDetailRowChangeEventHandler rptStockValuationDetailRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.rptStockValuationDetailRowChangeEventHandler rptStockValuationDetailRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.rptStockValuationDetailRowChangeEventHandler rptStockValuationDetailRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.rptStockValuationDetailRowChangeEventHandler rptStockValuationDetailRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public rptStockValuationDetailDataTable()
            {
                base.TableName = "rptStockValuationDetail";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal rptStockValuationDetailDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected rptStockValuationDetailDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddrptStockValuationDetailRow(DsReport2.rptStockValuationDetailRow row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.rptStockValuationDetailRow AddrptStockValuationDetailRow(string DISTRIBUTOR_NAME, string SKU_CODE, string SKU_NAME, string PACKSIZE, string SKU_HIE_NAME, int ClosingStock, decimal DISTRIBUTOR_PRICE)
            {
                DsReport2.rptStockValuationDetailRow row = (DsReport2.rptStockValuationDetailRow) base.NewRow();
                object[] objArray2 = new object[9];
                objArray2[1] = DISTRIBUTOR_NAME;
                objArray2[2] = SKU_CODE;
                objArray2[3] = SKU_NAME;
                objArray2[4] = PACKSIZE;
                objArray2[6] = SKU_HIE_NAME;
                objArray2[7] = ClosingStock;
                objArray2[8] = DISTRIBUTOR_PRICE;
                object[] objArray = objArray2;
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DsReport2.rptStockValuationDetailDataTable table = (DsReport2.rptStockValuationDetailDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.rptStockValuationDetailDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.rptStockValuationDetailRow);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "rptStockValuationDetailDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnSKU_ID = new DataColumn("SKU_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_ID);
                this.columnDISTRIBUTOR_NAME = new DataColumn("DISTRIBUTOR_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDISTRIBUTOR_NAME);
                this.columnSKU_CODE = new DataColumn("SKU_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_CODE);
                this.columnSKU_NAME = new DataColumn("SKU_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_NAME);
                this.columnPACKSIZE = new DataColumn("PACKSIZE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPACKSIZE);
                this.columnSKU_HIE_ID = new DataColumn("SKU_HIE_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_HIE_ID);
                this.columnSKU_HIE_NAME = new DataColumn("SKU_HIE_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_HIE_NAME);
                this.columnClosingStock = new DataColumn("ClosingStock", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnClosingStock);
                this.columnDISTRIBUTOR_PRICE = new DataColumn("DISTRIBUTOR_PRICE", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnDISTRIBUTOR_PRICE);
                this.columnSKU_ID.AutoIncrement = true;
                this.columnSKU_ID.AutoIncrementSeed = -1L;
                this.columnSKU_ID.AutoIncrementStep = -1L;
                this.columnSKU_ID.AllowDBNull = false;
                this.columnSKU_ID.ReadOnly = true;
                this.columnDISTRIBUTOR_NAME.MaxLength = 100;
                this.columnSKU_CODE.AllowDBNull = false;
                this.columnSKU_CODE.MaxLength = 15;
                this.columnSKU_NAME.AllowDBNull = false;
                this.columnSKU_NAME.MaxLength = 100;
                this.columnPACKSIZE.MaxLength = 100;
                this.columnSKU_HIE_ID.AutoIncrement = true;
                this.columnSKU_HIE_ID.AutoIncrementSeed = -1L;
                this.columnSKU_HIE_ID.AutoIncrementStep = -1L;
                this.columnSKU_HIE_ID.AllowDBNull = false;
                this.columnSKU_HIE_ID.ReadOnly = true;
                this.columnSKU_HIE_NAME.MaxLength = 60;
                this.columnClosingStock.ReadOnly = true;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnSKU_ID = base.Columns["SKU_ID"];
                this.columnDISTRIBUTOR_NAME = base.Columns["DISTRIBUTOR_NAME"];
                this.columnSKU_CODE = base.Columns["SKU_CODE"];
                this.columnSKU_NAME = base.Columns["SKU_NAME"];
                this.columnPACKSIZE = base.Columns["PACKSIZE"];
                this.columnSKU_HIE_ID = base.Columns["SKU_HIE_ID"];
                this.columnSKU_HIE_NAME = base.Columns["SKU_HIE_NAME"];
                this.columnClosingStock = base.Columns["ClosingStock"];
                this.columnDISTRIBUTOR_PRICE = base.Columns["DISTRIBUTOR_PRICE"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.rptStockValuationDetailRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.rptStockValuationDetailRow NewrptStockValuationDetailRow()
            {
                return (DsReport2.rptStockValuationDetailRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.rptStockValuationDetailRowChanged != null)
                {
                    this.rptStockValuationDetailRowChanged(this, new DsReport2.rptStockValuationDetailRowChangeEvent((DsReport2.rptStockValuationDetailRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.rptStockValuationDetailRowChanging != null)
                {
                    this.rptStockValuationDetailRowChanging(this, new DsReport2.rptStockValuationDetailRowChangeEvent((DsReport2.rptStockValuationDetailRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.rptStockValuationDetailRowDeleted != null)
                {
                    this.rptStockValuationDetailRowDeleted(this, new DsReport2.rptStockValuationDetailRowChangeEvent((DsReport2.rptStockValuationDetailRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.rptStockValuationDetailRowDeleting != null)
                {
                    this.rptStockValuationDetailRowDeleting(this, new DsReport2.rptStockValuationDetailRowChangeEvent((DsReport2.rptStockValuationDetailRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoverptStockValuationDetailRow(DsReport2.rptStockValuationDetailRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn ClosingStockColumn
            {
                get
                {
                    return this.columnClosingStock;
                }
            }

            [Browsable(false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DISTRIBUTOR_NAMEColumn
            {
                get
                {
                    return this.columnDISTRIBUTOR_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DISTRIBUTOR_PRICEColumn
            {
                get
                {
                    return this.columnDISTRIBUTOR_PRICE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.rptStockValuationDetailRow this[int index]
            {
                get
                {
                    return (DsReport2.rptStockValuationDetailRow) base.Rows[index];
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn PACKSIZEColumn
            {
                get
                {
                    return this.columnPACKSIZE;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SKU_CODEColumn
            {
                get
                {
                    return this.columnSKU_CODE;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SKU_HIE_IDColumn
            {
                get
                {
                    return this.columnSKU_HIE_ID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_HIE_NAMEColumn
            {
                get
                {
                    return this.columnSKU_HIE_NAME;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SKU_IDColumn
            {
                get
                {
                    return this.columnSKU_ID;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn SKU_NAMEColumn
            {
                get
                {
                    return this.columnSKU_NAME;
                }
            }
        }

        public class rptStockValuationDetailRow : DataRow
        {
            private DsReport2.rptStockValuationDetailDataTable tablerptStockValuationDetail;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal rptStockValuationDetailRow(DataRowBuilder rb) : base(rb)
            {
                this.tablerptStockValuationDetail = (DsReport2.rptStockValuationDetailDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsClosingStockNull()
            {
                return base.IsNull(this.tablerptStockValuationDetail.ClosingStockColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDISTRIBUTOR_NAMENull()
            {
                return base.IsNull(this.tablerptStockValuationDetail.DISTRIBUTOR_NAMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDISTRIBUTOR_PRICENull()
            {
                return base.IsNull(this.tablerptStockValuationDetail.DISTRIBUTOR_PRICEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsPACKSIZENull()
            {
                return base.IsNull(this.tablerptStockValuationDetail.PACKSIZEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSKU_HIE_NAMENull()
            {
                return base.IsNull(this.tablerptStockValuationDetail.SKU_HIE_NAMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClosingStockNull()
            {
                base[this.tablerptStockValuationDetail.ClosingStockColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDISTRIBUTOR_NAMENull()
            {
                base[this.tablerptStockValuationDetail.DISTRIBUTOR_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDISTRIBUTOR_PRICENull()
            {
                base[this.tablerptStockValuationDetail.DISTRIBUTOR_PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPACKSIZENull()
            {
                base[this.tablerptStockValuationDetail.PACKSIZEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetSKU_HIE_NAMENull()
            {
                base[this.tablerptStockValuationDetail.SKU_HIE_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ClosingStock
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablerptStockValuationDetail.ClosingStockColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ClosingStock' in table 'rptStockValuationDetail' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablerptStockValuationDetail.ClosingStockColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string DISTRIBUTOR_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablerptStockValuationDetail.DISTRIBUTOR_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DISTRIBUTOR_NAME' in table 'rptStockValuationDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablerptStockValuationDetail.DISTRIBUTOR_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal DISTRIBUTOR_PRICE
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tablerptStockValuationDetail.DISTRIBUTOR_PRICEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DISTRIBUTOR_PRICE' in table 'rptStockValuationDetail' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablerptStockValuationDetail.DISTRIBUTOR_PRICEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PACKSIZE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablerptStockValuationDetail.PACKSIZEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PACKSIZE' in table 'rptStockValuationDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablerptStockValuationDetail.PACKSIZEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_CODE
            {
                get
                {
                    return (string) base[this.tablerptStockValuationDetail.SKU_CODEColumn];
                }
                set
                {
                    base[this.tablerptStockValuationDetail.SKU_CODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int SKU_HIE_ID
            {
                get
                {
                    return (int) base[this.tablerptStockValuationDetail.SKU_HIE_IDColumn];
                }
                set
                {
                    base[this.tablerptStockValuationDetail.SKU_HIE_IDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SKU_HIE_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablerptStockValuationDetail.SKU_HIE_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_HIE_NAME' in table 'rptStockValuationDetail' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablerptStockValuationDetail.SKU_HIE_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int SKU_ID
            {
                get
                {
                    return (int) base[this.tablerptStockValuationDetail.SKU_IDColumn];
                }
                set
                {
                    base[this.tablerptStockValuationDetail.SKU_IDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SKU_NAME
            {
                get
                {
                    return (string) base[this.tablerptStockValuationDetail.SKU_NAMEColumn];
                }
                set
                {
                    base[this.tablerptStockValuationDetail.SKU_NAMEColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class rptStockValuationDetailRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.rptStockValuationDetailRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public rptStockValuationDetailRowChangeEvent(DsReport2.rptStockValuationDetailRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.rptStockValuationDetailRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void rptStockValuationDetailRowChangeEventHandler(object sender, DsReport2.rptStockValuationDetailRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class uspGetStockValuationDataTable : DataTable, IEnumerable
        {
            private DataColumn columnClosingStock;
            private DataColumn columnDISTRIBUTOR_NAME;
            private DataColumn columnDISTRIBUTOR_PRICE;
            private DataColumn columnPACKSIZE;
            private DataColumn columnSKU_CODE;
            private DataColumn columnSKU_HIE_ID;
            private DataColumn columnSKU_HIE_NAME;
            private DataColumn columnSKU_ID;
            private DataColumn columnSKU_NAME;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.uspGetStockValuationRowChangeEventHandler uspGetStockValuationRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.uspGetStockValuationRowChangeEventHandler uspGetStockValuationRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.uspGetStockValuationRowChangeEventHandler uspGetStockValuationRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DsReport2.uspGetStockValuationRowChangeEventHandler uspGetStockValuationRowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public uspGetStockValuationDataTable()
            {
                base.TableName = "uspGetStockValuation";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal uspGetStockValuationDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected uspGetStockValuationDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AdduspGetStockValuationRow(DsReport2.uspGetStockValuationRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.uspGetStockValuationRow AdduspGetStockValuationRow(string DISTRIBUTOR_NAME, string SKU_CODE, string SKU_NAME, string PACKSIZE, string SKU_HIE_NAME, int ClosingStock, decimal DISTRIBUTOR_PRICE)
            {
                DsReport2.uspGetStockValuationRow row = (DsReport2.uspGetStockValuationRow) base.NewRow();
                object[] objArray2 = new object[9];
                objArray2[1] = DISTRIBUTOR_NAME;
                objArray2[2] = SKU_CODE;
                objArray2[3] = SKU_NAME;
                objArray2[4] = PACKSIZE;
                objArray2[6] = SKU_HIE_NAME;
                objArray2[7] = ClosingStock;
                objArray2[8] = DISTRIBUTOR_PRICE;
                object[] objArray = objArray2;
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DsReport2.uspGetStockValuationDataTable table = (DsReport2.uspGetStockValuationDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new DsReport2.uspGetStockValuationDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DsReport2.uspGetStockValuationRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DsReport2 report = new DsReport2();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = report.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "uspGetStockValuationDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = report.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnSKU_ID = new DataColumn("SKU_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_ID);
                this.columnDISTRIBUTOR_NAME = new DataColumn("DISTRIBUTOR_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDISTRIBUTOR_NAME);
                this.columnSKU_CODE = new DataColumn("SKU_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_CODE);
                this.columnSKU_NAME = new DataColumn("SKU_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_NAME);
                this.columnPACKSIZE = new DataColumn("PACKSIZE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPACKSIZE);
                this.columnSKU_HIE_ID = new DataColumn("SKU_HIE_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_HIE_ID);
                this.columnSKU_HIE_NAME = new DataColumn("SKU_HIE_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSKU_HIE_NAME);
                this.columnClosingStock = new DataColumn("ClosingStock", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnClosingStock);
                this.columnDISTRIBUTOR_PRICE = new DataColumn("DISTRIBUTOR_PRICE", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnDISTRIBUTOR_PRICE);
                this.columnSKU_ID.AutoIncrement = true;
                this.columnSKU_ID.AutoIncrementSeed = -1L;
                this.columnSKU_ID.AutoIncrementStep = -1L;
                this.columnSKU_ID.AllowDBNull = false;
                this.columnSKU_ID.ReadOnly = true;
                this.columnDISTRIBUTOR_NAME.MaxLength = 100;
                this.columnSKU_CODE.AllowDBNull = false;
                this.columnSKU_CODE.MaxLength = 15;
                this.columnSKU_NAME.AllowDBNull = false;
                this.columnSKU_NAME.MaxLength = 100;
                this.columnPACKSIZE.MaxLength = 100;
                this.columnSKU_HIE_ID.AutoIncrement = true;
                this.columnSKU_HIE_ID.AutoIncrementSeed = -1L;
                this.columnSKU_HIE_ID.AutoIncrementStep = -1L;
                this.columnSKU_HIE_ID.AllowDBNull = false;
                this.columnSKU_HIE_ID.ReadOnly = true;
                this.columnSKU_HIE_NAME.MaxLength = 60;
                this.columnClosingStock.ReadOnly = true;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSKU_ID = base.Columns["SKU_ID"];
                this.columnDISTRIBUTOR_NAME = base.Columns["DISTRIBUTOR_NAME"];
                this.columnSKU_CODE = base.Columns["SKU_CODE"];
                this.columnSKU_NAME = base.Columns["SKU_NAME"];
                this.columnPACKSIZE = base.Columns["PACKSIZE"];
                this.columnSKU_HIE_ID = base.Columns["SKU_HIE_ID"];
                this.columnSKU_HIE_NAME = base.Columns["SKU_HIE_NAME"];
                this.columnClosingStock = base.Columns["ClosingStock"];
                this.columnDISTRIBUTOR_PRICE = base.Columns["DISTRIBUTOR_PRICE"];
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DsReport2.uspGetStockValuationRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.uspGetStockValuationRow NewuspGetStockValuationRow()
            {
                return (DsReport2.uspGetStockValuationRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.uspGetStockValuationRowChanged != null)
                {
                    this.uspGetStockValuationRowChanged(this, new DsReport2.uspGetStockValuationRowChangeEvent((DsReport2.uspGetStockValuationRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.uspGetStockValuationRowChanging != null)
                {
                    this.uspGetStockValuationRowChanging(this, new DsReport2.uspGetStockValuationRowChangeEvent((DsReport2.uspGetStockValuationRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.uspGetStockValuationRowDeleted != null)
                {
                    this.uspGetStockValuationRowDeleted(this, new DsReport2.uspGetStockValuationRowChangeEvent((DsReport2.uspGetStockValuationRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.uspGetStockValuationRowDeleting != null)
                {
                    this.uspGetStockValuationRowDeleting(this, new DsReport2.uspGetStockValuationRowChangeEvent((DsReport2.uspGetStockValuationRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void RemoveuspGetStockValuationRow(DsReport2.uspGetStockValuationRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ClosingStockColumn
            {
                get
                {
                    return this.columnClosingStock;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DISTRIBUTOR_NAMEColumn
            {
                get
                {
                    return this.columnDISTRIBUTOR_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DISTRIBUTOR_PRICEColumn
            {
                get
                {
                    return this.columnDISTRIBUTOR_PRICE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DsReport2.uspGetStockValuationRow this[int index]
            {
                get
                {
                    return (DsReport2.uspGetStockValuationRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PACKSIZEColumn
            {
                get
                {
                    return this.columnPACKSIZE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_CODEColumn
            {
                get
                {
                    return this.columnSKU_CODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_HIE_IDColumn
            {
                get
                {
                    return this.columnSKU_HIE_ID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_HIE_NAMEColumn
            {
                get
                {
                    return this.columnSKU_HIE_NAME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_IDColumn
            {
                get
                {
                    return this.columnSKU_ID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SKU_NAMEColumn
            {
                get
                {
                    return this.columnSKU_NAME;
                }
            }
        }

        public class uspGetStockValuationRow : DataRow
        {
            private DsReport2.uspGetStockValuationDataTable tableuspGetStockValuation;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal uspGetStockValuationRow(DataRowBuilder rb) : base(rb)
            {
                this.tableuspGetStockValuation = (DsReport2.uspGetStockValuationDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsClosingStockNull()
            {
                return base.IsNull(this.tableuspGetStockValuation.ClosingStockColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDISTRIBUTOR_NAMENull()
            {
                return base.IsNull(this.tableuspGetStockValuation.DISTRIBUTOR_NAMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDISTRIBUTOR_PRICENull()
            {
                return base.IsNull(this.tableuspGetStockValuation.DISTRIBUTOR_PRICEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPACKSIZENull()
            {
                return base.IsNull(this.tableuspGetStockValuation.PACKSIZEColumn);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsSKU_HIE_NAMENull()
            {
                return base.IsNull(this.tableuspGetStockValuation.SKU_HIE_NAMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetClosingStockNull()
            {
                base[this.tableuspGetStockValuation.ClosingStockColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDISTRIBUTOR_NAMENull()
            {
                base[this.tableuspGetStockValuation.DISTRIBUTOR_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDISTRIBUTOR_PRICENull()
            {
                base[this.tableuspGetStockValuation.DISTRIBUTOR_PRICEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetPACKSIZENull()
            {
                base[this.tableuspGetStockValuation.PACKSIZEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSKU_HIE_NAMENull()
            {
                base[this.tableuspGetStockValuation.SKU_HIE_NAMEColumn] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int ClosingStock
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableuspGetStockValuation.ClosingStockColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ClosingStock' in table 'uspGetStockValuation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableuspGetStockValuation.ClosingStockColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string DISTRIBUTOR_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableuspGetStockValuation.DISTRIBUTOR_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DISTRIBUTOR_NAME' in table 'uspGetStockValuation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableuspGetStockValuation.DISTRIBUTOR_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public decimal DISTRIBUTOR_PRICE
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tableuspGetStockValuation.DISTRIBUTOR_PRICEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DISTRIBUTOR_PRICE' in table 'uspGetStockValuation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableuspGetStockValuation.DISTRIBUTOR_PRICEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string PACKSIZE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableuspGetStockValuation.PACKSIZEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PACKSIZE' in table 'uspGetStockValuation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableuspGetStockValuation.PACKSIZEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_CODE
            {
                get
                {
                    return (string) base[this.tableuspGetStockValuation.SKU_CODEColumn];
                }
                set
                {
                    base[this.tableuspGetStockValuation.SKU_CODEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int SKU_HIE_ID
            {
                get
                {
                    return (int) base[this.tableuspGetStockValuation.SKU_HIE_IDColumn];
                }
                set
                {
                    base[this.tableuspGetStockValuation.SKU_HIE_IDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_HIE_NAME
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableuspGetStockValuation.SKU_HIE_NAMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SKU_HIE_NAME' in table 'uspGetStockValuation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableuspGetStockValuation.SKU_HIE_NAMEColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int SKU_ID
            {
                get
                {
                    return (int) base[this.tableuspGetStockValuation.SKU_IDColumn];
                }
                set
                {
                    base[this.tableuspGetStockValuation.SKU_IDColumn] = value;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string SKU_NAME
            {
                get
                {
                    return (string) base[this.tableuspGetStockValuation.SKU_NAMEColumn];
                }
                set
                {
                    base[this.tableuspGetStockValuation.SKU_NAMEColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class uspGetStockValuationRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DsReport2.uspGetStockValuationRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public uspGetStockValuationRowChangeEvent(DsReport2.uspGetStockValuationRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DsReport2.uspGetStockValuationRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void uspGetStockValuationRowChangeEventHandler(object sender, DsReport2.uspGetStockValuationRowChangeEvent e);
    }
}

