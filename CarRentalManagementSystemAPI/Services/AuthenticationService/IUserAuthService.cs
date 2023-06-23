using CarRentalManagementSystemAPI.Migrations;

namespace CarRentalManagementSystemAPI.Services.AuthenticationService
{
    public interface IUserAuthService
    {
        Task<int> Register(UserAuth user);
        Task<string> Login(UserAuth user, string password);
        Task<bool> UserExists(string emailId);
    }
}
