
using System.Linq;

namespace CoopShop.DataShop.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("DataShop"), TableName("Categories"), DisplayName("Categories"), InstanceName("Category"), TwoLevelCached]
    [ReadPermission(PermissionKeys.General)]
    [ModifyPermission(PermissionKeys.General)]
    [LookupScript("DataShop.Category")]
    [LocalizationRow(typeof(CategoryLangRow))]
    public sealed class CategoryRow : Row, IIdRow, INameRow
    {
        [DisplayName("Category Id"), Identity]
        public Int32? CategoryID
        {
            get { return Fields.CategoryID[this]; }
            set { Fields.CategoryID[this] = value; }
        }

        [DisplayName("Category Name"), Size(15), NotNull, QuickSearch]
        public String CategoryName
        {
            get { return Fields.CategoryName[this]; }
            set { Fields.CategoryName[this] = value; }
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
        [DisplayName("Tax type"), Size(20), NotNull, Updatable(true), LookupInclude]
        public TaxType? TaxType
        {
            get { return (TaxType?)Fields.TaxType[this]; }
            set { Fields.TaxType[this] = (Int32)value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.CategoryID; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CategoryName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CategoryRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field CategoryID;
            public StringField CategoryName;
            public StringField Description;
            public StreamField Picture;
            public Int32Field TaxType;

            public RowFields()
            {
                LocalTextPrefix = "DataShop.Category";
            }
        }
    }
}