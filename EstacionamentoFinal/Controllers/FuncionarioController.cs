using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoFinal.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            ViewBag.Funcionarios = FuncionarioDAO.RetornarFuncionarios();
            ViewBag.DataAtual = DateTime.Now;
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(string txtNome, string txtCPF)
        {
            Funcionario f = new Funcionario
            {
                Nome = txtNome,
                CPF = txtCPF
            };
            FuncionarioDAO.CadastrarFuncionario(f);
            return RedirectToAction("Index", "Funcionario");
        }
        public ActionResult Remover(int? id)
        {
            FuncionarioDAO.RemoverFuncionario(FuncionarioDAO.BuscarFuncionarioPorId(id));
            return RedirectToAction("Index", "Funcionario");
        }

        public ActionResult Alterar(int? id)
        {
            ViewBag.Funcionario = FuncionarioDAO.BuscarFuncionarioPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult Alterar(string txtNome, string txtCPF, int txtId)
        {
            Funcionario f = FuncionarioDAO.BuscarFuncionarioPorId(txtId);

            f.Nome = txtNome;
            f.CPF = txtCPF;

            FuncionarioDAO.AlterarFuncionario(f);
            return RedirectToAction("Index", "Funcionario");
        }
    }
}