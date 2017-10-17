namespace CoopShop.DataShop {
    export interface RegionRow {
        RegionID?: number;
        RegionDescription?: string;
    }

    export namespace RegionRow {
        export const idProperty = 'RegionID';
        export const nameProperty = 'RegionDescription';
        export const localTextPrefix = 'DataShop.Region';
        export const lookupKey = 'DataShop.Region';

        export function getLookup(): Q.Lookup<RegionRow> {
            return Q.getLookup<RegionRow>('DataShop.Region');
        }

        export namespace Fields {
            export declare const RegionID: string;
            export declare const RegionDescription: string;
        }

        [
            'RegionID', 
            'RegionDescription'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
