using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class updateNhanVien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DONHANG_NHANVIEN_idNhanVien",
                table: "DONHANG");

            migrationBuilder.DropIndex(
                name: "IX_DONHANG_idNhanVien",
                table: "DONHANG");

            migrationBuilder.CreateIndex(
                name: "IX_DONHANG_idNhanVien",
                table: "DONHANG",
                column: "idNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_DONHANG_NHANVIEN_idNhanVien",
                table: "DONHANG",
                column: "idNhanVien",
                principalTable: "NHANVIEN",
                principalColumn: "idNhanVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DONHANG_NHANVIEN_idNhanVien",
                table: "DONHANG");

            migrationBuilder.DropIndex(
                name: "IX_DONHANG_idNhanVien",
                table: "DONHANG");

            migrationBuilder.CreateIndex(
                name: "IX_DONHANG_idNhanVien",
                table: "DONHANG",
                column: "idNhanVien",
                unique: true,
                filter: "[idNhanVien] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DONHANG_NHANVIEN_idNhanVien",
                table: "DONHANG",
                column: "idNhanVien",
                principalTable: "NHANVIEN",
                principalColumn: "idNhanVien",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
