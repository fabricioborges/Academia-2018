using Aplication.Features.Clientes;
using Domain.Features.Clientes;
using EstudoWebService.Controllers.Comum;
using Infra.Data.Features.Clientes;
using Infra.Data.Features.Contexto;
using System.Web.Http;

namespace EstudoWebService.Controllers.Clientes
{
    public class ClienteController : ApiControllerBase
    {
        public IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public ClienteController()
        {
            var contexto = new WebContexto();
            var repositorio = new ClienteRepositorio(contexto);
            _clienteService = new ClienteService(repositorio);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var query = _clienteService.GetAll();

            return HandleQueryable<Cliente>(query);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _clienteService.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Post(Cliente cliente)
        {
            return HandleCallback(() => _clienteService.Add(cliente));
        }

        [HttpPut]
        public IHttpActionResult Update(Cliente cliente)
        {
            return HandleCallback(() => _clienteService.Update(cliente));
        }

        [HttpDelete]
        public IHttpActionResult Delete(Cliente cliente)
        {
            return HandleCallback(() => _clienteService.Remove(cliente));
        }
    }
}
