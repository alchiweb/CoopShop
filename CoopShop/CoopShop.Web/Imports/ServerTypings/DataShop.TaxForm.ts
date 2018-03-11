namespace CoopShop.DataShop {
    export class TaxForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.Tax';

    }

    export interface TaxForm {
        TaxID: Serenity.EnumEditor;
        TaxDescription: Serenity.StringEditor;
        RegionID: Serenity.LookupEditor;
        RatePercentage: Serenity.DecimalEditor;
        OfficialDate: Serenity.DateEditor;
    }

    [['TaxID', () => Serenity.EnumEditor], ['TaxDescription', () => Serenity.StringEditor], ['RegionID', () => Serenity.LookupEditor], ['RatePercentage', () => Serenity.DecimalEditor], ['OfficialDate', () => Serenity.DateEditor]].forEach(x => Object.defineProperty(TaxForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}
