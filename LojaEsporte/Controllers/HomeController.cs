using LojaEsporte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using LojaEsporte.Metodos;

namespace LojaEsporte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }

    }
}
