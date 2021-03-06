/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Subclass of OrderGrid to override dialog type to OtherFormInTabOneBarDialog
     */
    @Serenity.Decorators.registerClass()
    export class OtherFormInTabOneBarGrid extends DataShop.OrderGrid {

        protected getDialogType() { return OtherFormOneBarDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}