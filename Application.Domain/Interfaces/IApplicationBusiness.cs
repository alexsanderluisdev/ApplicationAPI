using System.Collections.Generic;

namespace Application.Domain.Interfaces
{
    public interface IApplicationBusiness
    {
        public List<Models.Application.Application> List();
        public Models.Application.Application Get(int Id);
        public Models.Application.Application Update(Models.Application.Application application);
        public Models.Application.Application Add(Models.Application.Application application);
        public bool Delete(int Id);
    }
}
