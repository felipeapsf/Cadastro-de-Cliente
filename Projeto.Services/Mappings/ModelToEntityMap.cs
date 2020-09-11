using AutoMapper;
using Projeto.Data.Entities;
using Projeto.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Services.Mappings
{
    public class ModelToEntityMap : Profile
    {
        //ctor
        public ModelToEntityMap()
        {
            CreateMap<ClienteCadastroModel, Cliente>();
            CreateMap<ClienteEdicaoModel, Cliente>();
        }
    }
}
