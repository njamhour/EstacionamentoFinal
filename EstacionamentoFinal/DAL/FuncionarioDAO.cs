using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class FuncionarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarFuncionario(Funcionario f)
        {
            ctx.Funcionarios.Add(f);
            ctx.SaveChanges();
        }

        public static List<Funcionario> RetornarFuncionarios()
        {
            return ctx.Funcionarios.ToList();
        }

        public static void RemoverFuncionario(Funcionario f)
        {
            ctx.Funcionarios.Remove(f);
            ctx.SaveChanges();
        }
        public static void AlterarFuncionario(Funcionario f)
        {
            ctx.Entry(f).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        public static Funcionario BuscarFuncionarioPorId(int? id)
        {
            return ctx.Funcionarios.Find(id);
        }
    }
}