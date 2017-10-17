/// <reference path="../../../DataShop/Product/ProductGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Subclass of ProductGrid to override dialog type to CloneableEntityDialog
     */
    @Serenity.Decorators.registerClass()
    export class CloneableEntityGrid extends DataShop.ProductGrid {

        protected getDialogType() { return CloneableEntityDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}