using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static feedback_form.Controllers.HomeController;

namespace feedback_form.Controllers
{
    public class newController : Controller
    {
        // GET: new
        public ActionResult Index()
        {
           // ExecuteMe.DeleteInsertUpdate("insert into demo (name) values('ii')", "Demo");
            return View();
        }
        public ActionResult test1()
        {
            return View();
        }

        public ActionResult fetch_record()
        {
            List<User> list1 = new List<User>();
            //string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` where category='" + user.category + "' and course='" + user.course + "' and branch='" + user.branch + "' and status='Active'  order by display_by asc";
            string myquery = "SELECT district,      sum(CASE WHEN Study_Mode = 'Online' THEN 1 ELSE 0 END) AS Online,      SUM(CASE WHEN Study_Mode = 'Offline' THEN 1 ELSE 0 END) AS Offline FROM lead_master GROUP BY district;";
           // string myquery1 = "select count(l1.Study_Mode) as offline,l1.District from lead_master l1 where l1.Study_Mode='Offline' and District !=''  GROUP BY l1.District  ORDER BY l1.district";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            //DataTable dt1 = ExecuteMe.Select(myquery1, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    district = dt.Rows[i]["district"].ToString(),
                    online = dt.Rows[i]["Online"].ToString(),
                    offline = dt.Rows[i]["Offline"].ToString(),
                   

                    //dob = dt.Rows[i]["dob"].GetType().t
                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult fetch_record_course()
        {
            List<User> list2 = new List<User>();
            string myquery = "SELECT tag,      sum(CASE WHEN Study_Mode = 'Online' THEN 1 ELSE 0 END) AS Online,      SUM(CASE WHEN Study_Mode = 'Offline' THEN 1 ELSE 0 END) AS Offline FROM lead_master GROUP BY tag ORDER BY tag;";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list2.Add(new User
                {
                    course = dt.Rows[i]["tag"].ToString(),
                    online = dt.Rows[i]["Online"].ToString(),
                    offline = dt.Rows[i]["Offline"].ToString(),


                    //dob = dt.Rows[i]["dob"].GetType().t
                });
            }
            return Json(new { list2 }, JsonRequestBehavior.AllowGet);
           

        }
        public ActionResult offline(User user)
        {
            List<User> list1 = new List<User>();
            //string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` where category='" + user.category + "' and course='" + user.course + "' and branch='" + user.branch + "' and status='Active'  order by display_by asc";
            string myquery = "select name,tag,district,study_mode from lead_master where district='" + user.district + "' and study_mode='Offline' order by name";
            // string myquery1 = "select count(l1.Study_Mode) as offline,l1.District from lead_master l1 where l1.Study_Mode='Offline' and District !=''  GROUP BY l1.District  ORDER BY l1.district";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            //DataTable dt1 = ExecuteMe.Select(myquery1, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    name = dt.Rows[i]["name"].ToString(),
                    tag = dt.Rows[i]["tag"].ToString(),
                    district = dt.Rows[i]["district"].ToString(),
                    s_mode = dt.Rows[i]["study_mode"].ToString(),


                    //dob = dt.Rows[i]["dob"].GetType().t
                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult onlinebycourse(User user)
        {
            List<User> list1 = new List<User>();
            //string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` where category='" + user.category + "' and course='" + user.course + "' and branch='" + user.branch + "' and status='Active'  order by display_by asc";
            string myquery = "select name,tag,district,study_mode from lead_master where tag='" + user.course + "' and study_mode='Online' order by name";
            // string myquery1 = "select count(l1.Study_Mode) as offline,l1.District from lead_master l1 where l1.Study_Mode='Offline' and District !=''  GROUP BY l1.District  ORDER BY l1.district";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            //DataTable dt1 = ExecuteMe.Select(myquery1, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    name = dt.Rows[i]["name"].ToString(),
                    tag = dt.Rows[i]["tag"].ToString(),
                    district = dt.Rows[i]["district"].ToString(),
                    s_mode = dt.Rows[i]["study_mode"].ToString(),


                    //dob = dt.Rows[i]["dob"].GetType().t
                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);


        }

        public ActionResult offlinebycourse(User user)
        {
            List<User> list1 = new List<User>();
            //string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` where category='" + user.category + "' and course='" + user.course + "' and branch='" + user.branch + "' and status='Active'  order by display_by asc";
            string myquery = "select name,tag,district,study_mode from lead_master where tag='" + user.course + "' and study_mode='Offline' order by name";
            // string myquery1 = "select count(l1.Study_Mode) as offline,l1.District from lead_master l1 where l1.Study_Mode='Offline' and District !=''  GROUP BY l1.District  ORDER BY l1.district";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            //DataTable dt1 = ExecuteMe.Select(myquery1, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    name = dt.Rows[i]["name"].ToString(),
                    tag = dt.Rows[i]["tag"].ToString(),
                    district = dt.Rows[i]["district"].ToString(),
                    s_mode = dt.Rows[i]["study_mode"].ToString(),


                    //dob = dt.Rows[i]["dob"].GetType().t
                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);

            
        }
        public ActionResult online(User user)
        {
            List<User> list1 = new List<User>();
            //string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` where category='" + user.category + "' and course='" + user.course + "' and branch='" + user.branch + "' and status='Active'  order by display_by asc";
            string myquery = "select name,tag,district,study_mode from lead_master where district='"+user.district+"' and study_mode='Online' order by name";
            // string myquery1 = "select count(l1.Study_Mode) as offline,l1.District from lead_master l1 where l1.Study_Mode='Offline' and District !=''  GROUP BY l1.District  ORDER BY l1.district";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            //DataTable dt1 = ExecuteMe.Select(myquery1, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    name = dt.Rows[i]["name"].ToString(),
                    tag = dt.Rows[i]["tag"].ToString(),
                    district = dt.Rows[i]["district"].ToString(),
                    s_mode = dt.Rows[i]["study_mode"].ToString(),


                    //dob = dt.Rows[i]["dob"].GetType().t
                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);
        }
        public class User
        {
            public string name
            {
                get;set;
            }
            public string course
            {
                get; set;
            }
            public string tag { get;set; }
            public string s_mode { get; set; }
            public string id
            {
                get; set;
            }
            public string district
            {
                get;set;
            }
            public string online
            {
                get; set;
            }
            public string offline
            {
                get; set;
            }
        }
    }
}
