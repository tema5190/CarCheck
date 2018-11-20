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
    [DbContext(typeof(CarAppContext))]
    [Migration("20181120171054_AddedPenaltyCountIntoCar")]
    partial class AddedPenaltyCountIntoCar
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

                    b.Property<int?>("PenaltyCount");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarIdCardDataId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Models.Grabber.PenaltyRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<DateTime>("PenaltyDataTime");

                    b.Property<string>("PenaltyNumber");

                    b.HasKey("Id");

                    b.ToTable("PenaltyRecords");
                });

            modelBuilder.Entity("Models.Mail.ConfirmationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Hash1");

                    b.Property<string>("Hash2");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ConfirmationModels");
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
