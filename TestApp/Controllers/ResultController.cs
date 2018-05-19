using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        // GET: api/<controller>
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId) {
            var sampleResults = new List<ResultViewModel>();

            sampleResults.Add(new ResultViewModel()
            {
                Id = 1,
                QuizId = quizId,
                Text = "What do you do",
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now
            });


            for (int i = 2; i <= 5; i++)
            {
                sampleResults.Add(new ResultViewModel()
                {
                    Id = i,
                    QuizId = quizId,
                    Text = String.Format("sample {0}", i),
                    CreatedDate = DateTime.Now,
                    LastModified = DateTime.Now
                });
            }


            return new JsonResult
            (
                sampleResults,
                new JsonSerializerSettings()
                { Formatting = Formatting.Indented }
                
                );

        } 
    }
}
