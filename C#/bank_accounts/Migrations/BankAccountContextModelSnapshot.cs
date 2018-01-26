﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bank_accounts.Models;

namespace bank_accounts.Migrations
{
    [DbContext(typeof(BankAccountContext))]
    partial class BankAccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("bank_accounts.Models.Transactions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Userid");

                    b.Property<int>("amount");

                    b.Property<DateTime>("created_at");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("bank_accounts.Models.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("balance");

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("bank_accounts.Models.Transactions", b =>
                {
                    b.HasOne("bank_accounts.Models.User")
                        .WithMany("Transactions")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
