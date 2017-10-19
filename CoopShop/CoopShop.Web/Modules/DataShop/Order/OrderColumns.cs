
namespace CoopShop.DataShop.Columns
{
    using Common;
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("DataShop.Order")]
    [BasedOnRow(typeof(Entities.OrderRow))]
    public class OrderColumns
    {
        [EditLink, AlignRight, SortOrder(1, descending: true), Width(70)]
        public String OrderID { get; set; }

        [EditLink, Width(200), QuickFilter]
        public String CustomerCompanyName { get; set; }

        [EditLink, QuickFilter]
        public DateTime? OrderDate { get; set; }

        //achiweb
        //[Width(140), EmployeeFormatter(GenderProperty = "EmployeeGender"), QuickFilter]
        [Width(140), EmployeeFormatter(GenderProperty = "EmployeeGender"), Hidden]
        public String EmployeeFullName { get; set; }

        [Hidden] //alchiweb
        public DateTime? RequiredDate { get; set; }

        //alchiweb
        //[FilterOnly, QuickFilter]
        [FilterOnly, Hidden]
        public OrderShippingState ShippingState { get; set; }

        [Hidden] //alchiweb
        public DateTime? ShippedDate { get; set; }

        //alchiweb
        //[Width(140), ShipperFormatter, QuickFilter, QuickFilterOption("multiple", true)]
        [Width(140), ShipperFormatter, QuickFilterOption("multiple", true), Hidden]
        public String ShipViaCompanyName { get; set; }

        //alchiweb
        //[Width(100), QuickFilter, LookupEditor(typeof(Scripts.OrderShipCountryLookup))]
        [Width(100), Hidden]
        public String ShipCountry { get; set; }

        //alchiweb
        //[Width(100), LookupEditor(typeof(Scripts.OrderShipCityLookup))]
        //[QuickFilter, QuickFilterOption("CascadeFrom", "ShipCountry")]
        [Width(100), Hidden]
        public String ShipCity { get; set; }

        //alchiweb
        //[FreightFormatter]
        [FreightFormatter, Hidden]
        public Decimal? Freight { get; set; }

        //alchiweb
        [Width(80), Sortable(false), EnumSelectFormatter(EnumKey = "DataShop.PaymentMethodType", AllowClear = false)]
        public PaymentMethodType PaymentMethod { get; set; }

        [Width(80), AlignRight, Updatable(false)]
        public Decimal PaymentTotal { get; set; }
    }
}