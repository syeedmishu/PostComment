using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostManagement.Models.Service
{
    public class PostService
    {
        private DatabaseContext db = new DatabaseContext();
        public List<Post> getPosts()
        {
            List<Post> Posts = db.Posts.ToList();
            if(Posts.Count > 0)
            {
                for(int i = 0; i < Posts.Count; i++)
                {
                    var postid = Posts[i].PostID;
                    var userid = Posts[i].CreatedBy;
                    Posts[i].FormattedDate =Posts[i].CreationDate.ToUniversalTime()
                         .ToString("dd'-'MM'-'yyyy");

                    Posts[i].UserName = db.Users.FirstOrDefault(x => x.UserID == userid).UserName.ToString();
                    var totalcomment = db.Comments.Where(x => x.PostID == postid).ToList().Count;
                    var com = totalcomment <= 1 ? " Comment" : " Comments";
                    Posts[i].TotalComment = totalcomment + com;
                    Posts[i].CommentList = db.Comments.Where(x => x.PostID == postid).ToList();
                    var comment = Posts[i].CommentList;
                    if (comment.Count > 0)
                    {
                        
                        for (int j = 0; j < comment.Count; j++)
                        {
                            var ct = comment[j].CreatedBy;
                            comment[j].UserName  = db.Users.FirstOrDefault(x => x.UserID == ct).UserName.ToString();
                            comment[j].FormattedDate = comment[j].CreationDate.ToUniversalTime()
                         .ToString("dd'-'MM'-'yyyy");
                            var commentid = comment[j].CommentID;
                            comment[j].TotalLike = db.Likes.Where(x => x.CommentID == commentid).ToList().Count;
                            comment[j].TotalDislike = db.Dislikes.Where(x => x.CommentID == commentid).ToList().Count;

                        }
                    }
                }
            }


            return Posts;
        }

        public List<Post> getPostByKeyword(string keywod)
        {
            //List<Post> Posts = db.Posts.ToList();
            var Posts = db.Posts.Where(x => x.PostTitle.Contains(keywod)).ToList();
            if (Posts.Count > 0)
            {
                for (int i = 0; i < Posts.Count; i++)
                {
                    var postid = Posts[i].PostID;
                    var userid = Posts[i].CreatedBy;
                    Posts[i].FormattedDate = Posts[i].CreationDate.ToUniversalTime()
                         .ToString("dd'-'MM'-'yyyy");

                    Posts[i].UserName = db.Users.FirstOrDefault(x => x.UserID == userid).UserName.ToString();
                    var totalcomment = db.Comments.Where(x => x.PostID == postid).ToList().Count;
                    var com = totalcomment <= 1 ? " Comment" : " Comments";
                    Posts[i].TotalComment = totalcomment + com;
                    Posts[i].CommentList = db.Comments.Where(x => x.PostID == postid).ToList();
                    var comment = Posts[i].CommentList;
                    if (comment.Count > 0)
                    {

                        for (int j = 0; j < comment.Count; j++)
                        {
                            var ct = comment[j].CreatedBy;
                            comment[j].UserName = db.Users.FirstOrDefault(x => x.UserID == ct).UserName.ToString();
                            comment[j].FormattedDate = comment[j].CreationDate.ToUniversalTime()
                         .ToString("dd'-'MM'-'yyyy");
                            var commentid = comment[j].CommentID;
                            comment[j].TotalLike = db.Likes.Where(x => x.CommentID == commentid).ToList().Count;
                            comment[j].TotalDislike = db.Dislikes.Where(x => x.CommentID == commentid).ToList().Count;

                        }
                    }
                }
            }


            return Posts;
        }
    }
}