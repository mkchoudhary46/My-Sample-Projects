using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using LifeLine.Services;

namespace LifeLine.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IBloodDonorService _bloodDonorService;

        public ValuesController(IBloodDonorService bloodDonorService)
        {
            _bloodDonorService = bloodDonorService;
        }

        // GET api/values
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Http.HttpGet, Route("api/get")]
        public IEnumerable<string> Get()
        {
            var result = _bloodDonorService.GetBloodDonorById(1);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}