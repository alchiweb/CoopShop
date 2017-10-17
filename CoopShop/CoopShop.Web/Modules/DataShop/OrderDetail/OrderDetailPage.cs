
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.OrderDetailRow))]
    public class OrderDetailController : Controller
    {
        [Route("DataShop/OrderDetail")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.OrderDetail.OrderDetailIndex);
        }
    }
}
