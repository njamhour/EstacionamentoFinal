using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoFinal.Controllers
{
    public class MovimentacaoController : Controller
    {
        // GET: Movimentacao
        public ActionResult Index()
        {
            ViewBag.Movimentacoes = MovimentacaoDAO.RetornarMovimentacoes();
            ViewBag.DataAtual = DateTime.Now;
            return View();
        }
        public ActionResult Cadastrar()
        {
            ViewBag.Veiculo = new SelectList(VeiculoDAO.RetornarVeiculosLivres(), "IdVeiculo", "Placa");
            ViewBag.Vaga = new SelectList(VagasDAO.RetornarVagasLivres(), "IdVaga", "Identificador");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(int Veiculo, int Vaga)
        {
            Veiculo ve = VeiculoDAO.BuscarVeiculoPorId(Veiculo);
            Vaga va = VagasDAO.BuscarVagaPorId(Vaga);


            Movimentacao mov = new Movimentacao
            {
                Veiculo = ve,
                Vaga = va,
                Entrada = DateTime.Now,
                Saida = DateTime.Now

            };
            if (va.Ocupado)
            {
                return RedirectToAction("Index", "Movimentacao");
            }
            MovimentacaoDAO.CadastrarMovimentacao(mov);
            VagasDAO.AlterarVagaStatus(va);
            VeiculoDAO.AlterarVeiculoStatus(ve);
            return RedirectToAction("Index", "Movimentacao");
        }
        public ActionResult Remover(int? id)
        {
            MovimentacaoDAO.RemoverMovimentacao(MovimentacaoDAO.BuscarMovimentacaoPorId(id));
            return RedirectToAction("Index", "Movimentacao");
        }

        public ActionResult Alterar(int? id)
        {
            ViewBag.Movimentacao = MovimentacaoDAO.BuscarMovimentacaoPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult Alterar(string txtVeiculo, string txtVaga, string txtEntrada, string txtSaida, int hdnId)
        {

            DateTime dataEntrada = DateTime.ParseExact(txtEntrada, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dataSaida = DateTime.ParseExact(txtSaida, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            Movimentacao mov = MovimentacaoDAO.BuscarMovimentacaoPorId(hdnId);

            mov.Veiculo.Placa = txtVeiculo;
            mov.Vaga.Identificador = txtVaga;
            mov.Entrada = dataEntrada;
            mov.Saida = dataSaida;
            mov.Finalizada = false;
            mov.Pagamento = 0;

            Vaga va = VagasDAO.BuscarVagaPorId(mov.Vaga.IdVaga);
            Veiculo ve = VeiculoDAO.BuscarVeiculoPorId(mov.Veiculo.IdVeiculo);
            MovimentacaoDAO.AlterarMovimentacao(mov);
            VagasDAO.AlterarVagaStatus(va);
            //VeiculoDAO.AlterarVeiculoStatus(ve);
            return RedirectToAction("Index", "Movimentacao");
        }
        public ActionResult Saida(int? id)
        {
            ViewBag.Movimentacao = MovimentacaoDAO.BuscarMovimentacaoPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult Saida(string txtSaida, int txtId)
        {
            Movimentacao mov = MovimentacaoDAO.BuscarMovimentacaoPorId(txtId);

            DateTime dataSaida = DateTime.ParseExact(txtSaida, "dd/MM HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            mov.Saida = dataSaida;

            CategoriaVeiculo cv = CategoriaVeiculoDAO.BuscarCategoriaPorId(mov.Veiculo.CategoriaVeiculo.IdCategoria);
            TimeSpan TempoTeste = (mov.Saida.AddMinutes(1) - mov.Entrada.AddMinutes(1));
            double Minutos = TempoTeste.TotalMinutes;

            //TimeSpan TempoTotal = mov.Saida - mov.Entrada;
            //int Teste = MinutosTotais.Minutes;
            //if(Teste.Minutes > 30)
            double Pagamento = (Util.CalculoHora.CalcularHora(Minutos, cv.IdCategoria));

            mov.Diferenca = Convert.ToInt32(Minutos);
            mov.Pagamento = Pagamento;
            //DateTime EntradaCalculo = mov.Entrada;
            //System.TimeSpan CalculoTempo = dataSaida - EntradaCalculo;
            ////CalculoTempoString

            //double Valor = CalculoTempo

            Vaga va = VagasDAO.BuscarVagaPorId(mov.Vaga.IdVaga);
            Veiculo ve = VeiculoDAO.BuscarVeiculoPorId(mov.Veiculo.IdVeiculo);
            //mov.Pagamento = teste;

            MovimentacaoDAO.AlterarMovimentacao(mov);
            VagasDAO.AlterarVagaStatus(va);
            VeiculoDAO.AlterarVeiculoStatus(ve);
            MovimentacaoDAO.FinalizarMovimentacao(mov);
            
            return RedirectToAction("Index", "Movimentacao");
        }
        public ActionResult Finalizadas()
        {
            ViewBag.Movimentacoes = MovimentacaoDAO.RetornarMovimentacoes();
            ViewBag.DataAtual = DateTime.Now;
            return View();
        }
    }
}