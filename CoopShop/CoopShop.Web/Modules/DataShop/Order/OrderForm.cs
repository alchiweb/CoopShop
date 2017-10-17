
namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [FormScript("DataShop.Order")]
    [BasedOnRow(typeof(Entities.OrderRow))]
    public class OrderForm
    {
        //alchiweb
        //[Tab("General")]
        [Category("Order")]
        public String CustomerID { get; set; }
        [DefaultValue("now")]
        public DateTime OrderDate { get; set; }
        //public DateTime RequiredDate { get; set; }
        //public Int32? EmployeeID { get; set; }

        [Category("Order Details")]
        [OrderDetailsEditor]
        public List<Entities.OrderDetailRow> DetailList { get; set; }

        [Category("Order Payment")]
        public Decimal PaymentTotal { get; set; }
        public PaymentMethodType PaymentMethod { get; set; }

        /*
        [Tab("Shipping")]
        [Category("Info")]
        public DateTime ShippedDate { get; set; }
        public Int32 ShipVia { get; set; }
        public Decimal Freight { get; set; }

        [Category("Ship To")]
        public String ShipName { get; set; }
        public String ShipAddress { get; set; }
        public String ShipCity { get; set; }
        public String ShipRegion { get; set; }
        public String ShipPostalCode { get; set; }
        public String ShipCountry { get; set; }
        */
    }
}