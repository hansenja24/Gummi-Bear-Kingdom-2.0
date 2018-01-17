using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Gummi_Bear_Kingdom.Models;

namespace Gummi_Bear_Kingdom.Migrations
{
    [DbContext(typeof(GummiBearKingdomDbContext))]
    [Migration("20180112225045_UpdateModelwithRelationship")]
    partial class UpdateModelwithRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Gummi_Bear_Kingdom.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ReviewId");

                    b.HasKey("ProductId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Gummi_Bear_Kingdom.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int>("Rating");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Gummi_Bear_Kingdom.Models.Product", b =>
                {
                    b.HasOne("Gummi_Bear_Kingdom.Models.Review", "Review")
                        .WithMany("Products")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
