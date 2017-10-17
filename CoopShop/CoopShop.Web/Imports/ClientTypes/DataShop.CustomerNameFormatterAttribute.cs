using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    public partial class CustomerNameFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "CoopShop.DataShop.CustomerNameFormatter";

        public CustomerNameFormatterAttribute()
            : base(Key)
        {
        }

        public String FirstNameField
        {
            get { return GetOption<String>("firstNameField"); }
            set { SetOption("firstNameField", value); }
        }

        public String LastNameField
        {
            get { return GetOption<String>("lastNameField"); }
            set { SetOption("lastNameField", value); }
        }
    }
}
