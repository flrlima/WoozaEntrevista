using AutoMapper;

namespace Wooza.Entrevista.Service.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(p =>
            {
                p.AddProfile<DomainToDtoDddConfig>();
                p.AddProfile<ToDtoDddDomainConfig>();
                p.AddProfile<DomainToDtoPlanoConfig>();
                p.AddProfile<ToDtoPlanoDomainConfig>();
            });
        }
    }
}