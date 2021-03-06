﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSC_T.BusinessLayer.DAL
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All();
        Task<IEnumerable<T>> AllAsync();
        T Find(Func<T, bool> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Func<T, bool> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Attach(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
