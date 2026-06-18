using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telemetry.Migrations.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddLogRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    _id = table.Column<Guid>(type: "uuid", nullable: false),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    log_level = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    message_template = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    rendered_message = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    exception = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: true),
                    session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    plugin_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    plugin_session_id = table.Column<Guid>(type: "uuid", nullable: false),
                    env_username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    env_machinename = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    revit_build = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    revit_version = table.Column<int>(type: "integer", nullable: false),
                    revit_language = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    revit_username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    doc_title = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    doc_pathname = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    doc_modelpath = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    log_event = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x._id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs");
        }
    }
}
