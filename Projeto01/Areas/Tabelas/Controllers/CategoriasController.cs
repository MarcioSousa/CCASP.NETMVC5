using Modelo.Tabelas;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Areas.Tabelas.Controllers
{
    //[Authorize]
    public class CategoriasController : Controller
    {
        private readonly CategoriaServico categoriaServico = new CategoriaServico();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            //PopularViewBag();
            return View();
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            //PopularViewBag(categoriaServico.ObterCategoriaPorId((long)id));
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria  " + categoria.Nome.ToUpper() + " foi removido.";
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        //private void PopularViewBag(Categoria categoria = null)
        //{
        //    if (categoria == null)
        //    {
        //        ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome");
        //        ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadasPorNome(), "FabricanteId", "Nome");
        //    }
        //    else
        //    {
        //        ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome", produto.CategoriaId);
        //        ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricantesClassificadasPorNome(), "FabricanteId", "Nome", produto.FabricanteId);
        //    }
        //}

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }

    }
}