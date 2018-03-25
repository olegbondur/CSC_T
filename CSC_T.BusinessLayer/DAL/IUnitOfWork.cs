using CSC_T.BusinessLayer.Entities;
using System;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Organization> OrganizationRepository { get; }
        IRepository<Country> CountryRepository { get;  }
        IRepository<Business> BusinessRepository { get; }
        IRepository<Family> FamilyRepository { get;  }
        IRepository<Offering> OfferingRepository { get;  }
        IRepository<Department> DepartmentRepository { get;  }
        IRepository<CountryBusiness> CountryBusinessRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
