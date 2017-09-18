
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.CircuitBreaker.Hystrix;
using System.Net.Http; //for Http calls
using core_hystrix_wrapper_ui.Models;


namespace core_hystrix_wrapper_ui.Services
{
    //HystrixCommand means no result, HystrixCommand<string> means a string comes back
    public class RecommendationService: HystrixCommand<List<Recommendations>>
    {      
        public RecommendationService(IHystrixCommandOptions options):base(options) {
            //nada        
        }

        protected override List<Recommendations> Run()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5000/api/recommendations").Result;

            var recommendations = response.Content.ReadAsAsync<List<Recommendations>>().Result;

            return recommendations;
        }

        protected override List<Recommendations> RunFallback()
        {
            Recommendations r1 = new Recommendations();
            r1.ProductId = "10007";
            r1.ProductDescription = "Black Hat";
            r1.ProductImage = "https://cdn.shopify.com/s/files/1/0692/5669/products/hatnew_1024x1024.png?v=1458082282";

            List<Recommendations> recommendations = new List<Recommendations>();
            recommendations.Add(r1);

            return recommendations;
        }
    }
}