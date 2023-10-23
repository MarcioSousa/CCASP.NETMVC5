using Modelo.Cadastros;
using Servico.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto01.Areas.Cadastros.Controllers
{
    //[Authorize(Roles = "Administradores")]
    //[Authorize]
    public class FabricantesController : Controller
    {
        private readonly FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(fabricanteServico.ObterFabricantesClassificadasPorNome());
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Fabricantes/Edit/5
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        // GET: Fabricantes/Details/5
        public ActionResult Details(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }

        // GET: Fabricantes/Delete/5
        public ActionResult Delete(long? id)
        {
            return ObterVisaoFabricantePorId(id);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        // POST: Fabricantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante fabricante)
        {
            return GravarFabricante(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Fabricante fabricante = fabricanteServico.EliminarProdutoPorId(id);
                TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ObterVisaoFabricantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = fabricanteServico.ObterProdutoPorId((long)id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }
        //private void PopularViewBag(Produto produto = null)
        //{
        //    if (produto == null)
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
        private ActionResult GravarFabricante(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fabricanteServico.GravarFabricante(fabricante);
                    return RedirectToAction("Index");
                }
                return View(fabricante);
            }
            catch
            {
                return View(fabricante);
            }
        }

    }
}