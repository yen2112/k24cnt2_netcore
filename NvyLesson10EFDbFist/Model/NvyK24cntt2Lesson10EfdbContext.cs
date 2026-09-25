using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NvyLesson10EFDbFist.Model;

public partial class NvyK24cntt2Lesson10EfdbContext : DbContext
{
    public NvyK24cntt2Lesson10EfdbContext()
    {
    }

    public NvyK24cntt2Lesson10EfdbContext(DbContextOptions<NvyK24cntt2Lesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NvyMember> NvyMembers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=NvyK24CNTt2Lesson10EFDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NvyMember>(entity =>
        {
            entity.ToTable("NvyMember");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NvyEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NvyFullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NvyPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NvyPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NvyUserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
