/// <reference path="SelectableEntityGrid.ts" />

namespace CoopShop.BasicSamples {

    @Serenity.Decorators.registerClass()
    export class RowSelectionGrid extends SelectableEntityGrid<DataShop.SupplierRow, any> {
        protected getColumnsKey() { return "DataShop.Supplier"; }
        protected getDialogType() { return <any>DataShop.SupplierDialog; }
        protected getIdProperty() { return DataShop.SupplierRow.idProperty; }
        protected getLocalTextPrefix() { return DataShop.SupplierRow.localTextPrefix; }
        protected getService() { return DataShop.SupplierService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}