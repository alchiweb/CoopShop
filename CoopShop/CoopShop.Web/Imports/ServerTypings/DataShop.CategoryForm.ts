namespace CoopShop.DataShop {
    export class CategoryForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.Category';

    }

    export interface CategoryForm {
        CategoryName: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        TaxType: Serenity.EnumEditor;
    }

    [['CategoryName', () => Serenity.StringEditor], ['Description', () => Serenity.StringEditor], ['TaxType', () => Serenity.EnumEditor]].forEach(x => Object.defineProperty(CategoryForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}
