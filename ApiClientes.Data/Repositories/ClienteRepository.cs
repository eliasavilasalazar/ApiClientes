using ApiClientes.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Data.Repositories
{
    public class ClienteRepository : ClientesRepository
    {
        private readonly SqlConfiguration _connectionString;
        public ClienteRepository(SqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<ClientesCo>> GetAllClientes()
        {
            string sql = "SELECT Cliente, Empresa, Titulo, Puesto, Ejecutivo, Comentario, email, telefono, Fase, Direccion FROM [COTIZADOR].[vCRM]";
            using (var db = dbConnection())
            {
                try
                {
                    return await db.QueryAsync<ClientesCo>(sql);
                }
                catch (Exception ex)
                {
                    // Maneja la excepción, imprímela en la consola o realiza un registro de errores.
                    Console.WriteLine("Error en GetAllClientes: " + ex.Message);
                    throw; // O maneja la excepción según corresponda.
                }
            }
        }
        public async Task<ClientesCo> GetClientes(string Cliente)
        {
            string sql = @"SELECT Cliente, Empresa, Titulo, Puesto, Ejecutivo, Comentario, email, telefono, Fase, Direccion FROM [COTIZADOR].[vCRM] WHERE Cliente = @Cliente";
            using (var db = dbConnection())
            {
                try
                {
                    return await db.QueryFirstOrDefaultAsync<ClientesCo>(sql, new { Cliente });
                }
                catch (Exception ex)
                {
                    // Maneja la excepción, imprímela en la consola o realiza un registro de errores.
                    Console.WriteLine("Error en GetClientes: " + ex.Message);
                    throw; // O maneja la excepción según corresponda.
                }
            }
        }
    }
}
