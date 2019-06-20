using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Ux.Mvc.Account.Models;
using System;
using System.Web.Mvc;

namespace SpaUserControl.Ux.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _service;

        #region Ctor
        public AccountController(IUserService service)
        {
            _service = service;
        }

        #endregion

        public ActionResult Register()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Register(RegisterUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _service.Register(model.Nome, model.Email, model.Password, model.ConfirmPassword);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", ex.Message);
                return View(model); 
            }
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
