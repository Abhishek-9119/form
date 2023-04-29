using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace feedback_form.Controllers
{
    public class HomeController : Controller
    {
        private object dt;

        public int Total_submission { get; private set; }
        public int Total_stu { get; private set; }
        public ActionResult login_form(User user)
        {

            return View();
        }
        public ActionResult fetchall()
        {
            List<User> list1 = new List<User>();
            string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` order by display_by asc";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    id = dt.Rows[i]["id"].ToString(),
                    category = dt.Rows[i]["category"].ToString(),
                    hostelorcourse = dt.Rows[i]["course"].ToString(),
                    branch = dt.Rows[i]["branch"].ToString(),
                    session = dt.Rows[i]["session"].ToString(),
                    q_type = dt.Rows[i]["q_type"].ToString(),
                    rating = dt.Rows[i]["rating"].ToString(),
                    question = dt.Rows[i]["question"].ToString(),
                    display_by = dt.Rows[i]["display_by"].ToString(),
                    //dob = dt.Rows[i]["dob"].GetType().t



                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);

        }

            public ActionResult Index()
        {
          
             Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            
            string rl = (string)Session["RollNo"];
            if (rl==null)
            {
                return RedirectToAction("Index","Abhi");
            }


            return View();
        }
        public ActionResult Testing()
        {
           return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult try1()
        {
            ExecuteMe.DeleteInsertUpdate("insert into demo (name) values('hii')","Demo");
            return View();
        }
        public ActionResult Contact()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            string rl = (string)Session["RollNo"];
            if (rl == null)
            {
                return RedirectToAction("Index", "Abhi");
            }
 
            return View();
        }
        [HttpPost]
        public ActionResult qbysem(User user)
        {
            var date1 = user.s_t.ToString("yyyy-MM-dd");
            var date2 = user.e_d.ToString("yyyy-MM-dd");
            ExecuteMe.DeleteInsertUpdate("insert into feedback_master (category,course,sem,q_id,branch,date_from,date_to) values ('"+user.category+"','"+user.course+"','"+user.sem+"','"+user.q_id+"','"+user.branch+"','"+date1+"','"+date2+"')", "Demo");
           
            return Content("Question apply on successfully");
        }
        
        public ActionResult search1(User user)
        {
            List<User> list1 = new List<User>();
            string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` where category='" + user.category + "' and course='" + user.course + "' and branch='" + user.branch + "' and status='Active'  order by display_by asc";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    id = dt.Rows[i]["id"].ToString(),
                    category = dt.Rows[i]["category"].ToString(),
                    hostelorcourse = dt.Rows[i]["course"].ToString(),
                    branch = dt.Rows[i]["branch"].ToString(),
                    session = dt.Rows[i]["session"].ToString(),
                    q_type = dt.Rows[i]["q_type"].ToString(),
                    rating = dt.Rows[i]["rating"].ToString(),
                    question = dt.Rows[i]["question"].ToString(),
                    display_by = dt.Rows[i]["display_by"].ToString(),

                 });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(User user)
        {
            List<User> list1 = new List<User>();
            string myquery = "SELECT id,category,course,branch,session,q_type,rating,question,display_by FROM `insert_question` where category='"+user.category + "' and course='"+user.course+"' and branch='"+user.branch+"' and status='Active'  order by display_by asc";
            DataTable dt = ExecuteMe.Select(myquery, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new User
                {
                    id = dt.Rows[i]["id"].ToString(),
                    category = dt.Rows[i]["category"].ToString(),
                    hostelorcourse = dt.Rows[i]["course"].ToString(),
                    branch = dt.Rows[i]["branch"].ToString(),
                    session = dt.Rows[i]["session"].ToString(),
                    q_type = dt.Rows[i]["q_type"].ToString(),
                    rating = dt.Rows[i]["rating"].ToString(),
                    question = dt.Rows[i]["question"].ToString(),
                    display_by = dt.Rows[i]["display_by"].ToString(),
 


                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult update(List<User> user)
        {
            foreach (User user1 in user)
            {
                ExecuteMe.DeleteInsertUpdate("update insert_question set display_by='" + user1.display_by + "' where id='" + user1.id + "'", "Demo");
               
            }
            return Content("Update Question Sequence successfully");
        }
        public ActionResult delete(User user)
        {
            
                ExecuteMe.DeleteInsertUpdate("update insert_question set status='In-Active' where id='" + user.id + "'", "Demo");

            
            return Content("Delete Question successfully");
        }
        public ActionResult UpdateFun(User user)
        {
            ExecuteMe.DeleteInsertUpdate("update insert_question set display_by='" + user.display_by + "' where id='"+user.id+"'" , "Demo");
            return Content("Update Question Sequence successfully");
        }
        public ActionResult insertQuestion(List<User> user)
        {
 
            foreach (User user1 in user)
            {
                ExecuteMe.DeleteInsertUpdate("insert into insert_question(category,course,branch,session,q_type,rating,question) values('" + user1.category + "','"+user1.hostelorcourse + "','"+user1.branch+"','"+user1.session+"','" + user1.q_type + "','" + user1.rating + "','" + user1.question + "')", "Demo");

            }


            return Content("insert Question Successfully");
        }
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult FetchRecordctrl2(demo user)
        {
            List<demo> list4 = new List<demo>();
            //string myquery2 = "SELECT id, stu_name as sub_name, course as sub_course, count(if (submitted = 0, submitted, NULL)) as 'Remain_stu' FROM `` where course = '" + user.category + "' and Semester='" + user.Semester + "' and submitted='0' GROUP BY id ";
            //string myquery2 = "SELECT course, COUNT(*) AS 'Total_stu',count(if(sesson22_23A >0, sesson22_23A, NULL)) as 'Total_submission', count(if(sesson22_23A =0, sesson22_23A, NULL)) as 'Pending' FROM `login_table` where type = '1' group by course ";
            //string myquery = "select submitted, id, stu_name,category, course,branch,question,rating,comment, Semester,DATE_FORMAT(datefrom,'%d.%m.%Y')'datefrom',DATE_FORMAT(dateto,'%d.%m.%Y')'dateto', sub_date   FROM `data_analysis` where course='" + user.category + "' and Semester='" + user.Semester + "'";
            string myquery2 = "SELECT course,COUNT(sesson22_23A) AS 'Total_stu', sum(sesson22_23A) as 'Total_submission' , COUNT(sesson22_23A) - SUM(sesson22_23A)  AS 'Pending'  FROM `login_table` where type = '1' group by course union Select 'Total' , count(sesson22_23A)  , sum(sesson22_23A) , COUNT(sesson22_23A) - SUM(sesson22_23A)    from login_table  where type = '1'";
            DataTable dt = ExecuteMe.Select(myquery2, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list4.Add(new demo
                {
                    //Total_stu = dt.Rows[i]["Total_stu"].ToString(),
                    //Total_submission = dt.Rows[i]["Total_submission"].ToString(),
                    //id = (int)dt.Rows[i]["id"],
                    course = dt.Rows[i]["course"].ToString(),
                    Total_stu = dt.Rows[i]["Total_stu"].ToString(),
                    Total_submission = dt.Rows[i]["Total_submission"].ToString(),
                    Pending = dt.Rows[i]["Pending"].ToString(),

                });
            }
            return Json(new { list4 }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult FetchRecordctrl(demo user)
        {
            List<demo> list2 = new List<demo>();
            string que = "SELECT ref_no,q_id,DATE_FORMAT(date_from,'%d-%m-%Y')'date_from',DATE_FORMAT(date_to,'%d-%m-%Y')'date_to' FROM `feedback_master` where course ='" + user.category + "' and Sem = '" + user.Semester + "'  and status = 'Active'";
            DataTable re = ExecuteMe.Select(que, "Demo");

            if (re.Rows.Count > 0)
            {
                int j = re.Rows.Count - 1;
                Session["ref_no"] = re.Rows[j]["ref_no"].ToString();
                Session["q_id"] = re.Rows[j]["q_id"].ToString();
            }
            string rf = (string)Session["ref_no"];
            string qid = (string)Session["q_id"];
            string cou_student = "select count(roll_no) as roll_no ,course,sem from login_table where course ='" + user.category + "' and Sem = '" + user.Semester + "'";
            DataTable re1 = ExecuteMe.Select(cou_student, "Demo");
            if (re1.Rows.Count > 0)
            {
                Session["total_student"] = re1.Rows[0]["roll_no"].ToString();

            }
            string t_s = (string)Session["total_student"];
            int n = 0;
          //  string co_student = "select count(if(sesson22_23A >0, sesson22_23A, NULL)) as 'ref_no' from login_table ";
            string co_student = "select COUNT(DISTINCT roll_no) as submit from feedback_master_student where Ref_no = '" + rf + "' group by roll_no";
            DataTable re2 = ExecuteMe.Select(co_student, "Demo");
            if (re2.Rows.Count > 0)
            {
                for (int i = 0; i < re2.Rows.Count; i++)
                {
                    n++;
                }

                Session["submit_student"] = re2.Rows[0]["submit"].ToString();

            }

            // string s_s = (string)Session["submit_student"];


            int pending = Convert.ToInt32(t_s) - n;

            string r_n = (string)Session["ref_no1"];

            //string myquery1 = "SELECT COUNT(*) AS 'Total_stu',count(if(sesson22_23A >0, sesson22_23A, NULL)) as 'Total_submission', count(if(sesson22_23A =0, sesson22_23A, NULL)) as 'Remain_stu',course,sem FROM `login_table` where course = '" + user.category + "' and Sem= '" + user.Semester + "' ";
            // DataTable dt1 = MyConnection.Select(myquery1, "Demo1");

            //string myquery = "select submitted, id, stu_name, category, course,branch,question,rating,comment, Semester,DATE_FORMAT(datefrom,'%d.%m.%Y')'datefrom',DATE_FORMAT(dateto,'%d.%m.%Y')'dateto', sub_date   FROM `login_table` where course='" + user.category + "' and Sem='" + user.Semester + "'";
            if (re1.Rows.Count > 0 && re.Rows.Count > 0)
            {



                list2.Add(new demo
                {
                    datefrom = re.Rows[0]["date_from"].ToString(),
                    dateto = re.Rows[0]["date_to"].ToString(),
                    Total_stu = re1.Rows[0]["roll_no"].ToString(),
                    // Total_submission= re2.Rows[0]["ref_no"].ToString(),
                    Total_submission = n.ToString(),
                    Remain_stu = pending.ToString(),
                    course = re1.Rows[0]["course"].ToString(),
                    Semester = re1.Rows[0]["sem"].ToString(),


                });
                return Json(new { list2 }, JsonRequestBehavior.AllowGet);
            }
            else
            {


                return Content("no record found");

            }


            //list2.Add(new demo
            //{
            //    datefrom = re.Rows[0]["date_from"].ToString(),
            //    dateto = re.Rows[0]["date_to"].ToString(),
            //    Total_stu = re1.Rows[0]["roll_no"].ToString(),
            //    // Total_submission= re2.Rows[0]["ref_no"].ToString(),
            //    Total_submission = n.ToString(),
            //    Remain_stu = pending.ToString(),
            //    course = re1.Rows[0]["course"].ToString(),
            //    Semester = re1.Rows[0]["sem"].ToString(),


            //});




            //return Json(new { list2 }, JsonRequestBehavior.AllowGet);





        }
        public ActionResult fetch_q()
        {
            List<demo> list3 = new List<demo>();
            string ids = (string)Session["q_id"];
            string[] question_list = ids.Split(',');
            foreach (string lst in question_list)
            {
                string a = lst;
                string myquery1 = "SELECT id,question FROM `insert_question`  where  id='" + a + "' ";
                string myquery2 = "select CAST(AVG(rating)AS DECIMAL(10,1)) as rating FROM  `feedback_master_student` where q_id ='" + a + "'";
                DataTable dt1 = ExecuteMe.Select(myquery1, "Demo");
                DataTable dt2 = ExecuteMe.Select(myquery2, "Demo");
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    list3.Add(new demo
                    {
                        question = dt1.Rows[i]["question"].ToString(),
                        id = dt1.Rows[i]["id"].ToString(),
                        rating = dt2.Rows[i]["rating"].ToString(),

                    });

                }

            }
            return Json(new { list3 }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult fetchtotal(demo user)
        {
            List<demo> lis = new List<demo>();
            string query1 = "select name,course,roll_no from login_table where course ='" + user.category + "' and Sem = '" + user.Semester + "'";
            DataTable dt = ExecuteMe.Select(query1, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lis.Add(new demo
                {
                    Name = dt.Rows[i]["name"].ToString(),
                    Roll_No = dt.Rows[i]["roll_no"].ToString() ,
                    course = dt.Rows[i]["course"].ToString(),
                    //sub_date = dt.Rows[0]["sub_date"].ToString(),

                });
            }
            return Json(new { lis }, JsonRequestBehavior.AllowGet);
            // return View();
        }
        public ActionResult FetchRecordctrl1(demo user)
        {
            List<demo> list1 = new List<demo>();
            string rf = (string)Session["ref_no"];

            string myquery2 = "SELECT course as sub_course, login_table.`Roll_No` as rollnot, login_table.`Name` as namenot from login_table where Type='1' and course='" + user.category + "' and sem='" + user.Semester + "' and login_table.Roll_No not IN(SELECT feedback_master_student.Roll_no from feedback_master_student where feedback_master_student.Ref_no='" + rf + "') ";


            DataTable dt = ExecuteMe.Select(myquery2, "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list1.Add(new demo
                {
                    sub_course = dt.Rows[i]["sub_course"].ToString(),
                    rollnot = dt.Rows[i]["rollnot"].ToString(),
                    namenot = dt.Rows[i]["namenot"].ToString(),

                    //sub_date = dt.Rows[0]["sub_date"].ToString(),
                });
            }
            return Json(new { list1 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult submitstudent(demo user)
        {
            List<demo> li = new List<demo>();
            string rf = (string)Session["ref_no"];

            string myquery2 = "SELECT course as sub_course, login_table.`Roll_No` as roll, login_table.`Name` as namenot,DATE_FORMAT(submitted_date,'%d-%m-%Y')'submitted_date' from login_table where Type='1' and course='" + user.category + "' and sem='" + user.Semester + "' and login_table.Roll_No IN(SELECT feedback_master_student.Roll_no from feedback_master_student where feedback_master_student.Ref_no='" + rf + "') ";
            DataTable dt = ExecuteMe.Select(myquery2, "Demo");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                li.Add(new demo
                {
                    course = dt.Rows[i]["sub_course"].ToString(),
                    Roll_No = dt.Rows[i]["roll"].ToString(),
                    Name = dt.Rows[i]["namenot"].ToString(),
                     submitted = dt.Rows[i]["submitted_date"].ToString(),
                    //sub_date = dt.Rows[0]["sub_date"].ToString(),
                });
            }
            return Json(new { li }, JsonRequestBehavior.AllowGet);

            // return View();
        }





        public class demo
        {
            public string sub_course1 { get; set; }
            public string rollnot { get; set; }
            public string namenot { get; set; }
            public string Pending { get; set; }
            public string Name { get; set; }
            public string sub_course { get; set; }
            public string Roll_No { get; set; }
            public string sem { get; set; }
            public string id { get; set; }
            public string Total_stu { get; set; }
            public string Total_submission { get; set; }
            public string Remain_stu { get; set; }
            public string category { get; set; }
            public string course { get; set; }
            public string branch { get; set; }
            public string rating { get; set; }
            public string question { get; set; }
            public string comment { get; set; }
            // public string semester { get; set; }
            public string submitted { get; set; }
            public string datefrom { get; set; }
            public string dateto { get; set; }
            public string Semester { get; set; }
            public string sub_name1 { get; set; }
            public string sesson22_23A { get; set; }
        }

        public class User
        {
            public string id
            {
                get;set;
            }
            public string course
            {
                get;
                set;
            }
            public string category { get; set; }
            public string hostelorcourse { get; set; }
            public string q_type { get; set; }
            public string branch { get; set; }
            public string question { get; set; }
            public string session { get; set; }
            public string rating { get; set; }
            public string display_by { get; set; }
            public string hostel { get; set;}
            public string sem { get; set; }
            public string q_id { get; set; }
            public DateTime s_t { get; set; }

            public DateTime e_d { get; set; }

        }
    }
}