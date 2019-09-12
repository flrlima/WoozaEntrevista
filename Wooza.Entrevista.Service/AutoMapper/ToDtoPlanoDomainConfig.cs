using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wooza.Entrevista.Dominio.Entidades;
using Wooza.Entrevista.Service.Dto;

namespace Wooza.Entrevista.Service.AutoMapper
{
    public class ToDtoPlanoDomainConfig : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToDtoMappings";
            }
        }
        protected override void Configure()
        {
            CreateMap<Plano, PlanoDto>();
        }
    }
}