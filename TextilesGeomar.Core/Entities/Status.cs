using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
