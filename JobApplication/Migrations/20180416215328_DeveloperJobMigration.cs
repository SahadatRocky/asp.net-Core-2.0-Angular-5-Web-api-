using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JobApplication.Migrations
{
    public partial class DeveloperJobMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    zipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyAddressId = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanySize = table.Column<int>(nullable: false),
                    CompanyTypeId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DeactivatedDate = table.Column<DateTime>(nullable: true),
                    EquitySharing = table.Column<bool>(nullable: true),
                    ExperienceLavel = table.Column<string>(nullable: true),
                    IndustryId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    JobDescription = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: false),
                    RemoteOptions = table.Column<bool>(nullable: true),
                    SalaryRange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperJobs_CompanyAddress_CompanyAddressId",
                        column: x => x.CompanyAddressId,
                        principalTable: "CompanyAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeveloperJobs_CompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperJobs_Industry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperJobs_JobType_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperJobs_CompanyAddressId",
                table: "DeveloperJobs",
                column: "CompanyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperJobs_CompanyTypeId",
                table: "DeveloperJobs",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperJobs_IndustryId",
                table: "DeveloperJobs",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperJobs_JobTypeId",
                table: "DeveloperJobs",
                column: "JobTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperJobs");

            migrationBuilder.DropTable(
                name: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.DropTable(
                name: "Industry");

            migrationBuilder.DropTable(
                name: "JobType");
        }
    }
}
