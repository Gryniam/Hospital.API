using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.API.Models.Entities;
using Microsoft.Identity.Client;

namespace Hospital.API.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Allergy> allergiesTable { get; set; }

        public DbSet<Analys> analysTable { get; set; }

        public DbSet<Case> caseTable { get; set; }

        public DbSet<CaseStatus> casesStatusTable { get; set; }

        public DbSet<Departament> departamentTable { get; set; }

        public DbSet<Disease> diseaseTable { get; set; }

        public DbSet<District> districtTable { get; set; }

        public DbSet<Doctor> doctorTable { get; set; }

        public DbSet<UserPicture> userPictureTable { get; set; }

        public DbSet<Gender> genderTable { get; set; }

        public DbSet<Hospital.API.Models.Entities.Hospital> hospitalTable { get; set; }

        public DbSet<Indexes> indexesTable { get; set; }

        public DbSet<Office> officeTable { get; set; }

        public DbSet<Offices> officesTable { get; set; }

        public DbSet<Patient> patientTable { get; set; }

        public DbSet<Preparation> preparationTable { get; set; }

        public DbSet<Region> regionTable { get; set; }

        public DbSet<Settlement> settlementTable { get; set; }

        public DbSet<Specialty> specialityTable { get; set; }

        public DbSet<Specialities> specialitiesTable { get; set; }

        public DbSet<Status> statusTable { get; set; }

        public DbSet<Substance> substanceTable { get; set; }

        public DbSet<Symptom> symptomTable { get; set; } 

        public DbSet<Symptoms> symptomsTable { get; set; }

        public DbSet<Treatment> treatmentTable { get; set;}
       
        public DbSet<Models.Entities.Type> typeTable { get; set; }

        public DbSet<User> userTable { get;set; }

        public DbSet<Work> workTable { get; set; }

        public DbSet<Preparations> preparationsTable { get; set;}

        public DbSet<Time>  timeTable { get; set; }
        public DbSet<Appoiment> appoimentTable { get; set;}

        public DbSet<Request> requestTable { get; set; }
    }
}
