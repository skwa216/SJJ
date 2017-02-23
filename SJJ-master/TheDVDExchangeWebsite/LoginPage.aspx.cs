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
    SqlConnection dbConnection = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        dbConnection = (SqlConnection)Session["DatabaseConnection"];

    }



    protected void Login(object sender, EventArgs e)
    {

    }
}