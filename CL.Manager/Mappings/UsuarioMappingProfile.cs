using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CL.Core.Domains;
using CL.CoreShared.ModelViews.Usuario;

namespace CL.Manager.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioView>().ReverseMap();
            // CreateMap<Usuario, NovoUsuario>().ReverseMap();
            // CreateMap<Usuario, UsuarioLogado>().ReverseMap();
            // CreateMap<Funcao, FuncaoView>().ReverseMap();
            // CreateMap<Funcao, ReferenciaFuncao>().ReverseMap();
        }
    }
}