﻿// <auto-generated />
using System;
using AirportWildlife.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportWildlife.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190630161320_addUserToModels")]
    partial class addUserToModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirportWildlife.Models.AnimalActivity", b =>
                {
                    b.Property<int>("AnimalActivityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("AnimalActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("AnimalActivities");
                });

            modelBuilder.Entity("AirportWildlife.Models.ControlMethod", b =>
                {
                    b.Property<int>("ControlMethodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("ControlMethodId");

                    b.HasIndex("UserId");

                    b.ToTable("ControlMethods");
                });

            modelBuilder.Entity("AirportWildlife.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Initials")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AirportWildlife.Models.Habitat", b =>
                {
                    b.Property<int>("HabitatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("HabitatId");

                    b.HasIndex("UserId");

                    b.ToTable("Habitats");
                });

            modelBuilder.Entity("AirportWildlife.Models.Interaction", b =>
                {
                    b.Property<int>("InteractionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalActivityId");

                    b.Property<string>("Comments");

                    b.Property<int>("ControlMethodId");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("HabitatId");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<int>("NumberTaken");

                    b.Property<int>("SpeciesCount");

                    b.Property<int>("SpeciesId");

                    b.Property<string>("UserId");

                    b.HasKey("InteractionId");

                    b.HasIndex("AnimalActivityId");

                    b.HasIndex("ControlMethodId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("HabitatId");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("UserId");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("AirportWildlife.Models.Species", b =>
                {
                    b.Property<int>("SpeciesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("SpeciesId");

                    b.HasIndex("UserId");

                    b.ToTable("Species");
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
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

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
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

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

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AirportWildlife.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("AccountName")
                        .IsRequired();

                    b.Property<string>("Airport")
                        .IsRequired();

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AirportWildlife.Models.AnimalActivity", b =>
                {
                    b.HasOne("AirportWildlife.Models.ApplicationUser", "User")
                        .WithMany("AnimalActivities")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AirportWildlife.Models.ControlMethod", b =>
                {
                    b.HasOne("AirportWildlife.Models.ApplicationUser", "User")
                        .WithMany("ControlMethods")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AirportWildlife.Models.Employee", b =>
                {
                    b.HasOne("AirportWildlife.Models.ApplicationUser", "User")
                        .WithMany("Employees")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AirportWildlife.Models.Habitat", b =>
                {
                    b.HasOne("AirportWildlife.Models.ApplicationUser", "User")
                        .WithMany("Habitats")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AirportWildlife.Models.Interaction", b =>
                {
                    b.HasOne("AirportWildlife.Models.AnimalActivity", "AnimalActivity")
                        .WithMany("Interactions")
                        .HasForeignKey("AnimalActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWildlife.Models.ControlMethod", "ControlMethod")
                        .WithMany("Interactions")
                        .HasForeignKey("ControlMethodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWildlife.Models.Employee", "Employee")
                        .WithMany("Interactions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWildlife.Models.Habitat", "Habitat")
                        .WithMany("Interactions")
                        .HasForeignKey("HabitatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWildlife.Models.Species", "Species")
                        .WithMany("Interactions")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWildlife.Models.ApplicationUser", "User")
                        .WithMany("Interactions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AirportWildlife.Models.Species", b =>
                {
                    b.HasOne("AirportWildlife.Models.ApplicationUser", "User")
                        .WithMany("Species")
                        .HasForeignKey("UserId");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
