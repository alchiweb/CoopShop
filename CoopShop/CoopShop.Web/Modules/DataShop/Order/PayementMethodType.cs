
using Serenity.ComponentModel;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    [EnumKey("DataShop.PaymentMethodType")]
    
    public enum PaymentMethodType
    {
        NotPayed = 0,
        Cash = 1,
        Check = 2,
        Other = 3
    }
}