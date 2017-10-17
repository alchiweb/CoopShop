/// <reference path="../../../DataShop/Customer/CustomerGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Subclass of CustomerGrid to override dialog type to SerialAutoNumberDialog
     */
    @Serenity.Decorators.registerClass()
    export class SerialAutoNumberGrid extends DataShop.CustomerGrid {

        protected getDialogType() { return SerialAutoNumberDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}