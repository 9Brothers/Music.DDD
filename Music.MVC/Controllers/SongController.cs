using AutoMapper;
using Music.Application;
using Music.Application.Interface;
using Music.Domain.Entities;
using Music.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.MVC.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongAppService _songApp;

        public SongController(ISongAppService songApp)
        {
            _songApp = songApp;
        }

        // GET: Song
        public ActionResult Index()
        {
            var songs = _songApp.GetAll();

            var clienteViewModel = Mapper.Map<IEnumerable<Song>, IEnumerable<SongViewModel>>(songs);

            return View(clienteViewModel);
        }

        // GET: Song/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Song/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongViewModel songViewModel)
        {
            if (ModelState.IsValid)
            {
                var songDomain = Mapper.Map<SongViewModel, Song>(songViewModel);

                _songApp.Add(songDomain);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Song/Edit/5
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

        // GET: Song/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Song/Delete/5
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
