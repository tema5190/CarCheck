using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class ReInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmationModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Hash1 = table.Column<string>(nullable: true),
                    Hash2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmationModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PasswordHash = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    AuthInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserAuthInfo_AuthInfoId",
                        column: x => x.AuthInfoId,
                        principalTable: "UserAuthInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CarIdCardDataId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCar_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarIdCardData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    CertificateSeries = table.Column<string>(nullable: true),
                    CertificateNumber = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PenaltyDataTime = table.Column<DateTime>(nullable: true),
                    PenaltyNumber = table.Column<string>(nullable: true),
                    UserCarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarIdCardData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarIdCardData_UserCar_UserCarId",
                        column: x => x.UserCarId,
                        principalTable: "UserCar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarIdCardData_UserCarId",
                table: "CarIdCardData",
                column: "UserCarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCar_CarIdCardDataId",
                table: "UserCar",
                column: "CarIdCardDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCar_UserId",
                table: "UserCar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthInfoId",
                table: "Users",
                column: "AuthInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCar_CarIdCardData_CarIdCardDataId",
                table: "UserCar",
                column: "CarIdCardDataId",
                principalTable: "CarIdCardData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarIdCardData_UserCar_UserCarId",
                table: "CarIdCardData");

            migrationBuilder.DropTable(
                name: "ConfirmationModels");

            migrationBuilder.DropTable(
                name: "UserCar");

            migrationBuilder.DropTable(
                name: "CarIdCardData");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserAuthInfo");
        }
    }
}
