using Homework4.Domain.Entities;
using System.Linq;

namespace Homework4.DataAccess.EntityFramework.Repository.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        public T GetById(int id);
    }
}
