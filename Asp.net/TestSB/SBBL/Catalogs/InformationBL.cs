using SBAL.Model;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace SBBL.Catalogs
{
    public class InformationBL
    {
        public const string PROVINCES = "ABUCHXOEWGILRMVNQSPYJKTZ";
        /// <summary>
        /// Method in charge of carrying out the validation of a plate
        /// </summary>
        /// <param name="placa"></param>
        /// <returns>Whether it can circulate</returns>
        public bool validatePlaca(String placa)
        {
            Regex reg = new Regex("[0-9]");
            try
            {
                if (placa.Length == 7)
                {
                    if (placa.Substring(0, 3).All(char.IsLetter) && placa.Substring(3).All(char.IsDigit))
                    {
                        return PROVINCES.IndexOf(placa[0]) >= 0 ? true: false;                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="information"></param>
        /// <returns></returns>
        public bool canCirculate(Information information)
        {
            String allowed;
            try
            {
                if (!this.insideHours("07:00", "09:30", information.dateTime.ToShortTimeString()) &&
                        !this.insideHours("16:00", "19:30", information.dateTime.ToShortTimeString()))
                {
                    return true;
                }
                else
                {
                    switch (Convert.ToInt16(information.dateTime.DayOfWeek))
                    {
                        case 1:
                            allowed = "12";
                            break;
                        case 2:
                            allowed = "34";
                            break;
                        case 3:
                            allowed = "56";
                            break;
                        case 4:
                            allowed = "78";
                            break;
                        case 5:
                            allowed = "90";
                            break;
                        default:
                            return true;
                    }
                    return (allowed.IndexOf(information.lastDigit.ToString()) >= 0) ? false : true;

                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Method in charge of controlling range of hours
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="checkTime"></param>
        /// <returns>If it is within that range or not</returns>
        private bool insideHours(String startTime, String endTime, String checkTime)
        {
            DateTime start = Convert.ToDateTime(startTime);
            DateTime end = Convert.ToDateTime(endTime);
            DateTime check = Convert.ToDateTime(checkTime);
            return check >= start && check <= end;
        }
    }
}
