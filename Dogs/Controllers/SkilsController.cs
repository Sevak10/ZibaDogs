using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dogs.Controllers
{
    public class SkilsController : Controller
    {
        public ViewResult DogsFacts()
        {
            return View();
        }

        public ViewResult DogsInformation()
        {
            return View();
        }

        public ViewResult DogsPictures(SignIn sign)
        {
            HelpDogs.DogsHelp dogsHelp = new HelpDogs.DogsHelp();
            
            List<object> lst = new List<object>();

            lst.Add(dogsHelp.DogHMail());
            lst.Add(dogsHelp.DogHName());
            lst.Add(dogsHelp.DogHPhone());
            lst.Add(dogsHelp.DogHText());
            return View(sign);
        }

        public ViewResult Training()
        {
            return View();
        }

        public ViewResult Health()
        {
            return View();
        }

        public ViewResult Assistans()
        {
            return View();
        }
    }
}