using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCMS.Data.Migrations
{
    public partial class RenamingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_ContentTypes_ContentTypeID",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_User_CreateUserID",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_User_ModifyUserID",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentAttributes_Content_ContentID",
                table: "ContentAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentRelations_Content_ContainerContentID",
                table: "ContentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentRelations_Content_ReferredContentID",
                table: "ContentRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Content",
                newName: "Contents");

            migrationBuilder.RenameIndex(
                name: "IX_Content_ModifyUserID",
                table: "Contents",
                newName: "IX_Contents_ModifyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Content_CreateUserID",
                table: "Contents",
                newName: "IX_Contents_CreateUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Content_ContentTypeID",
                table: "Contents",
                newName: "IX_Contents_ContentTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contents",
                table: "Contents",
                column: "ContentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentAttributes_Contents_ContentID",
                table: "ContentAttributes",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentRelations_Contents_ContainerContentID",
                table: "ContentRelations",
                column: "ContainerContentID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentRelations_Contents_ReferredContentID",
                table: "ContentRelations",
                column: "ReferredContentID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_ContentTypes_ContentTypeID",
                table: "Contents",
                column: "ContentTypeID",
                principalTable: "ContentTypes",
                principalColumn: "ContentTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Users_CreateUserID",
                table: "Contents",
                column: "CreateUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Users_ModifyUserID",
                table: "Contents",
                column: "ModifyUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentAttributes_Contents_ContentID",
                table: "ContentAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentRelations_Contents_ContainerContentID",
                table: "ContentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentRelations_Contents_ReferredContentID",
                table: "ContentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_ContentTypes_ContentTypeID",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Users_CreateUserID",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Users_ModifyUserID",
                table: "Contents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contents",
                table: "Contents");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Contents",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_ModifyUserID",
                table: "Content",
                newName: "IX_Content_ModifyUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_CreateUserID",
                table: "Content",
                newName: "IX_Content_CreateUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_ContentTypeID",
                table: "Content",
                newName: "IX_Content_ContentTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "ContentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_ContentTypes_ContentTypeID",
                table: "Content",
                column: "ContentTypeID",
                principalTable: "ContentTypes",
                principalColumn: "ContentTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_User_CreateUserID",
                table: "Content",
                column: "CreateUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_User_ModifyUserID",
                table: "Content",
                column: "ModifyUserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentAttributes_Content_ContentID",
                table: "ContentAttributes",
                column: "ContentID",
                principalTable: "Content",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentRelations_Content_ContainerContentID",
                table: "ContentRelations",
                column: "ContainerContentID",
                principalTable: "Content",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentRelations_Content_ReferredContentID",
                table: "ContentRelations",
                column: "ReferredContentID",
                principalTable: "Content",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
