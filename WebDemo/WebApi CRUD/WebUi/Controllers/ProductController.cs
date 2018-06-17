using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        [HttpGet()]
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            List<Product> products = new List<Product>();
            products = CreateMockData();
            result = Ok(products);
            return result;

        }

        private List<Product> CreateMockData()
        {
            string urlTemplate = @"/product";
            List<Product> products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                Product p = new Product();
                p.IntroductionDate = DateTime.Now.AddDays(i + GetRandomInt());
                p.ProductId = i + 1;
                p.ProductName = "Product " + i + 1;
                p.Url = urlTemplate + (i + 1).ToString();
                products.Add(p);
            }
            return products;
        }

        private int GetRandomInt()
        {
            Random r = new Random(1);
            return r.Next(100);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}