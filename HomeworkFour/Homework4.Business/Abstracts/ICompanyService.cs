using Homework4.Domain.Entities;
using System.Collections.Generic;

namespace Homework4.Business.Abstracts
{
    public interface ICompanyService
    {
        List<Company> GetAll();
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);

    }
}
