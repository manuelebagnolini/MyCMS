using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCMS.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AttributeType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentRelationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeOptions_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    ContentTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifyUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifyDatetime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_ContentTypes_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "ContentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContentId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueText = table.Column<string>(type: "TEXT", nullable: true),
                    ValueNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AttributeOptionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentAttributes_AttributeOptions_AttributeOptionId",
                        column: x => x.AttributeOptionId,
                        principalTable: "AttributeOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentAttributes_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContentRelationId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContainerContentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReferredContentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContentRelationTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentRelations_ContentRelationTypes_ContentRelationTypeId",
                        column: x => x.ContentRelationTypeId,
                        principalTable: "ContentRelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentRelations_Contents_ContainerContentId",
                        column: x => x.ContainerContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentRelations_Contents_ReferredContentId",
                        column: x => x.ReferredContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptions_AttributeId",
                table: "AttributeOptions",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Name",
                table: "Attributes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentAttributes_AttributeId",
                table: "ContentAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAttributes_AttributeOptionId",
                table: "ContentAttributes",
                column: "AttributeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAttributes_ContentId_AttributeId",
                table: "ContentAttributes",
                columns: new[] { "ContentId", "AttributeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentRelations_ContainerContentId_ReferredContentId_ContentRelationTypeId",
                table: "ContentRelations",
                columns: new[] { "ContainerContentId", "ReferredContentId", "ContentRelationTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentRelations_ContentRelationTypeId",
                table: "ContentRelations",
                column: "ContentRelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentRelations_ReferredContentId",
                table: "ContentRelations",
                column: "ReferredContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ContentTypeId",
                table: "Contents",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CreateUserId",
                table: "Contents",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_ModifyUserId",
                table: "Contents",
                column: "ModifyUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentAttributes");

            migrationBuilder.DropTable(
                name: "ContentRelations");

            migrationBuilder.DropTable(
                name: "AttributeOptions");

            migrationBuilder.DropTable(
                name: "ContentRelationTypes");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "ContentTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
