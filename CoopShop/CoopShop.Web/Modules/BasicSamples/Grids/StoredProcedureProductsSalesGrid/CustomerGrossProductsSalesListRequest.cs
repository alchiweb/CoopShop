namespace CoopShop.BasicSamples
{
    using Serenity.Services;
    using System;

    public class CustomerGrossProductsSalesListRequest : ListRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}