
namespace CoopShop.DataShop {
//    import { Big } from "big.js";

    //import {Big} from "big.js";
    //import IDataGrid = Serenity.IDataGrid;
    //import ListRequest = Serenity.ListRequest;
    //import getColumns = Q.getColumns;
    //import SlickFormatting = Serenity.SlickFormatting;

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
        export class OrderGrid extends Serenity.EntityGrid<OrderRow, any> {



        protected getColumnsKey() { return "DataShop.Order"; }
        protected getDialogType() { return <any>OrderDialog; }
        protected getIdProperty() { return OrderRow.idProperty; }
        protected getLocalTextPrefix() { return OrderRow.localTextPrefix; }
        protected getService() { return OrderService.baseUrl; }

        protected shippingStateFilter: Serenity.EnumEditor;

        constructor(container: JQuery) {
            super(container);
        }

        //alchiweb
        onViewProcessData(response: Serenity.ListResponse<DataShop.OrderRow>): Serenity.ListResponse<DataShop.OrderRow> {
            var eltsumtotal: Element = $("#sumtotal")[0];
            Big.RM = 1;

            if (eltsumtotal !== undefined) {

                var sumtotal: Big = new Big("0");

                var salestotal: number = 0;
                for (var resp of response.Entities) {
                    sumtotal = sumtotal.plus(resp.PaymentTotal);
                    salestotal++;
                }
                var salesaverage: Big = sumtotal.div(salestotal).round(2);
                eltsumtotal.innerHTML =
                    "<font color=\"#0000FF\">Total des ventes affichées (dans la page) : <font color=\"#FF0000\">" +
                sumtotal.toString().replace('.', Q.Culture.decimalSeparator) +
                    "</font> €<br/>Pour <font color=\"#FF0000\">" +
                    salestotal +
                    "</font> ventes. Prix moyen par vente : <font color=\"#FF0000\">" +
                salesaverage.toString().replace('.', Q.Culture.decimalSeparator) +
                    "</font> €</font>";
            }
            return super.onViewProcessData(response);
        }

        protected getQuickFilters() {
            var filters = super.getQuickFilters();

            filters.push({
                type: Serenity.LookupEditor,
                options: {
                    lookupKey: ProductRow.lookupKey
                },
                field: 'ProductID',
                title: 'Contient le produit...',//'Contains Product in Details',
                handler: w => {
                    (this.view.params as OrderListRequest).ProductID = Q.toId(w.value);
                },
                cssClass: 'hidden-xs'
            });

            return filters;
        }

        protected createQuickFilters() {
            super.createQuickFilters();

            //alchiweb
            //let fld = OrderRow.Fields;
            //this.shippingStateFilter = this.findQuickFilter(Serenity.EnumEditor, fld.ShippingState);
        }



        protected getButtons() {
            var buttons = super.getButtons();

            buttons.push(Common.ExcelExportHelper.createToolButton({
                grid: this,
                service: OrderService.baseUrl + '/ListExcel',
                onViewSubmit: () => this.onViewSubmit(),
                separator: true
            }));

            buttons.push(Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            return buttons;
        }

        protected getColumns() {
            var columns = super.getColumns();

            columns.splice(1, 0, {
                field: 'Print Invoice',
                name: '',
                format: ctx => '<a class="inline-action print-invoice" title="invoice">' +
                    '<i class="fa fa-file-pdf-o text-red"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number) {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            // if user clicks "i" element, e.g. icon
            if (target.parent().hasClass('inline-action'))
                target = target.parent();

            if (target.hasClass('inline-action')) {
                e.preventDefault();

                if (target.hasClass('print-invoice')) {
                    CoopShop.Common.ReportHelper.execute({
                        reportKey: 'DataShop.OrderDetail',
                        params: {
                            OrderID: item.OrderID
                        }
                    });
                }
            }
        }

        //alchiweb
        protected getViewOptions(): Slick.RemoteViewOptions {
            var slickRemoteViewOptions: Slick.RemoteViewOptions = super.getViewOptions();
            slickRemoteViewOptions.rowsPerPage = 2500;
            return slickRemoteViewOptions;
        }

        public set_shippingState(value: number): void {
            this.shippingStateFilter.value = value == null ? '' : value.toString();
        }

        protected addButtonClick() {
            var eq = this.view.params.EqualityFilter;
            this.editItem(<OrderRow>{
                CustomerID: eq ? eq.CustomerID : null
            });
        }
    }
}
