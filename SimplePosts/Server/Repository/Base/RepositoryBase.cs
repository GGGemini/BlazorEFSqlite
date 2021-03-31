using Microsoft.EntityFrameworkCore;
using SimplePosts.Server.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplePosts.Server.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        readonly ApplicationDbContext _context;
        readonly DbSet<T> _dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (!_dbSet.Contains(entity))
            {
                throw new Exception("Такой сущности не существует");
            }

            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);

            if (!_dbSet.Contains(entity))
            {
                throw new Exception("Такой сущности не существует");
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
