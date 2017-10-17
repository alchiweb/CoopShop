
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(PermissionKeys.General)]
    public class ReportsController : Controller
    {
        [Route("DataShop/Reports")]
        public ActionResult Index()
        {
            return View(MVC.Views.Common.Reporting.ReportPage, 
                new ReportRepository().GetReportTree("DataShop"));
        }
    }
}
