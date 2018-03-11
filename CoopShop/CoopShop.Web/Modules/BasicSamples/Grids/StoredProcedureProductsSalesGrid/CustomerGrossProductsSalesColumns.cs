namespace CoopShop.BasicSamples.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("BasicSamples.CustomerGrossProductsSales")]
    [BasedOnRow(typeof(DataShop.Entities.CustomerGrossProductsSalesRow))]
    public class CustomerGrossProductsSalesColumns
    {
         [Width(250), SortOrder(1)]
        public String ProductName { get; set; }

        [Width(150), AlignRight, SortOrder(2, descending: true), DisplayFormat("#,##0.00")]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]

        public String QuantityTotal { get; set; }

        [Width(150), AlignRight, SortOrder(2, descending: true), DisplayFormat("#,##0.00")]
        public String SalesTotal { get; set; }


        [Width(150), AlignRight, SortOrder(2, descending: true), DisplayFormat("#,##0.00")]
        public Decimal GrossAmount { get; set; }
    }
}