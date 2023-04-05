namespace BuberDinner.Application.Authentication;

public interface IAuthenticationServices
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}