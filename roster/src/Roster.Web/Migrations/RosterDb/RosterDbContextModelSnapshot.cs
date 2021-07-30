﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Roster.Infrastructure.Storage;

namespace Roster.Web.Migrations.RosterDb
{
    [DbContext(typeof(RosterDbContext))]
    partial class RosterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Roster.Core.Domain.ApplicationForm", b =>
                {
                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<string>("BiNickname")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DiscordId")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("GithubNickname")
                        .HasColumnType("text");

                    b.Property<string>("Gmail")
                        .HasColumnType("text");

                    b.Property<string>("SteamId")
                        .HasColumnType("text");

                    b.Property<string>("TeamspeakId")
                        .HasColumnType("text");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("Nickname");

                    b.ToTable("ApplicationForms");
                });

            modelBuilder.Entity("Roster.Core.Domain.ApplicationForm", b =>
                {
                    b.OwnsMany("Roster.Core.Domain.Arma3Dlc", "OwnedDlcs", b1 =>
                        {
                            b1.Property<string>("ApplicationFormNickname")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.HasKey("ApplicationFormNickname", "Id");

                            b1.ToTable("Arma3Dlc");

                            b1.WithOwner()
                                .HasForeignKey("ApplicationFormNickname");
                        });

                    b.Navigation("OwnedDlcs");
                });
#pragma warning restore 612, 618
        }
    }
}
