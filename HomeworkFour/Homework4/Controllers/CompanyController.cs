using Homework4.Business.Abstracts;
using Homework4.Business.DTOs;
using Homework4.Domain.Entities;
using Homework4.Filters;
using Homework4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Homework4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        [Route("Log")]
        [Log]
        public IActionResult Log()
        {
            return NoContent();
        }

        /// <summary>
        /// Method is used to get all companies.
        /// </summary>
        /// <returns>ResponseModel</returns>
        [Route("Companies")]
        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyService.GetAll().Select(x => new CompanyDTO
            {
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Location = x.Location,
                Phone = x.Phone
            });
            return Ok(new ResponseModel { Data = companies, Success = true});
        }

        /// <summary>
        /// Add a company to database...
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ResponseModel</returns>
        [Route("AddCompany")]
        [HttpPost]
        public IActionResult Add([FromBody] CompanyDTO model)
        {
            companyService.Add(new Company
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
            return Ok(new ResponseModel { Data = "New company successfuly added.", Success = true});
        }

        [Route("DeleteCompany")]
        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteCompanyDTO deleteCompanyDTO)
        {
            companyService.Delete(new Company
            {
                Name = deleteCompanyDTO.Name.ToUpper(),
                Address = deleteCompanyDTO.Address,
                City = deleteCompanyDTO.City

            });
            return Ok(new ResponseModel { Data = $"Company {deleteCompanyDTO.Name} is successfuly deleted.", Success = true});
        }

        [Route("UpdateCompany")]
        [HttpPut]
        public IActionResult Update([FromBody] CompanyDTO companyDTO)
        {
            companyService.Update(new Company
            {
                Name = companyDTO.Name.ToUpper(),
                Description=companyDTO.Description,
                Address=companyDTO.Address,
                City=companyDTO.City,
                Country=companyDTO.Country,
                Location=companyDTO.Location,
                Phone=companyDTO.Phone,
                LastUpdatedBy = "Not Murat",
                LastUpdatedAt = DateTime.Now
            });
            return Ok(new ResponseModel { Data = $"Company {companyDTO.Name} is successfuly updated.", Success = true });
        }
    }
}
