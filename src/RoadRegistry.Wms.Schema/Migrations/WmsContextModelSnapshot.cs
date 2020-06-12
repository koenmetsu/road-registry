﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using RoadRegistry.Wms.Schema;

namespace RoadRegistry.Wms.Schema.Migrations
{
    [DbContext(typeof(WmsContext))]
    partial class WmsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
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

                    b.ToTable("ProjectionStates","RoadRegistryWmsMeta");
                });

            modelBuilder.Entity("RoadRegistry.Wms.Schema.RoadSegmentRecord", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnName("wegsegmentID")
                        .HasColumnType("int");

                    b.Property<int?>("AccessRestriction")
                        .HasColumnName("toegangsbeperking")
                        .HasColumnType("int");

                    b.Property<string>("AccessRestrictionLabel")
                        .HasColumnName("lblToegangsbeperking")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("BeginApplication")
                        .HasColumnName("beginapplicatie")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("BeginOperator")
                        .HasColumnName("beginoperator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeginOrganization")
                        .HasColumnName("beginorganisatie")
                        .HasColumnType("varchar(18)");

                    b.Property<int?>("BeginRoadNodeId")
                        .HasColumnName("beginWegknoopID")
                        .HasColumnType("int");

                    b.Property<string>("BeginTime")
                        .HasColumnName("begintijd")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Category")
                        .HasColumnName("categorie")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CategoryLabel")
                        .HasColumnName("lblCategorie")
                        .HasColumnType("varchar(64)");

                    b.Property<int?>("EndRoadNodeId")
                        .HasColumnName("eindWegknoopID")
                        .HasColumnType("int");

                    b.Property<Geometry>("Geometry")
                        .HasColumnName("geometrie")
                        .HasColumnType("Geometry");

                    b.Property<Geometry>("Geometry2D")
                        .HasColumnName("geometrie2D")
                        .HasColumnType("Geometry");

                    b.Property<int?>("GeometryVersion")
                        .HasColumnName("geometrieversie")
                        .HasColumnType("int");

                    b.Property<int?>("LeftSideMunicipality")
                        .HasColumnName("linksGemeente")
                        .HasColumnType("int");

                    b.Property<int?>("LeftSideStreetNameId")
                        .HasColumnName("linksStraatnaamID")
                        .HasColumnType("int");

                    b.Property<string>("LeftSideStreetNameLabel")
                        .HasColumnName("linksStraatnaam")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Maintainer")
                        .HasColumnName("beheerder")
                        .HasColumnType("varchar(18)");

                    b.Property<string>("MaintainerLabel")
                        .HasColumnName("lblBeheerder")
                        .HasColumnType("varchar(64)");

                    b.Property<int?>("Method")
                        .HasColumnName("methode")
                        .HasColumnType("int");

                    b.Property<string>("MethodLabel")
                        .HasColumnName("lblMethode")
                        .HasColumnType("varchar(64)");

                    b.Property<int?>("Morphology")
                        .HasColumnName("morfologie")
                        .HasColumnType("int");

                    b.Property<string>("MorphologyLabel")
                        .HasColumnName("lblMorfologie")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("OrganizationLabel")
                        .HasColumnName("lblOrganisatie")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime?>("RecordingDate")
                        .HasColumnName("opnamedatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RightSideMunicipality")
                        .HasColumnName("rechtsGemeente")
                        .HasColumnType("int");

                    b.Property<int?>("RightSideStreetNameId")
                        .HasColumnName("rechtsStraatnaamID")
                        .HasColumnType("int");

                    b.Property<string>("RightSideStreetNameLabel")
                        .HasColumnName("rechtsStraatnaam")
                        .HasColumnType("varchar(128)");

                    b.Property<int?>("RoadSegmentVersion")
                        .HasColumnName("wegsegmentversie")
                        .HasColumnType("int");

                    b.Property<int?>("SourceId")
                        .HasColumnName("sourceID")
                        .HasColumnType("int");

                    b.Property<string>("SourceIdSource")
                        .HasColumnName("bronSourceID")
                        .HasColumnType("varchar(18)");

                    b.Property<int?>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.Property<string>("StatusLabel")
                        .HasColumnName("lblStatus")
                        .HasColumnType("varchar(64)");

                    b.Property<int?>("TransactionId")
                        .HasColumnName("transactieID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("wegsegmentDenorm","RoadRegistryWms");
                });
#pragma warning restore 612, 618
        }
    }
}