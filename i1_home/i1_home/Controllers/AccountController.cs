using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using i1.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using i1.DbMethods;
using i1.Service;
using i1_home.Models;
using System.Security.Cryptography;
using System.Text;

namespace i1.Controllers
{
    public class AccountController : Controller
    {
        UserMethods uM = new UserMethods();
        //
        // GET: /Account/LogOn
        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            model.UserName = model.UserName.ToLower();
            if (ModelState.IsValid)
            {
                string Fname = uM.GetUserNameByFirstName(model.UserName);
                
                //get the username
                string UserName = model.Password;

                //create the MD5CryptoServiceProvider object we will use to encrypt the password
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                //create an array of bytes we will use to store the encrypted password
                Byte[] hashedBytes;
                //Create a UTF8Encoding object we will use to convert our password string to a byte array
                UTF8Encoding encoder = new UTF8Encoding();

                //encrypt the password and store it in the hashedBytes byte array
                hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(model.Password));
                model.Password = hashedBytes.ToString();

                //if (Membership.ValidateUser(null, model.Password))
                //{
                    
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        Session["uid"] = model.UserName;
                        TempData["userid"] = model.UserName;
                        TempData.Keep();                 //Data will not be lost for all Keys
                        TempData.Keep("userid");
                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        string viewStr = uM.LogOnCon(model);
                        return RedirectToAction("Index", viewStr, model);
                    }
                //}
                //else
                //{
                //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            Loc locService = new Loc();
            RegisterModel model = new RegisterModel();
            List<SelectListItem> listcountries = new List<SelectListItem>();
            List<country> countries = new List<country>();
            countries = locService.GetCountryListFromDB();
            listcountries.Add(new SelectListItem { Text = "Select", Value = "Select", Selected = true });
            foreach (country item in countries)
            {
                listcountries.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
            }

            model.listcountries = listcountries;
            return View(model);
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model, string temp, string temp2, string cities)
        {
            // temp = country; temp2 = state; cities = city

            model.Country = temp;
            model.State = temp2;
            model.City = cities;
            model.FirstName = model.FirstName.ToLower();
            
            
            //get the username
            string UserName = model.Password;

            //create the MD5CryptoServiceProvider object we will use to encrypt the password
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;
            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();

            //encrypt the password and store it in the hashedBytes byte array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(model.Password));
            model.Password = hashedBytes.ToString();

            // Attempt to register the user
                MembershipCreateStatus createStatus;
                //var viewStr2 = uM.Register(model);
                //string Fname = uM.GetUserNameByFirstName(model.FirstName);
                //Membership.CreateUser(Fname, model.Password, model.Email, null, null, true, null, out createStatus);

                createStatus = MembershipCreateStatus.Success;

                if (createStatus == MembershipCreateStatus.Success)
                {
                    //FormsAuthentication.SetAuthCookie(model.FirstName, false /* createPersistentCookie */);
                    var viewStr = uM.Register(model);
                    LogOnModel lmodel = new LogOnModel();
                    lmodel.UserName = uM.GetLoginId(viewStr[0]);
                    lmodel.Password = String.Empty;
                    lmodel.RememberMe = false;
                    if (viewStr[1]=="Register")
                    {
                        return View(viewStr[1], model);   
                    }
                    else
                    {
                        return View(viewStr[1], lmodel);   
                    }
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }

            // If we got this far, something failed, redisplay form
            Loc locService = new Loc();
            model = new RegisterModel();
            List<SelectListItem> listcountries = new List<SelectListItem>();
            List<country> countries = new List<country>();
            countries = locService.GetCountryListFromDB();
            listcountries.Add(new SelectListItem { Text = "Select", Value = "Select", Selected = true });
            foreach (country item in countries)
            {
                listcountries.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
            }

            model.listcountries = listcountries;
            return View(model);
        }

        #region PassChange
        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        
        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
        #endregion

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

        public ActionResult GetCityListFromDB(string stateid)
        {
            Loc locService = new Loc();
            List<string> cityList = new List<string>();
            cityList = locService.GetCityListFromDB(Convert.ToInt32(stateid));
            return Json(new { CityList = cityList });
        }

        public ActionResult GetStateListFromDB(string countryid)
        {
            Loc locService = new Loc();
            List<state> stateList = new List<state>();
            List<string> s1 = new List<string>();
            List<int> s2 = new List<int>();
            s1 = locService.GetStateListFromDB(int.Parse(countryid));
            s2 = locService.GetStateListIdFromDB(int.Parse(countryid));

            int i = 0;
            foreach (int item in s2)
            {
                stateList.Add(new state { name = s1[i], id = s2[i] });
                i++;
                if (i == s2.Count)
                {
                    break;
                }
            }

            return Json(new { StateList = stateList });
        }


        public ActionResult RegisterSuccess()
        {
            LogOnModel r = new LogOnModel();
            r.UserName = "BC";
            return View(r);
        }

        //public ActionResult UserEdit()
        //{
        //    Register r = new Re
        //    return View(r);
        //}
    }
}