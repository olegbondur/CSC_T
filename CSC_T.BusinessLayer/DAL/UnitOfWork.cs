using CSC_T.BusinessLayer.DAL.Repositories;
using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
       
        private readonly CSCDbContext _dataContext;

        public UnitOfWork(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
        }



        public IRepository<Organization> OrganizationRepository
        {
            get { return new OrganizationRepository(_dataContext); }
        }

        public IRepository<Country> CountryRepository
        {
            get { return new CountryRepository(_dataContext); }
        }
        public IRepository<Business> BusinessRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<Department> FamilyRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
