using System.Collections.Generic;
using Challenge.BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Challenge.Controllers
{
    [Produces("application/json")]
    [Route("api/Motorista")]
    public class MotoristaController : Controller
    {
        private MotoristaBLL bll;

        public MotoristaController()
        {
            bll = new MotoristaBLL();
        }

        // GET: api/Motorista
        [HttpGet]
        public IEnumerable<Motorista> Get()
        {
            return bll.Listar();
        }

        // GET: api/Motorista/5
        [HttpGet("{id}", Name = "GetMotorista")]
        public Motorista Get(int id)
        {
            return bll.Buscar(id);
        }
        
        // POST: api/Motorista
        [HttpPost]
        public async System.Threading.Tasks.Task PostAsync([FromBody]Motorista model)
        {
            await bll.AdicionarAsync(model);
        }
        
        // PUT: api/Motorista/5
        [HttpPut]
        public async System.Threading.Tasks.Task PutAsync([FromBody]Motorista model)
        {
            await bll.AtualizarAsync(model);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bll.Deletar(id);
        }

    }
}
