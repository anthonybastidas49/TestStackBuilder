using SBAL.Model;
using SBBL.Catalogs;
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
        private Information infomation;
        private readonly InformationBL bl = new InformationBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                date.Value = DateTime.Now;
            }
            infomation = new Information();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (bl.validatePlaca(txtPlaca.Text.ToUpper()))
                {
                    infomation.placa = txtPlaca.Text.ToUpper();
                    infomation.lastDigit = (int)char.GetNumericValue(txtPlaca.Text[txtPlaca.Text.Length - 1]);
                    infomation.dateTime = DateTime.Parse(date.Date.ToShortDateString()+" "+time.DateTime.ToShortTimeString());
                }
                else
                {
                    this.showMessage("Error", "Placa Incorrecta", "~/Content/Images/nok.png");
                }
            }
            catch(Exception ex)
            {
                this.showMessage("Error", "Error del servidor", "~/Content/Images/nok.png");
            }        }

        protected void cmdCerrar_Click(object sender, EventArgs e)
        {
            poupMensaje.ShowOnPageLoad = false;
        }
        private void showMessage(String title,String message, String image)
        {
            try
            {
                poupMensaje.HeaderText = title;
                lblWarning.Text = message;
                imgWarning.ImageUrl = image;
                poupMensaje.ShowOnPageLoad = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}