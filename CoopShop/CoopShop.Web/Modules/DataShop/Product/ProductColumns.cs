
namespace CoopShop.DataShop.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;
//    using CoopShop.BasicSamples;
//    using MVC;
//    using Serenity.Data.Mapping;
    using Common;


    [ColumnsScript("DataShop.Product")]
    [BasedOnRow(typeof(Entities.ProductRow))]
    public class ProductColumns
    {
        /*
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public String ProductID { get; set; }
        */
        [Width(132), AlignRight]
        public String InternalRef { get; set; }
        /*
        [DisplayName("Product Image"), Size(100),InlineImageFormatter]
        public String ProductImage
        {
            get;
            set;
        }
        
        [InlineImageFormatter(FileProperty = "ProductImage", Thumb = true), Width(450)]
        public String ProductThumbnail { get; set; }
        */

        [EditLink, Width(250)]
        public String ProductName { get; set; }
        [QuickFilter]
        public Boolean Discontinued { get; set; }
        [EditLink(ItemType = "DataShop.Supplier"), QuickFilter]
        public String SupplierCompanyName { get; set; }
        [EditLink(ItemType = "DataShop.Category"), Width(150), QuickFilter, QuickFilterOption("multiple", true)]
        public String CategoryName { get; set; }
        [EditLink(ItemType = "DataShop.Brand"), Width(150), QuickFilter(), QuickFilterOption("multiple", true), QuickFilterOption("ignoreAccents", true)]
        public String BrandName { get; set; }
        //[Width(130)]
        [Width(80)]
        public Single QuantityPerUnit { get; set; }
        [Width(80)]
        public Single SoldQuantity { get; set; }

        [Width(80), Sortable(false), EnumSelectFormatter(EnumKey = "DataShop.QuantitySymbolType", AllowClear = false)]
        public QuantitySymbolType QuantitySymbol { get; set; }

        [Width(80), AlignRight]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal UnitPrice { get; set; }
        [Width(80), AlignRight]
        public Decimal BuyingPrice { get; set; }
        [Width(40), AlignRight, ReadOnly(true)]
        public Decimal SupplierCommissionPercentage { get; set; }

        [Width(80), AlignRight]
        public Single UnitsInStock { get; set; }
        [Width(80), AlignRight]
        public Single UnitsOnOrder { get; set; }
        [Width(80), AlignRight]
        public Single ReorderLevel { get; set; }

        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public String ProductID { get; set; }
        //[EditLink, Width(250)]
        //public String ProductName { get; set; }
        //[QuickFilter]
        //public Boolean Discontinued { get; set; }
        //[EditLink(ItemType = "DataShop.Supplier"), QuickFilter]
        //public String SupplierCompanyName { get; set; }
        //[EditLink(ItemType = "DataShop.Category"), Width(150), QuickFilter, QuickFilterOption("multiple", true)]
        //public String CategoryName { get; set; }
        //[Width(130)]
        //public String QuantityPerUnit { get; set; }
        //[Width(80), AlignRight]
        //public Decimal UnitPrice { get; set; }
        //[Width(80), AlignRight]
        //public Int16 UnitsInStock { get; set; }
        //[Width(80), AlignRight]
        //public Int16 UnitsOnOrder { get; set; }
        //[Width(80), AlignRight]
        //public Int16 ReorderLevel { get; set; }
    }
}