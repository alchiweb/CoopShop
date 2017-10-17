using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    public partial class ShipperFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "CoopShop.DataShop.ShipperFormatter";

        public ShipperFormatterAttribute()
            : base(Key)
        {
        }
    }
}
