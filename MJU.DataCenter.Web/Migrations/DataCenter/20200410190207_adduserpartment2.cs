using Microsoft.EntityFrameworkCore.Migrations;

namespace MJU.DataCenter.Web.Migrations.DataCenter
{
    public partial class adduserpartment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DepartmentRoleName",
                table: "DepartmentRole",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.Sql("Insert into DepartmentRole values('General',NULL)");
            migrationBuilder.Sql("Insert into DepartmentRole values('Office','20001')");
            migrationBuilder.Sql("Insert into DepartmentRole values('Science','20002')");
            migrationBuilder.Sql("Insert into DepartmentRole values('Engineer','20003')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentRoleName",
                table: "DepartmentRole",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
