using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingRequestedSuccessfully = table.Column<bool>(type: "bit", nullable: false),
                    ServiceProviderResponse = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ServiceProvided = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymetSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    CancelationConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingResponse",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ServiceResponse = table.Column<bool>(type: "bit", nullable: false),
                    ServiceMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentResponse = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancallationResponse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingResponse", x => x.ResponseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "BookingResponse");
        }
    }
}
