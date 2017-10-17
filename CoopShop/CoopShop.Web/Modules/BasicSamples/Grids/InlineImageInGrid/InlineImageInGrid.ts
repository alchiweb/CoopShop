/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    @Serenity.Decorators.registerClass()
    export class InlineImageInGrid extends Serenity.EntityGrid<DataShop.ProductRow, any> {

        protected getColumnsKey() { return "BasicSamples.InlineImageInGrid"; }
        protected getDialogType() { return <any>DataShop.ProductDialog; }
        protected getIdProperty() { return DataShop.ProductRow.idProperty; }
        protected getLocalTextPrefix() { return DataShop.ProductRow.localTextPrefix; }
        protected getService() { return DataShop.ProductService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getSlickOptions(): Slick.GridOptions {
            let opt = super.getSlickOptions();
            opt.rowHeight = 150;
            return opt;
        }
    }
}