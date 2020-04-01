using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista(); // listar todos os produtos do banco
            ViewBag.Produtos = produtos; // colocar a lista de produtos na ViewBag
            return View(); // camada de visualização
        }

        public ActionResult Form()
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();
            ViewBag.Categorias = categorias;
            ViewBag.Produto = new Produto();
            return View();
        }

        [HttpPost] // requisições enviadas do method post, deixa de exibir info na url o method post
        public ActionResult Adicionar(Produto produto)
        {
            int idDaInformatica = 1;
            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.Invalido", "Informatica com preco abaixo de 100 reais");
            }
            if (produto.Preco < 0)
            {
                ModelState.AddModelError("produto.Preco", "Preço inválido!");
            }
            if (ModelState.IsValid)// modelo obedece as regras de validação
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index", "Produto"); // redirecionado para Index da View Produto
            }
            else
            {
                ViewBag.Produto = produto;
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                return View("Form"); // retorna para o formulário
            }
        }
    }
}