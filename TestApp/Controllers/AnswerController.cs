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
