
namespace CoopShop.BasicSamples {

    /**
     * Our custom product editor type
     */
    @Serenity.Decorators.registerEditor()
    export class ChangingLookupTextEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, DataShop.ProductRow> {

        constructor(container: JQuery, options: Serenity.LookupEditorOptions) {
            super(container, options);
        }

        protected getLookupKey() {
            return DataShop.ProductRow.lookupKey;
        }

        protected getItemText(item: DataShop.ProductRow, lookup: Q.Lookup<DataShop.ProductRow>) {
            return super.getItemText(item, lookup) +
                ' (' +
                '$' + Q.formatNumber(item.UnitPrice, '#,##0.00') +
                ', ' + (item.UnitsInStock > 0 ? (item.UnitsInStock + ' in stock') : 'out of stock') +
                ', ' + (item.SupplierCompanyName || 'Unknown') +
                ')';
        }
    }
}