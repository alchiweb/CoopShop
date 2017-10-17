namespace CoopShop.DataShop {
    export class CustomerForm extends Serenity.PrefixedContext {
        static formKey = 'DataShop.Customer';

    }

    export interface CustomerForm {
        IsCoop: Serenity.BooleanEditor;
        CustomerID: Serenity.StringEditor;
        ContactTitle: Serenity.StringEditor;
        ContactName: Serenity.StringEditor;
        CompanyName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        SendBulletin: Serenity.BooleanEditor;
        Address: Serenity.StringEditor;
        PostalCode: Serenity.StringEditor;
        City: Serenity.LookupEditor;
        Country: Serenity.LookupEditor;
        Phone: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        NoteList: NotesEditor;
    }

    [['IsCoop', () => Serenity.BooleanEditor], ['CustomerID', () => Serenity.StringEditor], ['ContactTitle', () => Serenity.StringEditor], ['ContactName', () => Serenity.StringEditor], ['CompanyName', () => Serenity.StringEditor], ['Email', () => Serenity.EmailEditor], ['SendBulletin', () => Serenity.BooleanEditor], ['Address', () => Serenity.StringEditor], ['PostalCode', () => Serenity.StringEditor], ['City', () => Serenity.LookupEditor], ['Country', () => Serenity.LookupEditor], ['Phone', () => Serenity.StringEditor], ['Fax', () => Serenity.StringEditor], ['NoteList', () => NotesEditor]].forEach(x => Object.defineProperty(CustomerForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}
