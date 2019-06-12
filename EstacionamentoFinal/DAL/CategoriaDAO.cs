using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoFinal.DAL
{
    public class CategoriaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Categoria> RetornarCategoria()
        {
            return ctx.Categorias.ToList();
        }
        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return ctx.Categorias.Find(id);
        }
    }
}