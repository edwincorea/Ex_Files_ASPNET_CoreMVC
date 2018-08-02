using System;
using System.Collections.Generic;
using System.Linq;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.api
{
    [Route("api/posts/{postKey}/comments")]
    public class CommentsController : Controller
    {
        private readonly BlogDataContext _db;

        public CommentsController(BlogDataContext db)
        {
            this._db = db;
        }

        // GET: api/posts/{postKey}/comments
        [HttpGet]
        public IActionResult Get(string postKey)
        {
            return Ok(_db.Comments.
                Where(c => c.Post.Key == postKey).
                ToList());
        }

        // GET api/posts/{postKey}/comments/5
        [HttpGet("{id}")]
        public IActionResult Get(string postKey, int id)
        {
            var comment = _db.Comments.
                FirstOrDefault(c => c.Post.Key == postKey && c.Id == id);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        // POST api/posts/{postKey}
        [HttpPost]
        public IActionResult Post(string postKey, [FromBody]Comment comment)
        {
            var post = _db.Posts.FirstOrDefault(p => p.Key == postKey);

            if (post == null)
                return NotFound();

            comment.Post = post;
            comment.Posted = DateTime.Now;
            comment.Author = User.Identity.Name;

            _db.Comments.Add(comment);
            _db.SaveChanges();

            return Ok(comment);
        }

        // PUT api/posts/{postKey}/5
        [HttpPut("{id}")]
        public IActionResult Put(string postKey, int id, [FromBody]Comment comment)
        {
            var commentDb = _db.Comments.
                FirstOrDefault(c => c.Post.Key == postKey && c.Id == id);

            if (commentDb == null)
                return NotFound();

            commentDb.Body = comment.Body;

            _db.Comments.Update(commentDb);
            _db.SaveChanges();

            return NoContent();
        }

        // DELETE api/posts/{postKey}/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string postKey, int id)
        {
            var commentDb = _db.Comments.
                FirstOrDefault(c => c.Post.Key == postKey && c.Id == id);

            if (commentDb == null)
                return NotFound();

            _db.Comments.Remove(commentDb);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
