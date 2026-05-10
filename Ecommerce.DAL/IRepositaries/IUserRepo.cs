using Ecommerce.DAL.Entities;
using System;
using System.Text;

namespace Ecommerce.DAL.IRepositaries
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByEmail(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

        void Savechanges();
    }
}
