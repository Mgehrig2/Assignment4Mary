using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4Mary_Repository
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(connString);
            //TextBox1.Text = "Hello User!";

        }
        public static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MEG11\\OneDrive\\Desktop\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext dbcon;

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(connString);

            int id = Convert.ToInt32(DropDownList1.SelectedValue);

            var memberQueryFirst = from Members in dbcon.Members
                                   where Members.Member_UserID == id
                                   select Members.MemberFirstName;
            var memberQueryLast = from Members in dbcon.Members
                                  where Members.Member_UserID == id
                                  select Members.MemberLastName;
            Extra.memberNameFirst = memberQueryFirst.ToString();
            Extra.memberNameLast = memberQueryLast.ToString();
            TextBox1.Text = Extra.memberNameFirst + " " + Extra.memberNameLast;

            var sectionQuery = from Section in dbcon.Sections
                               where Section.Member_ID == id
                               select Section.SectionName;
            string sectionName = sectionQuery.ToString();

            var sectionQueryFee = from Section in dbcon.Sections
                                  where Section.Member_ID == id
                                  select Section.SectionFee;

            var sectionQueryInstructor = from Section in dbcon.Sections
                                         where Section.Member_ID == id
                                         select Section.Instructor_ID;
            Extra.instructorID = Convert.ToInt32(sectionQueryInstructor);
            int instructorID = Extra.instructorID;

            var instructorQueryFirst = from Instructor in dbcon.Instructors
                                       where Instructor.InstructorID == instructorID
                                       select Instructor.InstructorFirstName;
            string instructorFirst = instructorQueryFirst.ToString();
            var instructorQueryLast = from Instructor in dbcon.Instructors
                                      where Instructor.InstructorID == instructorID
                                      select Instructor.InstructorLastName;
            string instructorLast = instructorQueryLast.ToString();

            var ultimateQuery = from Instructor in dbcon.Instructors
                                from Section in dbcon.Sections
                                where Section.Member_ID == id && Instructor.InstructorID == instructorID
                                select new { Section.SectionName, Section.SectionFee, Instructor.InstructorFirstName, Instructor.InstructorLastName };
            GridView1.DataSource = memberQueryFirst;
            GridView1.DataBind();
        }
    }
}