using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class CategoriaDoProdutoController : Controller
    {
        // GET: CategoriaDoProduto
        public ActionResult Index()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista(); // listar todas as cotegorias do banco
            ViewBag.Categorias = categorias; // a ViewBag recebe a lista de categorias
            return View(); // camada de visualização
        }

        public ActionResult FormCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(CategoriaDoProduto categoriaDoProduto)
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            categoriasDAO.Adiciona(categoriaDoProduto);
            return RedirectToAction("Index", "CategoriaDoProduto");
        }


    }
}