using CoopShop.DataShop;
using Serenity.Navigation;
using DataShop = CoopShop.DataShop.Pages;


[assembly: NavigationMenu(7000, "DataShop", icon: "fa-shopping-cart")]
[assembly: NavigationLink(7100, "DataShop/Customers", typeof(DataShop.CustomerController), icon: "fa-credit-card")]
[assembly: NavigationLink(7200, "DataShop/Orders", typeof(DataShop.OrderController), icon: "fa-shopping-cart")]
[assembly: NavigationLink(7300, "DataShop/Products", typeof(DataShop.ProductController), icon: "fa-cube")]
[assembly: NavigationLink(7600, "DataShop/Categories", typeof(DataShop.CategoryController), icon: "fa-folder-o")]
[assembly: NavigationLink(7650, "DataShop/Brands", typeof(DataShop.BrandController), icon: "fa-folder-o")]
[assembly: NavigationLink(7400, "DataShop/Suppliers", typeof(DataShop.SupplierController), icon: "fa-truck")]
[assembly: NavigationLink(7400, "DataShop/Taxes", typeof(DataShop.TaxController), icon: "fa-money")]
[assembly: NavigationLink(7900, "DataShop/Reports", typeof(DataShop.ReportsController), icon: "fa-files-o")]
[assembly: NavigationLink(7700, "DataShop/Regions", typeof(DataShop.RegionController), icon: "fa-map-o")]


[assembly: NavigationLink(7500, "DataShop/Shippers", typeof(DataShop.ShipperController), icon: "fa-truck", Permission = PermissionKeys.Special)]
[assembly: NavigationLink(7800, "DataShop/Territories", typeof(DataShop.TerritoryController), icon: "fa-puzzle-piece", Permission = PermissionKeys.Special)]
