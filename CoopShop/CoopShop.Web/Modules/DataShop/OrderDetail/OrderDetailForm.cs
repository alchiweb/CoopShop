
namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("DataShop.OrderDetail")]
    [BasedOnRow(typeof(Entities.OrderDetailRow))]
    public class OrderDetailForm
    {
        //alchiweb
        [OneWay]
        public String InternalRef { get; set; }

        public Int32 ProductID { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal UnitPrice { get; set; }
        //alchiweb
        [DisplayFormat("#,##0.###")]
        public Single Quantity { get; set; }
        [ReadOnly(true)]
        public QuantitySymbolType QuantitySymbol { get; set; }

        [ReadOnly(true)]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Single QuantityPerUnitPrice { get; set; }
        public Double Discount { get; set; }
        [ReadOnly(true)]
        [DecimalEditor(MinValue = "0", MaxValue = "999999999.999")]
        public Single UnitsInStock { get; set; }
    }
}