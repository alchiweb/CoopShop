



namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.ShipperRow))]
    public class ShipperController : Controller
    {
        [Route("DataShop/Shipper")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Shipper.ShipperIndex);
        }
    }
}
