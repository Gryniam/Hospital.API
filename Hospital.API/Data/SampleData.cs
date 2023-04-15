using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.API.Models.Entities;
using System.IO;

namespace Hospital.API.Data
{
    public class SampleData
    {
        public static void fillBasicData(HospitalDbContext dbContext)
        {
          
           if(!dbContext.diseaseTable.Any()) {
                dbContext.diseaseTable.Add(new Disease
                {
                    id = Guid.NewGuid(),
                    name = "Запалення легенів"
                });
           }

           if(!dbContext.genderTable.Any())
           {
                dbContext.genderTable.Add(new Gender
                {
                    genderName = "Чоловік"
                });
                dbContext.genderTable.Add(new Gender
                {
                    genderName = "Жінка"
                });
                dbContext.genderTable.Add(new Gender
                {
                    genderName = "Вийняток"
                });
                dbContext.SaveChanges();
            }

           if(!dbContext.officeTable.Any())
           {
                dbContext.officeTable.Add(new Office
                {
                    id = Guid.NewGuid(),
                    name = "Палата стаціонарна",
                    numberInHospital = 612
                });
                dbContext.officeTable.Add(new Office
                {
                    id = Guid.NewGuid(),
                    name = "Палата стаціонарна",
                    numberInHospital = 316
                });
                dbContext.officeTable.Add(new Office
                {
                    id = Guid.NewGuid(),
                    name = "Кабінет УЗД",
                    numberInHospital = 210
                });
                dbContext.SaveChanges();
            }  
           //Add indexes

           if(!dbContext.regionTable.Any())
           {
                dbContext.regionTable.Add(new Region
                {
                    id = Guid.NewGuid(),
                    name = "Івано-Франківська"
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.districtTable.Any())
            {
                dbContext.districtTable.Add(new District
                {
                    id = Guid.NewGuid(),
                    name = "Коломийський",
                    regionId = dbContext.regionTable.First(x=>x.name == "Івано-Франківська").id
                    
                }
                );
                dbContext.SaveChanges();
            }
            if (!dbContext.settlementTable.Any())
           {
                dbContext.settlementTable.Add(new Settlement
                {
                    id = Guid.NewGuid(),
                    name = "Коломия",
                    districtId = dbContext.districtTable.First(x=>x.name == "Коломийський").id
                });
                dbContext.SaveChanges();
            }

           if (!dbContext.specialityTable.Any())
           {
                dbContext.specialityTable.Add(
                    new Specialty
                    {
                        Name = "Лікар-невролог"
                    });
                dbContext.specialityTable.Add(
                    new Specialty
                    {
                        Name = "Лікар-педіатр"
                    });
                dbContext.SaveChanges();
           }
           if (!dbContext.statusTable.Any())
           {
                dbContext.statusTable.Add(
                    new Status
                    {
                        status = "Активний"
                    });
                dbContext.statusTable.Add(
                    new Status
                    {
                        status = "Неактивний"
                    });
                dbContext.SaveChanges();
            }

            if (!dbContext.substanceTable.Any())
            {
                dbContext.substanceTable.Add(
                    new Substance { 
                        id = Guid.NewGuid(),
                        substanceName = "Е235"
                    }
                    );
                dbContext.substanceTable.Add(
                    new Substance
                    {
                        id = Guid.NewGuid(),
                        substanceName = "Лейкоза"
                    }
                    );
                dbContext.SaveChanges();
            }

            if (!dbContext.preparationTable.Any())
            {
                dbContext.preparationTable.Add(new Preparation
                {
                    id = Guid.NewGuid(),
                    name = "Азитроміцин"
                });
                dbContext.preparationTable.Add(new Preparation
                {
                    id = Guid.NewGuid(),
                    name = "Азитроміцин-лейкоцин"
                });
                dbContext.SaveChanges();
            }
            
            if (!dbContext.preparationsTable.Any())
            {
                dbContext.preparationsTable.Add(new Preparations
                {
                    id = Guid.NewGuid(),
                    preparationId = dbContext.preparationTable.First(x=>x.name == "Азитроміцин").id,
                    substanceId = dbContext.substanceTable.First(x=>x.substanceName == "Е235").id  
                }) ;
                dbContext.preparationsTable.Add(new Preparations
                {
                    id = Guid.NewGuid(),
                    preparationId = dbContext.preparationTable.First(x => x.name == "Азитроміцин-лейкоцин").id,
                    substanceId = dbContext.substanceTable.First(x => x.substanceName == "Е235").id
                });
                dbContext.preparationsTable.Add(new Preparations
                {
                    id = Guid.NewGuid(),
                    preparationId = dbContext.preparationTable.First(x => x.name == "Азитроміцин-лейкоцин").id,
                    substanceId = dbContext.substanceTable.First(x => x.substanceName == "Лейкоза").id
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.symptomTable.Any())
            {
                dbContext.symptomTable.Add(
                    new Symptom {
                        id = Guid.NewGuid(),
                        name = "Кашель"
                    });
                dbContext.symptomTable.Add(
                   new Symptom
                   {
                       id = Guid.NewGuid(),
                       name = "Висока температура"
                   });
                dbContext.SaveChanges();
            }
            if (!dbContext.typeTable.Any())
            {
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Госпіталь для інвалідів війни"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Районна лікарня"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Обласна лікарня"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Дитяча басейнова лікарня на водному транспорті"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Дитяча лікарня"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Дитяче територіальне медичне об’єднання"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Дільнична лікарня"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Лікарня"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Лікарня на водному транспорті"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Лікувально-діагностичний центр"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Медичний центр"
                });
                dbContext.typeTable.Add(new Models.Entities.Type
                {
                    name = "Інфекційна лікарня"
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.statusTable.Any())
            {
                dbContext.statusTable.Add(new Status
                {
                    status = "Працює"
                }) ;
                dbContext.statusTable.Add(new Status
                {
                    status = "Не працює"
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.userTable.Any())
            {
                HashPassword p = new HashPassword();
                Guid pictureId = Guid.NewGuid();
                Guid Id = Guid.NewGuid();
                dbContext.userTable.Add(new User
                {
                    id = Id,
                    surname = "Гриньків",
                    name = "Владислав",
                    middleName = "Іванович",
                    passwordHash = p.Hash("passwordOne"),
                    Age = 21,
                    birthDate = new DateTime(2002, 05, 22),
                    mail = "muzikaeng@gmail.com",
                    genderId = dbContext.genderTable.First(x=>x.genderName == "Чоловік").id,
                    isAdmin = true,
                    userPictureId = pictureId,
                    phoneNumber = "+380981086166"
                });
                dbContext.patientTable.Add(new Patient
                {
                    id = Guid.NewGuid(),
                    UserId = Id
                }) ;
                dbContext.userPictureTable.Add(new UserPicture
                {
                    id = pictureId,
                    //picture = File.ReadAllBytes("D:\\Study\\Doctor.png")
                    picture = null
                });
                Id = Guid.NewGuid();
                dbContext.userTable.Add(new User
                {
                    id = Id,
                    surname = "Гриньків",
                    name = "Олег",
                    middleName = "Іванович",
                    Age = 18,
                    birthDate = new DateTime(2002, 05, 22),
                    passwordHash = p.Hash("passwordTwo"),
                    mail = "muzikager@gmail.com",
                    genderId = dbContext.genderTable.First(x => x.genderName == "Чоловік").id,
                    isAdmin = true,
                    phoneNumber = "+380981086166"
                }) ;
                dbContext.patientTable.Add(new Patient
                {
                    id = Guid.NewGuid(),
                    UserId = Id
                });
                dbContext.SaveChanges();
            }

            if(!dbContext.symptomsTable.Any())
            {
                dbContext.symptomsTable.Add(new Symptoms
                {
                    id = Guid.NewGuid(),
                    diseaseId = dbContext.diseaseTable.First(x => x.name == "Запалення легенів").id,
                    symptomId = dbContext.symptomTable.First(x=>x.name == "Кашель").id
                    
                }) ;
                dbContext.symptomsTable.Add(new Symptoms
                {
                    id = Guid.NewGuid(),
                    diseaseId = dbContext.diseaseTable.First(x => x.name == "Запалення легенів").id,
                    symptomId = dbContext.symptomTable.First(x => x.name == "Висока температура").id

                });
                dbContext.SaveChanges();
            }

            if (!dbContext.timeTable.Any())
            {
                for (int i = 10; i <= 18; i++)
                {
                    dbContext.timeTable.Add(new Time
                    {
                        id = Guid.NewGuid(),
                        doctorId = dbContext.doctorTable.First(
                        x => x.userId == dbContext.userTable.First(
                            x => x.mail == "muzikager@gmail.com").id).id,
                        time = $"{i}:00"
                    });
                }
                dbContext.SaveChanges();
            }

            if (!dbContext.doctorTable.Any())
            {
                dbContext.doctorTable.Add(new Doctor
                {
                    id = Guid.NewGuid(),
                    userId = dbContext.userTable.First(x => x.mail == "muzikager@gmail.com").id,
                    additionalInformation = "Test Doctor",
                    phoneNumber = "+380981086166"
                    
                }) ;
                dbContext.doctorTable.Add(new Doctor
                {
                    id = Guid.NewGuid(),
                    userId = dbContext.userTable.First(x => x.mail == "muzikaeng@gmail.com").id,
                    additionalInformation = "Test Doctor2",
                    phoneNumber = "+380981086167"

                });


                dbContext.SaveChanges();
            }

            if (!dbContext.specialitiesTable.Any())
            {
                Guid userIdForDoctor = dbContext.userTable.First(x => x.mail == "muzikager@gmail.com").id;
                dbContext.specialitiesTable.Add(new Specialities
                {
                    doctorId = dbContext.doctorTable.First(x => x.userId == userIdForDoctor).id,
                    specialityId = dbContext.specialityTable.First(x => x.Name == "Лікар-невролог").id
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.hospitalTable.Any())
            {
                dbContext.hospitalTable.Add(new Models.Entities.Hospital
                {
                    id = Guid.NewGuid(),
                    name = "Коломийська районна лікарня",
                    regionId = dbContext.regionTable.First(x => x.name == "Івано-Франківська").id,
                    districtId = dbContext.districtTable.First(x=>x.name == "Коломийський").id,
                    settlementId = dbContext.settlementTable.First(x=>x.name == "Коломия").id,
                    typeId = dbContext.typeTable.First(x=>x.name == "Районна лікарня").id,
                    contactNumber = "+380662748934",
                    description = "Test Hospital"
                }) ;
                dbContext.SaveChanges();
            }

            if (!dbContext.workTable.Any())
            {
                dbContext.workTable.Add(new Work
                {
                    id = Guid.NewGuid(),
                    doctorId = dbContext.doctorTable.First(
                        x => x.userId == dbContext.userTable.First(
                            x => x.mail == "muzikager@gmail.com").id).id,
                    hospitalId = dbContext.hospitalTable.First(x => x.name == "Коломийська районна лікарня").id,
                    statusId = dbContext.statusTable.First(x => x.status == "Активний").id,
                    isAdminInHospital = true,
                    isAdminInDepartament = true,
                    departamentId = dbContext.departamentTable.First(x => x.name == "Відділення неврології").id

                });
            }

            if (!dbContext.departamentTable.Any())
            {
                dbContext.departamentTable.Add(new Departament
                {
                    id = Guid.NewGuid(),
                    hospitalId = dbContext.hospitalTable.First(
                        x=>x.name == "Коломийська районна лікарня").id,
                    name = "Відділення неврології",
                    additionalInformation = "Test departament"

                });
                dbContext.departamentTable.Add(new Departament
                {
                    id = Guid.NewGuid(),
                    hospitalId = dbContext.hospitalTable.First(
                        x => x.name == "Коломийська районна лікарня").id,
                    name = "Відділення діагностики",
                    additionalInformation = "Test departament"

                });
                dbContext.SaveChanges();
            }

            if (!dbContext.officesTable.Any())
            {
                dbContext.officesTable.Add(new Offices
                {
                    id = Guid.NewGuid(),
                    departamentId = dbContext.departamentTable.First(
                        x=>x.name == "Відділення неврології").id,
                    officeId = dbContext.officeTable.First(x=>x.numberInHospital == 612).id,
                });
                dbContext.officesTable.Add(new Offices
                {
                    id = Guid.NewGuid(),
                    departamentId = dbContext.departamentTable.First(
                        x => x.name == "Відділення неврології").id,
                    officeId = dbContext.officeTable.First(x => x.numberInHospital == 316).id,
                });
                dbContext.officesTable.Add(new Offices
                {
                    id = Guid.NewGuid(),
                    departamentId = dbContext.departamentTable.First(
                        x => x.name == "Відділення діагностики").id,
                    officeId = dbContext.officeTable.First(x => x.numberInHospital == 210).id,
                });
                dbContext.SaveChanges();
            }
            if (!dbContext.casesStatusTable.Any())
            {
                dbContext.casesStatusTable.Add(new CaseStatus
                {
                    id = Guid.NewGuid(),
                    statusName = "Пацієнт вилікувався"
                });
                dbContext.casesStatusTable.Add(new CaseStatus
                {
                    id = Guid.NewGuid(),
                    statusName = "У процесі"
                });
                dbContext.casesStatusTable.Add(new CaseStatus
                {
                    id = Guid.NewGuid(),
                    statusName = "Пацієнт помер"
                });
                dbContext.casesStatusTable.Add(new CaseStatus
                {
                    id = Guid.NewGuid(),
                    statusName = "Заплановано повторне лікування"
                });
                dbContext.casesStatusTable.Add(new CaseStatus
                {
                    id = Guid.NewGuid(),
                    statusName = "Пацієнт відправлений на діагностику"
                });
                dbContext.SaveChanges();
            }

            if (!dbContext.caseTable.Any())
            {
                dbContext.caseTable.Add(new Case
                {
                    id = Guid.NewGuid(),
                    patientId = dbContext.patientTable.First(
                        x => x.UserId == dbContext.userTable.First(
                            x => x.mail == "muzikaeng@gmail.com").id).id,
                    doctorId = dbContext.doctorTable.First(
                        x => x.userId == dbContext.userTable.First(
                            x => x.mail == "muzikager@gmail.com").id).id,
                    diseaseId = dbContext.diseaseTable.First(
                        x => x.name == "Запалення легенів").id,
                    caseStatusId = dbContext.casesStatusTable.First(
                        x => x.statusName == "У процесі").id,
                    officeId = dbContext.officeTable.First(
                        x=>x.numberInHospital == 612).id,
                    anamnesis = "Test anamnesis",
                    treatmentInformation = "Will be soon",
                    createDate = DateTime.Now
                });
                dbContext.SaveChanges();
            }
            if(!dbContext.allergiesTable.Any())
            {
                dbContext.allergiesTable.Add(new Allergy
                {
                    id = Guid.NewGuid(),
                    patiendId = dbContext.patientTable.First(
                        x => x.UserId == dbContext.userTable.First(
                            x => x.mail == "muzikaeng@gmail.com").id).id,
                    substanceId = dbContext.substanceTable.First(x => x.substanceName == "Е235").id
                });
            }

            dbContext.SaveChanges();
        }
    }
}
