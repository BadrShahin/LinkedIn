using LinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Controllers
{
    public class ConnectionController : Controller
    {
        private LinkedInDBContext db;
        public ConnectionController()
        {
            db = new LinkedInDBContext();
        }

        // GET: Connections
        public ActionResult Index()
        {
            Member me = Session["user"] as Member;
            var connections = (from i in db.Connections
                               where i.member_id == me.member_id
                               select i.connection_member_id).ToList();

            var connections_member = (from i in db.Connections
                                      where i.connection_member_id == me.member_id
                                      select i.member_id).ToList();

            List<Member> NotInCon = new List<Member>();
            if ((connections.Count() > 0) || (connections_member.Count() > 0))
            {
                foreach (var item in db.Members)
                {
                    var tempconnection = connections.FirstOrDefault(x => x.Value == item.member_id);
                    var tempconnection_member = connections_member.FirstOrDefault(x => x.Value == item.member_id);
                    if ((tempconnection == null && tempconnection_member == null) && item.member_id != me.member_id)
                    {
                        NotInCon.Add(db.Members.FirstOrDefault(x => x.member_id == item.member_id));
                    }
                }
            }
            else
            {
                foreach (var item in db.Members)
                {
                    if (item.member_id != me.member_id)
                    {
                        NotInCon.Add(item);

                    }
                }
            }

            return View(NotInCon);
        }

        public ActionResult request()
        {
            var user = Session["user"] as Member;

            var connections = (from i in db.Connections
                               where i.connection_member_id == user.member_id && i.accept == 0
                               select i.member_id).ToList();

            List<Member> reqs = new List<Member>();
            if ((connections.Count() > 0))
            {
                foreach (var item in db.Members)
                {
                    var tempconnection = connections.FirstOrDefault(x => x.Value == item.member_id);
                    if (tempconnection != null && item.member_id != user.member_id)
                    {
                        reqs.Add(db.Members.FirstOrDefault(x => x.member_id == item.member_id));
                    }
                }
            }
            return View(reqs);
        }

        public ActionResult connect(int id) // الراجل اللي باعت id  //تمام و زي الفل 
        {
            var user = Session["user"] as Member;
            Connection con = new Connection()
            {
                connection_member_id = id,
                member_id = user.member_id,
                date_connection_made = DateTime.Now

            };

            ViewBag.friend = id;
            db.Connections.Add(con);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult accept(int currentid, int senderid)
        {
            var con = db.Connections.FirstOrDefault(x => x.member_id == senderid && x.connection_member_id == currentid).accept = 1;
            db.SaveChanges();
            return RedirectToAction("request");
        }


        public ActionResult remove(int currentid, int senderid)
        {
            var con = db.Connections.FirstOrDefault(x => x.member_id == senderid && x.connection_member_id == currentid);
            if (con == null)
            {
                var con1 = db.Connections.FirstOrDefault(x => x.member_id == currentid && x.connection_member_id == senderid);
                if (con1 != null)
                {
                    db.Connections.Remove(con1);
                    db.SaveChanges();
                }
            }
            else
            {
                db.Connections.Remove(con);
                db.SaveChanges();
            }
            return RedirectToAction("request");
        }

    }
}