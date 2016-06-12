using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using Domain;

namespace BLL.Factories
{
    public class CommentFactory
    {
        public CommentFullDTO CreateCommentFullDTO(Comment comment)
        {
            return new CommentFullDTO()
            {
                BlogId = comment.BlogId,
                Body = comment.Body,
                CommentId = comment.BlogId,
                User = comment.User
            };
        }

        public Comment RecreateFromCommentFullDTO(CommentFullDTO commentFullDTO)
        {
            return new Comment()
            {
                BlogId = commentFullDTO.BlogId,
                Body = commentFullDTO.Body,
                CommentId = commentFullDTO.CommentId,
                User = commentFullDTO.User
            };
        }
    }
}
