using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class Item
{
    public int ItemId { get; set; }

    public int? UniformId { get; set; }

    public int? InstitutionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public string? FabricType { get; set; }

    public decimal Price { get; set; }

    public virtual Institution? Institution { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();

    public virtual Uniform? Uniform { get; set; }

    public virtual ICollection<UniformItem> UniformItems { get; set; } = new List<UniformItem>();
}
