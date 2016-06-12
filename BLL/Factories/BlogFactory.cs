using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using Domain;

namespace BLL.Factories
{
    public class BlogFactory
    {
        private readonly CommentFactory _commentFactory;

        public BlogFactory()
        {
            _commentFactory = new CommentFactory();
        }

        public BlogFullDTO CreateBlogFullDTO(Blog blog)
        {
            return new BlogFullDTO()
            {
                BlogId = blog.BlogId,
                Body = blog.Body,
                Comments = blog.Comments.Select(x => _commentFactory.CreateCommentFullDTO(x)).ToList()
            };
        }

        public Blog RecreateFromBlogDTO (BlogFullDTO BlogDTO)
        {
            return new Blog()
            {
                BlogId = BlogDTO.BlogId,
                Body = BlogDTO.Body,
                Comments = BlogDTO.Comments.Select(x => _commentFactory.RecreateFromCommentFullDTO(x)).ToList()
            };
        }
    }
}
