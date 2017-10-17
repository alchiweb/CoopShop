
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.CategoryRow))]
    public class CategoryController : Controller
    {
        [Route("DataShop/Category")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Category.CategoryIndex);
        }
    }
}
