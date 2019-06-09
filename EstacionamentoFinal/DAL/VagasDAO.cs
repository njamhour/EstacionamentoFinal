﻿using EstacionamentoFinal.Models;
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

    }
}