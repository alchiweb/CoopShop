namespace CoopShop.DataShop {

    @Serenity.Decorators.registerClass()
    export class RegionGrid extends Serenity.EntityGrid<RegionRow, any> {
        protected getColumnsKey() { return "DataShop.Region"; }
        protected getDialogType() { return <any>RegionDialog; }
        protected getIdProperty() { return RegionRow.idProperty; }
        protected getLocalTextPrefix() { return RegionRow.localTextPrefix; }
        protected getService() { return RegionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}