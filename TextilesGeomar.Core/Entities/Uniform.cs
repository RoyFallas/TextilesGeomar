using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class Uniform
{
    public int UniformId { get; set; }

    public int? InstitutionId { get; set; }

    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Institution? Institution { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();

    public virtual UniformStatus Status { get; set; } = null!;
}
