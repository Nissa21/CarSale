using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSale.Models;
using System.Diagnostics;

namespace CarSale.Controllers
{
    public class CarsController : Controller
    {
        private CarDBContext db = new CarDBContext();

        //
        // GET: /Cars/

        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        //
        // GET: /Cars/Details/5

        public ActionResult Details(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // GET: /Cars/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cars/Create

        [HttpPost]
        public ActionResult Create(Car car, HttpPostedFileBase file)
        {


            if (ModelState.IsValid)
            {

               car.CarImg = new byte[file.ContentLength];
               file.InputStream.Read(car.CarImg,0, file.ContentLength);

               Debug.WriteLine("CarImg value:"+file.ContentLength);
               Debug.WriteLine("This is the file:" + file);




                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        //
        // GET: /Cars/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /Cars/Edit/5

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        //
        // GET: /Cars/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }



        public ActionResult SearchIndex(string searchString)
        {
            var cars = from m in db.Cars
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Model.Contains(searchString));
            }

            else if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.BodyType.Contains(searchString));
            }

            else if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.FuelType.Contains(searchString));
            }

            else if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Color.Contains(searchString));
            }


            

            return View(cars);
        }

        
        //
        // POST: /Cars/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}