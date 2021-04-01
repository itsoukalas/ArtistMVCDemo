using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtistMVCDemo.Models;
using ArtistMVCDemo.ViewModels;

namespace ArtistMVCDemo.Controllers
{
   
    public class SongsController : Controller
    {
        private ApplicationDbContext _context;
        public SongsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Songs
        public ActionResult Index()
        {
            var songs = _context
                .Songs
                .Include(s => s.album.Artist)
                .ToList();

            return View(songs);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var song = _context
                .Songs
                .Include(s => s.album.Artist)
                .SingleOrDefault(s => s.ID == id);

            if (song == null)
            {
                return HttpNotFound();
            }

            return View(song);
        }

        public ActionResult New()
        {
            // Get Albums from the database
            var albums = _context.Albums.ToList();
            // Init and fill the viewmodel
            var viewmodel = new SongFormViewModel()
            {
                Song = new Song(),
                Albums = albums
            };
            // Return the appropriate view with the viewmodel
            return View("SongForm", viewmodel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // get the song from the database
            var song = _context
                .Songs
                .Include(s => s.album)
                .SingleOrDefault(s => s.ID == id);

            // Check if the song is null
            if (song == null)
            {
                return HttpNotFound();
            }

            //Get the Albums from the database
            var albums = _context.Albums.ToList();

            // Init the viewmodel and fill it 
            var viewModel = new SongFormViewModel()
            {
                Song = song,
                Albums = albums
            };

            return View("SongForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Song song)
        {
            if (song.Youtube != null)
            {
                song.Youtube = $"https://www.youtube.com/embed/{song.Youtube}";
            }

            if (song.ID == 0)
            {
                _context.Songs.Add(song);
            }
            else
            {
                var songInDb = _context.Songs.Single(s => s.ID == song.ID);
                songInDb.Title = song.Title;
                songInDb.Youtube = song.Youtube;
                songInDb.AlbumId = song.AlbumId;
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new SongFormViewModel()
                {
                    Song = song,
                    Albums = _context.Albums.ToList()
                };
                return View("SongForm", viewModel);
            }
            else
            {
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Songs");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}
