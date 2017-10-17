namespace CoopShop.DataShop {

    @Serenity.Decorators.registerEditor()
    export class CustomerEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, CustomerRow> {

        constructor(hidden: JQuery) {
            super(hidden);
        }

        protected getLookupKey() {
            return 'DataShop.Customer';
        }

        protected getItemText(item, lookup) {
            return super.getItemText(item, lookup) + ' [' + item.CustomerID + ']';
        }
    }
}