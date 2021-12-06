using Dapper;
using Domain.Entities;
using Infraestructure.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(string connectionString) : base(connectionString)
        {

        }

        public async Task<UsuarioViewModel> GetAcceso(UsuarioPaginationFilterViewModel filter)
        {
            var usuario = new UsuarioViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@Login", filter.Login, DbType.String);
                param.Add("@Password", filter.Password, DbType.String);
                param.Add("@Resultado", 1, DbType.Boolean, ParameterDirection.InputOutput);

                await connection.QueryAsync<UsuarioViewModel>(@"[dbo].[Usp_Get_Usuario_Acceso]", param, commandType: CommandType.StoredProcedure);
                usuario.Acceso = param.Get<Boolean>("@Resultado");
            }
            return usuario;
        }

    }
}
