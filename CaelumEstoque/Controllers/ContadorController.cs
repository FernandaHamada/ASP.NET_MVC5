using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            // contador de acesso a página
            object valorNaSession = Session["contador"];     //Session é um IDictionary <string, object>
            int contador = Convert.ToInt32(valorNaSession);
            contador++;
            Session["contador"] = contador;
            return View(contador);
        }
    }
}