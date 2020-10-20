using System;
using System.Collections.Generic;

namespace Application.Repository
{
    public class ApplicationRepository : Domain.Interfaces.IApplicationRepository
    {
        public List<Models.Application.Application> List()
        {
            throw new NotImplementedException();
        }
        public Models.Application.Application Get(int Id)
        {
            throw new NotImplementedException();
        }
        public Models.Application.Application Update(Models.Application.Application application)
        {
            throw new NotImplementedException();
        }
        public Models.Application.Application Add(Models.Application.Application application)
        {
            return application;
        }
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
