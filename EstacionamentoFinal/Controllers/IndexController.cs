using EstacionamentoFinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoFinal.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Movimentacoes = MovimentacaoDAO.RetornarMovimentacoes();
            ViewBag.VagasLivres = VagasDAO.RetornarVagasLivres();
            ViewBag.VagasTotais = VagasDAO.RetornarVagas();
            ViewBag.Veiculos = VeiculoDAO.RetornarVeiculos();
            return View();
        }
    }
}