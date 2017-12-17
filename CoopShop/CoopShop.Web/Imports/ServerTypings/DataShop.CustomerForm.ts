namespace CoopShop.DataShop {
    export class CustomerForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.Customer';

    }

    export interface CustomerForm {
        IsCoop: Serenity.BooleanEditor;
        ContactTitle: Serenity.StringEditor;
        ContactName: Serenity.StringEditor;
        CompanyName: Serenity.StringEditor;
        CustomerID: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        SendBulletin: Serenity.BooleanEditor;
        Address: Serenity.StringEditor;
        PostalCode: Serenity.StringEditor;
        City: Serenity.StringEditor;
        Country: Serenity.StringEditor;
        Phone: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        NoteList: NotesEditor;
    }

    [['IsCoop', () => Serenity.BooleanEditor], ['ContactTitle', () => Serenity.StringEditor], ['ContactName', () => Serenity.StringEditor], ['CompanyName', () => Serenity.StringEditor], ['CustomerID', () => Serenity.StringEditor], ['Email', () => Serenity.StringEditor], ['SendBulletin', () => Serenity.BooleanEditor], ['Address', () => Serenity.StringEditor], ['PostalCode', () => Serenity.StringEditor], ['City', () => Serenity.StringEditor], ['Country', () => Serenity.StringEditor], ['Phone', () => Serenity.StringEditor], ['Fax', () => Serenity.StringEditor], ['NoteList', () => NotesEditor]].forEach(x => Object.defineProperty(CustomerForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}
