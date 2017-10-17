
namespace CoopShop.DataShop.Entities
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;

    [ConnectionKey("DataShop")]
    public sealed class ProductLogRow : Row, ICaptureLogRow
    {
        [Identity]
        public Int64? ProductLogID
        {
            get { return Fields.ProductLogID[this]; }
            set { Fields.ProductLogID[this] = value; }
        }

        public CaptureOperationType? OperationType
        {
            get { return (CaptureOperationType?)Fields.OperationType[this]; }
            set { Fields.OperationType[this] = (Int16?)value; }
        }

        public Int32? ChangingUserId
        {
            get { return Fields.ChangingUserId[this]; }
            set { Fields.ChangingUserId[this] = value; }
        }

        public DateTime? ValidFrom
        {
            get { return Fields.ValidFrom[this]; }
            set { Fields.ValidFrom[this] = value; }
        }

        public DateTime? ValidUntil
        {
            get { return Fields.ValidUntil[this]; }
            set { Fields.ValidUntil[this] = value; }
        }

        [NotNull]
        public Int32? ProductID
        {
            get { return Fields.ProductID[this]; }
            set { Fields.ProductID[this] = value; }
        }

        [Size(40)]
        public String ProductName
        {
            get { return Fields.ProductName[this]; }
            set { Fields.ProductName[this] = value; }
        }

        [Size(100)]
        public String ProductImage
        {
            get { return Fields.ProductImage[this]; }
            set { Fields.ProductImage[this] = value; }
        }

        public Boolean? Discontinued
        {
            get { return Fields.Discontinued[this]; }
            set { Fields.Discontinued[this] = value; }
        }

        public Int32? SupplierID
        {
            get { return Fields.SupplierID[this]; }
            set { Fields.SupplierID[this] = value; }
        }

        public Int32? CategoryID
        {
            get { return Fields.CategoryID[this]; }
            set { Fields.CategoryID[this] = value; }
        }

        //alchiweb
        public Int32? BrandID
        {
            get { return Fields.BrandID[this]; }
            set { Fields.BrandID[this] = value; }
        }
        //alchiweb: modif
        [Scale(4)]
        public Single? QuantityPerUnit
        {
            get { return Fields.QuantityPerUnit[this]; }
            set { Fields.QuantityPerUnit[this] = value; }
        }

        [Scale(4)]
        public Decimal? UnitPrice
        {
            get { return Fields.UnitPrice[this]; }
            set { Fields.UnitPrice[this] = value; }
        }

        //alchiweb
        [Scale(4)]
        public Decimal? BuyingPrice
        {
            get { return Fields.BuyingPrice[this]; }
            set { Fields.BuyingPrice[this] = value; }
        }

        //alchiweb: modif
        public Single? UnitsInStock
        {
            get { return Fields.UnitsInStock[this]; }
            set { Fields.UnitsInStock[this] = value; }
        }

        //alchiweb: modif
        public Single? UnitsOnOrder
        {
            get { return Fields.UnitsOnOrder[this]; }
            set { Fields.UnitsOnOrder[this] = value; }
        }

        //alchiweb: modif
        public Single? ReorderLevel
        {
            get { return Fields.ReorderLevel[this]; }
            set { Fields.ReorderLevel[this] = value; }
        }

        //alchiweb
        public Int16? QuantitySymbol
        {
            get { return Fields.QuantitySymbol[this]; }
            set { Fields.QuantitySymbol[this] = value; }
        }

        public String InternalRef
        {
            get { return Fields.InternalRef[this]; }
            set { Fields.InternalRef[this] = value; }
        }

        public String SupplierRef
        {
            get { return Fields.SupplierRef[this]; }
            set { Fields.SupplierRef[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.ProductLogID; }
        }

        Int16Field ICaptureLogRow.OperationTypeField
        {
            get { return Fields.OperationType; }
        }

        Field ICaptureLogRow.ChangingUserIdField
        {
            get { return Fields.ChangingUserId; }
        }

        DateTimeField ICaptureLogRow.ValidFromField
        {
            get { return Fields.ValidFrom; }
        }

        DateTimeField ICaptureLogRow.ValidUntilField
        {
            get { return Fields.ValidUntil; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ProductLogRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field ProductLogID;
            public Int16Field OperationType;
            public Int32Field ChangingUserId;
            public DateTimeField ValidFrom;
            public DateTimeField ValidUntil;

            public Int32Field ProductID;
            public StringField ProductName;
            public StringField ProductImage;
            public BooleanField Discontinued;
            public Int32Field SupplierID;
            public Int32Field CategoryID;

            public Int32Field BrandID;
            public SingleField QuantityPerUnit;
            public DecimalField UnitPrice;
            public DecimalField BuyingPrice;
            public SingleField UnitsInStock;
            public SingleField UnitsOnOrder;
            public SingleField ReorderLevel;
            public Int16Field QuantitySymbol;
            public StringField InternalRef;
            public StringField SupplierRef;
            //public StringField QuantityPerUnit;
            //public DecimalField UnitPrice;
            //public Int16Field UnitsInStock;
            //public Int16Field UnitsOnOrder;
            //public Int16Field ReorderLevel;

            public RowFields()
                : base("ProductLog")
            {
                LocalTextPrefix = "DataShop.ProductLog";
            }
        }
    }
}