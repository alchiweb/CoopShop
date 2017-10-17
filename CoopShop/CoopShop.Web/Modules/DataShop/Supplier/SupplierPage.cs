
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.SupplierRow))]
    public class SupplierController : Controller
    {
        [Route("DataShop/Supplier")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Supplier.SupplierIndex);
        }
    }
}
