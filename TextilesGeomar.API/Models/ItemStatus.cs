using System;
using System.Collections.Generic;

namespace TextilesGeomar.API.Models;

public partial class ItemStatus
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
