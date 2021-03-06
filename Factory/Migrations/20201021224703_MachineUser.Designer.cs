﻿// <auto-generated />
using System;
using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Factory.Migrations
{
    [DbContext(typeof(FactoryContext))]
    [Migration("20201021224703_MachineUser")]
    partial class MachineUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Factory.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.Property<int>("EngineerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EngineerName");

                    b.Property<string>("EngineerStatus");

                    b.Property<string>("LicenseRenewal");

                    b.Property<string>("UserId");

                    b.HasKey("EngineerId");

                    b.HasIndex("UserId");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("Factory.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("IncidentDate");

                    b.Property<string>("IncidentTitle");

                    b.HasKey("IncidentId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("Factory.Models.IncidentJoin", b =>
                {
                    b.Property<int>("IncidentJoinId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("IncidentId");

                    b.Property<int>("MachineId");

                    b.HasKey("IncidentJoinId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("IncidentId");

                    b.HasIndex("MachineId");

                    b.ToTable("IncidentJoins");
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InspectionDate");

                    b.Property<string>("MachineName");

                    b.Property<string>("MachineStatus");

                    b.Property<string>("UserId");

                    b.HasKey("MachineId");

                    b.HasIndex("UserId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Factory.Models.MachineEngineer", b =>
                {
                    b.Property<int>("MachineEngineerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("MachineId");

                    b.HasKey("MachineEngineerId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("MachineId");

                    b.ToTable("MachineEngineers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.HasOne("Factory.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Factory.Models.IncidentJoin", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany("Incidents")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.Incident", "Incident")
                        .WithMany("IncidentJoin")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.Machine", "Machine")
                        .WithMany("Incidents")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.HasOne("Factory.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Factory.Models.MachineEngineer", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany("Machines")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.Machine", "Machine")
                        .WithMany("Engineers")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Factory.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Factory.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Factory.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
