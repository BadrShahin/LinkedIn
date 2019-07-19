using LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Controllers
{
    public class AdminController : Controller
    {
        LinkedInDBContext Context;

        public AdminController()
        {
            Context = new LinkedInDBContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            List<Member> members = (from m in Context.Members
                                   select m).ToList();
            return View(members);
        }

        // Get: Delete User
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Member member = Context.Members.FirstOrDefault(m => m.member_id == id);
            Address address = Context.Addresses.FirstOrDefault(a => a.member_id == member.member_id);
            Experience experience = Context.Experiences.FirstOrDefault(a => a.member_id == member.member_id);
            Education education = Context.Educations.FirstOrDefault(a => a.member_id == member.member_id);
            Context.Entry(member).State = System.Data.Entity.EntityState.Deleted;
            if(address != null)
            {
                Context.Entry(address).State = System.Data.Entity.EntityState.Deleted;
            }
            if(experience != null)
            {
                Context.Entry(experience).State = System.Data.Entity.EntityState.Deleted;
            }
            if(education != null)
            {
                Context.Entry(education).State = System.Data.Entity.EntityState.Deleted;
            }
            Context.SaveChanges();
            List<Member> members = (from m in Context.Members
                                    select m).ToList();
            return View("index", members);
        }

        // Get: User Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            Member member = Context.Members.FirstOrDefault(m => m.member_id == id);
            return View(member);
        }
    }
}