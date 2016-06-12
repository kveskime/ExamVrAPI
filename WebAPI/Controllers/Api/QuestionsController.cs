using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BLL.DTOs;
using BLL.DTOs.PK;
using BLL.Services;
using DAL.Interfaces;

namespace WebAPI.Controllers.Api
{
    [RoutePrefix("api/Questions")]
    public class QuestionsController : ApiController
    {

        private readonly QuestionService _questionService;

        public QuestionsController(IDbContext dbContext)
        {
            _questionService = new QuestionService(dbContext);
        }
        // GET: api/Questions
        public List<QuestionFullDTO> Get()
        {
            return _questionService.AllQuestions();
        }

        // GET: api/Questions/5
        public IHttpActionResult Get(int id)
        {
            QuestionFullDTO questionDTO = this._questionService.GetQuestionById(id);
            if (questionDTO == null)
            {
                return NotFound();
            }

            return Ok(questionDTO);
        }

        // POST: api/Questions
        public IHttpActionResult Post([FromBody]QuestionFullDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._questionService.AddQuestion(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = value.QuestionId }, value);

        }

        // PUT: api/Questions/5
        public IHttpActionResult Put(int id, [FromBody]QuestionFullDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != value.QuestionId)
            {
                return BadRequest();
            }

            try
            {
                this._questionService.UpdateQuestion(value);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this._questionService.GetQuestionById(id) != null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Questions/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var question = this._questionService.GetQuestionById(id);
            if (question  == null)
            {
                return NotFound();
            }
            this._questionService.DeleteQuestion(question);

            return Ok(question);
        }
    }
}
