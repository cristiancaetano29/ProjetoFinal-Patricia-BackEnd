using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBackEnd.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Inicio(){
            return new ContentResult{
                ContentType = "text/html",
                Content = "<h1>Api Da Biblioteca Funcionando!!!</h1>"
            };
        }
    }
}