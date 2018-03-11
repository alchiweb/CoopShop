namespace CoopShop.DataShop {
    export class OrderDetailForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.OrderDetail';

    }

    export interface OrderDetailForm {
        InternalRef: Serenity.StringEditor;
        ProductID: ProductEditor;
        UnitPrice: Serenity.DecimalEditor;
        Quantity: Serenity.DecimalEditor;
        QuantitySymbol: Serenity.EnumEditor;
        QuantityPerUnitPrice: Serenity.DecimalEditor;
        Discount: Serenity.DecimalEditor;
        UnitsInStock: Serenity.DecimalEditor;
        RatePercentage: Serenity.DecimalEditor;
    }

    [['InternalRef', () => Serenity.StringEditor], ['ProductID', () => ProductEditor], ['UnitPrice', () => Serenity.DecimalEditor], ['Quantity', () => Serenity.DecimalEditor], ['QuantitySymbol', () => Serenity.EnumEditor], ['QuantityPerUnitPrice', () => Serenity.DecimalEditor], ['Discount', () => Serenity.DecimalEditor], ['UnitsInStock', () => Serenity.DecimalEditor], ['RatePercentage', () => Serenity.DecimalEditor]].forEach(x => Object.defineProperty(OrderDetailForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}
