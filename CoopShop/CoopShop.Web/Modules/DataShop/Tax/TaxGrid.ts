namespace CoopShop.DataShop {

    @Serenity.Decorators.registerClass()
    export class TaxGrid extends Serenity.EntityGrid<TaxRow, any> {
        protected getColumnsKey() { return "DataShop.Tax"; }
        protected getDialogType() { return <any>TaxDialog; }
        protected getIdProperty() { return TaxRow.idProperty; }
        protected getLocalTextPrefix() { return TaxRow.localTextPrefix; }
        protected getService() { return TaxService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}