using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
//2/23/17
//Sam Kelsey, Jacob Homanics, Jordyn DiSanzo
//This class opens the database connection and stores into a session
public partial class HomePage : System.Web.UI.Page
{
    public static string message = "nothing";
    //Initializes the dbConnection to the database
    static SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Initial Catalog=TheDVDExchangeDatabase ;Integrated Security=true");
    //Initializes bool that is used to check if the user
    //is currently logged in
    public bool loggedIn = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        //If statement checks to see whether or not to print a message
        if (message != "nothing")
        {
            Response.Write(message);
        }
        //Sets the Session to the value of loggedIn
        Session["loginstatus"] = loggedIn;
        //Opens database Connection
        dbConnection.Open();
        //Sets the session to the dbConnection
        Session["DatabaseConnection"] = dbConnection;
        //Closes dbConnection
        dbConnection.Close();

    }
    //Protected function that redirects user to sign up page
    protected void LoadSignUpPage(object sender, EventArgs e)
    {
        if (loggedIn)
        {
            message = "You are currently logged in!";
            Response.Redirect("HomePage.aspx");
        }
        if (!loggedIn)
        {
            //Redirects to SignUpPage.aspx
            Response.Redirect("SignUpPage.aspx");
        }

    }

    protected void LoadBrowsePage(object sender, EventArgs e)
    {
        if (loggedIn)
        {
            Response.Redirect("BrowsePage.aspx");
        }
        if (!loggedIn)
        {
            message = "You are not logged in!";

            //Redirects to BrowsePage.aspx
            Response.Redirect("HomePage.aspx");

        }
    }
}