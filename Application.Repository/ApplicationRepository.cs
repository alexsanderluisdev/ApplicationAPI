using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Linq;

namespace Application.Repository
{
    public class ApplicationRepository : Domain.Interfaces.IApplicationRepository
    {
        private string _connectionString;
        public ApplicationRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
                    "SELECT E.SiglaEstado, E.NomeEstado, E.NomeCapital, " +
                           "R.NomeRegiao " +
                    "FROM dbo.Estados E " +
                    "INNER JOIN dbo.Regioes R ON R.IdRegiao = E.IdRegiao " +
                    "ORDER BY E.NomeEstado").ToList();
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
                    "UPDATE Application SET Url = @Url, PathLocal = @PathLocal, DebuggingMode = @DebuggingMode WHERE ApplicationId = @Id", application);
            }

            return application;
        }
        public Models.Application.Application Add(Models.Application.Application application)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                conexao.Execute(
                    "INSERT INTO Application VALUES (@Id, @Url, @PathLocal, @DebuggingMode)", application);
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
