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

        public static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MEG11\\source\\repos\\Assignment4Mary\\Assignment4Mary_Repository\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        DataClasses1DataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(connString);

            //   string userMember =User.Identity.Name;

            string userMember = "Ken.Magel";




            //search fir ID in Net Users

            NetUser searchID = (from x in dbcon.NetUsers
                                where x.UserName.Trim() == userMember.Trim()
                                select x).First();
            int ID = searchID.UserID;


            Member myMember = (from y in dbcon.Members
                                  where y.Member_UserID == ID
                                  select y).First();

            TextBox1.Text = myMember.MemberFirstName + " " + myMember.MemberLastName;


            var query = from x in dbcon.Sections
                        from y in dbcon.Instructors
                        where x.Instructor_ID == ID && x.Member_ID == y.InstructorID
                        select new { x.SectionName, x.SectionStartDate, x.SectionFee, y.InstructorFirstName, y.InstructorLastName }; 
            GridView1.DataSource = query;
            GridView1.DataBind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}