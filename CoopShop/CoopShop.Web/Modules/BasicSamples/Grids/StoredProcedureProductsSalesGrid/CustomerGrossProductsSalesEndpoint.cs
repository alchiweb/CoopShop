namespace CoopShop.BasicSamples.Endpoints
{
    using Serenity.Data;
    using Serenity.Reporting;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Data;
    using Microsoft.AspNetCore.Mvc;
    using MyRepository = Repositories.CustomerGrossProductsSalesRepository;
    using MyRow = DataShop.Entities.CustomerGrossProductsSalesRow;

    [Route("Services/BasicSamples/CustomerGrossProductsSales/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class CustomerGrossProductsSalesController : ServiceEndpoint
    {
        public ListResponse<MyRow> List(IDbConnection connection, CustomerGrossProductsSalesListRequest request)
        {
            return new MyRepository().List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, CustomerGrossProductsSalesListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.CustomerGrossProductsSalesColumns));
            var bytes = new ReportRepository().Render(report);
            return ExcelContentResult.Create(bytes, "CustomerGrossProductsSales_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }
    }
}
