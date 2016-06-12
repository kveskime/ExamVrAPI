using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Factories;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class BlogService
    {
        private readonly BlogFactory _blogFactory;
        private readonly CommentFactory _commentFactory;
        private readonly CommentRepository _commentRepository;
        private readonly BlogRepository _blogRepository;

        public BlogService(IDbContext dbContext)
        {
            _blogRepository = new BlogRepository(dbContext);
            _commentRepository = new CommentRepository(dbContext);


            _commentFactory = new CommentFactory();
            _blogFactory = new BlogFactory();
        }

        public List<BlogFullDTO> AllBlogs()
        {
            return _blogRepository.All.Select(x => _blogFactory.CreateBlogFullDTO(x)).ToList();
        }

        public BlogFullDTO GetBlogById(int id)
        {
            var blogBO = this._blogRepository.GetById(id);
            return blogBO == null ? null : this._blogFactory.CreateBlogFullDTO(blogBO); //null reference
        }

        public void UpdateBlog(BlogFullDTO blogDTO)
        {
            this._blogRepository.Update(this._blogFactory.RecreateFromBlogDTO(blogDTO));
            this._blogRepository.SaveChanges();
        }

        public void AddBlog(BlogFullDTO blogDTO)
        {
            this._blogRepository.Add(this._blogFactory.RecreateFromBlogDTO(blogDTO));
            this._blogRepository.SaveChanges();

        }

        public void DeleteBlog(BlogFullDTO blogDTO)
        {
            this._blogRepository.Delete(this._blogFactory.RecreateFromBlogDTO(blogDTO));
            this._blogRepository.SaveChanges();
        }

        public void DeleteBlogById(int blogId)
        {
            this._blogRepository.Delete(blogId);
            this._blogRepository.SaveChanges();
        }
        
        public List<CommentFullDTO> AllComments()
        {
            return this._commentRepository.All.Select(x => this._commentFactory.CreateCommentFullDTO(x)).ToList();
        }

        public CommentFullDTO GetCommentById(int id)
        {
            var commentBO = this._commentRepository.GetById(id);
            return commentBO == null ? null : this._commentFactory.CreateCommentFullDTO(commentBO); //null reference
        }

        public void UpdateComment(CommentFullDTO commentDTO)
        {
            this._commentRepository.Update(this._commentFactory.RecreateFromCommentFullDTO(commentDTO));
            this._commentRepository.SaveChanges();
        }

        public void AddComment(CommentFullDTO commentDTO)
        {
            this._commentRepository.Add(this._commentFactory.RecreateFromCommentFullDTO(commentDTO));
            this._commentRepository.SaveChanges();

        }

        public void DeleteComment(CommentFullDTO commentDTO)
        {
            this._commentRepository.Delete(this._commentFactory.RecreateFromCommentFullDTO(commentDTO));
            this._commentRepository.SaveChanges();
        }

        public void DeleteCommentById(int commentId)
        {
            this._commentRepository.Delete(commentId);
            this._commentRepository.SaveChanges();
        }

    }
}
