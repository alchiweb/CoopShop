

namespace CoopShop.DataShop.Repositories
{
    using System.Text.RegularExpressions;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using MyRow = Entities.CustomerRow;

    public class CustomerRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public UndeleteResponse Undelete(IUnitOfWork uow, UndeleteRequest request)
        {
            return new MyUndeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        public GetNextNumberResponse GetNextNumber(IDbConnection connection, GetNextNumberRequest request)
        {
            return GetNextNumberHelper.GetNextNumber(connection, request, fld.CustomerID);
        }

        //alchiweb private class MySaveHandler : SaveRequestHandler<MyRow> { }

        private class MySaveHandler : SaveRequestHandler<MyRow>
        {

            protected override void ValidateRequest()
            {
                base.ValidateRequest();
                if (IsUpdate)
                {
                    if (Row.CustomerID != Old.CustomerID)
                        Row.CustomerID = MySaveHandler.ValidateCustomerID(this.Connection, Row.CustomerID, Old.ID.Value);
                }

                if (IsCreate)
                {
                    this.Row.CustomerID = ValidateCustomerID(this.Connection, this.Row.CustomerID, null);
                }
            }

            private static bool IsValidCustomerID(string name)
            {
                return new Regex("^[a-z|A-Z|0-9|\\.]+$").IsMatch(name);
            }

            private static string ValidateCustomerID(IDbConnection connection, string customerId, Int32? existingId)
            {
                customerId = customerId.TrimToNull();

                if (customerId == null)
                    throw DataValidation.RequiredError(fld.CustomerID.Name, fld.CustomerID.Title);

                if (!IsValidCustomerID(customerId))
                    throw new ValidationError("InvalidCustomerID", "CustomerID",
                        "CustomerIDs only contain letters and numbers!");

                var existing = GetCustomer(connection,
                    new Criteria(fld.CustomerID) == customerId);

                if (existing != null && existingId != existing.ID)
                    throw new ValidationError("UniqueViolation", "Username",
                        "A user with same name exists. Please choose another!");

                return customerId;
            }

            private static MyRow GetCustomer(IDbConnection connection, BaseCriteria filter)
            {
                var row = new MyRow();
                if (new SqlQuery().From(row)
                    .Select(
                        fld.ID,
                        fld.CustomerID)
                    .Where(filter)
                    .GetFirst(connection))
                {
                    return row;
                }

                return null;
            }
        }

        private class MyDeleteHandler : DeleteRequestHandler<MyRow>
        {
            protected override void ExecuteDelete()
            {
                try
                {
                    base.ExecuteDelete();
                }
                catch (Exception e)
                {
                    SqlExceptionHelper.HandleDeleteForeignKeyException(e);
                    throw;
                }
            }
        }

        private class MyUndeleteHandler : UndeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}