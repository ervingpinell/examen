using MvcAnalisisArchivos.Models.DAO;
using MvcAnalisisArchivos.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;



namespace MvcAnalisisArchivos.Controllers
{
    public class LoginController : Controller
    {
        private UserDTO userDTO = new UserDTO();
        private UserDAO userDAO = new UserDAO();
        AtmParameterDAO atm = new AtmParameterDAO();
        UserLiveCycleDTO currentUser = new UserLiveCycleDTO();
        // GET: Login
        public ActionResult logIn()
        {
            return View();
        }

        UserDTO user = new UserDTO();
        // POST: Login/Login
        [HttpPost]
        public ActionResult logIn(string email, string code)
        {
            try
            {
                userDTO = userDAO.ReadUser(email);
                
                if (userDTO.VerifyCode(code,userDTO.Code)){

                    currentUser.User = userDTO;
                    currentUser.Atm = atm.ReadAtm(1);
                    currentUser.Session = 1;
             
                    string codedObject = JsonConvert.SerializeObject(currentUser);
                    string safetyCodedObject = WebUtility.UrlEncode(codedObject);
                    return RedirectToAction("mainmenu", "menu", new {session = safetyCodedObject });
                
            }
            }
            catch
            {
                return View();
            }
            return View();
        }

            }
        }
    
