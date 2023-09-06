using System;
using System.Collections.Generic;

namespace Entities.Catalogs;

public partial class Tblturno
{
    public int TurnoId { get; set; }

    public string Turno { get; set; }

    public TimeSpan? HoraInicial { get; set; }

    public TimeSpan? HoraFinal { get; set; }

    public int? MtoleracianI { get; set; }

    public int? MtoleranciaF { get; set; }

    public int? Anio { get; set; }

    public DateTime? FechaAlta { get; set; }

    public virtual ICollection<Tblempleado> Tblempleados { get; set; } = new List<Tblempleado>();

    public string GetTolerancia => $"{MtoleracianI} Minutos";
}
