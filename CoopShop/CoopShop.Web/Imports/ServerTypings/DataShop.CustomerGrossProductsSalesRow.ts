namespace CoopShop.DataShop {
    export interface CustomerGrossProductsSalesRow {
        ProductName?: string;
        SalesTotal?: number;
        QuantityTotal?: number;
        GrossAmount?: number;
    }

    export namespace CustomerGrossProductsSalesRow {
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'BasicSamples.GrossProductsSales';

        export namespace Fields {
            export declare const ProductName: string;
            export declare const SalesTotal: string;
            export declare const QuantityTotal: string;
            export declare const GrossAmount: string;
        }

        [
            'ProductName', 
            'SalesTotal', 
            'QuantityTotal', 
            'GrossAmount'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
