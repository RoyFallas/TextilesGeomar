using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Entities;

public partial class UniformStatus
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Uniform> Uniforms { get; set; } = new List<Uniform>();
}
