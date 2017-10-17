/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Subclass of OrderGrid to override dialog type to MultiColumnResponsiveDialog
     */
    @Serenity.Decorators.registerClass()
    export class MultiColumnResponsiveGrid extends DataShop.OrderGrid {

        protected getDialogType() { return MultiColumnResponsiveDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}