using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string useragent = Request.UserAgent;
            bool ios =
                 (useragent.IndexOf("iPad") > -1 || useragent.IndexOf("iPhone") > -1);

            StreamWriter goo = File.AppendText("c:\\testing.txt");

            goo.WriteLine(Request.UserAgent);
            goo.WriteLine(ios);

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=test.pdf");
            if (ios) Response.Write("<html>");
            Response.BinaryWrite(File.ReadAllBytes("c:\\test.pdf"));
            if (ios) Response.Write("</html>");
            goo.Close();
            Response.End();

           // goo.Close();
        }
    }
}
