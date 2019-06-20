using SpaUserControl.Domain.Models;
using System;

namespace SpaUserControl.Domain.Contracts.Services
{
    public interface IUserService : IDisposable
    {
        User Authenticate(string email, string password);

        User GetByEmail(string email);

        void Register(string nome, string email, string password, string confirmPassword);

        void ChangeInformation(string email, string nome);

        void ChangePassword(string email, string password, string newPassword, string confirmNewPassword);

        string ResetPassword(string email);
    }
}
