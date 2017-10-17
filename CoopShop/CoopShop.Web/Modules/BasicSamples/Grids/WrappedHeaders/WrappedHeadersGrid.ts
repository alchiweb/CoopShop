/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    @Serenity.Decorators.registerClass()
    export class WrappedHeadersGrid extends DataShop.OrderGrid {

        constructor(container: JQuery) {
            super(container);
        }
    }
}