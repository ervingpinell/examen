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
        private AtmParameterDAO atmParameterDAO = new AtmParameterDAO();

        // GET: User
        public ActionResult Index()
        {
            return View(atmParameterDAO.ReadAtms());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(atmParameterDAO.ReadAtm(id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(AtmParameterDTO atm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Perform any additional validation or business logic here
                    // For example, check if the email is unique before creating a new user

                    // Create the user
                    string response = atmParameterDAO.CreateAtm(atm);

                    if (response == "Success")
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Failed to create user. Please try again.");
                }

                return View(atm);
            }
            catch
            {
                return View(atm);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(atmParameterDAO.ReadAtm(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Perform any additional validation or business logic here

                    // Update the user
                    string response = atmParameterDAO.UpdateAtm(id, user);

                    if (response == "Success")
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Failed to update user. Please try again.");
                }

                return View(user);
            }
            catch
            {
                return View(user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // Delete the user
                string response = atmParameterDAO.DeleteAtm(id);

                if (response == "Success")
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Failed to delete user. Please try again.");

                return RedirectToAction("Index");
            }
            catch
            {
                // We have no a view here
                return View();
            }
        }
    }
}
