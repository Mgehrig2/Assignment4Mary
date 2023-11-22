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
            dbcon = new DataContext(connString);
            
        }
        public static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MEG11\\OneDrive\\Desktop\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        DataContext dbcon;
    }
}