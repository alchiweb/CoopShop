
using Serenity.Extensibility;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    [NestedPermissionKeys]
    [DisplayName("DataShop")]
    public class PermissionKeys
    {
        [DisplayName("Customers")]
        public class Customer
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "DataShop:Customer:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "DataShop:Customer:Modify";
            public const string View = "DataShop:Customer:View";
        }

        [Description("[General]")]
        public const string General = "DataShop:General";
    }
}
