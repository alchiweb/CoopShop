namespace CoopShop.DataShop {
    export interface OrderDetailRow {
        DetailID?: number;
        OrderID?: number;
        ProductID?: number;
        UnitPrice?: number;
        Quantity?: number;
        Discount?: number;
        UnitsInStock?: number;
        ProductName?: string;
        QuantityPerUnit?: number;
        LineTotal?: number;
        QuantityPerUnitPrice?: number;
        QuantitySymbol?: QuantitySymbolType;
        CategoryID?: number;
        BrandID?: number;
        CategoryName?: string;
        BrandName?: string;
    }

    export namespace OrderDetailRow {
        export const idProperty = 'DetailID';
        export const localTextPrefix = 'DataShop.OrderDetail';

        export namespace Fields {
            export declare const DetailID: string;
            export declare const OrderID: string;
            export declare const ProductID: string;
            export declare const UnitPrice: string;
            export declare const Quantity: string;
            export declare const Discount: string;
            export declare const UnitsInStock: string;
            export declare const ProductName: string;
            export declare const QuantityPerUnit: string;
            export declare const LineTotal: string;
            export declare const QuantityPerUnitPrice: string;
            export declare const QuantitySymbol: string;
            export declare const CategoryID: string;
            export declare const BrandID: string;
            export declare const CategoryName: string;
            export declare const BrandName: string;
        }

        [
            'DetailID', 
            'OrderID', 
            'ProductID', 
            'UnitPrice', 
            'Quantity', 
            'Discount', 
            'UnitsInStock', 
            'ProductName', 
            'QuantityPerUnit', 
            'LineTotal', 
            'QuantityPerUnitPrice', 
            'QuantitySymbol', 
            'CategoryID', 
            'BrandID', 
            'CategoryName', 
            'BrandName'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
