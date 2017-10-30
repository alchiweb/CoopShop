namespace CoopShop.DataShop {

    export interface Select2LookupEditorOptions extends Serenity.LookupEditorOptions {
/*        width?: any;
        minimumInputLength?: number;
        maximumInputLength?: number;
        minimumResultsForSearch?: number;
        maximumSelectionSize?: any;
        placeHolder?: string;
        placeHolderOption?: any;
        separator?: string;
        allowClear?: boolean;
        multiple?: boolean;
        closeOnSelect?: boolean;
        openOnEnter?: boolean;
        id?: (p1: any) => string;
        matcher?: (p1: string, p2: string, p3: JQuery) => boolean;
        sortResults?: (p1: any, p2: JQuery, p3: any) => any;
        formatSelection?: (p1: any, p2: JQuery, p3: (p1: string) => string) => string;
        formatResult?: (p1: any, p2: JQuery, p3: any, p4: (p1: string) => string) => string;
        formatResultCssClass?: (p1: any) => string;
        formatNoMatches?: (p1: string) => string;
        formatSearching?: () => string;
        formatInputTooShort?: (p1: string, p2: number) => string;
        formatSelectionTooBig?: (p1: string) => string;
        createSearchChoice?: (p1: string) => any;
        createSearchChoicePosition?: string;
        initSelection?: (p1: JQuery, p2: (p1: any) => void) => void;
        tokenizer?: (p1: string, p2: any, p3: (p1: any) => any, p4: any) => string;
        tokenSeparators?: any;
        query?: (p1: Select2QueryOptions) => void;
        ajax?: Select2AjaxOptions;
        data?: any;
        tags?: any;
        containerCss?: any;
        containerCssClass?: any;
        dropdownCss?: any;
        dropdownCssClass?: any;
        dropdownAutoWidth?: boolean;
        adaptContainerCssClass?: (p1: string) => string;
        adaptDropdownCssClass?: (p1: string) => string;
        escapeMarkup?: (p1: string) => string;
        selectOnBlur?: boolean;
        loadMorePadding?: number;
        nextSearchTerm?: (p1: any, p2: string) => string;
        */
    }

    @Serenity.Decorators.registerEditor()
    export class ProductEditor extends Serenity.LookupEditorBase<Select2LookupEditorOptions, ProductRow> {

        constructor(hidden: JQuery, opt: Select2LookupEditorOptions) {
            
            //$Serenity_Select2Editor.call(this, hidden, opt);
//            hidden.add("div").addClass("widget");
//            var pdiv = hidden.add("div");
//            opt.inplaceAdd = true;
            super(hidden, opt);
//            this.options.openOnEnter = true;

//            this.addOption('open', 'true');
//            hidden.click();
            hidden.on('change', 'input', (e) => this.inputsChange(e));

        }



        private inputsChange(e: JQueryEventObject) {
        }

        protected getLookupKey() {
            return 'DataShop.Product';
        }
        /*
        protected getTemplate() {
            return (
                "<form id='~_Form' class='s-Form'>" +
                "<textarea id='~_Text' class='required'></textarea>" +
                "</form>");
        }

        */

        protected getItems(lookup: Q.Lookup<ProductRow>) {
            var txt_lookup: string = "";
                for (var $t1 = 0; $t1 < lookup.items.length; $t1++) {
                    var item = lookup.items[$t1];
                    var textValue = item[lookup.textField];
                    txt_lookup = textValue;
//                    console.log("-:" + this.filterValue + "|");
            }
//            console.log(lookup.te + "/" + lookup.idField);
                return lookup.items.filter((x,index) =>
                    x.Discontinued !== true /*&& x.UnitsInStock > 0*/ && x.ProductID !== index);
        }

        protected getItemText(item, lookup) {
            return (item.CategoryName === undefined ? "" : (item.CategoryName + ' - ')) + super.getItemText(item, lookup) + ((item.BrandName === undefined || item.BrandID === 2094) ? "" :  (' (' + item.BrandName+')')); // + (item.InternalRef != undefined ? ' [' + item.InternalRef + ']' : '');
        }


        protected getItemDisabled(item, lookup) {
            return item.Discontinued/* || item.UnitsInStock <= 0*/;
        }
    }
}