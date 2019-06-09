using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class MovimentacaoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarMovimentacao(Movimentacao mov)
        {
            ctx.Movimentacoes.Add(mov);
            ctx.SaveChanges();
        }

        public static List<Movimentacao> RetornarMovimentacoes()
        {
            return ctx.Movimentacoes.ToList();
        }

        public static void RemoverMovimentacao(Movimentacao mov)
        {
            ctx.Movimentacoes.Remove(mov);
            ctx.SaveChanges();
        }
        public static void AlterarMovimentacao(Movimentacao mov)
        {
            ctx.Entry(mov).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        public static Movimentacao BuscarMovimentacaoPorId(int? id)
        {
            return ctx.Movimentacoes.Find(id);
        }
    }
}