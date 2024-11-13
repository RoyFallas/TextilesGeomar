using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public int? UniformId { get; set; }

    public int StatusId { get; set; }

    public int? InstitutionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public string? FabricType { get; set; }

    public decimal Price { get; set; }

    public virtual Institution? Institution { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();

    public virtual ItemStatus Status { get; set; } = null!;

    public virtual Uniform? Uniform { get; set; }
}
