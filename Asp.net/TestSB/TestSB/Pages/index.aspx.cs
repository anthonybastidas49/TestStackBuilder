using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestSB.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            date.Value = DateTime.Now;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            popupShowInfor.ShowOnPageLoad = true;
        }
    }
}