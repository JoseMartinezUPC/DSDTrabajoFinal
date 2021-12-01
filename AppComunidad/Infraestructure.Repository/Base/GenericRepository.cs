using Crosscuting.Common;
using Crosscuting.Messages;
using Domain.Core;
using Domain.Entities.Base;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected string _connectionString;
        public GenericRepository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"[{ type.Name }]"; };
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> result;
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.GetAllAsync<T>();
            }
            return result.Where(m => m.Activo).ToArray();
        }

        public async Task<T> GetByID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var model = await connection.GetAsync<T>(id);
                if (model == null)
                    throw new GuiaException(MensajesError.ItemNotFound);
                return model;
            }
        }

        public async Task<int> Add(T entity)
        {
            var result = default(int);
            using (var connection = new SqlConnection(_connectionString))
            {
                entity.UsuarioRegistro = "admin";
                entity.FechaRegistro = Extension.GetDate();
                entity.UsuarioModifica = "admin";
                entity.FechaModifica = Extension.GetDate();
                result =  await connection.InsertAsync(entity);
            }
            return result;
        }

        public async Task<int> AddDefaultAsync(T entity)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                return await cn.InsertAsync(entity);
            }
        }

        public async Task<bool> Update(T entity)
        {
            var result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                var model = await connection.GetAsync<T>(entity.Id);
                if (model == null)
                    throw new GuiaException(MensajesError.ItemNotFound);
                entity.UsuarioRegistro = model.UsuarioRegistro;
                entity.FechaRegistro = model.FechaRegistro;
                entity.UsuarioModifica = "admin";
                entity.FechaModifica = Extension.GetDate();
                result = await connection.UpdateAsync(entity);
            }
            return result;
        }

        public async Task<bool> UpdateDefaultAsync(T entity)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                return await cn.UpdateAsync(entity);
            }
        }

        public async Task<bool> Delete(T entity)
        {
            var result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                var model = await connection.GetAsync<T>(entity.Id);
                if (model == null)
                    throw new GuiaException(MensajesError.ItemNotFound);
                model.Activo = false;
                model.UsuarioModifica = "admin";
                model.FechaModifica = Extension.GetDate();
                result = await connection.UpdateAsync(model);
            }
            return result;
        }

    }
}
