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

        public static bool CadastrarCategoria(CategoriaVeiculo cv)
        {
            ctx.CategoriaVeiculo.Add(cv);
            ctx.SaveChanges();
            return true;
        }

        public static void RemoverCategoria(CategoriaVeiculo cv)
        {
            ctx.CategoriaVeiculo.Remove(cv);
            ctx.SaveChanges();
        }

        public static void AlterarCategoria(CategoriaVeiculo cv)
        {
            ctx.Entry(cv).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}