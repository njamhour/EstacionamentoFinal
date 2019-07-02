using EstacionamentoFinal.DAL;
using EstacionamentoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EstacionamentoFinal.Controllers
{
    [RoutePrefix("api/Vaga")]
    public class VagaAPIController : ApiController
    {
        [Route("Vagas")]
        public List<Vaga> GetVagas()
        {
            return VagasDAO.RetornarVagas();
        }

        [Route("VagasLivre")]
        public List<Vaga> GetVagasLivre()
        {
            return VagasDAO.RetornarVagasLivres();
        }

        [HttpGet]
        [Route("VagaStatus/{id}")]
        public IHttpActionResult VagaStatus(int id)
        {
            Vaga v = VagasDAO.BuscarVagaPorId(id);
                
                if (v != null)
                {
                    return Ok(v);
                }
           return NotFound();
        }

        }
    }

