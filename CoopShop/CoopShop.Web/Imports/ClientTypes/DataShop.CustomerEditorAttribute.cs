using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    public partial class CustomerEditorAttribute : LookupEditorBaseAttribute
    {
        public const string Key = "CoopShop.DataShop.CustomerEditor";

        public CustomerEditorAttribute()
            : base(Key)
        {
        }
    }
}
