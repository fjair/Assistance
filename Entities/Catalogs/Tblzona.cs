using System;
using System.Collections.Generic;
using Entities.Control;

namespace Entities.Catalogs;

public partial class Tblzona
{
    public int ZonaId { get; set; }

    public string Zona { get; set; }

    public DateTime? FechaAlta { get; set; }

    public virtual ICollection<Tblregistro> TblregistroZonaEntrada { get; set; } = new List<Tblregistro>();

    public virtual ICollection<Tblregistro> TblregistroZonaSalida { get; set; } = new List<Tblregistro>();
}
