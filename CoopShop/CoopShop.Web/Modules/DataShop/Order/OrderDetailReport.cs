
namespace CoopShop.DataShop
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Reporting;
    using System;
    using System.Collections.Generic;

    [Report("DataShop.OrderDetail")]
    [ReportDesign(MVC.Views.DataShop.Order.OrderDetailReport)]
    [RequiredPermission(PermissionKeys.General)]
    public class OrderDetailReport : IReport, ICustomizeHtmlToPdf
    {
        public Int32 OrderID { get; set; }

        public object GetData()
        {
            var data = new OrderDetailReportData();

            using (var connection = SqlConnections.NewFor<OrderRow>())
            {
                var o = OrderRow.Fields;

                data.Order = connection.TryById<OrderRow>(this.OrderID, q => q
                     .SelectTableFields()
                     //alchiweb
                     //.Select(o.EmployeeFullName)
                     //.Select(o.ShipViaCompanyName)
                     ) ?? new OrderRow();

                var od = OrderDetailRow.Fields;
                data.Details = connection.List<OrderDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Select(od.LineTotal)
                    .Where(od.OrderID == this.OrderID));

                var p = ProductRow.Fields;

                data.Details.ForEach(row => row.QuantitySymbol = connection.First<ProductRow>(q => q.Select(p.QuantitySymbol).Where(new Criteria(p.ProductID) == row.ProductID.Value)).QuantitySymbol);
                var c = CustomerRow.Fields;
                data.Customer = connection.TryFirst<CustomerRow>(c.CustomerID == data.Order.CustomerID)
                    ?? new CustomerRow();
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
            // you may customize HTML to PDF converter (WKHTML) parameters here, e.g. 
            // options.MarginsAll = "2cm";
        }
    }

    public class OrderDetailReportData
    {
        public OrderRow Order { get; set; }
        public List<OrderDetailRow> Details { get; set; }
        public CustomerRow Customer { get; set; }
    }
}