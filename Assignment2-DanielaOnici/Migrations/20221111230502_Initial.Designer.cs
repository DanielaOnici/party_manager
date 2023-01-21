﻿// <auto-generated />
using System;
using Assignment2_DanielaOnici.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment2DanielaOnici.Migrations
{
    [DbContext(typeof(PartyDBContext))]
    [Migration("20221111230502_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment2_DanielaOnici.Entities.Invitation", b =>
                {
                    b.Property<int>("InvitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvitationId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PartyId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("InvitationId");

                    b.HasIndex("PartyId");

                    b.ToTable("Invitations");

                    b.HasData(
                        new
                        {
                            InvitationId = 1,
                            Email = "danielaonici@gmail.com",
                            GuestName = "Daniela Onici",
                            PartyId = 1,
                            Status = "InvitationSent"
                        },
                        new
                        {
                            InvitationId = 2,
                            Email = "gloria@gmail.com",
                            GuestName = "Gloria",
                            PartyId = 1,
                            Status = "RespondedNo"
                        },
                        new
                        {
                            InvitationId = 3,
                            Email = "boa@gmail.com",
                            GuestName = "Boa",
                            PartyId = 1,
                            Status = "InvitationNotSent"
                        },
                        new
                        {
                            InvitationId = 4,
                            Email = "gabriela@gmail.com",
                            GuestName = "Gabriela",
                            PartyId = 1,
                            Status = "RespondedYes"
                        },
                        new
                        {
                            InvitationId = 5,
                            Email = "luiz@gmail.com",
                            GuestName = "Luiz",
                            PartyId = 2,
                            Status = "InvitationSent"
                        },
                        new
                        {
                            InvitationId = 6,
                            Email = "danielaonici@gmail.com",
                            GuestName = "Daniela Onici",
                            PartyId = 3,
                            Status = "InvitationSent"
                        });
                });

            modelBuilder.Entity("Assignment2_DanielaOnici.Entities.Party", b =>
                {
                    b.Property<int>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EventDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartyId");

                    b.ToTable("Parties");

                    b.HasData(
                        new
                        {
                            PartyId = 1,
                            Description = "New year's eve blast!!",
                            EventDate = new DateTime(2022, 12, 31, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Times Square, NY"
                        },
                        new
                        {
                            PartyId = 2,
                            Description = "Drinks at Moe's Bar",
                            EventDate = new DateTime(2022, 10, 30, 4, 43, 0, 0, DateTimeKind.Unspecified),
                            Location = "Moe's Bar, Springfield"
                        },
                        new
                        {
                            PartyId = 3,
                            Description = "Thanksgiving gathering",
                            EventDate = new DateTime(2022, 10, 20, 4, 43, 0, 0, DateTimeKind.Unspecified),
                            Location = "Springfield"
                        });
                });

            modelBuilder.Entity("Assignment2_DanielaOnici.Entities.Invitation", b =>
                {
                    b.HasOne("Assignment2_DanielaOnici.Entities.Party", "Party")
                        .WithMany("Invitations")
                        .HasForeignKey("PartyId");

                    b.Navigation("Party");
                });

            modelBuilder.Entity("Assignment2_DanielaOnici.Entities.Party", b =>
                {
                    b.Navigation("Invitations");
                });
#pragma warning restore 612, 618
        }
    }
}