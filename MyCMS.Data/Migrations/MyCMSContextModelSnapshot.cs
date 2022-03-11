﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCMS.Data;

#nullable disable

namespace MyCMS.Data.Migrations
{
    [DbContext(typeof(MyCMSContext))]
    partial class MyCMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("MyCMS.Core.Entities.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttributeType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.AttributeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttributeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.ToTable("AttributeOptions");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<int>("ContentTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDatetime")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifyDatetime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifyUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContentTypeId");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("ModifyUserId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.ContentAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttributeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AttributeOptionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ValueDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ValueNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ValueText")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("AttributeOptionId");

                    b.HasIndex("ContentId", "AttributeId")
                        .IsUnique();

                    b.ToTable("ContentAttributes");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.ContentRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContainerContentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContentRelationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContentRelationTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReferredContentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContentRelationTypeId");

                    b.HasIndex("ReferredContentId");

                    b.HasIndex("ContainerContentId", "ReferredContentId", "ContentRelationTypeId")
                        .IsUnique();

                    b.ToTable("ContentRelations");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.ContentRelationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ContentRelationTypes");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.ContentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ContentTypes");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.AttributeOption", b =>
                {
                    b.HasOne("MyCMS.Core.Entities.Attribute", "Attribute")
                        .WithMany("Options")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.Content", b =>
                {
                    b.HasOne("MyCMS.Core.Entities.ContentType", "ContentType")
                        .WithMany()
                        .HasForeignKey("ContentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCMS.Core.Entities.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCMS.Core.Entities.User", "ModifyUser")
                        .WithMany()
                        .HasForeignKey("ModifyUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentType");

                    b.Navigation("CreateUser");

                    b.Navigation("ModifyUser");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.ContentAttribute", b =>
                {
                    b.HasOne("MyCMS.Core.Entities.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCMS.Core.Entities.AttributeOption", "AttributeOption")
                        .WithMany()
                        .HasForeignKey("AttributeOptionId");

                    b.HasOne("MyCMS.Core.Entities.Content", "Content")
                        .WithMany("Attributes")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("AttributeOption");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.ContentRelation", b =>
                {
                    b.HasOne("MyCMS.Core.Entities.Content", "ContainerContent")
                        .WithMany("Contents")
                        .HasForeignKey("ContainerContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCMS.Core.Entities.ContentRelationType", "ContentRelationType")
                        .WithMany()
                        .HasForeignKey("ContentRelationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCMS.Core.Entities.Content", "ReferredContent")
                        .WithMany("ReferencedBy")
                        .HasForeignKey("ReferredContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContainerContent");

                    b.Navigation("ContentRelationType");

                    b.Navigation("ReferredContent");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.Attribute", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("MyCMS.Core.Entities.Content", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Contents");

                    b.Navigation("ReferencedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
