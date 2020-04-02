using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(String login, String senha)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario usuario = dao.Busca(login, senha);
            // usuário existente
            if (usuario != null){
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Produto"); // retorna para Lista de produtos
            }
            else
            {
                return RedirectToAction("Index"); // caso não exista, retorna para a página de login novamente
            }
        }
    }
}