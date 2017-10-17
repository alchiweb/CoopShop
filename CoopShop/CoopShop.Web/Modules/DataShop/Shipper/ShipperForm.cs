
namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("DataShop.Shipper")]
    [BasedOnRow(typeof(Entities.ShipperRow))]
    public class ShipperForm
    {
        public String CompanyName { get; set; }
        [DataShop.PhoneEditor]
        public String Phone { get; set; }
    }
}