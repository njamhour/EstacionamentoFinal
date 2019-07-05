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
            if (Util.ValidaPlaca.PlacaValida(v.Placa))
            {
                if (VeiculoDAO.CadastrarVeiculo(v))
                {
                    return RedirectToAction("Index", "Veiculo");
                }
                return View(v);
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
            ViewBag.Veiculos = VeiculoDAO.BuscarVeiculoPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult Alterar(string txtPlaca, string txtCor, string txtModelo, string txtFabricante, int txtId)
        {
            Veiculo v = VeiculoDAO.BuscarVeiculoPorId(txtId);

            v.Placa = txtPlaca;
            v.Cor = txtCor;
            v.Modelo = txtModelo;
            v.Fabricante = txtFabricante;

            //if(!v.Estacionado)
            //{
            if (Util.ValidaPlaca.PlacaValida(v.Placa))
            {
                VeiculoDAO.AlterarVeiculo(v);
                return RedirectToAction("Index", "Veiculo");
            }
            else
            {
                return RedirectToAction("Index", "Veiculo");
            }

            
        }

        public ActionResult IndexCategoria()
        {
            ViewBag.VeiculosCategoria = CategoriaVeiculoDAO.RetornarCategoria();
            return View();
        }
        public ActionResult CadastrarCategoria()
        {
            //ViewBag.VeiculosCategoria = VeiculoDAO.RetornarVeiculosCategoria();
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarCategoria(string Tamanho, string Valor)
        {
            CategoriaVeiculo cv = new CategoriaVeiculo();
            double ValorConvertido = Convert.ToDouble(Valor);

            cv.Tamanho = Tamanho;
            cv.Valor = ValorConvertido;
            CategoriaVeiculoDAO.CadastrarCategoria(cv);
            return RedirectToAction("IndexCategoria", "Veiculo");
            
        }
        public ActionResult RemoverCategoria(int? id)
        {
            CategoriaVeiculoDAO.RemoverCategoria(CategoriaVeiculoDAO.BuscarCategoriaPorId(id));
            return RedirectToAction("IndexCategoria", "Veiculo");
        }
        public ActionResult AlterarCategoria(int? id)
        {
            ViewBag.CategoriaVeiculos = CategoriaVeiculoDAO.BuscarCategoriaPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult AlterarCategoria(int txtId, string txtValor, string txtTamanho)
        {
            double dValor = Convert.ToDouble(txtValor);
            CategoriaVeiculo cv = CategoriaVeiculoDAO.BuscarCategoriaPorId(txtId);

            cv.Tamanho = txtTamanho;
            cv.Valor = dValor;

            CategoriaVeiculoDAO.AlterarCategoria(cv);
            //ViewBag.Veiculos = VeiculoDAO.BuscarVeiculoPorId(id);
            return RedirectToAction("IndexCategoria", "Veiculo");

        }
    }

    }
