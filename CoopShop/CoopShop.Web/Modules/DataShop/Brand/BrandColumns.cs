
namespace CoopShop.DataShop.Forms
{

    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("DataShop.Brand")]
    [BasedOnRow(typeof(Entities.BrandRow))]
    public class BrandColumns
    {

        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 BrandID { get; set; }
        [EditLink, Width(250)]
        public String BrandName { get; set; }
        [Width(450)]
        public String Description { get; set; }
    }
}