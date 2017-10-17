using Serenity.Services;

namespace CoopShop.DataShop
{
    public class OrderListRequest : ListRequest
    {
        public int? ProductID { get; set; }
    }
}