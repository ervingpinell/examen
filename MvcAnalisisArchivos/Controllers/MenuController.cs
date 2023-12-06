using MvcAnalisisArchivos.Models.DAO;
using MvcAnalisisArchivos.Models.DTO;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace MvcAnalisisArchivos.Controllers
{
    public class MenuController : Controller
    {
        private AtmParameterDAO atmDAO = new AtmParameterDAO();
        private UserDTO userDTO = new UserDTO();
        private UserDAO userDAO = new UserDAO();
        private UserLiveCycleDTO liveSession = new UserLiveCycleDTO();
 

        // GET: Menu
        public ActionResult mainMenu(UserLiveCycleDTO liveSession)
        {
            UserLiveCycleDTO session = TempData["liveSession"] as UserLiveCycleDTO;
            return View(session);
        }
        public ActionResult showBalance(UserLiveCycleDTO liveSession)
        {
            UserLiveCycleDTO session = TempData["liveSession"] as UserLiveCycleDTO;

            return View(session);
        }

        public ActionResult withdrawMoney(UserLiveCycleDTO liveSession)
        {
            UserLiveCycleDTO session = TempData["liveSession"] as UserLiveCycleDTO;

            return View(session);
        }
        // POST: menu/withDraw
        [HttpPost]
        public ActionResult withdrawMoney(int mount, UserLiveCycleDTO liveSession, UserDAO userDAO, UserDTO userDTO)
        {
            UserLiveCycleDTO session = TempData["liveSession"] as UserLiveCycleDTO;
            
            int amount = 0;
            userDTO = session.User;
            while (userDTO.Balance > 0)
            {
                if (userDTO.Balance > amount)
                {
                    userDTO.Balance = userDTO.Balance - amount;
                    
                    userDAO.UpdateUser(userDTO.Balance, userDTO);

                    Console.WriteLine("Haz hecho un retiro de: " + amount + "\nSaldo en cuenta: " + userDTO.Balance);

                    session.User = userDTO;
                    return View(session);
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente");

                }

            }
            return View(session);
        }

        public ActionResult exit()
        {

            return View();
        }

        public ActionResult logIn()
        {
            return View();
        }

        
        // POST: menu/LogIn
        [HttpPost]
        public ActionResult logIn(string email, string code)
        {
            try
            {
                userDTO = userDAO.ReadUser(email);

                if (userDTO.VerifyCode(code, userDTO.Code))
                {

                    liveSession.User = userDTO;
                    liveSession.Atm = atmDAO.ReadAtm(1);
                    liveSession.Session = 1;
                    liveSession.Id = 1;
                    TempData["liveSession"] = liveSession;
                    return View("mainMenu",liveSession);

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
