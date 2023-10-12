using System;
using System.Collections.Generic;

namespace Entities.Catalogs;

public partial class Tbldepartamento
{
    public int DepartamentoId { get; set; }

    public string Departamento { get; set; }

    public string Abreviatura { get; set; }    

    public bool? Activo { get; set; } = true;

    public DateTime? FechaAlta { get; set; } = DateTime.Now;

    public virtual ICollection<Tblpuesto> Tblpuestos { get; set; } = new List<Tblpuesto>();
}
