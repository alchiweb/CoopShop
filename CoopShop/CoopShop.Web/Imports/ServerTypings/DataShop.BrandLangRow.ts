namespace CoopShop.DataShop {
    export interface BrandLangRow {
        Id?: number;
        BrandId?: number;
        LanguageId?: number;
        BrandName?: string;
        Description?: string;
    }

    export namespace BrandLangRow {
        export const idProperty = 'Id';
        export const nameProperty = 'BrandName';
        export const localTextPrefix = 'DataShop.BrandLang';

        export namespace Fields {
            export declare const Id: string;
            export declare const BrandId: string;
            export declare const LanguageId: string;
            export declare const BrandName: string;
            export declare const Description: string;
        }

        [
            'Id', 
            'BrandId', 
            'LanguageId', 
            'BrandName', 
            'Description'
        ].forEach(x => (<any>Fields)[x] = x);
    }
}
