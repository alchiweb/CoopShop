
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
        //[SortOrder(1, descending:true)]
        //public Int32 DetailID { get; set; }


        [EditLink, Width(200)]
        public String ProductName { get; set; }
        [Width(100)]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal UnitPrice { get; set; }
        [Width(100)]
        public Single Quantity { get; set; } //alchiweb
        [Width(100)]
        //alchiweb
        [Hidden]
        public Double Discount { get; set; }
        [Width(100)]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal LineTotal { get; set; }
        //alchiweb
        [Width(80)]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Decimal QuantityPerUnitPrice { get; set; }
        [Width(50)]
        public QuantitySymbolType QuantitySymbol { get; set; }

        public Single  RatePercentage { get; set; }
        //public DateTime? OrderDate { get; set; }



    }
}