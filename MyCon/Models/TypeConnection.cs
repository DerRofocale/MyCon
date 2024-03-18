using System;
using System.Collections.Generic;

namespace MyCon.Models;

public partial class TypeConnection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Connection> Connections { get; set; } = new List<Connection>();
}
