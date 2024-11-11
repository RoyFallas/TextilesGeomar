using System;
using System.Collections.Generic;

namespace TextilesGeomar.API.Models;

public partial class PriceHistory
{
    public int PriceHistoryId { get; set; }

    public int? ItemId { get; set; }

    public int? UniformId { get; set; }

    public decimal Price { get; set; }

    public string? PriceChangeReason { get; set; }

    public DateTime ChangeDate { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Uniform? Uniform { get; set; }
}
