
namespace CoopShop.DataShop
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Reporting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;

    [Report, RequiredPermission(PermissionKeys.General)]
    [Category("DataShop/Ventes"), DisplayName("Meilleures ventes de produits")]
    public class CustomerGrossProductsSalesReport : IReport, IDataOnlyReport
    {
        [DisplayName("Date de début")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Date de fin")]
        public DateTime? EndDate { get; set; }

        public object GetData()
        {
            using (var connection = SqlConnections.NewFor<Entities.SalesByCategoryRow>())
            {
                return connection.Query<Item>("CustomerGrossProductsSales",
                    param: new
                    {
                        startDate = StartDate,
                        endDate = EndDate
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<ReportColumn> GetColumnList()
        {
            return ReportColumnConverter.ObjectTypeToList(typeof(Item));
        }

        [BasedOnRow(typeof(DataShop.Entities.CustomerGrossProductsSalesRow))]
        public class Item
        {

            [DisplayName("Produit")]
            public string ProductName { get; set; }
            [DisplayFormat("#,##0.00")]
            [DisplayName("Quantité")]
            public decimal QuantityTotal { get; set; }
            [DisplayFormat("#,##0.00")]
            [DisplayName("Total des ventes")]

            public decimal SalesTotal { get; set; }
            [DisplayFormat("#,##0.00")]
            [CellDecorator(typeof(AmountDecorator))]
            [DisplayName("Total")]
            public decimal GrossAmount { get; set; }
        }

        public class AmountDecorator : BaseCellDecorator
        {
            public override void Decorate()
            {
                var item = this.Item as Item;

#if COREFX
                if (item.GrossAmount > 1000)
                    Foreground = "#ff0000";
                else if (item.GrossAmount > 500)
                    Foreground = "#ffa500";
#else
                if (item.GrossAmount > 1000)
                    Foreground = Color.FromArgb(255, 0, 0);
                else if (item.GrossAmount > 500)
                    Foreground = Color.FromArgb(255, 165, 0);
#endif
            }
        }
    }
}