using MvcAnalisisArchivos.Models.DAO;
using MvcAnalisisArchivos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAnalisisArchivos.Controllers
{
    public class AtmController : Controller
    {
        private UserDAO userDAO = new UserDAO();

        private AtmParameterDAO atmDAO = new AtmParameterDAO();

        // GET: Atm
        public ActionResult Index()
        {
            return View();
        }

        // GET: Atm/Details/5
        public ActionResult Details(int id)
        {
            UserLiveCycleDTO userLiveCycleDTO = new UserLiveCycleDTO();
            userLiveCycleDTO.Session = 1;
            userLiveCycleDTO.User = userDAO.ReadUser(id);
            userLiveCycleDTO.Atm = atmDAO.GetAtmParameter();
            return View(userLiveCycleDTO);
        }

        // GET: Atm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atm/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Atm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Atm/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Atm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Atm/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
