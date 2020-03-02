using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Infrastructure.Migrations
{
    public partial class AddPostImageEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "ImagePostImageId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostImage",
                columns: table => new
                {
                    PostImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImage", x => x.PostImageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImagePostImageId",
                table: "Posts",
                column: "ImagePostImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostImage_ImagePostImageId",
                table: "Posts",
                column: "ImagePostImageId",
                principalTable: "PostImage",
                principalColumn: "PostImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostImage_ImagePostImageId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PostImage");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ImagePostImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImagePostImageId",
                table: "Posts");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Posts",
                nullable: true);
        }
    }
}
