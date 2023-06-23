using CarRentalManagementSystemAPI.Services.AuthenticationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _user;

        public UserAuthController(IUserAuthService user)
        {
            _user = user;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<int>> Register(NewUserRegisterVM newUserVM)
        {
            CreatePasswordHash(newUserVM.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new UserAuth()
            {
                EmailId = newUserVM.EmailId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var result = await _user.Register(user);

            if(result ==  0) {
                return NotFound("User already exists");
            }
            return Ok(result);
        }


        [HttpPost("Login")]

        public async Task<ActionResult<string>> Login(UserLoginVM userLoginVM)
        {
            CreatePasswordHash(userLoginVM.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new UserAuth()
            {
                EmailId = userLoginVM.EmailId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var result = await _user.Login(user, userLoginVM.Password);

            if (result.Equals("User not found.") || result.Equals("Wrong Password."))
            {
                return NotFound();
            }
            return Ok(result);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
