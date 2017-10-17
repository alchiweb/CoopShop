using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    public partial class ProductEditorAttribute : LookupEditorBaseAttribute
    {
        public const string Key = "CoopShop.DataShop.ProductEditor";

        public ProductEditorAttribute()
            : base(Key)
        {
        }
    }
}
