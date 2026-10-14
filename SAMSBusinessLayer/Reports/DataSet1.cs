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

    [Serializable, XmlRoot("DataSet1"), HelpKeyword("vs.data.DataSet"), XmlSchemaProvider("GetTypedDataSetSchema"), ToolboxItem(true), DesignerCategory("code")]
    public class DataSet1 : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private DataTable1DataTable tableDataTable1;
        private DataTable2DataTable tableDataTable2;
        private ssDataTable tabless;

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public DataSet1()
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
        protected DataSet1(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                    if (dataSet.Tables["ss"] != null)
                    {
                        base.Tables.Add(new ssDataTable(dataSet.Tables["ss"]));
                    }
                    if (dataSet.Tables["DataTable1"] != null)
                    {
                        base.Tables.Add(new DataTable1DataTable(dataSet.Tables["DataTable1"]));
                    }
                    if (dataSet.Tables["DataTable2"] != null)
                    {
                        base.Tables.Add(new DataTable2DataTable(dataSet.Tables["DataTable2"]));
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public override DataSet Clone()
        {
            DataSet1 set = (DataSet1) base.Clone();
            set.InitVars();
            set.SchemaSerializationMode = this.SchemaSerializationMode;
            return set;
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
            DataSet1 set = new DataSet1();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = set.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = set.GetSchemaSerializable();
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
            base.DataSetName = "DataSet1";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/DataSet1.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tabless = new ssDataTable();
            base.Tables.Add(this.tabless);
            this.tableDataTable1 = new DataTable1DataTable();
            base.Tables.Add(this.tableDataTable1);
            this.tableDataTable2 = new DataTable2DataTable();
            base.Tables.Add(this.tableDataTable2);
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
            this.tabless = (ssDataTable) base.Tables["ss"];
            if (initTable && (this.tabless != null))
            {
                this.tabless.InitVars();
            }
            this.tableDataTable1 = (DataTable1DataTable) base.Tables["DataTable1"];
            if (initTable && (this.tableDataTable1 != null))
            {
                this.tableDataTable1.InitVars();
            }
            this.tableDataTable2 = (DataTable2DataTable) base.Tables["DataTable2"];
            if (initTable && (this.tableDataTable2 != null))
            {
                this.tableDataTable2.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ss"] != null)
                {
                    base.Tables.Add(new ssDataTable(dataSet.Tables["ss"]));
                }
                if (dataSet.Tables["DataTable1"] != null)
                {
                    base.Tables.Add(new DataTable1DataTable(dataSet.Tables["DataTable1"]));
                }
                if (dataSet.Tables["DataTable2"] != null)
                {
                    base.Tables.Add(new DataTable2DataTable(dataSet.Tables["DataTable2"]));
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeDataTable1()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializeDataTable2()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private bool ShouldSerializess()
        {
            return false;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
        public DataTable1DataTable DataTable1
        {
            get
            {
                return this.tableDataTable1;
            }
        }

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DataTable2DataTable DataTable2
        {
            get
            {
                return this.tableDataTable2;
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

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(true)]
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ssDataTable ss
        {
            get
            {
                return this.tabless;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class DataTable1DataTable : DataTable, IEnumerable
        {
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable1RowChangeEventHandler DataTable1RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable1RowChangeEventHandler DataTable1RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable1RowChangeEventHandler DataTable1RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable1RowChangeEventHandler DataTable1RowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataTable1DataTable()
            {
                base.TableName = "DataTable1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal DataTable1DataTable(DataTable table)
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
            protected DataTable1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataSet1.DataTable1Row AddDataTable1Row()
            {
                DataSet1.DataTable1Row row = (DataSet1.DataTable1Row) base.NewRow();
                row.ItemArray = new object[0];
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddDataTable1Row(DataSet1.DataTable1Row row)
            {
                base.Rows.Add(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public override DataTable Clone()
            {
                DataSet1.DataTable1DataTable table = (DataSet1.DataTable1DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DataSet1.DataTable1DataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(DataSet1.DataTable1Row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DataSet1 set = new DataSet1();
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
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "DataTable1DataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
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
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataSet1.DataTable1Row NewDataTable1Row()
            {
                return (DataSet1.DataTable1Row) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataSet1.DataTable1Row(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DataTable1RowChanged != null)
                {
                    this.DataTable1RowChanged(this, new DataSet1.DataTable1RowChangeEvent((DataSet1.DataTable1Row) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DataTable1RowChanging != null)
                {
                    this.DataTable1RowChanging(this, new DataSet1.DataTable1RowChangeEvent((DataSet1.DataTable1Row) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DataTable1RowDeleted != null)
                {
                    this.DataTable1RowDeleted(this, new DataSet1.DataTable1RowChangeEvent((DataSet1.DataTable1Row) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DataTable1RowDeleting != null)
                {
                    this.DataTable1RowDeleting(this, new DataSet1.DataTable1RowChangeEvent((DataSet1.DataTable1Row) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveDataTable1Row(DataSet1.DataTable1Row row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataSet1.DataTable1Row this[int index]
            {
                get
                {
                    return (DataSet1.DataTable1Row) base.Rows[index];
                }
            }
        }

        public class DataTable1Row : DataRow
        {
            private DataSet1.DataTable1DataTable tableDataTable1;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal DataTable1Row(DataRowBuilder rb) : base(rb)
            {
                this.tableDataTable1 = (DataSet1.DataTable1DataTable) base.Table;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class DataTable1RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataSet1.DataTable1Row eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataTable1RowChangeEvent(DataSet1.DataTable1Row row, DataRowAction action)
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
            public DataSet1.DataTable1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void DataTable1RowChangeEventHandler(object sender, DataSet1.DataTable1RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class DataTable2DataTable : DataTable, IEnumerable
        {
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable2RowChangeEventHandler DataTable2RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable2RowChangeEventHandler DataTable2RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable2RowChangeEventHandler DataTable2RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.DataTable2RowChangeEventHandler DataTable2RowDeleting;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataTable2DataTable()
            {
                base.TableName = "DataTable2";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal DataTable2DataTable(DataTable table)
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
            protected DataTable2DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataSet1.DataTable2Row AddDataTable2Row()
            {
                DataSet1.DataTable2Row row = (DataSet1.DataTable2Row) base.NewRow();
                row.ItemArray = new object[0];
                base.Rows.Add(row);
                return row;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void AddDataTable2Row(DataSet1.DataTable2Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                DataSet1.DataTable2DataTable table = (DataSet1.DataTable2DataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new DataSet1.DataTable2DataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(DataSet1.DataTable2Row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DataSet1 set = new DataSet1();
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
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "DataTable2DataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
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
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataSet1.DataTable2Row NewDataTable2Row()
            {
                return (DataSet1.DataTable2Row) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataSet1.DataTable2Row(builder);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.DataTable2RowChanged != null)
                {
                    this.DataTable2RowChanged(this, new DataSet1.DataTable2RowChangeEvent((DataSet1.DataTable2Row) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.DataTable2RowChanging != null)
                {
                    this.DataTable2RowChanging(this, new DataSet1.DataTable2RowChangeEvent((DataSet1.DataTable2Row) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.DataTable2RowDeleted != null)
                {
                    this.DataTable2RowDeleted(this, new DataSet1.DataTable2RowChangeEvent((DataSet1.DataTable2Row) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.DataTable2RowDeleting != null)
                {
                    this.DataTable2RowDeleting(this, new DataSet1.DataTable2RowChangeEvent((DataSet1.DataTable2Row) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveDataTable2Row(DataSet1.DataTable2Row row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataSet1.DataTable2Row this[int index]
            {
                get
                {
                    return (DataSet1.DataTable2Row) base.Rows[index];
                }
            }
        }

        public class DataTable2Row : DataRow
        {
            private DataSet1.DataTable2DataTable tableDataTable2;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal DataTable2Row(DataRowBuilder rb) : base(rb)
            {
                this.tableDataTable2 = (DataSet1.DataTable2DataTable) base.Table;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class DataTable2RowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataSet1.DataTable2Row eventRow;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataTable2RowChangeEvent(DataSet1.DataTable2Row row, DataRowAction action)
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
            public DataSet1.DataTable2Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void DataTable2RowChangeEventHandler(object sender, DataSet1.DataTable2RowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class ssDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDataColumn1;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.ssRowChangeEventHandler ssRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.ssRowChangeEventHandler ssRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.ssRowChangeEventHandler ssRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DataSet1.ssRowChangeEventHandler ssRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public ssDataTable()
            {
                base.TableName = "ss";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal ssDataTable(DataTable table)
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
            protected ssDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddssRow(DataSet1.ssRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataSet1.ssRow AddssRow(string DataColumn1)
            {
                DataSet1.ssRow row = (DataSet1.ssRow) base.NewRow();
                row.ItemArray = new object[] { DataColumn1 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                DataSet1.ssDataTable table = (DataSet1.ssDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new DataSet1.ssDataTable();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public virtual IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(DataSet1.ssRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                DataSet1 set = new DataSet1();
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
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "ssDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
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
                this.columnDataColumn1 = new DataColumn("DataColumn1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDataColumn1);
                base.Constraints.Add(new UniqueConstraint("ssKey1", new DataColumn[] { this.columnDataColumn1 }, false));
                this.columnDataColumn1.Unique = true;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnDataColumn1 = base.Columns["DataColumn1"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DataSet1.ssRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataSet1.ssRow NewssRow()
            {
                return (DataSet1.ssRow) base.NewRow();
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ssRowChanged != null)
                {
                    this.ssRowChanged(this, new DataSet1.ssRowChangeEvent((DataSet1.ssRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ssRowChanging != null)
                {
                    this.ssRowChanging(this, new DataSet1.ssRowChangeEvent((DataSet1.ssRow) e.Row, e.Action));
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ssRowDeleted != null)
                {
                    this.ssRowDeleted(this, new DataSet1.ssRowChangeEvent((DataSet1.ssRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ssRowDeleting != null)
                {
                    this.ssRowDeleting(this, new DataSet1.ssRowChangeEvent((DataSet1.ssRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovessRow(DataSet1.ssRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DebuggerNonUserCode]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataColumn DataColumn1Column
            {
                get
                {
                    return this.columnDataColumn1;
                }
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public DataSet1.ssRow this[int index]
            {
                get
                {
                    return (DataSet1.ssRow) base.Rows[index];
                }
            }
        }

        public class ssRow : DataRow
        {
            private DataSet1.ssDataTable tabless;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal ssRow(DataRowBuilder rb) : base(rb)
            {
                this.tabless = (DataSet1.ssDataTable) base.Table;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public bool IsDataColumn1Null()
            {
                return base.IsNull(this.tabless.DataColumn1Column);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public void SetDataColumn1Null()
            {
                base[this.tabless.DataColumn1Column] = Convert.DBNull;
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
            public string DataColumn1
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabless.DataColumn1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DataColumn1' in table 'ss' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabless.DataColumn1Column] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class ssRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private DataSet1.ssRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public ssRowChangeEvent(DataSet1.ssRow row, DataRowAction action)
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
            public DataSet1.ssRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void ssRowChangeEventHandler(object sender, DataSet1.ssRowChangeEvent e);
    }
}

