namespace CoopShop.DataShop.Entities
{
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("DataShop"), DisplayName("Customer Gross Products Sales"), TwoLevelCached]
    [ReadPermission("DataShop:General")]
    [ModifyPermission("DataShop:General")]
    public sealed class CustomerGrossProductsSalesRow : Row, INameRow
    {
        [DisplayName("Product Name"), Size(40), NotNull, QuickSearch]
        public String ProductName
        {
            get { return Fields.ProductName[this]; }
            set { Fields.ProductName[this] = value; }
        }
        [DisplayName("Sales Total"), Size(19), Scale(2)]
        public Decimal? SalesTotal
        {
            get { return Fields.SalesTotal[this]; }
            set { Fields.SalesTotal[this] = value; }
        }
        [DisplayName("Quantity Total"), Size(19), Scale(2)]
        public Decimal? QuantityTotal
        {
            get { return Fields.QuantityTotal[this]; }
            set { Fields.QuantityTotal[this] = value; }
        }
        [DisplayName("Gross Amount"), Size(19), Scale(2)]
        public Decimal? GrossAmount
        {
            get { return Fields.GrossAmount[this]; }
            set { Fields.GrossAmount[this] = value; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ProductName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CustomerGrossProductsSalesRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField ProductName;
            public DecimalField SalesTotal;
            public DecimalField QuantityTotal;

            public DecimalField GrossAmount;

            public RowFields()
                : base("[dbo].[GrossProductsSales]")
            {
                LocalTextPrefix = "BasicSamples.GrossProductsSales";
            }
        }
    }
}