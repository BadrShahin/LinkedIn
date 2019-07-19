using LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Controllers
{
    public class DefaultController : Controller
    {
        LinkedInDBContext Context;
        Member user;
        public DefaultController()
        {
            Context = new LinkedInDBContext();
        }

        [HttpGet]
        public ActionResult welcome()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Member member)
        {

            if ((member.email_address != null) && (member.email_password != null))
            {
                user = Context.Members.FirstOrDefault(x => x.email_address == member.email_address && x.email_password == member.email_password);
                if (user != null)
                {
                    Session["user"] = user;
                    Session.Timeout = 30;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["LoginMsg"] = "Incorrect Email or Password !!";

                }
            }

            return View("welcome", member);

        }

        [HttpPost]
        public ActionResult register(Member member)
        {

            if (ModelState.IsValid)
            {

                //if (member.email_address != null)
                //{
                user = Context.Members.FirstOrDefault(x => x.email_address == member.email_address);

                if (user == null)
                {
                    Context.Members.Add(member);
                    member.date_joined = DateTime.Now;
                    Context.SaveChanges();
                    TempData["ID"] = member.member_id;
                    user = Context.Members.FirstOrDefault(x => x.email_address == member.email_address);
                    Session["user"] = user;
                    return RedirectToAction("Address");
                }
                else
                {
                    TempData["RegisterMsg"] = "Email Address Already Exist";
                }
                //}
            }

            return View("welcome", member);

        }

        /// /////////////////////////////// Address
        // GET: Addresses/Create
        public ActionResult Address()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Address(/*[Bind(Include = "Address_id,line_1,line_2,line_3,city,state_country_province,zip_or_postcode,country,other_details")]*/ Address address)
        {
            //int mID = Convert.ToInt32(TempData["ID"]);
            Member member = Session["user"] as Member;
            if (ModelState.IsValid)
            {
                address.member_id = member.member_id;
                Context.Entry(address).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
                Session["Address"] = address;
                return RedirectToAction("personalInfo");
            }
            return View(address);
        }


        /// //////////////////////////////////////////// personal info
        [HttpGet]
        public ActionResult personalInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult personalInfo(Member m)
        {
            //if (ModelState.IsValid)
            //{
            int mID = Convert.ToInt32(TempData["ID"]);
            var member = Context.Members.Single(w => w.member_id == mID);
            member.gender = m.gender;
            member.date_of_birth = m.date_of_birth;
            member.marital_status_description = m.marital_status_description;
            Context.SaveChanges();
            TempData["name"] = m.first_name;
            return RedirectToAction("Index", m);
            //}
            // return View(m);

        }

        // GET: Default
        public ActionResult Index()
        {
            //Session["user"] = user;
            return View();
        }

        public ActionResult Friends()
        {
            Member member = Session["user"] as Member;
            var con1 = Context.Connections.Where(x => x.member_id == member.member_id && x.accept == 1).Select(x => x.connection_member_id).ToList();
            var con2 = Context.Connections.Where(x => x.connection_member_id == member.member_id && x.accept == 1).Select(x => x.member_id).ToList();
            var con = con1.Union(con2);
            Session["isFriend"] = true;
            return PartialView(Context.Members.Where(x => con.Contains(x.member_id)));
        }

        public ActionResult remove(int currentid, int senderid)
        {
            var con = Context.Connections.FirstOrDefault(x => x.member_id == senderid && x.connection_member_id == currentid);
            if (con == null)
            {
                var con1 = Context.Connections.FirstOrDefault(x => x.member_id == currentid && x.connection_member_id == senderid);
                if (con1 != null)
                {
                    Context.Connections.Remove(con1);
                    Context.SaveChanges();
                }
            }
            else
            {
                Context.Connections.Remove(con);
                Context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Search(string searchTxt)
        {
            return View(Context.Members.Where(x => x.first_name.StartsWith(searchTxt) || searchTxt == null).ToList());
        }

            ///Logout 
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("welcome");
        }
    }
}