using Microsoft.EntityFrameworkCore;
using System;

namespace CSC_T.BusinessLayer.DAL
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly Action<DbContextOptionsBuilder> _sqlServerOptionsAction;

        public UnitOfWorkFactory(Action<DbContextOptionsBuilder> sqlServerOptionsAction)
        {
            _sqlServerOptionsAction = sqlServerOptionsAction;
        }

        public IUnitOfWork Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            _sqlServerOptionsAction?.Invoke(optionsBuilder);
            return new UnitOfWork(new CSCDbContext(optionsBuilder.Options));
        }
    }
}
