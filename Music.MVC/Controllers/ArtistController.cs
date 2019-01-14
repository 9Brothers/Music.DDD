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
    public class ArtistController : Controller
    {
        protected IArtistAppService service;

        public ArtistController(IArtistAppService service)
        {
            this.service = service;
        }


        // GET: Artist
        public ActionResult Index()
        {
            var artists = service.GetAll();

            var artistViewModel = Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistViewModel>>(artists);

            return View(artistViewModel);
        }

        // GET: Artist/Details/5
        public ActionResult Details(int id)
        {
            var artist = service.Get(new Artist { IdArtist = id });

            var artistViewModel = Mapper.Map<Artist, ArtistViewModel>(artist);

            return View(artistViewModel);
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        public ActionResult Create(ArtistViewModel artistViewModel)
        {
            if(ModelState.IsValid)
            {
                var artist = Mapper.Map<ArtistViewModel, Artist>(artistViewModel);

                if (service.Add(artist) > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Erro");
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ArtistViewModel artistViewModel)
        {
            var artist = Mapper.Map<ArtistViewModel, Artist>(artistViewModel);
            artist.IdArtist = id;

            if (service.Update(artist) > 0)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Erro");
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artist/Delete/5
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
