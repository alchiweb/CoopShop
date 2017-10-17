
namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("DataShop.Category")]
    [BasedOnRow(typeof(Entities.CategoryRow))]
    public class CategoryForm
    {
        public String CategoryName { get; set; }
        public String Description { get; set; }
    }
}