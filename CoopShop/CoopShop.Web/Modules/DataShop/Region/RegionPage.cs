
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.RegionRow))]
    public class RegionController : Controller
    {
        [Route("DataShop/Region")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Region.RegionIndex);
        }
    }
}
