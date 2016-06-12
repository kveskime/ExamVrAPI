using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BLL.DTOs.PK;
using BLL.Services;
using DAL.Interfaces;

namespace WebAPI.Controllers.Api
{
    [RoutePrefix("api/Answers")]

    public class AnswersController : ApiController
    {
        private readonly QuestionService _answerService;

        public AnswersController(IDbContext dbContext)
        {
            _answerService = new QuestionService(dbContext);
        }
        // GET: api/Answers
        public List<AnswerFullDTO> Get()
        {
            return _answerService.AllAnswers();
        }

        // GET: api/Answers/5
        public IHttpActionResult Get(int id)
        {
            AnswerFullDTO answerDTO = this._answerService.GetAnswerById(id);
            if (answerDTO == null)
            {
                return NotFound();
            }
            return Ok(answerDTO);
        }

        [Route("GetFiltered/{filter}")]
        [HttpGet]
        public IHttpActionResult GetFiltered(string filter)
        {
            return Ok(_answerService.FilterList(filter));
        }
        // POST: api/Answers
        public IHttpActionResult Post([FromBody]AnswerFullDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._answerService.AddAnswer(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = value.AnswerId }, value);

        }

        // PUT: api/Answers/5
        public IHttpActionResult Put(int id, [FromBody]AnswerFullDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != value.AnswerId)
            {
                return BadRequest();
            }

            try
            {
                this._answerService.UpdateAnswer(value);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this._answerService.GetAnswerById(id) != null)
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

        // DELETE: api/Answers/5
        public IHttpActionResult Delete(int id)
        {
            var answer = this._answerService.GetAnswerById(id);
            if (answer == null)
            {
                return NotFound();
            }
            this._answerService.DeleteAnswer(answer);

            return Ok(answer);
        }
    }
}
