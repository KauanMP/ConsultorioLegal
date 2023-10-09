using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CL.Core.Domains;
using CL.CoreShared.ModelViews;

namespace CL.Manager.Mappings
{
    public class NovoclienteMappingProfile : Profile
    {
        public NovoclienteMappingProfile()
        {
            CreateMap<NovoCliente, Cliente>()
            .ForMember(d => d.Criacao, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

            CreateMap<NovoEndereco, Endereco>();
        }
    }
}