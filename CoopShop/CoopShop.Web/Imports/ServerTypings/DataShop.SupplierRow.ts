namespace CoopShop.DataShop {
    export interface SupplierRow {
        SupplierID?: number;
        CompanyName?: string;
        ContactName?: string;
        ContactTitle?: string;
        Address?: string;
        City?: string;
        Region?: string;
        PostalCode?: string;
        Country?: string;
        Phone?: string;
        Fax?: string;
        HomePage?: string;
        CommissionPercentage?: number;
    }

    export namespace SupplierRow {
        export const idProperty = 'SupplierID';
        export const nameProperty = 'CompanyName';
        export const localTextPrefix = 'DataShop.Supplier';
        export const lookupKey = 'DataShop.Supplier';

        export function getLookup(): Q.Lookup<SupplierRow> {
            return Q.getLookup<SupplierRow>('DataShop.Supplier');
        }

        export namespace Fields {
            export declare const SupplierID: string;
            export declare const CompanyName: string;
            export declare const ContactName: string;
            export declare const ContactTitle: string;
            export declare const Address: string;
            export declare const City: string;
            export declare const Region: string;
            export declare const PostalCode: string;
            export declare const Country: string;
            export declare const Phone: string;
            export declare const Fax: string;
            export declare const HomePage: string;
            export declare const CommissionPercentage: string;
        }

        [
            'SupplierID', 
            'CompanyName', 
            'ContactName', 
            'ContactTitle', 
            'Address', 
            'City', 
            'Region', 
            'PostalCode', 
            'Country', 
            'Phone', 
            'Fax', 
            'HomePage', 
            'CommissionPercentage'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
