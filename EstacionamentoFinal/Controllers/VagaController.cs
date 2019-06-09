using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoFinal.Controllers
{
    public class VagaController : Controller
    {
        // GET: Vaga
        public ActionResult Index()
        {
            ViewBag.Vagas = VagasDAO.RetornarVagas();
            return View();
        }
        public ActionResult Cadastrar()
        {
            ViewBag.Setor = new SelectList(SetorDAO.RetornarSetor(), "IdSetor", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(int? Setor, int txtQuantidade)
        {
            Setor s = SetorDAO.BuscarSetorPorId(Setor);
            List<Vaga> vagas = new List<Vaga>();
            for (int i = 1; i <= txtQuantidade; i++)
            {
                Vaga vaga = new Vaga
                {
                    Setor = s,
                    Ocupado = false
                };
                vagas.Add(vaga);
            }
            VagasDAO.CadastrarVaga(vagas);



            return RedirectToAction("Index", "Vaga");
        }
        public ActionResult Remover(int? id)
        {
            VagasDAO.RemoverVaga(VagasDAO.BuscarVagaPorId(id));
            return RedirectToAction("Index", "Vaga");
        }
        public ActionResult Alterar(int? id)
        {
            ViewBag.Vagas = VagasDAO.BuscarVagaPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult Alterar(string txtIdentificador, int txtId, int hdnId)
        {
            Vaga v = VagasDAO.BuscarVagaPorId(txtId);

            //v.Identificador = txtIdentificador;
            VagasDAO.AlterarVaga(v);
            return RedirectToAction("Index", "Vaga");
        }
    }
}