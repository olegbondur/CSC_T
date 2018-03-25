using CSC_T.BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CSC_T.BusinessLayer.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        protected readonly CSCDbContext _dataContext;
        protected readonly DbSet<User> _dataSet;

        public UserRepository(CSCDbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Users;
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> All()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<User>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public void Attach(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public User Find(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<User> FindAsync(System.Linq.Expressions.Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
