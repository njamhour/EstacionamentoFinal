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

        public static Vaga ContarVagas(Vaga v, int id)
        {
            //return ctx.Vagas.Include("Setor").FirstOrDefault(x => x.IdVaga == ctx.Vagas.Include("Setor").Max(x => x.Identificador());

            var UltimoId = ctx.Vagas.Include("Setor").Max(x => x.IdVaga);
            var Teste = Convert.ToInt32(UltimoId);
            return ctx.Vagas.Include("Setor").FirstOrDefault(x => x.IdVaga == Teste && x.Setor.IdSetor.Equals(id));
        }

        public static List<Vaga> ContarVagasPorSetor(int? id)
        {
            //var UltimoId = ctx.Vagas.Include("Setor").Max(x => x.Identificador);
            //int LastId = Convert.ToInt32(UltimoId);
            //return ctx.Vagas.Include("Setor").Where(x => x.Setor.IdSetor == id).FirstOrDefault(x => x.Identificador == LastId);
            return ctx.Vagas.Include("Setor").Where(x => x.Setor.IdSetor == id).ToList();
        }

    }
}