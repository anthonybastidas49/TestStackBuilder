using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace SBBL.Catalogs
{
    public class InformationBL
    {
        public const string PROVINCES = "ABUCHXOEWGILRMVNQSPYJKTZ";
        public bool validatePlaca(String placa)
        {
            Regex reg = new Regex("[0-9]");
            try
            {
                if (placa.Length == 7)
                {
                    if (placa.Substring(0, 3).All(char.IsLetter) && placa.Substring(3).All(char.IsDigit))
                    {
                        return PROVINCES.IndexOf(placa[0]) == 0 ? true: false;                    }
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
    }
}
