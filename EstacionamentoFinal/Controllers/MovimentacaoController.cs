﻿using EstacionamentoFinal.DAL;
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
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(int txtVaga, string txtCPF)
        {
            Movimentacao mov = new Movimentacao
            {
                //Vaga = txtVaga,
                //Veiculo = txtVeiculo;
                //Entrada = dataEntrada;
                //Saida = dataSaida;

            };
            MovimentacaoDAO.CadastrarMovimentacao(mov);
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
        public ActionResult Alterar(string txtNome, string txtCPF, int txtId)
        {
            Movimentacao mov = MovimentacaoDAO.BuscarMovimentacaoPorId(txtId);

            //f.Nome = txtNome;
            //f.CPF = txtCPF;

            MovimentacaoDAO.AlterarMovimentacao(mov);
            return RedirectToAction("Index", "Movimentacao");
        }
    }
}