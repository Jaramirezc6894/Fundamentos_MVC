using Fundamentos_MVC.Models;
using Fundamentos_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fundamentos_MVC.API
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
