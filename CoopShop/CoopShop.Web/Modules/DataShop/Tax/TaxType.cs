using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serenity.ComponentModel;

namespace CoopShop.DataShop.Entities
{
    [EnumKey("DataShop.TaxType")]

    public enum TaxType
    {
        StandardRate = 0,
        ReducedRate = 1,
        ReducedLowerRate = 2,
        SuperReducedRate = 3,
        ParkingRate = 4
    }
}
