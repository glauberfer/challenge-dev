using System.Collections.Generic;
using Challenge.BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Challenge.Controllers
{
    [Produces("application/json")]
    [Route("api/Carro")]
    public class CarroController : Controller
    {
        private CarroBLL bll;

        public CarroController()
        {
            bll = new CarroBLL();
        }

        // GET: api/Carro
        [HttpGet]
        public IEnumerable<Carro> Get()
        {
            return bll.Listar();
        }

        // GET: api/Carro/5
        [HttpGet("{id}", Name = "GetCarro")]
        public Carro Get(int id)
        {
            return bll.Buscar(id);
        }
        
        // POST: api/Carro
        [HttpPost]
        public void Post([FromBody]Carro model)
        {
            bll.Adicionar(model);
        }
        
        // PUT: api/Carro
        [HttpPut]
        public void Put([FromBody]Carro model)
        {
            bll.Atualizar(model);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bll.Deletar(id);
        }
    }
}
