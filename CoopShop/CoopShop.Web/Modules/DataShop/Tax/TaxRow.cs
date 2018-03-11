

namespace CoopShop.DataShop.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("DataShop"), TableName("Taxes"), DisplayName("Taxes"), InstanceName("Tax"), TwoLevelCached]
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    [LookupScript("DataShop.Tax")]
    public sealed class TaxRow : Row, IIdRow, INameRow
    {
        [DisplayName("ID"), Identity]
        public Int32? ID
        {
            get { return Fields.ID[this]; }
            set { Fields.ID[this] = value; }
        }

        [DisplayName("Tax ID"), Size(20), PrimaryKey, NotNull, QuickSearch, Updatable(true)]
        public TaxType? TaxID
        {
            get { return (TaxType?)Fields.TaxID[this]; }
            set { Fields.TaxID[this] = (Int32)value; }
        }


        [DisplayName("Tax Description"), Size(50), NotNull, QuickSearch, LookupInclude]
        public String TaxDescription
        {
            get { return Fields.TaxDescription[this]; }
            set { Fields.TaxDescription[this] = value; }
        }

        [DisplayName("Region"), NotNull, ForeignKey(typeof(RegionRow)), LeftJoin("jRegion")]
        public Int32? RegionID
        {
            get { return Fields.RegionID[this]; }
            set { Fields.RegionID[this] = value; }
        }

        [Origin("jRegion"), DisplayName("Region"), QuickSearch, LookupInclude]
        public String RegionDescription
        {
            get { return Fields.RegionDescription[this]; }
            set { Fields.RegionDescription[this] = value; }
        }

        [DisplayName("Offical Date"), NotNull]
        public DateTime? OfficialDate
        {
            get { return Fields.OfficialDate[this]; }
            set { Fields.OfficialDate[this] = value; }
        }

        [DisplayName("Rate (percentage)"), LookupInclude]
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "999999999.99")]
        public Single? RatePercentage
        {
            get { return Fields.RatePercentage[this]; }
            set { Fields.RatePercentage[this] = value; }
        }
        IIdField IIdRow.IdField
        {
            get { return Fields.ID; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TaxDescription; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TaxRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ID;
            public Int32Field TaxID;
            public StringField TaxDescription;
            public Int32Field RegionID;

            public StringField RegionDescription;
            public DateTimeField OfficialDate;
            public SingleField RatePercentage;

            public RowFields()
            {
                LocalTextPrefix = "DataShop.Tax";
            }
        }
    }
}