using SpaUserControl.Commom.Validation;
using SpaUserControl.Commom.Validation.Resources;
using System;

namespace SpaUserControl.Domain.Models
{
    public class User
    {
        #region Ctor

        // Ctor para o EntityFramework
        protected User() { }

        public User(string nome, string email)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Email = email;
            
        }

        #endregion

        #region Propriedades

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        #endregion

        #region Métodos 

        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, Errors.InvalidPassword);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, Errors.InvalidPasswordConfirmation);
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, Errors.PasswordDoNotMatch);
            AssertionConcern.AssertArgumentLength(password, 6, 20, Errors.InvalidPasswordNumberChraracters);

            this.Password = PasswordAssertionConcern.Encrypt(password);
        }

        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = PasswordAssertionConcern.Encrypt(password);

            return password;
        }

        public void ChangeName(string nome)
        {
            this.Nome = nome;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 60, Errors.InvalidUserName);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Password);
        }

        #endregion 
    }
}
