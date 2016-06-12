using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;
using DAL.Interfaces;

namespace WebAPI.Controllers.Api
{
    [RoutePrefix("api/Comments")]
    public class CommentsController : ApiController
    {
        private readonly BlogService _blogService;

        public CommentsController(IDbContext dbContext)
        {
            this._blogService = new BlogService(dbContext);
        }

        // GET: api/Blogs
        [HttpGet]
        public List<CommentFullDTO> GetComments()
        {
            return this._blogService.AllComments();
        }

        // GET: api/Blogs/5
        [HttpGet]
        public IHttpActionResult GetComment(int id)
        {
            CommentFullDTO commentDTO = this._blogService.GetCommentById(id);
            if (commentDTO == null)
            {
                return NotFound();
            }

            return Ok(commentDTO);
        }

        // POST: api/Blogs
        [HttpPost]
        public IHttpActionResult PostComment([FromBody]CommentFullDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._blogService.AddComment(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = value.CommentId }, value);
        }

        // PUT: api/Blogs/5
        [HttpPut]
        public IHttpActionResult PutComment(int id, [FromBody]CommentFullDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != value.BlogId)
            {
                return BadRequest();
            }

            try
            {
                this._blogService.UpdateComment(value);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this._blogService.GetCommentById(id) != null)
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

        // DELETE: api/Blogs/5
        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            var comment = this._blogService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            this._blogService.DeleteComment(comment);

            return Ok(comment);
        }
    }
}
