/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace CoopShop.DataShop {
    //import Select2Extensions = Serenity.Select2Extensions;

    @Serenity.Decorators.registerClass()
    export class OrderDetailDialog extends Common.GridEditorDialog<OrderDetailRow> {
        protected getFormKey() { return OrderDetailForm.formKey; }
        protected getLocalTextPrefix() { return OrderDetailRow.localTextPrefix; }

        protected form: OrderDetailForm;
        protected beforeItemDeleted: boolean = false;
        protected savedItem: boolean = false;
        protected savedItemSuccess: boolean = false;

        afterLoadEntity(): void {
            super.afterLoadEntity();
            this.updateProduct();

            this.saveAndCloseButton.bind("click", () => {
                console.log("click saveandclose savedItem: " + this.savedItem + " - savedItemSuccess : " + this.savedItemSuccess);
                if (this.savedItem && this.savedItemSuccess) {
                    // clear all the fields for the new product
                    this.form.ProductID.value = "";
                    this.updateProduct();
                    this.form.InternalRef.element.focus();
                }

                this.savedItem = false;
                this.savedItemSuccess = false;
            }); // after 'dialogClose'

            //this.changePrice();
        }

        deleteHandler(options: Q.ServiceOptions<Serenity.DeleteResponse>,
            callback: (response: Serenity.DeleteResponse) => void): void {
            this.beforeItemDeleted = true;
            super.deleteHandler(options, callback);
        }

        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>,
            callback: (response: Serenity.SaveResponse) => void): void {
            console.log("saveHandler");
            this.savedItem = true;
            super.saveHandler(options, callback);
        }

        protected getDialogOptions(): JQueryUI.DialogOptions {
            var opt: JQueryUI.DialogOptions = super.getDialogOptions();

            opt.beforeClose = (event, ui) => {
                var itemBeingDeleted: boolean = this.beforeItemDeleted;
                if (this.beforeItemDeleted)
                    this.beforeItemDeleted = false;

                if (!this.savedItem) {
                    if (!itemBeingDeleted && this.form.ProductID.value !== "") {
                        Q.confirm("Quitter l'ajout d'un produit SANS SAUVEGARDER CE PRODUIT ?", () => { this.onDialogClose(); }, { modal: true });
                        return false;
                    }
                } else {
                    if (this.isNew()) {
                        this.savedItemSuccess = true;
                        return false;
                    }
                }
                return true;
            };
            return opt;
        }


//note needed        validateBeforeSave(): boolean { return (this.savedItem = this.validateForm()); }

// no more needed -> in order to add a new product window...
        //destroy(): void {
        //    if (this.savedItem && this.isNew())
        //        $(".s-OrderDetailsEditor").change();
        //}

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
            } else { //alchiweb
                if (this.form.InternalRef.value !== "")
                    this.form.InternalRef.value = "";
                this.form.ProductID.value = "";
                this.form.Quantity.value = 1;
                this.form.QuantitySymbol.value = null;
                this.form.Discount.value = null;
                this.form.QuantityPerUnitPrice.value = null;
                this.form.UnitPrice.value = null;
            }
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