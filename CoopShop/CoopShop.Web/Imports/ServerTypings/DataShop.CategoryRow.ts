namespace CoopShop.DataShop {
    export interface CategoryRow {
        CategoryID?: number;
        CategoryName?: string;
        Description?: string;
        Picture?: number[];
        TaxType?: TaxType;
    }

    export namespace CategoryRow {
        export const idProperty = 'CategoryID';
        export const nameProperty = 'CategoryName';
        export const localTextPrefix = 'DataShop.Category';
        export const lookupKey = 'DataShop.Category';

        export function getLookup(): Q.Lookup<CategoryRow> {
            return Q.getLookup<CategoryRow>('DataShop.Category');
        }

        export namespace Fields {
            export declare const CategoryID: string;
            export declare const CategoryName: string;
            export declare const Description: string;
            export declare const Picture: string;
            export declare const TaxType: string;
        }

        [
            'CategoryID', 
            'CategoryName', 
            'Description', 
            'Picture', 
            'TaxType'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
