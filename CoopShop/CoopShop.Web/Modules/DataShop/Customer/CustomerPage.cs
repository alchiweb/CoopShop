
namespace CoopShop.DataShop.Pages
{
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize(typeof(Entities.CustomerRow))]
    public class CustomerController : Controller
    {
        [Route("DataShop/Customer")]
        public ActionResult Index()
        {
            return View(MVC.Views.DataShop.Customer.CustomerIndex);
        }
    }
}
