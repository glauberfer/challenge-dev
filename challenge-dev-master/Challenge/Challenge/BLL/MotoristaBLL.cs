using Challenge.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Challenge.BLL
{
    public class MotoristaBLL
    {
        private MotoristaDAO dao;

        public MotoristaBLL()
        {
            dao = new MotoristaDAO();
        }

        public async System.Threading.Tasks.Task AdicionarAsync(Motorista model)
        {
            model.EnderecoMaps = await EnderecoMapsAsync(model.Endereco);
            dao.Adicionar(model);
        }

        public async System.Threading.Tasks.Task AtualizarAsync(Motorista model)
        {
            model.EnderecoMaps = await EnderecoMapsAsync(model.Endereco);
            dao.Atualizar(model);
        }

        public void Deletar(int id)
        {
            dao.Deletar(id);
        }

        public Motorista Buscar(int id)
        {
            return dao.Buscar(id);
        }

        public List<Motorista> Listar()
        {
            return dao.Listar();
        }

        public async System.Threading.Tasks.Task<string> EnderecoMapsAsync(string endereco)
        {
            string baseUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + endereco + "&key=AIzaSyCcdf6zBzL6J9Qs98cP1tN3NJJZLRRShGY";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                    return data;
                return string.Empty;
            }
        }
    }
}
