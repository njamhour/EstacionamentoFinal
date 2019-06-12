using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoFinal.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ViewBag.Clientes = ClienteDAO.RetornarClientes();
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(string txtNome, string txtCPF)
        {
            Cliente c = new Cliente()
            {
                Nome = txtNome,
                CPF = txtCPF
            };
            ClienteDAO.CadastrarCliente(c);
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Remover(int id)
        {
            ClienteDAO.RemoverCliente(ClienteDAO.BuscarClientePorId(id));
            return RedirectToAction("Index", "Cliente");
        }

        public ActionResult Alterar(int? id)
        {
            ViewBag.Clientes = ClienteDAO.BuscarClientePorId(id);
            return View();
        }

        [HttpPost]
        //string txtCategoria,
        public ActionResult Alterar(string txtNome, string txtCPF, string txtPlaca, string txtModelo, int txtId, int hdnId)
        {
            Cliente c = ClienteDAO.BuscarClientePorId(txtId);

            //c.Nome = txtNome;
            //c.CPF = txtCPF;
            //c.Veiculo.Placa = txtPlaca;
            //c.Veiculo.Modelo = txtModelo;
            //c.Veiculo.IdentificacaoCliente = txtId;
            //c.Veiculo.Categoria = 

            ClienteDAO.AlterarCliente(c);
            return RedirectToAction("Index", "Cliente");
        }
    }
}