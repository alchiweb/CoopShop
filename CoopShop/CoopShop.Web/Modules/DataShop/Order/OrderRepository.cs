﻿

namespace CoopShop.DataShop.Repositories
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using MyRow = Entities.OrderRow;

    public class OrderRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            //alchiweb
            if (request.Entity.PaymentMethod != PaymentMethodType.NotPayed)
                UpdateStock(uow, request);

            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        //alchiweb
        private static void UpdateStock(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            var productFields = Entities.ProductRow.Fields;
            var errorTxt = "";
            foreach (var orderDetail in request.Entity.DetailList)
            {
                bool productError = false;
                try
                {
                    productError = !new SqlQuery().From(productFields)
                        .Select(productFields.ProductID, productFields.UnitsInStock)
                        .WhereEqual(productFields.ProductID, orderDetail.ProductID)
                        .Where(new Criteria(productFields.UnitsInStock) >= (Single) orderDetail.Quantity.Value)
                        .Exists(uow.Connection);
                }
                catch (Exception ex)
                {
                    errorTxt += $"Erreur produit \"{orderDetail.ProductName}\" : {ex.Message}.\n";
                }
                if (productError)
                    errorTxt += $"Erreur produit \"{orderDetail.ProductName}\" : le stock est insuffisant.\n";
            }
            if (!string.IsNullOrEmpty(errorTxt))
                throw (new Exception(errorTxt));

            var updatedProducts = "";
            foreach (var orderDetail in request.Entity.DetailList)
            {
                try {
                    new SqlUpdate(productFields.TableName)
                        .SetTo(productFields.UnitsInStock.Name, productFields.UnitsInStock.Name + (orderDetail.Quantity.Value < 0 ? " + " : " - ") + orderDetail.Quantity.Value.ToString(CultureInfo.InvariantCulture))
                        //                        .Dec(productFields.UnitsInStock, orderDetail.Quantity.Value)
                        .WhereEqual(productFields.ProductID, orderDetail.ProductID)
                        .Execute(uow.Connection, ExpectedRows.One);
                    updatedProducts += "\"{orderDetail.ProductName}\" ";
                }
                catch (Exception ex)
                {
                    var errorMsg = $"Erreur mise à jour produit \"{orderDetail.ProductName}\" : {ex.Message}.\n";
                    if (ex.InnerException != null)
                    {
                        errorMsg += $"{ex.InnerException.Message}.\n";
                        if (ex.InnerException.InnerException != null)
                        {
                            errorMsg += $"{ex.InnerException.InnerException.Message}.\n";
                        }
                    }
                    if (!string.IsNullOrEmpty(updatedProducts))
                        errorMsg += $"ATTENTION : le stock des produits {updatedProducts} est déjà calculé !\n";
                    throw (new Exception(errorMsg, ex));
                }

            }
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            //alchiweb
            var orderFields = MyRow.Fields;

            var oldPaymentMethod = PaymentMethodType.NotPayed;
            try
            {
                oldPaymentMethod = uow.Connection.Query<PaymentMethodType>(new SqlQuery()
                        .From(orderFields)
                        .Select(orderFields.PaymentMethod)
                        .Where(new Criteria(orderFields.OrderID) == request.Entity.OrderID.Value))
                    .First();
            }
            catch (Exception) { }

            if (request.Entity.PaymentMethod != PaymentMethodType.NotPayed && oldPaymentMethod == PaymentMethodType.NotPayed)
                UpdateStock(uow, request);

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

        public ListResponse<MyRow> List(IDbConnection connection, OrderListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyUndeleteHandler : UndeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }

        private class MyListHandler : ListRequestHandler<MyRow, OrderListRequest>
        {
            protected override void ApplyFilters(SqlQuery query)
            {
                base.ApplyFilters(query);

                if (Request.ProductID != null)
                {
                    var od = Entities.OrderDetailRow.Fields.As("od");

                    query.Where(Criteria.Exists(
                        query.SubQuery()
                            .Select("1")
                            .From(od)
                            .Where(
                                od.OrderID == fld.OrderID &
                                od.ProductID == Request.ProductID.Value)
                            .ToString()));
                }
            }
        }
    }
}