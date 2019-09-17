using System.Collections.Generic;
using Wooza.Entrevista.Dominio.Entidades;

namespace Wooza.Entrevista.Service.Dto
{
    public class DddDto
    {
        public string DddDigito { get; set; }
        public string DddEstadoSigla { get; set; }
        public string DddCidade { get; set; }

        public virtual ICollection<CodigoDoPlanoDto> CodigoDoPlanoDto { get; set; }

        public DddDto()
        {
            this.CodigoDoPlanoDto = new List<CodigoDoPlanoDto>();
        }

    }

    public class DddDtoDigito
    {
        public string DddDigito { get; set; }
    }
}
