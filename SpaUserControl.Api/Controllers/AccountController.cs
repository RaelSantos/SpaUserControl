using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SpaUserControl.Api.Models;
using SpaUserControl.Commom.Validation.Resources;
using SpaUserControl.Domain.Contracts.Services;

namespace SpaUserControl.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IUserService _service;

        #region Ctor
        public AccountController(IUserService service)
        {
            _service = service;
        }
        #endregion

        /* // api/account - Post
           [Route("")]
           [HttpPost]
           public RegisterUserModel Register(RegisterUserModel model)
           {
               try
               {
                   _service.Register(model.Nome, model.Email, model.Password, model.ConfirmPassword);
                   model.Password = "";
                   model.ConfirmPassword = "";
                   return model;
               }
               catch { return null; }

           }*/
        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Register(RegisterUserModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Register(model.Nome, model.Email, model.Password, model.ConfirmPassword);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome, email = model.Email });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        /* // api/account - Put
           [Route("")]
           [HttpPut]
           [Authorize]
           public void ChangeInformation(ChangeInformationModel model)
           {
               _service.ChangeInformation(User.Identity.Name, model.Nome);
           }*/           
        [Authorize]
        [HttpPut]
        [Route("")]
        public Task<HttpResponseMessage> Put(ChangeInformationModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangeInformation(User.Identity.Name, model.Nome);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        /*  // api/account - Post
            [Route("changepassword")]
            [HttpPost]
            [Authorize]
            public void ChangePassword(ChangePasswordModel model)
            {
                _service.ChangePassword(User.Identity.Name, model.Password, model.NewPassword, model.ConfirmNewPassword);
            }*/
        [Authorize]
        [HttpPost]
        [Route("changepassword")]
        public Task<HttpResponseMessage> ChangePassword(ChangePasswordModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangePassword(User.Identity.Name, model.Password, model.NewPassword, model.ConfirmNewPassword);
                response = Request.CreateResponse(HttpStatusCode.OK, Messages.PasswordSuccessfulyChanges);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("resetpassword")]
        public Task<HttpResponseMessage> ResetPassword(ResetPasswordModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var password = _service.ResetPassword(model.Email);
                response = Request.CreateResponse(HttpStatusCode.OK, String.Format(Messages.ResetPasswordEmailBody, password));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}
 