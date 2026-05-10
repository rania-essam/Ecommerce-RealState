using Ecommerce.BLL.IServices;
using ECommerce.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.BLL.Dtos;
namespace ECommerce.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        // add user

        [HttpGet]  
        public IActionResult AddUser()
        {
            return View(); 
        }

        [HttpPost] 

        public IActionResult AddUser(AddUserDto addUserDto)
        {

            if (!ModelState.IsValid)
                return View(addUserDto); 

            _userService.AddUser(addUserDto);
            _userService.saveuserdata();
            return RedirectToAction("ShowAll");
        }

        //show user
        [HttpGet]
        public IActionResult GetUser(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
                return null;
            return View(user);
        }

        // update user

        [HttpGet]
        public IActionResult UpdateUser(string email)
        {
            var user = _userService.GetUserByEmail(email); 
            return View(user); 
        }

        [HttpPost]
        public IActionResult UpdateUser(string email, string newFirstName, string newLastName)
        {
             _userService.UpdateUser(email,newFirstName,newLastName);
             _userService.saveuserdata();

            return RedirectToAction("ShowAll");

        }

        // delete user 


        // GET — shows the confirmation page
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var users = _userService.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            var vm = new User
            {
                ID = user.Id,
                UserName = user.Fullname,
                UserEmail = user.Email
            };

            return View(vm);
        }


        // POST — actually deletes
        [HttpPost, ActionName("DeleteUser")]
        public IActionResult DeleteUserConfirmed(int id)
        {
            _userService.DeleteUser(id);
            _userService.saveuserdata();
            return RedirectToAction("ShowAll");
        }




        // show all users


        // /user/showall

        [HttpGet]
        public IActionResult ShowAll()
        {
            var users = _userService.GetAllUsers();

            var result = users.Select(u => new User
            {
                ID = u.Id,  
                UserEmail = u.Email,
                UserName = u.Fullname
            });

            return View(result);
        }

    }
}
