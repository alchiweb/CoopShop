namespace CoopShop.DataShop {
    //import OrderRow = CoopShop.DataShop.OrderRow;
    //import OrderForm = CoopShop.DataShop.OrderForm;
    //import OrderService = CoopShop.DataShop.OrderService;

    @Serenity.Decorators.registerClass()
    //@Serenity.Decorators.panel()
    @Serenity.Decorators.maximizable(true)

    export class OrderDialog extends Serenity.EntityDialog<OrderRow, any> {
        protected getFormKey() { return OrderForm.formKey; }
        protected getIdProperty() { return OrderRow.idProperty; }
        protected getLocalTextPrefix() { return OrderRow.localTextPrefix; }
        protected getNameProperty() { return OrderRow.nameProperty; }
        protected getService() { return OrderService.baseUrl; }

        protected form = new OrderForm(this.idPrefix);
        //alchiweb
        private isInitialized: boolean = false;
        private isOrderClosed: boolean = false;

        protected beforeItemDeleted: boolean = false;
        protected beforeItemSaved: boolean = false;

        
        constructor() {
            super();
            //alchiweb
            this.form.PaymentMethod.change(e => {
                if (!this.isInitialized) {

                    ///////MODIFICATION IMPOSSIBLE
                    //var payment: boolean = $(e.target).val() != 0;
                    ///////MODIFICATION POSSIBLE
                    //var payment: boolean = false; ///////////$(e.target).val() != 0;

                    var payment: boolean = !Authorization.hasPermission("DataShop:Customer:Admin") && $(e.target).val() != 0;


                    this.isOrderClosed = payment;
                    $(e.target).prop('disabled', payment);
                    this.form.PaymentTotal.element.prop('disabled', payment);
                    this.isInitialized = true;
                }
            });
            //no more needed (cf OrderDetailDialog)
            //this.form.DetailList.element.change(
            //    e => {
            //        this.element.find('.add-button').triggerHandler("click");
            //    });
        }

        afterLoadEntity(): void {
            super.afterLoadEntity();
            this.form.CustomerID.changeSelect2(e => {
                this.element.find('.add-button').triggerHandler("click");
            });
            //bug fix
            this.form.DetailList.getItems().forEach((row) => {
                row.QuantitySymbol = ProductRow.getLookup().itemById[row.ProductID].QuantitySymbol;
            });

            $("input[name='PaymentTotal']").after("<label>&nbsp;&nbsp;Monnaie&nbsp;:&nbsp;</label><input type='text' id='monnaie' name='monnaie' value='0,00'><div id='rendu' name='rendu'>&nbsp;Rendre&nbsp;:&nbsp;0,00&nbsp;&nbsp;&nbsp;</div>");
            $("input[name='PaymentTotal']").on('change', this.calculateMonnaie);
            $("input[name='monnaie']").on('change', this.calculateMonnaie);
        }

        calculateMonnaie() {
            var payment: number = parseFloat($("input[name='PaymentTotal']").val().replace(".", "").replace(",", "."));
            if (payment === NaN)
                payment = 0;
            var monnaie = parseFloat($("input[name='monnaie']").val().replace(",", "."));
            monnaie = Math.ceil(monnaie * 100) / 100;

            var monnaieStr = monnaie.toFixed(2).replace(".", ",");
            if (monnaieStr === "NaN") {
                monnaie = 0;
                monnaieStr = "0,00";
            }
            if ($("input[name='monnaie']").val() !== monnaieStr)
                $("input[name='monnaie']").val(monnaieStr);
            var rendu:number = monnaie - payment;
            if (rendu < 0)
                rendu = 0;
            $("#rendu").html("&nbsp;Rendre&nbsp;:&nbsp;" + rendu.toFixed(2).replace(".", ","));
        }

        getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(CoopShop.Common.ReportHelper.createToolButton({
                title: 'Facture', //'Invoice',
                cssClass: 'export-pdf-button',
                reportKey: 'DataShop.OrderDetail',
                getParams: () => ({
                    OrderID: this.get_entityId()
                })
            }));

            return buttons;
        }

        protected updateInterface() {
            super.updateInterface();
            //alchiweb
            // finding all editor elements and setting their readonly attribute
            // note that this helper method only works with basic inputs, 
            // some editors require widget based set readonly overload (setReadOnly)
            Serenity.EditorUtils.setReadonly(this.element.find('.editor'), this.isOrderClosed);
//            Serenity.EditorUtils.setReadonly(this.form.PaymentMethod.element, false);
//            this.form.PaymentTotal.element.prop('disabled', false);

            // remove required asterisk (*)
            this.element.find('sup').hide();


            // here is a way to locate a button by its css class
            // note that this method is not available in 
            // getToolbarButtons() because buttons are not 
            // created there yet!
            // 
            // this.toolbar.findButton('delete-button').hide();

            // entity dialog also has reference variables to
            // its default buttons, lets use them to hide delete button
            //this.deleteButton.hide();

            // we could also hide save buttons just like delete button,
            // but they are null now as we removed them in getToolbarButtons()
            // if we didn't we could write like this:
            // 
            this.saveAndCloseButton.toggleClass('disabled', this.isOrderClosed);

//            this.applyChangesButton.toggleClass('disabled', this.isOrderClosed);
            this.applyChangesButton.hide();


            //this.toolbar.findButton('save-and-close-button').toggle(!this.isOrderClosed);
            // instead of hiding, we could disable a button
            // 
            this.deleteButton.toggleClass('disabled', this.isOrderClosed);


            this.toolbar.findButton('export-pdf-button').toggle(this.isOrderClosed);

            if (!this.isOrderClosed)
                this.element.find('.grid-toolbar').show();
            else
                this.element.find('.grid-toolbar').hide();
            
            this.element.find('.add-button').toggleClass('disabled', this.isOrderClosed);

            //this.toolbar.findButton('export-pdf-button').toggle(this.isEditMode());
        }
        deleteHandler(options: Q.ServiceOptions<Serenity.DeleteResponse>,
            callback: (response: Serenity.DeleteResponse) => void): void {
            this.beforeItemDeleted = true;
            super.deleteHandler(options, callback);
        }

        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>,
            callback: (response: Serenity.SaveResponse) => void): void {
            console.log("saveHandler");
            this.beforeItemSaved = true;
            super.saveHandler(options, callback);
        }

        protected getDialogOptions(): JQueryUI.DialogOptions {
            var opt: JQueryUI.DialogOptions = super.getDialogOptions();

            opt.beforeClose = (event, ui) => {
                var itemBeingDeleted: boolean = this.beforeItemDeleted;
                if (this.beforeItemDeleted)
                    this.beforeItemDeleted = false;
                var itemBeingSaved: boolean = this.beforeItemSaved;
                if (this.beforeItemSaved)
                    this.beforeItemSaved = false;
                if (!this.isOrderClosed && !itemBeingDeleted && !itemBeingSaved && this.form.DetailList.getItems().length > 0) {
                    Q.confirm("Quitter cette vente SANS LA SAUVEGARDER ?", () => { this.onDialogClose(); }, { modal: true });
                    return false;
                }
                return true;
            };
            return opt;
        }
    }
}