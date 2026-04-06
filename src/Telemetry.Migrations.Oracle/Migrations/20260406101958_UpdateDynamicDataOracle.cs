using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telemetry.Migrations.Oracle.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDynamicDataOracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_script_record",
                table: "script_record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event_record",
                table: "event_record");

            migrationBuilder.RenameTable(
                name: "script_record",
                newName: "scripts");

            migrationBuilder.RenameTable(
                name: "event_record",
                newName: "events");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "scripts",
                newName: "_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "events",
                newName: "_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_scripts",
                table: "scripts",
                column: "_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "events",
                column: "_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_scripts",
                table: "scripts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.RenameTable(
                name: "scripts",
                newName: "script_record");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "event_record");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "script_record",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "_id",
                table: "event_record",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_script_record",
                table: "script_record",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event_record",
                table: "event_record",
                column: "id");
        }
    }
}
