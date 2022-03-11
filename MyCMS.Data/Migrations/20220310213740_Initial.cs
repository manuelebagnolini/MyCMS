using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCMS.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    AttributeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AttributeType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.AttributeID);
                });

            migrationBuilder.CreateTable(
                name: "ContentRelationTypes",
                columns: table => new
                {
                    ContentRelationTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRelationTypes", x => x.ContentRelationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ContentTypes",
                columns: table => new
                {
                    ContentTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentTypes", x => x.ContentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptions",
                columns: table => new
                {
                    AttributeOptionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttributeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptions", x => x.AttributeOptionID);
                    table.ForeignKey(
                        name: "FK_AttributeOptions_Attributes_AttributeID",
                        column: x => x.AttributeID,
                        principalTable: "Attributes",
                        principalColumn: "AttributeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    ContentTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateUserID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifyUserID = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifyDatetime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentID);
                    table.ForeignKey(
                        name: "FK_Content_ContentTypes_ContentTypeID",
                        column: x => x.ContentTypeID,
                        principalTable: "ContentTypes",
                        principalColumn: "ContentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content_User_CreateUserID",
                        column: x => x.CreateUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Content_User_ModifyUserID",
                        column: x => x.ModifyUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentAttributes",
                columns: table => new
                {
                    ContentAttributeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContentID = table.Column<int>(type: "INTEGER", nullable: false),
                    AttributeID = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueText = table.Column<string>(type: "TEXT", nullable: true),
                    ValueNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ValueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AttributeOptionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAttributes", x => x.ContentAttributeID);
                    table.ForeignKey(
                        name: "FK_ContentAttributes_AttributeOptions_AttributeOptionID",
                        column: x => x.AttributeOptionID,
                        principalTable: "AttributeOptions",
                        principalColumn: "AttributeOptionID");
                    table.ForeignKey(
                        name: "FK_ContentAttributes_Attributes_AttributeID",
                        column: x => x.AttributeID,
                        principalTable: "Attributes",
                        principalColumn: "AttributeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentAttributes_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Content",
                        principalColumn: "ContentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentRelations",
                columns: table => new
                {
                    ContentRelationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContainerContentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ReferredContentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ContentRelationTypeID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRelations", x => x.ContentRelationID);
                    table.ForeignKey(
                        name: "FK_ContentRelations_Content_ContainerContentID",
                        column: x => x.ContainerContentID,
                        principalTable: "Content",
                        principalColumn: "ContentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentRelations_Content_ReferredContentID",
                        column: x => x.ReferredContentID,
                        principalTable: "Content",
                        principalColumn: "ContentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentRelations_ContentRelationTypes_ContentRelationTypeID",
                        column: x => x.ContentRelationTypeID,
                        principalTable: "ContentRelationTypes",
                        principalColumn: "ContentRelationTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptions_AttributeID",
                table: "AttributeOptions",
                column: "AttributeID");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Name",
                table: "Attributes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContentTypeID",
                table: "Content",
                column: "ContentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CreateUserID",
                table: "Content",
                column: "CreateUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ModifyUserID",
                table: "Content",
                column: "ModifyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAttributes_AttributeID",
                table: "ContentAttributes",
                column: "AttributeID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAttributes_AttributeOptionID",
                table: "ContentAttributes",
                column: "AttributeOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAttributes_ContentID_AttributeID",
                table: "ContentAttributes",
                columns: new[] { "ContentID", "AttributeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentRelations_ContainerContentID_ReferredContentID_ContentRelationTypeID",
                table: "ContentRelations",
                columns: new[] { "ContainerContentID", "ReferredContentID", "ContentRelationTypeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentRelations_ContentRelationTypeID",
                table: "ContentRelations",
                column: "ContentRelationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentRelations_ReferredContentID",
                table: "ContentRelations",
                column: "ReferredContentID");
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
                name: "Content");

            migrationBuilder.DropTable(
                name: "ContentRelationTypes");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "ContentTypes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
