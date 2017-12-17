namespace CoopShop.DataShop {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class CustomerDialog extends Serenity.EntityDialog<CustomerRow, any> {
        protected getFormKey() { return CustomerForm.formKey; }
        protected getIdProperty() { return CustomerRow.idProperty; }
        protected getLocalTextPrefix() { return CustomerRow.localTextPrefix; }
        protected getNameProperty() { return CustomerRow.nameProperty; }
        protected getService() { return CustomerService.baseUrl; }

        protected form = new CustomerForm(this.idPrefix);

        private ordersGrid: CustomerOrdersGrid;
        private loadedState: string;

        constructor() {
            super();

            this.ordersGrid = new CustomerOrdersGrid(this.byId('OrdersGrid'));
            // force order dialog to open in Dialog mode instead of Panel mode
            // which is set as default on OrderDialog with @panelAttribute
            this.ordersGrid.openDialogsAsPanel = false; 
            $("input[name='ContactTitle']").on('change', this.generateId);
            $("input[name='ContactName']").on('change', this.generateId);

            this.byId('NoteList').closest('.field').hide().end().appendTo(this.byId('TabNotes'));
            DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);
        }
        sansAccent() {
            var accent = [
                /[\300-\306]/g, /[\340-\346]/g, // A, a
                /[\310-\313]/g, /[\350-\353]/g, // E, e
                /[\314-\317]/g, /[\354-\357]/g, // I, i
                /[\322-\330]/g, /[\362-\370]/g, // O, o
                /[\331-\334]/g, /[\371-\374]/g, // U, u
                /[\321]/g, /[\361]/g, // N, n
                /[\307]/g, /[\347]/g, // C, c
            ];
            var noaccent = ['A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'N', 'n', 'C', 'c'];

            var str = this;
            for (var i = 0; i < accent.length; i++) {
                str = str.replace(accent[i], noaccent[i]);
            }

            return str;
        }
        generateId() {
            var firstName = $("input[name='ContactTitle']").val();
            var lastName = $("input[name='ContactName']").val();
            $("input[name='CompanyName']").val(firstName + ((firstName !== '' || lastName !== '') ? " " : "") + lastName);
            firstName = firstName.toLowerCase().replace(/[\+\- \'\"\.]/g, '');
            lastName = lastName.toLowerCase().replace(/[-\/\\^$*+?.()|[\]{}]/g, '');
            $("input[name='CustomerID']").val(firstName + ((firstName !== '' || lastName !== '') ? "." : "") + lastName);
            
        }

        getSaveState() {
            try {
                return $.toJSON(this.getSaveEntity());
            }
            catch (e) {
                return null;
            }
        }

        loadResponse(data) {
            super.loadResponse(data);
            this.loadedState = this.getSaveState();
        }

        loadEntity(entity: CustomerRow) {
            super.loadEntity(entity);

            Serenity.TabsExtensions.setDisabled(this.tabs, 'Orders', this.isNewOrDeleted());

            this.ordersGrid.customerID = entity.CustomerID;
        }

        onSaveSuccess(response) {
            super.onSaveSuccess(response);

            Q.reloadLookup('DataShop.Customer');
        }
    }
}