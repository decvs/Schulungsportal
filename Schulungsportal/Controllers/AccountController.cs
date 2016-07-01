using Schulungsportal.Models;
using Schulungsportal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Schulungsportal.Util;
using Schulungsportal.Data;

namespace Schulungsportal.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Repository<Participant> _repository;
        private readonly Sha1Hasher _sha1Hasher;


        public AccountController()
        {
            this._repository = new Repository<Participant>();
            this._sha1Hasher = new Sha1Hasher();
        }
        //
        // GET: /Logon/
        [AllowAnonymous]
        public ActionResult Login()
        {
            var viewModel = new LoginUserViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogonUser(LoginUserViewModel viewModel)
        {
            if (viewModel != null)
            {
                if (ModelState.IsValid)
                {
                    var isValidUser = Membership.ValidateUser(viewModel.Name, viewModel.Password.ToString());
                    if (isValidUser == true)
                    {
                        FormsAuthentication.SetAuthCookie(viewModel.Name, viewModel.RememberMe);
                        return RedirectToAction("Index", "Participants");
                    }
                }
            }
            return RedirectToAction("Login");
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var viewModel = new RegisterUserViewModel();
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult RegisterUser(RegisterUserViewModel model)
        {
            var isModelValid = ModelState.IsValid;
            if (!isModelValid)
            {
                return View("Register", model);
            }
            if (isModelValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("Fehler","Passwort muss gleich Passwortbestätigung sein!");
                }
                var pwdHash = Sha1Hasher.Hash(model.Password.ToString());


                var part = new Participant
                {
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Username,
                    Company = model.Company,
                    Website = model.Website,
                    Password = pwdHash
                };

                this._repository.Insert(part);
               
            }

            return RedirectToAction("Login");
        }
    }
}