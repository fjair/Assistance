using System;
using System.Collections.Generic;
using Entities.Catalogs;

namespace Entities.Control;

public partial class Tblregistro
{
    public int RegistroId { get; set; }

    public DateTime FechaEntrada { get; set; }

    public DateTime? FechaSalida { get; set; }

    public int? EmpleadoId { get; set; }

    public int? ZonaEntradaId { get; set; }

    public int? ZonaSalidaId { get; set; }

    public int? EstatusHorarioEntradaId { get; set; }

    public int? EstatusHorarioSalidaId { get; set; }

    public virtual Tblempleado Empleado { get; set; }

    public virtual Tblestatushorario EstatusHorarioEntrada { get; set; }

    public virtual Tblestatushorario EstatusHorarioSalida { get; set; }

    public virtual Tblzona ZonaEntrada { get; set; }

    public virtual Tblzona ZonaSalida { get; set; }
    
    public string GetEmployeeName =>
        EmpleadoId > 0 && Empleado != null
        ? $"{Empleado.GetFullName}"
        : string.Empty;

    public string GetEmployeeJob =>
        EmpleadoId > 0 && Empleado != null
        ? $"{Empleado.GetJob}"
        : string.Empty;

    public string GetEMployeeShift =>
        EmpleadoId > 0 && Empleado != null
        ? $"{Empleado.GetShift}"
        : string.Empty;

    public string GetEmployeeDepartment =>
        EmpleadoId > 0 && Empleado != null
        ? $"{Empleado.GetDepartament}"
        : string.Empty;
    
    public string GetInputZone =>
        ZonaEntradaId > 0 && ZonaEntradaId != null
        ? $"{ZonaEntrada.Zona}"
        : string.Empty;
    
    public string GetOutputZone =>
        ZonaSalidaId > 0 && ZonaSalidaId != null
        ? $"{ZonaEntrada.Zona}"
        : string.Empty;
    
    public string GetInputStatus =>
       EstatusHorarioEntrada != null
        ? $"{EstatusHorarioEntrada.EstatusHorario}"
        : string.Empty;
    
    public string GetOutputStatus =>
       EstatusHorarioSalida != null
        ? $"{EstatusHorarioSalida.EstatusHorario}"
        : string.Empty;
}
