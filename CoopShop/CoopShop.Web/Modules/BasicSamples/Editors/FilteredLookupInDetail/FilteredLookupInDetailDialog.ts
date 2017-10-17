namespace CoopShop.BasicSamples {

    /**
     * Basic order dialog with a category selection
     */
    @Serenity.Decorators.registerClass()
    export class FilteredLookupInDetailDialog extends Serenity.EntityDialog<DataShop.OrderRow, any> {

        protected getFormKey() { return FilteredLookupInDetailForm.formKey; }
        protected getIdProperty() { return DataShop.OrderRow.idProperty; }
        protected getLocalTextPrefix() { return DataShop.OrderRow.localTextPrefix; }
        protected getNameProperty() { return DataShop.OrderRow.nameProperty; }
        protected getService() { return DataShop.OrderService.baseUrl; }

        private form: FilteredLookupInDetailForm;

        constructor() {
            super();

            this.form = new FilteredLookupInDetailForm(this.idPrefix);
            this.form.CategoryID.change(e => {
                this.form.DetailList.categoryID = Q.toId(this.form.CategoryID.value);
            });
        }
    }
}