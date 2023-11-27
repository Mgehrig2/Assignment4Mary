using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4Mary_Repository
{
    public partial class Instructor1 : System.Web.UI.Page
    {

        public static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MEG11\\source\\repos\\Assignment4Mary\\Assignment4Mary_Repository\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        
        DataClasses1DataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(connString);

            //   string userInstructor=User.Identity.Name;

            string userInstructor = "Anne.Denton";




            //search fir ID in Net Users

           NetUser searchID = (from x in dbcon.NetUsers
                           where x.UserName.Trim() == userInstructor.Trim()
                           select x).First();
            int ID = searchID.UserID;


            Instructor myInstr=(from y in dbcon.Instructors
                                 where y.InstructorID==ID select y).First();

          TextBox1.Text = myInstr.InstructorFirstName+ myInstr.InstructorLastName;



            var query = from x in dbcon.Sections
                       from y in dbcon.Members
                        where x.Instructor_ID == ID && x.Member_ID == y.Member_UserID
                        select new {x.SectionName, y.MemberFirstName,y.MemberLastName }; ;
            GridView1.DataSource = query;
            GridView1.DataBind();





            //if (DropDownList1.SelectedValue != null)
            //{
            //    var query = from Section in dbcon.Sections
            //                from Members in dbcon.Members
            //                where Section.Instructor_ID == ID && Section.Member_ID == Members.Member_UserID
            //                select Section;

            //    GridView1.DataSource = query;
            //    GridView1.DataBind();

            //    //TextBox1.Text = "Query Successful!";
            //}

            //GridView1.DataSource = all;
            //GridView1.DataBind();
        }



        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
          
        }
    }
}