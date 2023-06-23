using Microsoft.Exchange.WebServices.Data;
using System.Security.Claims;

namespace CarRentalManagementSystemAPI.Services.AuthenticationService
{
    public class UserAuthService : IUserAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserAuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Login(UserAuth user, string password)
        {
            var u = await _context.UserAuths.FirstOrDefaultAsync(
                x => x.EmailId.ToLower().Equals(user.EmailId));

            if (u == null)
                return "User not found.";

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return "Wrong Password.";
            }

            return CreateToken(user);
        }

        public async Task<int> Register(UserAuth user)
        {
            /*
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var u = new UserAuth{
                EmailId = user.EmailId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };*/

            if (await UserExists(user.EmailId))
            {
                return 0;
            }

            _context.UserAuths.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UserExists(string emailId)
        {
            if(await _context.UserAuths.AnyAsync(u => u.EmailId.ToLower() == emailId.ToLower()))
                return true;

            return false;
        }

        /*
        private void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));  
            }
        }*/

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        
        private string CreateToken(UserAuth user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.EmailId)
            };

            //var appSettingsToken = 

            return " ";
        }
    }
}
