using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.API.Migrations
{
    /// <inheritdoc />
    public partial class Firstinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allergiesTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patiendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    substanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allergiesTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "analysTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    officeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    additionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_analysTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appoimentTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    timeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    officeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appoimentTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "casesStatusTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    statusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_casesStatusTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "caseTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patiendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    diseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caseStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    officeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    anamnesis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    treatmentInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caseTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countryTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departamentTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hospitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    additionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "diseaseTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diseaseTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "districtTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districtTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctorTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    additionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genderTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genderTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hospitalTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    regionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    districtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    settlementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitalTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "indexesTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patiendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    height = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    bloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pulse = table.Column<int>(type: "int", nullable: false),
                    bloodSugar = table.Column<float>(type: "real", nullable: false),
                    bodyTemperature = table.Column<float>(type: "real", nullable: false),
                    additionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_indexesTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "officesTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    officeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    departamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_officesTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "officeTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberInHospital = table.Column<int>(type: "int", nullable: false),
                    additionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_officeTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patientTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "preparationsTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    preparationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    substanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preparationsTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "preparationTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preparationTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regionTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regionTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "settlementTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    districtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settlementTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specialitiesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    specialityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialitiesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specialityTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialityTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statusTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "substanceTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    substanceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_substanceTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "symptomsTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    diseaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    symptomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptomsTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "symptomTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_symptomTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "timeTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timeTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "treatmentTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    preparationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatmentTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "typeTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userPictureTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userPictureTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genderId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    userPictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workTable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hospitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    isAdminInHospital = table.Column<bool>(type: "bit", nullable: false),
                    isAdminInDepartament = table.Column<bool>(type: "bit", nullable: false),
                    departamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workTable", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "allergiesTable");

            migrationBuilder.DropTable(
                name: "analysTable");

            migrationBuilder.DropTable(
                name: "appoimentTable");

            migrationBuilder.DropTable(
                name: "casesStatusTable");

            migrationBuilder.DropTable(
                name: "caseTable");

            migrationBuilder.DropTable(
                name: "countryTable");

            migrationBuilder.DropTable(
                name: "departamentTable");

            migrationBuilder.DropTable(
                name: "diseaseTable");

            migrationBuilder.DropTable(
                name: "districtTable");

            migrationBuilder.DropTable(
                name: "doctorTable");

            migrationBuilder.DropTable(
                name: "genderTable");

            migrationBuilder.DropTable(
                name: "hospitalTable");

            migrationBuilder.DropTable(
                name: "indexesTable");

            migrationBuilder.DropTable(
                name: "officesTable");

            migrationBuilder.DropTable(
                name: "officeTable");

            migrationBuilder.DropTable(
                name: "patientTable");

            migrationBuilder.DropTable(
                name: "preparationsTable");

            migrationBuilder.DropTable(
                name: "preparationTable");

            migrationBuilder.DropTable(
                name: "regionTable");

            migrationBuilder.DropTable(
                name: "settlementTable");

            migrationBuilder.DropTable(
                name: "specialitiesTable");

            migrationBuilder.DropTable(
                name: "specialityTable");

            migrationBuilder.DropTable(
                name: "statusTable");

            migrationBuilder.DropTable(
                name: "substanceTable");

            migrationBuilder.DropTable(
                name: "symptomsTable");

            migrationBuilder.DropTable(
                name: "symptomTable");

            migrationBuilder.DropTable(
                name: "timeTable");

            migrationBuilder.DropTable(
                name: "treatmentTable");

            migrationBuilder.DropTable(
                name: "typeTable");

            migrationBuilder.DropTable(
                name: "userPictureTable");

            migrationBuilder.DropTable(
                name: "userTable");

            migrationBuilder.DropTable(
                name: "workTable");
        }
    }
}
