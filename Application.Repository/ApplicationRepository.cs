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

        /// <summary>
        /// Lista todas as aplicações.
        /// </summary>
        /// <returns>Uma lista com as aplicações populadas nos objetos.</returns>
        public List<Models.Application.Application> List()
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                return conexao.Query<Models.Application.Application>(
                    "SELECT * FROM Application ORDER BY ApplicationId ASC").ToList();
            }
        }

        /// <summary>
        /// Obtém uma aplicação com base no id informado.
        /// </summary>
        /// <param name="Id">Id da aplicação para ser retornada.</param>
        /// <returns>Objeto populado com as informações da aplicação.</returns>
        public Models.Application.Application Get(int Id)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                return conexao.QueryFirstOrDefault<Models.Application.Application>(
                    "SELECT * FROM Application WHERE ApplicationId = @Id", new { Id });
            }
        }

        /// <summary>
        /// Atualiza as informações de uma aplicação.
        /// </summary>
        /// <param name="application">Objeto com as informações da aplicação para ser atualizada.</param>
        /// <returns>Objeto com as informações da aplicação atualizada.</returns>
        public Models.Application.Application Update(Models.Application.Application application)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                conexao.Execute(
                    "UPDATE Application SET Url = @Url, PathLocal = @PathLocal, DebuggingMode = @DebuggingMode WHERE ApplicationId = @ApplicationId", application);
            }

            return application;
        }

        /// <summary>
        /// Adiciona uma aplicação na base de dados.
        /// </summary>
        /// <param name="application">Objeto com as informações da aplicação a ser inserida.</param>
        /// <returns>Objeto com as informações da aplicação inserida.</returns>
        public Models.Application.Application Add(Models.Application.Application application)
        {
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                conexao.Execute(
                    "INSERT INTO Application VALUES (@ApplicationId, @Url, @PathLocal, @DebuggingMode)", application);
            }

            return application;
        }

        /// <summary>
        /// Remove uma aplicação da base de dados.
        /// </summary>
        /// <param name="Id">Id da aplicação a ser removida.</param>
        /// <returns>Retorna true em caso de sucesso.</returns>
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
