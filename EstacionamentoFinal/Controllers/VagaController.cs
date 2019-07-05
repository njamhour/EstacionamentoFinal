using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult Cadastrar(int Setor, int txtQuantidade)
        {
            Setor s = SetorDAO.BuscarSetorPorId(Setor);
            int txtSetor = s.IdSetor;
            List<Vaga> v = new List<Vaga>();
            int CountVaga = 0;
            v = VagasDAO.ContarVagasPorSetor(txtSetor);
            //Console.WriteLine(v);
            if (v.Count != 0)
            { 
                var UltimaVaga = v.LastOrDefault();
                //Console.WriteLine(x);
                //Console.WriteLine(v);
                string txtUltimaVaga = UltimaVaga.Identificador;
                var LastVagaInt = string.Join("", txtUltimaVaga.ToCharArray().Where(Char.IsDigit));
                CountVaga = Convert.ToInt32(LastVagaInt);
            }
            
            //string TotalVagas = v.ToString();

            // ########################################
            //string UltimaVaga = v.Identificador;
            //var UltimaVagaInt = string.Join("", UltimaVaga.ToCharArray().Where(Char.IsDigit));
            //int CountVaga = Convert.ToInt32(UltimaVagaInt);
            // ########################################
            //TotalVagas = Regex.Match(TotalVagas, @"\d+").Value;
            //int TotalVagasInt = Int32.Parse(TotalVagas);
            //Console.WriteLine(Teste);

            List<Vaga> vagas = new List<Vaga>();
            //int abc = Convert.ToInt32(VagasDAO.ContarVagas());

            for (int i = (1 + CountVaga); i <= (txtQuantidade + CountVaga); i++)
            //    for (int i = 1; i <= txtQuantidade; i++)
            {
                Vaga vaga = new Vaga
                {
                    Setor = s,
                    Ocupado = false,
                    Identificador = String.Concat(s.Nome.Substring(0, 1), i)
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

        public ActionResult Historico(int? id)
        {
            ViewBag.Movimentacao = MovimentacaoDAO.RetornarHistoricoMovimentacoesVaga(id);
            
            return View();
        }
    }
}