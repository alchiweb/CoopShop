/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Subclass of OrderGrid to override dialog type to FilteredLookupInDetailDialog
     */
    @Serenity.Decorators.registerClass()
    export class FilteredLookupInDetailGrid extends DataShop.OrderGrid {

        protected getDialogType() { return FilteredLookupInDetailDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}