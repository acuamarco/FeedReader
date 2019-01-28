using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FeedReader.Repository;
using FeedReader.Repository.Model;

namespace FeedReader.Web.Controllers
{
    public class FeedsController : Controller
    {
        private FeedReaderContext db = new FeedReaderContext();

        // GET: Feeds
        public async Task<ActionResult> Index()
        {
            var feeds = db.Feeds.Include(f => f.Category);
            return View(await feeds.ToListAsync());
        }

        // GET: Feeds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // GET: Feeds/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Feeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,CategoryId,Image")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                db.Feeds.Add(feed);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", feed.CategoryId);
            return View(feed);
        }

        // GET: Feeds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", feed.CategoryId);
            return View(feed);
        }

        // POST: Feeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,CategoryId,Image")] Feed feed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feed).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", feed.CategoryId);
            return View(feed);
        }

        // GET: Feeds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feed feed = await db.Feeds.FindAsync(id);
            if (feed == null)
            {
                return HttpNotFound();
            }
            return View(feed);
        }

        // POST: Feeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Feed feed = await db.Feeds.FindAsync(id);
            db.Feeds.Remove(feed);
            await db.SaveChangesAsync();
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
