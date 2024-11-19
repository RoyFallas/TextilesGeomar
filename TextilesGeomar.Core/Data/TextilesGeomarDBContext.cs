using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Data;

public partial class TextilesGeomarDBContext : DbContext
{
    public TextilesGeomarDBContext()
    {
    }

    public TextilesGeomarDBContext(DbContextOptions<TextilesGeomarDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Institution> Institutions { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<NotificationHistory> NotificationHistories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=textilesGeomar; User Id=sa; Password=Textiles2024; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A24F68A0939");

            entity.ToTable("Client");

            entity.HasIndex(e => e.Email, "UQ__Client__A9D105343CECF709").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Institution).WithMany(p => p.Clients)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Client__Institut__412EB0B6");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.InstitutionId).HasName("PK__Institut__8DF6B6AD9D78D60F");

            entity.ToTable("Institution");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838B1AB3BA6F");

            entity.ToTable("Item");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FabricType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size).HasMaxLength(50);

            entity.HasOne(d => d.Institution).WithMany(p => p.Items)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Item__Institutio__46E78A0C");
        });

        modelBuilder.Entity<NotificationHistory>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E1205B668B0");

            entity.ToTable("NotificationHistory");

            entity.Property(e => e.EntityType).HasMaxLength(50);
            entity.Property(e => e.NotificationType).HasMaxLength(50);
            entity.Property(e => e.RecipientEmail).HasMaxLength(100);
            entity.Property(e => e.SentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SentStatus).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF666378C2");

            entity.ToTable("Order");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__ClientId__4CA06362");

            entity.HasOne(d => d.Institution).WithMany(p => p.Orders)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Order__Instituti__4D94879B");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__StatusId__4F7CD00D");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__UserId__4E88ABD4");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED0681D752FCD3");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__ItemI__5441852A");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__534D60F1");
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.HasKey(e => e.PriceHistoryId).HasName("PK__PriceHis__A927CACB2570E5A2");

            entity.ToTable("PriceHistory");

            entity.Property(e => e.ChangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceChangeReason).HasMaxLength(255);

            entity.HasOne(d => d.Item).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PriceHist__ItemI__5812160E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AE100F9E3");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ__Role__737584F6EEF1505A").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE206319D124FB");

            entity.ToTable("Status");

            entity.HasIndex(e => e.Name, "UQ__Status__737584F6F900A20A").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C9018020B");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534D98F385C").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
