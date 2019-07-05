using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoFinal.Controllers
{
    public class SetorController : Controller
    {
        // GET: Setor
        public ActionResult Index()
        {
            ViewBag.Setores = SetorDAO.RetornarSetor();
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(string txtNome)
        {
            Setor s = new Setor()
            {
                Nome = txtNome
            };
            SetorDAO.CadastrarSetor(s);
            return RedirectToAction("Index", "Setor");
        }
        public ActionResult Remover(int? id)
        {
            SetorDAO.RemoverSetor(SetorDAO.BuscarSetorPorId(id));
            return RedirectToAction("Index", "Setor");
        }
    
        public ActionResult Alterar(int? id)
        {
            ViewBag.Setores = SetorDAO.BuscarSetorPorId(id);
            return View();
        }
        [HttpPost]
        public ActionResult Alterar(int txtId, string txtNome)
        {
            Setor s = SetorDAO.BuscarSetorPorId(txtId);
            s.Nome = txtNome;
            SetorDAO.AlterarSetor(s);
            return RedirectToAction("Index", "Setor");
        }
    }
}