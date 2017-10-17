/// <reference path="../../../DataShop/Category/CategoryGrid.ts" />

namespace CoopShop.BasicSamples {

    /**
     * Subclass of CategoryGrid to override dialog type to GetInsertedRecordIdDialog
     */
    @Serenity.Decorators.registerClass()
    export class GetInsertedRecordIdGrid extends DataShop.CategoryGrid {

        protected getDialogType() { return GetInsertedRecordIdDialog; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}