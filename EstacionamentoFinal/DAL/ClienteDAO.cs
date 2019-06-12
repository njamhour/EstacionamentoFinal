using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class ClienteDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarCliente(Cliente c)
        {
            ctx.Clientes.Add(c);
            ctx.SaveChanges();
        }

        public static List<Cliente> RetornarClientes()
        {
            return ctx.Clientes.ToList();
        }

        public static Cliente BuscarClientePorCpf(string CPF)
        {
            return ctx.Clientes.Find(CPF);
        }

        public static Cliente BuscarClientePorId(int? id)
        {
            return ctx.Clientes.Find(id);
        }

        public static void RemoverCliente(Cliente c)
        {
            ctx.Clientes.Remove(c);
            ctx.SaveChanges();
        }

        public static void AlterarCliente(Cliente c)
        {
            ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}