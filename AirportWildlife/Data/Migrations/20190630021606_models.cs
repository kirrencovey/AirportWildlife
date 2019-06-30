using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportWildlife.Data.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Airport",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AnimalActivities",
                columns: table => new
                {
                    AnimalActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalActivities", x => x.AnimalActivityId);
                });

            migrationBuilder.CreateTable(
                name: "ControlMethods",
                columns: table => new
                {
                    ControlMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlMethods", x => x.ControlMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Initials = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    HabitatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.HabitatId);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpeciesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpeciesId);
                });

            migrationBuilder.CreateTable(
                name: "Interactoins",
                columns: table => new
                {
                    InteractionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: false),
                    SpeciesCount = table.Column<int>(nullable: false),
                    NumberTaken = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    SpeciesId = table.Column<int>(nullable: false),
                    AnimalActivityId = table.Column<int>(nullable: false),
                    HabitatId = table.Column<int>(nullable: false),
                    ControlMethodId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactoins", x => x.InteractionId);
                    table.ForeignKey(
                        name: "FK_Interactoins_AnimalActivities_AnimalActivityId",
                        column: x => x.AnimalActivityId,
                        principalTable: "AnimalActivities",
                        principalColumn: "AnimalActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactoins_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactoins_ControlMethods_ControlMethodId",
                        column: x => x.ControlMethodId,
                        principalTable: "ControlMethods",
                        principalColumn: "ControlMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactoins_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactoins_Habitats_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitats",
                        principalColumn: "HabitatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactoins_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "SpeciesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactoins_AnimalActivityId",
                table: "Interactoins",
                column: "AnimalActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactoins_ApplicationUserId",
                table: "Interactoins",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactoins_ControlMethodId",
                table: "Interactoins",
                column: "ControlMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactoins_EmployeeId",
                table: "Interactoins",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactoins_HabitatId",
                table: "Interactoins",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactoins_SpeciesId",
                table: "Interactoins",
                column: "SpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactoins");

            migrationBuilder.DropTable(
                name: "AnimalActivities");

            migrationBuilder.DropTable(
                name: "ControlMethods");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Airport",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
