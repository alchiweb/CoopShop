namespace CoopShop.DataShop {
    export class ProductForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.Product';

    }

    export interface ProductForm {
        InternalRef: Serenity.StringEditor;
        ProductName: Serenity.StringEditor;
        SupplierID: Serenity.LookupEditor;
        CategoryID: Serenity.LookupEditor;
        BrandID: Serenity.LookupEditor;
        QuantityPerUnit: Serenity.DecimalEditor;
        QuantitySymbol: Serenity.EnumEditor;
        UnitPrice: Serenity.DecimalEditor;
        BuyingPrice: Serenity.DecimalEditor;
        SupplierCommissionPercentage: Serenity.DecimalEditor;
        TaxType: Serenity.EnumEditor;
        RatePercentage: Serenity.DecimalEditor;
        BrandTax: Serenity.DecimalEditor;
        SupplierRegionID: Serenity.IntegerEditor;
        UnitsInStock: Serenity.DecimalEditor;
        UnitsOnOrder: Serenity.DecimalEditor;
        ReorderLevel: Serenity.DecimalEditor;
        SupplierRef: Serenity.StringEditor;
        ProductImage: Serenity.ImageUploadEditor;
        Discontinued: Serenity.BooleanEditor;
    }

    [['InternalRef', () => Serenity.StringEditor], ['ProductName', () => Serenity.StringEditor], ['SupplierID', () => Serenity.LookupEditor], ['CategoryID', () => Serenity.LookupEditor], ['BrandID', () => Serenity.LookupEditor], ['QuantityPerUnit', () => Serenity.DecimalEditor], ['QuantitySymbol', () => Serenity.EnumEditor], ['UnitPrice', () => Serenity.DecimalEditor], ['BuyingPrice', () => Serenity.DecimalEditor], ['SupplierCommissionPercentage', () => Serenity.DecimalEditor], ['TaxType', () => Serenity.EnumEditor], ['RatePercentage', () => Serenity.DecimalEditor], ['BrandTax', () => Serenity.DecimalEditor], ['SupplierRegionID', () => Serenity.IntegerEditor], ['UnitsInStock', () => Serenity.DecimalEditor], ['UnitsOnOrder', () => Serenity.DecimalEditor], ['ReorderLevel', () => Serenity.DecimalEditor], ['SupplierRef', () => Serenity.StringEditor], ['ProductImage', () => Serenity.ImageUploadEditor], ['Discontinued', () => Serenity.BooleanEditor]].forEach(x => Object.defineProperty(ProductForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}
