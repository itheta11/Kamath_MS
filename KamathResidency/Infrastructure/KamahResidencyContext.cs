using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Infrastructure;

public partial class KamahResidencyContext : DbContext
{
    public KamahResidencyContext()
    {
    }

    public KamahResidencyContext(DbContextOptions<KamahResidencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\\\\\\\Work Desk\\\\\\\\kamath-residency\\\\\\\\sqlite-db\\\\\\\\KamathResidency.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.AdvanceAmount).HasColumnName("advance_amount");
            entity.Property(e => e.CheckIn)
                .HasColumnType("DATETIME")
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasColumnType("DATETIME")
                .HasColumnName("check_out");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("created_at");
            entity.Property(e => e.ModifiedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("modified_at");
            entity.Property(e => e.TotalBill).HasColumnName("total_bill");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Rooms).WithMany(p => p.Bookings)
                .UsingEntity<Dictionary<string, object>>(
                    "BookingRoomAssociation",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Booking>().WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("BookingId", "RoomId");
                        j.ToTable("Booking_Room_Association");
                    });
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("created_at");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.IsAc)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_ac");
            entity.Property(e => e.RoomType).HasColumnName("room_type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("lower(hex(randomblob(16)))")
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME")
                .HasColumnName("created_at");
            entity.Property(e => e.IdProof).HasColumnName("Id_Proof");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("NUMERIC")
                .HasColumnName("phone_Number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
