using System;
using System.Collections.Generic;

namespace MyCon.Models;

public partial class Connection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TypeConntecionId { get; set; }

    public int? OrganizationId { get; set; }

    public string Ip { get; set; } = null!;

    public string? Login { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual TypeConnection? TypeConntecion { get; set; }
}
