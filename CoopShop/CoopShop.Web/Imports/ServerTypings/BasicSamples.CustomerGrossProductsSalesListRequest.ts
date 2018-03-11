namespace CoopShop.BasicSamples {
    export interface CustomerGrossProductsSalesListRequest extends Serenity.ListRequest {
        StartDate?: string;
        EndDate?: string;
    }
}
