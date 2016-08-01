using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
using X.PagedList;

namespace MusicStore.Controllers
{
    public class Gwb001Controller : Controller
    {
        // GET: Gwb001
        public ActionResult Index(string Search=null,int page = 1)
        {
            var PageSize = 8;
            ViewBag.PageSize = PageSize.ToString();
            ViewBag.CurrentPage = page.ToString();
            Models.MusicStoreEntity db = new Models.MusicStoreEntity();///实例化数据访问对象db
            IPagedList<Albums> dbal1;
            if (string.IsNullOrEmpty(Search))
            {
                dbal1 = db.Albums.OrderBy(a => a.Title).Where(a => a.Title.CompareTo("d") > 0).ToPagedList(page, PageSize);    /// list 方式获取上表
            }
            else
            {
                ViewBag.Search = Search;
               dbal1 = db.Albums.OrderBy(a => a.Title).Where(a => a.Title.Contains(Search)).ToPagedList(page, PageSize);    /// list 方式获取上表
            }
            var dbal = db.Albums.ToList();                               ///var 方式获取albums表
            ViewBag.dbal = db.Albums.ToList();                          ///用viewbag传参数
            return View(dbal1);                                         ///用参数形式传数据
        }
        public ActionResult Details(int id=0)
        {
            Models.MusicStoreEntity db = new Models.MusicStoreEntity();///实例化数据访问对象db
            Albums OneAlbum = db.Albums.Find(id);                               ///var 方式获取albums表
            return View(OneAlbum);
        }
        public ActionResult Edit(int id=0)
        {
            Models.MusicStoreEntity db = new Models.MusicStoreEntity();///实例化数据访问对象db
            Albums OneAlbum =db.Albums.Find(id);                               ///var 方式获取albums表
            if (OneAlbum == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(OneAlbum);
            }
        }
        public ActionResult Delete(int id=0)
        {
            Models.MusicStoreEntity db = new Models.MusicStoreEntity();///实例化数据访问对象db
            Albums OneAlbum = db.Albums.Find(id);                               ///var 方式获取albums表
            if (OneAlbum == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(OneAlbum);
            }
        }
        public ActionResult Create()
        {
            Models.MusicStoreEntity db = new Models.MusicStoreEntity();///实例化数据访问对象db
            Albums OneAlbum = db.Albums.Add(new Albums() );                               ///var 方式获取albums表
            return View();
        }
    }
}