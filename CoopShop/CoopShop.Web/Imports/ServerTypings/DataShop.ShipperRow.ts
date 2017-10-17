namespace CoopShop.DataShop {
    export interface ShipperRow {
        ShipperID?: number;
        CompanyName?: string;
        Phone?: string;
    }

    export namespace ShipperRow {
        export const idProperty = 'ShipperID';
        export const nameProperty = 'CompanyName';
        export const localTextPrefix = 'DataShop.Shipper';
        export const lookupKey = 'DataShop.Shipper';

        export function getLookup(): Q.Lookup<ShipperRow> {
            return Q.getLookup<ShipperRow>('DataShop.Shipper');
        }

        export namespace Fields {
            export declare const ShipperID: string;
            export declare const CompanyName: string;
            export declare const Phone: string;
        }

        [
            'ShipperID', 
            'CompanyName', 
            'Phone'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
