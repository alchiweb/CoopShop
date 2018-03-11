
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.TaxRow))]
    public class TaxController : Controller
    {
        [Route("DataShop/Tax")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Tax.TaxIndex);
        }
    }
}
