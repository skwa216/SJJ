using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class SignUpPage : System.Web.UI.Page
{
    public string usernametext;
    public string passwordtext;
    public string emailtext;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection dbConnection = (SqlConnection)Session["DatabaseConnection"];
        dbConnection.Open();

      //  string retString2 = "Select * from users";
     //   SqlCommand getUsers2 = new SqlCommand(retString2, dbConnection2);
     //   SqlDataReader printUsers2 = getUsers2.ExecuteReader();

      //  if (printUsers2.Read())
      //  {
      //      do
       //     {
       //         Response.Write(printUsers2["userid"] + " ");
      //      } while (printUsers2.Read());
       // }

        dbConnection.Close();
    
}

    public void CreateAccount(object sender, EventArgs e)
    {
        usernametext = usernameTextBox.Text;
        passwordtext = passwordTextBox.Text;
        emailtext = EmailTextBox.Text;
        Response.Write(usernametext);
        Response.Write(passwordtext);
        Response.Write(emailtext);


    }
}