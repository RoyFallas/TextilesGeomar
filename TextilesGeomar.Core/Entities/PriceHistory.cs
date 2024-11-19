using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class PriceHistory
{
    public int PriceHistoryId { get; set; }

    public int ItemId { get; set; }

    public decimal Price { get; set; }

    public string? PriceChangeReason { get; set; }

    public DateTime ChangeDate { get; set; }

    public virtual Item Item { get; set; } = null!;
}
