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

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Uniform> Uniforms { get; set; }

    public virtual DbSet<UniformItem> UniformItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=textilesGeomar; User Id=sa; Password=Textiles2024; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A24C4B4C72E");

            entity.ToTable("Client");

            entity.HasIndex(e => e.Email, "UQ__Client__A9D10534348C397B").IsUnique();

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
            entity.HasKey(e => e.InstitutionId).HasName("PK__Institut__8DF6B6AD4165F61C");

            entity.ToTable("Institution");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838BE6865916");

            entity.ToTable("Item");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FabricType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size).HasMaxLength(50);

            entity.HasOne(d => d.Institution).WithMany(p => p.Items)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Item__Institutio__4AB81AF0");

            entity.HasOne(d => d.Uniform).WithMany(p => p.Items)
                .HasForeignKey(d => d.UniformId)
                .HasConstraintName("FK__Item__UniformId__49C3F6B7");
        });

        modelBuilder.Entity<NotificationHistory>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E123E343459");

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
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFB5912441");

            entity.ToTable("Order");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__ClientId__5441852A");

            entity.HasOne(d => d.Institution).WithMany(p => p.Orders)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Order__Instituti__5535A963");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__StatusId__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__UserId__5629CD9C");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36C142C03F0");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Item).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__OrderDeta__ItemI__5DCAEF64");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__5BE2A6F2");

            entity.HasOne(d => d.UniformItem).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.UniformItemId)
                .HasConstraintName("FK__OrderDeta__Unifo__5CD6CB2B");
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.HasKey(e => e.PriceHistoryId).HasName("PK__PriceHis__A927CACB38393A34");

            entity.ToTable("PriceHistory");

            entity.Property(e => e.ChangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceChangeReason).HasMaxLength(255);

            entity.HasOne(d => d.Item).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__PriceHist__ItemI__619B8048");

            entity.HasOne(d => d.Uniform).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.UniformId)
                .HasConstraintName("FK__PriceHist__Unifo__628FA481");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AF279E833");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ__Role__737584F6F3C24C52").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE2063C9CC6F78");

            entity.ToTable("Status");

            entity.HasIndex(e => e.Name, "UQ__Status__737584F68F12754D").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Uniform>(entity =>
        {
            entity.HasKey(e => e.UniformId).HasName("PK__Uniform__FF513A500CDBD25C");

            entity.ToTable("Uniform");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Institution).WithMany(p => p.Uniforms)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Uniform__Institu__46E78A0C");
        });

        modelBuilder.Entity<UniformItem>(entity =>
        {
            entity.HasKey(e => e.UniformItemId).HasName("PK__UniformI__CEF736A319CBB45E");

            entity.HasIndex(e => new { e.UniformId, e.ItemId }, "UC_UniformItem").IsUnique();

            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Item).WithMany(p => p.UniformItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UniformIt__ItemI__5070F446");

            entity.HasOne(d => d.Uniform).WithMany(p => p.UniformItems)
                .HasForeignKey(d => d.UniformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UniformIt__Unifo__4F7CD00D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CB767E513");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D105342665B3E4").IsUnique();

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
