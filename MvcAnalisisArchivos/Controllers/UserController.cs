using MvcAnalisisArchivos.Models.DAO;
using MvcAnalisisArchivos.Models.DTO;
using System.Web.Mvc;

namespace MvcAnalisisArchivos.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userDAO = new UserDAO();

        // GET: User
        public ActionResult Index()
        {
            return View(userDAO.ReadUsers());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(userDAO.ReadUser(id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Perform any additional validation or business logic here
                    // For example, check if the email is unique before creating a new user

                    // Create the user
                    string response = userDAO.CreateUser(user);

                    if (response == "Success")
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Failed to create user. Please try again.");
                }

                return View(user);
            }
            catch
            {
                return View(user);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(userDAO.ReadUser(id));
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
                    string response = userDAO.UpdateUser(id, user);

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
                string response = userDAO.DeleteUser(id);

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
