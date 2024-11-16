using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class UniformItem
{
    public int UniformItemId { get; set; }

    public int UniformId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Uniform Uniform { get; set; } = null!;
}
