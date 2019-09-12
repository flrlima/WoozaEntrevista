using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wooza.Entrevista.Dominio.Enum
{
    public enum TipoPlanoEnum
    {
        [Description("Controle")]
        Controle,
        [Description("Pós-Pago")]
        Pos,
        [Description("Pré-Pago")]
        Pre
    }
}
