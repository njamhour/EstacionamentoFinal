using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class SetorDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Setor> RetornarSetor()
        {
            return ctx.Setor.ToList();
        }

        public static bool CadastrarSetor(Setor s)
        {
            ctx.Setor.Add(s);
            ctx.SaveChanges();
            return true;
        }

        public static Setor BuscarSetorPorNome(Setor s)
        {
            return ctx.Setor.FirstOrDefault(x => x.Nome.Equals(s.Nome));
        }

        public static Setor BuscarSetorPorId(int? id)
        {
            return ctx.Setor.Find(id);
        }

        public static void AlterarSetor(Setor s)
        {
            ctx.Entry(s).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        public static void RemoverSetor(Setor s)
        {
            ctx.Setor.Remove(s);
            ctx.SaveChanges();
        }

    }
}