/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace CoopShop.DataShop {
    //import Select2Extensions = Serenity.Select2Extensions;

    @Serenity.Decorators.registerClass()
    export class OrderDetailDialog extends Common.GridEditorDialog<OrderDetailRow> {
        protected getFormKey() { return OrderDetailForm.formKey; }
        protected getLocalTextPrefix() { return OrderDetailRow.localTextPrefix; }

        protected form: OrderDetailForm;
        protected savedItem: boolean;

        afterLoadEntity(): void {
            super.afterLoadEntity();
            this.updateProduct();
            this.element.bind('dialogclose', () =>  this.savedItem = false );   // before 'click' on saveCloseButton
            this.saveAndCloseButton.bind("click", () => this.savedItem = true); // after 'dialogClose'
            //this.changePrice();
        }


//note needed        validateBeforeSave(): boolean { return (this.savedItem = this.validateForm()); }
 
        destroy(): void {
            if (this.savedItem && this.isNew())
                $(".s-OrderDetailsEditor").change();
        }

        constructor() {
            super();
            this.form = new OrderDetailForm(this.idPrefix);
            this.form.ProductID.changeSelect2(e => {
                this.updateProduct();
            });

            //alchiweb
            this.form.InternalRef.changeSelect2(e => {
                var tabItems: Array<ProductRow> = ProductRow.getLookup().items
                    .filter(e => e.InternalRef === this.form.InternalRef.value);
                if (tabItems.length >= 1) {
                    this.form.ProductID.value = tabItems[0].ProductID.toString();
                    this.form.UnitPrice.value = tabItems[0].UnitPrice;
                    this.form.QuantitySymbol.value = tabItems[0].QuantitySymbol.toString();

                    this.changePrice();
                }

            });

            this.form.UnitPrice.changeSelect2(e => {
                this.changePrice();
            });



            this.form.Discount.addValidationRule(this.uniqueName, e => {
                var price = this.form.UnitPrice.value;
                var quantity = this.form.Quantity.value;
                var discount = this.form.Discount.value;
                if (price != null && quantity != null && discount != null &&
                    discount > 0 && discount >= price * quantity) {
                    return "Discount can't be higher than total price!";
                }
            });

        }

        updateProduct() {
            var productID = Q.toId(this.form.ProductID.value);
            if (productID != null) {
                //alchiweb
                //this.form.UnitPrice.value = ProductRow.getLookup().itemById[productID].UnitPrice;
                var currentProduct: ProductRow = ProductRow.getLookup().itemById[productID];
                this.form.UnitPrice.value = currentProduct.UnitPrice;
                this.form.InternalRef.value = currentProduct.InternalRef;
                this.form.QuantitySymbol.value = currentProduct.QuantitySymbol.toString();
                this.changePrice();
            }
            else //alchiweb
            if (this.form.InternalRef.value !== "")
                this.form.InternalRef.value = "";
        }
        changePrice() {
            if (this.form != null) {
                var productID = Q.toId(this.form.ProductID.value);
                if (productID != null) {
                    var productRow = ProductRow.getLookup().itemById[productID];
                    this.form.QuantityPerUnitPrice.value = this.form.UnitPrice.value / productRow.QuantityPerUnit;
                    this.form.QuantityPerUnitPrice.element.parent().children("label")
                        .text("Prix / " + QuantitySymbolType[productRow.QuantitySymbol]);
                }
            }
        }
    }
}