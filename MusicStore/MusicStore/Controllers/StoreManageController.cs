using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StoreManageController : Controller
    {
        private MusicStoreEntity db = new MusicStoreEntity();

        // GET: StoreManage

        private ActionResult ar000;
        public ActionResult Check()
        {
            ar000 = null;
            if (ModelState.IsValid ==false)
            {
                 ar000=RedirectToAction("Index");
            }
            return ar000;
        }

        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artists).Include(a => a.Genres);
            return View(albums.ToList());
        }

        // GET: StoreManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albums albums = db.Albums.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            return View(albums);
        }

        // GET: StoreManage/Create
        public ActionResult Create()
        {
            ar000=Check();
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            if (ActionResult.Equals(ar000, null))
            {
                return View();
            }
            else
            {
                return ar000;
            }
        }

        // POST: StoreManage/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Albums albums)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(albums);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", albums.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", albums.GenreId);
            return View(albums);
        }

        // GET: StoreManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albums albums = db.Albums.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", albums.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", albums.GenreId);
            return View(albums);
        }

        // POST: StoreManage/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Albums albums)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albums).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", albums.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", albums.GenreId);
            return View(albums);
        }

        // GET: StoreManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albums albums = db.Albums.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            return View(albums);
        }

        // POST: StoreManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albums albums = db.Albums.Find(id);
            db.Albums.Remove(albums);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
