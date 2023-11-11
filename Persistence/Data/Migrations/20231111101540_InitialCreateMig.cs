using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departament", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "schoolarCurse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Start = table.Column<short>(type: "year", nullable: false),
                    Finish = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolarCurse", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DNI = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adress = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    IdGenderFk = table.Column<int>(type: "int", nullable: false),
                    IdPersonTypeFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_gender_IdGenderFk",
                        column: x => x.IdGenderFk,
                        principalTable: "gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_personType_IdPersonTypeFk",
                        column: x => x.IdPersonTypeFk,
                        principalTable: "personType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userrole",
                columns: table => new
                {
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    IdRoleFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => new { x.IdRoleFk, x.IdUserFk });
                    table.ForeignKey(
                        name: "FK_userrole_role_IdRoleFk",
                        column: x => x.IdRoleFk,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userrole_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersonFk = table.Column<int>(type: "int", nullable: false),
                    IdDepartamentFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teacher_departament_IdDepartamentFk",
                        column: x => x.IdDepartamentFk,
                        principalTable: "departament",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_teacher_person_IdPersonFk",
                        column: x => x.IdPersonFk,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Credits = table.Column<float>(type: "float(7,2)", nullable: false),
                    IdSubjectTypeFk = table.Column<int>(type: "int", nullable: false),
                    Curse = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Period = table.Column<sbyte>(type: "tinyint", nullable: false),
                    IdTeacherFk = table.Column<int>(type: "int", nullable: true),
                    IdGradeFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_grade_IdGradeFk",
                        column: x => x.IdGradeFk,
                        principalTable: "grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_subjectType_IdSubjectTypeFk",
                        column: x => x.IdSubjectTypeFk,
                        principalTable: "subjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_teacher_IdTeacherFk",
                        column: x => x.IdTeacherFk,
                        principalTable: "teacher",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subjectRegister",
                columns: table => new
                {
                    IdStudentFk = table.Column<int>(type: "int", nullable: false),
                    IdSubjectFk = table.Column<int>(type: "int", nullable: false),
                    IdSchoolarCurseFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectRegister", x => new { x.IdStudentFk, x.IdSubjectFk, x.IdSchoolarCurseFk });
                    table.ForeignKey(
                        name: "FK_subjectRegister_Subject_IdSubjectFk",
                        column: x => x.IdSubjectFk,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjectRegister_person_IdStudentFk",
                        column: x => x.IdStudentFk,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjectRegister_schoolarCurse_IdSchoolarCurseFk",
                        column: x => x.IdSchoolarCurseFk,
                        principalTable: "schoolarCurse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_person_IdGenderFk",
                table: "person",
                column: "IdGenderFk");

            migrationBuilder.CreateIndex(
                name: "IX_person_IdPersonTypeFk",
                table: "person",
                column: "IdPersonTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_IdUserFk",
                table: "RefreshToken",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_IdGradeFk",
                table: "Subject",
                column: "IdGradeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_IdSubjectTypeFk",
                table: "Subject",
                column: "IdSubjectTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_IdTeacherFk",
                table: "Subject",
                column: "IdTeacherFk");

            migrationBuilder.CreateIndex(
                name: "IX_subjectRegister_IdSchoolarCurseFk",
                table: "subjectRegister",
                column: "IdSchoolarCurseFk");

            migrationBuilder.CreateIndex(
                name: "IX_subjectRegister_IdSubjectFk",
                table: "subjectRegister",
                column: "IdSubjectFk");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_IdDepartamentFk",
                table: "teacher",
                column: "IdDepartamentFk");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_IdPersonFk",
                table: "teacher",
                column: "IdPersonFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userrole_IdUserFk",
                table: "userrole",
                column: "IdUserFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "subjectRegister");

            migrationBuilder.DropTable(
                name: "userrole");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "schoolarCurse");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "grade");

            migrationBuilder.DropTable(
                name: "subjectType");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "departament");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "personType");
        }
    }
}
