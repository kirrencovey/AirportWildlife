using Microsoft.EntityFrameworkCore.Migrations;

namespace AirportWildlife.Data.Migrations
{
    public partial class addUserToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_AspNetUsers_ApplicationUserId",
                table: "Interactions");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Interactions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Interactions_ApplicationUserId",
                table: "Interactions",
                newName: "IX_Interactions_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Species",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Habitats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ControlMethods",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnimalActivities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_UserId",
                table: "Species",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_UserId",
                table: "Habitats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlMethods_UserId",
                table: "ControlMethods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalActivities_UserId",
                table: "AnimalActivities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalActivities_AspNetUsers_UserId",
                table: "AnimalActivities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlMethods_AspNetUsers_UserId",
                table: "ControlMethods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_AspNetUsers_UserId",
                table: "Habitats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_AspNetUsers_UserId",
                table: "Interactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Species_AspNetUsers_UserId",
                table: "Species",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalActivities_AspNetUsers_UserId",
                table: "AnimalActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlMethods_AspNetUsers_UserId",
                table: "ControlMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_AspNetUsers_UserId",
                table: "Habitats");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_AspNetUsers_UserId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_AspNetUsers_UserId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_UserId",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Habitats_UserId",
                table: "Habitats");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_ControlMethods_UserId",
                table: "ControlMethods");

            migrationBuilder.DropIndex(
                name: "IX_AnimalActivities_UserId",
                table: "AnimalActivities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ControlMethods");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnimalActivities");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Interactions",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Interactions_UserId",
                table: "Interactions",
                newName: "IX_Interactions_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_AspNetUsers_ApplicationUserId",
                table: "Interactions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
