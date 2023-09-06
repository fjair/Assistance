using System;
using System.Collections.Generic;
using Entities.Control;

namespace Entities.Catalogs;

public partial class Tblestatushorario
{
    public int EstatusHorarioId { get; set; }

    public string EstatusHorario { get; set; }

    public virtual ICollection<Tblregistro> TblregistroEstatusHorarioEntrada { get; set; } = new List<Tblregistro>();

    public virtual ICollection<Tblregistro> TblregistroEstatusHorarioSalida { get; set; } = new List<Tblregistro>();
}
