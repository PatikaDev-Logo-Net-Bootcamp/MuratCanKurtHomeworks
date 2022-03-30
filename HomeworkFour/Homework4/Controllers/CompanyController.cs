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
            var companies = companyService.GetAll();
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
            companyService.Add(model);
            return Ok(new ResponseModel { Data = "New company successfuly added.", Success = true});
        }

        [Route("DeleteCompany")]
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            companyService.Delete(Id);
            return Ok(new ResponseModel { Data = $"Company with id {Id} is successfuly deleted.", Success = true});
        }

        [Route("UpdateCompany")]
        [HttpPut]
        public IActionResult Update([FromBody] CompanyDTO companyDTO)
        {
            companyService.Update(companyDTO);
            return Ok(new ResponseModel { Data = $"Company {companyDTO.Name} is successfuly updated.", Success = true });
        }
    }
}
