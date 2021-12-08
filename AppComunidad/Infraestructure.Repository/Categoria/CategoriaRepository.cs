﻿using Dapper;
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
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(string connectionString) : base(connectionString)
        {

        }
        public async Task<CategoriaPaginationViewModel> GetPagination(CategoriaPaginationFilterViewModel filter)
        {
            var pagination = new CategoriaPaginationViewModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@Start", filter.Start, DbType.Int32);
                param.Add("@Rows", filter.Rows, DbType.Int32);

                param.Add("@Records", 1, DbType.Int32, ParameterDirection.InputOutput);
                param.Add("@Total", 1, DbType.Int32, ParameterDirection.InputOutput);

                pagination.Data = await connection.QueryAsync<CategoriaViewModel>(@"[dbo].[Usp_Get_Categoria_Pagination]", param, commandType: CommandType.StoredProcedure);
                pagination.RecordsFiltered = param.Get<int>("@Records");
                pagination.RecordsTotal = param.Get<int>("@Total");
            }
            return pagination;
        }
    }
}
