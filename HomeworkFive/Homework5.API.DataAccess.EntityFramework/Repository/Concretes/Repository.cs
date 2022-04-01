using Homework5.API.DataAccess.EntityFramework.Repository.Abstracts;
using Homework5.API.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Homework5.API.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return _unitOfWork.Context.Set<T>().AsQueryable();
            return _unitOfWork.Context.Set<T>().Where(filter).AsQueryable();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _unitOfWork.Context.Set<T>().SingleOrDefault(filter);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
