using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class SignUpPage : System.Web.UI.Page
{
    static SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Initial Catalog=TheDVDExchangeDatabase ;Integrated Security=true");
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void CreateAccount()
    { 

}
}