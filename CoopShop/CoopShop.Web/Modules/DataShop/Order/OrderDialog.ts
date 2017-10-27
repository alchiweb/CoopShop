namespace CoopShop.DataShop {
    //import OrderRow = CoopShop.DataShop.OrderRow;
    //import OrderForm = CoopShop.DataShop.OrderForm;
    //import OrderService = CoopShop.DataShop.OrderService;

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
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

        constructor() {
            super();
            //alchiweb
            this.form.PaymentMethod.change(e => {
                if (!this.isInitialized) {
                    ///////MODIFICATION POSSIBLE
                    var payment: boolean = false; ///////////$(e.target).val() != 0;
                    this.isOrderClosed = payment;
                    $(e.target).prop('disabled', payment);
                    this.form.PaymentTotal.element.prop('disabled', payment);
                    this.isInitialized = true;
                }
            });
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
            this.applyChangesButton.toggleClass('disabled', this.isOrderClosed);
            this.saveAndCloseButton.toggleClass('disabled', this.isOrderClosed);
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
    }
}