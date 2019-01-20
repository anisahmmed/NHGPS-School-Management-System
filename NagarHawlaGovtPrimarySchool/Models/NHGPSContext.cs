using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class NHGPSContext : DbContext
    {
        public NHGPSContext(DbContextOptions<NHGPSContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admission> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<RelResult> RelResults { get; set; }

        public DbSet<RelClass> RelClasses { get; set; }
        public DbSet<RelClassSubject> RelClassSubjects { get; set; }
        public DbSet<RelClassSection> RelClassSections { get; set; }


    }
}
