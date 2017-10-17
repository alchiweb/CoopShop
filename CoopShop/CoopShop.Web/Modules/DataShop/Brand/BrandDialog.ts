namespace CoopShop.DataShop {



    @Serenity.Decorators.registerClass()
    export class BrandDialog extends Serenity.EntityDialog<BrandRow, any> {
        protected getFormKey() { return BrandForm.formKey; }
        protected getIdProperty() { return BrandRow.idProperty; }
        protected getLocalTextPrefix() { return BrandRow.localTextPrefix; }
        protected getNameProperty() { return BrandRow.nameProperty; }
        protected getService() { return BrandService.baseUrl; }

        protected form = new BrandForm(this.idPrefix);
    }
}