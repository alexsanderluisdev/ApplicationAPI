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
        public List<Models.Application.Application> List()
        {
            return _applicationRepository.List();
        }
        public Models.Application.Application Get(int Id)
        {
            return _applicationRepository.Get(Id);
        }
        public Models.Application.Application Update(Models.Application.Application application)
        {
            return _applicationRepository.Update(application);
        }
        public Models.Application.Application Add(Models.Application.Application application)
        {
            return _applicationRepository.Add(application);
        }
        public bool Delete(int Id)
        {
            return _applicationRepository.Delete(Id);
        }
    }
}
