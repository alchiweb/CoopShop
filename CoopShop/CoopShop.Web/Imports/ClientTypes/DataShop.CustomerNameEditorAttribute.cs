using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    public partial class CustomerNameEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "CoopShop.DataShop.CustomerNameEditor";

        public CustomerNameEditorAttribute()
            : base(Key)
        {
        }

        public String FirstNameField
        {
            get { return GetOption<String>("firstNameField"); }
            set { SetOption("firstNameField", value); }
        }

        public String FullNameField
        {
            get { return GetOption<String>("fullNameField"); }
            set { SetOption("fullNameField", value); }
        }

        public String LastNameField
        {
            get { return GetOption<String>("lastNameField"); }
            set { SetOption("lastNameField", value); }
        }
    }
}
