using Aplication.Features.Lojas;
using Domain.Features.Lojas;
using EstudoWebService.Controllers.Comum;
using Infra.Data.Features.Clientes;
using Infra.Data.Features.Contexto;
using Infra.Data.Features.Lojas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace EstudoWebService.Controllers.Lojas
{
    public class LojaController : ApiControllerBase
    {
        public ILojaService _lojaService;

        public LojaController(ILojaService lojaService)
        {
            _lojaService = lojaService;
        }

        public LojaController() : base()
        {
            var contexto = new WebContexto();
            var _repositoryLoja = new LojaRepository(contexto);
            var _repositoryCliente = new ClienteRepositorio(contexto);
            _lojaService = new LojaService(_repositoryLoja, _repositoryCliente);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var query = _lojaService.GetAll();

            return HandleQueryable<Loja>(query);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _lojaService.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Post(Loja loja)
        {
            return HandleCallback(() => _lojaService.Add(loja));
        }

        [HttpPut]
        public IHttpActionResult Update(Loja loja)
        {
            return HandleCallback(() => _lojaService.Update(loja));
        }

        [HttpDelete]
        public IHttpActionResult Delete(Loja loja)
        {
            return HandleCallback(() => _lojaService.Remove(loja));
        }
    }
}
