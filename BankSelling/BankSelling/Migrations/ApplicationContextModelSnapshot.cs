// <auto-generated />
using System;
using BankSelling;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BankSelling.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BankSelling.Models.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreditSum")
                        .HasColumnType("integer");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("Goal");

                    b.Property<int>("LenderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LenderId");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("BankSelling.Models.Lender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<string>("FatherName")
                        .HasColumnType("text");

                    b.Property<bool>("IsJail")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PassportId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("WorkType")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("WorkType");

                    b.HasKey("Id");

                    b.HasIndex("PassportId");

                    b.ToTable("Lenders");
                });

            modelBuilder.Entity("BankSelling.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("LenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Percent")
                        .HasColumnType("text");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("BankSelling.ValueObjects.Passport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("Number");

                    b.Property<string>("Propiska")
                        .HasColumnType("text");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("Series");

                    b.Property<string>("Vidan")
                        .HasColumnType("text");

                    b.Property<DateTime>("VidanTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("BankSelling.Models.Credit", b =>
                {
                    b.HasOne("BankSelling.Models.Lender", "Lender")
                        .WithMany("Credits")
                        .HasForeignKey("LenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lender");
                });

            modelBuilder.Entity("BankSelling.Models.Lender", b =>
                {
                    b.HasOne("BankSelling.ValueObjects.Passport", "Passport")
                        .WithMany()
                        .HasForeignKey("PassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passport");
                });

            modelBuilder.Entity("BankSelling.Models.Lender", b =>
                {
                    b.Navigation("Credits");
                });
#pragma warning restore 612, 618
        }
    }
}
