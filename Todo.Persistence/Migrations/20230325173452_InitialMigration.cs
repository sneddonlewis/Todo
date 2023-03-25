using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    TodoItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.TodoItemId);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoItemId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[] { new Guid("6a6113ae-bda0-40ba-9def-44e5e00d188b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweep the pation", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gardening" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoItemId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[] { new Guid("b04de8dc-44f1-46b2-a028-e7d269221e5a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mow the lawn", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gardening" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoItemId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[] { new Guid("f6aa7b0c-7f51-4a87-99ab-b3420c324191"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water the plants", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gardening" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
