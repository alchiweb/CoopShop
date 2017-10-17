
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
        public Int16 Quantity { get; set; }
        [Width(100)]
        public Double Discount { get; set; }
        [Width(100)]
        public Decimal LineTotal { get; set; }
    }
}