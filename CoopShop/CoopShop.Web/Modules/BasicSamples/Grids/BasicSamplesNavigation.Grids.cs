using CoopShop.BasicSamples;
using CoopShop.BasicSamples.Pages;
using Serenity.Navigation;

//alchiweb: add , Permission = PermissionKeys.General
[assembly: NavigationMenu(7950, "Basic Samples/Grids")]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Cancellable Bulk Action", typeof(BasicSamplesController), action: "CancellableBulkAction", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Conditional Formatting", typeof(BasicSamplesController), action: "ConditionalFormatting", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Custom Links In Grid", typeof(BasicSamplesController), action: "CustomLinksInGrid", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Drag & Drop in Tree Grid", typeof(BasicSamplesController), action: "DragDropInTreeGrid", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Enabling Row Selection", typeof(BasicSamplesController), action: "EnablingRowSelection", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Grouping and Sum. In Grid", typeof(BasicSamplesController), action: "GroupingAndSummariesInGrid", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Grid Filtered by Criteria", typeof(BasicSamplesController), action: "GridFilteredByCriteria", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Initial Value for Quick Flt.", typeof(BasicSamplesController), action: "InitialValuesForQuickFilters", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Inline Action Buttons", typeof(BasicSamplesController), action: "InlineActionButtons", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Inline Image In Grid", typeof(BasicSamplesController), action: "InlineImageInGrid", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Product Excel Import", typeof(BasicSamplesController), action: "ProductExcelImport", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Quick Filter Customization", typeof(BasicSamplesController), action: "QuickFilterCustomization", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Removing Add Button", typeof(BasicSamplesController), action: "RemovingAddButton", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Stored Procedure Grid", typeof(BasicSamplesController), action: "StoredProcedureGrid", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Tree Grid", typeof(BasicSamplesController), action: "TreeGrid", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/View Without ID", typeof(BasicSamplesController), action: "ViewWithoutID", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7950, "Basic Samples/Grids/Wrapped Headers", typeof(BasicSamplesController), action: "WrappedHeaders", Permission = PermissionKeys.General)]