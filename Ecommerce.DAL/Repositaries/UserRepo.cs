using Ecommerce.DAL.Entities;
using Ecommerce.DAL.IRepositaries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Ecommerce.DAL.Repositaries
{
    public class UserRepo:IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users
            .ToList();
        }


        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
           
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
             
            }
            else
            {
                throw new Exception("User not Found ");
            }
        }

        public void Savechanges()
        {
            _context.SaveChanges();
        }
    }
}
