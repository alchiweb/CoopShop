
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
        public Decimal UnitPrice { get; set; }
        //alchiweb
        [DisplayFormat("#,##0.###")]
        public Single Quantity { get; set; }
        [ReadOnly(true)]
        public QuantitySymbolType QuantitySymbol { get; set; }
        [ReadOnly(true)]
        public Single QuantityPerUnitPrice { get; set; }
        public Double Discount { get; set; }
    }
}