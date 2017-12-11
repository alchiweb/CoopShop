
namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("DataShop.Product")]
    [BasedOnRow(typeof(Entities.ProductRow))]
    public class ProductForm
    {
        [Category("General")]
        public String InternalRef { get; set; }
        public String ProductName { get; set; }
        //        [DefaultValue(1)]
        public Int32 SupplierID { get; set; }
        //        [DefaultValue(1)]
        public Int32 CategoryID { get; set; }
        public Int32 BrandID { get; set; }
        [Category("Pricing"), DisplayFormat("#,##0.###")]
        public Single QuantityPerUnit { get; set; }
        public Int16 QuantitySymbol { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]

        public Decimal UnitPrice { get; set; }
        public Decimal BuyingPrice { get; set; }
        [ReadOnly(true)]
        public Single SupplierCommissionPercentage { get; set; }

        [Category("Status"), DisplayFormat("#,##0.###")]
        [DecimalEditor(MinValue = "0", MaxValue = "999999999.999")]
        public Single UnitsInStock { get; set; }
        [DisplayFormat("#,##0.###")]
        [DecimalEditor(MinValue = "0", MaxValue = "999999999.999")]
        public Single UnitsOnOrder { get; set; }
        [DisplayFormat("#,##0.###")]
        [DecimalEditor(MinValue = "0", MaxValue = "999999999.999")]
        public Single ReorderLevel { get; set; }
        [Category("Optionnel")]
        public String SupplierRef { get; set; }
        public String ProductImage { get; set; }
        public Boolean Discontinued { get; set; }

        //[Category("General")]
        //public String ProductName { get; set; }
        //public String ProductImage { get; set; }
        //public Boolean Discontinued { get; set; }
        //public Int32 SupplierID { get; set; }
        //public Int32 CategoryID { get; set; }
        //[Category("Pricing")]
        //public String QuantityPerUnit { get; set; }
        //public Decimal UnitPrice { get; set; }
        //[Category("Status")]
        //public Int16 UnitsInStock { get; set; }
        //public Int16 UnitsOnOrder { get; set; }
        //public Int16 ReorderLevel { get; set; }
    }
}