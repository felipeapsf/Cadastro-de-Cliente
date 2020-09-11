using Projeto.Data.Context;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        //atributo
        private readonly DataContext context;

        //construtor para injeção de dependência
        public ClienteRepository(DataContext context) : base(context) //contrutor da superclasse
        {
            this.context = context;
        }
    }
}
