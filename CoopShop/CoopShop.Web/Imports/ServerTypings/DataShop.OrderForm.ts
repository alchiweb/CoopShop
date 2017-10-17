namespace CoopShop.DataShop {
    export class OrderForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.Order';

    }

    export interface OrderForm {
        CustomerID: CustomerEditor;
        OrderDate: Serenity.DateEditor;
        DetailList: OrderDetailsEditor;
        PaymentTotal: Serenity.DecimalEditor;
        PaymentMethod: Serenity.EnumEditor;
    }

    [['CustomerID', () => CustomerEditor], ['OrderDate', () => Serenity.DateEditor], ['DetailList', () => OrderDetailsEditor], ['PaymentTotal', () => Serenity.DecimalEditor], ['PaymentMethod', () => Serenity.EnumEditor]].forEach(x => Object.defineProperty(OrderForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}
