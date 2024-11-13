using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Models;

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

    public virtual DbSet<ItemStatus> ItemStatuses { get; set; }

    public virtual DbSet<NotificationHistory> NotificationHistories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Uniform> Uniforms { get; set; }

    public virtual DbSet<UniformStatus> UniformStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=textilesGeomar; User Id=sa; Password=Textiles2024; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A246B49395D");

            entity.HasIndex(e => e.Email, "UQ__Clients__A9D105343A4CFB9B").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Institution).WithMany(p => p.Clients)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Clients__Institu__412EB0B6");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.InstitutionId).HasName("PK__Institut__8DF6B6ADFFD918DB");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__727E838BEAA695AD");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FabricType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size).HasMaxLength(50);

            entity.HasOne(d => d.Institution).WithMany(p => p.Items)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Items__Instituti__4F7CD00D");

            entity.HasOne(d => d.Status).WithMany(p => p.Items)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Items__StatusId__4E88ABD4");

            entity.HasOne(d => d.Uniform).WithMany(p => p.Items)
                .HasForeignKey(d => d.UniformId)
                .HasConstraintName("FK__Items__UniformId__4D94879B");
        });

        modelBuilder.Entity<ItemStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ItemStat__C8EE206303C231D9");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<NotificationHistory>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E121E9F724C");

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
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF87942B29");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__ClientId__5535A963");

            entity.HasOne(d => d.Institution).WithMany(p => p.Orders)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Orders__Institut__5629CD9C");

            entity.HasOne(d => d.Item).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Orders__ItemId__534D60F1");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__StatusId__571DF1D5");

            entity.HasOne(d => d.Uniform).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UniformId)
                .HasConstraintName("FK__Orders__UniformI__5441852A");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__OrderSta__C8EE2063514BE48B");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.HasKey(e => e.PriceHistoryId).HasName("PK__PriceHis__A927CACBA2636365");

            entity.Property(e => e.ChangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceChangeReason).HasMaxLength(255);

            entity.HasOne(d => d.Item).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__PriceHist__ItemI__5AEE82B9");

            entity.HasOne(d => d.Uniform).WithMany(p => p.PriceHistories)
                .HasForeignKey(d => d.UniformId)
                .HasConstraintName("FK__PriceHist__Unifo__5BE2A6F2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A3BC06CB1");

            entity.HasIndex(e => e.Name, "UQ__Roles__737584F6ECD4A9BF").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Uniform>(entity =>
        {
            entity.HasKey(e => e.UniformId).HasName("PK__Uniforms__FF513A5000D69BB8");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Institution).WithMany(p => p.Uniforms)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Uniforms__Instit__49C3F6B7");

            entity.HasOne(d => d.Status).WithMany(p => p.Uniforms)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Uniforms__Status__4AB81AF0");
        });

        modelBuilder.Entity<UniformStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__UniformS__C8EE2063CF99C4C6");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C1B3A9721");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534DEF7D8E4").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
