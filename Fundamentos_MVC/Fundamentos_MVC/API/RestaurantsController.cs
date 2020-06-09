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
        public string Get()
        {
            return "Hello, World!!";
        }
    }
}
