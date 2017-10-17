using Serenity.Data;

namespace CoopShop.BasicSamples.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize, Route("BasicSamples/[action]")]
    //alchiweb
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    public partial class BasicSamplesController : Controller
    {
    }
}
