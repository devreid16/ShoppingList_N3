﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ShoppingListModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListModel
        public ActionResult Index()
        {
            return View(db.ShoppingListModels.ToList());
        }

        // GET: ShoppingListModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListModel shoppingListModel = db.ShoppingListModels.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // GET: ShoppingListModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingListModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingListModelId,UserId,Name,Color,CreatedUtc,ModifiedUtc")] ShoppingListModel shoppingListModel)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingListModels.Add(shoppingListModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingListModel);
        }

        // GET: ShoppingListModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListModel shoppingListModel = db.ShoppingListModels.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // POST: ShoppingListModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingListModelId,UserId,Name,Color,CreatedUtc,ModifiedUtc")] ShoppingListModel shoppingListModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingListModel);
        }

        // GET: ShoppingListModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListModel shoppingListModel = db.ShoppingListModels.Find(id);
            if (shoppingListModel == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListModel);
        }

        // POST: ShoppingListModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListModel shoppingListModel = db.ShoppingListModels.Find(id);
            db.ShoppingListModels.Remove(shoppingListModel);
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