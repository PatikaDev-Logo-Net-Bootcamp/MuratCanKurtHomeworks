using Homework4.Business.Abstracts;
using Homework4.DataAccess.EntityFramework.Repository.Abstracts;
using Homework4.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Homework4.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Company company)
        {
            repository.Add(company);
            unitOfWork.Commit();
        }

        public List<Company> GetAll()
        {
            return repository.Get().ToList();
        }

        public void Delete(Company company)
        {
            repository.Delete(company);
            unitOfWork.Commit();
        }

        public void Update(Company company)
        {
            repository.Update(company);
            unitOfWork.Commit();
        }
    }
}
