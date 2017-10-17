using FluentMigrator;

namespace CoopShop.Migrations.DataShopDB
{
    [Migration(20141123155100)]
    public class DefaultDB_20141123_155100_Initial : Migration
    {
        public override void Up()
        {
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe")
                .Execute.EmbeddedScript("CoopShop.Web.Migrations.DataShopDB.DataShopDBScript_SqlServer.sql");

            IfDatabase("Postgres")
                .Execute.EmbeddedScript("CoopShop.Web.Migrations.DataShopDB.DataShopDBScript_Postgres.sql");

            IfDatabase("Postgres")
                .Execute.EmbeddedScript("CoopShop.Web.Migrations.DataShopDB.DataShopDBScript_PostgresData.sql");

            IfDatabase("MySql")
                .Execute.EmbeddedScript("CoopShop.Web.Migrations.DataShopDB.DataShopDBScript_MySql.sql");

            IfDatabase("Oracle")
                .Execute.EmbeddedScript("CoopShop.Web.Migrations.DataShopDB.DataShopDBScript_Oracle.sql");
            IfDatabase("Sqlite")
                .Execute.EmbeddedScript("CoopShop.Web.Migrations.DataShopDB.DataShopDBScript_Sqlite.sql");

            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe", "Postgres")
                .Alter.Table("Customers")
                    .AddColumn("ID").AsInt32().Identity().NotNullable();

            IfDatabase("Oracle")
                .Alter.Table("Customers")
                    .AddColumn("ID").AsInt32().Nullable();

            Utils.AddOracleIdentity(this, "Customers", "ID");
            IfDatabase("Oracle")
                .Execute.Sql("UPDATE Customers SET ID = CUSTOMERS_SEQ.nextval");

            IfDatabase("Oracle")
                .Alter.Column("ID").OnTable("Customers")
                    .AsInt32().NotNullable();

            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe", "Postgres")
                .Alter.Table("Territories")
                    .AddColumn("ID").AsInt32().Identity();

            IfDatabase("Oracle")
                .Alter.Table("Territories")
                    .AddColumn("ID").AsInt32().Nullable();

            Utils.AddOracleIdentity(this, "Territories", "ID");

            IfDatabase("Oracle")
                .Execute.Sql("UPDATE Territories SET ID = Territories_SEQ.nextval");

            IfDatabase("Oracle")
                .Alter.Column("ID").OnTable("Territories")
                    .AsInt32().NotNullable();

            Alter.Table("Products")
                .AddColumn("ProductImage").AsString(100).Nullable();
        }

        public override void Down()
        {
        }
    }
}