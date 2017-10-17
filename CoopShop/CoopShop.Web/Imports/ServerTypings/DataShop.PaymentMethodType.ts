namespace CoopShop.DataShop {
    export enum PaymentMethodType {
        NotPayed = 0,
        Cash = 1,
        Check = 2,
        Other = 3
    }
    Serenity.Decorators.registerEnum(PaymentMethodType, 'DataShop.PaymentMethodType');
}
