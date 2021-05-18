using crud_dnf.Data;
using crud_dnf.DTOs;
using crud_dnf.ModelBinders;
using crud_dnf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace crud_dnf.Repositories
{
    interface IUserRepository
    {
        IQueryable<UserDto> GetUsers();
        UserDto GetUserDetails(int? id);
        void UserCreate(CreateUser user);
        void UserEdit(int id, EditUser user);
        void UserDelete(int id);

    }
}
