namespace CoopShop.DataShop {
    export enum TaxType {
        StandardRate = 0,
        ReducedRate = 1,
        ReducedLowerRate = 2,
        SuperReducedRate = 3,
        ParkingRate = 4
    }
    Serenity.Decorators.registerEnum(TaxType, 'CoopShop.DataShop.Entities.TaxType');
}
