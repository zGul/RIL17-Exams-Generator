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
        DbSet<Exam> Examen;
        public ExamGeneratorContext(DbContextOptions<ExamGeneratorContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Exam>()
                .Property(b => b.Url)
                .IsRequired();*/
        }

    }
}
