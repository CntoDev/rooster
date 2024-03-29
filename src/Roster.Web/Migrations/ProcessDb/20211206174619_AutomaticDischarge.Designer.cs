﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Roster.Infrastructure.Storage;

namespace Roster.Web.Migrations.ProcessDb
{
    [DbContext(typeof(ProcessDbContext))]
    [Migration("20211206174619_AutomaticDischarge")]
    partial class AutomaticDischarge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Roster.Core.Sagas.RecruitmentSaga", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<bool>("AutomaticDischarge")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("BootcampCompletionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("EnoughAttendedEvents")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModsCheckDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RecruitmentStartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool?>("TrialSucceeded")
                        .HasColumnType("boolean");

                    b.HasKey("CorrelationId");

                    b.ToTable("RecruitmentSaga");
                });
#pragma warning restore 612, 618
        }
    }
}
