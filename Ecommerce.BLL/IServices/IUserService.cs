using Ecommerce.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.IServices
{
    public interface IUserService
    {
        IEnumerable<GetUserDto> GetAllUsers();
        GetUserDto GetUserByEmail(string email);
        void AddUser(AddUserDto userDto);
        void DeleteUser(int id);

        void UpdateUser(string email, string newFirstName, string newLastName);

        void saveuserdata();
    }
}
