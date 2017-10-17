namespace CoopShop.DataShop {
    export interface BrandRow {
        BrandID?: number;
        BrandName?: string;
        Description?: string;
        Picture?: number[];
    }

    export namespace BrandRow {
        export const idProperty = 'BrandID';
        export const nameProperty = 'BrandName';
        export const localTextPrefix = 'DataShop.Brand';
        export const lookupKey = 'DataShop.Brand';

        export function getLookup(): Q.Lookup<BrandRow> {
            return Q.getLookup<BrandRow>('DataShop.Brand');
        }

        export namespace Fields {
            export declare const BrandID: string;
            export declare const BrandName: string;
            export declare const Description: string;
            export declare const Picture: string;
        }

        [
            'BrandID', 
            'BrandName', 
            'Description', 
            'Picture'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
