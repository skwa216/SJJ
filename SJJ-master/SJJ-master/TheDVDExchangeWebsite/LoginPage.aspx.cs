using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class LoginPage : System.Web.UI.Page
{
    public SqlCommand cmd = new SqlCommand();
    public SqlDataReader reader;
    SqlConnection dbConnection = new SqlConnection();

    public string usernameText;
    public string passwordText;

    public string message = "nothing";
    public static bool messageEnable = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        dbConnection = (SqlConnection)Session["DatabaseConnection"];



        if (Session["message"] != null)
        {
            message = Session["message"].ToString();
            if (messageEnable)
            {
                Response.Write("<p>" + message + "</p>");

            }
        }

    }



    protected void Login(object sender, EventArgs e)
    {
        dbConnection.Open();

        usernameText = usernameTextBox.Text;
        passwordText = passwordTextBox.Text;
        cmd.Connection = dbConnection;
        cmd.CommandText = "Select * from users where username = " + "'" + usernameText + "'";
        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
           // Response.Write(reader["username"]);
           // Response.Write(reader["userpassword"]);
           // Response.Write(reader["useremail"]);
           if (reader.GetValue(1).ToString() == usernameText && reader.GetValue(2).ToString() == passwordText)
            {
                Session["message"] = "<p>You have been succesfully logged in!</p>";
                dbConnection.Close();
                Session["loginstatus"] = true;
                Response.Redirect("HomePage.aspx");
            }
           else
            {
                messageEnable = true;
                Session["message"] = "Username or password is incorrect";
                dbConnection.Close();

                Response.Redirect("LoginPage.aspx");

            }

        }


        //Executes SQL Command
        // Response.Write(cmd.ExecuteScalar());
        //Closes database connection
        dbConnection.Close();
    }
}