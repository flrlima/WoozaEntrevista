using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Service.Dto;

namespace Wooza.Entrevista.Service.AutoMapper
{
    public class DomainToDtoPlanoConfig : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DtoToDomainMappings";
            }
        }
        protected override void Configure()
        {
            CreateMap<PlanoDto, Plano>()
                .ForMember(para => para.PlanoId, de => de.MapFrom(p => p.PlanoDtoId))
                .ForMember(para => para.CodigoDoPlano, de => de.MapFrom(p => p.CodigoDoPlano))
                .ForMember(para => para.Minuto, de => de.MapFrom(p => p.Minuto))
                .ForMember(para => para.FranquiaDeInternet, de => de.MapFrom(p => p.FranquiaDeInternet))
                .ForMember(para => para.Valor, de => de.MapFrom(p => p.Valor))
                .ForMember(para => para.Tipo, de => de.MapFrom(p => p.Tipo))
                .ForMember(para => para.Operadora, de => de.MapFrom(p => p.Operadora))
                .ForMember(para => para.Ddds, de => de.MapFrom(p => p.DddDigito));
                
        }
    }
}