using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = txtEMAIL.Text;
        string password = txtPASSWORD.Text;
        string[] loginResult = db_SQLDatabase.ExecuteSPWithParameters("PRO_LOGIN",
        new string[] { "@in_EMAIL", "@in_PASSWORD" },
        new string[] { email, password },
        new string[] { "@out_MESSAGE", "@out_USER_ID" });
        if (loginResult[0] == "OK")
        {
            Response.Redirect("Template/basic-table.html");
        }
        else
        {
        }
    }
}