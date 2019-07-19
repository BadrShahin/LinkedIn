using LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Controllers
{
    public class ProfileController : Controller
    {
        LinkedInDBContext Context;

        Member user;
        public ProfileController()
        {
            Context = new LinkedInDBContext();
        }
        // GET: Profile
        public ActionResult Index()
        {
            user = Session["user"] as Member;
            Session["Address"] = Context.Addresses.ToList().FirstOrDefault(x => x.member_id == user.member_id);
            if (Context.Experiences.ToList().FirstOrDefault(x=>x.member_id == user.member_id) != null)
            {
                TempData["Experience"] = Context.Experiences.ToList().FindAll(x => x.member_id == user.member_id);
            }
            if (Context.Educations.ToList().FirstOrDefault(x => x.member_id == user.member_id) != null)
            {
                TempData["Education"] = Context.Educations.ToList().FindAll(x => x.member_id == user.member_id);
            }
            return View(user);
        }

        public ActionResult GetProfile(int id)
        {
            Member member = Context.Members.FirstOrDefault(x => x.member_id == id);

            Session["Address"] = Context.Addresses.ToList().FirstOrDefault(x => x.member_id == member.member_id);
            if (Context.Experiences.ToList().FirstOrDefault(x => x.member_id == member.member_id) != null)
            {
                TempData["Experience"] = Context.Experiences.ToList().FindAll(x => x.member_id == member.member_id);
            }
            if (Context.Educations.ToList().FirstOrDefault(x => x.member_id == member.member_id) != null)
            {
                TempData["Education"] = Context.Educations.ToList().FindAll(x => x.member_id == member.member_id);
            }
            return View(member);
        }

        // Edit: Profile
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var member = Context.Members.ToList().FirstOrDefault(m => m.member_id == id);
            return PartialView(member);
        }

        [HttpPost]
        public ActionResult Edit(Member member, Address address, HttpPostedFileBase profile_image)
        {
            if (ModelState.IsValid)
            {
                if (profile_image != null)
                {
                    profile_image.SaveAs(Server.MapPath("~/LayoutResources/images/" + profile_image.FileName));
                    member.profile_image = ("/LayoutResources/images/" + profile_image.FileName) as string;
                }
                else
                {
                    member.profile_image = Session["user_profile_image"] as string;
                    //member.profile_image = ("/LayoutResources/images/user.png") as string;
                }
                Context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                Address add= Session["Address"] as Address;
                address.Address_id = add.Address_id;
                address.member_id = add.member_id;
                Context.Entry(address).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                Session["user"] = member;
                return PartialView(member);
            }
            else
            {
                return PartialView(member);
            }
        }


        Member member;
        // Add User Experience 
        [HttpGet]
        public ActionResult AddExperience(int id)
        {
            member = Context.Members.ToList().FirstOrDefault(m => m.member_id == id);
            return PartialView(new Experience());
        }

        [HttpPost]
        public ActionResult AddExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                user = Session["user"] as Member;
                experience.member_id = user.member_id;
                Context.Entry(experience).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
                return PartialView(member);
            }
            else
            {
                return PartialView(member);
            }
        }

        //Edit Experience Action
        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            Experience experience = Context.Experiences.ToList().FirstOrDefault(ex => ex.experience_id == id);
            return PartialView(experience);
        }

        [HttpPost]
        public ActionResult EditExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                user = Session["user"] as Member;
                experience.member_id = user.member_id;
                Context.Entry(experience).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return PartialView(member);
            }
            else
            {
                return PartialView(member);
            }
        }

        // Add User Eduction 
        [HttpGet]
        public ActionResult AddEducation(int id)
        {
            member = Context.Members.ToList().FirstOrDefault(m => m.member_id == id);
            return PartialView(new Education());
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                user = Session["user"] as Member;
                education.member_id = user.member_id;
                Context.Entry(education).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
                return PartialView(member);
            }
            else
            {
                return PartialView(member);
            }
        }

        //Edit Eduction Action
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            Education education = Context.Educations.ToList().FirstOrDefault(ex => ex.id == id);
            return PartialView(education);
        }

        [HttpPost]
        public ActionResult EditEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                user = Session["user"] as Member;
                education.member_id = user.member_id;
                Context.Entry(education).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return PartialView(member);
            }
            else
            {
                return PartialView(member);
            }
        }

    }
}