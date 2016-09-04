using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KOKService;

namespace KoK_Source.Controllers
{
    public class MENUsController : Controller
    {
        private KOK_DATAEntities db = new KOK_DATAEntities();

        // GET: MENUs
        public async Task<ActionResult> Index()
        {
            return View(await db.MENU.ToListAsync());
        }

        // GET: MENUs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = await db.MENU.FindAsync(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // GET: MENUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MENUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,MENU_NAME,MENU_LINK,MENU_RANK,MENU_PARENT_ID,MENU_ACTIVE,MENU_ORDER,ACTIVE,CREATE_DATE,UPDATE_DATE,CREATE_USER,UPDATE_USER")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.MENU.Add(mENU);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mENU);
        }

        // GET: MENUs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = await db.MENU.FindAsync(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: MENUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,MENU_NAME,MENU_LINK,MENU_RANK,MENU_PARENT_ID,MENU_ACTIVE,MENU_ORDER,ACTIVE,CREATE_DATE,UPDATE_DATE,CREATE_USER,UPDATE_USER")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mENU).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mENU);
        }

        // GET: MENUs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = await db.MENU.FindAsync(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: MENUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MENU mENU = await db.MENU.FindAsync(id);
            db.MENU.Remove(mENU);
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
