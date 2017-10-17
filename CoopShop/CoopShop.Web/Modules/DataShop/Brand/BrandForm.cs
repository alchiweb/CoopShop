
namespace CoopShop.DataShop.Forms
{


    using Serenity.ComponentModel;
    using System;

    [FormScript("DataShop.Brand")]
    [BasedOnRow(typeof(Entities.BrandRow))]
    public class BrandForm
    {
        public String BrandName { get; set; }
        public String Description { get; set; }
    }
}