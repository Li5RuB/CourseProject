using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    public class CollectionController : Controller
    {
        public CollectionController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
