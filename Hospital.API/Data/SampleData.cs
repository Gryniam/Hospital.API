using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.API.Models.Entities;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Hospital.API.Data
{
    public class SampleData
    {
        public static void fillBasicData(HospitalDbContext dbContext)
        {
          
          if(!dbContext.regionTable.Any())
          {
                fillLocations(dbContext);
          }
          if (!dbContext.settlementTable.Any())
          {
                fillSettlements(dbContext);
          }

          if(!dbContext.userTable.Any())
          {
                fillUsers(dbContext);
          }

          if(!dbContext.substanceTable.Any() && !dbContext.allergiesTable.Any())
          {
                fillAllergiesAndSubstances(dbContext);
          }

          if(!dbContext.preparationTable.Any() && !dbContext.preparationsTable.Any()) 
          {
                fillPreparationAndPreparations(dbContext);
          }

         
          
          fillSymptomDiseaseAndSymptoms(dbContext);
          

          if (!dbContext.hospitalTable.Any())
          {
            fillHospitalList(dbContext);
          }

          if (!dbContext.officeTable.Any())
          {
              fillDepartamentsAndOffices(dbContext);
          }
          if (!dbContext.specialityTable.Any() && !dbContext.specialitiesTable.Any())
          {
                fillSpecialtyAndSpecialities(dbContext);
          }

          if (!dbContext.workTable.Any())
          {
              fillWorkTableAndStatus(dbContext);
          }

            
              fillCaseTable(dbContext);
            


            fillTimeAndAppoimentTimeTable(dbContext);

        }
        public static void ClearAllTables(DbContext context)
        {
            var tables = context.Model.GetEntityTypes().Select(t => t.GetTableName()).ToList();
            
            foreach(var a in tables)
            {
                context.Database.ExecuteSqlRaw($"TRUNCATE TABLE {a}");
            }
            // Зберігаємо зміни
            context.SaveChanges();
        }


        public static void fillLocations(HospitalDbContext dbContext)
        {
            var regions = new List<Region>
            {
                new Region { id = Guid.NewGuid(), name = "Вінницька область" },
                new Region { id = Guid.NewGuid(), name = "Волинська область" },
                new Region { id = Guid.NewGuid(), name = "Дніпропетровська область" },
                new Region { id = Guid.NewGuid(), name = "Донецька область" }
            };

            dbContext.regionTable.AddRange(regions);

            var districts = new List<District>();
            foreach (var region in regions)
            {
                for (int i = 1; i <= 3; i++)
                {
                    var district = new District { id = Guid.NewGuid(), name = $"Район {i} в області {region.name}", regionId = region.id };
                    districts.Add(district);
                }
            }

            dbContext.districtTable.AddRange(districts);
            dbContext.SaveChanges();


           

        }

        public static void fillSettlements(HospitalDbContext dbContext)
        {
            var allDistricts = dbContext.districtTable.ToList();

            var settlements = new List<Settlement>();
            foreach (var district in allDistricts)
            {
                for (int i = 0; i < 2; i++)
                {
                    var settlement = new Settlement { id = Guid.NewGuid(), name = $"Нас. пункт {i} в районі {district.name}", districtId = district.id };
                    settlements.Add(settlement);
                }
            }

            dbContext.settlementTable.AddRange(settlements);
            dbContext.SaveChanges();
        }

        public static void fillUsers(HospitalDbContext dbContext)
        {
            HashPassword hash = new HashPassword();
            var settlements = dbContext.settlementTable.ToList();
            if (!dbContext.genderTable.Any())
            {
                var genders = new List<Gender>
                {
                    new Gender {  genderName = "Чоловік" },
                     new Gender { genderName = "Жінка" }
                };

                dbContext.genderTable.AddRange(genders);
                dbContext.SaveChanges();
            }

            var random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                bool b = true;
                if(i > 5)
                {
                    b = false;
                }
                var user = new User
                {
                    id = Guid.NewGuid(),
                    surname = "Прізвище " + i,
                    name = "Ім'я " + i,
                    middleName = "По-батькові " + i,
                    passwordHash = hash.Hash("password"), //password
                    mail = "mail" + i + "@example.com",
                    genderId = i % 2 == 0 ? 2 : 1, 
                    birthDate = DateTime.Now.AddYears(-20 - i),
                    Age = 20 + i,
                    isAdmin = i == 1,
                    phoneNumber = "+38095123456" + i,
                    userPictureId = Guid.NewGuid(),
                    settlementId = settlements[random.Next(settlements.Count)].id
                };

                dbContext.userTable.Add(user);

                var userPicture = new UserPicture
                {
                    id = user.userPictureId,
                    picture = null,
                    base64StringPhoto = null
                };

                dbContext.userPictureTable.Add(userPicture);

                var patient = new Patient
                {
                    id = Guid.NewGuid(),
                    UserId = user.id,
                };
                dbContext.patientTable.Add(patient);
                Indexes indexes = new Indexes
                {
                    id = Guid.NewGuid(),
                    patiendId = patient.id
                };
                dbContext.indexesTable.Add(indexes);

                if (b)
                {
                    var doctor = new Doctor
                    {
                        id = Guid.NewGuid(),
                        userId = user.id,
                    };
                    dbContext.doctorTable.Add(doctor);
                }

            }
            dbContext.SaveChanges();
        }

        public static void fillAllergiesAndSubstances(HospitalDbContext context)
        {
            var patient = context.patientTable.First();

            for (int i = 0; i < 20; i++)
            {
                Substance sub = new Substance
                {
                    id = Guid.NewGuid(),
                    substanceName = $"Речовина {i + 1}"
                };
                context.substanceTable.Add(sub);
                if(i<3)
                {
                    var allergy = new Allergy
                    {
                        patiendId = patient.id,
                        substanceId = sub.id
                    };
                    context.allergiesTable.Add(allergy);
                }
            }
           
            context.SaveChanges();
        }

        public static void fillPreparationAndPreparations(HospitalDbContext context)
        {
            var substances = context.substanceTable.ToList();
            for (int i = 0; i < 5; i++)
            {
                var preparation = new Preparation
                {
                    id= Guid.NewGuid(),
                    name = $"Preparation {i + 1}",
                    substances = new List<Substance>
                    {
                          substances[i * 2],
                          substances[i * 2 + 1]
                    }
                };

                context.preparationTable.Add(preparation);

                context.preparationsTable.Add(new Preparations
                {
                    id = Guid.NewGuid(),
                    preparationId = preparation.id,
                    substanceId = preparation.substances[0].id
                });

                context.preparationsTable.Add(new Preparations
                {
                    id  = Guid.NewGuid(),
                    preparationId = preparation.id,
                    substanceId = preparation.substances[1].id
                });
            }

            context.SaveChanges();
        }

        //пофіксити
        public static void fillSymptomDiseaseAndSymptoms(HospitalDbContext context)
        {
            if(!context.symptomTable.Any())
            {
                for (int i = 1; i <= 20; i++)
                {
                    context.symptomTable.Add(new Symptom { id = Guid.NewGuid(), name = $"Symptom{i}" });
                }
                context.SaveChanges();
            }
           
            if(!context.diseaseTable.Any())
            {
                var random = new Random();

                for (int i = 1; i <= 10; i++)
                {
                    var disease = new Disease { id = Guid.NewGuid(), name = $"Disease{i}" };
                    List<Symptom> symptoms = context.symptomTable.OrderBy(s => Guid.NewGuid()).Take(3).ToList();
                    for (int j = 0; j < 3; j++)
                    {
                        // зберігаємо запис про зв'язок між хворобою та симптомом
                        context.symptomsTable.Add(new Symptoms { id = Guid.NewGuid(), diseaseId = disease.id, symptomId = symptoms[j].id });
                    }
                    context.diseaseTable.Add(disease);
                }
                context.SaveChanges();
            }
        }

        public static void fillHospitalList(HospitalDbContext context)
        {
            List<Models.Entities.Type> types = new List<Models.Entities.Type>();
            string[] typeNames = { "Type1", "Type2", "Type3", "Type4", "Type5" };
            for (int i = 0; i < typeNames.Length; i++)
            {
                Models.Entities.Type type = new Models.Entities.Type
                {
                    name = typeNames[i]
                };
                types.Add(type);
            }
            context.typeTable.AddRange(types);
            context.SaveChanges();

            Random random = new Random();
            List<Models.Entities.Hospital> hospitals = new List<Models.Entities.Hospital>();
            List<Guid> settlementIds = context.settlementTable.Select(s => s.id).ToList();
            for (int i = 0; i < 3; i++)
            {
                int randomTypeId = random.Next(1, 6);
                Guid randomSettlementId = settlementIds[random.Next(settlementIds.Count)];
                Settlement settlement = context.settlementTable.FirstOrDefault(s => s.id == randomSettlementId);
                if (settlement != null)
                {
                    Guid districtId = settlement.districtId;
                    District district = context.districtTable.FirstOrDefault(d => d.id == districtId);
                    if (district != null)
                    {
                        Guid regionId = district.regionId;
                        Region region = context.regionTable.FirstOrDefault(r => r.id == regionId);
                        if (region != null)
                        {
                            Models.Entities.Hospital hospital = new Models.Entities.Hospital
                            {
                                name = "Hospital " + i,
                                regionId = regionId,
                                districtId = districtId,
                                settlementId = randomSettlementId,
                                typeId = randomTypeId,
                                contactNumber = "+380981097188",
                                description = "Description",
                                adressDescription = "Hospital"
                            };
                            hospitals.Add(hospital);
                        }
                    }
                }
            }
            context.hospitalTable.AddRange(hospitals);
            context.SaveChanges();
        }

        public static void fillDepartamentsAndOffices(HospitalDbContext dbContext)
        {
            List<Models.Entities.Hospital> hospitals = dbContext.hospitalTable.ToList();

            foreach (Models.Entities.Hospital hospital in hospitals)
            {
                // Створюємо два департаменти для кожної лікарні
                Departament department1 = new Departament
                {
                    hospitalId = hospital.id,
                    name = "Department 1",
                    additionalInformation = "Additional information 1"
                };

                Departament department2 = new Departament
                {
                    hospitalId = hospital.id,
                    name = "Department 2",
                    additionalInformation = "Additional information 2"
                };

                // Додаємо департаменти до бази даних і зберігаємо зміни
                dbContext.departamentTable.Add(department1);
                dbContext.departamentTable.Add(department2);
                dbContext.SaveChanges();


                List<Departament> departments = dbContext.departamentTable.ToList();

                // Для кожного департаменту створити по 2 офіси та додати їх до списку офісів департаменту
                foreach (Departament department in departments)
                {
                    List<Office> offices = new List<Office>();

                    for (int i = 1; i <= 2; i++)
                    {
                        Office office = new Office
                        {
                            id = Guid.NewGuid(),
                            name = $"Офіс {i} департаменту {department.name}",
                            numberInHospital = i,
                            additionalInformation = $"Офіс  {i} в департаменті {department.name}"
                        };

                        offices.Add(office);
                        dbContext.officeTable.Add(office);
                    }

                    // Зберегти зміни в базі даних, щоб отримати id офісів
                    dbContext.SaveChanges();

                    // Для кожного офісу додати зв'язок з департаментом та зберегти зміни в базі даних
                    foreach (Office office in offices)
                    {
                        Offices departmentOffice = new Offices
                        {
                            id = Guid.NewGuid(),
                            officeId = office.id,
                            departamentId = department.id
                        };

                        //department.officesList.Add(departmentOffice);
                        dbContext.officesTable.Add(departmentOffice);
                    }

                    // Зберегти зміни в базі даних
                    dbContext.SaveChanges();
                }
            }
        }

        public static void fillSpecialtyAndSpecialities(HospitalDbContext context)
        {
            Random rnd = new Random();
            List<string> specialityNames = new List<string> { "Cardiologist", "Dermatologist", 
                "Endocrinologist", "Gastroenterologist", "Hematologist", "Neurologist", 
                "Oncologist", "Ophthalmologist", "Pediatrician", "Psychiatrist", 
                "Rheumatologist", "Urologist", "Allergist", "Anesthesiologist", "Chiropractor", 
                "ENT Specialist", "Gynecologist", "Internist", "Orthopedist", "Physical therapist" };

            List<Specialty> specialties = new List<Specialty>();
            for (int i = 0; i < 20; i++)
            {
                string randomName = specialityNames[rnd.Next(specialityNames.Count)];
                specialties.Add(new Specialty {id = Guid.NewGuid(), Name = randomName });
            }

            context.specialityTable.AddRange(specialties);
            context.SaveChanges();



            List<Doctor> doctors  = context.doctorTable.ToList();
            List<Specialities> specialities = new List<Specialities>();

            foreach (var doctor in doctors)
            {
                for (int i = 0; i < 2; i++)
                {
                    var randomSpecialty = specialties[rnd.Next(specialties.Count)];
                    specialities.Add(new Specialities {Id = Guid.NewGuid() ,doctorId = doctor.id, specialityId = randomSpecialty.id });
                }
            }

            context.specialitiesTable.AddRange(specialities);
            context.SaveChanges();
        }


        //Тут не заповнює
        public static void fillWorkTableAndStatus(HospitalDbContext context)
        {
            var activeStatus = new Status { status = "Активний" };
            var inactiveStatus = new Status { status = "Неактивний" };
            context.statusTable.Add(activeStatus);
            context.statusTable.Add(inactiveStatus);
            context.SaveChanges();

            // get all doctors from doctorTable
            var doctors = context.doctorTable.ToList();

            // get all hospitals from hospitalTable
            var hospitals = context.hospitalTable.ToList();

            var random = new Random();

            foreach (var doctor in doctors)
            {
                
                var hospital = hospitals[random.Next(hospitals.Count)];

                hospital.departaments = context.departamentTable.ToList();

                var status = context.statusTable.ToList()[random.Next(2)];
                var department = hospital.departaments[random.Next(hospital.departaments.Count)];

                var officesInDepartament = context.officesTable.Where(x=> x.departamentId == department.id).ToList();

                Work work;
                while(true)
                {
                    var randomOffice = officesInDepartament[random.Next(officesInDepartament.Count)].officeId;
                    if(!context.workTable.Any(x=>x.officeId != randomOffice))
                    {
                        work = new Work
                        {
                            id = Guid.NewGuid(),
                            doctorId = doctor.id,
                            hospitalId = hospital.id,
                            statusId = status.id,
                            departamentId = department.id,
                            officeId = officesInDepartament[random.Next(officesInDepartament.Count)].officeId

                        };
                        break;
                    }
                    
                }
                
                
                //Тут треба зробити закономірність. Щоб офіси не дублювались

                if (doctors.IndexOf(doctor) < 3)
                {
                    work.isAdminInHospital = true;
                    work.isAdminInDepartament = true;
                }

                context.workTable.Add(work);
            }
            context.SaveChanges();

        }

        public static void fillCaseTable(HospitalDbContext context)
        {
            var random = new Random();
            if(!context.casesStatusTable.Any())
            {
                var caseStatuses = new List<CaseStatus>
            {
                 new CaseStatus {statusName = "Активний"},
                 new CaseStatus {statusName = "Неактивний"},
            };
                context.casesStatusTable.AddRange(caseStatuses);
                context.SaveChanges();
            }
            

            //List<Case> cases = new List<Case>();
            //for(int i = 0; i < 2; i++)
            //{
            //    var randomPatient = context.patientTable.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            //    // отримуємо рандомного лікаря із таблиці Doctor
            //    var randomDoctor = context.doctorTable.Where(x => x.userId != randomPatient.UserId).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            //    // отримуємо рандомну хворобу із таблиці Disease
            //    var randomDisease = context.diseaseTable.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            //    // отримуємо рандомний статус із таблиці CaseStatus
            //    var randomCaseStatus = context.casesStatusTable.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            //    // отримуємо рандомний офіс із таблиці Office
            //    var randomOffice = context.officeTable.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            //    var caseS = new Case
            //    {
            //        id = Guid.NewGuid(),
            //        patientId = randomPatient.id,
            //        doctorId = randomDoctor.id,
            //        diseaseId = randomDisease.id,
            //        caseStatusId = randomCaseStatus.id,
            //        officeId = randomOffice.id,
            //        anamnesis = "test1",
            //        createDate = DateTime.Now
            //    };

            //    cases.Add(caseS);
            //}
            

           
            
            //context.caseTable.AddRange(cases);
            //context.SaveChanges();

            //var preparations = context.preparationTable.ToList();
            ////var mYcases = context.caseTable.ToList();

            //List<Treatment> treatments = new List<Treatment>();
            //foreach (var caseItem in cases)
            //{
            //    // Get two random preparations
            //    var preparation1 = preparations[random.Next(preparations.Count)];
            //    var preparation2 = preparations[random.Next(preparations.Count)];

            //    // Create treatments for each preparation
            //    treatments.Add(new Treatment { preparation = preparation1 });
            //    treatments.Add(new Treatment { preparation = preparation2 });
            //}

            //context.treatmentTable.AddRange(treatments);
            //context.SaveChanges();
        }


        public static void fillTimeAndAppoimentTimeTable(HospitalDbContext context)
        {
            if (!context.timeTable.Any())
            {
                for (int i = 10; i < 18; i++)
                {
                    for (int j = 0; j < 60; j += 20)
                    {
                        context.timeTable.Add(new Time
                        {
                            id = Guid.NewGuid(),
                            time = $"{i}:{j}"
                        });
                    }
                }
                context.SaveChanges();
            }
            
            if(!context.timesTable.Any())
            {
                var doctors = context.doctorTable.Where(x => context.workTable.Any());

                var doctor = doctors.First();
                var office = context.workTable.FirstOrDefault(x => x.doctorId == doctor.id);

                for (int i = 0; i < 5; i++)
                {

                    Time time = null;
                    foreach(var iterator in context.timeTable.ToList())
                    {
                        if (!context.timesTable.Any(x=>x.timeId == iterator.id))
                        {
                            time = iterator;
                            break;
                        }
                    }

                    
                    context.timesTable.Add(new Times
                    {
                        Id = Guid.NewGuid(),
                        doctorId = doctor.id,
                        timeId = time.id,
                        officeId = office.officeId
                    });
                    context.SaveChanges();
                }
                //context.SaveChanges();
            }

            
        }

        
    }
}
