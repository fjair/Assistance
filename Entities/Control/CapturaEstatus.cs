using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Control
{
    public enum CapturaEstatus
    {
        NO_EXISTE = 0,
        ACCESO_DENEGADO = 1,
        ACCESO = 2,
        ENTRADA = 3,
        SALIDA = 4,
        JORNADA_COMPLETA = 5,
        ERROR_API = 6,
        TOLERANCIA = 7,
        TARDE = 8
    }
}
