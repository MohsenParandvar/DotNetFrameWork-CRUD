using crud_dnf.Data;
using crud_dnf.DTOs;
using crud_dnf.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using crud_dnf.Models;
using System.Threading.Tasks;
using crud_dnf.ModelBinders;
using System.Data;
using System.Data.Entity;


namespace crud_dnf.Services
{
    public class UserRepository : IUserRepository
    {
        private crud_dnfContext _context = new crud_dnfContext();
        public IQueryable<UserDto> GetUsers()
        {
            var users = from u in _context.Users
                        select new UserDto()
                        {
                            ID = u.ID,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            UserName = u.UserName
                        };
            return users;
        }
        public UserDto GetUserDetails(int? id)
        {
            UserDto user = (from u in _context.Users
                            where u.ID == id
                            select new UserDto()
                            {
                                ID = u.ID,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                UserName = u.UserName
                            }).FirstOrDefault();
            return user;
        }
        public void UserCreate(CreateUser user)
        {
            var InsertUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                EmailPass = user.EmailPass
            };
            _context.Users.Add(InsertUser);
            _context.SaveChanges();
        }
        public void UserEdit(int id,EditUser user)
        {
            var EditUser = new User()
            {
                ID = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                EmailPass = user.EmailPass
            };
            _context.Entry(EditUser).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void UserDelete(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}