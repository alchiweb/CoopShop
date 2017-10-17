
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.OrderRow))]
    public class OrderController : Controller
    {
        [Route("DataShop/Order")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Order.OrderIndex);
        }
    }
}
