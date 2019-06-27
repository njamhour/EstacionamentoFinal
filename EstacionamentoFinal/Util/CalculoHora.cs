using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.Util
{
    public class CalculoHora
    {
        public static double CalcularHora(double Tempo, int? id)
        {
            CategoriaVeiculo cv = CategoriaVeiculoDAO.BuscarCategoriaPorId(id);
            int Horas = (Convert.ToInt32(Tempo) / 60);
            int Minutos = (Convert.ToInt32(Tempo) % 60);
            double Total = (Horas * cv.Valor) + ((Minutos * cv.Valor) / 60);
            double TotalFinal = Math.Round(Total, 2);

            //double Teste = Convert.ToDouble(TotalFinal);

            return TotalFinal;
   
        }
    }
}