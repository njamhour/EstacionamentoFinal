using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class VagasDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarVaga(List<Vaga> vagas)
        {
            ctx.Vagas.AddRange(vagas);
            ctx.SaveChanges();
        }
        public static List<Vaga> RetornarVagas()
        {
            return ctx.Vagas.Include("Setor").ToList();
        }
        public static Vaga BuscarVagaPorId(int? id)
        {
            return ctx.Vagas.Find(id);
        }
        public static void RemoverVaga(Vaga v)
        {
            ctx.Vagas.Remove(v);
            ctx.SaveChanges();
        }
        public static void AlterarVaga(Vaga v)
        {
            ctx.Entry(v).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        public static Vaga BuscarVagaPorIdentificador(string identificador)
        {
            return ctx.Vagas.Find(identificador);
        }

        public static void AlterarVagaStatus(Vaga v)
        {
            v.Ocupado = !v.Ocupado;
            ctx.Entry(v).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        //public static List<Vaga> BuscarHistoricoVaga(Vaga v)
        //{
        //    return ctx.Vagas.Include("Veiculo").
        //        Include("Movimentacao").
        //        Where(x => x.IdVaga.Equals(v.IdVaga)).ToList();
        //}
        public static List<Vaga> RetornarVagasLivres()
        {
            return ctx.Vagas.Include("Setor").Where(x => x.Ocupado == false).ToList();
        }

        public static Vaga ContarVagas()
        {
            var UltimoRegistro = ctx.Vagas.Max(x => x.IdVaga);
            return ctx.Vagas.FirstOrDefault(x => x.IdVaga == UltimoRegistro);

        }

    }
}