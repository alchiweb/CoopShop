namespace CoopShop.DataShop {
    export class ShipperForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.Shipper';

    }

    export interface ShipperForm {
        CompanyName: Serenity.StringEditor;
        Phone: PhoneEditor;
    }

    [['CompanyName', () => Serenity.StringEditor], ['Phone', () => PhoneEditor]].forEach(x => Object.defineProperty(ShipperForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

