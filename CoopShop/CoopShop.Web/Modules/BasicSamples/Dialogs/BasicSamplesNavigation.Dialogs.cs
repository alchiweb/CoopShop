using CoopShop.BasicSamples;
using CoopShop.BasicSamples.Pages;
using Serenity.Navigation;

[assembly: NavigationMenu(7910, "Basic Samples/Dialogs")]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Chart in a Dialog", typeof(BasicSamplesController), action: "ChartInDialog", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Cloneable Entity Dialog", typeof(BasicSamplesController), action: "CloneableEntityDialog", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Default Values in New Dialog", typeof(BasicSamplesController), action: "DefaultValuesInNewDialog", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Dialog Boxes", typeof(BasicSamplesController), action: "DialogBoxes", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Entity Dialog as Panel", typeof(BasicSamplesController), action: "EntityDialogAsPanel", Url = "~/BasicSamples/EntityDialogAsPanel/11077", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Get Inserted Record ID", typeof(BasicSamplesController), action: "GetInsertedRecordId", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Multi Column Dialog", typeof(BasicSamplesController), action: "MultiColumnResponsiveDialog", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Other Form In Tab", typeof(BasicSamplesController), action: "OtherFormInTab", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Other Form, One Toolbar", typeof(BasicSamplesController), action: "OtherFormInTabOneBar", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Populate Linked Data", typeof(BasicSamplesController), action: "PopulateLinkedData", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Read-Only Dialog", typeof(BasicSamplesController), action: "ReadOnlyDialog", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Responsive Dialog", typeof(BasicSamplesController), action: "ResponsiveDialog", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7910, "Basic Samples/Dialogs/Serial Auto Numbering", typeof(BasicSamplesController), action: "SerialAutoNumber", Permission = PermissionKeys.General)]