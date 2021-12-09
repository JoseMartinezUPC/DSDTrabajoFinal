using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class NegocioRepository : GenericRepository<Negocio>, INegocioRepository
    {
        public NegocioRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
