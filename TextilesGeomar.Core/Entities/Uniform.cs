using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class Uniform
{
    public int UniformId { get; set; }

    public int? InstitutionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Institution? Institution { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();

    public virtual ICollection<UniformItem> UniformItems { get; set; } = new List<UniformItem>();
}
