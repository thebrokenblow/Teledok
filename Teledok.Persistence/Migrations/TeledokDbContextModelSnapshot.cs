﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teledok.Persistence;

#nullable disable

namespace Teledok.Persistence.Migrations
{
    [DbContext(typeof(TeledokDbContext))]
    partial class TeledokDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientFounder", b =>
                {
                    b.Property<string>("ClientsINN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FoundersINN")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClientsINN", "FoundersINN");

                    b.HasIndex("FoundersINN");

                    b.ToTable("ClientFounder");
                });

            modelBuilder.Entity("Teledok.Domain.Client", b =>
                {
                    b.Property<string>("INN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEdit")
                        .HasColumnType("datetime2");

                    b.Property<string>("TitleCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeCompany")
                        .HasColumnType("int");

                    b.HasKey("INN");

                    b.HasIndex("INN")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Teledok.Domain.Founder", b =>
                {
                    b.Property<string>("INN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("INN");

                    b.HasIndex("INN")
                        .IsUnique();

                    b.ToTable("Founders");
                });

            modelBuilder.Entity("ClientFounder", b =>
                {
                    b.HasOne("Teledok.Domain.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsINN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teledok.Domain.Founder", null)
                        .WithMany()
                        .HasForeignKey("FoundersINN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
