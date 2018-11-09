<%@ WebHandler Language="C#" Class="logout" %>

using System;
using System.Web;
using System.Web.Security;

public class logout : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
	//	Cookie.CurrentUser = null;
        FormsAuthentication.SignOut();
        context.Response.Redirect("login.aspx");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}