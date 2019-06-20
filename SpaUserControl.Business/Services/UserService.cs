using SpaUserControl.Commom.Validation;
using SpaUserControl.Commom.Validation.Resources;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Models;
using System;

namespace SpaUserControl.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        #region Ctor
        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        #endregion

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);

            if (user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(Errors.InvalidCredentials);

            return user;
        }

        public void ChangeInformation(string email, string nome)
        {
            var user = GetByEmail(email);

            user.ChangeName(nome);
            user.Validate();

            _repository.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);

            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _repository.Update(user);

        }   

        public User GetByEmail(string email)
        {
            var user = _repository.Get(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public void Register(string nome, string email, string password, string confirmPassword)
        {
            var hasUser = _repository.Get(email);
            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            var user = new User(nome, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public string ResetPassword(string email)
        {
            var user = GetByEmail(email);
            var password = user.ResetPassword();
            user.Validate();

            _repository.Update(user);
            return password;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

       
    }
}
