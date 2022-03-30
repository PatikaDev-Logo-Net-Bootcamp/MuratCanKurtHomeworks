using Homework4.Business.DTOs;
using System.Collections.Generic;

namespace Homework4.Business.Abstracts
{
    public interface ICompanyService
    {
        List<CompanyDTO> GetAll();
        void Add(CompanyDTO company);
        void Update(CompanyDTO company);
        void Delete(int companyId);

    }
}
