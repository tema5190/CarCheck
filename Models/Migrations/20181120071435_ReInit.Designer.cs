﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Models.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20181120071435_ReInit")]
    partial class ReInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.CarInfo.CarIdCardData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CertificateNumber");

                    b.Property<string>("CertificateSeries");

                    b.Property<string>("FullName");

                    b.HasKey("Id");

                    b.ToTable("CarIdCardData");
                });

            modelBuilder.Entity("Models.CarInfo.UserCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarIdCardDataId");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarIdCardDataId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCar");
                });

            modelBuilder.Entity("Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthInfoId");

                    b.Property<string>("Email");

                    b.Property<bool>("IsEmailConfirmed");

                    b.HasKey("Id");

                    b.HasIndex("AuthInfoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.User.UserAuthInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PasswordHash");

                    b.Property<byte[]>("Salt");

                    b.HasKey("Id");

                    b.ToTable("UserAuthInfo");
                });

            modelBuilder.Entity("Models.CarInfo.UserCar", b =>
                {
                    b.HasOne("Models.CarInfo.CarIdCardData", "CarIdCardData")
                        .WithMany()
                        .HasForeignKey("CarIdCardDataId");

                    b.HasOne("Models.User.User")
                        .WithMany("UserCars")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Models.User.User", b =>
                {
                    b.HasOne("Models.User.UserAuthInfo", "AuthInfo")
                        .WithMany()
                        .HasForeignKey("AuthInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
