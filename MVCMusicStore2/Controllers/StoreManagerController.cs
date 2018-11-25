using MVCMusicStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2.Controllers
{
    public class StoreManagerController : Controller
    {
        MVCMusicStore2.Models.MusicStoreEntities storeDB
            = new MVCMusicStore2.Models.MusicStoreEntities();
        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = storeDB.Albums.Include("Genre").Include("Artist");
            return View(albums.ToList());
        }
        //Get 方式的 Action 用来提供编辑表单
        public ActionResult Edit(int id)
        {
            Album album = storeDB.Albums.Find(id);
            //通过ViewBag来处理，允许在传递一个Model的同时还通过ViewBag传递两个额外的SelectList
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return this.View(album);
        }
        //Get 方式的 Action 用来提供编辑表单
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(album).State = System.Data.EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: /StoreManager/Details/5
        public ViewResult Details(int id)
        {
            MVCMusicStore2.Models.Album album = storeDB.Albums.Find(id);
            return View(album);
        }
        public ActionResult Delete(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {           
                Album album = storeDB.Albums.Find(id);
                storeDB.Albums.Remove(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
          
        }
        public ActionResult Create()
        {
            //用来生成下拉列表中信息的集合，第一个参数是流派对象的集合
            //第二个提供下拉列表中的值。是流派对象的一个属性GenreId
            //第三个参数提供下了列表中显示出来的值。这里是流派的Name属性
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                //将对象模型加入到Albums中，再调用SaveChangs();
                storeDB.Albums.Add(album);
                storeDB.SaveChanges();
                //保存数据之后，重定向到index页面
                return Redirect("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.Aritist = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }
    }
}