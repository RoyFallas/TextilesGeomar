using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public int? InstitutionId { get; set; }

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Institution? Institution { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
