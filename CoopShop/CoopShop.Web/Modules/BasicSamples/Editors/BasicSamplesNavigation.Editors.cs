using CoopShop.BasicSamples;
using CoopShop.BasicSamples.Pages;
using Serenity.Navigation;

[assembly: NavigationMenu(7930, "Basic Samples/Editors")]
[assembly: NavigationLink(7930, "Basic Samples/Editors/Changing Lookup Text", typeof(BasicSamplesController), action: "ChangingLookupText", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7930, "Basic Samples/Editors/Filtered Lookup in Detail.", typeof(BasicSamplesController), action: "FilteredLookupInDetailDialog", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7930, "Basic Samples/Editors/Lookup Filter by Multi Val.", typeof(BasicSamplesController), action: "LookupFilterByMultipleValues", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7930, "Basic Samples/Editors/Select with Hardcod.Vals.", typeof(BasicSamplesController), action: "SelectWithHardcodedValues", Permission = PermissionKeys.General)]
[assembly: NavigationLink(7930, "Basic Samples/Editors/Static Text Block", typeof(BasicSamplesController), action: "StaticTextBlock", Permission = PermissionKeys.General)]
