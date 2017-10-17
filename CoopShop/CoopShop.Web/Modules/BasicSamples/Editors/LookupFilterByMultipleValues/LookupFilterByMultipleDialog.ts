/// <reference path="../../../DataShop/Product/ProductDialog.ts" />

namespace CoopShop.BasicSamples {

    /**
     * This is our custom product dialog that uses a different product form
     * (LookupFilterByMultipleForm) with our special category editor.
     */
    @Serenity.Decorators.registerClass()
    export class LookupFilterByMultipleDialog extends DataShop.ProductDialog {

        protected getFormKey() { return LookupFilterByMultipleForm.formKey; }
    }
}