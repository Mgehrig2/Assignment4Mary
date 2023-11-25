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
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 2;
            if (!IsPostBack)
            {
                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MEG11\\OneDrive\\Desktop\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
                dbcon = new DataClasses1DataContext(connString);

                var result = from Instructor in dbcon.Instructors
                             orderby Instructor.InstructorFirstName, Instructor.InstructorLastName
                             select new { Name = Instructor.InstructorFirstName + " " + Instructor.InstructorLastName };
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "InstructorID";

                DropDownList1.DataSource = result;
                DropDownList1.DataBind();
                             
            }
            //int id = Extra.nonSpecificID;

            dbcon = new DataClasses1DataContext(connString);
            //var all = from Section in dbcon.Sections
            //          where Section.Instructor_ID == 2
            //          select Section;
            //if(DropDownList1.SelectedValue != null)
            //{
            //     id = Extra.nonSpecificID;
            //    //id = 2;

            //    var query = from Section in dbcon.Sections
            //                from Members in dbcon.Members
            //                where Section.Instructor_ID == id && Section.Member_ID == Members.Member_UserID
            //                select Section;

            //    GridView1.DataSource = query;
            //    GridView1.DataBind();

            //    //TextBox1.Text = "Query Successful!";
            //}

            //GridView1.DataSource = all;
            //GridView1.DataBind();
        }
        public static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MEG11\\OneDrive\\Desktop\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext dbcon;


        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList1.SelectedValue);

            Extra.nonSpecificID = id;
            //var query = from Section in dbcon.Sections
            //            from Members in dbcon.Members
            //            where Section.Instructor_ID == id && Section.Member_ID == Members.Member_UserID
            //            select new { Section.SectionName, Members.MemberFirstName, Members.MemberLastName }; ;
            //GridView1.DataSource = query;
            //GridView1.DataBind();
            var all = from Section in dbcon.Sections
                      where Section.Instructor_ID == id
                      select Section;
            GridView1.DataSource = all;
            GridView1.DataBind();
            TextBox1.Text = "Query Successful!";
        }
    }
}