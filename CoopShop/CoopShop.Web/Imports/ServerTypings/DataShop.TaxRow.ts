namespace CoopShop.DataShop {
    export interface TaxRow {
        ID?: number;
        TaxID?: TaxType;
        TaxDescription?: string;
        RegionID?: number;
        RegionDescription?: string;
        OfficialDate?: string;
        RatePercentage?: number;
    }

    export namespace TaxRow {
        export const idProperty = 'ID';
        export const nameProperty = 'TaxDescription';
        export const localTextPrefix = 'DataShop.Tax';
        export const lookupKey = 'DataShop.Tax';

        export function getLookup(): Q.Lookup<TaxRow> {
            return Q.getLookup<TaxRow>('DataShop.Tax');
        }

        export namespace Fields {
            export declare const ID: string;
            export declare const TaxID: string;
            export declare const TaxDescription: string;
            export declare const RegionID: string;
            export declare const RegionDescription: string;
            export declare const OfficialDate: string;
            export declare const RatePercentage: string;
        }

        [
            'ID', 
            'TaxID', 
            'TaxDescription', 
            'RegionID', 
            'RegionDescription', 
            'OfficialDate', 
            'RatePercentage'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
