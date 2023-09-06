using System;
using System.Collections.Generic;

namespace Entities.Catalogs;

public partial class Tblpuesto
{
    public int PuestoId { get; set; }

    public string Puesto { get; set; }

    public int? DepartamentoId { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaAlta { get; set; }

    public virtual Tbldepartamento Departamento { get; set; }

    public virtual ICollection<Tblempleado> Tblempleados { get; set; } = new List<Tblempleado>();    

    public string GetDepartamento =>
        DepartamentoId > 0 && Departamento != null
        ? $"{Departamento.Departamento}"
        : string.Empty;
}
