using BankSelling.Models;
using BankSelling.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSelling
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Lender> Lenders { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Log> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ec2-34-254-120-2.eu-west-1.compute.amazonaws.com;Port=5432;Database=d4t90dhlg4i98k;Username=bphjbgrondmejy;Password=5943b49e112c90998c7d099df98c25505f3eedcd8dd2459e318ea362bc964818;Trust Server Certificate = true;SslMode=Require;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var ageConverter = new ValueConverter<Age, Int32>(
                  v => v.age,
                  v => new Age(v));

            var seriesConverter = new ValueConverter<Series, string>(
               v => v._Series,
               v => new Series(v));

            var numberConverter = new ValueConverter<Number, string>(
             v => v._Number,
             v => new Number(v));

            var workTypeConverter = new ValueConverter<WorkType, string>(
                v => v._WorkType,
                v => new WorkType(v));

            var goalConverter = new ValueConverter<Goal, string>(
               v => v._Goal,
               v => new Goal(v));


            builder.Entity<Lender>()     
            .Property(p => p.Age)
            .HasConversion(ageConverter)
            .HasColumnName("Age")
            .HasColumnType("int")
            .IsRequired();

            builder.Entity<Lender>()
           .Property(p => p.WorkType)
           .HasConversion(workTypeConverter)
           .HasColumnName("WorkType")
           .HasColumnType("varchar")
           .IsRequired();

            builder.Entity<Passport>()
         .Property(p => p.Series)
         .HasConversion(seriesConverter)
         .HasColumnName("Series")
         .HasColumnType("varchar")
         .IsRequired();

            builder.Entity<Passport>()
         .Property(p => p.Number)
         .HasConversion(numberConverter)
         .HasColumnName("Number")
         .HasColumnType("varchar")
         .IsRequired();

            builder.Entity<Credit>()
         .Property(p => p.Goal)
         .HasConversion(goalConverter)
         .HasColumnName("Goal")
         .HasColumnType("varchar")
         .IsRequired();
        }
    }
}
