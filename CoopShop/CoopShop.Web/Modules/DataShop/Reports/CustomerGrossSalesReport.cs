
namespace CoopShop.DataShop
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Reporting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;

    [Report]
    [RequiredPermission(PermissionKeys.General)]
    [Category("DataShop/Ventes"), DisplayName("Détail des ventes par produit")]
    public class CustomerGrossSalesReport : IReport, IDataOnlyReport
    {
        [DisplayName("Date de début")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Date de fin")]
        public DateTime? EndDate { get; set; }

        public object GetData()
        {
            using (var connection = SqlConnections.NewFor<Entities.SalesByCategoryRow>())
            {
                return connection.Query<Item>("CustomerGrossSales",
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

        [BasedOnRow(typeof(DataShop.Entities.CustomerGrossSalesRow))]
        public class Item
        {
            [DisplayName("N° coopérateur")]

            public string CustomerId { get; set; }
            [DisplayName("Coopérateur")]
            public string ContactName { get; set; }
            [DisplayName("N° produit")]
            public int? ProductId { get; set; }
            [DisplayName("Nom produit")]
            public string ProductName { get; set; }
            [CellDecorator(typeof(AmountDecorator))]
            [DisplayFormat("#,##0.00")]
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