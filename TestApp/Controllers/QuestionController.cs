using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApp.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        // GET: /<controller>/
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var sampleQuestions = new List<QuestionViewModel>();

            // add sample question
            sampleQuestions.Add(new QuestionViewModel()
            {
                Id = 1,
                QuizId = quizId,
                Text = "What do you think",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            // add other questions
            for (int i = 2; i <= 5; i++)
            {
                sampleQuestions.Add(new QuestionViewModel()
                {
                    Id = i,
                    QuizId = quizId,
                    Text = String.Format("Sample Question {0}", i),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            // output the result in JSON format
            return new JsonResult (
                sampleQuestions,
                new JsonSerializerSettings()
                { Formatting = Formatting.Indented }
            );
        }




    }
}
