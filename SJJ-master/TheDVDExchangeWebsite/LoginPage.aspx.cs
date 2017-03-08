using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class LoginPage : System.Web.UI.Page
{
    public ErrorMessage em = new ErrorMessage();

   


    public SQLConnections skwal = new SQLConnections();

    public string usernameText;
    public string passwordText;

    public static bool messageEnable = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (ErrorMessage.printMe)
        {
            Response.Write(em.returnMessage());
        }

       

    }



    protected void Login(object sender, EventArgs e)
    {
        skwal.openDatabase();

        usernameText = usernameTextBox.Text;
        passwordText = passwordTextBox.Text;


       if ( skwal.executeLoginCheckCommand(usernameText,passwordText))
        {
            skwal.closeDatabase();
            Response.Redirect("HomePage.aspx");

        }
       else
        {
            skwal.closeDatabase();
            Response.Redirect("LoginPage.aspx");
        }

     
    }
}