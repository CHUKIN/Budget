using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Budget.Models;

namespace Budget.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Budget.Models.Cash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Money");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cashs");
                });

            modelBuilder.Entity("Budget.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("Budget.Models.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cash");

                    b.Property<int>("CategoryId");

                    b.Property<int>("Count");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Money");

                    b.Property<string>("Name");

                    b.Property<string>("Unit");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("Budget.Models.CostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cash");

                    b.Property<string>("Category");

                    b.Property<int>("Count");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Money");

                    b.Property<string>("Name");

                    b.Property<string>("Unit");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("CostModels");
                });

            modelBuilder.Entity("Budget.Models.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cash");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Money");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("Budget.Models.Saving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Current");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateCreate");

                    b.Property<int>("Money");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Savings");
                });

            modelBuilder.Entity("Budget.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Budget.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Budget.Models.Cost", b =>
                {
                    b.HasOne("Budget.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Budget.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
