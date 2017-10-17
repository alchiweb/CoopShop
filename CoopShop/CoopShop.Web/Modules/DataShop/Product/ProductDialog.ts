namespace CoopShop.DataShop {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.maximizable()
    export class ProductDialog extends Serenity.EntityDialog<ProductRow, any> {
        protected getFormKey() { return ProductForm.formKey; }
        protected getIdProperty() { return ProductRow.idProperty; }
        protected getLocalTextPrefix() { return ProductRow.localTextPrefix; }
        protected getNameProperty() { return ProductRow.nameProperty; }
        protected getService() { return ProductService.baseUrl; }

        protected form = new ProductForm(this.idPrefix);

        //alchiweb
        constructor() {
            super();


            //this.form.PaymentMethod.element.change(x => console.log($(x.target).val()));
            this.form.SupplierID.change(e => {
                if (this.form.SupplierID.value !== "") {
                    var com = SupplierRow.getLookup().itemById[this.form.SupplierID.value].CommissionPercentage;
                    this.form.SupplierCommissionPercentage.element.val(com.toString().replace(".", ","));
                    if (this.form.BuyingPrice.element != undefined)
                        this.validateBuyingPrice(this.form.BuyingPrice.element);
                }
            });
        }

        //alchiweb
        protected updateInterface() {
            //            this.form = new ProductForm(this.idPrefix);
            // by default cloneButton is hidden in base UpdateInterface method
            super.updateInterface();
            // here we show it if it is edit mode (not new)
            this.cloneButton.toggle(this.isEditMode());
            //  console.log(this.idPrefix);

            //this.byId(this.idPrefix + 'BuyingPrice').on('change', 'input', ((e) => console.log("Change!!!")));
            //this.byId(this.idPrefix + 'ProductName').val('test2');
            this.form.BuyingPrice.addValidationRule(this.uniqueName, this.validateBuyingPrice);

            this.form.QuantityPerUnit.addValidationRule(this.uniqueName, e => {
                if (this.form.QuantityPerUnit.value <= 0) {
                    return Q.text('Doit être supérieur à 0 (par défaut : 1) !');
                }
            });
        }

        //alchiweb
        private validateBuyingPrice(priceInput: JQuery): string {

            var text = Q.coalesce(Q.trimToNull(priceInput.val()), '0');
            var value = Q.parseDecimal(text);

            if (isNaN(value)) {
                return Q.text('Validation.BuyingPrice');
            }
            else {
                //                this.form.
                var commPerc = parseFloat(priceInput.closest(".category").find("input[name='SupplierCommissionPercentage']").val().replace(",", "."));
                if (commPerc === 0.)
                    value = 0;

                if (value > 0) {

                    priceInput.closest(".category").find("input[name='UnitPrice']").val((Math.ceil(value * (1. + commPerc) * 10.0) / 10.0).toString().replace(".", ","));
                }
                //                this.byId(this.idPrefix + 'UnitPrice').val(value * .78);

            }
        }

        /**
         * Overriding this method is optional to customize cloned entity
         */
        protected getCloningEntity() {
            var clone = super.getCloningEntity();

            // add (Clone) suffix if it's not already added
            var suffix = ' (Clone)';
            if (!Q.endsWith(clone.ProductName || '', suffix)) {
                clone.ProductName = (clone.ProductName || '') + suffix;
            }

            // it's better to clear image for this sample
            // otherwise we would have to create a temporary copy of it
            // and upload
            clone.ProductImage = null;

            // let's clear fields not logical to be cloned
            clone.UnitsInStock = 0;
            clone.UnitsOnOrder = 0;
            return clone;
        }
    }
}