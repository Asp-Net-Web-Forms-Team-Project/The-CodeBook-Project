namespace TheCodeBookProject.Web.App
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();
        }

        void Application_Error()
        {
            // Uncomment for better user experience

            //Exception error = this.Server.GetLastError();
            //if (error is HttpException)
            //{
            //    this.Response.Redirect("~/ErrorPages/NotFound.aspx");
            //}

            //this.Server.ClearError();
        }
    }
}