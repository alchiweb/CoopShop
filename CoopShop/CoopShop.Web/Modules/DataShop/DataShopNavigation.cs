using CoopShop.DataShop;
using Serenity.Navigation;
using DataShop = CoopShop.DataShop.Pages;


[assembly: NavigationMenu(7000, "DataShop", icon: "icon-home")]
[assembly: NavigationLink(7100, "DataShop/Customers", typeof(DataShop.CustomerController), icon: "icon-wallet")]
[assembly: NavigationLink(7200, "DataShop/Orders", typeof(DataShop.OrderController), icon: "icon-basket-loaded")]
[assembly: NavigationLink(7300, "DataShop/Products", typeof(DataShop.ProductController), icon: "icon-present")]
[assembly: NavigationLink(7600, "DataShop/Categories", typeof(DataShop.CategoryController), icon: "icon-folder-alt")]
[assembly: NavigationLink(7650, "DataShop/Brands", typeof(DataShop.BrandController), icon: "icon-folder-alt")]
[assembly: NavigationLink(7400, "DataShop/Suppliers", typeof(DataShop.SupplierController), icon: "icon-magic-wand")]

[assembly: NavigationLink(7500, "DataShop/Shippers", typeof(DataShop.ShipperController), icon: "icon-plane", Permission = PermissionKeys.Special)]
[assembly: NavigationLink(7700, "DataShop/Regions", typeof(DataShop.RegionController), icon: "icon-map", Permission = PermissionKeys.Special)]
[assembly: NavigationLink(7800, "DataShop/Territories", typeof(DataShop.TerritoryController), icon: "icon-puzzle", Permission = PermissionKeys.Special)]
[assembly: NavigationLink(7900, "DataShop/Reports", typeof(DataShop.ReportsController), icon: "icon-docs", Permission = PermissionKeys.Special)]
