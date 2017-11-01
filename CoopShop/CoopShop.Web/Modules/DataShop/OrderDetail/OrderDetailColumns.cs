
using System.ComponentModel;
using Serenity.Navigation;

namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("DataShop.OrderDetail")]
    [BasedOnRow(typeof(Entities.OrderDetailRow))]
    public class OrderDetailColumns
    {
        [EditLink, Width(200)]
        public String ProductName { get; set; }
        [Width(100)]
        public Decimal UnitPrice { get; set; }
        [Width(100)]
        public Single Quantity { get; set; } //alchiweb
        [Width(100)]
        //alchiweb
        [Hidden]
        public Double Discount { get; set; }
        [Width(100)]
        public Decimal LineTotal { get; set; }
        //alchiweb
        [Width(80)]
        public Decimal QuantityPerUnitPrice { get; set; }
        [Width(50)]
        public QuantitySymbolType QuantitySymbol { get; set; }
    }
}