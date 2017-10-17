
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.TerritoryRow))]
    public class TerritoryController : Controller
    {
        [Route("DataShop/Territory")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Territory.TerritoryIndex);
        }
    }
}
