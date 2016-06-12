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
    [RoutePrefix("api/Blogs")]
    public class BlogsController : ApiController
    {

        private readonly BlogService _blogService;

        public BlogsController(IDbContext dbContext)
        {
            _blogService = new BlogService(dbContext);
        }

        // GET: api/Blogs
        [HttpGet]
        public List<BlogFullDTO> GetBlogs()
        {
            return this._blogService.AllBlogs();
        }

        // GET: api/Blogs/5
        [HttpGet]
        public IHttpActionResult GetBlog(int id)
        {
            BlogFullDTO blogDTO = this._blogService.GetBlogById(id);
            if (blogDTO == null)
            {
                return NotFound();
            }
            return Ok(blogDTO);
        }

        // POST: api/Blogs
        [HttpPost]
        public IHttpActionResult PostBlog([FromBody]BlogFullDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                this._blogService.AddBlog(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtRoute("DefaultApi", new { id = value.BlogId }, value);
        }

        // PUT: api/Blogs/5
        [HttpPut]
        public IHttpActionResult PutBlog(int id, [FromBody]BlogFullDTO value)
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
                this._blogService.UpdateBlog(value);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this._blogService.GetBlogById(id) != null)
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
        public IHttpActionResult DeleteBlog(int id)
        {
            var blog = this._blogService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            this._blogService.DeleteBlog(blog);

            return Ok(blog);
        }
    }
}
