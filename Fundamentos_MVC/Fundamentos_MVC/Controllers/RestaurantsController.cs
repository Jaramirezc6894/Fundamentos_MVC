﻿using Fundamentos_MVC.Models;
using Fundamentos_MVC.Services;
using System.Web.Mvc;

namespace Fundamentos_MVC.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {

            //************Se reciclara esta logica de autentificacion de campos para asi implementar una nuevalogica
            //if(String.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            //}



            if(ModelState.IsValid)
            {            
                db.Add(restaurant);
                return RedirectToAction("Details", new {id = restaurant.Id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }
    }
}