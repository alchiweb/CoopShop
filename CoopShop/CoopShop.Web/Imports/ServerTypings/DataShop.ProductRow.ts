namespace CoopShop.DataShop {
    export interface ProductRow {
        ProductID?: number;
        ProductName?: string;
        ProductImage?: string;
        Discontinued?: boolean;
        SupplierID?: number;
        CategoryID?: number;
        BrandID?: number;
        QuantityPerUnit?: number;
        SoldQuantity?: number;
        UnitPrice?: number;
        BuyingPrice?: number;
        UnitsInStock?: number;
        UnitsOnOrder?: number;
        ReorderLevel?: number;
        SupplierCompanyName?: string;
        SupplierContactName?: string;
        SupplierContactTitle?: string;
        SupplierAddress?: string;
        SupplierCity?: string;
        SupplierRegion?: string;
        SupplierPostalCode?: string;
        SupplierCountry?: string;
        SupplierPhone?: string;
        SupplierFax?: string;
        SupplierHomePage?: string;
        SupplierCommissionPercentage?: number;
        CategoryName?: string;
        CategoryDescription?: string;
        CategoryPicture?: number[];
        BrandName?: string;
        BrandDescription?: string;
        BrandPicture?: number[];
        QuantitySymbol?: QuantitySymbolType;
        InternalRef?: string;
        SupplierRef?: string;
    }

    export namespace ProductRow {
        export const idProperty = 'ProductID';
        export const nameProperty = 'ProductName';
        export const localTextPrefix = 'DataShop.Product';
        export const lookupKey = 'DataShop.Product';

        export function getLookup(): Q.Lookup<ProductRow> {
            return Q.getLookup<ProductRow>('DataShop.Product');
        }

        export namespace Fields {
            export declare const ProductID: string;
            export declare const ProductName: string;
            export declare const ProductImage: string;
            export declare const Discontinued: string;
            export declare const SupplierID: string;
            export declare const CategoryID: string;
            export declare const BrandID: string;
            export declare const QuantityPerUnit: string;
            export declare const SoldQuantity: string;
            export declare const UnitPrice: string;
            export declare const BuyingPrice: string;
            export declare const UnitsInStock: string;
            export declare const UnitsOnOrder: string;
            export declare const ReorderLevel: string;
            export declare const SupplierCompanyName: string;
            export declare const SupplierContactName: string;
            export declare const SupplierContactTitle: string;
            export declare const SupplierAddress: string;
            export declare const SupplierCity: string;
            export declare const SupplierRegion: string;
            export declare const SupplierPostalCode: string;
            export declare const SupplierCountry: string;
            export declare const SupplierPhone: string;
            export declare const SupplierFax: string;
            export declare const SupplierHomePage: string;
            export declare const SupplierCommissionPercentage: string;
            export declare const CategoryName: string;
            export declare const CategoryDescription: string;
            export declare const CategoryPicture: string;
            export declare const BrandName: string;
            export declare const BrandDescription: string;
            export declare const BrandPicture: string;
            export declare const QuantitySymbol: string;
            export declare const InternalRef: string;
            export declare const SupplierRef: string;
        }

        [
            'ProductID', 
            'ProductName', 
            'ProductImage', 
            'Discontinued', 
            'SupplierID', 
            'CategoryID', 
            'BrandID', 
            'QuantityPerUnit', 
            'SoldQuantity', 
            'UnitPrice', 
            'BuyingPrice', 
            'UnitsInStock', 
            'UnitsOnOrder', 
            'ReorderLevel', 
            'SupplierCompanyName', 
            'SupplierContactName', 
            'SupplierContactTitle', 
            'SupplierAddress', 
            'SupplierCity', 
            'SupplierRegion', 
            'SupplierPostalCode', 
            'SupplierCountry', 
            'SupplierPhone', 
            'SupplierFax', 
            'SupplierHomePage', 
            'SupplierCommissionPercentage', 
            'CategoryName', 
            'CategoryDescription', 
            'CategoryPicture', 
            'BrandName', 
            'BrandDescription', 
            'BrandPicture', 
            'QuantitySymbol', 
            'InternalRef', 
            'SupplierRef'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
