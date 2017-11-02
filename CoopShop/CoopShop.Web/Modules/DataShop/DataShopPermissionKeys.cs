
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
            public const string Admin = "DataShop:Customer:Admin";
        }


        [Description("[General]")]
        public const string General = "DataShop:General";
        public const string Special = "DataShop:Special";

        //public class Customer
        //{
        //    public const string Delete = "DataShop:Customer:Delete";
        //    public const string Modify = "DataShop:Customer:Modify";
        //    public const string View = "DataShop:Customer:View";
        //}
        //public const string General = "DataShop:General";
        //public const string Special = "DataShop:Special";
    }
}
