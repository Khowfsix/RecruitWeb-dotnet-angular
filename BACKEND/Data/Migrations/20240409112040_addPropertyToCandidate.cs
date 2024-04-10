using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyToCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificateInCV",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_ofCV",
                table: "CV_has_Skills");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "347c32b8-33ee-4c24-a0fe-28b79e62e0d2", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5343a1d1-78f5-4f96-a275-05b614feccae", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71dd8ab2-893e-4105-a9af-b6ab164340db", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5577554-ab97-4eee-bcb3-eb99cb8d2476", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5343a1d1-78f5-4f96-a275-05b614feccae", "bf328094-07c0-4f89-aad4-258c79acd243" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71dd8ab2-893e-4105-a9af-b6ab164340db", "bf328094-07c0-4f89-aad4-258c79acd243" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "347c32b8-33ee-4c24-a0fe-28b79e62e0d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5343a1d1-78f5-4f96-a275-05b614feccae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71dd8ab2-893e-4105-a9af-b6ab164340db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5577554-ab97-4eee-bcb3-eb99cb8d2476");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "987ed908-234a-4343-8e50-fcc44d6fd9ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf328094-07c0-4f89-aad4-258c79acd243");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "DateEarned",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Certificate");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "CV",
                newName: "AboutMe");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Certificate",
                newName: "CertificateURL");

            migrationBuilder.RenameColumn(
                name: "Cvid",
                table: "Certificate",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Certificate_Cvid",
                table: "Certificate",
                newName: "IX_Certificate_CandidateId");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Candidate",
                newName: "AboutMe");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "CV",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CvPdf",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Certificate",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 531, DateTimeKind.Local).AddTicks(6735));

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    AwardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardOrganization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(8021)),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_award", x => x.AwardId);
                    table.ForeignKey(
                        name: "FK_candidateHasAward",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateHasSkill",
                columns: table => new
                {
                    CandidateHasSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateHasSkill", x => x.CandidateHasSkillId);
                    table.ForeignKey(
                        name: "PK_candidateHasSkill_candidate",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PK_candidateHasSkill_skill",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(1824)),
                    To = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_CandidateHasEducations",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalProject",
                columns: table => new
                {
                    PersonalProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(6572)),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalProject", x => x.PersonalProjectId);
                    table.ForeignKey(
                        name: "FK_candidateHasPersonalProject",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    WorkExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(3260)),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workExperience", x => x.WorkExperienceId);
                    table.ForeignKey(
                        name: "FK_CandidateHasWorkExperience",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "010f3321-c20d-4080-bc8a-e26370b7acd1", "1", "Candidate", "Candidate" },
                    { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "3", "Recruiter", "Recruiter" },
                    { "9ddf7f2b-50d9-4b08-be52-3a01afbf612f", "4", "Admin", "Admin" },
                    { "c98b24cb-3acf-494b-bd49-2829fd573d4a", "2", "Interviewer", "Interviewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dbc43d9d-84bf-47f5-a1d4-7c990f903723", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" },
                    { "ff01cfbf-c330-4332-b500-07f33f10e8ce", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "010f3321-c20d-4080-bc8a-e26370b7acd1", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" },
                    { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" },
                    { "010f3321-c20d-4080-bc8a-e26370b7acd1", "ff01cfbf-c330-4332-b500-07f33f10e8ce" },
                    { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "ff01cfbf-c330-4332-b500-07f33f10e8ce" },
                    { "9ddf7f2b-50d9-4b08-be52-3a01afbf612f", "ff01cfbf-c330-4332-b500-07f33f10e8ce" },
                    { "c98b24cb-3acf-494b-bd49-2829fd573d4a", "ff01cfbf-c330-4332-b500-07f33f10e8ce" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Award_CandidateId",
                table: "Award",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateHasSkill_CandidateId",
                table: "CandidateHasSkill",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateHasSkill_SkillId",
                table: "CandidateHasSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_CandidateId",
                table: "Education",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalProject_CandidateId",
                table: "PersonalProject",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_CandidateId",
                table: "WorkExperience",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_candidateHasCertificate",
                table: "Certificate",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CV_has_Skills_CV_Cvid",
                table: "CV_has_Skills",
                column: "Cvid",
                principalTable: "CV",
                principalColumn: "Cvid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_candidateHasCertificate",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_CV_has_Skills_CV_Cvid",
                table: "CV_has_Skills");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "CandidateHasSkill");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "PersonalProject");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "010f3321-c20d-4080-bc8a-e26370b7acd1", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "010f3321-c20d-4080-bc8a-e26370b7acd1", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ddf7f2b-50d9-4b08-be52-3a01afbf612f", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c98b24cb-3acf-494b-bd49-2829fd573d4a", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "010f3321-c20d-4080-bc8a-e26370b7acd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ffa778f-ec76-4b4a-8525-5d5549cf7937");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddf7f2b-50d9-4b08-be52-3a01afbf612f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c98b24cb-3acf-494b-bd49-2829fd573d4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc43d9d-84bf-47f5-a1d4-7c990f903723");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff01cfbf-c330-4332-b500-07f33f10e8ce");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Certificate");

            migrationBuilder.RenameColumn(
                name: "AboutMe",
                table: "CV",
                newName: "Introduction");

            migrationBuilder.RenameColumn(
                name: "CertificateURL",
                table: "Certificate",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Certificate",
                newName: "Cvid");

            migrationBuilder.RenameIndex(
                name: "IX_Certificate_CandidateId",
                table: "Certificate",
                newName: "IX_Certificate_Cvid");

            migrationBuilder.RenameColumn(
                name: "AboutMe",
                table: "Candidate",
                newName: "Experience");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "CV",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CvPdf",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Certificate",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEarned",
                table: "Certificate",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Certificate",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Certificate",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "347c32b8-33ee-4c24-a0fe-28b79e62e0d2", "4", "Admin", "Admin" },
                    { "5343a1d1-78f5-4f96-a275-05b614feccae", "1", "Candidate", "Candidate" },
                    { "71dd8ab2-893e-4105-a9af-b6ab164340db", "3", "Recruiter", "Recruiter" },
                    { "d5577554-ab97-4eee-bcb3-eb99cb8d2476", "2", "Interviewer", "Interviewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "987ed908-234a-4343-8e50-fcc44d6fd9ea", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" },
                    { "bf328094-07c0-4f89-aad4-258c79acd243", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "347c32b8-33ee-4c24-a0fe-28b79e62e0d2", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "5343a1d1-78f5-4f96-a275-05b614feccae", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "71dd8ab2-893e-4105-a9af-b6ab164340db", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "d5577554-ab97-4eee-bcb3-eb99cb8d2476", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "5343a1d1-78f5-4f96-a275-05b614feccae", "bf328094-07c0-4f89-aad4-258c79acd243" },
                    { "71dd8ab2-893e-4105-a9af-b6ab164340db", "bf328094-07c0-4f89-aad4-258c79acd243" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateInCV",
                table: "Certificate",
                column: "Cvid",
                principalTable: "CV",
                principalColumn: "Cvid");

            migrationBuilder.AddForeignKey(
                name: "FK_ofCV",
                table: "CV_has_Skills",
                column: "Cvid",
                principalTable: "CV",
                principalColumn: "Cvid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
