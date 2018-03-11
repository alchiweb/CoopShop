namespace CoopShop.BasicSamples {
    export namespace CustomerGrossProductsSalesService {
        export const baseUrl = 'BasicSamples/CustomerGrossProductsSales';

        export declare function List(request: CustomerGrossProductsSalesListRequest, onSuccess?: (response: Serenity.ListResponse<DataShop.CustomerGrossProductsSalesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export namespace Methods {
            export declare const List: string;
        }

        [
            'List'
        ].forEach(x => {
            (<any>CustomerGrossProductsSalesService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
            (<any>Methods)[x] = baseUrl + '/' + x;
        });
    }
}
