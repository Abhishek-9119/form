using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult name1()
        {
            return View();
        }
        public ActionResult insert(user mo)
        {
            MyConnection.DeleteInsertUpdate("insert INTO insert2(name,father,mother ) values('" + mo.name + "', '" + mo.father + "','" + mo.mother + "')", "Demo");
            return RedirectToAction("name1");

        }
        public ActionResult Fetch8()
        {
            List<user> list8 = new List<user>();
            string myquery8 = "SELECT name,father,mother FROM `insert2`";
            DataTable dt8 = MyConnection.Select(myquery8, "Demo");
            for (int i = 0; i < dt8.Rows.Count; i++)
            {
                list8.Add(new user
                {
                    name = dt8.Rows[i]["name"].ToString(),
                    father = dt8.Rows[i]["father"].ToString(),
                    mother = dt8.Rows[i]["mother"].ToString(),

                });

            }
            return Json(new { list8 }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult check()
        {
            return View();
        }
        public ActionResult student_form()
        {



            List<registration> student = new List<registration>();
            string constr = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select * from student_detaila";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            student.Add(new registration
                            {
                                id = sdr.GetInt32("id"),

                                name = sdr["name"].ToString(),
                                father = sdr["father"].ToString(),
                                mothername = sdr["mothername"].ToString(),

                                email = sdr["email"].ToString(),
                                address = sdr["address"].ToString(),
                                course = sdr["course"].ToString(),
                                contactno = sdr["contactno"].ToString(),
                                status = sdr["status"].ToString()






                            });
                        }
                    }
                    con.Close();
                }
            }

            return View(student);
        }
        public ActionResult addstudent(string name, string email, string father, string contactno,
            string mothername, string address, string course, string status)
        {
            string constr = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "insert into student_detaila(name,email,father,contactno," +
                    "mothername,address,course,status)values(@name,@email,@father,@contactno,@mothername,@address,@course,@status)";

                using (MySqlCommand cmd = new MySqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();
                    //cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@father", father);
                    cmd.Parameters.AddWithValue("@contactno", contactno);
                    cmd.Parameters.AddWithValue("@mothername", mothername);
                    cmd.Parameters.AddWithValue("@course", course);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@status", status);


                    cmd.ExecuteNonQuery();
                    con.Close();

                }



            }
            return View("~/Home/student_form");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentInformation()
        {
            MyConnection.DeleteInsertUpdate("insert INTO ss(name,course) values('kalua','TESTING')");
            string status = "Success";
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public ActionResult student_fetch()
        {
            List<object> list = new List<object>();
            DataTable dt = MyConnection.Select("SELECT * FROM `ss`", "Demo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new
                {
                    Name = dt.Rows[i]["name"].ToString(),
                    FatherName = dt.Rows[i]["couse"].ToString(),


                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MY_FORM()
        {

            return View();
        }

        public ActionResult About()
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            //Response.Cache.SetNoStore();
            //Session["RollNo"] = null;


            return View();

        }
        public ActionResult Logout()
        {

            //Session["RollNo"] = null;
            //string rl = (string)Session["RollNo"];
            //if (rl == null)
            //{
            //    return RedirectToAction("About", "Home");
            //}
            //return View();


            //Session["name"] = "";
            //Session["RollNo"] = "";
            return Content("ok:/Home/About");
            //return View("About");
            //return RedirectToAction("About", "Home");
        }
        //login//
        [HttpPost]
        public ActionResult login(User myvar)
        {



            List<User> list2 = new List<User>();
            string query = "select Roll_No,Password1,Name,course,sem from login_table where Roll_No='" + myvar.RollNo + "' and Password1='" + myvar.Password1 + "'";
            DataTable dt = MyConnection.Select(query, "Demo1");
            if (dt.Rows.Count > 0)
            {
                Session["name"] = dt.Rows[0]["Name"].ToString();
                Session["RollNo"] = dt.Rows[0]["Roll_No"].ToString();
                Session["course"] = dt.Rows[0]["course"].ToString();
                Session["sem"] = dt.Rows[0]["sem"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list2.Add(new User
                    {
                        RollNo = dt.Rows[i]["Roll_No"].ToString(),
                    });
                }
                return Content("ok:/Home/Acadmic");
            }
            else
            {
                return Content("Sorry!  Login-Id / Roll Number And Password Mismatched..");
            }
        }
        public ActionResult Acadmic()

        {
            //string query7 = "select DATE_FORMAT(date_from,'%d-%m-%Y')'date_from',DATE_FORMAT(date_to,'%d-%m-%Y')'date_to' from feedback_master where status='Active'";
            //  DataTable dt7 = MyConnection.Select(query7, "Demo1");
            //   if (dt7.Rows.Count > 0)
            //   {
            //       Session["date_from"] = dt7.Rows[0]["date_from"].ToString();
            //       Session["date_to"] = dt7.Rows[0]["date_to"].ToString();
            //   }
            // string sessionValue1 = Session["date_from"] as string;
            //string sessionValue2 = Session["date_to"] as string;

            ////ViewBag.Variable1 = "sessionValue1";
            //ViewBag.Variable2 = "sessionValue2";
            //return Json(new { value = sessionValue }, JsonRequestBehavior.AllowGet);
            return View();

        }
        //fatch record academic//
        public ActionResult fetch_date(mycls myvar)
        {
            List<User> list0 = new List<User>();
            string sem = (string)Session["sem"];
            string query4 = "select DATE_FORMAT(date_from,'%d-%m-%Y')'date_from',DATE_FORMAT(date_to,'%d-%m-%Y')'date_to' from feedback_master where status='Active' and Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and category='" + myvar.category + "' and sem='" + sem + "' ";
            DataTable dt9 = MyConnection.Select(query4, "Demo1");
            // DataTable dt7 = MyConnection.Select(query7, "Demo1");

            if (dt9.Rows.Count > 0)
            {


                //string fro = dt4.Rows[0]["date_from"].ToString();
                for (int i = 0; i < dt9.Rows.Count; i++)
                {
                    list0.Add(new User
                    {
                        from1 = dt9.Rows[0]["date_from"].ToString(),
                        to1 = dt9.Rows[0]["date_to"].ToString(),
                        con1 = "present",
                    });
                }




            }
            else
            {
                string query5 = "SELECT DATE_FORMAT(date_from,'%d-%m-%Y')'date_from',DATE_FORMAT(date_to,'%d-%m-%Y')'date_to'\r\nFROM feedback_master\r\nWHERE date_from BETWEEN DATE(NOW()) AND DATE(DATE_ADD(NOW(), INTERVAL 1 DAY)) \r\nORDER BY date_from ASC;";
                DataTable dt4= MyConnection.Select(query5, "Demo1");
                if (dt4.Rows.Count > 0)
                {


                   // string fro = dt4.Rows[0]["date_from"].ToString();
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        list0.Add(new User
                        {
                            from1 = dt4.Rows[0]["date_from"].ToString(),
                            to1 = dt4.Rows[0]["date_to"].ToString(),
                            con1 = "comming",
                        });
                    }




                }
            
                else
                {
                    //string query6 = "select DATE_FORMAT(date_from,'%d-%m-%Y')'date_from',DATE_FORMAT(date_to,'%d-%m-%Y')'date_to' FROM feedback_master\r\nWHERE date_from <= DATE_SUB(NOW(), INTERVAL 1 DAY); ";
                    //DataTable dt0 = MyConnection.Select(query6, "Demo1");
                    list0.Add(new User
                    {
                        //from1 = dt0.Rows[0]["date_from"].ToString(),
                        //to1 = dt0.Rows[0]["date_to"].ToString(),
                        con1 = "close",
                
                    });
                }
            }
                

            return Json(new { list0 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult fetch_dateH(mycls myvar1)
        {
            List<User> list9 = new List<User>();
            string sem = (string)Session["sem"];

            string query4 = "select DATE_FORMAT(date_from,'%d-%m-%Y')'date_from',DATE_FORMAT(date_to,'%d-%m-%Y')'date_to' from feedback_master where status='Active' and Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and category='" + myvar1.category1 + "' ";
            DataTable dt4 = MyConnection.Select(query4, "Demo1");

            if (dt4.Rows.Count > 0)
            {
                //string fro = dt4.Rows[0]["date_from"].ToString();
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    list9.Add(new User
                    {
                        from1 = dt4.Rows[0]["date_from"].ToString(),
                        to1 = dt4.Rows[0]["date_to"].ToString(),
                        con3 = "present",


                    });
                }




            }
            else
            {

                string query5 = "SELECT DATE_FORMAT(date_from,'%d-%m-%Y')'date_from',DATE_FORMAT(date_to,'%d-%m-%Y')'date_to'\r\nFROM feedback_master\r\nWHERE date_from BETWEEN DATE(NOW()) AND DATE(DATE_ADD(NOW(), INTERVAL 1 DAY)) \r\nORDER BY date_from ASC;";
                 dt4 = MyConnection.Select(query5, "Demo1");
                if (dt4.Rows.Count > 0)
                {


                    // string fro = dt4.Rows[0]["date_from"].ToString();
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        list9.Add(new User
                        {
                            from1 = dt4.Rows[0]["date_from"].ToString(),
                            to1 = dt4.Rows[0]["date_to"].ToString(),
                            con3 = "comming",
                        });
                    }




                }
                else
                {

                    list9.Add(new User
                    {

                        con3 = "close",

                    });
                }
               
            }


            return Json(new { list9 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult myfun(mycls myvar)
        {
            //string query4 = "select DATE_FORMAT(date_from,'%d.%m.%Y')'date_from',DATE_FORMAT(date_to,'%d.%m.%Y')'date_to' from feedback_master where status='Active'";
            //DataTable dt4 = MyConnection.Select(query4, "Demo1");
            //Session["from1"] = dt4.Rows[0]["date_from"].ToString();
            //String from1 = dt4.Rows[0]["date_from"].ToString();
            // to1 = dt4.Rows[0]["date_to"].ToString();
            //string tod=DateTime.Now.ToString("dd/MM/yyyy");

            //int value = DateTime.Compare(DateTime.Now, DateTime.tod);
            string str;
            str = (string)Session["RollNo"];
            string check = "select sesson22_23A from login_table where roll_no='" + str + "' and sesson22_23A='1' ";
            DataTable dt0 = MyConnection.Select(check, "Demo1");
            if (dt0.Rows.Count > 0)
            {
              return Content("already");
            }

            List<demo> list2 = new List<demo>();

            // string myquery = "SELECT * FROM `rating` WHERE Date(from1)<=dATE(NOW()) and DATE(NOW()) <= DATE(to1) and Status = 'Active' and  category='" + myvar.category + "' ";

            string cou = (string)Session["course"];
            string sem = (string)Session["sem"];


            string myquery2 = "SELECT course,sem FROM `feedback_master`  where Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and Status = 'Active' and  category='" + myvar.category + "' and sem='" + sem + "'  ";
            DataTable dt2 = MyConnection.Select(myquery2, "Demo1");

            if (dt2.Rows.Count > 0)
            {
                string c = dt2.Rows[0]["course"].ToString();
                if (c == "All")
                {
                    string myquery3 = "SELECT ref_no,q_id FROM `feedback_master`  where Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and Status = 'Active' and  category='" + myvar.category + "' and sem='" + sem + "'  ";
                    dt2 = MyConnection.Select(myquery3, "Demo1");
                    if (dt2.Rows.Count > 0)
                    {
                        Session["ref_no"] = dt2.Rows[0]["ref_no"].ToString();
                        Session["q_id"] = dt2.Rows[0]["q_id"].ToString();


                        string ids = (string)Session["q_id"];
                        string[] question_list = ids.Split(',');
                        foreach (string lst in question_list)
                        {
                            string a = lst;
                            string myquery1 = "SELECT id,question FROM `insert_question`  where  id='" + a + "' ";

                            DataTable dt1 = MyConnection.Select(myquery1, "Demo1");
                            list2.Add(new demo
                            {
                                question = dt1.Rows[0]["question"].ToString(),
                                id = dt1.Rows[0]["id"].ToString(),

                                // q_type = dt.Rows[i]["rating"].ToString(),



                            });

                        }
                    }
                }
                else
                {
                    string myquery = "SELECT ref_no,q_id,course FROM `feedback_master`  where Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and Status = 'Active' and  category='" + myvar.category + "' and course='" + cou + "' and sem='" + sem + "'  ";
                    DataTable dt = MyConnection.Select(myquery, "Demo1");
                    if (dt.Rows.Count > 0)
                    {
                        Session["ref_no"] = dt.Rows[0]["ref_no"].ToString();
                        Session["q_id"] = dt.Rows[0]["q_id"].ToString();


                        string ids = (string)Session["q_id"];
                        string[] question_list = ids.Split(',');
                        foreach (string lst in question_list)
                        {
                            string a = lst;
                            string myquery1 = "SELECT id,question FROM `insert_question`  where  id='" + a + "' ";

                            DataTable dt1 = MyConnection.Select(myquery1, "Demo1");
                            list2.Add(new demo
                            {
                                question = dt1.Rows[0]["question"].ToString(),
                                id = dt1.Rows[0]["id"].ToString(),
                                // q_type = dt.Rows[i]["rating"].ToString(),



                            });

                        }
                    }
                }
            }

            //string myquery = "SELECT id,question FROM `insert_question`  where Status = 'Active' and  category='" + myvar.category + "' order by display_by asc ";
            //    string myquery = "SELECT ref_no,q_id,course FROM `feedback_master`  where Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and Status = 'Active' and  category='" + myvar.category + "' and course='"+cou+"' and sem='"+sem+"'  ";
            //DataTable dt = MyConnection.Select(myquery, "Demo1");





            //if (dt.Rows.Count > 0)
            //{
            //    Session["ref_no"] = dt.Rows[0]["ref_no"].ToString();
            //    Session["q_id"] = dt.Rows[0]["q_id"].ToString();


            //    string ids = (string)Session["q_id"];
            //    string[] question_list = ids.Split(',');
            //    foreach (string lst in question_list)
            //    {
            //        string a = lst;
            //        string myquery1 = "SELECT id,question FROM `insert_question`  where  id='" + a + "' ";

            //        DataTable dt1 = MyConnection.Select(myquery1, "Demo1");
            //        list2.Add(new demo
            //        {
            //            question = dt1.Rows[0]["question"].ToString(),
            //            id = dt1.Rows[0]["id"].ToString(),
            //            // q_type = dt.Rows[i]["rating"].ToString(),



            //        });

            //    }
            //}

            //DataTable dt = MyConnection.Select(myquery, "Demo");

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        list2.Add(new demo
            //        {
            //            question = dt.Rows[i]["Question"].ToString(),
            //            id = dt.Rows[i]["id"].ToString(),
            //            // q_type = dt.Rows[i]["rating"].ToString(),



            //        });
            //    }
            return Json(new { list2 }, JsonRequestBehavior.AllowGet);
            //return View();

        }
        //fatch record hostel//
        public ActionResult myfun2(mycls myvar1)
        {
            //string query = "select DATE_FORMAT(from1,'%d.%m.%Y')'from1',DATE_FORMAT(to1,'%d.%m.%Y')'to1' from rating where status='Active'";
            //DataTable dt1 = MyConnection.Select(query, "Demo");
            //String from1 = dt1.Rows[0]["from1"].ToString();
            //String to1 = dt1.Rows[0]["to1"].ToString();
            //string tod=DateTime.Now.ToString("dd/MM/yyyy");

            //int value = DateTime.Compare(DateTime.Now, DateTime.tod);
            string str;
            str = (string)Session["RollNo"];
            string check = "select session22_23H from login_table where roll_no='" + str + "' and session22_23H='1' ";
            DataTable dt0 = MyConnection.Select(check, "Demo1");
            if (dt0.Rows.Count > 0)
            {
                return Content("already");
            }

            List<demo> list3 = new List<demo>();

            string myquery = "SELECT ref_no,q_id FROM `feedback_master`  where Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and Status = 'Active' and  category='" + myvar1.category1 + "'  ";
            DataTable dt = MyConnection.Select(myquery, "Demo1");
            if (dt.Rows.Count > 0)
            {
                Session["ref_no1"] = dt.Rows[0]["ref_no"].ToString();
                Session["q_id1"] = dt.Rows[0]["q_id"].ToString();


                string ids = (string)Session["q_id1"];
                string[] question_list = ids.Split(',');
                foreach (string lst in question_list)
                {
                    string a = lst;
                    string myquery1 = "SELECT id,question FROM `insert_question`  where  id='" + a + "' ";

                    DataTable dt1 = MyConnection.Select(myquery1, "Demo1");
                    list3.Add(new demo
                    {
                        question = dt1.Rows[0]["question"].ToString(),
                        id = dt1.Rows[0]["id"].ToString(),
                        // q_type = dt.Rows[i]["rating"].ToString(),



                    });

                }
            }


            return Json(new { list3 }, JsonRequestBehavior.AllowGet);

            //string myquery = "SELECT * FROM `rating` WHERE Date(from1)<=dATE(NOW()) and DATE(NOW()) <= DATE(to1) and Status = 'Active' and  category='" + myvar1.category1 + "' ";

            //string myquery = "SELECT ref_no,q_id FROM `feedback_master`  where Date(date_from)<=dATE(NOW()) and DATE(NOW()) <= DATE(date_to) and Status = 'Active' and  category='" + myvar1.category1 + "'  ";
            //DataTable dt = MyConnection.Select(myquery, "Demo1");
            //Session["ref_no"] = dt.Rows[0]["ref_no"].ToString();
            //Session["q_id"] = dt.Rows[0]["q_id"].ToString();


            //string ids = (string)Session["q_id"];
            //string[] question_list = ids.Split(',');
            //foreach (string lst in question_list)
            //{
            //    string a = lst;
            //}


            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    list3.Add(new demo
            //    {
            //        question = dt.Rows[i]["Question"].ToString(),
            //        //id = dt.Rows[i]["ref_no"].ToString(),


            //    // q_type = dt.Rows[i]["rating"].ToString(),



            //    });
            //}
            //return Json(new { list3 }, JsonRequestBehavior.AllowGet);

            //return View();
        }
        //insert record acadmic table//

        //[HttpPost]
        public ActionResult myfun1(List<mycls> user)

        {


            string str;
            str = (string)Session["RollNo"];

            string str1;
            str1 = (string)Session["ref_no"];

            string str2;
            str2 = (string)Session["name"];
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string tod = DateTime.Now.ToString("yyyy-MM-dd");
            MyConnection.DeleteInsertUpdate("update login_table set sesson22_23A='1' where Roll_no='" + str + "' ", "Demo1");
            foreach (mycls item in user)
            {
                MyConnection.DeleteInsertUpdate("update login_table set submitted_date='" + tod + "' where roll_no='" + str + "'", "Demo1");
                //MyConnection.DeleteInsertUpdate("insert into 'feedback_master_student' set comment='" + item.comment + "', r_rating='" + item.rating + "', RollNo= '"+str+"' where id='" + item.id + "'", "Demo");
                MyConnection.DeleteInsertUpdate("insert INTO feedback_master_student(ref_no,Roll_no,rating,Comment,submitted_date,submitted_by,submitted_from) values('" + str1 + "','" + str + "','" + item.rating + "','" + item.comment + "'  ,'" + tod + "' ,'" + str2 + "' ,'" + myIP + "' )", "Demo1");


                // MyConnection.DeleteInsertUpdate("update insert_question set comment='" + item.comment + "', r_rating='" + item.rating + "' where id='" + item.id + "'", "Demo") ;
            }
            return Content("feedback submitted successfully");
        }
        //insert record hostel table//
        [HttpPost]
        public ActionResult myfun3(List<mycls> user)
        {
            string str;
            str = (string)Session["RollNo"];
            string str1;
            str1 = (string)Session["ref_no1"];
            string str2;
            str2 = (string)Session["name"];
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string tod = DateTime.Now.ToString("yyyy-MM-dd");
            MyConnection.DeleteInsertUpdate("update login_table set session22_23H='1' where Roll_no='" + str + "' ", "Demo1");
            foreach (mycls item in user)
            {
                //MyConnection.DeleteInsertUpdate("insert into 'feedback_master_student' set comment='" + item.comment + "', r_rating='" + item.rating + "', RollNo= '"+str+"' where id='" + item.id + "'", "Demo");
                MyConnection.DeleteInsertUpdate("insert INTO feedback_master_student(ref_no,Roll_no,rating,Comment,submitted_date,submitted_by,submitted_from) values('" + str1 + "','" + str + "','" + item.rating + "','" + item.comment + "'  ,'" + tod + "' ,'" + str2 + "' ,'" + myIP + "' )", "Demo1");


                // MyConnection.DeleteInsertUpdate("update insert_question set comment='" + item.comment + "', r_rating='" + item.rating + "' where id='" + item.id + "'", "Demo") ;
            }
            return Content("feedback submitted successfully ");
            //foreach (mycls item in user)
            //{
            //    MyConnection.DeleteInsertUpdate("update rating set comment='" + item.comment + "', r_rating='" + item.rating + "' where id='" + item.id + "'", "Demo");


            //    // MyConnection.DeleteInsertUpdate("update insert_question set comment='" + item.comment + "', r_rating='" + item.rating + "' where id='" + item.id + "'", "Demo") ;
            //}
            //return RedirectToAction("Update Record");

        }




    }
}

public class user
{
    public string name { get; set; }

    public string father { get; set; }
    public string mother { get; set; }
}
public class demo
{
    public string from1 { get; set; }

    public string id { get; set; }
    public string category { get; set; }
    public string category1 { get; set; }
    public string Sno { get; set; }
    public string Question1 { get; set; }
    public string Comment { get; set; }
    public string Rating { get; set; }
    public string q_type { get; set; }
    public string question { get; set; }
    public string to1 { get; set; }
    public string rating { get; set; }



}
public class mycls
{
    public string category { get; set; }
    public string from1 { get; set; }
    public string comment { get; set; }
    public string id { get; set; }
    public string rating { get; set; }
    public string category1 { get; set; }
    public string RollNo { get; set; }
    public string to1 { get; set; }
}
public class User
{
    public string to1 { get; set; }
    public string from1 { get; set; }
    public int Id { get; set; }
    public string RollNo { get; set; }
    public string Password1 { get; set; }
    public string con1 { get; set; }
    public string con2 { get; set; }
    public string con3 { get; set; }
}


