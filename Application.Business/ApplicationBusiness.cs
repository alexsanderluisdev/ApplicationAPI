using Application.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Business
{
    public class ApplicationBusiness : IApplicationBusiness
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationBusiness(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        /// <summary>
        /// Lista todas as aplicações.
        /// </summary>
        /// <returns>Uma lista com as aplicações populadas nos objetos.</returns>
        public List<Models.Application.Application> List()
        {
            return _applicationRepository.List();
        }

        /// <summary>
        /// Obtém uma aplicação com base no id informado.
        /// </summary>
        /// <param name="Id">Id da aplicação para ser retornada.</param>
        /// <returns>Objeto populado com as informações da aplicação.</returns>
        public Models.Application.Application Get(int Id)
        {
            return _applicationRepository.Get(Id);
        }

        /// <summary>
        /// Atualiza as informações de uma aplicação.
        /// </summary>
        /// <param name="application">Objeto com as informações da aplicação para ser atualizada.</param>
        /// <returns>Objeto com as informações da aplicação atualizada.</returns>
        public Models.Application.Application Update(Models.Application.Application application)
        {
            return _applicationRepository.Update(application);
        }

        /// <summary>
        /// Adiciona uma aplicação na base de dados.
        /// </summary>
        /// <param name="application">Objeto com as informações da aplicação a ser inserida.</param>
        /// <returns>Objeto com as informações da aplicação inserida.</returns>
        public Models.Application.Application Add(Models.Application.Application application)
        {
            return _applicationRepository.Add(application);
        }

        /// <summary>
        /// Remove uma aplicação da base de dados.
        /// </summary>
        /// <param name="Id">Id da aplicação a ser removida.</param>
        /// <returns>Retorna true em caso de sucesso.</returns>
        public bool Delete(int Id)
        {
            return _applicationRepository.Delete(Id);
        }
    }
}
