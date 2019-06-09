﻿using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class VeiculoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarVeiculo(Veiculo ve)
        {
            if (BuscarVeiculoPorPlaca(ve) == null)
            {
                ctx.Veiculos.Add(ve);
                ctx.SaveChanges();
                return true;
            }
            return false;

        }

        public static List<Veiculo> RetornarVeiculos()
        {
            return ctx.Veiculos.Include("CategoriaVeiculo").ToList();
        }

        public static Veiculo BuscarVeiculoPorPlaca(Veiculo ve)
        {
            return ctx.Veiculos.FirstOrDefault(x => x.Placa.Equals(ve.Placa));
        }

        public static Veiculo BuscarVeiculoPorId(int? id)
        {
            return ctx.Veiculos.Find(id);
        }

        public static void RemoverVeiculo(Veiculo ve)
        {
            ctx.Veiculos.Remove(ve);
            ctx.SaveChanges();
        }

        public static void AlterarVeiculo(Veiculo ve)
        {
            ctx.Entry(ve).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}