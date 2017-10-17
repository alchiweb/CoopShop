namespace CoopShop.DataShop {
    export enum OrderShippingState {
        NotShipped = 0,
        Shipped = 1
    }
    Serenity.Decorators.registerEnum(OrderShippingState, 'DataShop.OrderShippingState');
}

