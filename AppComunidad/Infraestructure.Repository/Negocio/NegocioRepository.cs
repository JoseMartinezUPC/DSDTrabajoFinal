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
    public class NegocioRepository : GenericRepository<Negocio>, INegocioRepository
    {
        public NegocioRepository(string connectionString) : base(connectionString)
        {

        }

        public async Task<NegocioPaginationViewModel> NegocioUsuarioId(NegocioPaginationFilterViewModel filter)
        {
            var pagination = new NegocioPaginationViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@IdUsuario", filter.UsuarioId, DbType.Int32);

                pagination.Data = await connection.QueryAsync<NegocioViewModel>(@"[dbo].[Usp_Get_Negocio_UsuarioId]", param, commandType: CommandType.StoredProcedure);
            }
            return pagination;

        }

        public async Task<NegocioPaginationViewModel> NegocioCategoriasUsuarioId(NegocioPaginationFilterViewModel filter)
        {
            var pagination = new NegocioPaginationViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@IdUsuario", filter.UsuarioId, DbType.Int32);

                pagination.Data = await connection.QueryAsync<NegocioViewModel>(@"[dbo].[Usp_Get_Negocio_Categorias_UsuarioId]", param, commandType: CommandType.StoredProcedure);
            }
            return pagination;

        }

        public async Task<NegocioPaginationViewModel> NegocioRedesUsuarioId(NegocioPaginationFilterViewModel filter)
        {
            var pagination = new NegocioPaginationViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@IdUsuario", filter.UsuarioId, DbType.Int32);

                pagination.Data = await connection.QueryAsync<NegocioViewModel>(@"[dbo].[Usp_Get_Negocio_Redes_UsuarioId]", param, commandType: CommandType.StoredProcedure);
            }
            return pagination;

        }


    }
}
