using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiEntity.Models;

namespace XUnitTestWebApiNews_site
{
    public class CommentsFake
    {
        private readonly List<Comments> _commentsList;
        public CommentsFake()
        {
            _commentsList = new List<Comments>()
            {
                new Comments(){ Id = new Guid("c7721867-6fb6-4eb3-8340-cbd24c2c4552"), Author = "JACK", Body = "lol", CreateDate = DateTime.Now,},
                new Comments(){ Id = new Guid("97ffda2c-0ed3-4bc7-aa21-fdc7f6726c73"), Author = "OLIVER", Body = "ok", CreateDate = DateTime.Now,},
                new Comments(){ Id = new Guid("901cc250-2b6a-479c-8275-dbdb34e2d1bb"), Author = "JAMES", Body = "Please", CreateDate = DateTime.Now,},
                new Comments(){ Id = new Guid("2f81a0c0-4dff-4f46-9c9b-43d3bb0f3903"), Author = "AMELIA", Body = "Saturday", CreateDate = DateTime.Now,},
                new Comments(){ Id = new Guid("6c830762-963d-429e-8cda-d0b18371b27d"), Author = "EMILY", Body = "Yes", CreateDate = DateTime.Now,}
            };
        }
        public Comments GetCommentById(Guid id)
        {
            return _commentsList.Where(c => c.Id == id).FirstOrDefault();
        }
        public Comments PostComments(Comments comments) 
        {
            comments.Id = Guid.NewGuid();
            _commentsList.Add(comments);
            return comments;
        }
        public void DeleteCommentsById(Guid id)
        {
            var result = _commentsList.FirstOrDefault(c => c.Id == id);
            _commentsList.Remove(result);
        }
    }
}
