
namespace CoopShop.DataShop.Entities
{

    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("DataShop"), DisplayName("BrandLang"), InstanceName("BrandLang"), TwoLevelCached]
    [ReadPermission("DataShop:General")]
    [ModifyPermission("DataShop:General")]
    public sealed class BrandLangRow : Row, IIdRow, INameRow, ILocalizationRow
    {
        [DisplayName("Id"), Column("ID"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Brand Id"), Column("BrandID"), NotNull]
        public Int32? BrandId
        {
            get { return Fields.BrandId[this]; }
            set { Fields.BrandId[this] = value; }
        }

        [DisplayName("Language Id"), Column("LanguageID"), NotNull]
        public Int32? LanguageId
        {
            get { return Fields.LanguageId[this]; }
            set { Fields.LanguageId[this] = value; }
        }

        [DisplayName("Brand Name"), Size(15), QuickSearch]
        public String BrandName
        {
            get { return Fields.BrandName[this]; }
            set { Fields.BrandName[this] = value; }
        }

        [DisplayName("Description")]
        public String Description
        {
            get { return Fields.Description[this]; }
            set { Fields.Description[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.BrandName; }
        }

        public Field CultureIdField
        {
            get { return Fields.LanguageId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public BrandLangRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field BrandId;
            public Int32Field LanguageId;
            public StringField BrandName;
            public StringField Description;

            public RowFields()
                : base("BrandLang")
            {
                LocalTextPrefix = "DataShop.BrandLang";
            }
        }
    }
}