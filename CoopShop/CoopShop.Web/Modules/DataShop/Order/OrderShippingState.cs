
namespace CoopShop.DataShop
{
    using Serenity.ComponentModel;
    using System.ComponentModel;

    [EnumKey("DataShop.OrderShippingState")]
    public enum OrderShippingState
    {
        [Description("Not Shipped")]
        NotShipped = 0,
        [Description("Shipped")]
        Shipped = 1
    }
}