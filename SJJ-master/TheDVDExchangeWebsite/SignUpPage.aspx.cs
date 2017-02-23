﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
//2/23/2017
//Jacob Homanics, Sam Kelsey, Jordyn DiSanzo
//This class works in correlation with the SignUpPage.aspx webpage
//Used to create a user and insert them into the database
public partial class SignUpPage : System.Web.UI.Page
{
    public static string message = "nothing";

    public bool loggedIn;

    //Initializes the string variables that will
    //hold the values of the TextBoxes
    public string usernametext;
    public string passwordtext;
    public string emailtext;
    //Initializes an int to be used
    //for how many rows are in the users database
    public int count = 0;

    //Initializes SQL Commands and Connection
    public SqlCommand cmd = new SqlCommand();
    SqlConnection dbConnection = new SqlConnection();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (message != "nothing")
        {
            Response.Write(message);
        }
        loggedIn = (bool)Session["loginstatus"];

       
        //Sets the dbConnection to the dbConnection Session
        dbConnection = (SqlConnection)Session["DatabaseConnection"];
    }

    public void CreateAccount(object sender, EventArgs e)
    {
        Regex thePattern = new Regex(@"[\s]");
        Regex theAlphanumeric = new Regex(@"[\w]");
        Match theMatch;

        //Sets the string variables to the TextBox values
        usernametext = usernameTextBox.Text;
        theMatch = thePattern.Match(usernametext);
        
        if (theMatch.Success)
        {
            message = "Cannot have a space in your username!";
            Response.Redirect("SignUpPage.aspx");
        }
        theMatch = theAlphanumeric.Match(usernametext);
        if (!theMatch.Success)
        {
            message = "Cannot have special characters";
            Response.Redirect("SignUpPage.aspx");
        }
        passwordtext = passwordTextBox.Text;
        theMatch = thePattern.Match(passwordtext);
        if (theMatch.Success)
        {
            message = "Cannot have a space in your password!";
            Response.Redirect("SignUpPage.aspx");
        }
        if (passwordtext.Length > 10)
        {
            message = "Password cannot be longer than 10 characters";
            Response.Redirect("SignUpPage.aspx");
        }

        emailtext = EmailTextBox.Text;
        theMatch = thePattern.Match(emailtext);
        if(theMatch.Success)
        {
            message = "Cannot have a space in your e-mail!";
            Response.Redirect("SignUpPage.aspx");
        }


        //Gets the count of the rows in the users table
        cmd.CommandText = "Select count(*) from users";

        //sets the cmd connection to dbConnection
        cmd.Connection = dbConnection;
        //opens the database
        dbConnection.Open();

        //Sets the int count to the number of rows in the users table
        count = (int)cmd.ExecuteScalar();

        //sets the command text to an insert statement
        cmd.CommandText = "Insert into users (userid, username, userpassword, useremail) values ('" + (count + 1).ToString() + "', '" + usernametext +
            "', '" + passwordtext + "', '" + emailtext + "')";

        //Executes SQL Command
        cmd.ExecuteScalar();
       //Closes database connection
        dbConnection.Close();

        Response.Write("Account created!");

    }
}