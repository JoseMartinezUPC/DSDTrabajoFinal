using Dapper;
using Infraestructure.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Infraestructure.Repository
{
    public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(string connectionString) : base(connectionString)
        {

        }

        public async Task<TipoDocumentoPaginationViewModel> GetPagination(TipoDocumentoPaginationFilterViewModel filter)
        {
            var pagination = new TipoDocumentoPaginationViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@Start", filter.Start, DbType.Int32);
                param.Add("@Rows", filter.Rows, DbType.Int32);

                param.Add("@Records", 1, DbType.Int32, ParameterDirection.InputOutput);
                param.Add("@Total", 1, DbType.Int32, ParameterDirection.InputOutput);

                pagination.Data = await connection.QueryAsync<TipoDocumentoViewModel>(@"[dbo].[Usp_Get_TipoDocumento_Pagination]", param, commandType: CommandType.StoredProcedure);
                pagination.RecordsFiltered = param.Get<int>("@Records");
                pagination.RecordsTotal = param.Get<int>("@Total");
            }
            return pagination;
        }
    }
}
