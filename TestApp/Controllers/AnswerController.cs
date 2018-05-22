using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    // may need different controller
namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    public class AnswerController : Controller
    {

        #region RESTful conventions
        
        
        /// <summary>
        /// retreives answer w/iven {id}
        /// </summary>
        /// <param name="Id">The ID of existing answer</param>
        /// <returns>answerr w/given id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Content("not implemented yet...");
        }

        /// <summary>
        /// Adds new answer to DB
        /// </summary>
        /// <param name="m">The AnswerViewModel containing the data to insert</param>
        [HttpPut]
        public IActionResult Put(AnswerViewModel m) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit the answer with given id
        /// </summary>
        /// <param name="m">AnswerViewModel containing answer to be updated</param>
        [HttpPost]
        public IActionResult Post(AnswerViewModel m) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete Answer w/given id from DB
        /// </summary>
        /// <param name="Id">Id of existing answer</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            throw new NotImplementedException();
        }
 
        #endregion






        // GET: api/answer/all
        [HttpGet("All/{questionId}")]
        public IActionResult All(int questionId)
        {
            var sampleAnswers = new List<AnswerViewModel>();

            sampleAnswers.Add(new AnswerViewModel()
            {
                Id = 1,
                QuestionId = questionId,
                Text = "Friednds",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });



            // add a few mre
            for (int i = 2; i <= 5; i++) {
                sampleAnswers.Add(new AnswerViewModel()
                {
                    Id = 1,
                    QuestionId = questionId,
                    Text = String.Format("Sample Answer {0}", i),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }



            return new JsonResult(
                sampleAnswers,
                new JsonSerializerSettings()
                { Formatting = Formatting.Indented });
        }
    }
}
