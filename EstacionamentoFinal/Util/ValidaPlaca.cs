using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EstacionamentoFinal.Util
{
    public class ValidaPlaca
    {
        public static bool PlacaValida(string Placa)
        {
            Regex rx = new Regex(@"^[a-zA-Z]{3}\-\d{4}$");
            if (Placa != null)
            {
                if (rx.IsMatch(Placa))
                {
                    return true;
                }
            }
            return false;
        }
    }
}