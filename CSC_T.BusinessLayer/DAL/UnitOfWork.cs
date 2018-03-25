using CSC_T.BusinessLayer.DAL.Repositories;
using CSC_T.BusinessLayer.Entities;
using System;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
       
        private readonly CSCDbContext _dataContext;

        private UserRepository userRepository;

        public UnitOfWork(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IRepository<User> UserRepository
        {
           get { return new UserRepository(_dataContext); }
        }
        public IRepository<Organization> OrganizationRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Country> CountryRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Business> BusinessRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Family> FamilyRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Offering> OfferingRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Department> DepartmentRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<CountryBusiness> CountryBusinessRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
