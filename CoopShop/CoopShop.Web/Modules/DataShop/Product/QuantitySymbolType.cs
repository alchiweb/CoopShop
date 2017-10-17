
using Serenity.ComponentModel;
using System.ComponentModel;

namespace CoopShop.DataShop
{
    [EnumKey("DataShop.QuantitySymbolType")]
    
    public enum QuantitySymbolType
    {
        Indéfini = 0,
        Kilo = 1,
        Litre = 2,
        Pièce = 3
    }
}