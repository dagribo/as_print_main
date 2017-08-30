using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using printer.Database;

namespace data.printer.Migrations
{
    [DbContext(typeof(PrinterContext))]
    [Migration("20170731101935_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("printer.Database.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("Color");

                    b.Property<int>("Format");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("PaperFeed");

                    b.Property<int?>("ProducerId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("printer.Database.ModelZip", b =>
                {
                    b.Property<int>("ModelId");

                    b.Property<int>("ZipId");

                    b.Property<int>("Type");

                    b.HasKey("ModelId", "ZipId");

                    b.HasIndex("ZipId");

                    b.ToTable("ModelsZips");
                });

            modelBuilder.Entity("printer.Database.Printer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("ModelId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Printers");
                });

            modelBuilder.Entity("printer.Database.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("printer.Database.Zip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("Cost");

                    b.Property<string>("Model")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int?>("ProducerId");

                    b.Property<int>("Resource");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Zips");
                });

            modelBuilder.Entity("printer.Database.Model", b =>
                {
                    b.HasOne("printer.Database.Producer", "Producer")
                        .WithMany("Models")
                        .HasForeignKey("ProducerId");
                });

            modelBuilder.Entity("printer.Database.ModelZip", b =>
                {
                    b.HasOne("printer.Database.Model", "Model")
                        .WithMany("ModelsZips")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("printer.Database.Zip", "Zip")
                        .WithMany("ModelsZips")
                        .HasForeignKey("ZipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("printer.Database.Printer", b =>
                {
                    b.HasOne("printer.Database.Model", "Model")
                        .WithMany("Printers")
                        .HasForeignKey("ModelId");
                });

            modelBuilder.Entity("printer.Database.Zip", b =>
                {
                    b.HasOne("printer.Database.Producer", "Producer")
                        .WithMany("Zips")
                        .HasForeignKey("ProducerId");
                });
        }
    }
}
