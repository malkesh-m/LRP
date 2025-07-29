using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSCPA.Data.Migrations
{
    public partial class InsertTableLRPVendor_Reportings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LRPVendor_Reportings",
                columns: table => new
                {
                    ObjectUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AddressI_Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressII_Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressIII_Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode_Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Country_StateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Userdef1_Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userdef2_Reporting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldRecordID = table.Column<int>(type: "int", nullable: true),
                    InstallationUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImportedObjectUID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LRPVendor_Reportings", x => x.ObjectUID);
                    table.ForeignKey(
                        name: "FK_LRPVendor_Reportings_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ObjectUID");
                    table.ForeignKey(
                        name: "FK_LRPVendor_Reportings_Country_State_Country_StateID",
                        column: x => x.Country_StateID,
                        principalTable: "Country_State",
                        principalColumn: "ObjectUID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LRPVendor_Reportings_Country_StateID",
                table: "LRPVendor_Reportings",
                column: "Country_StateID");

            migrationBuilder.CreateIndex(
                name: "IX_LRPVendor_Reportings_CountryID",
                table: "LRPVendor_Reportings",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LRPVendor_Reportings");
        }
    }
}
