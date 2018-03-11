using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoopShop.DataShop.Entities
{
    public enum TaxType
    {
        StandardRate = 0,
        ReducedRate = 1,
        ReducedLowerRate = 2,
        SuperReducedRate = 3,
        ParkingRate = 4
    }
}
