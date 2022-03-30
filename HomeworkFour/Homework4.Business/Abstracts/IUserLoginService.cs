using Homework4.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.Business.Abstracts
{
    public interface IUserLoginService
    {
        bool CheckCredentials(UserDTO userDTO);
    }
}
