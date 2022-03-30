using Homework4.Business.Abstracts;
using Homework4.Business.DTOs;
using Homework4.DataAccess.EntityFramework.Repository.Abstracts;
using Homework4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.Business.Concretes
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IRepository<UserLogin> repository;
        private readonly IUnitOfWork unitOfWork;


        public UserLoginService(IRepository<UserLogin> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }


        public bool CheckCredentials(UserDTO userDTO)
        {
            var user = repository.Get().SingleOrDefault(x => x.UserName == userDTO.UserName && x.Password == userDTO.Password);
            if (user == null)
                return false;
            return true;
        }
    }
}
