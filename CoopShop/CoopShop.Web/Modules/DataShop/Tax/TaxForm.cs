
using System.ComponentModel;

namespace CoopShop.DataShop.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("DataShop.Tax")]
    [BasedOnRow(typeof(Entities.TaxRow))]
    public class TaxForm
    {
        public Int32 TaxID { get; set; }
        public String TaxDescription { get; set; }
        [LookupEditor(typeof(Entities.RegionRow))]
        public Int32 RegionID { get; set; }
        [DefaultValue(1)]
        public String RatePercentage { get; set; }
        [DefaultValue("now")]
        public DateTime OfficialDate { get; set; }
    }
}