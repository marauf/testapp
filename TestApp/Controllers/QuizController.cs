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
    public class QuizController : Controller
    {

        #region Restful Convention method public API method
        ///<summary>
        ///GET:api/quiz/{}id
        ///Retrieves quiz w/id
        /// </summary>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var v = new QuizViewModel()
            {
                Id = id,
                Title = String.Format("Sample quiz with id {0}", id),
                Description = "no real number",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            return new JsonResult(
                v, new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
   
        #endregion













        #region attribute-based routing method
        /// <summary>
        /// Get: api/quiz/latest
        /// Retrieves the {num} latest quizes
        /// </summary>
        /// <param name="num">quizzes .. </param>
        /// <returns></returns>
        // Attribute routing
        [HttpGet("Latest/{num}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>();

            // add sample quiz
            sampleQuizzes.Add(new QuizViewModel()
            {
                Id = 1,
                Title = "Which Shingeki characater",
                Description = "Anime-related",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });


            // add other quizzes
            for (int i = 2; i <= num; i++)
            {
                sampleQuizzes.Add(new QuizViewModel()
                {
                    Id = i,
                    Title = String.Format("Sample Quiz {0}", i),
                    Description = "This is sample quiz",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }



            //output result in JSON format
            return new JsonResult(
                sampleQuizzes,
                new JsonSerializerSettings()
                { Formatting = Formatting.Indented });
        }
        #endregion

        /*
         * GET: api/quiz/ByTitle
         */
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10) {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;


            return new JsonResult(
                sampleQuizzes.OrderBy(t => t.Title),
                new JsonSerializerSettings()
                { Formatting = Formatting.Indented });
        }



        /*
         GET: api/quiz/mostViewed
         Retrieves {num} random Quizes
             */
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10) {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(
                sampleQuizzes.OrderBy(t => Guid.NewGuid()),
                new JsonSerializerSettings()
                { Formatting = Formatting.Indented });
        }

    }
}
