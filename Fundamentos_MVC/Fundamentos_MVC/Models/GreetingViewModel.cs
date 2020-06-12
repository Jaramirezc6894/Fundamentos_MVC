using Fundamentos_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fundamentos_MVC.Models
{
    public class GreetingViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Mensaje { get; set; }
        
        public string Name { get; set; }

    }
}