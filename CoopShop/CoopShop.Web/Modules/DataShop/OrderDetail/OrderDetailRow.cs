
namespace CoopShop.DataShop.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("DataShop"), TableName("[Order Details]"), DisplayName("Order Details"), InstanceName("Order Detail"), TwoLevelCached]
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    public sealed class OrderDetailRow : Row, IIdRow
    {
        [SortOrder(0, true)]

        [DisplayName("ID"), Identity]
        public Int32? DetailID
        {
            get { return Fields.DetailID[this]; }
            set { Fields.DetailID[this] = value; }
        }

        [DisplayName("Order Id"), PrimaryKey, ForeignKey(typeof(OrderRow)), LeftJoin("o"), Updatable(false)]
        public Int32? OrderID
        {
            get { return Fields.OrderID[this]; }
            set { Fields.OrderID[this] = value; }
        }

        //alchiweb
        //[DisplayName("Product"), PrimaryKey, ForeignKey(typeof(ProductRow)), LeftJoin("p")]
        //[LookupEditor(typeof(ProductRow))]
        [DisplayName("Product"), PrimaryKey, ForeignKey(typeof(ProductRow), "ProductID"), LeftJoin("p")]
        [ProductEditor(InplaceAdd = true)]
        public Int32? ProductID
        {
            get { return Fields.ProductID[this]; }
            set { Fields.ProductID[this] = value; }
        }

        [DisplayName("Unit Price"), Scale(4), NotNull, AlignRight, DisplayFormat("#,##0.00")]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal? UnitPrice
        {
            get { return Fields.UnitPrice[this]; }
            set { Fields.UnitPrice[this] = value; }
        }

        [DisplayName("Quantity"), NotNull, DefaultValue(1), AlignRight]
        //alchiweb
        [DisplayFormat("#,##0.###"), DecimalEditor(Decimals = 3)]
        public Single? Quantity
        {
            get { return Fields.Quantity[this]; }
            set { Fields.Quantity[this] = value; }
        }

        [DisplayName("Discount"), NotNull, DefaultValue(0), AlignRight, DisplayFormat("#,##0.00")]
        //alchiweb
        [Hidden]
        public Single? Discount
        {
            get { return Fields.Discount[this]; }
            set { Fields.Discount[this] = value; }
        }
        //alchiweb
        //[DisplayName("Line Total"), Expression("(t0.[UnitPrice] * t0.[Quantity] - t0.[Discount])")]
        [DisplayName("Line Total"), Expression("(CEILING((t0.[UnitPrice] * t0.[Quantity] - t0.[Discount])*100)/100)")]
        [AlignRight, DisplayFormat("#,##0.00"), MinSelectLevel(SelectLevel.List)]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal? LineTotal
        {
            get { return Fields.LineTotal[this]; }
            set { Fields.LineTotal[this] = value; }
        }

        //alchiweb
        [DisplayName("Prix /"), Expression("IsNull(t0.[UnitPrice] / p.[QuantityPerUnit], 0)")]
        [AlignRight, DisplayFormat("#,##0.00 € /"), MinSelectLevel(SelectLevel.List)]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal? QuantityPerUnitPrice
        {
            get { return Fields.QuantityPerUnitPrice[this]; }
            set { Fields.QuantityPerUnitPrice[this] = value; }
        }


        [Origin("p"), MinSelectLevel(SelectLevel.List)]
        [Expression("cat.[CategoryName] + ' - ' + p.[ProductName] + ' (' + brand.[BrandName] + ')'")]

        public String ProductName
        {
            get { return Fields.ProductName[this]; }
            set { Fields.ProductName[this] = value; }
        }
        [Origin("p")]
        public Single? QuantityPerUnit
        {
            get { return Fields.QuantityPerUnit[this]; }
            set { Fields.QuantityPerUnit[this] = value; }
        }

        [Origin("p"), DisplayName("Unité")]
//                [Expression("p.[QuantitySymbol]")]
        public QuantitySymbolType? QuantitySymbol
        {
            get { return (QuantitySymbolType?)Fields.QuantitySymbol[this]; }
            set { Fields.QuantitySymbol[this] = (Int16?)value; }
        }

        [Origin("p"), DisplayName("Stock")]
        //                [Expression("p.[QuantitySymbol]")]
        public Single? UnitsInStock
        {
            get { return (Single?)Fields.UnitsInStock[this]; }
            set { Fields.UnitsInStock[this] = (Single?)value; }
        }


        [Origin("p"), DisplayName("Category"), ForeignKey(typeof(CategoryRow), "CategoryID"), LeftJoin("cat"), LookupInclude]
        [LookupEditor(typeof(CategoryRow), InplaceAdd = true)]
        public Int32? CategoryID
        {
            get { return Fields.CategoryID[this]; }
            set { Fields.CategoryID[this] = value; }
        }

        [Origin("p"), DisplayName("Brand"), ForeignKey(typeof(BrandRow), "BrandID"), LeftJoin("brand"), LookupInclude]
        [LookupEditor(typeof(BrandRow), InplaceAdd = true)]
        public Int32? BrandID
        {
            get { return Fields.BrandID[this]; }
            set { Fields.BrandID[this] = value; }
        }


        [Origin("cat"), DisplayName("Category"), QuickSearch, LookupInclude]
        public String CategoryName
        {
            get { return Fields.CategoryName[this]; }
            set { Fields.CategoryName[this] = value; }
        }

        [DisplayName("RatePercentage")]
        [Expression("(SELECT [RatePercentage] FROM [Taxes] WHERE [TaxID] = cat.[TaxType] AND [RegionID] = 1 AND [OfficialDate] <= o.[OrderDate] ORDER BY [OfficialDate] DESC)")]
        public Single? RatePercentage
        {
            get
            {
                return Fields.RatePercentage[this];
            }
            set
            {
                Fields.RatePercentage[this] = value;
            }
        }


        [Origin("brand"), DisplayName("Brand"), QuickSearch, LookupInclude]
        public String BrandName
        {
            get { return Fields.BrandName[this]; }
            set { Fields.BrandName[this] = value; }
        }

        [Origin("o")]
        public DateTime? OrderDate
        {
            get { return Fields.OrderDate[this]; }
            set { Fields.OrderDate[this] = value; }
        }

        /*
        [Origin("o")]
        public String OrderCustomerID
        {
            get { return Fields.OrderCustomerID[this]; }
            set { Fields.OrderCustomerID[this] = value; }
        }

        [Origin("o")]
        public Int32? OrderEmployeeID
        {
            get { return Fields.OrderEmployeeID[this]; }
            set { Fields.OrderEmployeeID[this] = value; }
        }

        [Origin("o")]
        public DateTime? OrderDate
        {
            get { return Fields.OrderDate[this]; }
            set { Fields.OrderDate[this] = value; }
        }

        [Origin("o")]
        public DateTime? OrderShippedDate
        {
            get { return Fields.OrderShippedDate[this]; }
            set { Fields.OrderShippedDate[this] = value; }
        }

        [Origin("o")]
        public Int32? OrderShipVia
        {
            get { return Fields.OrderShipVia[this]; }
            set { Fields.OrderShipVia[this] = value; }
        }

        [Origin("o")]
        public String OrderShipCity
        {
            get { return Fields.OrderShipCity[this]; }
            set { Fields.OrderShipCity[this] = value; }
        }

        [Origin("o")]
        public String OrderShipCountry
        {
            get { return Fields.OrderShipCountry[this]; }
            set { Fields.OrderShipCountry[this] = value; }
        }

        [Origin("p"), MinSelectLevel(SelectLevel.List)]
        public String ProductName
        {
            get { return Fields.ProductName[this]; }
            set { Fields.ProductName[this] = value; }
        }

        [Origin("p")]
        public Boolean? ProductDiscontinued
        {
            get { return Fields.ProductDiscontinued[this]; }
            set { Fields.ProductDiscontinued[this] = value; }
        }

        [Origin("p")]
        public Int32? ProductSupplierID
        {
            get { return Fields.ProductSupplierID[this]; }
            set { Fields.ProductSupplierID[this] = value; }
        }

        [Origin("p")]
        public String ProductQuantityPerUnit
        {
            get { return Fields.ProductQuantityPerUnit[this]; }
            set { Fields.ProductQuantityPerUnit[this] = value; }
        }

        [Origin("p")]
        public Decimal? ProductUnitPrice
        {
            get { return Fields.ProductUnitPrice[this]; }
            set { Fields.ProductUnitPrice[this] = value; }
        }
        */
        IIdField IIdRow.IdField
        {
            get { return Fields.DetailID; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public OrderDetailRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DetailID;
            public Int32Field OrderID;
            public Int32Field ProductID;
            public DecimalField UnitPrice;
            public SingleField Quantity; // alchiweb
            public SingleField Discount;
            public SingleField UnitsInStock;

            public StringField ProductName;
            public SingleField QuantityPerUnit;
            public DateTimeField OrderDate;

/*
            public StringField OrderCustomerID;

            public Int32Field OrderEmployeeID;
            public DateTimeField OrderDate;
            public DateTimeField OrderShippedDate;
            public Int32Field OrderShipVia;
            public StringField OrderShipCity;
            public StringField OrderShipCountry;
  
            public StringField ProductName;
            public BooleanField ProductDiscontinued;
            public Int32Field ProductSupplierID;
            public StringField ProductQuantityPerUnit;
            public DecimalField ProductUnitPrice;
            */
            public DecimalField LineTotal;

            public DecimalField QuantityPerUnitPrice;
            public Int16Field QuantitySymbol;

            public Int32Field CategoryID;
            public Int32Field BrandID;
            public StringField CategoryName;
            public StringField BrandName;

            public SingleField RatePercentage;

            public RowFields()
            {
                LocalTextPrefix = "DataShop.OrderDetail";
            }
        }
    }
}