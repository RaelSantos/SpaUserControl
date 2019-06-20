using System;

namespace SpaUserControl.Api.Models
{
    public class RegisterUserModel
    {
        public String Nome { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public String ConfirmPassword { get; set; }
    }
}