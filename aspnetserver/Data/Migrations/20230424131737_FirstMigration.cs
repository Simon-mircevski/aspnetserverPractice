using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aspnetserver.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Title" },
                values: new object[,]
                {
                    { 10, "This is post 0 and it has some very interesting content. I have also liked the video and subscribed.", "Post 0" },
                    { 11, "This is post 1 and it has some very interesting content. I have also liked the video and subscribed.", "Post 1" },
                    { 12, "This is post 2 and it has some very interesting content. I have also liked the video and subscribed.", "Post 2" },
                    { 13, "This is post 3 and it has some very interesting content. I have also liked the video and subscribed.", "Post 3" },
                    { 14, "This is post 4 and it has some very interesting content. I have also liked the video and subscribed.", "Post 4" },
                    { 15, "This is post 5 and it has some very interesting content. I have also liked the video and subscribed.", "Post 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
