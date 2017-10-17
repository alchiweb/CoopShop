namespace CoopShop.DataShop {
    export enum QuantitySymbolType {
        Indéfini = 0,
        Kilo = 1,
        Litre = 2,
        Pièce = 3
    }
    Serenity.Decorators.registerEnum(QuantitySymbolType, 'DataShop.QuantitySymbolType');
}
