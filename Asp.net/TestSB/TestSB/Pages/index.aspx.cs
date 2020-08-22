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
        private Information information;
        private readonly InformationBL bl = new InformationBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                date.Value = DateTime.Now;
            }
            information = new Information();
        }
        /// <summary>
        /// Method in charge of listening to the click event of the search button
        /// </summary>
        /// <param name="sender"> view</param>
        /// <param name="e"> event</param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (bl.validatePlaca(txtPlaca.Text.ToUpper()))
                {
                    information.placa = txtPlaca.Text.ToUpper();
                    information.lastDigit = (int)char.GetNumericValue(txtPlaca.Text[txtPlaca.Text.Length - 1]);
                    information.dateTime = DateTime.Parse(date.Date.ToShortDateString()+" "+time.DateTime.ToShortTimeString());
                    if (bl.canCirculate(information))
                    {
                        this.showMessage("Reusltado","Puede circular, recuerde el horario de 7:00 a 9:30 y 16:00 a 19:30", "~/Content/Images/ok.png");
                    }
                    else
                    {
                        this.showMessage("Reusltado", "NO puede circular", "~/Content/Images/nok.png");
                    }
                }
                else
                {
                    this.showMessage("Error", "Placa Incorrecta", "~/Content/Images/nok.png");
                }
            }
            catch(Exception ex)
            {
                this.showMessage("Error", "Error del servidor", "~/Content/Images/nok.png");
            }
        }
        /// <summary>
        /// Method in charge of listening to the click event of the close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdClose_Click(object sender, EventArgs e)
        {
            poupMensaje.ShowOnPageLoad = false;
        }
        /// <summary>
        /// Feedback method for error messages
        /// </summary>
        /// <param name="title">title of message</param>
        /// <param name="message">name header of message</param>
        /// <param name="image">image of message</param>
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