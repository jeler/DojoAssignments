using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using user_dashboard.Models;

namespace user_dashboard.Migrations
{
    [DbContext(typeof(user_dashboardContext))]
    partial class user_dashboardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("user_dashboard.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MessageId");

                    b.Property<int>("UserId");

                    b.Property<string>("comment")
                        .IsRequired();

                    b.Property<DateTime>("created_at");

                    b.HasKey("CommentId");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("user_dashboard.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReceiverId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("message")
                        .IsRequired();

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("user_dashboard.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<string>("description");

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.Property<int>("user_level");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("user_dashboard.Models.Comment", b =>
                {
                    b.HasOne("user_dashboard.Models.Message")
                        .WithMany("Comments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("user_dashboard.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("user_dashboard.Models.Message", b =>
                {
                    b.HasOne("user_dashboard.Models.User", "User")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
