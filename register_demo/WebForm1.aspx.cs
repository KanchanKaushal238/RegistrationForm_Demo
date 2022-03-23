using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace register_demo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            DataClasses1DataContext student = new DataClasses1DataContext();
            register_student sd = new register_student();
            var duplicate = from s in student.register_students where s.emailid == TextBox3.Text select s.emailid;
            if(duplicate.Count()>0)
            {
                Response.Write("email already exists");
            }
            else
            { 
            sd.emailid = TextBox3.Text; 
            
            sd.rollno = Convert.ToInt32(TextBox1.Text);
            
            sd.username = TextBox2.Text;
            
            sd.password = TextBox4.Text;
            student.register_students.InsertOnSubmit(sd);
            student.SubmitChanges();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
                }
        }
    }
}