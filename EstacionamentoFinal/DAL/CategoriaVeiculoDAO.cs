using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class CategoriaVeiculoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<CategoriaVeiculo> RetornarCategoria()
        {
            return ctx.CategoriaVeiculo.ToList();
        }
        public static CategoriaVeiculo BuscarCategoriaPorId(int? id)
        {
            return ctx.CategoriaVeiculo.Find(id);
        }
    }
}