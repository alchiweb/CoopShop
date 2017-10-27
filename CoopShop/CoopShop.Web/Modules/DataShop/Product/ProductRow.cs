
namespace CoopShop.DataShop.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [ConnectionKey("DataShop"), TableName("Products"), DisplayName("Products"), InstanceName("Product"), TwoLevelCached]
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    [LookupScript("DataShop.Product")]
    [CaptureLog(typeof(ProductLogRow))]
    [LocalizationRow(typeof(ProductLangRow))]
    public sealed class ProductRow : Row, IIdRow, INameRow
    {
        [DisplayName("Product Id"), Identity, LookupInclude]
        public Int32? ProductID
        {
            get { return Fields.ProductID[this]; }
            set { Fields.ProductID[this] = value; }
        }

        [DisplayName("Product Name"), Size(40), NotNull, QuickSearch, LookupInclude]
        public String ProductName
        {
            get { return Fields.ProductName[this]; }
            set { Fields.ProductName[this] = value; }
        }

        [DisplayName("Product Image"), Size(100)]
        [ImageUploadEditor(FilenameFormat = "ProductImage/~", CopyToHistory = true)]
        public String ProductImage
        {
            get { return Fields.ProductImage[this]; }
            set { Fields.ProductImage[this] = value; }
        }

        //alchiwed
        [DisplayName("Discontinued"), NotNull]
        //[LookupInclude] ???
        public Boolean? Discontinued
        {
            get { return Fields.Discontinued[this]; }
            set { Fields.Discontinued[this] = value; }
        }

        [DisplayName("Supplier"), ForeignKey(typeof(SupplierRow)), LeftJoin("sup")]
        [LookupEditor(typeof(SupplierRow), InplaceAdd = true)]
        [NotNull] //alchiweb
        public Int32? SupplierID
        {
            get { return Fields.SupplierID[this]; }
            set { Fields.SupplierID[this] = value; }
        }

        [DisplayName("Category"), ForeignKey(typeof(CategoryRow)), LeftJoin("cat"), LookupInclude]
        [LookupEditor(typeof(CategoryRow), InplaceAdd = true)]
        [NotNull] //alchiweb
        public Int32? CategoryID
        {
            get { return Fields.CategoryID[this]; }
            set { Fields.CategoryID[this] = value; }
        }

        [DisplayName("Brand"), ForeignKey(typeof(BrandRow)), LeftJoin("brand"), LookupInclude, NotNull, DefaultValue(2094)]
        [LookupEditor(typeof(BrandRow), InplaceAdd = true)]
        public Int32? BrandID
        {
            get { return Fields.BrandID[this]; }
            set { Fields.BrandID[this] = value; }
        }
        /*
        [DisplayName("Quantity Per Unit"), Size(20)]
        public String QuantityPerUnit
        {
            get { return Fields.QuantityPerUnit[this]; }
            set { Fields.QuantityPerUnit[this] = value; }
        }

        [DisplayName("Unit Price"), Scale(4), LookupInclude]
        public Decimal? UnitPrice
        {
            get { return Fields.UnitPrice[this]; }
            set { Fields.UnitPrice[this] = value; }
        }

        [DisplayName("Units In Stock"), NotNull, DefaultValue(0), LookupInclude]
        public Int16? UnitsInStock
        {
            get { return Fields.UnitsInStock[this]; }
            set { Fields.UnitsInStock[this] = value; }
        }

        [DisplayName("Units On Order"), NotNull, DefaultValue(0)]
        public Int16? UnitsOnOrder
        {
            get { return Fields.UnitsOnOrder[this]; }
            set { Fields.UnitsOnOrder[this] = value; }
        }

        [DisplayName("Reorder Level"), NotNull, DefaultValue(0)]
        public Int16? ReorderLevel
        {
            get { return Fields.ReorderLevel[this]; }
            set { Fields.ReorderLevel[this] = value; }
        }
        */
        [DisplayName("Quantity Per Unit"), Scale(6), DisplayFormat("#,##0.###"), LookupInclude, DecimalEditor(Decimals = 3), DefaultValue(1)]
        public Single? QuantityPerUnit
        {
            get { return Fields.QuantityPerUnit[this]; }
            set { Fields.QuantityPerUnit[this] = value; }
        }
        [DisplayName("Sold Quantity"), Scale(6), DefaultValue(1), DisplayFormat("#,##0.###"), Expression("(t0.QuantityPerUnit)")]
        public Single? SoldQuantity
        {
            get
            {
                return Fields.SoldQuantity[this];
            }
            set
            {
                Fields.SoldQuantity[this] = value;
            }
        }

        [DisplayName("Quantity Symbol"), NotNull, DefaultValue(1), LookupInclude]
        public QuantitySymbolType? QuantitySymbol
        {
            get { return (QuantitySymbolType?)Fields.QuantitySymbol[this]; }
            set { Fields.QuantitySymbol[this] = (Int16?)value; }
        }

        [DisplayName("Internal Reference"), Unique, QuickSearch(SearchType.Equals, numericOnly: 1), LookupInclude]
        public String InternalRef
        {
            get { return Fields.InternalRef[this]; }
            set { Fields.InternalRef[this] = value; }
        }

        [DisplayName("Supplier Reference")]
        public String SupplierRef
        {
            get { return Fields.SupplierRef[this]; }
            set { Fields.SupplierRef[this] = value; }
        }

        //alchiweb
        //[DisplayName("Unit Price"), Scale(4), LookupInclude]
        [DisplayName("Unit Price"), Scale(4), LookupInclude, NotNull, DefaultValue(0)]
        public Decimal? UnitPrice
        {
            get { return Fields.UnitPrice[this]; }
            set { Fields.UnitPrice[this] = value; }
        }
        [DisplayName("Buying Price"), Scale(4), LookupInclude, DefaultValue(0)]
        public Decimal? BuyingPrice
        {
            get { return Fields.BuyingPrice[this]; }
            set { Fields.BuyingPrice[this] = value; }
        }

        //alchiweb
        //[DisplayName("Units In Stock"), NotNull, DefaultValue(0), LookupInclude]
        [DisplayName("Units In Stock"), NotNull, DefaultValue(1), LookupInclude]
        public Single? UnitsInStock
        {
            get { return Fields.UnitsInStock[this]; }
            set { Fields.UnitsInStock[this] = value; }
        }

        [DisplayName("Units On Order"), NotNull, DefaultValue(0)]
        public Single? UnitsOnOrder
        {
            get { return Fields.UnitsOnOrder[this]; }
            set { Fields.UnitsOnOrder[this] = value; }
        }

        [DisplayName("Reorder Level"), NotNull, DefaultValue(0)]
        public Single? ReorderLevel
        {
            get { return Fields.ReorderLevel[this]; }
            set { Fields.ReorderLevel[this] = value; }
        }



        [Origin("sup"), DisplayName("Supplier"), LookupInclude]
        public String SupplierCompanyName
        {
            get { return Fields.SupplierCompanyName[this]; }
            set { Fields.SupplierCompanyName[this] = value; }
        }

        [Origin("sup")]
        public String SupplierContactName
        {
            get { return Fields.SupplierContactName[this]; }
            set { Fields.SupplierContactName[this] = value; }
        }

        [Origin("sup")]
        public String SupplierContactTitle
        {
            get { return Fields.SupplierContactTitle[this]; }
            set { Fields.SupplierContactTitle[this] = value; }
        }

        [Origin("sup")]
        public String SupplierAddress
        {
            get { return Fields.SupplierAddress[this]; }
            set { Fields.SupplierAddress[this] = value; }
        }

        [Origin("sup")]
        public String SupplierCity
        {
            get { return Fields.SupplierCity[this]; }
            set { Fields.SupplierCity[this] = value; }
        }

        [Origin("sup")]
        public String SupplierRegion
        {
            get { return Fields.SupplierRegion[this]; }
            set { Fields.SupplierRegion[this] = value; }
        }

        [Origin("sup")]
        public String SupplierPostalCode
        {
            get { return Fields.SupplierPostalCode[this]; }
            set { Fields.SupplierPostalCode[this] = value; }
        }

        [Origin("sup")]
        public String SupplierCountry
        {
            get { return Fields.SupplierCountry[this]; }
            set { Fields.SupplierCountry[this] = value; }
        }

        [Origin("sup")]
        public String SupplierPhone
        {
            get { return Fields.SupplierPhone[this]; }
            set { Fields.SupplierPhone[this] = value; }
        }

        [Origin("sup")]
        public String SupplierFax
        {
            get { return Fields.SupplierFax[this]; }
            set { Fields.SupplierFax[this] = value; }
        }

        [Origin("sup")]
        public String SupplierHomePage
        {
            get { return Fields.SupplierHomePage[this]; }
            set { Fields.SupplierHomePage[this] = value; }
        }

        //alchiweb
        [Origin("sup"), ReadOnly(true), DisplayFormat("#,##0.00"), LookupInclude]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Single? SupplierCommissionPercentage
        {
            get { return Fields.SupplierCommissionPercentage[this]; }
            set { Fields.SupplierCommissionPercentage[this] = value; }
        }

        [Origin("cat"), DisplayName("Category")]
        [ QuickSearch, LookupInclude] //alchiweb
        public String CategoryName
        {
            get { return Fields.CategoryName[this]; }
            set { Fields.CategoryName[this] = value; }
        }

        [Origin("cat")]
        public String CategoryDescription
        {
            get { return Fields.CategoryDescription[this]; }
            set { Fields.CategoryDescription[this] = value; }
        }

        [Origin("cat")]
        public Stream CategoryPicture
        {
            get { return Fields.CategoryPicture[this]; }
            set { Fields.CategoryPicture[this] = value; }
        }

        [Origin("brand"), DisplayName("Brand"), QuickSearch, LookupInclude]
        public String BrandName
        {
            get { return Fields.BrandName[this]; }
            set { Fields.BrandName[this] = value; }
        }

        [Origin("brand")]
        public String BrandDescription
        {
            get { return Fields.BrandDescription[this]; }
            set { Fields.BrandDescription[this] = value; }
        }

        [Origin("brand")]
        public Stream BrandPicture
        {
            get { return Fields.BrandPicture[this]; }
            set { Fields.BrandPicture[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.ProductID; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.ProductName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ProductRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ProductID;
            public StringField ProductName;
            public StringField ProductImage;
            public BooleanField Discontinued;
            public Int32Field SupplierID;
            public Int32Field CategoryID;

            //public StringField QuantityPerUnit;
            //public DecimalField UnitPrice;
            //public Int16Field UnitsInStock;
            //public Int16Field UnitsOnOrder;
            //public Int16Field ReorderLevel;

            public Int32Field BrandID;
            public SingleField QuantityPerUnit;
            public SingleField SoldQuantity;
            public DecimalField UnitPrice;
            public DecimalField BuyingPrice;
            public SingleField UnitsInStock;
            public SingleField UnitsOnOrder;
            public SingleField ReorderLevel;

            public StringField SupplierCompanyName;
            public StringField SupplierContactName;
            public StringField SupplierContactTitle;
            public StringField SupplierAddress;
            public StringField SupplierCity;
            public StringField SupplierRegion;
            public StringField SupplierPostalCode;
            public StringField SupplierCountry;
            public StringField SupplierPhone;
            public StringField SupplierFax;
            public StringField SupplierHomePage;
            public SingleField SupplierCommissionPercentage;

            public StringField CategoryName;
            public StringField CategoryDescription;
            public StreamField CategoryPicture;

            public StringField BrandName;
            public StringField BrandDescription;
            public StreamField BrandPicture;

            public Int16Field QuantitySymbol;

            public StringField InternalRef;
            public StringField SupplierRef;

            public RowFields()
            {
                LocalTextPrefix = "DataShop.Product";
            }
        }
    }
}