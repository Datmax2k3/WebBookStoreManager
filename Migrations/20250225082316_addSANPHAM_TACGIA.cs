using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class addSANPHAM_TACGIA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SANPHAM_TACGIA_IdTacGia",
                table: "SANPHAM");

            migrationBuilder.DropIndex(
                name: "IX_SANPHAM_IdTacGia",
                table: "SANPHAM");

            migrationBuilder.DropColumn(
                name: "IdTacGia",
                table: "SANPHAM");

            migrationBuilder.CreateTable(
                name: "SANPHAM_TACGIA",
                columns: table => new
                {
                    IdSanPham = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IdTacGia = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAM_TACGIA", x => new { x.IdSanPham, x.IdTacGia });
                    table.ForeignKey(
                        name: "FK_SANPHAM_TACGIA_SANPHAM_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SANPHAM",
                        principalColumn: "IdSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SANPHAM_TACGIA_TACGIA_IdTacGia",
                        column: x => x.IdTacGia,
                        principalTable: "TACGIA",
                        principalColumn: "IdTacGia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_TACGIA_IdTacGia",
                table: "SANPHAM_TACGIA",
                column: "IdTacGia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SANPHAM_TACGIA");

            migrationBuilder.AddColumn<string>(
                name: "IdTacGia",
                table: "SANPHAM",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_IdTacGia",
                table: "SANPHAM",
                column: "IdTacGia");

            migrationBuilder.AddForeignKey(
                name: "FK_SANPHAM_TACGIA_IdTacGia",
                table: "SANPHAM",
                column: "IdTacGia",
                principalTable: "TACGIA",
                principalColumn: "IdTacGia",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
