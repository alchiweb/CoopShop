/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace CoopShop.DataShop {

    @Serenity.Decorators.registerClass()
    export class OrderDetailsEditor extends Common.GridEditorBase<OrderDetailRow> {
        protected getColumnsKey() { return "DataShop.OrderDetail"; }
        protected getDialogType() { return OrderDetailDialog; }
        protected getLocalTextPrefix() { return OrderDetailRow.localTextPrefix; }

        //alchiweb
        parentContainer;

        constructor(container: JQuery) {
            super(container);
            //alchiweb
            this.parentContainer = container;


//            this.getItems().forEach(x => { x.QuantitySymbol = QuantitySymbolType.Litre; });
        }

        protected editItem(entityOrId: any): void {

            var readonly: boolean = $("input[name='PaymentTotal']").prop('disabled');

            if (readonly) {
                var id = entityOrId;
                var item = this.view.getItemById(id);
                this.createEntityDialog(this.getItemType(),
                    dlg => {
                        var dialog = dlg as OrderDetailDialog; //Common.GridEditorDialog<OrderDetailRow>;
                        //dialog.onDelete = (opt, callback) => {
                        //    if (!this.deleteEntity(id)) {
                        //        return;
                        //    }
                        //    callback({});
                        //};

                        //dialog.onSave = (opt, callback) => this.save(opt, callback);
                        dialog.loadEntityAndOpenDialog(item);
                        dialog.makeReadOnly();
//                Serenity.EditorUtils.setReadonly(dialog.element, true);

                    });
            }
            else
                super.editItem(entityOrId);
        }




        protected deleteEntity(id) {
            var result = super.deleteEntity(id);
            this.setPaymentTotal(this.view.getItems());
            return result;
        }

        protected setEntities(items) {
            super.setEntities(items);
            this.setPaymentTotal(items);

        }


        private setPaymentTotal(items) {
            if (!$("input[name='PaymentTotal']").prop('disabled')) {
                var currentLanguage = Q.coalesce($.cookie("LanguagePreference"), 'en');

                var newTotal: number = 0;
                items.forEach(orderDetailRow => {
                    newTotal += orderDetailRow.LineTotal;
                });

                newTotal = Math.ceil(newTotal * 20)/20;

                $("input[name='PaymentTotal']").val(newTotal.toLocaleString(currentLanguage)).focus().off("focus");
                $("input[name='PaymentTotal']").change();
            }
        }


        validateEntity(row, id) {

            //alchiweb
            //row.ProductID = Q.toId(row.ProductID);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.ProductID === row.ProductID);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This product is already in order details!');
            //    return false;
            //}

            //row.ProductName = ProductRow.getLookup().itemById[row.ProductID].ProductName;
            //row.LineTotal = (row.Quantity || 0) * (row.UnitPrice || 0) - (row.Discount || 0);

            var allDetailItems = this.view.getItems();
            row.ProductID = Q.toId(row.ProductID);
//            row.getLookup.ProductName;
            var sameProduct = Q.tryFirst(allDetailItems, x => x.ProductID === row.ProductID);
            if (sameProduct && this.id(sameProduct) !== id) {
                Q.alert('This product is already in order details!');
                return false;
            }

            var currentProduct: ProductRow = ProductRow.getLookup().itemById[row.ProductID];

            row.ProductName = currentProduct.CategoryName + ' - ' + currentProduct.ProductName + ' ('+ currentProduct.BrandName + ')';
            row.LineTotal = (row.Quantity || 0) * (row.UnitPrice || 0) - (row.Discount || 0);
            row.LineTotal = Math.ceil(row.LineTotal * 100) / 100;
//            row.QuantityPerUnit = 1;
            row.QuantitySymbol = ProductRow.getLookup().itemById[row.ProductID].QuantitySymbol;

            return true;
        }
    }
}