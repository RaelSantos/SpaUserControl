using System;

namespace SpaUserControl.Ux.Mvc.Account.Models
{
    public class RegisterUserModel
    {
        public String Nome { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public String ConfirmPassword { get; set; }
    }
}