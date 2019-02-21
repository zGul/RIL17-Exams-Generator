using Microsoft.EntityFrameworkCore;
using ril17ExamsGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ril17ExamsGenerator.Dal
{
    public class ExamGeneratorContext : DbContext
    {
        public  DbSet<Exam> exams { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<History> histories { get; set; }

        public ExamGeneratorContext(DbContextOptions<ExamGeneratorContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Exam>()
                .HasMany(e => e.questions).
                WithOne();

            builder.Entity<History>()
                .HasOne(h => h.exam);
            //To complete
        }
    }
}
