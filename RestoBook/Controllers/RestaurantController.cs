using RestoBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoBook.Controllers
{
    public class RestaurantController : Controller
    {
        private RestoBookDBContext db = new RestoBookDBContext();
        // GET: Restaurant

        public ActionResult Index(string search)
        {
            //ViewBag.TypeRestaurant = new SelectList(db.TypeRestaurant, "Id", "Type");

            var restaurants = from resto in db.NomRestaurant
                              from ville in resto.VilleRestaurants
                              select new R()
                              {
                                  Name = resto.Nom,
                                  Ville = ville.Ville
                              };

            //var restaurants = from resto in db.NomRestaurant
            //                  join ville in
            //                  join type in db.TypeRestaurant on resto.Id_Type_Fk equals type.Id
            //                  select resto;

            if(!string.IsNullOrEmpty(search))
            {
                restaurants = restaurants.Where(w => w.Name.Contains(search));
            }

            return View(restaurants);
        }
       
        
        public JsonResult IsTypeAvailable(BigRestaurant type)
        {
            var TypeQry=db.TypeRestaurant.Where(w=>w.Type.Contains(type.TypeRestaurants.Type));
            if (TypeQry.Count() > 0)
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult IsVilleAvailable(BigRestaurant ville)
        {
            var VilleQry = db.VilleRestaurant.Where(w => w.Ville.Contains(ville.VilleRestaurants.Ville));
            if (VilleQry.Count() > 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Proposer()
        {
            if (Request.IsAuthenticated)
            {
                var TypeQry = (from type in db.TypeRestaurant
                              orderby type.Type
                              select type).Distinct();

                ViewBag.TypeRestaurant = new SelectList(TypeQry,"Id","Type");
                ViewBag.VilleRestaurant = new SelectList(db.VilleRestaurant, "Id", "Ville");

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Proposer(BigRestaurant restaurants, string TypeRestaurant)
        {
            if (ModelState.IsValid)
            {


                restaurants.VilleRestaurants.NomRestaurants.Add(restaurants.NomRestaurants);
                restaurants.TypeRestaurants.NomRestaurants.Add(restaurants.NomRestaurants);
                db.TypeRestaurant.Add(restaurants.TypeRestaurants);
                db.VilleRestaurant.Add(restaurants.VilleRestaurants);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(restaurants);
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

    public class R
    {
        public string Name{get;set;}
        public string Ville{get;set;}
    }
}