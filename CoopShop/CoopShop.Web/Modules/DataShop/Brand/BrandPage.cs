
namespace CoopShop.DataShop.Pages
{


    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.BrandRow))]
    public class BrandController : Controller
    {
        [Route("DataShop/Brand")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Brand.BrandIndex);
        }
    }
}
