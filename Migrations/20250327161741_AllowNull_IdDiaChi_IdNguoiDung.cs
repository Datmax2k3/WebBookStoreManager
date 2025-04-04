using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBookStoreManage.Migrations
{
    public partial class AllowNull_IdDiaChi_IdNguoiDung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_idPhieuDat",
                table: "CHITIETPHIEUDAT");

            migrationBuilder.AlterColumn<int>(
                name: "idNguoiDung",
                table: "PHIEUDAT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "idDiaChi",
                table: "PHIEUDAT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "idPhieuDat",
                table: "CHITIETPHIEUDAT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_idPhieuDat",
                table: "CHITIETPHIEUDAT",
                column: "idPhieuDat",
                principalTable: "PHIEUDAT",
                principalColumn: "idPhieuDat",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_idPhieuDat",
                table: "CHITIETPHIEUDAT");

            migrationBuilder.AlterColumn<int>(
                name: "idNguoiDung",
                table: "PHIEUDAT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idDiaChi",
                table: "PHIEUDAT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idPhieuDat",
                table: "CHITIETPHIEUDAT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CHITIETPHIEUDAT_PHIEUDAT_idPhieuDat",
                table: "CHITIETPHIEUDAT",
                column: "idPhieuDat",
                principalTable: "PHIEUDAT",
                principalColumn: "idPhieuDat",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
