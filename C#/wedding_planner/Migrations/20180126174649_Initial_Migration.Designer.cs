using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using wedding_planner.Models;

namespace wedding_planner.Migrations
{
    [DbContext(typeof(wedding_plannerContext))]
    [Migration("20180126174649_Initial_Migration")]
    partial class Initial_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("wedding_planner.Models.RSVP", b =>
                {
                    b.Property<int>("RSVPId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int>("WeddingId");

                    b.HasKey("RSVPId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("RSVPS");
                });

            modelBuilder.Entity("wedding_planner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("wedding_planner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatorId");

                    b.Property<string>("address")
                        .IsRequired();

                    b.Property<DateTime>("date");

                    b.Property<string>("wedder_one")
                        .IsRequired();

                    b.Property<string>("wedder_two")
                        .IsRequired();

                    b.HasKey("WeddingId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("wedding_planner.Models.RSVP", b =>
                {
                    b.HasOne("wedding_planner.Models.User", "User")
                        .WithMany("RSVPS")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("wedding_planner.Models.Wedding", "Wedding")
                        .WithMany("RSVPS")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("wedding_planner.Models.Wedding", b =>
                {
                    b.HasOne("wedding_planner.Models.User", "Creator")
                        .WithMany("Weddings")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
