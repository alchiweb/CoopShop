/// <reference path="../../../DataShop/Order/OrderGrid.ts" />

namespace CoopShop.BasicSamples {

    @Serenity.Decorators.registerClass()
    export class DefaultValuesInNewGrid extends DataShop.OrderGrid {

        constructor(container: JQuery) {
            super(container);
        }

        /**
         * This method is called when New Item button is clicked.
         * By default, it calls EditItem with an empty entity.
         * This is a good place to fill in default values for New Item button.
         */
        protected addButtonClick() {
            this.editItem(<DataShop.OrderRow>{
                CustomerID: 'ANTON',
                RequiredDate: Q.formatDate(new Date(), 'yyyy-MM-dd'),
                EmployeeID: DataShop.EmployeeRow.getLookup().items
                    .filter(x => x.FullName === 'Robert King')[0].EmployeeID,
                ShipVia: DataShop.ShipperRow.getLookup().items
                    .filter(x => x.CompanyName === 'Speedy Express')[0].ShipperID
            });
        }

        protected getButtons() {
            // preserving default New Item button
            var buttons = super.getButtons();

            buttons.push({
                title: 'Add Order from the Queen',
                cssClass: 'add-button', 
                onClick: () => {
                    // using EditItem method as a shortcut to create a new Order dialog,
                    // bind to its events, load our order row, and open dialog
                    this.editItem(<DataShop.OrderRow>{
                        CustomerID: 'QUEEN',
                        EmployeeID: DataShop.EmployeeRow.getLookup().items
                            .filter(x => x.FullName === 'Nancy Davolio')[0].EmployeeID,
                        ShipVia: DataShop.ShipperRow.getLookup().items
                            .filter(x => x.CompanyName === 'United Package')[0].ShipperID
                    });
                }
            });

            buttons.push({
                title: 'Add Order with 5 Chai by Laura', cssClass: 'add-note-button',
                onClick: () => {
                    // we could use EditItem here too, but for demonstration
                    // purposes we are manually creating dialog this time
                    var dlg = new DataShop.OrderDialog();

                    // let grid watch for changes to manually created dialog, 
                    // so when a new item is saved, grid can refresh itself
                    this.initDialog(dlg);

                    // get a reference to product Chai
                    var chai = DataShop.ProductRow.getLookup().items
                        .filter(x => x.ProductName === 'Chai')[0];

                    // LoadEntityAndOpenDialog, loads an OrderRow 
                    // to dialog and opens it
                    var lauraCallahanID = DataShop.EmployeeRow.getLookup().items
                        .filter(x => x.FullName === 'Laura Callahan')[0].EmployeeID;

                    dlg.loadEntityAndOpenDialog(<DataShop.OrderRow>{
                        CustomerID: 'GOURL',
                        EmployeeID: lauraCallahanID,
                        DetailList: [{
                            ProductID: chai.ProductID,
                            ProductName: chai.ProductName,
                            UnitPrice: chai.UnitPrice,
                            Quantity: 5,
                            LineTotal: chai.UnitPrice * 5
                        }]
                    });
                }
            });

            return buttons;
        }
    }
}