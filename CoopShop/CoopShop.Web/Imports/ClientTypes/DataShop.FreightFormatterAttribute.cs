using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    public partial class FreightFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "CoopShop.DataShop.FreightFormatter";

        public FreightFormatterAttribute()
            : base(Key)
        {
        }
    }
}
