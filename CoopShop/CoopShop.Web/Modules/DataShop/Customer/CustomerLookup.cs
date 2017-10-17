
namespace CoopShop.DataShop.Scripts
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Web;
    using Serenity.Data;

    [LookupScript("DataShop.Customer")]
    public class CustomerLookup : RowLookupScript<CustomerRow>
    {
        public CustomerLookup()
        {
            IdField = CustomerRow.Fields.CustomerID.PropertyName;
            TextField = CustomerRow.Fields.CompanyName.PropertyName;
        }
        //alchiweb
        protected override void PrepareQuery(SqlQuery query)
        {
            var fld = CustomerRow.Fields;
            query.Select(fld.CustomerID, fld.IsCoop, fld.CompanyName).WhereEqual(fld.IsCoop, true);
        }
    }
}