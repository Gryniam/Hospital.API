using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.API.Data
{
    public class ManualData
    {
        
        public static void fillData(HospitalDbContext context)
        {
            HashPassword hash = new HashPassword();
            List<Region> regions = new List<Region>
            {
                new Region{id = Guid.Parse("d453a27f-c4da-5ec9-9a36-ee09c08f6872"), name = "Івано-Франківська область"},
                new Region { id = Guid.Parse("a2346c65-82eb-598c-b4ad-0fff0f8b7304"), name = "Полтавська область" },
                new Region { id = Guid.Parse("67ce66d4-0d6b-59c9-9cd0-f3e4466a4fa5"), name = "Львівська область" },
                new Region { id = Guid.Parse("b31b3231-954f-572c-8526-2ab81a383d1f"), name = "Чернігівська область" },
                new Region { id = Guid.Parse("8182b86e-9356-5708-8e08-d88877c34264"), name = "Бєлгородська область" },
                new Region { id = Guid.Parse("8976a1a6-ec10-567d-bf04-3416c9393826"), name = "Кременчуцька область" },
                new Region { id = Guid.Parse("e61208cc-72b3-5018-954b-695815277ebc"), name = "Кримська область" },
                new Region { id = Guid.Parse("b0f5a1b7-e1b9-5b9b-9bec-4955ed64dca5"), name = "Донецька область" }
            };
            if (!context.regionTable.Any())
            {
                context.regionTable.AddRange(regions);
                context.SaveChanges();
            }

            List<District> districts = new List<District>
            {
                new District{id = Guid.Parse("82667681-ab2f-5c8c-a044-594b398d0ba4"), name = "Коломия", regionId = Guid.Parse("d453a27f-c4da-5ec9-9a36-ee09c08f6872")},
                new District{id = Guid.Parse("4d0065b5-c0da-51b9-a565-48c2d9914598"), name = "Івано-Франківськ", regionId = Guid.Parse("d453a27f-c4da-5ec9-9a36-ee09c08f6872")},
                new District{id = Guid.Parse("4100a843-d766-5adb-b046-213d67c73f79"), name = "Львів", regionId = Guid.Parse("67ce66d4-0d6b-59c9-9cd0-f3e4466a4fa5")},
                new District{id = Guid.Parse("abc46f3f-3d45-5f78-8391-8921ab2ad72f"), name = "Кобилянськ", regionId = Guid.Parse("67ce66d4-0d6b-59c9-9cd0-f3e4466a4fa5")},
                new District{id = Guid.Parse("f6a7a7cf-9c81-5454-884a-aaa6d3f2b8c4"), name = "Армагедонськ", regionId = Guid.Parse("b31b3231-954f-572c-8526-2ab81a383d1f")},
                new District{id = Guid.Parse("0df12eac-b65a-5f73-8cc3-57cc86d23e0f"), name = "Калуш", regionId = Guid.Parse("a2346c65-82eb-598c-b4ad-0fff0f8b7304")},
                new District{id = Guid.Parse("787aef9c-b137-5a78-9a1f-133bdddbb9c7"), name = "Коронавіруснівка", regionId = Guid.Parse("a2346c65-82eb-598c-b4ad-0fff0f8b7304")},
                new District{id = Guid.Parse("d51faff2-29ab-5793-94d4-69b4990d0fab"), name = "Барбарисівка", regionId = Guid.Parse("8182b86e-9356-5708-8e08-d88877c34264")},
                new District{id = Guid.Parse("a48d85ef-66d0-50da-8f5e-3aad733efe70"), name = "Песпатронівськ", regionId = Guid.Parse("8976a1a6-ec10-567d-bf04-3416c9393826")},
                new District{id = Guid.Parse("ae9b757f-d5ac-51ac-a7e3-a65130377a5d"), name = "Гріндей", regionId = Guid.Parse("8976a1a6-ec10-567d-bf04-3416c9393826")},
                new District{id = Guid.Parse("f9a055ae-ca9f-58e6-b759-3e8ddc2ab31e"), name = "Нью-Йорк", regionId = Guid.Parse("e61208cc-72b3-5018-954b-695815277ebc")},
                new District{id = Guid.Parse("1f2b2de9-9925-56c4-8cdf-a011c6313f9c"), name = "Майнд", regionId = Guid.Parse("e61208cc-72b3-5018-954b-695815277ebc")},
                new District{id = Guid.Parse("8e4ce857-8547-5e7e-bbda-d9b5e62b2305"), name = "Ялта", regionId = Guid.Parse("b0f5a1b7-e1b9-5b9b-9bec-4955ed64dca5")},
                new District{id = Guid.Parse("a92dfabb-ad00-5fd4-8dde-7cbd2261358a"), name = "Долина", regionId = Guid.Parse("b0f5a1b7-e1b9-5b9b-9bec-4955ed64dca5")}
            };
            if (!context.districtTable.Any())
            {
                context.districtTable.AddRange(districts);
                context.SaveChanges();
            }
            List<Settlement> settlements = new List<Settlement>
            {
                new Settlement{id = Guid.Parse("89ba72c2-3ca1-5f1c-9912-45c5fdf86deb"), name = "Zihpuvir", districtId = Guid.Parse("82667681-ab2f-5c8c-a044-594b398d0ba4")},
                new Settlement{id = Guid.Parse("77c50afd-6911-57cc-b2ac-21a7eedd7275"), name = "Harusuz", districtId = Guid.Parse("82667681-ab2f-5c8c-a044-594b398d0ba4")},
                new Settlement{id = Guid.Parse("18b07c02-6f3f-50d0-8915-599d604a3ec2"), name = "Jadedse", districtId = Guid.Parse("4d0065b5-c0da-51b9-a565-48c2d9914598")},
                new Settlement{id = Guid.Parse("7b63c245-e6dd-530f-a083-c04f20a01b7f"), name = "Mukuruw", districtId = Guid.Parse("4d0065b5-c0da-51b9-a565-48c2d9914598")},
                new Settlement{id = Guid.Parse("485c3429-b8e5-5894-9764-8402376cd77e"), name = "Heefote", districtId = Guid.Parse("4100a843-d766-5adb-b046-213d67c73f79")},
                new Settlement{id = Guid.Parse("66e45772-37f0-5a6a-8d48-79a048fa94ef"), name = "Umemebi", districtId = Guid.Parse("4100a843-d766-5adb-b046-213d67c73f79")},
                new Settlement{id = Guid.Parse("03b68f2a-eee6-5eda-b58c-a6338c7991c9"), name = "Tuocca", districtId = Guid.Parse("abc46f3f-3d45-5f78-8391-8921ab2ad72f")},
                new Settlement{id = Guid.Parse("16f7ebc8-61e1-5e06-84ae-33ea3b4b4c77"), name = "Ricwehmuv", districtId = Guid.Parse("abc46f3f-3d45-5f78-8391-8921ab2ad72f")},
                new Settlement{id = Guid.Parse("6f30444f-43c0-59ee-83a1-8368c32571d7"), name = "Rasefenef", districtId = Guid.Parse("f5d797df-8a39-5109-bce2-30e42b9b3dc0")},
                new Settlement{id = Guid.Parse("59ad1d7a-8d61-5de5-8612-9d5b6b973cf8"), name = "Ruwnead", districtId = Guid.Parse("f5d797df-8a39-5109-bce2-30e42b9b3dc0")},
                new Settlement{id = Guid.Parse("66aa3a9b-932f-5f39-9efe-cfabeb4a1abc"), name = "Detiro", districtId = Guid.Parse("0df12eac-b65a-5f73-8cc3-57cc86d23e0f")},
                new Settlement{id = Guid.Parse("208874bf-fa01-59a7-919b-eb7d10da08cb"), name = "Puniteg", districtId = Guid.Parse("0df12eac-b65a-5f73-8cc3-57cc86d23e0f")},
                new Settlement{id = Guid.Parse("7c9ba39d-92d8-555a-bcb9-4cb25c19ba1e"), name = "Winbeiri", districtId = Guid.Parse("787aef9c-b137-5a78-9a1f-133bdddbb9c7")},
                new Settlement{id = Guid.Parse("c172e2c3-887f-5460-92e6-3a88749ed34f"), name = "Unkopat", districtId = Guid.Parse("787aef9c-b137-5a78-9a1f-133bdddbb9c7")},
                new Settlement{id = Guid.Parse("1c50670e-6cbb-563c-b1ec-9606fe9a2963"), name = "Noakuhoc", districtId = Guid.Parse("d51faff2-29ab-5793-94d4-69b4990d0fab")},
                new Settlement{id = Guid.Parse("0535d7f5-b1f9-520b-8d30-be8b24c700c6"), name = "Sensulvop", districtId = Guid.Parse("d51faff2-29ab-5793-94d4-69b4990d0fab")},
                new Settlement{id = Guid.Parse("4d9dad46-6a67-5be4-bbea-0dbf3da25738"), name = "Puezsu", districtId = Guid.Parse("a48d85ef-66d0-50da-8f5e-3aad733efe70")},
                new Settlement{id = Guid.Parse("05bc1ae6-caef-5abf-97ec-dedd9bba51b5"), name = "Fakoupu", districtId = Guid.Parse("a48d85ef-66d0-50da-8f5e-3aad733efe70")},
                new Settlement{id = Guid.Parse("9ae9e57d-08c7-5cbd-9ff4-b38b01d01319"), name = "Jognoere", districtId = Guid.Parse("ae9b757f-d5ac-51ac-a7e3-a65130377a5d")},
                new Settlement{id = Guid.Parse("3eed4d50-d799-53d3-ab64-926c35c12230"), name = "Rakegaf", districtId = Guid.Parse("ae9b757f-d5ac-51ac-a7e3-a65130377a5d")},
                new Settlement{id = Guid.Parse("c13f7316-9dcc-5f56-88ef-b283c069b122"), name = "Busunkat", districtId = Guid.Parse("f9a055ae-ca9f-58e6-b759-3e8ddc2ab31e")},
                new Settlement{id = Guid.Parse("066abe5a-86a2-5687-bd1c-5c80d07a70c5"), name = "Fijseze", districtId = Guid.Parse("f9a055ae-ca9f-58e6-b759-3e8ddc2ab31e")},
                new Settlement{id = Guid.Parse("288643fc-1ff7-54e6-9e09-06b027358c75"), name = "Gosimnug", districtId = Guid.Parse("1f2b2de9-9925-56c4-8cdf-a011c6313f9c")},
                new Settlement{id = Guid.Parse("e0df5d5b-74fb-5487-9ee0-8ec7a482c3d0"), name = "Bogcorzi", districtId = Guid.Parse("1f2b2de9-9925-56c4-8cdf-a011c6313f9c")},
                new Settlement{id = Guid.Parse("dfffb34a-e2bc-5f31-a50f-abfc4300ff64"), name = "Cevnupkom", districtId = Guid.Parse("8e4ce857-8547-5e7e-bbda-d9b5e62b2305")},
                new Settlement{id = Guid.Parse("3683c957-e828-5e42-aa04-c8a7e4b27b8a"), name = "Kijaco", districtId = Guid.Parse("8e4ce857-8547-5e7e-bbda-d9b5e62b2305")},
                new Settlement{id = Guid.Parse("d7d27f26-9e75-5c08-b7fd-c61d0cfa8a2b"), name = "Foohuiju", districtId = Guid.Parse("a92dfabb-ad00-5fd4-8dde-7cbd2261358a")},
                new Settlement{id = Guid.Parse("31519044-d25d-557e-a058-a25622dfef7c"), name = "Kefbujdi", districtId = Guid.Parse("a92dfabb-ad00-5fd4-8dde-7cbd2261358a")}

            };
            if (!context.settlementTable.Any())
            {
                context.settlementTable.AddRange(settlements);
                context.SaveChanges();
            }

            List<Models.Entities.Type> types = new List<Models.Entities.Type>
            {
                new Models.Entities.Type{name = "Дитяча лікарня"},
                new Models.Entities.Type{name = "Доросла лікарня"},
                new Models.Entities.Type{name = "Тваринна лікарня"},
                new Models.Entities.Type{name = "Центр лікування"},
                new Models.Entities.Type{name = "Психологічний центр"},
                new Models.Entities.Type{name = "Обласна лікарня"},
                new Models.Entities.Type{name = "Районна лікарня"},
                new Models.Entities.Type{name = "Смішна лікарня"},
                new Models.Entities.Type{name = "Весела лікарня"},
                new Models.Entities.Type{name = "Сумна лікарня"},
                new Models.Entities.Type{name = "Зла лікарня"},
                new Models.Entities.Type{name = "Приватна клініка"},
                new Models.Entities.Type{name = "Польовий госпіталь"},
                new Models.Entities.Type{name = "Просто лікарня"},
                new Models.Entities.Type{name = "Лікарня для багатих"},
                new Models.Entities.Type{name = "Дурдом"},

            };
            if (!context.typeTable.Any())
            {
                context.typeTable.AddRange(types);
                context.SaveChanges();
            }
            List<Models.Entities.Hospital> hospitals = new List<Models.Entities.Hospital>
            {
                new Models.Entities.Hospital{id = Guid.Parse("5e576d22-018c-5d55-be3a-7c04eea61612"), name = "Центральна міська лікарня №1", regionId = Guid.Parse("d453a27f-c4da-5ec9-9a36-ee09c08f6872"),
                    districtId = Guid.Parse("82667681-ab2f-5c8c-a044-594b398d0ba4"), settlementId = Guid.Parse("77c50afd-6911-57cc-b2ac-21a7eedd7275"), typeId = 1, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
                new Models.Entities.Hospital{id = Guid.Parse("cf9a819a-73d0-5d45-9a08-de1c3f9a31bd"), name = "Львівський обласний клінічний медичний центр", regionId = Guid.Parse("a2346c65-82eb-598c-b4ad-0fff0f8b7304"),
                    districtId = Guid.Parse("0df12eac-b65a-5f73-8cc3-57cc86d23e0f"), settlementId = Guid.Parse("208874bf-fa01-59a7-919b-eb7d10da08cb"), typeId = 2, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
                new Models.Entities.Hospital{id = Guid.Parse("0f01eaea-93a2-5f37-8334-6c0434619c3d"), name = "Харківська обласна клінічна лікарня", regionId = Guid.Parse("67ce66d4-0d6b-59c9-9cd0-f3e4466a4fa5"),
                    districtId = Guid.Parse("4100a843-d766-5adb-b046-213d67c73f79"), settlementId = Guid.Parse("485c3429-b8e5-5894-9764-8402376cd77e"), typeId = 3, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
                new Models.Entities.Hospital{id = Guid.Parse("5e1c4c9f-81be-5d60-8a46-b2e8f1925cb5"), name = "Київська міська клінічна лікарня №17", regionId = Guid.Parse("b31b3231-954f-572c-8526-2ab81a383d1f"),
                    districtId = Guid.Parse("f6a7a7cf-9c81-5454-884a-aaa6d3f2b8c4"), settlementId = Guid.Parse("0535d7f5-b1f9-520b-8d30-be8b24c700c6"), typeId = 3, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
                new Models.Entities.Hospital{id = Guid.Parse("ea4413f1-074e-5d24-a737-8b8086bc91d2"), name = "Чернівецька міська клінічна лікарня №1", regionId = Guid.Parse("8182b86e-9356-5708-8e08-d88877c34264"),
                    districtId = Guid.Parse("d51faff2-29ab-5793-94d4-69b4990d0fab"), settlementId = Guid.Parse("1c50670e-6cbb-563c-b1ec-9606fe9a2963"), typeId = 4, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
                new Models.Entities.Hospital{id = Guid.Parse("bae3bb0d-12f2-582f-88cf-fb68bef87f38"), name = "Одеська обласна клінічна лікарня", regionId = Guid.Parse("8976a1a6-ec10-567d-bf04-3416c9393826"),
                    districtId = Guid.Parse("ae9b757f-d5ac-51ac-a7e3-a65130377a5d"), settlementId = Guid.Parse("3eed4d50-d799-53d3-ab64-926c35c12230"), typeId = 5, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
                new Models.Entities.Hospital{id = Guid.Parse("9cbef8ea-7f9d-5238-85f2-4b5423fabc8c"), name = "Тернопільська міська клінічна лікарня №1", regionId = Guid.Parse("e61208cc-72b3-5018-954b-695815277ebc"),
                    districtId = Guid.Parse("f9a055ae-ca9f-58e6-b759-3e8ddc2ab31e"), settlementId = Guid.Parse("066abe5a-86a2-5687-bd1c-5c80d07a70c5"), typeId = 7, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
                new Models.Entities.Hospital{id = Guid.Parse("07730cbd-632d-53b1-b498-e44935fb26ba"), name = "Запорізька міська дитяча клінічна лікарня", regionId = Guid.Parse("b0f5a1b7-e1b9-5b9b-9bec-4955ed64dca5"),
                    districtId = Guid.Parse("a92dfabb-ad00-5fd4-8dde-7cbd2261358a"), settlementId = Guid.Parse("d7d27f26-9e75-5c08-b7fd-c61d0cfa8a2b"), typeId = 6, contactNumber = "+380678734576", adressDescription="hospitalTestLoc",
                    description="hospitalTest"},
            };
            if (!context.hospitalTable.Any())
            {
                context.hospitalTable.AddRange(hospitals);
                context.SaveChanges();
            }

            List<Office> offices = new List<Office>
            {
                new Office{id = Guid.Parse("b2f26a3e-96f9-51d1-8e49-abf9e401e0b4"), name="палата1", numberInHospital=563, additionalInformation="палата"},
                new Office{id = Guid.Parse("04673c2b-52a4-5049-87e1-5befdf0422fc"), name="палата2", numberInHospital=472, additionalInformation="палата"},
                new Office{id = Guid.Parse("1b8d6c12-42f6-556a-b7f3-c25e47e7a060"), name="палата3", numberInHospital=312, additionalInformation="палата"},
                new Office{id = Guid.Parse("f3a4d776-1e15-538e-baf4-c95cf210b982"), name="палата4", numberInHospital=314, additionalInformation="палата"},
                new Office{id = Guid.Parse("7942939e-7591-5121-8bff-44021d603bdf"), name="палата5", numberInHospital=602, additionalInformation="палата"},
                new Office{id = Guid.Parse("7b1146cb-0783-5d5d-8ad0-5a45818e9435"), name="палата6", numberInHospital=77, additionalInformation="палата"},
                new Office{id = Guid.Parse("f5155710-7404-5fa0-9d85-35016b3cd883"), name="палата7", numberInHospital=81, additionalInformation="палата"},
                new Office{id = Guid.Parse("7778a776-e927-56e2-8ff9-4479c5933fb1"), name="палата8", numberInHospital=90, additionalInformation="палата"},

                new Office{id = Guid.Parse("f89f4413-b3b1-58fd-b7f8-754ac579ab18"), name="палата9", numberInHospital=13, additionalInformation="палата"},
                new Office{id = Guid.Parse("0c5b2277-d87c-5946-8021-7ebf1beafbe9"), name="палата10", numberInHospital=450, additionalInformation="палата"},
                new Office{id = Guid.Parse("c2c20f3b-ee76-566e-9168-bb6c11b6d365"), name="палата11", numberInHospital=666, additionalInformation="палата"},
                new Office{id = Guid.Parse("627229e5-3881-5e8f-a48e-d61e2a694fba"), name="палата12", numberInHospital=777, additionalInformation="палата"},
                new Office{id = Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e"), name="палата13", numberInHospital=1024, additionalInformation="палата"},
                new Office{id = Guid.Parse("47d93223-6700-5335-9a4c-a08903f759f7"), name="палата14", numberInHospital=1251, additionalInformation="палата"},
                new Office{id = Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f"), name="палата15", numberInHospital=116, additionalInformation="палата"},
                new Office{id = Guid.Parse("6dc5e4f8-8899-5846-bbce-6d80a475449c"), name="палата16", numberInHospital=123, additionalInformation="палата"}
            };
            if (!context.officeTable.Any())
            {
                context.officeTable.AddRange(offices);
                context.SaveChanges();
            }
            List<Departament> departaments = new List<Departament>
            {
                new Departament{id = Guid.Parse("298799bb-3d33-5e6c-8f20-14888d5ead17"), hospitalId = Guid.Parse("5e576d22-018c-5d55-be3a-7c04eea61612"), name = "департамент1", additionalInformation = "департамент1"},
                new Departament{id = Guid.Parse("bc0023a7-e4ad-5783-bc3f-6adc908add35"), hospitalId = Guid.Parse("cf9a819a-73d0-5d45-9a08-de1c3f9a31bd"), name = "департамент2", additionalInformation = "департамент2"},
                new Departament{id = Guid.Parse("8e800eac-7fd2-5254-b313-3651f2f0acfa"), hospitalId = Guid.Parse("0f01eaea-93a2-5f37-8334-6c0434619c3d"), name = "департамент3", additionalInformation = "департамент3"},
                new Departament{id = Guid.Parse("5eb17557-accc-5e77-875a-7acf00667d91"), hospitalId = Guid.Parse("5e1c4c9f-81be-5d60-8a46-b2e8f1925cb5"), name = "департамент4", additionalInformation = "департамент4"},
                new Departament{id = Guid.Parse("889392a4-64ab-5337-a3a3-efe08cc2e72e"), hospitalId = Guid.Parse("ea4413f1-074e-5d24-a737-8b8086bc91d2"), name = "департамент5", additionalInformation = "департамент5"},
                new Departament{id = Guid.Parse("242b277c-135c-5514-9713-3988d423b354"), hospitalId = Guid.Parse("bae3bb0d-12f2-582f-88cf-fb68bef87f38"), name = "департамент6", additionalInformation = "департамент6"},
                new Departament{id = Guid.Parse("26a886a3-e671-5830-abcc-33115239d17e"), hospitalId = Guid.Parse("9cbef8ea-7f9d-5238-85f2-4b5423fabc8c"), name = "департамент7", additionalInformation = "департамент7"},
                new Departament{id = Guid.Parse("70b7eff5-8d4d-58cc-af1e-71effe3e4b33"), hospitalId = Guid.Parse("07730cbd-632d-53b1-b498-e44935fb26ba"), name = "департамент8", additionalInformation = "департамент8"}
            };
            if (!context.departamentTable.Any())
            {
                context.departamentTable.AddRange(departaments);
                context.SaveChanges();
            }
            List<Offices> globalOffices = new List<Offices>
            {
                new Offices{id = Guid.Parse("ee352ba9-1329-5187-b690-16d5310b5e45"), officeId = Guid.Parse("b2f26a3e-96f9-51d1-8e49-abf9e401e0b4"), departamentId = Guid.Parse("298799bb-3d33-5e6c-8f20-14888d5ead17")},
                new Offices{id = Guid.Parse("f99cb4e8-fcb3-5f5a-b5c3-d91ae383bbb6"), officeId = Guid.Parse("04673c2b-52a4-5049-87e1-5befdf0422fc"), departamentId = Guid.Parse("298799bb-3d33-5e6c-8f20-14888d5ead17")},

                new Offices{id = Guid.Parse("46fb5c36-bdca-5cbf-b3b5-d06fd8172f39"), officeId = Guid.Parse("1b8d6c12-42f6-556a-b7f3-c25e47e7a060"), departamentId = Guid.Parse("bc0023a7-e4ad-5783-bc3f-6adc908add35")},
                new Offices{id = Guid.Parse("3a1c4472-8560-55de-96fd-a2751f43a24f"), officeId = Guid.Parse("f3a4d776-1e15-538e-baf4-c95cf210b982"), departamentId = Guid.Parse("bc0023a7-e4ad-5783-bc3f-6adc908add35")},

                new Offices{id = Guid.Parse("1f7ebf29-d5c4-5420-baac-78a4ad497fd2"), officeId = Guid.Parse("7942939e-7591-5121-8bff-44021d603bdf"), departamentId = Guid.Parse("8e800eac-7fd2-5254-b313-3651f2f0acfa")},
                new Offices{id = Guid.Parse("8ee1a9a2-5d24-5c17-841e-6e24f61ab760"), officeId = Guid.Parse("7b1146cb-0783-5d5d-8ad0-5a45818e9435"), departamentId = Guid.Parse("8e800eac-7fd2-5254-b313-3651f2f0acfa")},

                new Offices{id = Guid.Parse("451b2930-3fc2-52ee-9d6f-783c4ec7491b"), officeId = Guid.Parse("f5155710-7404-5fa0-9d85-35016b3cd883"), departamentId = Guid.Parse("5eb17557-accc-5e77-875a-7acf00667d91")},
                new Offices{id = Guid.Parse("f630f6af-21c0-53a8-9ca1-6dcec6d4483b"), officeId = Guid.Parse("7778a776-e927-56e2-8ff9-4479c5933fb1"), departamentId = Guid.Parse("5eb17557-accc-5e77-875a-7acf00667d91")},

                new Offices{id = Guid.Parse("b708c47a-1303-506f-ae6c-154993a10f04"), officeId = Guid.Parse("f89f4413-b3b1-58fd-b7f8-754ac579ab18"), departamentId = Guid.Parse("889392a4-64ab-5337-a3a3-efe08cc2e72e")},
                new Offices{id = Guid.Parse("42f0a411-aa85-533c-9e1b-9ca784e39ed4"), officeId = Guid.Parse("0c5b2277-d87c-5946-8021-7ebf1beafbe9"), departamentId = Guid.Parse("889392a4-64ab-5337-a3a3-efe08cc2e72e")},

                new Offices{id = Guid.Parse("320476f8-5c48-5f03-994e-c47b7f1f816a"), officeId = Guid.Parse("c2c20f3b-ee76-566e-9168-bb6c11b6d365"), departamentId = Guid.Parse("242b277c-135c-5514-9713-3988d423b354")},
                new Offices{id = Guid.Parse("ff105f15-9302-5d73-8ddb-842f5e6f4ed3"), officeId = Guid.Parse("627229e5-3881-5e8f-a48e-d61e2a694fba"), departamentId = Guid.Parse("242b277c-135c-5514-9713-3988d423b354")},

                new Offices{id = Guid.Parse("a3d7fc65-6964-5fa1-80ae-bcadc8a15d85"), officeId = Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e"), departamentId = Guid.Parse("26a886a3-e671-5830-abcc-33115239d17e")},
                new Offices{id = Guid.Parse("f302a4bb-40d2-58ba-b326-070d1a07e537"), officeId = Guid.Parse("47d93223-6700-5335-9a4c-a08903f759f7"), departamentId = Guid.Parse("26a886a3-e671-5830-abcc-33115239d17e")},

                new Offices{id = Guid.Parse("5dfca5de-f29a-57ec-8ea7-fc64d1b7cc32"), officeId = Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f"), departamentId = Guid.Parse("70b7eff5-8d4d-58cc-af1e-71effe3e4b33")},
                new Offices{id = Guid.Parse("1856aab0-ef03-5929-9743-b605c1b0af54"), officeId = Guid.Parse("6dc5e4f8-8899-5846-bbce-6d80a475449c"), departamentId = Guid.Parse("70b7eff5-8d4d-58cc-af1e-71effe3e4b33")},

            };
            if (!context.officesTable.Any())
            {
                context.officesTable.AddRange(globalOffices);
                context.SaveChanges();
            }


            List<Gender> genders = new List<Gender>
            {
                new Gender{genderName = "Чоловік"},
                new Gender{genderName = "Жінка"}
            };
            if (!context.genderTable.Any())
            {
                context.genderTable.AddRange(genders);
                context.SaveChanges();
            }
            List<UserPicture> userPictures = new List<UserPicture>
            {
                new UserPicture{id = Guid.Parse("657d5b76-a096-5203-8119-a49fbc7ba04f"), picture = null},
                new UserPicture{id = Guid.Parse("f5d9e5ca-b90a-5faa-a1e5-e1d634729b1e"), picture = null},
                new UserPicture{id = Guid.Parse("b79b50b1-aa71-5741-9a27-ef140f00667f"), picture = null},
                new UserPicture{id = Guid.Parse("e6c4fdd9-bcf3-535b-b57b-314cba181322"), picture = null},
                new UserPicture{id = Guid.Parse("9b370cee-0558-5bac-aaf7-fb021fb3beb3"), picture = null},
                new UserPicture{id = Guid.Parse("85efa5ca-1e35-560a-95cc-b647b9ab55ed"), picture = null},
                new UserPicture{id = Guid.Parse("c131c6cb-40bc-5e47-915a-26a38e9a658d"), picture = null},
                new UserPicture{id = Guid.Parse("20c0d272-eef8-5e75-9b0e-5b6b5875af05"), picture = null},
            };
            if (!context.userPictureTable.Any())
            {
                context.userPictureTable.AddRange(userPictures);
                context.SaveChanges();
            }
            List<User> users = new List<User>
            {
                new User{id = Guid.Parse("67029187-6d3a-5154-9a7b-724167874572"), surname = "surname1", name = "name1", middleName = "middlename1", passwordHash = hash.Hash("password"), mail="mail1@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 1, userPictureId=Guid.Parse("657d5b76-a096-5203-8119-a49fbc7ba04f"), phoneNumber = "+380634477823", isAdmin = true,
                settlementId = Guid.Parse("89ba72c2-3ca1-5f1c-9912-45c5fdf86deb")},

                new User{id = Guid.Parse("178192a9-08d2-51cf-bc46-f581bcfcd7db"), surname = "surname2", name = "name2", middleName = "middlename2", passwordHash = hash.Hash("password"), mail="mail2@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 1, userPictureId=Guid.Parse("f5d9e5ca-b90a-5faa-a1e5-e1d634729b1e"), phoneNumber = "+380634477823", isAdmin = true,
                settlementId = Guid.Parse("77c50afd-6911-57cc-b2ac-21a7eedd7275")},

                new User{id = Guid.Parse("17c52f21-e174-5967-b17e-3e832564f172"), surname = "surname3", name = "name3", middleName = "middlename3", passwordHash = hash.Hash("password"), mail="mail3@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 2, userPictureId=Guid.Parse("b79b50b1-aa71-5741-9a27-ef140f00667f"), phoneNumber = "+380634477823", isAdmin = true,
                settlementId = Guid.Parse("16f7ebc8-61e1-5e06-84ae-33ea3b4b4c77")},

                new User{id = Guid.Parse("3ae6c191-e942-5a29-a796-5aba81716b92"), surname = "surname4", name = "name4", middleName = "middlename4", passwordHash = hash.Hash("password"), mail="mail4@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 1, userPictureId=Guid.Parse("e6c4fdd9-bcf3-535b-b57b-314cba181322"), phoneNumber = "+380634477823", isAdmin = false,
                settlementId = Guid.Parse("16f7ebc8-61e1-5e06-84ae-33ea3b4b4c77")},

                new User{id = Guid.Parse("2b6bbcd7-ff21-51cd-827a-f34fa7b2234f"), surname = "surname5", name = "name5", middleName = "middlename5", passwordHash = hash.Hash("password"), mail="mail5@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 1, userPictureId=Guid.Parse("9b370cee-0558-5bac-aaf7-fb021fb3beb3"), phoneNumber = "+380634477823", isAdmin = false,
                settlementId = Guid.Parse("0535d7f5-b1f9-520b-8d30-be8b24c700c6")},

                new User{id = Guid.Parse("cf481229-c9b3-5704-810d-80b996286e71"), surname = "surname6", name = "name6", middleName = "middlename6", passwordHash = hash.Hash("password"), mail="mail6@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 1, userPictureId=Guid.Parse("85efa5ca-1e35-560a-95cc-b647b9ab55ed"), phoneNumber = "+380634477823", isAdmin = false,
                settlementId = Guid.Parse("288643fc-1ff7-54e6-9e09-06b027358c75")},

                new User{id = Guid.Parse("99f1a26c-232e-5fb2-b4eb-5657a46a214e"), surname = "surname7", name = "name7", middleName = "middlename7", passwordHash = hash.Hash("password"), mail="mail7@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 1, userPictureId=Guid.Parse("c131c6cb-40bc-5e47-915a-26a38e9a658d"), phoneNumber = "+380634477823", isAdmin = false,
                settlementId = Guid.Parse("dfffb34a-e2bc-5f31-a50f-abfc4300ff64")},

                new User{id = Guid.Parse("31f76074-f44a-580e-b9cd-fc101a14e8f1"), surname = "surname8", name = "name8", middleName = "middlename8", passwordHash = hash.Hash("password"), mail="mail8@gmail.com",
                Age = 18, birthDate = new DateTime(2002, 05, 22), genderId = 1, userPictureId=Guid.Parse("20c0d272-eef8-5e75-9b0e-5b6b5875af05"), phoneNumber = "+380634477823", isAdmin = false,
                settlementId = Guid.Parse("31519044-d25d-557e-a058-a25622dfef7c")},
            };
            if (!context.userTable.Any())
            {
                context.userTable.AddRange(users);
                context.SaveChanges();
            }

            List<Patient> patients = new List<Patient>
            {
                new Patient{id=Guid.Parse("5e92d932-5550-5958-9ff0-eaba681438ae"), UserId = Guid.Parse("67029187-6d3a-5154-9a7b-724167874572")},
                new Patient{id=Guid.Parse("4c333d3d-e04d-517e-8cd4-8c7c9a7a0883"), UserId = Guid.Parse("178192a9-08d2-51cf-bc46-f581bcfcd7db")},
                new Patient{id=Guid.Parse("d363663a-26f5-5be1-8f52-ef7e9d750c7a"), UserId = Guid.Parse("17c52f21-e174-5967-b17e-3e832564f172")},
                new Patient{id=Guid.Parse("5c6ee728-e05c-5548-958d-814b37393c38"), UserId = Guid.Parse("3ae6c191-e942-5a29-a796-5aba81716b92")},
                new Patient{id=Guid.Parse("e899c5cf-e8c3-5df4-86ca-4bc885f2e57e"), UserId = Guid.Parse("2b6bbcd7-ff21-51cd-827a-f34fa7b2234f")},
                new Patient{id=Guid.Parse("057849e0-7e07-5201-a7f1-c32dcac787a8"), UserId = Guid.Parse("cf481229-c9b3-5704-810d-80b996286e71")},
                new Patient{id=Guid.Parse("3ccf7f1c-46bc-5ddf-b047-736b4c89a3d8"), UserId = Guid.Parse("99f1a26c-232e-5fb2-b4eb-5657a46a214e")},
                new Patient{id=Guid.Parse("bc3d7dbe-d155-52eb-89ab-7caf7330edea"), UserId = Guid.Parse("31f76074-f44a-580e-b9cd-fc101a14e8f1")}
            };
            if (!context.patientTable.Any())
            {
                context.patientTable.AddRange(patients);
                context.SaveChanges();
            }
            List<Indexes> indexes = new List<Indexes>
            {
                new Indexes{id = Guid.Parse("905e590f-ed4f-5c4c-9909-12386e76cd17"), patiendId = Guid.Parse("5e92d932-5550-5958-9ff0-eaba681438ae")},
                new Indexes{id = Guid.Parse("2b5e548d-e0ca-576d-8b92-bd289c1a1e5c"), patiendId = Guid.Parse("4c333d3d-e04d-517e-8cd4-8c7c9a7a0883")},
                new Indexes{id = Guid.Parse("c1da4210-67b4-587d-935f-6c4269ed3447"), patiendId = Guid.Parse("d363663a-26f5-5be1-8f52-ef7e9d750c7a")},
                new Indexes{id = Guid.Parse("3764cc3c-110a-56de-b9fd-c728de9750ce"), patiendId = Guid.Parse("5c6ee728-e05c-5548-958d-814b37393c38")},
                new Indexes{id = Guid.Parse("564c2336-3a69-5ed5-8c4d-ad9c77098824"), patiendId = Guid.Parse("e899c5cf-e8c3-5df4-86ca-4bc885f2e57e")},
                new Indexes{id = Guid.Parse("c5e487ce-4ddc-5e81-bd5f-1aa2d71c1e5e"), patiendId = Guid.Parse("057849e0-7e07-5201-a7f1-c32dcac787a8")},
                new Indexes{id = Guid.Parse("d3b935c9-d9b7-540c-8b87-c38acdbc1fdd"), patiendId = Guid.Parse("3ccf7f1c-46bc-5ddf-b047-736b4c89a3d8")},
                new Indexes{id = Guid.Parse("b4e45ff8-d5c8-5cfe-980e-705861727ee8"), patiendId = Guid.Parse("bc3d7dbe-d155-52eb-89ab-7caf7330edea")}
            };
            if (!context.indexesTable.Any())
            {
                context.indexesTable.AddRange(indexes);
                context.SaveChanges();
            }
            List<Doctor> doctors = new List<Doctor>
            {
                new Doctor{id = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), userId = Guid.Parse("67029187-6d3a-5154-9a7b-724167874572"), additionalInformation = "additionalInformation"},
                new Doctor{id = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"), userId = Guid.Parse("178192a9-08d2-51cf-bc46-f581bcfcd7db"), additionalInformation = "additionalInformation"},
                new Doctor{id = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), userId = Guid.Parse("17c52f21-e174-5967-b17e-3e832564f172"), additionalInformation = "additionalInformation"}
            };
            if (!context.doctorTable.Any())
            {
                context.doctorTable.AddRange(doctors);
                context.SaveChanges();
            }

            List<Specialty> specialtyList = new List<Specialty>
            {
                new Specialty{id = Guid.Parse("636e085c-3ace-57f3-8368-40c90ca96d0b"), Name = "Specialty2"},
                new Specialty{id = Guid.Parse("5c8c77ae-b803-5a25-9263-8e4d8ac866f0"), Name = "Specialty3"},
                new Specialty{id = Guid.Parse("10fcb112-768d-5fc2-a3e1-2334980d27a2"), Name = "Specialty4"},
                new Specialty{id = Guid.Parse("8cffc705-2f99-5959-ba26-41adcc3a0457"), Name = "Specialty5"},
                new Specialty{id = Guid.Parse("54bc2910-c01a-521a-9dc1-ccdfc61d6b45"), Name = "Specialty6"},
                new Specialty{id = Guid.Parse("eacebf9c-7fdb-54da-be9d-e03b79e79902"), Name = "Specialty7"},
                new Specialty{id = Guid.Parse("79833b69-0d1a-56df-aad7-546dab7cd4a4"), Name = "Specialty8"},
                new Specialty{id = Guid.Parse("2c6c7d1c-06e1-5d04-9e6e-9f8b2b716b86"), Name = "Specialty9"},
                new Specialty{id = Guid.Parse("b2ca7c3f-9bd2-52f1-a9e1-6466096c24cf"), Name = "Specialty10"},
                new Specialty{id = Guid.Parse("18bd5b76-6d2f-5ca7-9291-73aba73180d8"), Name = "Specialty11"},
            };
            if (!context.specialityTable.Any())
            {
                context.specialityTable.AddRange(specialtyList);
                context.SaveChanges();
            }
            List<Specialities> specialities = new List<Specialities>
            {
                new Specialities{Id = Guid.Parse("3704dc4c-058b-5107-a2c3-9b30ea49f5d0"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"),specialityId = Guid.Parse("636e085c-3ace-57f3-8368-40c90ca96d0b")},
                new Specialities{Id = Guid.Parse("e3144a5a-2c9c-5114-9cf2-bcdd346cd77b"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"),specialityId = Guid.Parse("5c8c77ae-b803-5a25-9263-8e4d8ac866f0")},
                new Specialities{Id = Guid.Parse("ef9e5398-a0e9-582e-b9c9-123a337093e1"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"),specialityId = Guid.Parse("10fcb112-768d-5fc2-a3e1-2334980d27a2")},
                new Specialities{Id = Guid.Parse("81c1c96b-4db4-5b19-ae62-1b6170170848"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"),specialityId = Guid.Parse("8cffc705-2f99-5959-ba26-41adcc3a0457")},
                new Specialities{Id = Guid.Parse("45c9a04f-b75a-5550-a18d-5a67a6d75f64"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"),specialityId = Guid.Parse("eacebf9c-7fdb-54da-be9d-e03b79e79902")},
                new Specialities{Id = Guid.Parse("fd91e902-1cc5-51fb-b68b-783254d91cc3"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"),specialityId = Guid.Parse("b2ca7c3f-9bd2-52f1-a9e1-6466096c24cf")},

            };
            if (!context.specialitiesTable.Any())
            {
                context.specialitiesTable.AddRange(specialities);
                context.SaveChanges();
            }

            List<Status> statuses = new List<Status>
            {
                new Status{status = "Working"},
                new Status{status = "Free Day"},
                new Status{status = "Not Working"}
            };
            if (!context.statusTable.Any())
            {
                context.statusTable.AddRange(statuses);
                context.SaveChanges();
            }
            List<Work> workList = new List<Work>
            {
                new Work{id = Guid.Parse("500fa235-62d6-53d8-a0be-51ba570a9eb2"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), hospitalId = Guid.Parse("07730cbd-632d-53b1-b498-e44935fb26ba"), statusId = 1,
                isAdminInHospital = true, isAdminInDepartament = true, officeId = Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f"), departamentId = Guid.Parse("70b7eff5-8d4d-58cc-af1e-71effe3e4b33")},

                new Work{id = Guid.Parse("515e9486-f650-5b2e-8cee-bd3fec23ce18"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), hospitalId = Guid.Parse("9cbef8ea-7f9d-5238-85f2-4b5423fabc8c"), statusId = 1,
                isAdminInHospital = true, isAdminInDepartament = false, officeId = Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e"), departamentId = Guid.Parse("26a886a3-e671-5830-abcc-33115239d17e")},

                new Work{id = Guid.Parse("b886474d-b6ef-5f06-8855-9aa12425523a"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"), hospitalId = Guid.Parse("9cbef8ea-7f9d-5238-85f2-4b5423fabc8c"), statusId = 1,
                isAdminInHospital = false, isAdminInDepartament = true, officeId = Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e"), departamentId = Guid.Parse("26a886a3-e671-5830-abcc-33115239d17e")},

                new Work{id = Guid.Parse("d143f56e-9f11-5592-9af5-92ada44f9f44"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), hospitalId = Guid.Parse("ea4413f1-074e-5d24-a737-8b8086bc91d2"), statusId = 1,
                isAdminInHospital = false, isAdminInDepartament = false, officeId = Guid.Parse("f89f4413-b3b1-58fd-b7f8-754ac579ab18"), departamentId = Guid.Parse("889392a4-64ab-5337-a3a3-efe08cc2e72e")},

                new Work{id = Guid.Parse("8fc9bf98-4ab0-5cf6-b6d4-4281914c71f3"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), hospitalId = Guid.Parse("ea4413f1-074e-5d24-a737-8b8086bc91d2"), statusId = 1,
                isAdminInHospital = false, isAdminInDepartament = false, officeId = Guid.Parse("0c5b2277-d87c-5946-8021-7ebf1beafbe9"), departamentId = Guid.Parse("889392a4-64ab-5337-a3a3-efe08cc2e72e")},
            };
            if (!context.workTable.Any())
            {
                context.workTable.AddRange(workList);
                context.SaveChanges();
            }


            List<Time> timeTable = new List<Time>
            {
                new Time{id = Guid.Parse("d762c293-f319-51fb-b71e-20dbc39f9f78"), time = "10:00"},
                new Time{id = Guid.Parse("ec79f706-a978-56a7-8012-6ac97952b2b1"), time = "10:20"},
                new Time{id = Guid.Parse("8d13e30f-60b9-5474-b513-4805e5f08edb"), time = "10:40"},
                new Time{id = Guid.Parse("37948bd9-df25-5388-a5f8-df14d30de2b5"), time = "11:00"},
                new Time{id = Guid.Parse("1f2d276e-a5e0-5dec-a5ba-728889af9a5c"), time = "11:20"},
                new Time{id = Guid.Parse("85f9abad-b62b-5069-8660-b7d561aa2374"), time = "11:40"},
                new Time{id = Guid.Parse("77db4239-15c2-58fc-b3ee-c4fad286fe1d"), time = "12:00"},
                new Time{id = Guid.Parse("8c747ab5-3f55-5256-9ac0-96ddb38ddd57"), time = "12:20"},
                new Time{id = Guid.Parse("47cefcbb-2db4-5f80-9fd2-18c20678ff2d"), time = "12:40"},
                new Time{id = Guid.Parse("72fc1ace-56a3-5ae1-977d-e9f003e284d0"), time = "13:00"},
                new Time{id = Guid.Parse("35616701-123f-5863-b43a-43c98a63c485"), time = "13:20"},
                new Time{id = Guid.Parse("4e37181c-fd1c-57f9-b527-f437711e0a3d"), time = "13:40"},
                new Time{id = Guid.Parse("42bad806-f46d-5532-bf81-abb83e0ded91"), time = "14:00"},
                new Time{id = Guid.Parse("8362277d-43d5-578d-9482-ea070e80aa2f"), time = "14:20"},
                new Time{id = Guid.Parse("284c6010-388b-5f0e-9f46-c6facd1cbe3c"), time = "14:40"},
                new Time{id = Guid.Parse("98a58cdf-0b68-5ea0-be56-7226ace98130"), time = "15:00"},
                new Time{id = Guid.Parse("1eda3c9d-ef39-5b91-be6f-8417d5ee669a"), time = "15:20"},
            };
            if (!context.timeTable.Any())
            {
                context.timeTable.AddRange(timeTable);
                context.SaveChanges();
            }

            List<Times> appoimentTimes = new List<Times>
            {
                new Times{Id = Guid.Parse("690f89f5-33ed-55af-8b57-2acb972c70ed"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("d762c293-f319-51fb-b71e-20dbc39f9f78"), officeId=Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f")},
                new Times{Id = Guid.Parse("78d94b1a-c946-5dfb-b635-ad009835cf4a"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("ec79f706-a978-56a7-8012-6ac97952b2b1"), officeId=Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f")},
                new Times{Id = Guid.Parse("5ba2e51f-59a8-5cfc-96b2-c15369447fc0"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("8d13e30f-60b9-5474-b513-4805e5f08edb"), officeId=Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f")},
                new Times{Id = Guid.Parse("548da2f3-2f2c-5f0a-af7a-6073a4b65bda"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("37948bd9-df25-5388-a5f8-df14d30de2b5"), officeId=Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f")},
                new Times{Id = Guid.Parse("561c9acd-50df-5cec-9808-d8f7d4c0a1df"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("1f2d276e-a5e0-5dec-a5ba-728889af9a5c"), officeId=Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f")},

                new Times{Id = Guid.Parse("682f1972-9523-5c42-8d4a-9475f500226d"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("72fc1ace-56a3-5ae1-977d-e9f003e284d0"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},
                new Times{Id = Guid.Parse("7252b09a-c6d3-523b-bdcd-03e4f609e17f"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("35616701-123f-5863-b43a-43c98a63c485"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},
                new Times{Id = Guid.Parse("d2bc5d57-4402-52b0-adc3-980b38cfa302"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("4e37181c-fd1c-57f9-b527-f437711e0a3d"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},
                new Times{Id = Guid.Parse("89287e25-9cdf-59d2-a78f-9e664635b29b"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"), timeId = Guid.Parse("42bad806-f46d-5532-bf81-abb83e0ded91"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},

                new Times{Id = Guid.Parse("e1315bf0-074d-5658-8145-1317010d2544"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"), timeId = Guid.Parse("d762c293-f319-51fb-b71e-20dbc39f9f78"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},
                new Times{Id = Guid.Parse("0352fb4f-7dc3-5204-99d5-c1932c22511c"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"), timeId = Guid.Parse("ec79f706-a978-56a7-8012-6ac97952b2b1"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},
                new Times{Id = Guid.Parse("fc796a5b-97ff-5eae-a8fe-5b92a4b533db"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"), timeId = Guid.Parse("8d13e30f-60b9-5474-b513-4805e5f08edb"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},
                new Times{Id = Guid.Parse("06a7b52a-2150-5388-91e8-47e2fb634e3d"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"), timeId = Guid.Parse("37948bd9-df25-5388-a5f8-df14d30de2b5"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},
                new Times{Id = Guid.Parse("9844a6a7-434e-57c5-bce7-2a2118f3f06b"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"), timeId = Guid.Parse("1f2d276e-a5e0-5dec-a5ba-728889af9a5c"), officeId=Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e")},


                new Times{Id = Guid.Parse("f50ce9de-c039-5ea7-8422-b64f999e9bd2"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("d762c293-f319-51fb-b71e-20dbc39f9f78"), officeId=Guid.Parse("f89f4413-b3b1-58fd-b7f8-754ac579ab18")},
                new Times{Id = Guid.Parse("9bc60a1c-9338-58ed-8222-fdb00e4bee1a"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("ec79f706-a978-56a7-8012-6ac97952b2b1"), officeId=Guid.Parse("f89f4413-b3b1-58fd-b7f8-754ac579ab18")},
                new Times{Id = Guid.Parse("c25907ba-8173-5ec2-a031-a6fa06c15fae"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("8d13e30f-60b9-5474-b513-4805e5f08edb"), officeId=Guid.Parse("f89f4413-b3b1-58fd-b7f8-754ac579ab18")},
                new Times{Id = Guid.Parse("d8f9b359-238b-5d09-87ec-4f9b4bd07326"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("37948bd9-df25-5388-a5f8-df14d30de2b5"), officeId=Guid.Parse("f89f4413-b3b1-58fd-b7f8-754ac579ab18")},

                new Times{Id = Guid.Parse("dd5c7276-e8ce-5b74-8761-b098d8fb0ab9"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("72fc1ace-56a3-5ae1-977d-e9f003e284d0"), officeId=Guid.Parse("0c5b2277-d87c-5946-8021-7ebf1beafbe9")},
                new Times{Id = Guid.Parse("1f0bcab2-fef3-5c48-8ea6-1cf3da47a4c3"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("35616701-123f-5863-b43a-43c98a63c485"), officeId=Guid.Parse("0c5b2277-d87c-5946-8021-7ebf1beafbe9")},
                new Times{Id = Guid.Parse("b5da8948-7c9f-51f9-a718-990dbf44250d"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("4e37181c-fd1c-57f9-b527-f437711e0a3d"), officeId=Guid.Parse("0c5b2277-d87c-5946-8021-7ebf1beafbe9")},
                new Times{Id = Guid.Parse("3591d19f-8bb0-52a1-82f7-ccd824f62325"), doctorId = Guid.Parse("49f4b2cf-0d6a-5cf5-9645-1676c550bc41"), timeId = Guid.Parse("42bad806-f46d-5532-bf81-abb83e0ded91"), officeId=Guid.Parse("0c5b2277-d87c-5946-8021-7ebf1beafbe9")},
            };
            if (!context.timesTable.Any())
            {
                context.timesTable.AddRange(appoimentTimes);
                context.SaveChanges();
            }



            List<Substance> substances = new List<Substance>
            {
                new Substance{id = Guid.Parse("ba708c67-ea24-5d24-8c74-f8035844bdb9"), substanceName = "Substance1"},
                new Substance{id = Guid.Parse("c15c6275-2f62-52da-b4d5-2be439d553dc"), substanceName = "Substance2"},
                new Substance{id = Guid.Parse("df9c2354-8005-57f9-a625-149a34e77acb"), substanceName = "Substance3"},
                new Substance{id = Guid.Parse("3533adbf-8df8-5109-93a2-0da893b7cbc7"), substanceName = "Substance4"},
                new Substance{id = Guid.Parse("c862f4f1-07a5-5e67-a833-09c3a01344c5"), substanceName = "Substance5"},
                new Substance{id = Guid.Parse("460e19cb-69fa-5641-b2be-a3a6090d8505"), substanceName = "Substance6"},
                new Substance{id = Guid.Parse("13aa1f23-f7cd-5844-93f1-d02288edab3f"), substanceName = "Substance7"},
                new Substance{id = Guid.Parse("1741e39c-f09a-52cf-9b0a-78e042f0475d"), substanceName = "Substance8"},
                new Substance{id = Guid.Parse("cbba5594-0868-51d9-939d-d6eb6d25eb43"), substanceName = "Substance9"},
                new Substance{id = Guid.Parse("1d8b8ae5-16c7-500b-af54-b7fc76f8a692"), substanceName = "Substance10"},
                new Substance{id = Guid.Parse("11e8dd28-a306-5728-bd11-86f4b5e78e88"), substanceName = "Substance11"},
                new Substance{id = Guid.Parse("46106466-bc43-5e38-937f-3969a91f1014"), substanceName = "Substance12"},
                new Substance{id = Guid.Parse("71b5f683-10ca-5a25-9b1c-994c2f6aea2c"), substanceName = "Substance13"},
                new Substance{id = Guid.Parse("a4bf5b84-2195-513f-8890-818d317f112b"), substanceName = "Substance14"},
                new Substance{id = Guid.Parse("e69778c4-5a92-51b1-b7a9-e8bfccd0bf89"), substanceName = "Substance15"},
                new Substance{id = Guid.Parse("1c0ff73d-0af4-5436-ba1d-f1b2684c1020"), substanceName = "Substance16"},
                new Substance{id = Guid.Parse("022ce388-b484-5363-98a8-db8d284aff31"), substanceName = "Substance17"}
            };
            if (!context.substanceTable.Any())
            {
                context.substanceTable.AddRange(substances);
                context.SaveChanges();
            }

            List<Allergy> allergies = new List<Allergy>
            {
                new Allergy{id = Guid.Parse("8f232cfd-ec75-5e24-a50e-0adc79d3e12c"), patiendId = Guid.Parse("5e92d932-5550-5958-9ff0-eaba681438ae"), substanceId = Guid.Parse("ba708c67-ea24-5d24-8c74-f8035844bdb9")},
                new Allergy{id = Guid.Parse("8ffb0255-e123-5d85-b81d-55c0f07f8fb6"), patiendId = Guid.Parse("5e92d932-5550-5958-9ff0-eaba681438ae"), substanceId = Guid.Parse("c862f4f1-07a5-5e67-a833-09c3a01344c5")},
                new Allergy{id = Guid.Parse("af7023c4-cd3d-574c-a0f8-8c495b2632ed"), patiendId = Guid.Parse("5e92d932-5550-5958-9ff0-eaba681438ae"), substanceId = Guid.Parse("11e8dd28-a306-5728-bd11-86f4b5e78e88")},

                new Allergy{id = Guid.Parse("b975286e-0970-53d6-bd5d-859224c06425"), patiendId = Guid.Parse("4c333d3d-e04d-517e-8cd4-8c7c9a7a0883"), substanceId = Guid.Parse("df9c2354-8005-57f9-a625-149a34e77acb")},
                new Allergy{id = Guid.Parse("33c214ee-d6c6-510d-95b2-7b12ce71d699"), patiendId = Guid.Parse("4c333d3d-e04d-517e-8cd4-8c7c9a7a0883"), substanceId = Guid.Parse("11e8dd28-a306-5728-bd11-86f4b5e78e88")},

                new Allergy{id = Guid.Parse("48cb85bd-3275-5802-8565-c918023924c0"), patiendId = Guid.Parse("d363663a-26f5-5be1-8f52-ef7e9d750c7a"), substanceId = Guid.Parse("46106466-bc43-5e38-937f-3969a91f1014")},
                new Allergy{id = Guid.Parse("e71f4c55-5438-5050-bea2-7f29f5bbec1a"), patiendId = Guid.Parse("d363663a-26f5-5be1-8f52-ef7e9d750c7a"), substanceId = Guid.Parse("a4bf5b84-2195-513f-8890-818d317f112b")},
                new Allergy{id = Guid.Parse("e9a51a2e-e766-5ae3-b23c-b8aa5d1b4c31"), patiendId = Guid.Parse("d363663a-26f5-5be1-8f52-ef7e9d750c7a"), substanceId = Guid.Parse("e69778c4-5a92-51b1-b7a9-e8bfccd0bf89")},
                new Allergy{id = Guid.Parse("fc79c502-d16b-5685-8baa-7880c7692b18"), patiendId = Guid.Parse("d363663a-26f5-5be1-8f52-ef7e9d750c7a"), substanceId = Guid.Parse("022ce388-b484-5363-98a8-db8d284aff31")},

                new Allergy{id = Guid.Parse("8934cb8f-85c5-5f1f-8a03-47db57e99f02"), patiendId = Guid.Parse("5c6ee728-e05c-5548-958d-814b37393c38"), substanceId = Guid.Parse("df9c2354-8005-57f9-a625-149a34e77acb")},
            };
            if (!context.allergiesTable.Any())
            {
                context.allergiesTable.AddRange(allergies);
                context.SaveChanges();
            }


            List<Preparation> preparations = new List<Preparation>
            {
                new Preparation{id = Guid.Parse("cffbba09-bfc5-5118-804e-1e24d1adbe7d"), name = "Preparation1"},
                new Preparation{id = Guid.Parse("d592283e-9b6c-5230-b3c2-0832974f987c"), name = "Preparation2"},
                new Preparation{id = Guid.Parse("f7740154-612b-5374-a697-59eef0867373"), name = "Preparation3"},
                new Preparation{id = Guid.Parse("077f314e-73e0-5d93-b07e-00c24a3b8433"), name = "Preparation4"},
                new Preparation{id = Guid.Parse("c2b14833-5908-5091-b6f0-60e6a900b188"), name = "Preparation5"},
                new Preparation{id = Guid.Parse("7d21386e-d763-5003-a138-b3e5df97e1f1"), name = "Preparation6"},
                new Preparation{id = Guid.Parse("c6911467-545b-503c-8344-8240be7ad37a"), name = "Preparation7"},
                new Preparation{id = Guid.Parse("867d2a2e-8ef0-52eb-8f0b-4122be383250"), name = "Preparation8"},
                new Preparation{id = Guid.Parse("12752f1b-3334-5642-904b-36495306d21c"), name = "Preparation9"},
                new Preparation{id = Guid.Parse("15c894d4-599b-573a-8d37-f802bdeddae8"), name = "Preparation10"}
            };
            if (!context.preparationTable.Any())
            {
                context.preparationTable.AddRange(preparations);
                context.SaveChanges();
            }

            List<Preparations> preparationsReceipts = new List<Preparations>
            {
                new Preparations{id = Guid.Parse("8e162b11-ed92-5c5e-bba5-b44f99acc85c"), preparationId = Guid.Parse("cffbba09-bfc5-5118-804e-1e24d1adbe7d"), substanceId = Guid.Parse("ba708c67-ea24-5d24-8c74-f8035844bdb9")},
                new Preparations{id = Guid.Parse("18e43dab-5c06-52d7-bd0c-d2ef4f9a5b0a"), preparationId = Guid.Parse("cffbba09-bfc5-5118-804e-1e24d1adbe7d"), substanceId = Guid.Parse("c15c6275-2f62-52da-b4d5-2be439d553dc")},
                new Preparations{id = Guid.Parse("b9fcb7e1-f5e6-5b15-8dcb-89f373b8c332"), preparationId = Guid.Parse("cffbba09-bfc5-5118-804e-1e24d1adbe7d"), substanceId = Guid.Parse("df9c2354-8005-57f9-a625-149a34e77acb")},

                new Preparations{id = Guid.Parse("8d37b022-d411-5e81-8c1b-0694086fdd89"), preparationId = Guid.Parse("d592283e-9b6c-5230-b3c2-0832974f987c"), substanceId = Guid.Parse("3533adbf-8df8-5109-93a2-0da893b7cbc7")},
                new Preparations{id = Guid.Parse("f7543657-a4a4-5b6f-99b8-d0c1da79cd08"), preparationId = Guid.Parse("d592283e-9b6c-5230-b3c2-0832974f987c"), substanceId = Guid.Parse("c862f4f1-07a5-5e67-a833-09c3a01344c5")},

                new Preparations{id = Guid.Parse("b80e02fd-5074-5d91-b8ad-7b3c86a709a8"), preparationId = Guid.Parse("f7740154-612b-5374-a697-59eef0867373"), substanceId = Guid.Parse("c862f4f1-07a5-5e67-a833-09c3a01344c5")},
                new Preparations{id = Guid.Parse("78b58dfc-74dc-538b-85d1-ed712f01ddfe"), preparationId = Guid.Parse("f7740154-612b-5374-a697-59eef0867373"), substanceId = Guid.Parse("460e19cb-69fa-5641-b2be-a3a6090d8505")},
                new Preparations{id = Guid.Parse("f361fede-ef31-5565-a094-e90139fb359f"), preparationId = Guid.Parse("f7740154-612b-5374-a697-59eef0867373"), substanceId = Guid.Parse("13aa1f23-f7cd-5844-93f1-d02288edab3f")},
                new Preparations{id = Guid.Parse("fe545b70-4444-5a15-bb20-bdcda6e98215"), preparationId = Guid.Parse("f7740154-612b-5374-a697-59eef0867373"), substanceId = Guid.Parse("1741e39c-f09a-52cf-9b0a-78e042f0475d")},

                new Preparations{id = Guid.Parse("628bc037-f567-5cf6-83a1-9816c2e224fc"), preparationId = Guid.Parse("077f314e-73e0-5d93-b07e-00c24a3b8433"), substanceId = Guid.Parse("cbba5594-0868-51d9-939d-d6eb6d25eb43")},
                new Preparations{id = Guid.Parse("007b9fef-313d-518d-9b48-1c33bff16e4f"), preparationId = Guid.Parse("077f314e-73e0-5d93-b07e-00c24a3b8433"), substanceId = Guid.Parse("1d8b8ae5-16c7-500b-af54-b7fc76f8a692")},

                new Preparations{id = Guid.Parse("0d145380-b9da-5a3e-9021-6ac841b5eac7"), preparationId = Guid.Parse("c2b14833-5908-5091-b6f0-60e6a900b188"), substanceId = Guid.Parse("11e8dd28-a306-5728-bd11-86f4b5e78e88")},

                new Preparations{id = Guid.Parse("2450593f-2a5c-5f2f-8ad7-a512663c58f9"), preparationId = Guid.Parse("7d21386e-d763-5003-a138-b3e5df97e1f1"), substanceId = Guid.Parse("46106466-bc43-5e38-937f-3969a91f1014")},
                new Preparations{id = Guid.Parse("7a54194d-599f-5e57-bdf3-a4b2021eaaeb"), preparationId = Guid.Parse("7d21386e-d763-5003-a138-b3e5df97e1f1"), substanceId = Guid.Parse("71b5f683-10ca-5a25-9b1c-994c2f6aea2c")},

                new Preparations{id = Guid.Parse("882b104d-df3a-519a-894f-7069bd24bb09"), preparationId = Guid.Parse("c6911467-545b-503c-8344-8240be7ad37a"), substanceId = Guid.Parse("a4bf5b84-2195-513f-8890-818d317f112b")},
                new Preparations{id = Guid.Parse("d8a803d3-4b95-5508-894f-323e658cd7d0"), preparationId = Guid.Parse("c6911467-545b-503c-8344-8240be7ad37a"), substanceId = Guid.Parse("e69778c4-5a92-51b1-b7a9-e8bfccd0bf89")},
                new Preparations{id = Guid.Parse("17be70f4-e003-5d43-99e5-73b184cef8b1"), preparationId = Guid.Parse("c6911467-545b-503c-8344-8240be7ad37a"), substanceId = Guid.Parse("1c0ff73d-0af4-5436-ba1d-f1b2684c1020")},

                new Preparations{id = Guid.Parse("a75558a6-3480-576a-a0ca-7123dff3168c"), preparationId = Guid.Parse("867d2a2e-8ef0-52eb-8f0b-4122be383250"), substanceId = Guid.Parse("022ce388-b484-5363-98a8-db8d284aff31")},
                new Preparations{id = Guid.Parse("ed0b4107-609e-5ea3-8585-651edd62766b"), preparationId = Guid.Parse("867d2a2e-8ef0-52eb-8f0b-4122be383250"), substanceId = Guid.Parse("ba708c67-ea24-5d24-8c74-f8035844bdb9")},
                new Preparations{id = Guid.Parse("a30eec3b-ea6f-5bce-ad5e-c49927070ea8"), preparationId = Guid.Parse("867d2a2e-8ef0-52eb-8f0b-4122be383250"), substanceId = Guid.Parse("c15c6275-2f62-52da-b4d5-2be439d553dc")},

                new Preparations{id = Guid.Parse("3d0cfad3-9699-5be1-b5cf-67697305b9df"), preparationId = Guid.Parse("12752f1b-3334-5642-904b-36495306d21c"), substanceId = Guid.Parse("df9c2354-8005-57f9-a625-149a34e77acb")},
                new Preparations{id = Guid.Parse("c5438248-b623-5d65-9da3-55d1f4e10f62"), preparationId = Guid.Parse("12752f1b-3334-5642-904b-36495306d21c"), substanceId = Guid.Parse("022ce388-b484-5363-98a8-db8d284aff31")},

                new Preparations{id = Guid.Parse("f4730a81-5ced-5973-9220-e171226a07bc"), preparationId = Guid.Parse("15c894d4-599b-573a-8d37-f802bdeddae8"), substanceId = Guid.Parse("cbba5594-0868-51d9-939d-d6eb6d25eb43")},
                new Preparations{id = Guid.Parse("1ed45c7a-4fb8-5ba7-83db-55b8606090b8"), preparationId = Guid.Parse("15c894d4-599b-573a-8d37-f802bdeddae8"), substanceId = Guid.Parse("1c0ff73d-0af4-5436-ba1d-f1b2684c1020")},
                new Preparations{id = Guid.Parse("a86231d7-107d-534f-8052-09a3bed3ff80"), preparationId = Guid.Parse("15c894d4-599b-573a-8d37-f802bdeddae8"), substanceId = Guid.Parse("df9c2354-8005-57f9-a625-149a34e77acb")},
            };
            if (!context.preparationsTable.Any())
            {
                context.preparationsTable.AddRange(preparationsReceipts);
                context.SaveChanges();
            }

            List<Symptom> symptomList = new List<Symptom>
            {
                new Symptom{id = Guid.Parse("6b11d1f0-fe01-5d79-929b-d53e7f8871b3"), name = "Symptom1"},
                new Symptom{id = Guid.Parse("b7e65431-2411-514c-90f8-e93b0437ae0e"), name = "Symptom2"},
                new Symptom{id = Guid.Parse("c5df1d3f-5504-55be-bf12-b14d578012b8"), name = "Symptom3"},
                new Symptom{id = Guid.Parse("7c3dc816-a45d-5ef0-9996-be8cbb00bd29"), name = "Symptom4"},
                new Symptom{id = Guid.Parse("5ea31f58-5a23-524a-bc7d-01154942d082"), name = "Symptom5"},
                new Symptom{id = Guid.Parse("b0ecb478-434f-5d76-9dd5-b157d2bfb7cc"), name = "Symptom6"},
                new Symptom{id = Guid.Parse("63a268b5-1d03-574c-92e6-59eb7f33834b"), name = "Symptom7"},
                new Symptom{id = Guid.Parse("6ea0c9be-a7d4-5c0c-8fbb-19f99be5963e"), name = "Symptom8"},
                new Symptom{id = Guid.Parse("b49a8c37-3839-5505-a64c-030e35a9c08c"), name = "Symptom9"},
                new Symptom{id = Guid.Parse("b3b6f0a4-d962-5a32-94ba-af8e054f9bcc"), name = "Symptom10"},
                new Symptom{id = Guid.Parse("06381b1a-3119-5084-a344-69a60fbe5c22"), name = "Symptom11"},
                new Symptom{id = Guid.Parse("eeaf7a70-7141-5677-9019-5aec71fcff18"), name = "Symptom12"},
                new Symptom{id = Guid.Parse("e5205c32-56b2-50a4-9fc1-52f579c824e2"), name = "Symptom13"},
                new Symptom{id = Guid.Parse("6eed7737-7100-57d3-ae1b-5d396ca62c1c"), name = "Symptom14"},
                new Symptom{id = Guid.Parse("b18764ec-e354-5ca9-bfbb-b908fdb6727c"), name = "Symptom15"},

            };
            if (!context.symptomTable.Any())
            {
                context.symptomTable.AddRange(symptomList);
                context.SaveChanges();
            }

            List<Disease> diseases = new List<Disease>
            {
                new Disease{id = Guid.Parse("3fcba847-c743-509e-9d62-6e14e0f2beb9"), name = "Disease1"},
                new Disease{id = Guid.Parse("9dac7a5d-6078-51f5-9a60-53ac2a9e08db"), name = "Disease2"},
                new Disease{id = Guid.Parse("19e42b86-cdb5-59a1-9e75-566cee838675"), name = "Disease3"},
                new Disease{id = Guid.Parse("edd6e090-3f85-5285-8139-2aa62b1d2b25"), name = "Disease4"},
                new Disease{id = Guid.Parse("d4d4d6e7-5780-5e47-8a44-26280c1bf5a2"), name = "Disease5"}
            };
            if (!context.diseaseTable.Any())
            {
                context.diseaseTable.AddRange(diseases);
                context.SaveChanges();
            }

            List<Symptoms> diseaseSymptoms = new List<Symptoms>
            {
                new Symptoms{id = Guid.Parse("6e229afc-8bc0-5a33-9652-328175e0fbed"), diseaseId = Guid.Parse("3fcba847-c743-509e-9d62-6e14e0f2beb9"), symptomId = Guid.Parse("6b11d1f0-fe01-5d79-929b-d53e7f8871b3")},
                new Symptoms{id = Guid.Parse("eb518a46-cb7d-5562-a5c5-2c85641a8e5d"), diseaseId = Guid.Parse("3fcba847-c743-509e-9d62-6e14e0f2beb9"), symptomId = Guid.Parse("b7e65431-2411-514c-90f8-e93b0437ae0e")},
                new Symptoms{id = Guid.Parse("1c5a77b2-596a-5695-9e00-7c015af2290a"), diseaseId = Guid.Parse("3fcba847-c743-509e-9d62-6e14e0f2beb9"), symptomId = Guid.Parse("c5df1d3f-5504-55be-bf12-b14d578012b8")},

                new Symptoms{id = Guid.Parse("5d35ac1f-0032-5649-b939-a6f6cc6e2b26"), diseaseId = Guid.Parse("9dac7a5d-6078-51f5-9a60-53ac2a9e08db"), symptomId = Guid.Parse("7c3dc816-a45d-5ef0-9996-be8cbb00bd29")},
                new Symptoms{id = Guid.Parse("28542794-c2a9-597d-b822-ca520a8db311"), diseaseId = Guid.Parse("9dac7a5d-6078-51f5-9a60-53ac2a9e08db"), symptomId = Guid.Parse("5ea31f58-5a23-524a-bc7d-01154942d082")},
                new Symptoms{id = Guid.Parse("63c185ca-c0a9-514c-aba9-1456b44a8afc"), diseaseId = Guid.Parse("9dac7a5d-6078-51f5-9a60-53ac2a9e08db"), symptomId = Guid.Parse("b0ecb478-434f-5d76-9dd5-b157d2bfb7cc")},

                new Symptoms{id = Guid.Parse("b398ae6d-be21-5de5-a636-b9b225d2c21d"), diseaseId = Guid.Parse("19e42b86-cdb5-59a1-9e75-566cee838675"), symptomId = Guid.Parse("c5df1d3f-5504-55be-bf12-b14d578012b8")},
                new Symptoms{id = Guid.Parse("dc197455-16e1-53f3-9fbf-1cae770953b2"), diseaseId = Guid.Parse("19e42b86-cdb5-59a1-9e75-566cee838675"), symptomId = Guid.Parse("63a268b5-1d03-574c-92e6-59eb7f33834b")},
                new Symptoms{id = Guid.Parse("c2ec9f84-f21c-53ea-b0fc-484ec1ae195c"), diseaseId = Guid.Parse("19e42b86-cdb5-59a1-9e75-566cee838675"), symptomId = Guid.Parse("6ea0c9be-a7d4-5c0c-8fbb-19f99be5963e")},

                new Symptoms{id = Guid.Parse("a36c3732-a1d9-56fb-a3ca-2975c36a78e2"), diseaseId = Guid.Parse("edd6e090-3f85-5285-8139-2aa62b1d2b25"), symptomId = Guid.Parse("b49a8c37-3839-5505-a64c-030e35a9c08c")},
                new Symptoms{id = Guid.Parse("c1e65afb-a615-58b5-b4ba-566687e6b969"), diseaseId = Guid.Parse("edd6e090-3f85-5285-8139-2aa62b1d2b25"), symptomId = Guid.Parse("06381b1a-3119-5084-a344-69a60fbe5c22")},
                new Symptoms{id = Guid.Parse("4a30ee39-a9f5-50c0-af8a-f4d5ff42476f"), diseaseId = Guid.Parse("edd6e090-3f85-5285-8139-2aa62b1d2b25"), symptomId = Guid.Parse("e5205c32-56b2-50a4-9fc1-52f579c824e2")},

                new Symptoms{id = Guid.Parse("aa22aa2d-f4a0-5907-aea7-47ce90bcf1fb"), diseaseId = Guid.Parse("d4d4d6e7-5780-5e47-8a44-26280c1bf5a2"), symptomId = Guid.Parse("b18764ec-e354-5ca9-bfbb-b908fdb6727c")},
                new Symptoms{id = Guid.Parse("79af1a13-ee21-5d90-b14c-8dba8cf7cd5e"), diseaseId = Guid.Parse("d4d4d6e7-5780-5e47-8a44-26280c1bf5a2"), symptomId = Guid.Parse("6eed7737-7100-57d3-ae1b-5d396ca62c1c")},
                new Symptoms{id = Guid.Parse("74ee5d3a-3b82-5c9a-aa73-245dae6ec262"), diseaseId = Guid.Parse("d4d4d6e7-5780-5e47-8a44-26280c1bf5a2"), symptomId = Guid.Parse("b49a8c37-3839-5505-a64c-030e35a9c08c")}
            };
            if (!context.symptomsTable.Any())
            {
                context.symptomsTable.AddRange(diseaseSymptoms);
                context.SaveChanges();
            }

            List<CaseStatus> caseStatus = new List<CaseStatus>
            {
                new CaseStatus{id=Guid.Parse("f201740b-635e-5e43-8828-91edf981319f"), statusName="В опрацюванні"},
                new CaseStatus{id=Guid.Parse("e1da67f5-443b-5292-a2e8-30af8c67bf53"), statusName="Закрито"}
            };
            if (!context.casesStatusTable.Any())
            {
                context.casesStatusTable.AddRange(caseStatus);
                context.SaveChanges();
            }
            List<Case> caseList = new List<Case>
            {
                new Case{id = Guid.Parse("83d8e883-6f2e-5831-a776-6efabe41f21b"), patientId = Guid.Parse("5c6ee728-e05c-5548-958d-814b37393c38"), doctorId = Guid.Parse("ddd5e6df-6814-5712-9b5c-4556fc5a0e94"),diseaseId = Guid.Parse("3fcba847-c743-509e-9d62-6e14e0f2beb9"),
                caseStatusId = Guid.Parse("f201740b-635e-5e43-8828-91edf981319f"), officeId = Guid.Parse("ef85177c-56a1-5e90-adea-8e46f55ee19f"), anamnesis = "anamnesis:", treatmentInformation = "treatment:", createDate = DateTime.Now},
                new Case{id = Guid.Parse("4672cc58-63a6-5154-9691-ce1b39fdc807"), patientId = Guid.Parse("5e92d932-5550-5958-9ff0-eaba681438ae"), doctorId = Guid.Parse("d2302edd-c8e4-54a2-a6c9-9d2a45b6b3dd"),diseaseId = Guid.Parse("edd6e090-3f85-5285-8139-2aa62b1d2b25"),
                caseStatusId = Guid.Parse("f201740b-635e-5e43-8828-91edf981319f"), officeId = Guid.Parse("1b7ab27e-517f-58f3-82c6-876fb523033e"), anamnesis = "anamnesis:", treatmentInformation = "treatment:", createDate = DateTime.Now}

            };
            if (!context.caseTable.Any())
            {
                context.caseTable.AddRange(caseList);
                context.SaveChanges();
            }
            List<Treatment> treatments = new List<Treatment>
            {
                new Treatment{id=Guid.Parse("87cc1dd9-9e21-40ef-b7e1-faec88b411cf"), caseId = Guid.Parse("83d8e883-6f2e-5831-a776-6efabe41f21b"), preparationId = Guid.Parse("15c894d4-599b-573a-8d37-f802bdeddae8")},
                new Treatment{id=Guid.Parse("9ba7a205-bcde-4807-8c34-b44b3104e8a2"), caseId = Guid.Parse("83d8e883-6f2e-5831-a776-6efabe41f21b"), preparationId = Guid.Parse("c6911467-545b-503c-8344-8240be7ad37a")},

                new Treatment{id=Guid.Parse("e9a36b63-4ebd-4a8a-9ac7-12efc3a1bc40"), caseId = Guid.Parse("4672cc58-63a6-5154-9691-ce1b39fdc807"), preparationId = Guid.Parse("f7740154-612b-5374-a697-59eef0867373")},
                new Treatment{id=Guid.Parse("208ce9de-da42-413b-bbe9-e3d93f143d5b"), caseId = Guid.Parse("4672cc58-63a6-5154-9691-ce1b39fdc807"), preparationId = Guid.Parse("12752f1b-3334-5642-904b-36495306d21c")}
            };
            if(!context.treatmentTable.Any())
            {
                context.treatmentTable.AddRange(treatments);
                context.SaveChanges();
            }

        }
    }
}
