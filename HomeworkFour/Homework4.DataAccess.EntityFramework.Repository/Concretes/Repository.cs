using Homework4.DataAccess.EntityFramework.Repository.Abstracts;
using Homework4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Homework4.DataAccess.EntityFramework.Repository.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            this.unitOfWork.Context.Set<T>().Add(entity);
            //unitOfWork.Context.Add(entity); //Same job but untrackable
        }

        public void Delete(T entity)
        {
            T exist = this.unitOfWork.Context.Set<T>().Find(entity.Id);
            if (exist != null)
            {
                exist.IsDeleted = true;
                this.unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public IQueryable<T> Get()
        {
            return this.unitOfWork.Context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }

        public void Update(T entity)
        {
            this.unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
