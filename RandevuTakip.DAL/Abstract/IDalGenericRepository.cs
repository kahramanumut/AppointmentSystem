using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RandevuTakip.DAL.Abstract
{
    public interface IDalGenericRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        void Add(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        void Update(T entity);
    }
}
