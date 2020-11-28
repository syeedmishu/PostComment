using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PostManagement.Models;
using PostManagement.Models.Service;

namespace PostManagement.Controllers
{
    public class PostController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: api/Post
        [HttpGet]
        public IHttpActionResult GetPosts()
        {
            PostService postServiec = new PostService();
            List<Post> posts = postServiec.getPosts();

            
           
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        [HttpGet]
        [Route("api/PostbyKeyward")]
        public IHttpActionResult GetPostsByKeyward(string keywod)
        {
            PostService postServiec = new PostService();
            List<Post> posts = postServiec.getPostByKeyword(keywod);

            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.PostID == id) > 0;
        }
    }
}