using Ecommerce.BLL.Dtos;
using Ecommerce.BLL.IServices;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.IRepositaries;
using Ecommerce.DAL.Repositaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public void AddUser(AddUserDto userDto)
        {
            User user = new User
            {
                FirstName= userDto.FirstName,
                LastName= userDto.LastName,
                Email=userDto.email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.password) 

            };
            
            _userRepo.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }

        public IEnumerable<GetUserDto> GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();

            return users.Select(u => new GetUserDto
            {
                Id = u.Id,          
                Fullname = u.FirstName + " " + u.LastName,
                Email = u.Email
            }).ToList();
        }

        public GetUserDto GetUserByEmail(string email)
        {
            var user=  _userRepo.GetUserByEmail(email);
            if (user == null)
                throw new Exception("User Can’t be found ");

            GetUserDto res = new GetUserDto
            {
                Fullname=user.FirstName+" "+user.LastName,
                Email=user.Email
            };
            return res;
        }

        public void saveuserdata()
        {
            _userRepo.Savechanges();
        }

        public void UpdateUser(string email, string newFirstName, string newLastName)
        {
          
            var user = _userRepo.GetUserByEmail(email);

            user.FirstName = newFirstName;
            user.LastName = newLastName;
     
        }
    }
}
