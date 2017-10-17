namespace CoopShop.BasicSamples {

    /**
     * Adding Responsive attribute makes this dialog use full screen in mobile devices.
     */
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    @Serenity.Decorators.maximizable()
    export class ResponsiveDialog extends Serenity.EntityDialog<DataShop.OrderRow, any> {
        protected getFormKey() { return DataShop.OrderForm.formKey; }
        protected getIdProperty() { return DataShop.OrderRow.idProperty; }
        protected getLocalTextPrefix() { return DataShop.OrderRow.localTextPrefix; }
        protected getNameProperty() { return DataShop.OrderRow.nameProperty; }
        protected getService() { return DataShop.OrderService.baseUrl; }

        constructor() {
            super();
        }
    }
}