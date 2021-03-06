
namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("DataShop.Category")]
    [BasedOnRow(typeof(Entities.CategoryRow))]
    public class CategoryColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 CategoryID { get; set; }
        [EditLink, Width(250)]
        public String CategoryName { get; set; }
        [Width(450)]
        public String Description { get; set; }
        [Width(100)]
        public Int32 TaxType { get; set; }
    }
}