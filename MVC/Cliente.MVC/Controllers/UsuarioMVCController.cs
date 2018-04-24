using Cliente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente.MVC.Controllers
{
    public class UsuarioMVCController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioMVCController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        // GET: UsuarioMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioMVC/Details/5
        public ActionResult Details()
        {
            
            return View(this._usuarioService.GetAsync());
        }

        // GET: UsuarioMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioMVC/Create
        [HttpPost]
        public ActionResult Create(UsuarioServiceModel usuarioServiceModel)
        {
            try
            {
                var usuario = this._usuarioService.SetAsync(usuarioServiceModel);

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioMVC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioMVC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
