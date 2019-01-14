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
        private readonly ISongAppService songService;
        private readonly IArtistAppService artistService;
        private readonly IStyleAppService styleService;

        public SongController(ISongAppService songService, IArtistAppService artistService, IStyleAppService styleService)
        {
            this.songService = songService;
            this.artistService = artistService;
            this.styleService = styleService;
        }


        // GET: Song
        public ActionResult Index()
        {
            var songs = songService.GetAll();

            var clienteViewModel = Mapper.Map<IEnumerable<Song>, IEnumerable<SongViewModel>>(songs);

            return View(clienteViewModel);
        }

        // GET: Song/Details/5
        public ActionResult Details(int id)
        {
            var song = songService.Get(new Song { IdSong = id });

            var songViewModel = Mapper.Map<Song, SongViewModel>(song);

            return View(songViewModel);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            ViewBag.Artists = artistService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Name });
            ViewBag.Styles = styleService.GetAll().Select(s => new SelectListItem { Text = s.Name, Value = s.Name });

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

                if (songService.Add(songDomain) > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("Error");
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Artists = artistService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.IdArtist.ToString() });
            ViewBag.Styles = styleService.GetAll().Select(s => new SelectListItem { Text = s.Name, Value = s.IdStyle.ToString() });

            return View();
        }

        // POST: Song/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SongViewModel songViewModel)
        {
            var song = Mapper.Map<SongViewModel, Song>(songViewModel);
            song.IdSong = id;

            if (songService.Update(song) > 0)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Song/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SongViewModel songViewModel)
        {
            if (songService.Remove(id) > 0)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }
    }
}
