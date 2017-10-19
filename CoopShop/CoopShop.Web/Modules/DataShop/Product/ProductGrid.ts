namespace CoopShop.DataShop {
    //import ProductRow = CoopShop.DataShop.ProductRow;
    //import ProductDialog = CoopShop.DataShop.ProductDialog;
    //import CategoryRow = CoopShop.DataShop.CategoryRow;
    //import BrandRow = CoopShop.DataShop.BrandRow;
    //import SupplierRow = CoopShop.DataShop.SupplierRow;
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class ProductGrid extends Serenity.EntityGrid<ProductRow, any> {
        protected getColumnsKey() { return "DataShop.Product"; }
        protected getDialogType() { return <any>ProductDialog; }
        protected getIdProperty() { return ProductRow.idProperty; }
        protected getLocalTextPrefix() { return ProductRow.localTextPrefix; }
        protected getService() { return ProductService.baseUrl; }

        private pendingChanges: Q.Dictionary<any> = {};

        //alchiweb
        private numericPrecision = '0.##';
        private numeric2Precision = '0.###';
        private searchText: string;

        constructor(container: JQuery) {
            super(container);

            //alchiweb
            this.slickContainer.on('change', 'select', e => {
                if (!e.target.classList.contains('edit')) {
                    var cell = this.slickGrid.getCellFromEvent(e);
                    if (!cell)
                        return;
                    var item = this.itemAt(cell.row);
                    var field = this.slickGrid.getColumns()[cell.cell].field;
                    item[field] = Q.toId($(e.target).val());

                    var pending = this.pendingChanges[item.ProductID];

                    this.pendingChanges[item.ProductID] = item;
                    this.setSaveButtonState();

                    if (!e.target.classList.contains('dirty'))
                        e.target.classList.add('dirty');

                }
            });

            this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));

        }

        protected getButtons()
        {
            var buttons = super.getButtons();

            buttons.push(Common.ExcelExportHelper.createToolButton({
                grid: this,
                service: ProductService.baseUrl + '/ListExcel',
                onViewSubmit: () => this.onViewSubmit(),
                separator: true
            }));

            buttons.push(Common.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                reportTitle: 'Product List',
                columnTitles: {
                    'Discontinued': 'Dis.',
                },
                tableOptions: {
                    columnStyles: {
                        ProductID: {
                            columnWidth: 25,
                            halign: 'right'
                        },
                        Discountinued: {
                            columnWidth: 25
                        }
                    }
                }
            }));

            buttons.push({
                title: 'Enregister les changements', //'Save Changes',
                cssClass: 'apply-changes-button disabled',
                onClick: e => this.saveClick(),
                separator: true
            });

            return buttons;
        }

        protected onViewProcessData(response) {
            this.pendingChanges = {};
            this.setSaveButtonState();
            return super.onViewProcessData(response);
        }

        // PLEASE NOTE! Inline editing in grids is not something Serenity supports nor recommends.
        // SlickGrid has some set of limitations, UI is very hard to use on some devices like mobile, 
        // custom widgets and validations are not possible, and as a bonus the code can become a mess.
        // 
        // This was just a sample how-to after much requests, and is not supported. 
        // This is all we can offer, please don't ask us to Guide you...

        /**
         * It would be nice if we could use autonumeric, Serenity editors etc. here, to control input validation,
         * but it's not supported by SlickGrid as we are only allowed to return a string, and should attach
         * no event handlers to rendered cell contents
         */
        //alchiweb: modif (add numericClass)
        private numericInputFormatter(ctx, numericClass = 'numeric') {
            var klass = 'edit ' + numericClass;
            var item = ctx.item as ProductRow;
            var pending = this.pendingChanges[item.ProductID];

            if (pending && pending[ctx.column.field] !== undefined) {
                klass += ' dirty';
            }

            var value = this.getEffectiveValue(item, ctx.column.field) as number;

            return "<input type='text' class='" + klass + 
                "' data-field='" + ctx.column.field + 

                //"' value='" + Q.formatNumber(value, '0.##') + "'/>";
                "' value='" + Q.formatNumber(value, numericClass == 'numeric' ? this.numericPrecision : this.numeric2Precision) + "'/>";

        }

        private stringInputFormatter(ctx) {
            var klass = 'edit string';
            var item = ctx.item as ProductRow;
            var pending = this.pendingChanges[item.ProductID];
            var column = ctx.column as Slick.Column;

            if (pending && pending[column.field] !== undefined) {
                klass += ' dirty';
            }

            var value = this.getEffectiveValue(item, column.field) as string;

            return "<input type='text' class='" + klass +
                "' data-field='" + column.field + 
                "' value='" + Q.htmlEncode(value) + 
                "' maxlength='" + column.sourceItem.maxLength + "'/>";
        }

        /**
         * Sorry but you cannot use LookupEditor, e.g. Select2 here, only possible is a SELECT element
         */
        private selectFormatter(ctx: Slick.FormatterContext, idField: string, lookup: Q.Lookup<any>) {
            var fld = ProductRow.Fields;
            var klass = 'edit';
            var item = ctx.item as ProductRow;
            var pending = this.pendingChanges[item.ProductID];
            var column = ctx.column as Slick.Column;

            if (pending && pending[idField] !== undefined) {
                klass += ' dirty';
            }

            var value = this.getEffectiveValue(item, idField);
            var markup = "<select class='" + klass +
                "' data-field='" + idField + 
                "' style='width: 100%; max-width: 100%'>";
            if (lookup != null) { //alchiweb
                for (var c of lookup.items) {
                    let id = c[lookup.idField];
                    markup += "<option value='" + id + "'"
                    if (id == value) {
                        markup += " selected";
                    }
                    markup += ">" + Q.htmlEncode(c[lookup.textField]) + "</option>";
                }
            }
            return markup + "</select>";
        }

        private getEffectiveValue(item, field): any {
            var pending = this.pendingChanges[item.ProductID];
            if (pending && pending[field] !== undefined) {
                return pending[field];
            }

            return item[field];
        }

        protected getColumns() {
            var columns = super.getColumns();
            var num = ctx => this.numericInputFormatter(ctx);
            var numMorePrecise = ctx => this.numericInputFormatter(ctx, 'numeric2'); //alchiweb
            var str = ctx => this.stringInputFormatter(ctx);
            var fld = ProductRow.Fields;

            //alchiweb
            //Q.first(columns, x => x.field === 'QuantityPerUnit').format = str;

            var category = Q.first(columns, x => x.field === fld.CategoryName);
            category.referencedFields = [fld.CategoryID];
            category.format = ctx => this.selectFormatter(ctx, fld.CategoryID, CategoryRow.getLookup());

            //alchiweb
            var brand = Q.first(columns, x => x.field === fld.BrandName);
            brand.referencedFields = [fld.BrandID];
            brand.format = ctx => this.selectFormatter(ctx, fld.BrandID, BrandRow.getLookup());

            var supplier = Q.first(columns, x => x.field === fld.SupplierCompanyName);
            supplier.referencedFields = [fld.SupplierID];
            supplier.format = ctx => this.selectFormatter(ctx, fld.SupplierID, SupplierRow.getLookup());

            Q.first(columns, x => x.field === fld.QuantityPerUnit).format = numMorePrecise;

            Q.first(columns, x => x.field === fld.UnitPrice).format = num;
            Q.first(columns, x => x.field === fld.UnitsInStock).format = num;
            Q.first(columns, x => x.field === fld.UnitsOnOrder).format = num;
            Q.first(columns, x => x.field === fld.ReorderLevel).format = num;

            //alchiweb
            Q.first(columns, x => x.field === fld.BuyingPrice).format = num;
            Q.first(columns, x => x.field === fld.InternalRef).format = str;

            return columns;
        }

        private inputsChange(e: JQueryEventObject) {
            var cell = this.slickGrid.getCellFromEvent(e);
            var item = this.itemAt(cell.row);
            var input = $(e.target);
            var field = input.data('field');
            //alchiweb: TODO
            //var text = Q.coalesce(Q.trimToNull(input.val()), '0');
            var text = Q.coalesce(Q.trimToNull(input.val()), '0').replace(".", ",");

            var pending = this.pendingChanges[item.ProductID];

            var effective = this.getEffectiveValue(item, field);
            var oldText: string;
            if (input.hasClass("numeric") || input.hasClass("numeric2")) //alchiweb
                //oldText = Q.formatNumber(effective, '0.##');
                oldText = Q.formatNumber(effective, input.hasClass("numeric") ? this.numericPrecision : this.numeric2Precision);
            else
                oldText = effective as string;
            if (!pending) {
                this.pendingChanges[item.ProductID] = pending = {};
            }
            var value;
            if (field === 'BuyingPrice' || field === 'UnitPrice' || field === 'QuantityPerUnit') {
                value = Q.parseDecimal(text);
                if (value == null || isNaN(value)) {
                    Q.notifyError(Q.text('Validation.Decimal'), '', null);
                    input.val(oldText);
                    input.focus();
                    return;
                } else {
                    if (field === 'BuyingPrice') {
                        this.updatePrice(input, pending, item);
                    }

                }
            }
            //if (field === 'UnitPrice') {
            //    value = Q.parseDecimal(text);
            //    if (value == null || isNaN(value)) {
            //        Q.notifyError(Q.text('Validation.Decimal'), '', null);
            //        input.val(oldText);
            //        input.focus();
            //        return;
            //    }
            //}
            else if (input.hasClass("numeric")) {
                var i = Q.parseInteger(text);
                if (isNaN(i) || i > 32767 || i < 0) {
                    Q.notifyError(Q.text('Validation.Integer'), '', null);
                    input.val(oldText);
                    input.focus();
                    return;
                }
                value = i;
            }
            else
                value = text;

            //alchiweb
            if (field === "SupplierID") {
                var sup = SupplierRow.getLookup().itemById[value].CommissionPercentage;
                var inputBuyingPrice = input.closest(".slick-row").find("input[data-field='BuyingPrice']");

                inputBuyingPrice.parent().next().text(sup.toString().replace(".", ","));
                this.updatePrice(inputBuyingPrice, pending, item);
                item['SupplierCommissionPercentage'] = sup;

            }



            pending[field] = value;
            item[field] = value;
            this.view.refresh();

            if (input.hasClass("numeric") || input.hasClass("numeric2"))
                value = Q.formatNumber(value, input.hasClass("numeric") ? this.numericPrecision : this.numeric2Precision);

            //if (input.hasClass("numeric"))
            //    value = Q.formatNumber(value, '0.##');

            input.val(value).addClass('dirty');

            this.setSaveButtonState();
        }

        //alchiweb
        private updatePrice(inputBuyingPrice, pending, item) {
            var inputUnitPrice = inputBuyingPrice.closest(".slick-row").find("input[data-field='UnitPrice']");
            var commPerc = parseFloat(inputBuyingPrice.parent().next().text().replace(",", "."));
            var fieldUnitPrice = inputUnitPrice.data('field');
            var valuePrice: number = 0;

            if (commPerc !== 0.)
                valuePrice = Math.ceil(parseFloat(inputBuyingPrice.val().replace(",", ".")) * (1. + commPerc) * 10.0) / 10.0;

            if (valuePrice > 0) {
                var stringPrice = valuePrice.toString().replace(".", ",");
                inputUnitPrice.val(stringPrice).addClass('dirty');
                pending[fieldUnitPrice] = valuePrice;
                item[fieldUnitPrice] = valuePrice;
            }
        }

        private setSaveButtonState() {
            this.toolbar.findButton('apply-changes-button').toggleClass('disabled',
                Object.keys(this.pendingChanges).length === 0);
        }

        private saveClick() {
            if (Object.keys(this.pendingChanges).length === 0) {
                return;
            }

            // this calls save service for all modified rows, one by one
            // you could write a batch update service
            var keys = Object.keys(this.pendingChanges);
            var current = -1;
            var self = this;

            (function saveNext() {
                if (++current >= keys.length) {
                    self.refresh();
                    return;
                }

                var key = keys[current];
                var entity = Q.deepClone(self.pendingChanges[key]);
                entity.ProductID = key;
                Q.serviceRequest('DataShop/Product/Update', {
                    EntityId: key,
                    Entity: entity
                }, (response) => {
                    delete self.pendingChanges[key];
                    saveNext();
                });
            })();
        }

        protected getQuickFilters() {
            var flt = super.getQuickFilters();

            var q = Q.parseQueryString();
            if (q["cat"]) {
                var category = Q.tryFirst(flt, x => x.field == "CategoryID");
                category.init = e => {
//                    e.element.getWidget(Serenity.LookupEditor).value = q["cat"];
                    e.element.getWidget(Serenity.LookupEditor).value = q["cat"].toLowerCase();
                };
            }
            if (q["brand"]) {
                var brand = Q.tryFirst(flt, x => x.field == "BrandID");
                brand.init = e => {
                    e.element.getWidget(Serenity.LookupEditor).value = q["brand"].toLowerCase();
                };
            }
            return flt;
        }

        //alchiweb
        protected usePager() {
            return true;//false;
        }

        //alchiweb
        protected getViewOptions(): Slick.RemoteViewOptions {
            var slickRemoteViewOptions: Slick.RemoteViewOptions = super.getViewOptions();
            slickRemoteViewOptions.rowsPerPage = 2500;
            return slickRemoteViewOptions;
        }

    }
}
