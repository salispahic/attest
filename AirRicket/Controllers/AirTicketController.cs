using AirTicketBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirRicket.Controllers
{
    public class AirTicketController : ApiController
    {
        public void Post([FromBody]string value)
        {
            ProducerConsumer pc = new ProducerConsumer();

        }
    }
}
