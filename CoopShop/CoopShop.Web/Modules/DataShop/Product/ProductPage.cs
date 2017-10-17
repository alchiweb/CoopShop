
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.ProductRow))]
    public class ProductController : Controller
    {
        [Route("DataShop/Product")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Product.ProductIndex);
        }
    }
}
