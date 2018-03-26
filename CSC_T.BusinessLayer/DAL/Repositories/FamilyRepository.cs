using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL.Repositories
{
    public class FamilyRepository : IRepository<Department>
    {
        protected readonly CSCDbContext _dataContext;
        protected readonly DbSet<Department> _dataSet;

        public FamilyRepository(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Families;
        }

        public void Add(Department entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<Department> entities)
        {
            _dataSet.AddRange(entities);
        }

        public IEnumerable<Department> All()
        {
            return _dataSet.ToList();
        }

        public async Task<IEnumerable<Department>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public void Attach(Department entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Department entity)
        {
            _dataSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<Department> entities)
        {
            _dataSet.RemoveRange(entities);
        }

        public Department Find(Func<Department, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }

        public IEnumerable<Department> FindAll(Func<Department, bool> predicate)
        {
            return _dataSet.ToList();
        }

        public async Task<Department> FindAsync(Expression<Func<Department, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }

    }
}
