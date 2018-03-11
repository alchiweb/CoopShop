
namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("DataShop.Tax")]
    [BasedOnRow(typeof(Entities.TaxRow))]
    public class TaxColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Width(100)]
        public Int32 TaxID { get; set; }
        [EditLink, Width(200)]
        public String TaxDescription { get; set; }
        [EditLink(ItemType = "DataShop.Region", IdField = "RegionID"), Width(150)]
        [LookupEditor(typeof(Entities.RegionRow)), QuickFilter]
        public String RegionDescription { get; set; }
        [Width(40)]
        public Single RatePercentage { get; set; }
        [EditLink, QuickFilter(CssClass = "hidden-xs")]
        public DateTime? OfficialDate { get; set; }
    }
}