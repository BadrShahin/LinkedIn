using LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Controllers
{
    public class PostController : Controller
    {
        LinkedInDBContext Context;
        Member user;
        public PostController()
        {
            Context = new LinkedInDBContext();
        }

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        /// Get Post 
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Post> posts = Context.Posts.ToList();
            Member current = Session["user"] as Member;
            var con = (from i in Context.Connections
                       where i.member_id == current.member_id && i.accept == 1
                       select i.connection_member_id).ToList();
            var con1=(from i in Context.Connections
                      where i.connection_member_id == current.member_id && i.accept == 1
                      select i.member_id).ToList();

            var union = con1.Union(con);

            
            posts = (Context.Posts.Where(x => union.Contains(x.member_id))).ToList();
            
            foreach(var item in Context.Posts)
            {
                if(item.member_id==current.member_id)
                {
                    posts.Add(item);

                }
            }
            return PartialView(posts);
        }

        ///Create Post
        [HttpGet]
        public ActionResult CreatePost()
        {
            user = Session["user"] as Member;
            return PartialView(new Post());
        }
        [HttpPost]
        public ActionResult CreatePost(Post post, HttpPostedFileBase post_image)
        {
            if (ModelState.IsValid)
            {
                if (post_image != null)
                {
                    post_image.SaveAs(Server.MapPath("~/LayoutResources/images/posts/" + post_image.FileName));
                    post.post_image = ("/LayoutResources/images/posts/" + post_image.FileName) as string;
                }
                user = Session["user"] as Member;
                Random rnd = new Random();
                post.member_id = user.member_id;
                post.post_id = rnd.Next(1, 1000);
                Context.Entry(post).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
            }
            return RedirectToAction("GetAll");
        }

        ///Edit Post
        ///
        [HttpGet]
        public ActionResult EditPost(int id)
        {
            Post post = Context.Posts.FirstOrDefault(x => x.post_id == id);
            return PartialView("EditPost", post);
        }
        [HttpPost]
        public ActionResult EditPost(Post post, HttpPostedFileBase post_image)
        {
            if (ModelState.IsValid)
            {
                if (post_image != null)
                {
                    post_image.SaveAs(Server.MapPath("~/LayoutResources/images/posts/" + post_image.FileName));
                    post.post_image = ("/LayoutResources/images/posts/" + post_image.FileName) as string;
                }
                user = Session["user"] as Member;
                post.member_id = user.member_id;
                Context.Entry(post).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
            }
            return RedirectToAction("GetAll");
        }

        ///Delete Post 
        ///
        [HttpGet]
        public ActionResult DeletePost(int id)
        {
            Post post = Context.Posts.Find(id);
            Context.Entry(post).State = System.Data.Entity.EntityState.Deleted;
            Context.SaveChanges();
            if (post == null)
            {
                return HttpNotFound();
            }
            else
            {
                return PartialView("GetAll", Context.Posts.ToList());
            }
        }

        [HttpGet]
        public ActionResult GetAllComments(int id)
        {
            var comments = Context.Comments.Where(c => c.post_id == id).ToList();
            return PartialView(comments);
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            Member member = Session["user"] as Member;
            return PartialView(new Comment());
        }
        [HttpPost]
        public ActionResult AddComment(string commentContent, int postId)
        {
            Member member = Session["user"] as Member;
            var CommenterId = member.member_id;
            var comment = new Comment();

            Random rnd = new Random();
            comment.comment_id = rnd.Next(1, 1000);
            comment.member_id = CommenterId;
            comment.comment_content = commentContent;
            comment.post_id = postId;

            Context.Comments.Add(comment);
            Context.SaveChanges();

            return RedirectToAction("Index", "Default");
        }
        
        [HttpGet]
        public ActionResult EditComment(int id)
        {

            var comment = Context.Comments.FirstOrDefault(c => c.comment_id == id);
            return PartialView("EditComment", comment);


        }

        [HttpPost]
        public ActionResult EditComment(Comment comment)
        {
            Member member = Session["user"] as Member;
            comment.member_id = member.member_id;
            Context.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public ActionResult DeleteComment(int id)
        {
            Comment comment = Context.Comments.FirstOrDefault(c => c.comment_id == id);
            Context.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
            Context.SaveChanges();
            return PartialView("GetAll", Context.Posts.ToList());
        }

    }
}