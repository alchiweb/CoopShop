/// <reference path="../../../DataShop/Order/OrderDialog.ts" />

namespace CoopShop.BasicSamples {

    /**
     * A version of order dialog converted to a panel by adding Serenity.Decorators.panel decorator.
     */
    @Serenity.Decorators.panel()
    export class EntityDialogAsPanel extends DataShop.OrderDialog {

        constructor() {
            super();

            this.element.addClass('flex-layout');

        }
    }
}