namespace CoopShop.DataShop {

    @Serenity.Decorators.registerClass()
    export class TaxDialog extends Serenity.EntityDialog<TaxRow, any> {
        protected getFormKey() { return TaxForm.formKey; }
        protected getIdProperty() { return TaxRow.idProperty; }
        protected getLocalTextPrefix() { return TaxRow.localTextPrefix; }
        protected getNameProperty() { return TaxRow.nameProperty; }
        protected getService() { return TaxService.baseUrl; }

        protected form = new TaxForm(this.idPrefix);

        protected getLanguages() {
            return LanguageList.getValue();
        }
    }
}