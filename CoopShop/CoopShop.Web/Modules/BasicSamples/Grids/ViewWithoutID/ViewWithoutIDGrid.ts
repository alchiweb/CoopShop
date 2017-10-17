namespace CoopShop.BasicSamples {
    @Serenity.Decorators.registerClass()
    export class ViewWithoutIDGrid extends Serenity.EntityGrid<DataShop.SalesByCategoryRow, any> {
        protected getColumnsKey() { return "DataShop.SalesByCategory"; }
        protected getIdProperty() { return "__id"; }
        protected getNameProperty() { return DataShop.SalesByCategoryRow.nameProperty; }
        protected getLocalTextPrefix() { return DataShop.SalesByCategoryRow.localTextPrefix; }
        protected getService() { return DataShop.SalesByCategoryService.baseUrl; }

        // this is our autoincrementing counter
        private nextId = 1; 

        constructor(container: JQuery) {
            super(container);
        }

        /**
         * This method is called to preprocess data returned from the list service
         */
        protected onViewProcessData(response: Serenity.ListResponse<DataShop.SalesByCategoryRow>) {
            response = super.onViewProcessData(response);

            // there is no __id property in SalesByCategoryRow but 
            // this is javascript and we can set any property of an object
            for (var x of response.Entities) {
                (x as any).__id = this.nextId++;
            }
            return response;
        }

        protected getButtons() {
            return [];
        }
    }
}