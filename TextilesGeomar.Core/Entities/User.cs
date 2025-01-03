﻿using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; } = null!;
}
