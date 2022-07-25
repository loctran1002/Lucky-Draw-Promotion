﻿// <auto-generated />
using System;
using LuckyDrawPromotion.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LuckyDrawPromotion.Migrations
{
    [DbContext(typeof(PromotionDbContext))]
    partial class PromotionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Admin", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Award", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsSent")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumberUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UsedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdCode");

                    b.HasIndex("PhoneNumberUser");

                    b.ToTable("Award", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Campaign", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AutoUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdmin")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("smalldatetime");

                    b.Property<Guid>("IdSetting")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("UseOnlyOnce")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Name");

                    b.HasIndex("EmailAdmin");

                    b.HasIndex("IdSetting")
                        .IsUnique();

                    b.ToTable("Campaign", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Code", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdGift")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LimitUsage")
                        .HasColumnType("int");

                    b.Property<string>("NameCampaign")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("RuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Target")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UsedCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("IdGift");

                    b.HasIndex("NameCampaign");

                    b.HasIndex("RuleId");

                    b.ToTable("Code", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Gift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gift", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.InsCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Charset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("NameCampaign")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Postfix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NameCampaign");

                    b.ToTable("InsCode", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Log", b =>
                {
                    b.Property<int>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Priority"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCampaign")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Priority");

                    b.HasIndex("NameCampaign");

                    b.ToTable("Log", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Rule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdGift")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameCampaign")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("Probability")
                        .HasColumnType("int");

                    b.Property<int>("QuantityGift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdGift");

                    b.HasIndex("NameCampaign");

                    b.ToTable("Rule", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DailyReport")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenQR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandingPage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SMSText")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeSend")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Setting", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.User", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Block")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("TypeBusiness")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneNumber");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Award", b =>
                {
                    b.HasOne("LuckyDrawPromotion.Data.Entity.Code", "Code")
                        .WithMany("Awards")
                        .HasForeignKey("IdCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDrawPromotion.Data.Entity.User", "User")
                        .WithMany("Awards")
                        .HasForeignKey("PhoneNumberUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Code");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Campaign", b =>
                {
                    b.HasOne("LuckyDrawPromotion.Data.Entity.Admin", "Admin")
                        .WithMany("Campaigns")
                        .HasForeignKey("EmailAdmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDrawPromotion.Data.Entity.Setting", "Setting")
                        .WithOne("Campaign")
                        .HasForeignKey("LuckyDrawPromotion.Data.Entity.Campaign", "IdSetting")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Setting");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Code", b =>
                {
                    b.HasOne("LuckyDrawPromotion.Data.Entity.Gift", "Gift")
                        .WithMany("Codes")
                        .HasForeignKey("IdGift")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LuckyDrawPromotion.Data.Entity.Campaign", "Campaign")
                        .WithMany("Codes")
                        .HasForeignKey("NameCampaign")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LuckyDrawPromotion.Data.Entity.Rule", null)
                        .WithMany("Codes")
                        .HasForeignKey("RuleId");

                    b.Navigation("Campaign");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.InsCode", b =>
                {
                    b.HasOne("LuckyDrawPromotion.Data.Entity.Campaign", "Campaign")
                        .WithMany("InsCodes")
                        .HasForeignKey("NameCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Log", b =>
                {
                    b.HasOne("LuckyDrawPromotion.Data.Entity.Campaign", "Campaign")
                        .WithMany("Logs")
                        .HasForeignKey("NameCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Rule", b =>
                {
                    b.HasOne("LuckyDrawPromotion.Data.Entity.Gift", "Gift")
                        .WithMany("Rules")
                        .HasForeignKey("IdGift")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LuckyDrawPromotion.Data.Entity.Campaign", "Campaign")
                        .WithMany("Rules")
                        .HasForeignKey("NameCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Admin", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Campaign", b =>
                {
                    b.Navigation("Codes");

                    b.Navigation("InsCodes");

                    b.Navigation("Logs");

                    b.Navigation("Rules");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Code", b =>
                {
                    b.Navigation("Awards");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Gift", b =>
                {
                    b.Navigation("Codes");

                    b.Navigation("Rules");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Rule", b =>
                {
                    b.Navigation("Codes");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.Setting", b =>
                {
                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("LuckyDrawPromotion.Data.Entity.User", b =>
                {
                    b.Navigation("Awards");
                });
#pragma warning restore 612, 618
        }
    }
}
