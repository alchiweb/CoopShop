namespace CoopShop.DataShop {
    export interface ProductLogRow {
        ProductLogID?: number;
        OperationType?: Serenity.CaptureOperationType;
        ChangingUserId?: number;
        ValidFrom?: string;
        ValidUntil?: string;
        ProductID?: number;
        ProductName?: string;
        ProductImage?: string;
        Discontinued?: boolean;
        SupplierID?: number;
        CategoryID?: number;
        BrandID?: number;
        QuantityPerUnit?: number;
        UnitPrice?: number;
        BuyingPrice?: number;
        UnitsInStock?: number;
        UnitsOnOrder?: number;
        ReorderLevel?: number;
        QuantitySymbol?: number;
        InternalRef?: string;
        SupplierRef?: string;
    }

    export namespace ProductLogRow {
        export const idProperty = 'ProductLogID';
        export const localTextPrefix = 'DataShop.ProductLog';

        export namespace Fields {
            export declare const ProductLogID: string;
            export declare const OperationType: string;
            export declare const ChangingUserId: string;
            export declare const ValidFrom: string;
            export declare const ValidUntil: string;
            export declare const ProductID: string;
            export declare const ProductName: string;
            export declare const ProductImage: string;
            export declare const Discontinued: string;
            export declare const SupplierID: string;
            export declare const CategoryID: string;
            export declare const BrandID: string;
            export declare const QuantityPerUnit: string;
            export declare const UnitPrice: string;
            export declare const BuyingPrice: string;
            export declare const UnitsInStock: string;
            export declare const UnitsOnOrder: string;
            export declare const ReorderLevel: string;
            export declare const QuantitySymbol: string;
            export declare const InternalRef: string;
            export declare const SupplierRef: string;
        }

        [
            'ProductLogID', 
            'OperationType', 
            'ChangingUserId', 
            'ValidFrom', 
            'ValidUntil', 
            'ProductID', 
            'ProductName', 
            'ProductImage', 
            'Discontinued', 
            'SupplierID', 
            'CategoryID', 
            'BrandID', 
            'QuantityPerUnit', 
            'UnitPrice', 
            'BuyingPrice', 
            'UnitsInStock', 
            'UnitsOnOrder', 
            'ReorderLevel', 
            'QuantitySymbol', 
            'InternalRef', 
            'SupplierRef'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
