using Microsoft.EntityFrameworkCore;
using RandevuTakip.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RandevuTakip.DAL.Concrete.EfCore
{
    public class EfGenericRepository<T> : IDalGenericRepository<T> where T : class
    {
        private readonly AppointmentDbContext context;
        private DbSet<T> entities;

        public EfGenericRepository(AppointmentDbContext _context)
        {
            context = _context;
        }

        public DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }


        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Null entity");
                }
                this.Entities.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Null empty");
                }

                this.Entities.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                var entity = FindById(id);
                if (entity == null)
                {
                    throw new ArgumentNullException("Null Entity");
                }

                this.Entities.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate).AsQueryable<T>();
        }

        public T FindById(int id)
        {
            return this.Entities.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.Entities.AsQueryable<T>();
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Null Empty");
                }
                this.context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
