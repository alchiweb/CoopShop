/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Subclass of OrderGrid to override dialog type to OtherFormInTabDialog
     */
    @Serenity.Decorators.registerClass()
    export class OtherFormInTabGrid extends DataShop.OrderGrid {

        protected getDialogType() { return OtherFormInTabDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}