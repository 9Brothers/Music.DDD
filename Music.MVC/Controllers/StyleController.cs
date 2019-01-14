using AutoMapper;
using Music.Application.Interface;
using Music.Domain.Entities;
using Music.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.MVC.Controllers
{
    public class StyleController : Controller
    {
        private IStyleAppService service;

        public StyleController(IStyleAppService service)
        {
            this.service = service;
        }

        // GET: Style
        public ActionResult Index()
        {
            var styles = service.GetAll();

            var stylesViewModel = Mapper.Map<IEnumerable<Style>, IEnumerable<StyleViewModel>>(styles);

            return View(stylesViewModel);
        }

        // GET: Style/Details/5
        public ActionResult Details(int id)
        {
            var style = service.Get(new Style { IdStyle = id });

            var styleViewModel = Mapper.Map<Style, StyleViewModel>(style);

            return View(styleViewModel);
        }

        // GET: Style/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Style/Create
        [HttpPost]
        public ActionResult Create(StyleViewModel styleViewModel)
        {
            if (ModelState.IsValid)
            {
                var style = Mapper.Map<StyleViewModel, Style>(styleViewModel);

                if (service.Add(style) > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Erro");
        }

        // GET: Style/Edit/5
        public ActionResult Edit(int id)
        {
            var style = service.Get(new Style { IdStyle = id });

            var styleViewModel = Mapper.Map<Style, StyleViewModel>(style);

            return View(styleViewModel);
        }

        // POST: Style/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StyleViewModel styleViewModel)
        {
            var style = Mapper.Map<StyleViewModel, Style>(styleViewModel);
            style.IdStyle = id;

            if (service.Update(style) > 0)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Erro");
        }

        // GET: Style/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Style/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (service.Remove(id) > 0)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Erro");
        }
    }
}
