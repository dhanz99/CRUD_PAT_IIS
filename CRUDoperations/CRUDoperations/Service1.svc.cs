using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUDoperations
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string Insert(InsertUser user)
        {
            string msg;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-5QOEH7MN;Initial Catalog=WCF;Persist Security Info=True;User ID=sa; Password=iDhanzaghnia99");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into dbo.UserTab (Name, Email) values(@Name, @Email)", con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            int g = cmd.ExecuteNonQuery();
            if (g == 1)
            {
                msg = "Successfuly Inserted";
            }
            else
            {
                msg = "Failed to Insert";
            }
            return msg;

        }


        public gettestdata GetInfo()
        {
            gettestdata g = new gettestdata();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-5QOEH7MN;Initial Catalog=WCF;Persist Security Info=True;User ID=sa; Password=iDhanzaghnia99");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from dbo.UserTab", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("mytab");
            da.Fill(dt);
            g.usertab = dt;
            return g;
        }

        public string Update(UpdateUser u)
        {
            string Message = "";
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-5QOEH7MN;Initial Catalog=WCF;Persist Security Info=True;User ID=sa; Password=iDhanzaghnia99");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update dbo.UserTab set Name = @Name, Email = @Email where UserId= @UserId", con);
            cmd.Parameters.AddWithValue("@UserId", u.UID);
            cmd.Parameters.AddWithValue("@name", u.Name);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                Message = "Successfuly Updated";
            }
            else
            {
                Message = "Failed to Update";
            }
            return Message;
        }

        public string Delete(DeleteUser d)
        {
            string msg = "";
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-5QOEH7MN;Initial Catalog=WCF;Persist Security Info=True;User ID=sa; Password=iDhanzaghnia99");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete dbo.UserTab where UserId = @UserId", con);
            cmd.Parameters.AddWithValue("@UserId", d.UID);
            int res = cmd.ExecuteNonQuery();
            if (res == 1)
            {
                msg = "Successfully deleted";
            }
            else
            {
                msg = "Failed to deleted";
            }
            return msg;
        }
    }
}