using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class HomePage : System.Web.UI.Page
{
    static SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Initial Catalog=TheDVDExchangeDatabase ;Integrated Security=true");

    protected void Page_Load(object sender, EventArgs e)
    {
        dbConnection.Open();
        //string retString = "Select * from users";
        // SqlCommand getUsers = new SqlCommand(retString, dbConnection);
        // SqlDataReader printUsers = getUsers.ExecuteReader();



        Session["DatabaseConnection"] = dbConnection;
        dbConnection.Close();

    }

    protected void LoadSignUpPage(object sender, EventArgs e)
    {
        Response.Redirect("SignUpPage.aspx");

    }
}