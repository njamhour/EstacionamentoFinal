using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Util
{
    public class EncurtarSetor
    {
        public string LimitarSetor(string input, int max)
        {
            if(!String.IsNullOrEmpty(input) && input.Length > max)
            {
                return input.Substring(0, max);
            }
            return input;
        }
    }
}