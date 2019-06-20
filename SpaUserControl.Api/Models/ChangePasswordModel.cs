using System;

namespace SpaUserControl.Api.Models
{
    public class ChangePasswordModel
    {
        public String Password { get; set; }
        public String NewPassword { get; set; }
        public String ConfirmNewPassword { get; set; }
    }
}