using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoFinal.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Index()
        {
            ViewBag.Veiculos = VeiculoDAO.RetornarVeiculos();
            return View();
        }

        public ActionResult Cadastrar()
        {
            ViewBag.CategoriaVeiculo = new SelectList(CategoriaVeiculoDAO.RetornarCategoria(), "IdCategoria", "Tamanho");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(int? CategoriaVeiculo, Veiculo v)
        {
            ViewBag.CategoriaVeiculo = new SelectList(CategoriaVeiculoDAO.RetornarCategoria(), "IdCategoria", "Tamanho");

            v.CategoriaVeiculo = CategoriaVeiculoDAO.BuscarCategoriaPorId(CategoriaVeiculo);
            if (VeiculoDAO.CadastrarVeiculo(v))
            {
                return RedirectToAction("Index", "Veiculo");
            }
            return View(v);
        }

        public ActionResult Remover(int? id)
        {
            VeiculoDAO.RemoverVeiculo(VeiculoDAO.BuscarVeiculoPorId(id));
            return RedirectToAction("Index", "Veiculo");
        }
        public ActionResult Alterar(int? id)
        {
            return View(VeiculoDAO.BuscarVeiculoPorId(id));
        }
        [HttpPost]
        public ActionResult Alterar(Veiculo veiculo)
        {
            Veiculo v = VeiculoDAO.BuscarVeiculoPorId(veiculo.IdVeiculo);

            v.Placa = veiculo.Placa;
            v.Cor = veiculo.Cor;
            v.Modelo = veiculo.Modelo;
            v.Fabricante = veiculo.Fabricante;

            VeiculoDAO.AlterarVeiculo(v);
            return RedirectToAction("Index", "Veiculo");
        }
    }
}