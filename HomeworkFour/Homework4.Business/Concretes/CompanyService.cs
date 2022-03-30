using Homework4.Business.Abstracts;
using Homework4.Business.DTOs;
using Homework4.DataAccess.EntityFramework.Repository.Abstracts;
using Homework4.Domain.Entities;
using System;
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

        public void Add(CompanyDTO model)
        {
            repository.Add(new Company
            {
                Name = model.Name.ToUpper(),
                Description = model.Description,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Location = model.Location,
                Phone = model.Phone,
                CreatedBy = "Murat",
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                LastUpdatedBy = "Murat"
            });
            unitOfWork.Commit();
        }

        public List<CompanyDTO> GetAll()
        {
            return repository.Get()
                .Select(x => new CompanyDTO
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Location = x.Location,
                Phone = x.Phone
            }).ToList();
        }

        public void Delete(int companyId)
        {
            repository.Delete(new Company {Id = companyId});
            unitOfWork.Commit();
        }

        public void Update(CompanyDTO companyDTO)
        {
            var exist = repository.GetById(companyDTO.Id);
            if (exist != null)
            {
                exist.Name = !string.IsNullOrEmpty(companyDTO.Name) ? companyDTO.Name.ToUpper() : exist.Name;
                exist.Description = !string.IsNullOrEmpty(companyDTO.Description) ? companyDTO.Description : exist.Description;
                exist.Address = !string.IsNullOrEmpty(companyDTO.Address) ? companyDTO.Address : exist.Address;
                exist.City = !string.IsNullOrEmpty(companyDTO.City) ? companyDTO.City : exist.City;
                exist.Country = !string.IsNullOrEmpty(companyDTO.Country) ? companyDTO.Country : exist.Country;
                exist.Location = !string.IsNullOrEmpty(companyDTO.Location) ? companyDTO.Location : exist.Location;
                exist.Phone = !string.IsNullOrEmpty(companyDTO.Phone) ? companyDTO.Phone : exist.Phone;
                exist.LastUpdatedBy = "Not Murat";
                exist.LastUpdatedAt = DateTime.Now;
            }
            repository.Update(exist);
            unitOfWork.Commit();
        }
    }
}
