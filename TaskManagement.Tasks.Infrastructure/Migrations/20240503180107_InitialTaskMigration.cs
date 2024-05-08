using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Tasks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTaskMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriorityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriorityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskItemDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    TaskItemStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskItemEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskItemCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalTimeEstimated = table.Column<double>(type: "float(3)", precision: 3, scale: 1, nullable: false),
                    RemainingTime = table.Column<double>(type: "float(3)", precision: 3, scale: 1, nullable: false),
                    CompletedTime = table.Column<double>(type: "float(3)", precision: 3, scale: 1, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskItemId);
                    table.ForeignKey(
                        name: "FK_Task_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskComments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_TaskComments_Task_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "Task",
                        principalColumn: "TaskItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_PriorityId",
                table: "Task",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StateId",
                table: "Task",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskItemId",
                table: "TaskComments",
                column: "TaskItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskComments");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
