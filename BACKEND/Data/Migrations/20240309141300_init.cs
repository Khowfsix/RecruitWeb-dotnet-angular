using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryPosition",
            //    columns: table => new
            //    {
            //        CategoryPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CategoryPositionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValue: ""),
            //        CategoryPositionDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_categoryPostion", x => x.CategoryPositionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryQuestion",
            //    columns: table => new
            //    {
            //        CategoryQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CategoryQuestionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Weight = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Category__DE130A6A56DA0675", x => x.CategoryQuestionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Company",
            //    columns: table => new
            //    {
            //        CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Phone = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
            //        Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Departme__B2079BED26482F76", x => x.CompanyId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Language",
            //    columns: table => new
            //    {
            //        LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        LanguageName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Language__B93855AB02B6E2A3", x => x.LanguageId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ResetPasswords",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        InsertDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ResetPasswords", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Result",
            //    columns: table => new
            //    {
            //        ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ResultString = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Result__976902081579C0D7", x => x.ResultId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Room",
            //    columns: table => new
            //    {
            //        RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RoomName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Room__3286393943AEBB6D", x => x.RoomId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SecurityQuestion",
            //    columns: table => new
            //    {
            //        SecurityQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        QuestionString = table.Column<string>(type: "nvarchar(max)", maxLength: 255, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SecurityQuestion__C0A83881EF08EB13", x => x.SecurityQuestionId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Shift",
            //    columns: table => new
            //    {
            //        ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ShiftTimeStart = table.Column<int>(type: "int", nullable: false),
            //        ShiftTimeEnd = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Shift__C0A83881EF08EB13", x => x.ShiftId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Skill",
            //    columns: table => new
            //    {
            //        SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SkillName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Skill__DFA0918741CB17C8", x => x.SkillId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Candidate",
            //    columns: table => new
            //    {
            //        CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Candidat__DF539B9C8196430E", x => x.CandidateId);
            //        table.ForeignKey(
            //            name: "FK_CandidateUser",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RefreshToken",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ExpiryOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WebUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RefreshToken", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RefreshToken_AspNetUsers_WebUserId",
            //            column: x => x.WebUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Question",
            //    columns: table => new
            //    {
            //        QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        QuestionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CategoryQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Question__0DC06FAC07D9C6DD", x => x.QuestionId);
            //        table.ForeignKey(
            //            name: "Fk_catQues",
            //            column: x => x.CategoryQuestionId,
            //            principalTable: "CategoryQuestion",
            //            principalColumn: "CategoryQuestionId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Interviewer",
            //    columns: table => new
            //    {
            //        InterviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Intervie__C29BDA1D949A214A", x => x.InterviewerId);
            //        table.ForeignKey(
            //            name: "Fk_InterviewerUser",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "Fk_interDepart",
            //            column: x => x.CompanyId,
            //            principalTable: "Company",
            //            principalColumn: "CompanyId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Recruiter",
            //    columns: table => new
            //    {
            //        RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Recruite__219CFF5625FB1B60", x => x.RecruiterId);
            //        table.ForeignKey(
            //            name: "FK_ReccerUser",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "Fk_reccerDepart",
            //            column: x => x.CompanyId,
            //            principalTable: "Company",
            //            principalColumn: "CompanyId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SecurityAnswer",
            //    columns: table => new
            //    {
            //        SecurityAnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SecurityQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        WebUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SecurityAnswer__C0A83881EF08EB13", x => x.SecurityAnswerId);
            //        table.ForeignKey(
            //            name: "FK_AnswerForQues",
            //            column: x => x.SecurityQuestionId,
            //            principalTable: "SecurityQuestion",
            //            principalColumn: "SecurityQuestionId");
            //        table.ForeignKey(
            //            name: "FK_AnswerForUser",
            //            column: x => x.WebUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ITRSInterview",
            //    columns: table => new
            //    {
            //        ITRSInterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        DateInterview = table.Column<DateTime>(type: "date", nullable: false),
            //        ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ITRSInte__689D871CEED2E961", x => x.ITRSInterviewId);
            //        table.ForeignKey(
            //            name: "Fk_ITRS_Room",
            //            column: x => x.RoomId,
            //            principalTable: "Room",
            //            principalColumn: "RoomId");
            //        table.ForeignKey(
            //            name: "Fk_ITRS_Shift",
            //            column: x => x.ShiftId,
            //            principalTable: "Shift",
            //            principalColumn: "ShiftId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BlackList",
            //    columns: table => new
            //    {
            //        BlackListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        DateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        Status = table.Column<int>(type: "int", nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__BlackLis__B54E3C741F66E917", x => x.BlackListId);
            //        table.ForeignKey(
            //            name: "FK_CandiInBlackList",
            //            column: x => x.CandidateId,
            //            principalTable: "Candidate",
            //            principalColumn: "CandidateId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CV",
            //    columns: table => new
            //    {
            //        Cvid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CvPdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CvName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
            //        IsDefault = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__CV__A04CFFA37AEDF099", x => x.Cvid);
            //        table.ForeignKey(
            //            name: "FK_CreateCV",
            //            column: x => x.CandidateId,
            //            principalTable: "Candidate",
            //            principalColumn: "CandidateId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionLanguages",
            //    columns: table => new
            //    {
            //        QuestionLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_QuestionLanguageId", x => x.QuestionLanguageId);
            //        table.ForeignKey(
            //            name: "Fk_LanguageQues",
            //            column: x => x.QuestionId,
            //            principalTable: "Question",
            //            principalColumn: "QuestionId");
            //        table.ForeignKey(
            //            name: "Fk_QuesLanguage",
            //            column: x => x.LanguageId,
            //            principalTable: "Language",
            //            principalColumn: "LanguageId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionSkills",
            //    columns: table => new
            //    {
            //        QuestionSkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Question__3D7C86CBF36F4D5D", x => x.QuestionSkillsId);
            //        table.ForeignKey(
            //            name: "Fk_QuesSkill",
            //            column: x => x.SkillId,
            //            principalTable: "Skill",
            //            principalColumn: "SkillId");
            //        table.ForeignKey(
            //            name: "Fk_SkillQues",
            //            column: x => x.QuestionId,
            //            principalTable: "Question",
            //            principalColumn: "QuestionId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Event",
            //    columns: table => new
            //    {
            //        EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        EventName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DatetimeEvent = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        MaxParticipants = table.Column<int>(type: "int", nullable: false),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Event__7944C8101630C102", x => x.EventId);
            //        table.ForeignKey(
            //            name: "FK_EventManagedBy",
            //            column: x => x.RecruiterId,
            //            principalTable: "Recruiter",
            //            principalColumn: "RecruiterId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Position",
            //    columns: table => new
            //    {
            //        PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        PositionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Salary = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
            //        MaxHiringQty = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "date", nullable: true),
            //        EndDate = table.Column<DateTime>(type: "date", nullable: true),
            //        CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        CategoryPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Position__60BB9A79BADAC7AE", x => x.PositionId);
            //        table.ForeignKey(
            //            name: "FK_Hires",
            //            column: x => x.CompanyId,
            //            principalTable: "Company",
            //            principalColumn: "CompanyId");
            //        table.ForeignKey(
            //            name: "FK_ManagedBy",
            //            column: x => x.RecruiterId,
            //            principalTable: "Recruiter",
            //            principalColumn: "RecruiterId");
            //        table.ForeignKey(
            //            name: "FK__categoryOfPosition",
            //            column: x => x.CategoryPositionId,
            //            principalTable: "CategoryPosition",
            //            principalColumn: "CategoryPositionId");
            //        table.ForeignKey(
            //            name: "Fk_language",
            //            column: x => x.LanguageId,
            //            principalTable: "Language",
            //            principalColumn: "LanguageId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Report",
            //    columns: table => new
            //    {
            //        ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ReportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Report__D5BD48055F400A51", x => x.ReportId);
            //        table.ForeignKey(
            //            name: "FK_ReccerCreateReport",
            //            column: x => x.RecruiterId,
            //            principalTable: "Recruiter",
            //            principalColumn: "RecruiterId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Certificate",
            //    columns: table => new
            //    {
            //        CertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CertificateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        OrganizationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        DateEarned = table.Column<DateTime>(type: "date", nullable: false),
            //        ExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
            //        Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Cvid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Certific__BBF8A7C122402FA9", x => x.CertificateId);
            //        table.ForeignKey(
            //            name: "FK_CertificateInCV",
            //            column: x => x.Cvid,
            //            principalTable: "CV",
            //            principalColumn: "Cvid");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CV_has_Skills",
            //    columns: table => new
            //    {
            //        CV_SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Cvid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ExperienceYear = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__CV_has_S__21EE6FE772D382E5", x => x.CV_SkillsId);
            //        table.ForeignKey(
            //            name: "FK_hasSkill",
            //            column: x => x.SkillId,
            //            principalTable: "Skill",
            //            principalColumn: "SkillId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ofCV",
            //            column: x => x.Cvid,
            //            principalTable: "CV",
            //            principalColumn: "Cvid",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CandidateJoinEvent",
            //    columns: table => new
            //    {
            //        CandidateJoinEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        DateJoin = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Candidat__ECDC0AF2269C389E", x => x.CandidateJoinEventId);
            //        table.ForeignKey(
            //            name: "FK_CandiJoin",
            //            column: x => x.CandidateId,
            //            principalTable: "Candidate",
            //            principalColumn: "CandidateId");
            //        table.ForeignKey(
            //            name: "FK_joinEvent",
            //            column: x => x.EventId,
            //            principalTable: "Event",
            //            principalColumn: "EventId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Application",
            //    columns: table => new
            //    {
            //        ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Cvid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        DateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        Company_Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Candidate_Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Applicat__C93A4C99D502D0BD", x => x.ApplicationId);
            //        table.ForeignKey(
            //            name: "Fk_appliCv",
            //            column: x => x.Cvid,
            //            principalTable: "CV",
            //            principalColumn: "Cvid");
            //        table.ForeignKey(
            //            name: "Fk_appliPosition",
            //            column: x => x.PositionId,
            //            principalTable: "Position",
            //            principalColumn: "PositionId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Requirements",
            //    columns: table => new
            //    {
            //        RequirementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Requirem__7DF11E5D19F31719", x => x.RequirementId);
            //        table.ForeignKey(
            //            name: "FK_requePos",
            //            column: x => x.PositionId,
            //            principalTable: "Position",
            //            principalColumn: "PositionId");
            //        table.ForeignKey(
            //            name: "FK_requeSkil",
            //            column: x => x.SkillId,
            //            principalTable: "Skill",
            //            principalColumn: "SkillId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SuccessfulCadidate",
            //    columns: table => new
            //    {
            //        SuccessfulCadidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        DateSuccess = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Successf__0743315651E595B0", x => x.SuccessfulCadidateId);
            //        table.ForeignKey(
            //            name: "FK_SuccessfulCandi",
            //            column: x => x.CandidateId,
            //            principalTable: "Candidate",
            //            principalColumn: "CandidateId");
            //        table.ForeignKey(
            //            name: "FK_SuccessfulPosition",
            //            column: x => x.PositionId,
            //            principalTable: "Position",
            //            principalColumn: "PositionId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Interview",
            //    columns: table => new
            //    {
            //        InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        InterviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ITRSInterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            //        Company_Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Candidate_Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Intervie__C97C58525A846D87", x => x.InterviewId);
            //        table.ForeignKey(
            //            name: "FK_ITRS",
            //            column: x => x.ITRSInterviewId,
            //            principalTable: "ITRSInterview",
            //            principalColumn: "ITRSInterviewId");
            //        table.ForeignKey(
            //            name: "FK_IsConductes",
            //            column: x => x.InterviewerId,
            //            principalTable: "Interviewer",
            //            principalColumn: "InterviewerId");
            //        table.ForeignKey(
            //            name: "FK_ReccerCreateInterview",
            //            column: x => x.RecruiterId,
            //            principalTable: "Recruiter",
            //            principalColumn: "RecruiterId");
            //        table.ForeignKey(
            //            name: "FK_ResultInterview",
            //            column: x => x.ResultId,
            //            principalTable: "Result",
            //            principalColumn: "ResultId");
            //        table.ForeignKey(
            //            name: "FK_applicationInterview",
            //            column: x => x.ApplicationId,
            //            principalTable: "Application",
            //            principalColumn: "ApplicationId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Round",
            //    columns: table => new
            //    {
            //        RoundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Score = table.Column<double>(type: "float", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Round__94D84DFA949E251F", x => x.RoundId);
            //        table.ForeignKey(
            //            name: "Fk_RoundInterview",
            //            column: x => x.InterviewId,
            //            principalTable: "Interview",
            //            principalColumn: "InterviewId");
            //        table.ForeignKey(
            //            name: "Fk_RoundQuestion",
            //            column: x => x.QuestionId,
            //            principalTable: "Question",
            //            principalColumn: "QuestionId");
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "0721cdb5-5027-457b-ac68-2d1ed8273c58", "2", "Interviewer", "Interviewer" },
            //        { "9f49a9cf-c12c-4cb8-9c08-082cfb7c5f74", "3", "Recruiter", "Recruiter" },
            //        { "ac469261-7a78-439c-84a8-f0f915d2bcc7", "4", "Admin", "Admin" },
            //        { "aec3221d-17a9-4b8a-8a66-c652faa6eca3", "1", "Candidate", "Candidate" }
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Application_Cvid",
            //    table: "Application",
            //    column: "Cvid");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Application_PositionId",
            //    table: "Application",
            //    column: "PositionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BlackList_CandidateId",
            //    table: "BlackList",
            //    column: "CandidateId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Candidate_UserId",
            //    table: "Candidate",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CandidateJoinEvent_EventId",
            //    table: "CandidateJoinEvent",
            //    column: "EventId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Candidat__0FAC84DD20A583A2",
            //    table: "CandidateJoinEvent",
            //    columns: new[] { "CandidateId", "EventId" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Certificate_Cvid",
            //    table: "Certificate",
            //    column: "Cvid");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CV_CandidateId",
            //    table: "CV",
            //    column: "CandidateId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CV_has_Skills_Cvid",
            //    table: "CV_has_Skills",
            //    column: "Cvid");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CV_has_Skills_SkillId",
            //    table: "CV_has_Skills",
            //    column: "SkillId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Event_RecruiterId",
            //    table: "Event",
            //    column: "RecruiterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interview_ApplicationId",
            //    table: "Interview",
            //    column: "ApplicationId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interview_InterviewerId",
            //    table: "Interview",
            //    column: "InterviewerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interview_ITRSInterviewId",
            //    table: "Interview",
            //    column: "ITRSInterviewId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interview_RecruiterId",
            //    table: "Interview",
            //    column: "RecruiterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interview_ResultId",
            //    table: "Interview",
            //    column: "ResultId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interviewer_CompanyId",
            //    table: "Interviewer",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Interviewer_UserId",
            //    table: "Interviewer",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ITRSInterview_RoomId",
            //    table: "ITRSInterview",
            //    column: "RoomId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ITRSInterview_ShiftId",
            //    table: "ITRSInterview",
            //    column: "ShiftId");

            //migrationBuilder.CreateIndex(
            //    name: "UNIQUE_InterviewTime",
            //    table: "ITRSInterview",
            //    columns: new[] { "DateInterview", "ShiftId", "RoomId" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Position_CategoryPositionId",
            //    table: "Position",
            //    column: "CategoryPositionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Position_CompanyId",
            //    table: "Position",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Position_LanguageId",
            //    table: "Position",
            //    column: "LanguageId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Position_RecruiterId",
            //    table: "Position",
            //    column: "RecruiterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Question_CategoryQuestionId",
            //    table: "Question",
            //    column: "CategoryQuestionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_QuestionLanguages_LanguageId",
            //    table: "QuestionLanguages",
            //    column: "LanguageId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Question_LanguageId",
            //    table: "QuestionLanguages",
            //    columns: new[] { "QuestionId", "LanguageId" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_QuestionSkills_SkillId",
            //    table: "QuestionSkills",
            //    column: "SkillId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Question__603A66B596184E51",
            //    table: "QuestionSkills",
            //    columns: new[] { "QuestionId", "SkillId" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Recruiter_CompanyId",
            //    table: "Recruiter",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Recruiter_UserId",
            //    table: "Recruiter",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RefreshToken_WebUserId",
            //    table: "RefreshToken",
            //    column: "WebUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Report_RecruiterId",
            //    table: "Report",
            //    column: "RecruiterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Requirements_PositionId",
            //    table: "Requirements",
            //    column: "PositionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Requirements_SkillId",
            //    table: "Requirements",
            //    column: "SkillId");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Room__6B500B55E5A0FA95",
            //    table: "Room",
            //    column: "RoomName",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Round_InterviewId",
            //    table: "Round",
            //    column: "InterviewId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Round_QuestionId",
            //    table: "Round",
            //    column: "QuestionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SecurityAnswer_SecurityQuestionId",
            //    table: "SecurityAnswer",
            //    column: "SecurityQuestionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SecurityAnswer_WebUserId",
            //    table: "SecurityAnswer",
            //    column: "WebUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SuccessfulCadidate_CandidateId",
            //    table: "SuccessfulCadidate",
            //    column: "CandidateId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SuccessfulCadidate_PositionId",
            //    table: "SuccessfulCadidate",
            //    column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlackList");

            migrationBuilder.DropTable(
                name: "CandidateJoinEvent");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "CV_has_Skills");

            migrationBuilder.DropTable(
                name: "QuestionLanguages");

            migrationBuilder.DropTable(
                name: "QuestionSkills");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "ResetPasswords");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "SecurityAnswer");

            migrationBuilder.DropTable(
                name: "SuccessfulCadidate");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "SecurityQuestion");

            migrationBuilder.DropTable(
                name: "ITRSInterview");

            migrationBuilder.DropTable(
                name: "Interviewer");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "CategoryQuestion");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Recruiter");

            migrationBuilder.DropTable(
                name: "CategoryPosition");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
