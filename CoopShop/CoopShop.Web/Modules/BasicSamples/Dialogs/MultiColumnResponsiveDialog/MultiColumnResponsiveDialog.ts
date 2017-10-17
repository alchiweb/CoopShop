/// <reference path="../../../DataShop/Order/OrderDialog.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Styling for columns is done with CSS in site.basicsamples.less file.
     * When comparing this to MultiColumnDialog sample, you may notice that
     * this version requires much less JS and CSS code.
     */
    @Serenity.Decorators.registerClass()
    export class MultiColumnResponsiveDialog extends DataShop.OrderDialog {

        constructor() {
            super();
        }
    }
}