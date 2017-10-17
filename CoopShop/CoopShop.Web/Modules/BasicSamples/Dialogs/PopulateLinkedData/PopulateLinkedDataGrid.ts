/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * A subclass of OrderGrid that launches PopulateLinkedDataDialog
     */
    @Serenity.Decorators.registerClass()
    export class PopulateLinkedDataGrid extends DataShop.OrderGrid {

        protected getDialogType() { return PopulateLinkedDataDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}