using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int? UniformItemId { get; set; }

    public int? ItemId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual UniformItem? UniformItem { get; set; }
}
