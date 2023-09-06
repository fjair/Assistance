using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Entities.Control;

namespace Entities.Catalogs;

public partial class Tblempleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; }

    public string Paterno { get; set; }

    public string Materno { get; set; }

    public string Correo { get; set; }

    public int? PuestoId { get; set; }

    public int? TurnoId { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaAlta { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual Tbldepartamento Departamento { get; set; }

    public virtual Tblpuesto Puesto { get; set; }

    public virtual ICollection<Tblregistro> Tblregistros { get; set; } = new List<Tblregistro>();

    public virtual Tblturno Turno { get; set; }

    public string GetFullName => $"{Nombre} {Paterno} {Materno}";   

    public string GetDepartament => DepartamentoId < 0 || Departamento == null ? string.Empty : $"{Departamento.Departamento}";

    public string GetJob => PuestoId < 0 || Puesto == null ? string.Empty : $"{Puesto.Puesto}";

    public string GetShift => TurnoId < 0 || Turno == null ? string.Empty : $"{Turno.Turno}";
}
