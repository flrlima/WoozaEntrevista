using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wooza.Entrevista.Dominio.Enum
{
    public enum OperadoraEnum
    {
        [Description("Claro")]
        Claro,
        [Description("Vivo")]
        Vivo,
        [Description("Nextel")]
        Nextel,
        [Description("Oi")]
        Oi,
        [Description("Tim")]
        Tim
    }
}
