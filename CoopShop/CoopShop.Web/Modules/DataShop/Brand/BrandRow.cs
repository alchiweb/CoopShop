
namespace CoopShop.DataShop.Entities
{

    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("DataShop"), TableName("Brands"), DisplayName("Brands"), InstanceName("Brand"), TwoLevelCached]
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    [LookupScript("DataShop.Brand")]
    [LocalizationRow(typeof(BrandLangRow))]
    public sealed class BrandRow : Row, IIdRow, INameRow
    {
        [DisplayName("Brand Id"), Identity]
        public Int32? BrandID
        {
            get { return Fields.BrandID[this]; }
            set { Fields.BrandID[this] = value; }
        }

        [DisplayName("Brand Name"), Size(15), NotNull, QuickSearch]
        public String BrandName
        {
            get { return Fields.BrandName[this]; }
            set { Fields.BrandName[this] = value; }
        }

        [DisplayName("Description"), QuickSearch]
        public String Description
        {
            get { return Fields.Description[this]; }
            set { Fields.Description[this] = value; }
        }

        [DisplayName("Picture")]
        public Stream Picture
        {
            get { return Fields.Picture[this]; }
            set { Fields.Picture[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.BrandID; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.BrandName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public BrandRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field BrandID;
            public StringField BrandName;
            public StringField Description;
            public StreamField Picture;

            public RowFields()
            {
                LocalTextPrefix = "DataShop.Brand";
            }
        }
    }
}