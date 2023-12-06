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

namespace MvcAnalisisArchivos.Controllers
{
    public class MenuController : Controller
    {
         UserDAO userDAO = new UserDAO();
        AtmParameterDAO atmDAO = new AtmParameterDAO();
        UserLiveCycleDTO liveSession;

        // GET: Menu
        public ActionResult mainMenu (string session)
        {
            string safetyDecodedObject = WebUtility.UrlDecode(session);
            var liveSession = JsonConvert.DeserializeObject<UserLiveCycleDTO>(safetyDecodedObject);
            return View(liveSession);
        }
        public ActionResult showBalance(UserLiveCycleDTO liveSession)
        {
            return View(liveSession);
        }

        public ActionResult withdrawMoney(UserLiveCycleDTO liveSession)
        {
            return View(liveSession);
        }

        public ActionResult exit()
        {
            return View();
        }
    }
    }
