using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Application.Repository
{
    public class ApplicationRepository : Domain.Interfaces.IApplicationRepository
    {
        private string _connectionString;
        public ApplicationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public ApplicationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Models.Application.Application> List()
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                return conexao.Query<Models.Application.Application>(
                    "SELECT * FROM Application ORDER BY ApplicationId ASC").ToList();
            }
        }

        public Models.Application.Application Get(int Id)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                return conexao.QueryFirstOrDefault<Models.Application.Application>(
                    "SELECT * FROM Application WHERE ApplicationId = @Id", new { Id });
            }
        }

        public Models.Application.Application Update(Models.Application.Application application)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                conexao.Execute(
                    "UPDATE Application SET Url = @Url, PathLocal = @PathLocal, DebuggingMode = @DebuggingMode WHERE ApplicationId = @ApplicationId", application);
            }

            return application;
        }

        public Models.Application.Application Add(Models.Application.Application application)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                conexao.Execute(
                    "INSERT INTO Application VALUES (@ApplicationId, @Url, @PathLocal, @DebuggingMode)", application);
            }

            return application;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                conexao.Execute(
                    "DELETE FROM Application WHERE ApplicationId = @Id", new { Id });
            }

            return true;
        }
    }
}
