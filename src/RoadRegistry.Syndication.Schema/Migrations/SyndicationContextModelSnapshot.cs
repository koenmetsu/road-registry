﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoadRegistry.Syndication.Schema;

namespace RoadRegistry.Syndication.Schema.Migrations
{
    [DbContext(typeof(SyndicationContext))]
    partial class SyndicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Be.Vlaanderen.Basisregisters.ProjectionHandling.Runner.ProjectionStates.ProjectionStateItem", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DesiredState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DesiredStateChangedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("Position")
                        .HasColumnType("bigint");

                    b.HasKey("Name")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("ProjectionStates","RoadRegistrySyndicationMeta");
                });

            modelBuilder.Entity("RoadRegistry.Syndication.Schema.MunicipalityRecord", b =>
                {
                    b.Property<Guid>("MunicipalityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DutchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GermanName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MunicipalityStatus")
                        .HasColumnType("int");

                    b.Property<string>("NisCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MunicipalityId");

                    b.HasIndex("MunicipalityId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Municipality","RoadRegistrySyndication");
                });

            modelBuilder.Entity("RoadRegistry.Syndication.Schema.StreetNameRecord", b =>
                {
                    b.Property<Guid>("StreetNameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DutchHomonymAddition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DutchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DutchNameWithHomonymAddition")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("COALESCE(DutchName + COALESCE('_' + DutchHomonymAddition,''), DutchHomonymAddition) PERSISTED");

                    b.Property<string>("EnglishHomonymAddition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishNameWithHomonymAddition")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("COALESCE(EnglishName + COALESCE('_' + EnglishHomonymAddition,''), EnglishHomonymAddition) PERSISTED");

                    b.Property<string>("FrenchHomonymAddition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrenchNameWithHomonymAddition")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("COALESCE(FrenchName + COALESCE('_' + FrenchHomonymAddition,''), FrenchHomonymAddition) PERSISTED");

                    b.Property<string>("GermanHomonymAddition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GermanName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GermanNameWithHomonymAddition")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("COALESCE(GermanName + COALESCE('_' + GermanHomonymAddition,''), GermanHomonymAddition) PERSISTED");

                    b.Property<string>("HomonymAddition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MunicipalityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameWithHomonymAddition")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("COALESCE(Name + COALESCE('_' + HomonymAddition,''), HomonymAddition) PERSISTED");

                    b.Property<string>("NisCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersistentLocalId")
                        .HasColumnType("int");

                    b.Property<long>("Position")
                        .HasColumnType("bigint");

                    b.Property<int?>("StreetNameStatus")
                        .HasColumnType("int");

                    b.HasKey("StreetNameId");

                    b.HasIndex("PersistentLocalId");

                    b.HasIndex("StreetNameId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("StreetName","RoadRegistrySyndication");
                });
#pragma warning restore 612, 618
        }
    }
}
