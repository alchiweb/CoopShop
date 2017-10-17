using Serenity.Navigation;
using DataShop = CoopShop.DataShop.Pages;

[assembly: NavigationMenu(7000, "DataShop", icon: "icon-anchor")]
[assembly: NavigationLink(7100, "DataShop/Customers", typeof(DataShop.CustomerController), icon: "icon-wallet")]
[assembly: NavigationLink(7200, "DataShop/Orders", typeof(DataShop.OrderController), icon: "icon-basket-loaded")]
[assembly: NavigationLink(7300, "DataShop/Products", typeof(DataShop.ProductController), icon: "icon-present")]
[assembly: NavigationLink(7400, "DataShop/Suppliers", typeof(DataShop.SupplierController), icon: "icon-magic-wand")]
[assembly: NavigationLink(7500, "DataShop/Shippers", typeof(DataShop.ShipperController), icon: "icon-plane")]
[assembly: NavigationLink(7600, "DataShop/Categories", typeof(DataShop.CategoryController), icon: "icon-folder-alt")]
[assembly: NavigationLink(7700, "DataShop/Regions", typeof(DataShop.RegionController), icon: "icon-map")]
[assembly: NavigationLink(7800, "DataShop/Territories", typeof(DataShop.TerritoryController), icon: "icon-puzzle")]
[assembly: NavigationLink(7900, "DataShop/Reports", typeof(DataShop.ReportsController), icon: "icon-docs")]
